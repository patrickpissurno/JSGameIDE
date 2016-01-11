#FOREACH Object
    var obj$objectId = function()
    {
        this.name = 'obj$objectId';
        this._this = this;
        this.toDestroy = false;
        this.x = 0;
        this.y = 0;
        this.pressed = false;
        this.alpha = 1;
        this.angle = 0;
        this.imageIndex = 0;
        this.imageSpeed = 1;
        this.width = $objectWidth;
        this.height = $objectHeight;
        this.hspeed = 0;
        this.vspeed = 0;
        this.autoDraw = $objectAutoDraw;
        this.sprite = $objectSprite;
        this._create_executed = false;
        this.usePhysics = $objectUsePhysics;
        this.bodyType = $objectBodyType;
        this.lockRotation = $objectLockRotation;
        this.body = null;
        this.transform = null;
        
        
        this.create = function()
        {
            if(this.usePhysics)
            {
                  this.body = Physics.CreateBody(this.bodyType, this.x * Physics.Scale, this.y * Physics.Scale, Physics.Shapes.Box((this.width / 2) * Physics.Scale, (this.height / 2) * Physics.Scale), this.lockRotation);
                this.transform = this.body.transform;  
            }
            $objectCreate
        };
        
        this.update = function()
        {
            if(!this._create_executed)
            {
                this.create();
                this._create_executed = true;
            };
            
            //Update the X and Y variables when using Physics (read only)
            if(this.usePhysics)
            {
                this.x = (this.transform.position.x / Physics.Scale) - this.width / 2;
                this.y = (this.transform.position.y / Physics.Scale) - this.height / 2;
            }
                
            if(this.pressed && !mouse.pressed)
            {
                this.pressed = false;
                $objectMouseReleased
            };
            
            if(mouse.pressed && roomManager.actual.camera.x + mouse.x > this.x  && roomManager.actual.camera.x + mouse.x < this.x + this.width && roomManager.actual.camera.y + mouse.y > this.y && roomManager.actual.camera.y + mouse.y < this.y + this.height)
            {
                this.pressed = true;
                $objectMousePressed
            };
            
            if(this.toDestroy)
            {
                this.destroy();
            };
            
            $objectUpdate
            
            if(!this.usePhysics)
            {
                this.x += this.hspeed;
                this.y += this.vspeed;
            }
            else
            {
                this.angle = this.transform.GetAngle() * 180 / Math.PI;
            }
        };
        
        this.draw = function()
        {
            this.fixData();
            this.animator();
            if(this.sprite != null && this.autoDraw)
            {
                context.globalAlpha = this.alpha;
                drawSpriteExt(this.x, this.y, this.width, this.height, this.sprite[Math.round(this.imageIndex)], this.angle);
                context.globalAlpha = 1;
            };
            $objectDraw
        };
        
        this.keyPressed = function(event)
        {
            $objectKeyPressed
        };
        
        this.keyReleased = function(event)
        {
            $objectKeyReleased
        };
        
        this.mousePressed = function()
        {
            $objectMousePressed
        }
        
        this.mouseReleased = function()
        {
            $objectMouseReleased
        }
        
        this.destroy = function()
        {
            if(!this.toDestroy)
            {
                this.toDestroy=true;
            }
            else
            {
                $objectDestroy
                for(var i=0; i<roomManager.actual['obj$objectId'].length; i++)
                {
                    if(roomManager.actual['obj$objectId'][i] == this)
                    {
                        roomManager.actual['obj$objectId'].splice(i,1);
                        break;
                    };
                };
                if(this.usePhysics)
                {
                    if(this.body != null)
                        Physics.World.DestroyBody(this.body);
                    this.body = null;
                }
            };
        }
        
        this.fixData = function()
        {
            while(this.imageIndex < 0)
                this.imageIndex += this.sprite.length - 1;
            while(this.imageIndex > this.sprite.length - 1)
                this.imageIndex -= this.sprite.length - 1;
            if(this.alpha > 1)
                this.alpha = 1;
            if(this.alpha < 0)
                this.alpha = 0;
            while(this.angle > 360)
                this.angle -= 360;
            while(this.angle < 0)
                this.angle += 360;
        };
        
        this.animator = function()
        {
            if(this.imageIndex < this.sprite.length - 1)
                this.imageIndex += this.imageSpeed / 10;
            else
                this.imageIndex = 0;
        };
    }
#END