var Button = function()
{
    this.x = 0;
    this.y = 0;
    this.width = 80;
    this.height = 30;
    
    this.draw = function()
    {
        drawRect(this.x, this.y, this.width, this.height, 200, 200, 200, false);
        drawRect(this.x, this.y, this.width, this.height, 30, 30, 30, true);
        drawText(this.x + this.width/2, this.y + this.height/2,"Button","14px Arial","#000","center");
    }
}