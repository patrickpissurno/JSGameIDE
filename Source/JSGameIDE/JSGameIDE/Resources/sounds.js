var sndImport = function()
{
    this.sounds = [];
    #FOREACH Sound
        this.sound$soundId = new Audio("$soundPath");
        this.sound$soundId.preload = "none";
        this.sounds.push(this.sound$soundId);
    #END
}