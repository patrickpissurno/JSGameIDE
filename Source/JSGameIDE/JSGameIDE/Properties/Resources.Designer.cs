﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JSGameIDE.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("JSGameIDE.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///    &lt;head&gt;
        ///        &lt;title&gt;$gameTitle&lt;/title&gt;
        ///        &lt;link rel=&apos;shortcut icon&apos; type=&apos;image/x-icon&apos; href=&apos;favicon.ico&apos; /&gt;
        ///        &lt;style&gt;
        ///            body
        ///            {
        ///                background-color: #47484B;
        ///                overflow: hidden;
        ///                color:white;
        ///                font-family:sans-serif;
        ///            }
        ///            canvas
        ///            {
        ///                background-color:white;
        ///                border-style: none;
        ///                box-shadow: 5px 5px 5px #333;
        ///      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _default {
            get {
                return ResourceManager.GetString("_default", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to room_goback()=roomManager.go(roomManager.last)
        ///room_actual=roomManager.actual
        ///room_goto(=roomManager.go(new 
        ///gameFPS=fps.get()
        ///screen_clear()=context.clearRect(0,0,canvas.width,canvas.height)
        ///vk_mouseLeft=0
        ///vk_mouseMiddle=1
        ///vk_mouseRight=2.
        /// </summary>
        internal static string alias {
            get {
                return ResourceManager.GetString("alias", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to var Box2D={};
        ///(function(F,G){function K(){}if(!(Object.prototype.defineProperty instanceof Function)&amp;&amp;Object.prototype.__defineGetter__ instanceof Function&amp;&amp;Object.prototype.__defineSetter__ instanceof Function)Object.defineProperty=function(y,w,A){A.get instanceof Function&amp;&amp;y.__defineGetter__(w,A.get);A.set instanceof Function&amp;&amp;y.__defineSetter__(w,A.set)};F.inherit=function(y,w){K.prototype=w.prototype;y.prototype=new K;y.prototype.constructor=y};F.generateCallback=function(y,w){return function(){w.apply( [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Box2d_min {
            get {
                return ResourceManager.GetString("Box2d_min", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to function loop()
        ///{
        ///    roomManager.update();
        ///    roomManager.draw();
        ///};
        ///var mouse = new mousePrefab();
        ///var roomManager = new rM();
        ///var sprite = new sprImport();
        ///var sound = new sndImport();
        ///updateFrame();.
        /// </summary>
        internal static string footer {
            get {
                return ResourceManager.GetString("footer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //Some basic variable definition
        ///var map = {width: $gameWidth, height: $gameHeight};
        ///var canvas = document.getElementById(&apos;gameCanvas&apos;);
        ///var context = canvas.getContext(&apos;2d&apos;);
        ///var start = (new Date()).getTime();
        ///var currentFrame=0;
        ///
        /////Physics
        ///var b2Vec = Box2D.Common.Math.b2Vec2;
        ///var b2BodyDef = Box2D.Dynamics.b2BodyDef;
        ///var b2Body = Box2D.Dynamics.b2Body;
        ///var b2FixtureDef = Box2D.Dynamics.b2FixtureDef;
        ///var b2Fixture = Box2D.Dynamics.b2Fixture;
        ///var b2World = Box2D.Dynamics.b2World;
        ///var b2MassD [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string header {
            get {
                return ResourceManager.GetString("header", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;style&gt;
        ///    body
        ///    {
        ///        background-color: #47484B;
        ///        overflow: hidden;
        ///        color:white;
        ///        font-family:sans-serif;
        ///    }
        ///    .center, .center2
        ///    {
        ///        position: absolute;
        ///        width: 100vw;
        ///        display: flex;
        ///        justify-content: center;
        ///        align-items: center;
        ///        text-shadow: .3vh .3vh .6vh #27282B;
        ///    }
        ///    .center
        ///    {
        ///        height: 94vh;
        ///        font-size: 6vh;
        ///    }
        ///    .center2
        ///    {
        ///        height: 106vh;
        ///        font-size: [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string livePreview {
            get {
                return ResourceManager.GetString("livePreview", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //Instance Create
        ///instance_create = function(x, y, e)
        ///{
        ///    var _i = new e();
        ///    _i.x = x;
        ///    _i.y = y;
        ///    roomManager.actual[_i.name].push(_i);
        ///    return _i;
        ///};
        ///
        /////FPS
        ///var fps = {
        ///    startTime : 0,
        ///    frameNumber : 0,
        ///    get : function(){
        ///        this.frameNumber++;
        ///        var d = new Date().getTime(),
        ///            currentTime = (d - this.startTime) / 1000,
        ///            result = Math.floor((this.frameNumber / currentTime));
        ///        if(currentTime &gt; 1)
        ///        {
        ///            this.s [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string nativeFunctions {
            get {
                return ResourceManager.GetString("nativeFunctions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #FOREACH Object
        ///    var obj$objectId = function()
        ///    {
        ///        this.name = &apos;obj$objectId&apos;;
        ///        this._this = this;
        ///        this.toDestroy = false;
        ///        this.x = 0;
        ///        this.y = 0;
        ///        this.pressed = [false, false, false];
        ///        this.alpha = 1;
        ///        this.angle = 0;
        ///        this.imageIndex = 0;
        ///        this.imageSpeed = 1;
        ///        this.width = $objectWidth;
        ///        this.height = $objectHeight;
        ///        this.hspeed = 0;
        ///        this.vspeed = 0;
        ///        this.autoDraw = $objec [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string objects {
            get {
                return ResourceManager.GetString("objects", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon player {
            get {
                object obj = ResourceManager.GetObject("player", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //Room Manager
        ///var rM = function()
        ///{
        ///    this.last = {
        ///        keyboardEnabled: false,
        ///        update: function(){},
        ///        draw: function(){}
        ///    };
        ///    
        ///    this.camera = new camera();
        ///    this.actual = this.last;
        ///    this.change = true;
        ///    this.alpha = 0;
        ///    this.room2go = new Room$roomFirstId();
        ///    
        ///    //Change room function
        ///    this.go = function(e)
        ///    {
        ///        this.last = this.actual;
        ///        this.room2go = e;
        ///        this.alpha = 0;
        ///        this.change=true;
        ///    };
        ///            /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string rooms {
            get {
                return ResourceManager.GetString("rooms", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to var sndImport = function()
        ///{
        ///    this.sounds = [];
        ///    #FOREACH Sound
        ///        this.sound$soundId = new Audio(&quot;$soundPath&quot;);
        ///        this.sound$soundId.preload = &quot;none&quot;;
        ///        this.sounds.push(this.sound$soundId);
        ///    #END
        ///}.
        /// </summary>
        internal static string sounds {
            get {
                return ResourceManager.GetString("sounds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to var sprImport = function()
        ///{
        ///    #FOREACH Sprite
        ///        this.sprite$spriteId = [];
        ///        #FOREACH Frame
        ///            this.sprite$spriteId[$frameId] = new Image();
        ///            this.sprite$spriteId[$frameId].src = $framePath;
        ///        #END
        ///    #END
        ///}.
        /// </summary>
        internal static string sprites {
            get {
                return ResourceManager.GetString("sprites", resourceCulture);
            }
        }
    }
}
