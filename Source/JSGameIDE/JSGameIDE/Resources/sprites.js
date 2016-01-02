var sprImport = function()
{
    #FOREACH Sprite
        this.sprite$spriteId = [];
        #FOREACH Frame
            this.sprite$spriteId[$frameId] = new Image();
            this.sprite$spriteId[$frameId].src = $framePath;
        #END
    #END
}