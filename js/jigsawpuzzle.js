{
  'use strict';

  JigsawPuzzle.Core = {};

  JigsawPuzzle.Core.createPieces = function(image, row, column) {
    let width = image.width / row;
    let height = image.height / column;
    let canvas = document.createElement('canvas');
    canvas.setAttribute('width', width);
    canvas.setAttribute('height', height);
    canvas.setAttribute('hidden', true);
    document.body.appendChild(canvas);
    let context = canvas.getContext('2d');

    let dataURLList = []
    for(let num = 0; num < row * column; num++) {
      context.clearRect(0,0, canvas.width, canvas.height);
      context.drawImage(image, width * (num % row), height * Math.floor(num / row), width, height, 0, 0, width, height);
      dataURLList.push(canvas.toDataURL());
    }

    return new Promise(
      (resolve, reject) => {
        let imageList = []
        let loadedCount = 0;
        for (let i in dataURLList) {
          imageList[i] = new Image();
          imageList[i].src = dataURLList[i];
          imageList[i].addEventListener("load", function() {
            if (++loadedCount >= imageList.length) {
              resolve(imageList);
            }
          });
        }
        return imageList;
      }
    );
  };
}
