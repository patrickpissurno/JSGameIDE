//Some basic variable definition
var map = {width: $gameWidth, height: $gameHeight};
var canvas = document.getElementById('gameCanvas');
var context = canvas.getContext('2d');
var start = (new Date()).getTime();
var currentFrame=0;

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
    Start : function(){
        this.World = new b2World(new b2Vec(0, 9.8), false);

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
    CreateBody : function(type, x, y, shape, lockRotation){
        var bodyDef = new b2BodyDef();
        bodyDef.type = type;
        bodyDef.position.x = x;
        bodyDef.position.y = y;
        bodyDef.fixedRotation = lockRotation;

        var fixDef = new b2FixtureDef();
        fixDef.density = 1.0;
        fixDef.friction = 0.5;
        fixDef.restitution = 0.5;
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
    context.fillStyle = c;
    context.font = f;
    context.textAlign = align;
    context.fillText(text,-roomManager.actual.camera.x + x,-roomManager.actual.camera.y + y);
};

//Draw Rect Function
function drawRect(x,y,w,h,r,g,b,onlyStroke)
{
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
};

//Draw Sprite Function
function drawSprite(x,y,sprite)
{
    context.drawImage(sprite,-roomManager.actual.camera.x + x,-roomManager.actual.camera.y + y);
};

//Draw Sprite Extended Function
function drawSpriteExt(x,y,w,h,sprite,angle)
{
    context.save();
    context.translate(-roomManager.actual.camera.x+x+w/2, -roomManager.actual.camera.y+y+h/2);
    context.rotate(angle * Math.PI/180);
    context.drawImage(sprite,-w/2,-h/2);
    context.restore();
};

var mousePrefab = function()
{
    this.x = 0;
    this.y = 0;
    this.pressed = false;
};

var mousePressed = function(e)
{
    if(e.button == 0)
    {
        e.preventDefault();
        mouse.pressed=true;
    }
};

var mouseReleased = function(e)
{
    e.preventDefault();
    mouse.pressed=false;
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