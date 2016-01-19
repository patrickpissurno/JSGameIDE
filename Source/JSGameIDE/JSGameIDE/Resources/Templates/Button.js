var Button = function()
{
    this.x = 0;
    this.y = 0;
    this.width = 50;
    this.height = 50;
    
    this.draw = function()
    {
        drawRect(this.x, this.y, this.width, this.height, 255, 0, 0, false);
        drawText(this.x + this.width/2, this.y + this.height/2,"Button","14px Arial","#000","center");
    }
}