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
        this.onDestroy = null;
        this.result = null;
        this.movable = {
            allowed : $UIMovable,
            offset : {
                x : 0,
                y : 0
            },
            moving : false
        };
        
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
            
            var alignedPos = UI.GetAlignedPosition(this.x, this.y, this.width, this.height, this.align, 1);
            
            var mouseHandled = false;
            //Update the components
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
                                var event = {
                                    button : (!comp.pressed[0] && mouse.pressed[0] ? 0 : !comp.pressed[1] && mouse.pressed[1] ? 1 : 2),
                                    handled : true
                                };
                                comp.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                                if(comp.mousePressed != null)
                                {
                                    comp.mousePressed(event);
                                    if(event.handled)
                                        mouseHandled = true;
                                }
                                else if(comp.mouseReleased != null)
                                    mouseHandled = true;
                            }
                        }
                        
                        //Mouse Released
                        if((!mouse.pressed[0] && comp.pressed[0])||
                          (!mouse.pressed[1] && comp.pressed[1])||
                          (!mouse.pressed[2] && comp.pressed[2]))
                        {
                            var event = {
                                button : (comp.pressed[0] && !mouse.pressed[0] ? 0 : comp.pressed[1] && !mouse.pressed[1] ? 1 : 2),
                                handled : true
                            };
                            comp.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                            if(comp.mouseReleased != null)
                            {
                                comp.mouseReleased(event);
                                if(event.handled)
                                    mouseHandled = true;
                            }
                        }
                        
                        if(comp.pressed[0])
                            mouseHandled = true;
                    }
                    if(comp.update != null)
                        comp.update();
                }
            }
                        
            
            //Mouse
            if((!mouse.pressed[0] && this.pressed[0])||
               (!mouse.pressed[1] && this.pressed[1])||
               (!mouse.pressed[2] && this.pressed[2]))
            {
                var event = {button : (this.pressed[0] && !mouse.pressed[0] ? 0 : this.pressed[1] && !mouse.pressed[1] ? 1 : 2)};
                this.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                //$UIMouseReleased
                if(this.movable.allowed && this.movable.moving)
                {
                    this.movable.moving = false;
                }
            };
            
            if(((mouse.pressed[0] && !this.pressed[0])||
               (mouse.pressed[1] && !this.pressed[1])||
               (mouse.pressed[2] && !this.pressed[2])) && mouse.x > alignedPos.x  && mouse.x < alignedPos.x + alignedPos.width && mouse.y > alignedPos.y && mouse.y < alignedPos.y + alignedPos.height && !mouseHandled)
            {
                var event = {button : (!this.pressed[0] && mouse.pressed[0] ? 0 : !this.pressed[1] && mouse.pressed[1] ? 1 : 2)};
                this.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                //$UIMousePressed
                if(this.movable.allowed && !this.movable.moving)
                {
                    this.movable.offset.x = alignedPos.x - mouse.x;
                    this.movable.offset.y = alignedPos.y - mouse.y;
                    this.movable.moving = true;
                }
            };
            
            if(this.toDestroy)
            {
                this.destroy();
            };
            
            if(this.pressed[0] && this.movable.allowed && this.movable.moving)
            {
                var offsetX = alignedPos.x - this.x;
                var offsetY = alignedPos.y - this.y;
                this.x = mouse.x - offsetX + this.movable.offset.x;
                this.y = mouse.y - offsetY + this.movable.offset.y;
            }            
            
            $UIUpdate
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
                
                if(this.onDestroy != null)
                    this.onDestroy();
                
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