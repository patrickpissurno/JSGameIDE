//Instance Create
instance_create = function(x, y, e)
{
    var _i = new e();
    _i.x = x;
    _i.y = y;
    roomManager.actual[_i.name].push(_i);
    return _i;
};

//FPS
var fps = {
    startTime : 0,
    frameNumber : 0,
    get : function(){
        this.frameNumber++;
        var d = new Date().getTime(),
            currentTime = (d - this.startTime) / 1000,
            result = Math.floor((this.frameNumber / currentTime));
        if(currentTime > 1)
        {
            this.startTime = new Date().getTime();
            this.frameNumber = 0;
        }
        return result;
    }
};

//Check Collision
check_collision_object = function(me, other, todo)
{
    for(i = 0; i<roomManager.actual[other].length; i++)
    {
        if(checkCollision(me, roomManager.actual[other][i]))
        {
            todo.bind(me)(roomManager.actual[other][i]);
        };
    };
};

//Check Collision
check_collision_object_circle = function(me, other, todo)
{
    for(i = 0; i<roomManager.actual[other].length; i++)
    {
        if(checkCollisionInnerCircle(me, roomManager.actual[other][i]))
        {
            todo.bind(me)(roomManager.actual[other][i]);
        };
    };
};

//Draw Set Alpha
draw_set_alpha = function(alpha)
{
    if(alpha > 1)
        alpha = 1;
    else if(alpha < 0)
        alpha = 0;
    context.globalAlpha = alpha;
};