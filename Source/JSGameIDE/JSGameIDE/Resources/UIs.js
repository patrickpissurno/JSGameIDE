//Defines each UI
#FOREACH UI
    var UI$UIId = function(args)
    {
        this.name = "UI$UIId";
        this.x = 0;
        this.y = 0;
        this.width = $UIWidth;
        this.height = $UIHeight;
        this.align = $UIAlign;
        this.components = [];
        this._create_executed = false;
        this.prefab = UI$UIId;
        this.toDestroy = false;
        this.args = args;
        
        //Instantiate
        roomManager.actual[this.name].push(this);
        
        //UI Create Event
        this.create = function()
        {
            var args = this.args;
            $UICreate
            for(var i=0; i<this.components.length; i++){
                if(this.components[i] != null && this.components[i].create != null)
                    this.components[i].create();
            }
            this.args = null;
        };
        
        //UI Update Event
        this.update = function()
        {
            if(!this._create_executed)
            {
                this.create();
                this._create_executed = true;
            };
            
            if(this.toDestroy)
            {
                this.destroy();
            };
            
            $UIUpdate
            
            for(var i=0; i<this.components.length; i++){
                if(this.components[i] != null && this.components[i].update != null)
                    this.components[i].update();
            }
        };
        
        //UI Draw Event
        this.draw = function()
        {
            $UIDraw
            
            for(var i=0; i<this.components.length; i++){
                if(this.components[i] != null && this.components[i].draw != null)
                    this.components[i].draw();
            }
        }
        
        //UI Key Pressed Event
        this.keyPressed = function(event)
        {
            $UIKeyPressed
            
            for(var i=0; i<this.components.length; i++){
                if(this.components[i] != null && this.components[i].keyPressed != null)
                    this.components[i].keyPressed();
            }
        }
        
        //UI Key Released Event
        this.keyReleased = function(event)
        {
            $UIKeyReleased
            
            for(var i=0; i<this.components.length; i++){
                if(this.components[i] != null && this.components[i].keyReleased != null)
                    this.components[i].keyReleased();
            }
        }
        
        //UI Destroy Event
        this.destroy = function()
        {
            if(!this.toDestroy)
            {
                this.toDestroy = true;
            }
            else
            {
                $UIDestroy
                
                for(var i=0; i<roomManager.actual['UI$UIId'].length; i++)
                {
                    if(roomManager.actual['UI$UIId'][i] == this)
                    {
                        roomManager.actual['UI$UIId'].splice(i,1);
                        break;
                    };
                };
            };
        }
    }
#END