var JigsawPuzzle = {};
{
  'use strict';

  JigsawPuzzle.Common = {};

  JigsawPuzzle.Common.initialize = function() {

  };
  
  JigsawPuzzle.Common.run = function(drawFunc) {
    let canvas = document.getElementById("canvas");
    let context = canvas.getContext("2d");
    drawFunc(context);
    return canvas;
  };
}
