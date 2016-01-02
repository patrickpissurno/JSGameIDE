function loop()
{
    roomManager.update();
    roomManager.draw();
};
var mouse = new mousePrefab();
var roomManager = new rM();
var sprite = new sprImport();
updateFrame();