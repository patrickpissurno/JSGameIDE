/*
    <JSGameIDE - An open-source IDE+Library to Javascript Game Development>
    Copyright (C) 2015  Patrick Pissurno

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, version 3, except for commercial usage,
    which is strictly FORBIDDEN.
   
    COMMERCIAL USAGE IS STRICTLY FORBIDDEN!
    
    If you're going to distribute a version of this program you need to
    keep this commentary in all the classes of it, and also you  should
    mantain it open source and under the same  terms  of  the  original
    version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See  the
    GNU General Public License for more details.

    You should have received a copy of  the  GNU  General Public  License
    along with this program.  If  not, see <http://www.gnu.org/licenses/>.
  
    For further  details see: http://patrickpissurno.github.io/JSGameIDE/
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace JSGameIDE
{
    public static class Builder
    {
        public static readonly string LibraryPath = Application.StartupPath + @"\Library";
        public static string[] PreprocessorTags;
        public static string[] PreprocessorValues;

        /// <summary>
        /// Replaces preprocessor tags with their values
        /// </summary>
        /// <param name="str">The input string</param>
        /// <param name="tags">Preprocessor tags</param>
        /// <param name="values">Values that are going to replace the tags</param>
        /// <returns></returns>
        public static string PreprocessorReplacer(string str, string[] tags, string[] values)
        {
            for (int i = 0; i < tags.Length; i++)
                str = str.Replace(tags[i], values[i]);
            return str;
        }

        public static string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
        }

        private static void PreprocessorDefine()
        {
            PreprocessorTags = new string[] {
                "$viewWidth",
                "$viewHeight",
                "$gameWidth",
                "$gameHeight"
            };
            PreprocessorValues = new string[]{
                GameConfig.viewWidth.ToString(),
                GameConfig.viewHeight.ToString(),
                GameConfig.width.ToString(),
                GameConfig.height.ToString()
            };
        }

        /// <summary>
        /// This method is used to export the game.
        /// </summary>
        /// <param name="skipAlert">If true the builder wouldn't show any alert</param>
        /// <returns>Returns true if successful. Otherwise returns false.</returns>
        public static bool Build(bool skipAlert = false)
        {
            PreprocessorDefine();
            FileManager.ReloadCode();
            string data = "";
            try
            {
                Directory.CreateDirectory(GameConfig.path + @"\Build\IMG");
                data += BuildHTML();
                using (StreamWriter outfile = new StreamWriter(GameConfig.path + @"\Build\index.html"))
                {
                    outfile.Write(data);
                }
                data = "";
                data += BuildHeader() + Environment.NewLine + Environment.NewLine;
                data += BuildSprites() + Environment.NewLine + Environment.NewLine;
                data += BuildScripts() + Environment.NewLine + Environment.NewLine;
                data += BuildObjects() + Environment.NewLine + Environment.NewLine;
                data += BuildRooms() + Environment.NewLine + Environment.NewLine;
                data += BuildNativeFunctions() + Environment.NewLine + Environment.NewLine;
                data += BuildFooter();
                using (StreamWriter outfile = new StreamWriter(GameConfig.path + @"\Build\game.js"))
                {
                    outfile.Write(data);
                }
                if (!skipAlert)
                    MessageBox.Show("Exported successfully!");
                return true;
            }
            catch
            {
                MessageBox.Show("Exportation error.");
                return false;
            }
        }

        /// <summary>
        /// This method is used to build the basic HTML page. 
        /// </summary>
        /// <returns>Returns it as a string.</returns>
        private static string BuildHTML()
        {
            string _d = File.ReadAllText(LibraryPath + @"\default.html");
            _d = PreprocessorReplacer(_d, PreprocessorTags, PreprocessorValues);
            return _d;
        }

        /// <summary>
        /// This method is used to build the header of the JS game. 
        /// </summary>
        /// <returns>Returns it as a string.</returns>
        private static string BuildHeader()
        {
            string _d = File.ReadAllText(LibraryPath + @"\header.js");
            _d = PreprocessorReplacer(_d, PreprocessorTags, PreprocessorValues);
            return _d;
        }

        /// <summary>
        /// This method is used to build the sprites of the JS game. 
        /// </summary>
        /// <returns>Returns them as a string.</returns>
        private static string BuildSprites()
        {
            string _i = File.ReadAllText(LibraryPath + @"\sprites.js");
            _i = PreprocessorReplacer(_i, PreprocessorTags, PreprocessorValues);

            string _d = _i.Substring(0, _i.IndexOf("#FOREACH Sprite"));
            foreach (Sprite sprite in Sprites.sprites)
            {
                if (sprite != null && sprite.path != null)
                {
                    DirectoryExtension.Copy(GameConfig.path + @"\Resources\IMG\spr" + sprite.id, GameConfig.path + @"\Build\IMG\spr" + sprite.id, false);
                    
                    int _fsi = _i.IndexOf("#FOREACH Sprite") + 15;
                    _d += PreprocessorReplacer(_i.Substring(_fsi, _i.IndexOf("#FOREACH Frame") - _fsi),
                        new string[] { "$spriteId" }, new string[] { sprite.id.ToString() });

                    for (int i = 0; i < sprite.path.Length; i++)
                    {
                        int _ffi = _i.IndexOf("#FOREACH Frame", _fsi) + 14;
                        _d += PreprocessorReplacer(_i.Substring(_ffi, _i.IndexOf("#END") - _ffi),
                            new string[] { "$spriteId", "$frameId", "$framePath"},
                            new string[] { sprite.id.ToString(), i.ToString(),  "'IMG/spr" + sprite.id +"/"+i+Path.GetExtension(sprite.path[i])+"'"});
                    }

                    _fsi = _i.IndexOf("#END", _fsi) + 4;
                    _d += PreprocessorReplacer(_i.Substring(_fsi, _i.IndexOf("#END", _fsi) - _fsi),
                        new string[] { "$spriteId" }, new string[] { sprite.id.ToString() });
                }
            }
            int _le = _i.LastIndexOf("#END") + 4;
            _d += _i.Substring(_le, _i.Length - _le);
            //_d = RemoveEmptyLines(_d);
            //MessageBox.Show(_d);
            return _d.Trim();
        }

        /// <summary>
        /// This method is used to build the scripts of the JS game. 
        /// </summary>
        /// <returns>Returns them as a string.</returns>
        private static string BuildScripts()
        {
            string _d = "";
            foreach (Script script in Scripts.scripts)
            {
                if (script != null)
                {
                    _d += replaceCode(script.data);
                }
            }
            return _d;
        }

        /// <summary>
        /// This method is used to build the rooms of the JS game. 
        /// </summary>
        /// <returns>Returns them as a string.</returns>
        private static string BuildRooms()
        {
            string _d = "var rM = function(){";
            _d += "this.last = {keyboardEnabled:false,update:function(){},draw:function(){}};this.camera = new camera();";
            _d += "this.actual = this.last;";
            _d += "this.change=true;";
            _d += "this.alpha = 0;";
            if (Rooms.rooms[Rooms.firstId] != null)
                _d += "this.room2go = new Room" + Rooms.firstId + "();";
            else
                MessageBox.Show("You need to create at least one room");
            _d += "this.go = function(e){this.last = this.actual;this.room2go = e;this.alpha = 0;this.change=true;};";
            _d += "this.update = function(){";
            _d += "if(!this.change)this.actual.update();else{";
            _d += "if(this.alpha<1 && this.actual != this.room2go)this.alpha+=0.1;";
            _d += "else if(this.alpha>=1 && this.actual != this.room2go)this.actual = this.room2go;";
            _d += "else if(this.alpha>0 && this.actual == this.room2go)this.alpha-=0.1;";
            _d += "else{this.alpha=0;this.change = false;}}};";
            _d += "this.draw = function(){this.actual.draw();if(this.change){if(this.alpha>1)this.alpha=1;else if(this.alpha<0)this.alpha=0;context.globalAlpha = this.alpha;drawRect(0,0,canvas.width,canvas.height,0,0,0,0);context.globalAlpha = 1;}}};";


            foreach (Room room in Rooms.rooms)
            {
                if(room!=null)
                {
                    _d += "var Room"+room.id+" = function(){";
                    string _oc="", _ou="", _od="", _okp="", _okr="", _oec = "";
                    foreach (Object obj in Objects.objects)
                    {
                        if (obj != null)
                        {
                            _d += "this.obj" + obj.id + "=[];";
                            _oc += "for(var i=0; i<this.obj" + obj.id + ".length; i++){if(this.obj" + obj.id + "[i]!=null){this.obj"+obj.id+"[i].create();};};";
                            _ou += "for(var i=0; i<this.obj" + obj.id + ".length; i++){if(this.obj" + obj.id + "[i]!=null){this.obj" + obj.id + "[i].update();};};";
                            _od += "for(var i=0; i<this.obj" + obj.id + ".length; i++){if(this.obj" + obj.id + "[i]!=null){this.obj" + obj.id + "[i].draw();};};";
                            _okp += "for(var i=0; i<this.obj" + obj.id + ".length; i++){if(this.obj" + obj.id + "[i]!=null){this.obj" + obj.id + "[i].keyPressed(event);};};";
                            _okr += "for(var i=0; i<this.obj" + obj.id + ".length; i++){if(this.obj" + obj.id + "[i]!=null){this.obj" + obj.id + "[i].keyReleased(event);};};";
                        }
                    }

                    foreach (EditorObject obj in room.editorCreate)
                    {
                        if (obj != null)
                            _oec += "instance_create(" + obj.x + "," + obj.y + "," + Objects.objects[obj.id].name + ");";
                    }

                    _d += "this._create_executed=false;";
                    _d += "this.camera = new camera();";
                    
                    //Room create event
                    _d += "this.create = function(){";
                    _d +=       replaceCode(room.onCreate) + replaceCode(_oec) + _oc;
                    _d += "};";

                    //Room update event
                    _d += "this.update = function(){";
                    _d +=       "if(!this._create_executed){";
                    _d +=           "this.create();";
                    _d +=           "this._create_executed=true;";
                    _d +=       "};";
                    _d +=       replaceCode(room.onUpdate) + _ou;
                    _d += "};";

                    _d += "this.draw = function(){" + replaceCode(room.onDraw) + _od + "};";
                    _d += "this.keyPressed = function(event){" + replaceCode(room.onKeyPressed) + _okp + "};";
                    _d += "this.keyReleased = function(event){" + replaceCode(room.onKeyReleased) + _okr + "};";
                    _d += "};";
                }
            }
            return _d;
        }

        /// <summary>
        /// This method is used to build the objects of the JS game. 
        /// </summary>
        /// <returns>Returns them as a string.</returns>
        private static string BuildObjects()
        {
            string _d = "";
            foreach (Object obj in Objects.objects)
            {
                if (obj != null)
                {
                    _d += "var obj" + obj.id + " = function(){";
                    _d += "this.name='obj" + obj.id + "';";
                    _d += "this._this = this;";
                    _d += "this.toDestroy=false;";
                    _d += "this.x = 0;";
                    _d += "this.y = 0;";
                    _d += "this.pressed = false;";
                    _d += "this.alpha = 1;";
                    _d += "this.angle = 0;";
                    _d += "this.imageIndex = 0;";
                    _d += "this.imageSpeed = 1;";
                    if (obj.sprite != -1)
                    {
                        _d += "this.height = sprite.sprite" + obj.sprite + "[this.imageIndex].height;";
                        _d += "this.width = sprite.sprite" + obj.sprite + "[this.imageIndex].width;";
                    }
                    else
                    {
                        _d += "this.width = 0;";
                        _d += "this.height = 0;";
                    }
                    _d += "this.hspeed = 0;";
                    _d += "this.vspeed = 0;";
                    _d += "this.autoDraw = " + (obj.autoDraw.ToString()).ToLower() + ";";
                    if (obj.sprite != -1)
                        _d += "this.sprite = sprite.sprite" + obj.sprite + ";";
                    else
                        _d += "this.sprite = null;";
                    _d += "this._create_executed=false;";
                    _d += "this.create = function(){" + replaceCode(obj.onCreate) + "};";
                    _d += "this.update = function(){if(!this._create_executed){this.create();this._create_executed=true;};if(this.pressed && !mouse.pressed){this.pressed=false;"+ replaceCode(obj.onMouseReleased) +"};if(mouse.pressed && roomManager.actual.camera.x + mouse.x > this.x  && roomManager.actual.camera.x + mouse.x < this.x + this.width && roomManager.actual.camera.y + mouse.y > this.y && roomManager.actual.camera.y + mouse.y < this.y + this.height){this.pressed=true;"+ replaceCode(obj.onMousePressed) +"};if(this.toDestroy){this.destroy();};" + replaceCode(obj.onUpdate) + "this.x+=this.hspeed;this.y+=this.vspeed;};";
                    _d += "this.draw = function(){this.fixData();this.animator();if(this.sprite!=null&&this.autoDraw){context.globalAlpha = this.alpha; drawSpriteExt(this.x,this.y,this.width,this.height,this.sprite[Math.round(this.imageIndex)],this.angle); context.globalAlpha=1;};" + replaceCode(obj.onDraw) + "};";
                    _d += "this.keyPressed = function(event){" + replaceCode(obj.onKeyPressed) + "};";
                    _d += "this.keyReleased = function(event){" + replaceCode(obj.onKeyReleased) + "};";
                    _d += "this.mousePressed = function(){" + replaceCode(obj.onMousePressed) + "};";
                    _d += "this.mouseReleased = function(){" + replaceCode(obj.onMouseReleased) + "};";
                    _d += "this.destroy = function(){if(!this.toDestroy){this.toDestroy=true;} else{" + replaceCode(obj.onDestroy) + "for(var i=0; i<roomManager.actual['obj" + obj.id + "'].length; i++){if(roomManager.actual['obj" + obj.id + "'][i] == this){roomManager.actual['obj" + obj.id + "'].splice(i,1);break;};};};};";
                    _d += "this.fixData = function(){while(this.imageIndex<0)this.imageIndex+=this.sprite.length-1;while(this.imageIndex > this.sprite.length-1)this.imageIndex -= this.sprite.length-1;if(this.alpha>1)this.alpha=1;if(this.alpha<0)this.alpha=0;while(this.angle>360)this.angle-=360;while(this.angle<0)this.angle+=360;};";
                    _d += "this.animator = function(){if(this.imageIndex<this.sprite.length-1)this.imageIndex+=this.imageSpeed/10;else this.imageIndex=0;};";
                    _d += "};";
                }
            }
            return _d;
        }

        /// <summary>
        /// This method is used to build the footer of the JS game. 
        /// </summary>
        /// <returns>Returns the footer as a string.</returns>
        private static string BuildFooter()
        {
            string _d = "function loop(){roomManager.update();roomManager.draw();};";
            _d += "var mouse = new mousePrefab();";
            _d += "var roomManager = new rM();";
            _d += "var sprite = new sprImport();";
            _d += "updateFrame();";
            return _d;
        }

        /// <summary>
        /// This method is used to build the native functions of the JS library. 
        /// </summary>
        /// <returns>Returns them as a string.</returns>
        private static string BuildNativeFunctions()
        {
            string _d = "";
            //Instance Create
            _d += "instance_create = function(x,y,e){var _i = new e(); _i.x = x; _i.y=y; roomManager.actual[_i.name].push(_i);return _i;};";
            //Fps
            _d += "var fps = {startTime : 0,frameNumber : 0,get : function(){this.frameNumber++;var d = new Date().getTime(),currentTime = ( d - this.startTime ) / 1000, result = Math.floor( ( this.frameNumber / currentTime ) );if( currentTime > 1 ){this.startTime = new Date().getTime();this.frameNumber = 0;}return result;}};";
            //Check Collision
            _d += "check_collision_object = function(me,other,todo){for(i=0;i<roomManager.actual[other].length;i++){if(checkCollision(me,roomManager.actual[other][i])){todo.bind(me)(roomManager.actual[other][i]);};};};";
            //Draw Set Alpha
            _d += "draw_set_alpha = function(alpha){if(alpha>1)alpha=1;else if(alpha<0)alpha=0;context.globalAlpha = alpha;};";
            return _d;
        }

        /// <summary>
        /// This method is used to replace some words into another ones. (It's needed for any user input code).
        /// </summary>
        /// <param name="str">The string which will have the words replaced</param>
        /// <returns>Returns the fixed string</returns>
        private static string replaceCode(string str)
        {
            str = str.Replace(System.Environment.NewLine, " ");
            str = str.Replace("var", " ");
            str = str.Replace("room_goback()", "roomManager.go(roomManager.last)");
            str = str.Replace("room_actual", "roomManager.actual");
            str = str.Replace("room_goto(", "roomManager.go(new ");
            str = str.Replace("gameFPS", "fps.get()");
            str = str.Replace("screen_clear()", "context.clearRect(0,0,canvas.width,canvas.height)");
            foreach (Sprite spr in Sprites.sprites)
            {
                if(spr!=null)
                    str = str.Replace(spr.name, "sprite.sprite"+spr.id);
            }
            foreach (Room rm in Rooms.rooms)
            {
                if(rm!=null)
                    str = str.Replace(rm.name, "Room" + rm.id);
            }
            foreach (Object obj in Objects.objects)
            {
                if (obj != null)
                {
                    str = str.Replace(obj.name, "obj" + obj.id);
                }
            }
            foreach (string vk in KeyCode.keyCodes.Keys)
            {
                str = str.Replace(vk, ""+KeyCode.keyCodes[vk]);
            }
            return str;
        }
    }
}
