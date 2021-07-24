var JigsawPuzzle = {};
{
  'use strict';

  JigsawPuzzle.Common = {};

  JigsawPuzzle.Common.initialize = function() {
  };

  JigsawPuzzle.Common.loadImages = function(fileList, loadComplete) {
    return new Promise(
      (resolve, _) => {
        let imageList = []
        let loadedCount = 0;
        for (let i in fileList) {
          imageList[i] = new Image();
          imageList[i].src = fileList[i];
          imageList[i].addEventListener("load", function() {
            if (++loadedCount >= imageList.length) {
              resolve(imageList);
            }
          });
        }
      }
    );
  };

  JigsawPuzzle.Common.run = function(drawFunc) {
    let canvas = document.getElementById("canvas");
    let context = canvas.getContext("2d");
    drawFunc(context, canvas);
    return canvas;
  };
}
