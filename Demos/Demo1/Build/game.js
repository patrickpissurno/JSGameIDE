var map = {width:1280, height: 720};var canvas = document.getElementById('gameCanvas');var context = canvas.getContext('2d');var start = (new Date()).getTime();var currentFrame=0;function deltaTime(){current = (new Date()).getTime();elapsed = current - start;start = current;var delta = elapsed / 1000;return delta;};function updateFrame(){if(document.hasFocus()){currentFrame += deltaTime() * 60;if(currentFrame>1){loop();currentFrame-=1;}}else deltaTime();setTimeout(updateFrame, 0);};function drawText(x,y,text,f,c,align){context.fillStyle = c;context.font = f; context.textAlign = align; context.fillText(text,-roomManager.actual.camera.x + x,-roomManager.actual.camera.y + y);};function drawRect(x,y,w,h,r,g,b,onlyStroke){if(!onlyStroke){context.fillStyle = 'rgba('+r+','+g+','+b+', 1)';context.fillRect(x,y,w,h);}else {context.strokeStyle = 'rgba('+r+','+g+','+b+', 1)';context.strokeRect(x,y,w,h);}};function drawSprite(x,y,sprite){context.drawImage(sprite,-roomManager.actual.camera.x + x,-roomManager.actual.camera.y + y);};function drawSpriteExt(x,y,w,h,sprite,angle){context.save();context.translate(-roomManager.actual.camera.x+x+w/2, -roomManager.actual.camera.y+y+h/2);context.rotate(angle * Math.PI/180);context.drawImage(sprite,-w/2,-h/2);context.restore();};var mousePrefab = function(){this.x = 0;this.y = 0;this.pressed = false;};var mousePressed = function(e){if(e.button == 0){e.preventDefault();mouse.pressed=true;}};var mouseReleased = function(e){e.preventDefault();mouse.pressed=false;};function getMouse(e){rect = canvas.getBoundingClientRect();if((Math.floor(e.clientX - rect.left) >= 0) && (Math.floor(e.clientX - rect.left) <= canvas.width) && (Math.floor(e.clientY - rect.top) >= 0) && (Math.floor(e.clientY - rect.top) <= canvas.height)){mouse.x=Math.floor(e.clientX - rect.left);mouse.y=Math.floor(e.clientY - rect.top);}};addEventListener('mousedown', mousePressed, true);addEventListener('mouseup', mouseReleased, true);addEventListener('mousemove', function(e){getMouse(e)}, false);function randomRange (min, max) {return Math.floor(Math.random() * (max - min + 1)) + min;};function checkCollision(a,b) {return !(((a.y+a.height) < (b.y)) ||(a.y > (b.y+b.height)) ||((a.x+a.width) < b.x) ||(a.x > (b.x+b.width)));};var keyPressed = function(e){roomManager.actual.keyPressed(e);if(e.keyCode == 32)e.preventDefault();};var keyReleased = function(e){roomManager.actual.keyReleased(e);};addEventListener('keydown', keyPressed, true);addEventListener('keyup', keyReleased, true);var global = {};var camera = function(){this.x=0; this.y=0; this.width = 800; this.height = 600;};var sprImport = function(){this.sprite0 = new Image();this.sprite0.src = 'IMG/1.png';this.sprite1 = new Image();this.sprite1.src = 'IMG/enemy.png';};function gameOver() { 	roomManager.go(new Room0); }var obj0 = function(){this.name='obj0';this._this = this;this.toDestroy=false;this.x = 0;this.y = 0;this.pressed = false;this.alpha = 1;this.angle = 0;this.height = sprite.sprite0.height;this.width = sprite.sprite0.width;this.hspeed = 0;this.vspeed = 0;this.autoDraw = true;this.sprite = sprite.sprite0;this._create_executed=false;this.create = function(){};this.update = function(){if(!this._create_executed){this.create();this._create_executed=true;};if(this.pressed && !mouse.pressed){this.pressed=false;};if(mouse.pressed && roomManager.actual.camera.x + mouse.x > this.x  && roomManager.actual.camera.x + mouse.x < this.x + this.width && roomManager.actual.camera.y + mouse.y > this.y && roomManager.actual.camera.y + mouse.y < this.y + this.height){this.pressed=true;console.log("You pressed me!"); mouse.pressed=false;};if(this.toDestroy){this.destroy();};check_collision_object(this,"obj1",function(i) { 	gameOver(); }); roomManager.actual.camera.x = this.x - roomManager.actual.camera.width/2; roomManager.actual.camera.y = this.y - roomManager.actual.camera.height/2;this.x+=this.hspeed;this.y+=this.vspeed;};this.draw = function(){this.fixData();if(this.sprite!=null&&this.autoDraw){context.globalAlpha = this.alpha; drawSpriteExt(this.x,this.y,this.width,this.height,this.sprite,this.angle); context.globalAlpha=1;};};this.keyPressed = function(event){switch(event.keyCode) { 	case 37: 		this.hspeed=-2; 		break; 	case 39: 		this.hspeed=2; 		break; 	case 38: 		this.vspeed=-2; 		break; 	case 40: 		this.vspeed=2; 		break; }};this.keyReleased = function(event){switch(event.keyCode) { 	case 37: 	case 39: 		this.hspeed=0; 		break; 	case 38: 	case 40: 		this.vspeed=0; 		break; }};this.mousePressed = function(){console.log("You pressed me!"); mouse.pressed=false;};this.mouseReleased = function(){};this.destroy = function(){if(!this.toDestroy){this.toDestroy=true;} else{for(var i=0; i<roomManager.actual['obj0'].length; i++){if(roomManager.actual['obj0'][i] == this){roomManager.actual['obj0'].splice(i,1);break;};};};};this.fixData = function(){if(this.alpha>1)this.alpha=1;if(this.alpha<0)this.alpha=0;while(this.angle>360)this.angle-=360;while(this.angle<0)this.angle+=360;};};var obj1 = function(){this.name='obj1';this._this = this;this.toDestroy=false;this.x = 0;this.y = 0;this.pressed = false;this.alpha = 1;this.angle = 0;this.height = sprite.sprite1.height;this.width = sprite.sprite1.width;this.hspeed = 0;this.vspeed = 0;this.autoDraw = true;this.sprite = sprite.sprite1;this._create_executed=false;this.create = function(){this.hspeed=4;};this.update = function(){if(!this._create_executed){this.create();this._create_executed=true;};if(this.pressed && !mouse.pressed){this.pressed=false;};if(mouse.pressed && roomManager.actual.camera.x + mouse.x > this.x  && roomManager.actual.camera.x + mouse.x < this.x + this.width && roomManager.actual.camera.y + mouse.y > this.y && roomManager.actual.camera.y + mouse.y < this.y + this.height){this.pressed=true;this.destroy(); global.score++;};if(this.toDestroy){this.destroy();};if(this.x + this.hspeed > map.width || this.x+this.hspeed < 0) 	this.hspeed*=-1; this.angle+=Math.sign(this.hspeed);this.x+=this.hspeed;this.y+=this.vspeed;};this.draw = function(){this.fixData();if(this.sprite!=null&&this.autoDraw){context.globalAlpha = this.alpha; drawSpriteExt(this.x,this.y,this.width,this.height,this.sprite,this.angle); context.globalAlpha=1;};};this.keyPressed = function(event){};this.keyReleased = function(event){};this.mousePressed = function(){this.destroy(); global.score++;};this.mouseReleased = function(){};this.destroy = function(){if(!this.toDestroy){this.toDestroy=true;} else{for(var i=0; i<roomManager.actual['obj1'].length; i++){if(roomManager.actual['obj1'][i] == this){roomManager.actual['obj1'].splice(i,1);break;};};};};this.fixData = function(){if(this.alpha>1)this.alpha=1;if(this.alpha<0)this.alpha=0;while(this.angle>360)this.angle-=360;while(this.angle<0)this.angle+=360;};};var rM = function(){this.last = {keyboardEnabled:false,update:function(){},draw:function(){}};this.camera = new camera();this.actual = this.last;this.change=true;this.alpha = 0;this.room2go = new Room0();this.go = function(e){this.last = this.actual;this.room2go = e;this.alpha = 0;this.change=true;};this.update = function(){if(!this.change)this.actual.update();else{if(this.alpha<1 && this.actual != this.room2go)this.alpha+=0.1;else if(this.alpha>=1 && this.actual != this.room2go)this.actual = this.room2go;else if(this.alpha>0 && this.actual == this.room2go)this.alpha-=0.1;else{this.alpha=0;this.change = false;}}};this.draw = function(){this.actual.draw();if(this.change){if(this.alpha>1)this.alpha=1;else if(this.alpha<0)this.alpha=0;context.globalAlpha = this.alpha;drawRect(0,0,canvas.width,canvas.height,0,0,0,0);context.globalAlpha = 1;}}};var Room0 = function(){this.obj0=[];this.obj1=[];this._create_executed=false;this.camera = new camera();this.create = function(){global.score = 0;instance_create(414,534,obj0);instance_create(582,137,obj1);instance_create(53,375,obj1);instance_create(342,207,obj1);instance_create(137,206,obj1);instance_create(437,117,obj1);instance_create(661,428,obj1);instance_create(542,308,obj1);for(var i=0; i<this.obj0.length; i++){if(this.obj0[i]!=null){this.obj0[i].create();};};for(var i=0; i<this.obj1.length; i++){if(this.obj1[i]!=null){this.obj1[i].create();};};};this.update = function(){if(!this._create_executed){this.create();this._create_executed=true;};for(var i=0; i<this.obj0.length; i++){if(this.obj0[i]!=null){this.obj0[i].update();};};for(var i=0; i<this.obj1.length; i++){if(this.obj1[i]!=null){this.obj1[i].update();};};};this.draw = function(){context.clearRect(0,0,canvas.width,canvas.height); drawText(this.camera.x+20,this.camera.y+20,"Score: "+global.score);for(var i=0; i<this.obj0.length; i++){if(this.obj0[i]!=null){this.obj0[i].draw();};};for(var i=0; i<this.obj1.length; i++){if(this.obj1[i]!=null){this.obj1[i].draw();};};};this.keyPressed = function(event){for(var i=0; i<this.obj0.length; i++){if(this.obj0[i]!=null){this.obj0[i].keyPressed(event);};};for(var i=0; i<this.obj1.length; i++){if(this.obj1[i]!=null){this.obj1[i].keyPressed(event);};};};this.keyReleased = function(event){for(var i=0; i<this.obj0.length; i++){if(this.obj0[i]!=null){this.obj0[i].keyReleased(event);};};for(var i=0; i<this.obj1.length; i++){if(this.obj1[i]!=null){this.obj1[i].keyReleased(event);};};};};instance_create = function(x,y,e){var _i = new e(); _i.x = x; _i.y=y; roomManager.actual[_i.name].push(_i);return _i;};var fps = {startTime : 0,frameNumber : 0,get : function(){this.frameNumber++;var d = new Date().getTime(),currentTime = ( d - this.startTime ) / 1000, result = Math.floor( ( this.frameNumber / currentTime ) );if( currentTime > 1 ){this.startTime = new Date().getTime();this.frameNumber = 0;}return result;}};check_collision_object = function(me,other,todo){o_arr = [];for(i=0;i<roomManager.actual[other].length;i++){if(checkCollision(me,roomManager.actual[other][i])){o_arr.push(i);};};o_arr.forEach(todo);};function loop(){roomManager.update();roomManager.draw();};var mouse = new mousePrefab();var roomManager = new rM();var sprite = new sprImport();updateFrame();