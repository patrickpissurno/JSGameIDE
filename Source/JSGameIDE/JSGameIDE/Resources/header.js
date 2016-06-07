//Some basic variable definition
var map = {width: $gameWidth, height: $gameHeight};
var canvas = document.getElementById('gameCanvas');
var context = canvas.getContext('2d');
var start = (new Date()).getTime();
var currentFrame=0;

Math.lerp = function (a,  b, f) {
    return (a * (1.0 - f)) + (b * f);
}

if(Box2D != null){
    //Physics
    var b2Vec = Box2D.Common.Math.b2Vec2;
    var b2BodyDef = Box2D.Dynamics.b2BodyDef;
    var b2Body = Box2D.Dynamics.b2Body;
    var b2FixtureDef = Box2D.Dynamics.b2FixtureDef;
    var b2Fixture = Box2D.Dynamics.b2Fixture;
    var b2World = Box2D.Dynamics.b2World;
    var b2MassData = Box2D.Collision.Shapes.b2MassData;
    var b2PolygonShape = Box2D.Collision.Shapes.b2PolygonShape;
    var b2CircleShape = Box2D.Collision.Shapes.b2CircleShape;
    var b2DebugDraw = Box2D.Dynamics.b2DebugDraw;

    var Physics = {
        Scale : 1.0 / 30,
        World : null,
        Start : function(gravityVector, allowSleep){
            this.World = new b2World(gravityVector, allowSleep);

            this.SetCollision();

            //Set debug draw
            var b2DebugDraw = Box2D.Dynamics.b2DebugDraw;
            var debugDraw = new b2DebugDraw();
            debugDraw.SetSprite(context);
            debugDraw.SetDrawScale(30.0);
            debugDraw.SetFillAlpha(0.3);
            debugDraw.SetLineThickness(1.0);
            debugDraw.SetFlags(b2DebugDraw.e_shapeBit | b2DebugDraw.e_jointBit);
            this.World.SetDebugDraw(debugDraw);
        },
        Shapes : {
            Box : function(width, height){
                var r = new b2PolygonShape();
                r.SetAsBox(width, height);
                return r;
            },
            Circle : function(radius){
                return new b2CircleShape(radius);
            }
        },
        BodyTypes : {
            Static : 0,
            Kinematic : 1,
            Dynamic : 2
        },
        CreateBody : function(type, x, y, shape, lockRotation, density, friction, restitution){
            var bodyDef = new b2BodyDef();
            bodyDef.type = type;
            bodyDef.position.x = x;
            bodyDef.position.y = y;
            bodyDef.fixedRotation = lockRotation;

            var fixDef = new b2FixtureDef();
            fixDef.density = density;
            fixDef.friction = friction;
            fixDef.restitution = restitution;
            fixDef.shape = shape;

            var _obj = this.World.CreateBody(bodyDef).CreateFixture(fixDef);
            _obj.body = _obj.GetBody();
            _obj.body.transform = _obj.body.GetTransform();
            _obj.body.fixture = _obj;
            return _obj.body;
        },
        Update : function(){
            this.World.Step(1/60, 10, 10);
            this.World.DrawDebugData();
            this.World.ClearForces();
        },
        SetCollision : function()
        {
            this.listener = new Box2D.Dynamics.b2ContactListener();
            this.listener.BeginContact = function(event)
            {
                var objA = event.GetFixtureA().GetBody().obj;
                var objB = event.GetFixtureB().GetBody().obj;
                if(objA._beginContact == null)
                    objA._beginContact = objB;
                if(objB._beginContact == null)
                    objB._beginContact = objA;
            }
            this.listener.EndContact = function(event)
            {
                var objA = event.GetFixtureA().GetBody().obj;
                var objB = event.GetFixtureB().GetBody().obj;
                if(objA._beginContact == null)
                    objA._beginContact = objB;
                if(objB._endContact == null)
                    objB._endContact = objA;
            }
            this.World.SetContactListener(this.listener);
        }
    }
}

//UI Development
var UI ={
    SCREEN_SCALE : 1,
    SCREEN_ALIGN : {
        TOP_CENTER : 0,
        TOP_LEFT : 1,
        TOP_RIGHT : 2,
        CENTER_LEFT : 3,
        CENTER_CENTER : 4,
        CENTER_RIGHT : 5,
        BOT_LEFT : 6,
        BOT_CENTER : 7,
        BOT_RIGHT : 8,
        STRETCH_ALL : 9,
        STRETCH_HORIZONTAL : 10,
        STRETCH_VERTICAL : 11,
        FILL : 12
    },
    GetAlignedPosition : function(x, y, width, height, align, scale)
    {
        if(scale == null)
		  scale = 1;
        x += (this.parent != null ? this.parent.x : 0);
        y += (this.parent != null ? this.parent.y : 0);
        switch(align)
        {
            case UI.SCREEN_ALIGN.BOT_CENTER:
                return {
                    x : canvas.width/2 - width/2 * UI.SCREEN_SCALE * scale + x,
                    y : canvas.height - UI.SCREEN_SCALE * scale * height + y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.BOT_LEFT:
                return {
                    x : x,
                    y: canvas.height - UI.SCREEN_SCALE * scale * height + y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.BOT_RIGHT:
                return {
                    x : canvas.width - width * UI.SCREEN_SCALE * scale + x,
                    y : canvas.height - UI.SCREEN_SCALE * scale * height + y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.TOP_CENTER:
                return {
                    x : canvas.width/2 - width/2 * UI.SCREEN_SCALE * scale + x,
                    y : y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.TOP_LEFT:
                return {
                    x : x, 
                    y : y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.TOP_RIGHT:
                return {
                    x : canvas.width - width * UI.SCREEN_SCALE * scale + x,
                    y : y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.CENTER_CENTER:
                return {
                    x : canvas.width/2 - width/2 * UI.SCREEN_SCALE * scale + x,
                    y : canvas.height/2 - UI.SCREEN_SCALE * scale * height/2 + y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.CENTER_LEFT:
                return {
                    x : x,
                    y : canvas.height/2 - UI.SCREEN_SCALE * scale * height/2 + y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.CENTER_RIGHT:
                return {
                    x : canvas.width - width * UI.SCREEN_SCALE * scale + x,
                    y : canvas.height/2 - UI.SCREEN_SCALE * scale * height/2 + y,
                    width : UI.SCREEN_SCALE * scale * width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.STRETCH_ALL:
                return {
                    x : x,
                    y : y, 
                    width : canvas.width,
                    height : canvas.height
                };
                break;
            case UI.SCREEN_ALIGN.STRETCH_HORIZONTAL:
                return {
                    x : x,
                    y : y,
                    width : canvas.width,
                    height : height * UI.SCREEN_SCALE * scale
                };
                break;
            case UI.SCREEN_ALIGN.STRETCH_VERTICAL:
                return {
                    x : x,
                    y : y,
                    width : width * UI.SCREEN_SCALE * scale,
                    height : canvas.height
                };
                break;
            case UI.SCREEN_ALIGN.FILL:
                if(canvas.width > canvas.height)
                    return {
                        x : x,
                        y : y,
                        width : canvas.width,
                        height : canvas.width * (height / width)
                    };
                else
                    return {
                        x : x,
                        y : y,
                        width : canvas.height * (width / height),
                        height : canvas.height
                    };
                break; 
        }
    },
    DrawSprite : function(x, y, sprite, screen_align, scale)
    {
        if(scale == null)
		  scale = 1;
        if(screen_align == null)
            screen_align = UI.SCREEN_ALIGN.TOP_LEFT;
        var width = sprite.width;
        var height = sprite.height;
        if(this.parent == null)
        {
            var result = UI.GetAlignedPosition(x, y, sprite.width, sprite.height, screen_align, scale);
            x = result.x;
            y = result.y;
            width = result.width;
            height = result.height;
        }
        else
        {
            var result = UI.GetAlignedPosition(this.parent.x, this.parent.y, this.parent.width, this.parent.height, this.parent.align, 1);
            x += result.x;
            y += result.y;
        }
        context.drawImage(sprite, x, y, width, height);
    },
    DrawText : function (x, y, text, f, c, align, screen_align, lineHeight){
        if(this.parent == null)
        {
            var result = UI.GetAlignedPosition(x, y, 0, 0, (screen_align == null ? UI.SCREEN_ALIGN.TOP_LEFT : screen_align), 1);
            x = result.x;
            y = result.y;
        }
        else
        {
            var result = UI.GetAlignedPosition(this.parent.x, this.parent.y, this.parent.width, this.parent.height, this.parent.align, 1);
            x += result.x;
            y += result.y;
        }
        if(lineHeight == null)
            lineHeight = 15;
        context.fillStyle = c;
        context.font = f;
        context.textAlign = align;
        var lines = text.split("\n");
        for(var i=0; i<lines.length; i++)
            context.fillText(lines[i], x, y + i * lineHeight);
    },
    DrawRect : function(x, y, w, h, r, g, b, onlyStroke, screen_align){
        if(this.parent == null)
        {
            var result = UI.GetAlignedPosition(x, y, w, h, screen_align == null ? UI.SCREEN_ALIGN.TOP_LEFT : screen_align, 1);
            x = result.x;
            y = result.y;
            w = result.width;
            h = result.height;
        }
        else
        {
            var result = UI.GetAlignedPosition(this.parent.x, this.parent.y, this.parent.width, this.parent.height, this.parent.align, 1);
            x += result.x;
            y += result.y;
        }
        if(!onlyStroke)
        {
            context.fillStyle = 'rgba('+r+','+g+','+b+', 1)';
            context.fillRect(x,y,w,h);
        }
        else
        {
            context.strokeStyle = 'rgba('+r+','+g+','+b+', 1)';
            context.strokeRect(x,y,w,h);
        }
    }
}

//Delta Time Function
function deltaTime()
{
    current = (new Date()).getTime();
    elapsed = current - start;
    start = current;
    var delta = elapsed / 1000;
    return delta;
};

//Update Frame Function
function updateFrame()
{
    //Sound auto-dispose
    if(!document.hasFocus())
    {
        for(var i=0; i<sound.sounds.length; i++)
        {
            soundDispose(sound.sounds[i]);
        }
    }
    if(true)
    {
        currentFrame += deltaTime() * 60;
        if(currentFrame>1)
        {
            loop();
            currentFrame--;
        };
        if(currentFrame > 5)
            currentFrame=5;
    }
    else
        deltaTime();
    setTimeout(updateFrame, 0);
};

//Sound Functions
function soundPlay(snd)
{
    if(document.hasFocus())
    {
        snd.loop = false;
        snd.play();
    }
}

function soundStop(snd)
{
    if(document.hasFocus())
    {
        snd.pause();
        snd.currentTime = 0;
    }
}

function soundLoop(snd)
{
    if(document.hasFocus())
    {
        snd.loop = true;
        soundStop(snd);
        snd.play();
    }
}

function soundIsPlaying(snd)
{
    return !snd.paused;
}

function soundDispose(snd)
{
    snd.loop = false;
    snd.pause();
    snd.preload = "none";
    var _src = snd.src;
    snd.src = "";
    snd.load();
    snd.src = _src;
}

//Draw Text Function
function drawText(x,y,text,f,c,align)
{
    var bX = roomManager.actual.x != null ? -roomManager.actual.camera.x : 0;
    var bY = roomManager.actual.y != null ? -roomManager.actual.camera.y : 0;
    context.fillStyle = c;
    context.font = f;
    context.textAlign = align;
    context.fillText(text, bX + x, bY + y);
};

function objOff(obj)
{
    var currleft = currtop = 0;
    if( obj.offsetParent )
    { do { currleft += obj.offsetLeft; currtop += obj.offsetTop; }
      while( obj = obj.offsetParent ); }
    else { currleft += obj.offsetLeft; currtop += obj.offsetTop; }
    return [currleft,currtop];
}

function measureTextHeight(fontStyle, str) 
{
    fontStyle = fontStyle.split(" ");
    var text = document.createElement("span");
    text.style.fontFamily = fontStyle[1];
    text.style.fontSize = fontStyle[0];
    text.innerHTML = str; 
    // if you will use some weird fonts, like handwriting or symbols, then you need to edit this test string for chars that will have most extreme accend/descend values

    var block = document.createElement("div");
    block.style.display = "inline-block";
    block.style.width = "1px";
    block.style.height = "0px";

    var div = document.createElement("div");
    div.appendChild(text);
    div.appendChild(block);

    // this test div must be visible otherwise offsetLeft/offsetTop will return 0
    // but still let's try to avoid any potential glitches in various browsers
    // by making it's height 0px, and overflow hidden
    div.style.height = "0px";
    div.style.overflow = "hidden";

    // I tried without adding it to body - won't work. So we gotta do this one.
    document.body.appendChild(div);

    block.style.verticalAlign = "baseline";
    var bp = objOff(block);
    var tp = objOff(text);
    var taccent = bp[1] - tp[1];
    block.style.verticalAlign = "bottom";
    bp = objOff(block);
    tp = objOff(text);
    var theight = bp[1] - tp[1];
    var tdescent = theight - taccent;

    // now take it off :-)
    document.body.removeChild(div);

    // return text accent, descent and total height
    return theight;
}

//Draw Rect Function
function drawRect(x,y,w,h,r,g,b,onlyStroke)
{
    var bX = roomManager.actual.x != null ? -roomManager.actual.camera.x : 0;
    var bY = roomManager.actual.y != null ? -roomManager.actual.camera.y : 0;
    if(!onlyStroke)
    {
        context.fillStyle = 'rgba('+r+','+g+','+b+', 1)';
        context.fillRect(bX + x, bY + y, w, h);
    }
    else
    {
        context.strokeStyle = 'rgba('+r+','+g+','+b+', 1)';
        context.strokeRect(bX + x, bY + y, w, h);
    }
};

//Draw Sprite Function
function drawSprite(x,y,sprite)
{
    context.drawImage(sprite,-roomManager.actual.camera.x + x,-roomManager.actual.camera.y + y);
};

//Draw Sprite Extended Function
function drawSpriteExt(x,y,w,h,sprite,angle, scaleX, scaleY)
{
    context.save();
    context.translate(-roomManager.actual.camera.x+x+w/2, -roomManager.actual.camera.y+y+h/2);
    context.rotate(angle * Math.PI/180);
    context.scale(scaleX, scaleY);
    context.drawImage(sprite,-w/2,-h/2);
    context.restore();
};

var mousePrefab = function()
{
    this.x = 0;
    this.y = 0;
    this.pressed = [false,false,false];
};

var mousePressed = function(e)
{
    e.preventDefault();
    mouse.pressed[e.button] = true;
};

var mouseReleased = function(e)
{
    e.preventDefault();
    mouse.pressed[e.button] = false;
};

function getMouse(e)
{
    rect = canvas.getBoundingClientRect();
    if((Math.floor(e.clientX - rect.left) >= 0) && (Math.floor(e.clientX - rect.left) <= canvas.width) && (Math.floor(e.clientY - rect.top) >= 0) && (Math.floor(e.clientY - rect.top) <= canvas.height))
    {
        mouse.x=Math.floor(e.clientX - rect.left);
        mouse.y=Math.floor(e.clientY - rect.top);
    }
};
addEventListener('mousedown', mousePressed, true);
addEventListener('mouseup', mouseReleased, true);
addEventListener('mousemove', function(e){getMouse(e)}, false);

function randomRange (min, max)
{
    return Math.floor(Math.random() * (max - min + 1)) + min;
};

function checkCollision(a,b) 
{
    //return !(((a.y+a.height) < (b.y)) ||(a.y > (b.y+b.height)) ||((a.x+a.width) < b.x) ||(a.x > (b.x+b.width)));
    return doPolygonsIntersect(
        [
            getRC(a, -a.width/2, -a.height/2),
            getRC(a, a.width/2, -a.height/2),
            getRC(a, -a.width/2, a.height/2),
            getRC(a, a.width/2, a.height/2)
        ],
        [
            getRC(b, -b.width/2, -b.height/2),
            getRC(b, b.width/2, -b.height/2),
            getRC(b, -b.width/2, b.height/2),
            getRC(b, b.width/2, b.height/2)
        ]
    );
};

function getRC(obj, cX, cY){
    var angle = obj.angle * (Math.PI/180);
    var x = obj.x + obj.width/2 + (cX  * Math.cos(angle)) - (cY * Math.sin(angle));
    var y = obj.y + obj.height/2 + (cX  * Math.sin(angle)) + (cY * Math.cos(angle));
    return {x : x, y : y};
}


function doPolygonsIntersect (a, b) {
    var polygons = [a, b];
    var minA, maxA, projected, i, i1, j, minB, maxB;

    for (i = 0; i < polygons.length; i++) {

        // for each polygon, look at each edge of the polygon, and determine if it separates
        // the two shapes
        var polygon = polygons[i];
        for (i1 = 0; i1 < polygon.length; i1++) {

            // grab 2 vertices to create an edge
            var i2 = (i1 + 1) % polygon.length;
            var p1 = polygon[i1];
            var p2 = polygon[i2];

            // find the line perpendicular to this edge
            var normal = { x: p2.y - p1.y, y: p1.x - p2.x };

            minA = maxA = undefined;
            // for each vertex in the first shape, project it onto the line perpendicular to the edge
            // and keep track of the min and max of these values
            for (j = 0; j < a.length; j++) {
                projected = normal.x * a[j].x + normal.y * a[j].y;
                if (minA == undefined || projected < minA) {
                    minA = projected;
                }
                if (maxA == undefined || projected > maxA) {
                    maxA = projected;
                }
            }

            // for each vertex in the second shape, project it onto the line perpendicular to the edge
            // and keep track of the min and max of these values
            minB = maxB = undefined;
            for (j = 0; j < b.length; j++) {
                projected = normal.x * b[j].x + normal.y * b[j].y;
                if (minB == undefined || projected < minB) {
                    minB = projected;
                }
                if (maxB == undefined || projected > maxB) {
                    maxB = projected;
                }
            }

            // if there is no overlap between the projects, the edge we are looking at separates the two
            // polygons, and we know there is no overlap
            if (maxA < minB || maxB < minA) {
                return false;
            }
        }
    }
    return true;
};

function checkCollisionInnerCircle(a,b) 
{
    var aR = (a.width > a.height ? a.height : a.width)/2;
    var bR = (b.width > b.height ? b.height : b.width)/2;
    var aX = a.x + a.width/2;
    var aY = a.y + a.height/2;
    var bX = b.x + b.width/2;
    var bY = b.y + b.height/2;
    return Math.pow(bX-aX, 2) + Math.pow(aY-bY, 2) <= Math.pow(aR+bR, 2);
};

var keyPressed = function(e)
{
    roomManager.actual.keyPressed(e);
    if(e.keyCode == 32)
        e.preventDefault();
};

var keyReleased = function(e)
{
    roomManager.actual.keyReleased(e);
};

addEventListener('keydown', keyPressed, true);
addEventListener('keyup', keyReleased, true);

var global = {};
var camera = function()
{
    this.x=0;
    this.y=0;
    this.width = $viewWidth; this.height = $viewHeight;
};