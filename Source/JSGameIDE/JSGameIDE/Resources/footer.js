function loop()
{
    roomManager.update();
    roomManager.draw();
    roomManager.drawUI();
};
var mouse = new mousePrefab();
var roomManager = new rM();
var sprite = new sprImport();
var sound = new sndImport();
updateFrame();