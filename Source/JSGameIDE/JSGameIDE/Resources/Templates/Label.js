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
		this.height = measureTextHeight(this.font, this.text);
	}
	
    this.draw = function()
    {
        UI.DrawText(this.x, this.y + this.height + 1, this.text, this.font,"#000","left");
    }
    
}