#FOREACH Object
    var obj$objectId = function()
    {
        this.name = 'obj$objectId';
        this._this = this;
        this.toDestroy = false;
        this.x = 0;
        this.y = 0;
        this.pressed = [false, false, false];
        this.alpha = 1;
        this.angle = 0;
        this.imageIndex = 0;
        this.imageSpeed = 1;
        this.width = $objectWidth;
        this.height = $objectHeight;
        this.scaleX = 1;
        this.scaleY = 1;
        this.hspeed = 0;
        this.vspeed = 0;
        this.autoDraw = $objectAutoDraw;
        this.sprite = $objectSprite;
        this._create_executed = false;
        this.usePhysics = $objectUsePhysics;
        this.bodyType = $objectBodyType;
        this.lockRotation = $objectLockRotation;
        this.density = $objectDensity;
        this.friction = $objectFriction;
        this.restitution = $objectRestitution;
        this.body = null;
        this.transform = null;
        this._beginContact = null;
        this._endContact = null;
        
        
        this.create = function()
        {
            if(this.usePhysics)
            {
                var _s;
                switch($objectColliderType)
                {
                    case 0:
                        _s = Physics.Shapes.Box((this.width / 2) * Physics.Scale, (this.height / 2) * Physics.Scale);
                        break;
                    case 1:
                        var _r;
                        if(this.width > this.height)
                            _r = this.height;
                        else
                            _r = this.width;
                        _s = Physics.Shapes.Circle(_r/2 * Physics.Scale);
                        break;
                    case 2:
                        var _r;
                        if(this.width > this.height)
                            _r = this.width;
                        else
                            _r = this.height;
                        _s = Physics.Shapes.Circle(_r/2 * Physics.Scale);
                        break;
                }
                this.body = Physics.CreateBody(this.bodyType, this.x * Physics.Scale + this.width/2 * Physics.Scale, this.y * Physics.Scale + this.height/2 * Physics.Scale, _s, this.lockRotation, this.density, this.friction, this.restitution);
                this.transform = this.body.transform;
                this.body.obj = this;
                this.transform.obj = this;
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
            
            //Update the X, Y, Hspeed and Vspeed variables when using Physics (read only)
            if(this.usePhysics)
            {
                this.x = (this.transform.position.x / Physics.Scale) - this.width / 2;
                this.y = (this.transform.position.y / Physics.Scale) - this.height / 2;
                this.hspeed = this.body.m_linearVelocity.x;
                this.vspeed = this.body.m_linearVelocity.y;
            }
                
            if((!mouse.pressed[0] && this.pressed[0])||
               (!mouse.pressed[1] && this.pressed[1])||
               (!mouse.pressed[2] && this.pressed[2]))
            {
                var event = {button : (this.pressed[0] && !mouse.pressed[0] ? 0 : this.pressed[1] && !mouse.pressed[1] ? 1 : 2)};
                this.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                $objectMouseReleased
            };
            
            if(((mouse.pressed[0] && !this.pressed[0])||
               (mouse.pressed[1] && !this.pressed[1])||
               (mouse.pressed[2] && !this.pressed[2])) && roomManager.actual.camera.x + mouse.x > this.x  && roomManager.actual.camera.x + mouse.x < this.x + this.width && roomManager.actual.camera.y + mouse.y > this.y && roomManager.actual.camera.y + mouse.y < this.y + this.height)
            {
                var event = {button : (!this.pressed[0] && mouse.pressed[0] ? 0 : !this.pressed[1] && mouse.pressed[1] ? 1 : 2)};
                this.pressed = [mouse.pressed[0], mouse.pressed[1], mouse.pressed[2]];
                $objectMousePressed
            };
            
            if(this.toDestroy)
            {
                this.destroy();
            };
            
            if(this._beginContact != null)
            {
                this.collisionEnter(this._beginContact);
                this._beginContact = null;
            }
            
            if(this._endContact != null)
            {
                this.collisionExit(this._endContact);
                this._endContact = null;
            }
            
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
                this.drawSelf();
            };
            $objectDraw
        };
        
        this.drawSelf = function()
        {
            if(this.sprite != null)
            {
                this.fixData();
                context.globalAlpha = this.alpha;
                drawSpriteExt(this.x, this.y, this.width, this.height, this.sprite[Math.round(this.imageIndex)], this.angle, this.scaleX, this.scaleY);
                context.globalAlpha = 1;
            };
        }
        
        this.collisionEnter = function(other)
        {
            $objectCollisionEnter
        }
        
        this.collisionExit = function(other)
        {
            $objectCollisionExit
        }
        
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
            if(this.sprite != null)
            {
                while(this.imageIndex < 0)
                    this.imageIndex += this.sprite.length - 1;
                while(this.imageIndex > this.sprite.length - 1)
                    this.imageIndex -= this.sprite.length - 1;
            }
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
            if(this.sprite != null)
            {
                if(this.imageIndex < this.sprite.length - 1)
                    this.imageIndex += this.imageSpeed / 10;
                else
                    this.imageIndex = 0;
            }
        };
    }
#END