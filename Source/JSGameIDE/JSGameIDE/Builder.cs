/*
    <JSGameIDE - An open-source IDE+Framework to Javascript Game Development>
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
        public static readonly string LibraryPath = Application.StartupPath + @"\Resources";
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
            if (Rooms.rooms[Rooms.firstId] == null)
            {
                MessageBox.Show("You need to create at least one room");
                throw new Exception();
            }

            string _i = File.ReadAllText(LibraryPath + @"\rooms.js");
            _i = PreprocessorReplacer(_i, PreprocessorTags, PreprocessorValues);

            string _d = _i.Substring(0, _i.IndexOf("#FOREACH Room"));

            foreach (Room room in Rooms.rooms)
            {
                if(room!=null)
                {
                    List<string> pTags = new List<string>();
                    List<string> pValues = new List<string>();

                    pTags.AddRange(new string[] { "$roomFirstId", "$roomId" });
                    pValues.AddRange(new string[] { Rooms.firstId.ToString(), room.id.ToString() });

                    string ObjectCreates, ObjectUpdates, ObjectDraws, ObjectKeyPresseds, ObjectKeyReleaseds;
                    int _o, _o2;

                    _o = _i.IndexOf("#DEFINE ObjectCreates") + 21;
                    _o2 = _i.IndexOf("#END", _o) - _o;
                    ObjectCreates = _i.Substring(_o, _o2);
                    _i = _i.Replace(_i.Substring(_o - 21, _o2 + 21 + 4), "");

                    _o = _i.IndexOf("#DEFINE ObjectUpdates") + 21;
                    _o2 = _i.IndexOf("#END", _o) - _o;
                    ObjectUpdates = _i.Substring(_o, _o2);
                    _i = _i.Replace(_i.Substring(_o - 21, _o2 + 21 + 4), "");

                    _o = _i.IndexOf("#DEFINE ObjectDraws") + 19;
                    _o2 = _i.IndexOf("#END", _o) - _o;
                    ObjectDraws = _i.Substring(_o, _o2);
                    _i = _i.Replace(_i.Substring(_o - 19, _o2 + 19 + 4), "");

                    _o = _i.IndexOf("#DEFINE ObjectKeyPresseds") + 25;
                    _o2 = _i.IndexOf("#END", _o) - _o;
                    ObjectKeyPresseds = _i.Substring(_o, _o2);
                    _i = _i.Replace(_i.Substring(_o - 25, _o2 + 25 + 4), "");

                    _o = _i.IndexOf("#DEFINE ObjectKeyReleaseds") + 26;
                    _o2 = _i.IndexOf("#END", _o) - _o;
                    ObjectKeyReleaseds = _i.Substring(_o, _o2);
                    _i = _i.Replace(_i.Substring(_o - 26, _o2 + 26 + 4), "");

                    _d = _d.TrimEnd() + Environment.NewLine;

                    int _fsi = _i.IndexOf("#FOREACH Room") + 13;
                    _d += _i.Substring(_fsi, _i.IndexOf("#FOREACH Object") - _fsi).TrimEnd() + Environment.NewLine;

                    _d = PreprocessorReplacer(_d, pTags.ToArray(), pValues.ToArray());

                    string _oc="", _ou="", _od="", _okp="", _okr="", _oec = "";
                    foreach (Object obj in Objects.objects)
                    {
                        if (obj != null)
                        {
                            string[] _pTags = pTags.Concat(new string[] { "$objectId" }).ToArray();
                            string[] _pValues = pValues.Concat(new string[] { obj.id.ToString() }).ToArray();
                            int _ffi = _i.IndexOf("#FOREACH Object", _fsi) + 15;
                            _d += PreprocessorReplacer(_i.Substring(_ffi, _i.IndexOf("#END") - _ffi),
                                _pTags, _pValues).TrimEnd() + Environment.NewLine;

                            _oc += PreprocessorReplacer(ObjectCreates, _pTags, _pValues).TrimEnd() + Environment.NewLine;
                            _ou += PreprocessorReplacer(ObjectUpdates, _pTags, _pValues).TrimEnd() + Environment.NewLine;
                            _od += PreprocessorReplacer(ObjectDraws, _pTags, _pValues).TrimEnd() + Environment.NewLine;
                            _okp += PreprocessorReplacer(ObjectKeyPresseds, _pTags, _pValues).TrimEnd() + Environment.NewLine;
                            _okr += PreprocessorReplacer(ObjectKeyReleaseds, _pTags, _pValues).TrimEnd() + Environment.NewLine;
                        }
                    }

                    foreach (EditorObject obj in room.editorCreate)
                    {
                        if (obj != null)
                            _oec += "instance_create(" + obj.x + "," + obj.y + "," + Objects.objects[obj.id].name + ");\n\t\t\t";
                    }

                    _fsi = _i.IndexOf("#END", _fsi) + 4;
                    _d += PreprocessorReplacer(_i.Substring(_fsi, _i.IndexOf("#END", _fsi) - _fsi),
                        pTags.Concat(new string[] {
                            "$roomCreate",
                            "$roomUpdate",
                            "$roomDraw",
                            "$roomKeyPressed",
                            "$roomKeyReleased",
                            "$roomEditorCreate",
                            "$objectCreates",
                            "$objectUpdates",
                            "$objectDraws",
                            "$objectKeyPresseds",
                            "$objectKeyReleaseds"
                        }).ToArray(),
                        pValues.Concat(new string[] { 
                            replaceCode(room.onCreate),
                            replaceCode(room.onUpdate),
                            replaceCode(room.onDraw),
                            replaceCode(room.onKeyPressed),
                            replaceCode(room.onKeyReleased),
                            replaceCode(_oec),
                            _oc,
                            _ou,
                            _od,
                            _okp,
                            _okr
                        }).ToArray());
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
            string _i = File.ReadAllText(LibraryPath + @"\objects.js");
            _i = PreprocessorReplacer(_i, PreprocessorTags, PreprocessorValues);

            string _d = _i.Substring(0, _i.IndexOf("#FOREACH Object"));
            foreach (Object obj in Objects.objects)
            {
                if (obj != null)
                {
                    string sprite = obj.sprite != -1 ? "sprite.sprite" + obj.sprite : "null";
                    string width = obj.sprite != -1 ? "sprite.sprite" + obj.sprite + "[this.imageIndex].width" : "0";
                    string height = obj.sprite != -1 ? "sprite.sprite" + obj.sprite + "[this.imageIndex].height" : "0";
                    string autoDraw = (obj.autoDraw.ToString()).ToLower();
                    string[] pTags = new string[] {
                        "$objectId",
                        "$objectWidth",
                        "$objectHeight",
                        "$objectAutoDraw",
                        "$objectSprite",
                        "$objectCreate",
                        "$objectUpdate",
                        "$objectDraw",
                        "$objectKeyPressed",
                        "$objectKeyReleased",
                        "$objectDestroy",
                        "$objectMousePressed",
                        "$objectMouseReleased"
                    };
                    string[] pValues = new string[]
                    {
                        obj.id.ToString(),
                        width,
                        height,
                        autoDraw,
                        sprite,
                        replaceCode(obj.onCreate),
                        replaceCode(obj.onUpdate),
                        replaceCode(obj.onDraw),
                        replaceCode(obj.onKeyPressed),
                        replaceCode(obj.onKeyReleased),
                        replaceCode(obj.onDestroy),
                        replaceCode(obj.onMousePressed),
                        replaceCode(obj.onMouseReleased)
                    };
                    int _fsi = _i.IndexOf("#FOREACH Object") + 15;
                    _d += PreprocessorReplacer(_i.Substring(_fsi, _i.IndexOf("#END") - _fsi).TrimEnd() + Environment.NewLine, pTags, pValues);
                }
            }
            return PreprocessorReplacer(_d, PreprocessorTags, PreprocessorValues).TrimEnd() + Environment.NewLine;
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
