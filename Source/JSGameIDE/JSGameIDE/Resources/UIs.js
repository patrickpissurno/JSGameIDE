//Defines each UI
#FOREACH UI
    var UI$UIId = function(args)
    {
        this.name = "UI$UIId";
        this.x = $UIX;
        this.y = $UIY;
        this.width = $UIWidth;
        this.height = $UIHeight;
        this.align = $UIAlign;
        this.pressed = [false, false, false];
        this.components = [$UIInstantiate];
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
                if(this.components[i] != null){
                    this.components[i].parent = this;
                    if(this.components[i].create != null)
                        this.components[i].create();
                }
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
            
            //Mouse
            if((!mouse.pressed[0] && this.pressed[0])||
               (!mouse.pressed[1] && this.pressed[1])||
               (!mouse.pressed[2] && this.pressed[2]))
            {
                var event = {button : (this.pressed[0] && !mouse.pressed[0] ? 0 : this.pressed[1] && !mouse.pressed[1] ? 1 : 2)};
                this.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                //$UIMouseReleased
            };
            
            if(((mouse.pressed[0] && !this.pressed[0])||
               (mouse.pressed[1] && !this.pressed[1])||
               (mouse.pressed[2] && !this.pressed[2])) && roomManager.actual.camera.x + mouse.x > this.x  && roomManager.actual.camera.x + mouse.x < this.x + this.width && roomManager.actual.camera.y + mouse.y > this.y && roomManager.actual.camera.y + mouse.y < this.y + this.height)
            {
                var event = {button : (!this.pressed[0] && mouse.pressed[0] ? 0 : !this.pressed[1] && mouse.pressed[1] ? 1 : 2)};
                this.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                //$UIMousePressed
            };
            
            if(this.toDestroy)
            {
                this.destroy();
            };
            
            $UIUpdate
            
            var alignedPos = UI.GetAlignedPosition(this.x, this.y, this.width, this.height, this.align, 1);
            for(var i=0; i<this.components.length; i++){
                if(this.components[i] != null)
                {
                    var comp = this.components[i];
                    //Mouse Events for Components
                    if(comp.pressed != null && comp.x != null && comp.y != null && comp.width != null && comp.height != null)
                    {
                        //Mouse Pressed
                        if(mouse.x > alignedPos.x + comp.x && mouse.x < alignedPos.x + comp.x + comp.width &&
                          mouse.y > alignedPos.y + comp.y && mouse.y < alignedPos.y + comp.y + comp.height)
                        {
                            if((mouse.pressed[0] && !comp.pressed[0])||(mouse.pressed[1] && !comp.pressed[1])||
                               (mouse.pressed[2] && !comp.pressed[2]))
                            {
                                var event = {button : (!comp.pressed[0] && mouse.pressed[0] ? 0 : !comp.pressed[1] && mouse.pressed[1] ? 1 : 2)};
                                comp.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                                if(comp.mousePressed != null)
                                    comp.mousePressed(event);
                            }
                        }
                        
                        //Mouse Released
                        if((!mouse.pressed[0] && comp.pressed[0])||
                          (!mouse.pressed[1] && comp.pressed[1])||
                          (!mouse.pressed[2] && comp.pressed[2]))
                        {
                            var event = {button : (comp.pressed[0] && !mouse.pressed[0] ? 0 : comp.pressed[1] && !mouse.pressed[1] ? 1 : 2)};
                            comp.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                            if(comp.mouseReleased != null)
                                comp.mouseReleased(event);
                        }
                    }
                    if(comp.update != null)
                        comp.update();
                }
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
                    this.components[i].keyPressed(event);
            }
        }
        
        //UI Key Released Event
        this.keyReleased = function(event)
        {
            $UIKeyReleased
            
            for(var i=0; i<this.components.length; i++){
                if(this.components[i] != null && this.components[i].keyReleased != null)
                    this.components[i].keyReleased(event);
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