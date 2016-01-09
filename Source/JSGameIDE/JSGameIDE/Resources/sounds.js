var sndImport = function()
{
    #FOREACH Sound
        this.sound$soundId = new Audio("$soundPath");
    #END
}