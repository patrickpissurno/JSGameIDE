﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
        ///    &lt;body&gt;
        ///        &lt;center&gt;
        ///            &lt;canvas id=&apos;gameCanvas&apos; width=&apos;$viewWidth&apos; height=&apos;$viewHeight&apos; style=&apos;border:1px solid #000&apos;&gt;
        ///            &lt;/canvas&gt;
        ///        &lt;/center&gt;
        ///        &lt;script src=&apos;game.js&apos;&gt;
        ///        &lt;/script&gt;
        ///    &lt;/body&gt;
        ///&lt;/html&gt;.
        /// </summary>
        internal static string _default {
            get {
                return ResourceManager.GetString("_default", resourceCulture);
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
        /////Delta Time Function
        ///function deltaTime()
        ///{
        ///    current = (new Date()).getTime();
        ///    elapsed = current - start;
        ///    start = current;
        ///    var delta = elapsed / 1000;
        ///    return delta;
        ///};
        ///
        /////Update Frame Function
        ///function updateFrame()
        ///{
        ///    if(document.hasFo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string header {
            get {
                return ResourceManager.GetString("header", resourceCulture);
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
        ///updateFrame();.
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
        ///        this.pressed = false;
        ///        this.alpha = 1;
        ///        this.angle = 0;
        ///        this.imageIndex = 0;
        ///        this.imageSpeed = 1;
        ///        this.width = $objectWidth;
        ///        this.height = $objectHeight;
        ///        this.hspeed = 0;
        ///        this.vspeed = 0;
        ///        this.autoDraw = $objectAutoDraw;
        ///     [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string objects {
            get {
                return ResourceManager.GetString("objects", resourceCulture);
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
