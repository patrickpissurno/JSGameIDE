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

namespace JSGameIDE
{
    public static class Builder
    {
        /// <summary>
        /// This method is used to export the game.
        /// </summary>
        /// <param name="skipAlert">If true the builder wouldn't show any alert</param>
        /// <returns>Returns true if successful. Otherwise returns false.</returns>
        public static bool Build(bool skipAlert = false)
        {
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
                data += BuildHeader();
                data += BuildSprites();
                data += BuildObjects();
                data += BuildRooms();
                data += BuildNativeFunctions();
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
            string _d = "<HTML>";
            _d += "<body>";
            _d += "<center>";
            _d += "<canvas id='gameCanvas' width='" + GameConfig.viewWidth +  "' height='" + GameConfig.viewHeight + "' style='border:1px solid #000'>";
            _d += "</canvas>";
            _d += "</center>";
            _d += "<script src='game.js'>";
            _d += "</script>";
            _d += "</body>";
            _d += "</HTML>";
            return _d;
        }

        /// <summary>
        /// This method is used to build the header of the JS game. 
        /// </summary>
        /// <returns>Returns it as a string.</returns>
        private static string BuildHeader()
        {
            string _d = "";
            _d += "var map = {width:" + GameConfig.width + ", height: "+ GameConfig.height + "};";
            _d += "var canvas = document.getElementById('gameCanvas');";
            _d += "var context = canvas.getContext('2d');";
            _d += "var start = (new Date()).getTime();";
            _d += "var currentFrame=0;";
            _d += "function deltaTime(){current = (new Date()).getTime();elapsed = current - start;start = current;var delta = elapsed / 1000;return delta;};";
            _d += "function updateFrame(){if(document.hasFocus()){currentFrame += deltaTime() * 60;if(currentFrame>1){loop();currentFrame-=1;}}else deltaTime();setTimeout(updateFrame, 0);};";
            _d += "function drawText(x,y,text,f,c,align){context.fillStyle = c;context.font = f; context.textAlign = align; context.fillText(text,-roomManager.actual.camera.x + x,-roomManager.actual.camera.y + y);};";
            _d += "function drawRect(x,y,w,h,r,g,b,onlyStroke){if(!onlyStroke){context.fillStyle = 'rgba('+r+','+g+','+b+', 1)';context.fillRect(x,y,w,h);}else {context.strokeStyle = 'rgba('+r+','+g+','+b+', 1)';context.strokeRect(x,y,w,h);}};";
            _d += "function drawSprite(x,y,sprite,angle){context.drawImage(sprite,-roomManager.actual.camera.x + x,-roomManager.actual.camera.y + y);};";
            _d += "var mousePrefab = function(){this.x = 0;this.y = 0;this.pressed = false;};";
            _d += "var mousePressed = function(e){if(e.button == 0){e.preventDefault();mouse.pressed=true;}};";
            _d += "var mouseReleased = function(e){e.preventDefault();mouse.pressed=false;};";
            _d += "function getMouse(e){rect = canvas.getBoundingClientRect();if((Math.floor(e.clientX - rect.left) >= 0) && (Math.floor(e.clientX - rect.left) <= canvas.width) && (Math.floor(e.clientY - rect.top) >= 0) && (Math.floor(e.clientY - rect.top) <= canvas.height)){mouse.x=Math.floor(e.clientX - rect.left);mouse.y=Math.floor(e.clientY - rect.top);}};addEventListener('mousedown', mousePressed, true);addEventListener('mouseup', mouseReleased, true);addEventListener('mousemove', function(e){getMouse(e)}, false);";
            _d += "function randomRange (min, max) {return Math.floor(Math.random() * (max - min + 1)) + min;};";
            _d += "function checkCollision(a,b) {return !(((a.y+a.height) < (b.y)) ||(a.y > (b.y+b.height)) ||((a.x+a.width) < b.x) ||(a.x > (b.x+b.width)));};";
            _d += "var keyPressed = function(e){roomManager.actual.keyPressed(e);if(e.keyCode == 32)e.preventDefault();};";
            _d += "var keyReleased = function(e){roomManager.actual.keyReleased(e);};";
            _d += "addEventListener('keydown', keyPressed, true);";
            _d += "addEventListener('keyup', keyReleased, true);";
            _d += "var global = {};";
            _d += "var camera = function(){this.x=0; this.y=0; this.width = "+ GameConfig.viewWidth +"; this.height = "+ GameConfig.viewHeight +";};";
            return _d;
        }

        /// <summary>
        /// This method is used to build the sprites of the JS game. 
        /// </summary>
        /// <returns>Returns them as a string.</returns>
        private static string BuildSprites()
        {
            string _d = "var sprImport = function(){";
            foreach (Sprite sprite in Sprites.sprites)
            {
                if (sprite != null)
                {
                    _d += "this.sprite" + sprite.id + " = new Image();";
                    string _sprpath = GameConfig.path + @"\" + sprite.path;
                    File.Copy(_sprpath, GameConfig.path + @"\Build\IMG\" + Path.GetFileName(_sprpath), true);
                    _d += "this.sprite" + sprite.id + ".src = 'IMG/" + Path.GetFileName(_sprpath) + "';";
                }
            }
            _d += "};";
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
                    if (obj.sprite != -1)
                    {
                        _d += "this.height = sprite.sprite" + obj.sprite + ".height;";
                        _d += "this.width = sprite.sprite" + obj.sprite + ".width;";
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
                    _d += "this.update = function(){if(!this._create_executed){this.create();this._create_executed=true;};if(this.toDestroy){this.destroy();};" + replaceCode(obj.onUpdate) + "this.x+=this.hspeed;this.y+=this.vspeed;};";
                    _d += "this.draw = function(){if(this.sprite!=null&&this.autoDraw){drawSprite(this.x,this.y,this.sprite);};" + replaceCode(obj.onDraw) + "};";
                    _d += "this.keyPressed = function(event){" + replaceCode(obj.onKeyPressed) + "};";
                    _d += "this.keyReleased = function(event){" + replaceCode(obj.onKeyReleased) + "};";
                    _d += "this.destroy = function(){if(!this.toDestroy){this.toDestroy=true;} else{" + replaceCode(obj.onDestroy) + "for(var i=0; i<roomManager.actual['obj" + obj.id + "'].length; i++){if(roomManager.actual['obj" + obj.id + "'][i] == this){roomManager.actual['obj" + obj.id + "'].splice(i,1);break;};};};};";
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
            _d += "instance_create = function(x,y,e){var _i = new e(); _i.x = x; _i.y=y; roomManager.actual[_i.name].push(_i);return _i;};";
            _d += "var fps = {startTime : 0,frameNumber : 0,get : function(){this.frameNumber++;var d = new Date().getTime(),currentTime = ( d - this.startTime ) / 1000, result = Math.floor( ( this.frameNumber / currentTime ) );if( currentTime > 1 ){this.startTime = new Date().getTime();this.frameNumber = 0;}return result;}};";
            _d += "check_collision_object = function(me,other,todo){";
	        _d += "o_arr = [];";
	        _d += "for(i=0;i<roomManager.actual[other].length;i++)";
	        _d += "{";
		    _d += "if(checkCollision(me,roomManager.actual[other][i]))";
		    _d += "{";
			_d += "o_arr.push(i);";
		    _d += "};";
	        _d += "};";
	        _d += "o_arr.forEach(todo);";
            _d += "};";
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
