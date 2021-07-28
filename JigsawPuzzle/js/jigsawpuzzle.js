{
  'use strict';

  JigsawPuzzle.Core = {};

  /** ピースのジョイント部分のサイズ */
  const PIECE_JOINT_SIZE = 20;
  /** ジョイント部分を除くピースのサイズ */
  const IMAGE_SPLIT_SIZE = 75
  /** ピース全体の画像サイズ */
  const PIECE_SIZE = IMAGE_SPLIT_SIZE + (PIECE_JOINT_SIZE * 2);

  /**
   * 一つのピースを表すクラス
   */
  class PuzzlePiece {
    constructor(image, width, height, jointWidth, jointHeight) {
      this.image = image;
      this.width = width;
      this.height = height;
      this.jointWidth = jointWidth;
      this.jointHeight = jointHeight;
    }
    draw(context, x, y) {
      context.drawImage(this.image, x - this.jointWidth, y - this.jointHeight);
    }
  };

  class JigsawPuzzleMaker {
    constructor(param) {
      this.image = param.image;
      this.row = param.row;
      this.column = param.column;
    }
    clipPiece(context, left, right, top, bottom) {
      let width = this.image.width / this.row;
      let height = this.image.height / this.column;
      let jointWidth = width * 0.4;
      let jointHeight = height * 0.4;
      let jointArcRadius = height * 0.085;
      let jointArcSize = jointArcRadius * 2;
      let pieceWidth = width + jointWidth * 2;
      let pieceHeight = height + jointHeight * 2;

      // ベースの切り抜き
      context.beginPath();
      context.moveTo(jointWidth, jointHeight);
      context.lineTo(jointWidth + width, jointHeight);
      context.lineTo(jointWidth + width, jointHeight + height);
      context.lineTo(jointWidth, jointHeight + height);
      context.closePath();
      
      context.moveTo(jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize);
      if (left !== null) {
        if (left) {
          context.arc(jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 90 * Math.PI / 180, 270 * Math.PI / 180, false);
        } else {
          context.arc(jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 270 * Math.PI / 180, 90 * Math.PI / 180, false);
        }
      }
      context.closePath();

      context.moveTo(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize);
      if (right !== null) {
        if (right) {
          context.arc(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 270 * Math.PI / 180, 90 * Math.PI / 180, false);
        } else {
          context.arc(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 90 * Math.PI / 180, 270 * Math.PI / 180, false);
        }
      }
      context.closePath();

      context.moveTo(jointWidth * 0.5, jointHeight);
      if (top !== null) {
        if (top) {
          context.arc(pieceWidth * 0.5, jointHeight, jointArcSize, 180 * Math.PI / 180, 360 * Math.PI / 180, false);
        } else {
          context.arc(pieceWidth * 0.5, jointHeight, jointArcSize, 360 * Math.PI / 180, 180 * Math.PI / 180, false);
        }
      }
      context.closePath();

      context.moveTo(pieceWidth / 2, height + jointHeight, jointArcSize);
      if (bottom !== null) {
        if (bottom) {
          context.arc(pieceWidth / 2, height + jointHeight, jointArcSize, 360 * Math.PI / 180, 180 * Math.PI / 180, false);
        } else {
          context.arc(pieceWidth * 0.5, jointHeight, jointArcSize, 360 * Math.PI / 180, 180 * Math.PI / 180, false);
        }
      }
      context.closePath();

      context.clip("evenodd");
    }

    createPieces(options) {
      if (!options) {
        options = {
          grayscale: false,
        }
      } 
      let width = this.image.width / this.row;
      let height = this.image.height / this.column;
      let jointWidth = width * 0.4;
      let jointHeight = height * 0.4;
      let jointArcRadius = 8;
      let jointArcSize = jointArcRadius * 2;
      let pieceWidth = width + jointWidth * 2;
      let pieceHeight = height + jointHeight * 2;

      let halfWidth = width / 2;
      let halfHeight = height / 2;

      let canvas = document.createElement('canvas');
      canvas.setAttribute('width', pieceWidth);
      canvas.setAttribute('height', pieceHeight);
      canvas.setAttribute('hidden', true);
      document.body.appendChild(canvas);
      let context = canvas.getContext('2d');

      let dataURLList = [];
      for(let y = 0; y < this.column; ++y) {
        for(let x = 0; x < this.row; ++x) {
          context.clearRect(0, 0, canvas.width, canvas.height);
          context.save();
          this.clipPiece(context, 
            x === 0 ? null : true, 
            x === this.row - 1 ? null : false, 
            y === 0 ? null : false, 
            true);
          context.drawImage(this.image, 
            (width * x) - jointWidth, (height * y) - jointHeight, pieceWidth, pieceHeight, 
            0, 0, pieceWidth, pieceHeight
          );

          if (options.grayscale) {
            let pixels = context.getImageData(0, 0, pieceWidth, pieceHeight);
            for(let y = 0; y < pixels.height; y++){
              for(let x = 0; x < pixels.width; x++){
                let i = (y * 4) * pixels.width + x * 4;
                let avg = (pixels.data[i] + pixels.data[i + 1] + pixels.data[i + 2]) / 3;
                pixels.data[i] = avg;
                pixels.data[i + 1] = avg;
                pixels.data[i + 2] = avg;
              }
            }
            context.putImageData(pixels, 0, 0, 0, 0, pixels.width, pixels.height);
          }

          context.restore();
          dataURLList.push(canvas.toDataURL());
        }
      }

      document.body.removeChild(canvas);

      // DataURL から Image にロード
      return new Promise(
        (resolve, _) => {
          let pieceList = []
          let loadedCount = 0;
          for (let i in dataURLList) {
            let pieceImage = new Image();
            pieceImage.src = dataURLList[i];
            pieceImage.addEventListener("load", function() {
              if (++loadedCount >= pieceList.length) {
                resolve(pieceList);
              }
            });
            pieceList[i] = new PuzzlePiece(pieceImage, width, height, jointWidth, jointHeight);
          }
          return pieceList;
        }
      );
    }
  };
  JigsawPuzzle.Core.JigsawPuzzleMaker = JigsawPuzzleMaker;
}
