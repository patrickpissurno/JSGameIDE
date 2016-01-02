//Some basic variable definition
var map = {width: $gameWidth, height: $gameHeight};
var canvas = document.getElementById('gameCanvas');
var context = canvas.getContext('2d');
var start = (new Date()).getTime();
var currentFrame=0;

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
    if(document.hasFocus())
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