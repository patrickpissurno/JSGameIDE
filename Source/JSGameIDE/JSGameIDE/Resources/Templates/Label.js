var Label = function()
{
    this.x = 0;
    this.y = 0;
    this.width = 50;
    this.height = 30;
	this.text = "Label";
	this.font = "22px Arial";
    
	this.create = function()
	{
		var backup = context.font;
		context.font = this.font;
		this.height = measureTextHeight(0, 0, 50, 50, this.text);
		context.font = backup;
	}
	
    this.draw = function()
    {
        UI.DrawText(this.x, this.y + this.height + 1, this.text, this.font,"#000","left");
    }
    
}