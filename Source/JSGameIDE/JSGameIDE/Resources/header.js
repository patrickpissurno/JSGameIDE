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
    DrawSprite : function(x, y, sprite, screen_align, scale)
    {
        if(scale == null)
		  scale = 1;
        x += (this.parent != null ? this.parent.x : 0);
        y += (this.parent != null ? this.parent.y : 0);
        switch(screen_align)
        {
            //BOT
            case UI.SCREEN_ALIGN.BOT_CENTER:
                context.drawImage(sprite,canvas.width/2 - sprite.width/2 * UI.SCREEN_SCALE * scale + x,canvas.height - UI.SCREEN_SCALE * scale * sprite.height + y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            case UI.SCREEN_ALIGN.BOT_LEFT:
                context.drawImage(sprite, x,canvas.height - UI.SCREEN_SCALE * scale * sprite.height + y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            case UI.SCREEN_ALIGN.BOT_RIGHT:
                context.drawImage(sprite,canvas.width - sprite.width * UI.SCREEN_SCALE * scale + x,canvas.height - UI.SCREEN_SCALE * scale * sprite.height + y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            //TOP
            case UI.SCREEN_ALIGN.TOP_CENTER:
                context.drawImage(sprite,canvas.width/2 - sprite.width/2 * UI.SCREEN_SCALE * scale + x, y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            case UI.SCREEN_ALIGN.TOP_LEFT:
                context.drawImage(sprite, x, y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            case UI.SCREEN_ALIGN.TOP_RIGHT:
                context.drawImage(sprite,canvas.width - sprite.width * UI.SCREEN_SCALE * scale + x, y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            //CENTER
            case UI.SCREEN_ALIGN.CENTER_CENTER:
                context.drawImage(sprite,canvas.width/2 - sprite.width/2 * UI.SCREEN_SCALE * scale + x,canvas.height/2 - UI.SCREEN_SCALE * scale * sprite.height/2 + y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            case UI.SCREEN_ALIGN.CENTER_LEFT:
                context.drawImage(sprite, x,canvas.height/2 - UI.SCREEN_SCALE * scale * sprite.height/2 + y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            case UI.SCREEN_ALIGN.CENTER_RIGHT:
                context.drawImage(sprite,canvas.width - sprite.width * UI.SCREEN_SCALE * scale + x,canvas.height/2 - UI.SCREEN_SCALE * scale * sprite.height/2 + y, UI.SCREEN_SCALE * scale * sprite.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            //OTHER
            case UI.SCREEN_ALIGN.STRETCH_ALL:
                context.drawImage(sprite,x,y, canvas.width, canvas.height);
                break;
            case UI.SCREEN_ALIGN.STRETCH_HORIZONTAL:
                context.drawImage(sprite,x,y, canvas.width, sprite.height * UI.SCREEN_SCALE * scale);
                break;
            case UI.SCREEN_ALIGN.STRETCH_VERTICAL:
                context.drawImage(sprite,x,y, sprite.width * UI.SCREEN_SCALE * scale, canvas.height);
                break;
            case UI.SCREEN_ALIGN.FILL:
                if(canvas.width > canvas.height)
                    context.drawImage(sprite,x,y, canvas.width, canvas.width * (sprite.height / sprite.width));
                else
                    context.drawImage(sprite,x,y, canvas.height * (sprite.width / sprite.height), canvas.height);
                break; 
        }
    },
    DrawText : function (x, y, text, f, c, align){
        x += (this.parent != null ? this.parent.x : 0);
        y += (this.parent != null ? this.parent.y : 0);
        context.fillStyle = c;
        context.font = f;
        context.textAlign = align;
        context.fillText(text, x, y);
    },
    DrawRect : function(x, y, w, h, r, g, b, onlyStroke){
        x += (this.parent != null ? this.parent.x : 0);
        y += (this.parent != null ? this.parent.y : 0);
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

function measureTextHeight(left, top, width, height, text) {
        // Draw the text in the specified area
        context.save();
        context.clearRect(0,0,canvas.width,canvas.height);
        context.fillText(text, 0, 35); // This seems like tall text...  Doesn't it?
        context.restore();

        // Get the pixel data from the canvas
        var data = context.getImageData(left, top, width, height).data,
            first = false, 
            last = false,
            r = height,
            c = 0;

        // Find the last line with a non-white pixel
        while(!last && r) {
            r--;
            for(c = 0; c < width; c++) {
                if(data[r * width * 4 + c * 4 + 3]) {
                    last = r;
                    break;
                }
            }
        }

        // Find the first line with a non-white pixel
        while(r) {
            r--;
            for(c = 0; c < width; c++) {
                if(data[r * width * 4 + c * 4 + 3]) {
                    first = r;
                    break;
                }
            }

            // If we've got it then return the height
            if(first != r) return last - first;
        }

        // We screwed something up...  What do you expect from free code?
        return 0;
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
    return !(((a.y+a.height) < (b.y)) ||(a.y > (b.y+b.height)) ||((a.x+a.width) < b.x) ||(a.x > (b.x+b.width)));
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