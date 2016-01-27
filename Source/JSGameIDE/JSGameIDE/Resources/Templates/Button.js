var Button = function()
{
    this.x = 0;
    this.y = 0;
    this.width = 80;
    this.height = 30;
    this.pressed = [false, false, false];
    
    this.text = "Button";
	this.font = "14px Arial";
	this.textHeight = 0;
    
    this.create = function()
    {
        //Measures the Text Height (for vertical center alignment)
		this.textHeight = measureTextHeight(this.font, this.text);
    }
    
    this.draw = function()
    {
        UI.DrawRect(this.x, this.y, this.width, this.height, 200, 200, 200, false);
        UI.DrawRect(this.x, this.y, this.width, this.height, 30, 30, 30, true);
        UI.DrawText(this.x + this.width/2, this.y + this.height/2 + this.textHeight/2, this.text, this.font, "#000","center");
    }
    
    this.mouseReleased = function(event)
    {
        if(event.button == 0) //Left mouse button
        {
            alert("'" + this.text + "' button was pressed");
        }
    }
}