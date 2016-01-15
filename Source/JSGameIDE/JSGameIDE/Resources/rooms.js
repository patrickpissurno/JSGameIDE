//Room Manager
var rM = function()
{
    this.last = {
        keyboardEnabled: false,
        update: function(){},
        draw: function(){}
    };
    
    this.camera = new camera();
    this.actual = this.last;
    this.change = true;
    this.alpha = 0;
    this.room2go = new Room$roomFirstId();
    
    //Change room function
    this.go = function(e)
    {
        this.last = this.actual;
        this.room2go = e;
        this.alpha = 0;
        this.change=true;
    };
    
    //Room manager update function
    this.update = function()
    {
        if(!this.change)
            this.actual.update();
        else
        {
            if(this.alpha < 1 && this.actual != this.room2go)
                this.alpha += 0.1;
            else if(this.alpha >= 1 && this.actual != this.room2go)
                this.actual = this.room2go;
            else if(this.alpha > 0 && this.actual == this.room2go)
                this.alpha -= 0.1;
            else
            {
                this.alpha = 0;
                this.change = false;
            }
        }
    }
    
    //Room manager draw function
    this.draw = function()
    {
        this.actual.draw();
        if(this.change)
        {
            if(this.alpha > 1)
                this.alpha = 1;
            else if(this.alpha < 0)
                this.alpha = 0;
            context.globalAlpha = this.alpha;
            drawRect(0, 0, canvas.width, canvas.height, 0, 0, 0, 0);
            context.globalAlpha = 1;
        }
    }
};
//Defines each room
#FOREACH Room
    var Room$roomId = function()
    {
        #DEFINE ObjectCreates
            /*for(var i=0; i<this.obj$objectId.length; i++){
                if(this.obj$objectId[i] != null)
                    this.obj$objectId[i].create();
            };*/
        #END
        #DEFINE ObjectUpdates
            for(var i=0; i<this.obj$objectId.length; i++)
            {
                if(this.obj$objectId[i] != null)
                    this.obj$objectId[i].update();
            };
        #END
        #DEFINE ObjectDraws
            for(var i=0; i<this.obj$objectId.length; i++)
            {
                if(this.obj$objectId[i] != null)
                    this.obj$objectId[i].draw();
            };
        #END
        #DEFINE ObjectKeyPresseds
            for(var i=0; i<this.obj$objectId.length; i++)
            {
                if(this.obj$objectId[i] != null)
                    this.obj$objectId[i].keyPressed(event);
            };
        #END
        #DEFINE ObjectKeyReleaseds
            for(var i=0; i<this.obj$objectId.length; i++)
            {
                if(this.obj$objectId[i] != null)
                    this.obj$objectId[i].keyReleased(event);
            };
        #END
        #FOREACH Object
            this.obj$objectId = [];
        #END
        this._create_executed = false;
        this.prefab = Room$roomId;
        this.camera = new camera();
        this.allowSleep = $roomAllowSleep;
        this.gravityVector = new b2Vec($roomGravityX, $roomGravityY);
        
        //Room Create Event
        this.create = function()
        {
            Physics.Start(this.gravityVector, this.allowSleep);
            $roomCreate
            $roomEditorCreate
            $objectCreates
        };
        
        //Room Update Event
        this.update = function()
        {
            if(!this._create_executed)
            {
                this.create();
                this._create_executed = true;
            };
            $roomUpdate
            $objectUpdates
            Physics.Update();
        };
        
        //Room Draw Event
        this.draw = function()
        {
            $roomDraw
            $objectDraws
        }
        
        //Room Key Pressed Event
        this.keyPressed = function(event)
        {
            $roomKeyPressed
            $objectKeyPresseds
        }
        
        //Room Key Released Event
        this.keyReleased = function(event)
        {
            $roomKeyReleased
            $objectKeyReleaseds
        }
    }
#END