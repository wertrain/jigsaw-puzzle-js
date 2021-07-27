{
  'use strict';

  JigsawPuzzle.Utils = {};

  JigsawPuzzle.Utils.grayscale = (image) => {
    let canvas = document.createElement('canvas');
    canvas.setAttribute('width', image.width);
    canvas.setAttribute('height', image.height);
    canvas.setAttribute('hidden', true);
    document.body.appendChild(canvas);
    let canvasContext = canvas.getContext('2d');
    
    let imgW = image.width;
    let imgH = image.height;
    canvas.width = imgW;
    canvas.height = imgH;

    canvasContext.drawImage(image, 0, 0);

    var imgPixels = canvasContext.getImageData(0, 0, imgW, imgH);

    for(let y = 0; y < imgPixels.height; y++){
        for(let x = 0; x < imgPixels.width; x++){
          var i = (y * 4) * imgPixels.width + x * 4;
          var avg = (imgPixels.data[i] + imgPixels.data[i + 1] + imgPixels.data[i + 2]) / 3;
          imgPixels.data[i] = avg;
          imgPixels.data[i + 1] = avg;
          imgPixels.data[i + 2] = avg;
        }
    }

    canvasContext.putImageData(imgPixels, 0, 0, 0, 0, imgPixels.width, imgPixels.height);
    dataurl = canvas.toDataURL();
    //document.body.removeChild(canvas);
    return new Promise(
      (resolve, _) => {
        let newimg = new Image();
        newimg.src = canvas.toDataURL();
        newimg.addEventListener("load", function() {
          resolve(newimg);
        });
      }
    );
  }
}