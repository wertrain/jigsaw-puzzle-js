{
  'use strict';

  JigsawPuzzle.Core = {};

  /** ピースのジョイント部分のサイズ */
  const PIECE_JOINT_SIZE = 20;
  /** ジョイント部分を除くピースのサイズ */
  const IMAGE_SPLIT_SIZE = 75
  /** ピース全体の画像サイズ */
  const PIECE_SIZE = IMAGE_SPLIT_SIZE + (PIECE_JOINT_SIZE * 2);

    
  class PuzzlePiece {
    constructor(image, jointWidth, jointHeight) {
      this.image = image;
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
      let jointArcRadius = 8;
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
      if (left) {
        context.arc(jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 90 * Math.PI / 180, 270 * Math.PI / 180, false);
      } else {
        context.arc(jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 270 * Math.PI / 180, 90 * Math.PI / 180, false);
      }
      context.closePath();

      context.moveTo(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize);
      if (right) {
        context.arc(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 270 * Math.PI / 180, 90 * Math.PI / 180, false);
      } else {
        context.arc(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 90 * Math.PI / 180, 270 * Math.PI / 180, false);
      }
      context.closePath();

      context.moveTo(jointWidth * 0.5, jointHeight);
      if (top) {
        context.arc(pieceWidth * 0.5, jointHeight, jointArcSize, 180 * Math.PI / 180, 360 * Math.PI / 180, false);
      } else {
        context.arc(pieceWidth * 0.5, jointHeight, jointArcSize, 360 * Math.PI / 180, 180 * Math.PI / 180, false);
      }
      context.closePath();

      context.moveTo(pieceWidth / 2, height + jointHeight, jointArcSize);
      if (bottom) {
        context.arc(pieceWidth / 2, height + jointHeight, jointArcSize, 360 * Math.PI / 180, 180 * Math.PI / 180, false);
      } else {
        context.arc(pieceWidth * 0.5, jointHeight, jointArcSize, 360 * Math.PI / 180, 180 * Math.PI / 180, false);
      }
      context.closePath();

      context.clip("evenodd");
    }

    createPieces() {
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


          // ベースの切り抜き
          context.beginPath();
          context.moveTo(jointWidth, jointHeight);
          context.lineTo(jointWidth + width, jointHeight);
          context.lineTo(jointWidth + width, jointHeight + height);
          context.lineTo(jointWidth, jointHeight + height);
          context.closePath();

          this.clipPiece(context, true, false, false, true);


          // 上の ON ジョイント作成
          //context.arc(pieceWidth / 2, jointHeight / 2, jointArcSize, 0 * Math.PI / 180, 360 * Math.PI / 180, false);
          //context.moveTo((jointWidth + width * 0.5) - jointArcSize + jointArcRadius, jointHeight - jointArcSize);
          //context.lineTo((jointWidth + width * 0.5) + jointArcSize - jointArcRadius, jointHeight - jointArcSize);
          //context.lineTo((jointWidth + width * 0.5) + jointArcSize - jointArcRadius, jointHeight - jointArcSize + height / 4);
          //context.lineTo((jointWidth + width * 0.5) - jointArcSize + jointArcRadius, jointHeight - jointArcSize + height / 4);
          //context.closePath();
          //context.clip();
          // 上の OFF ジョイント作成
          //context.moveTo((jointWidth + width * 0.5) - jointArcSize + jointArcRadius, jointHeight);
          //context.lineTo((jointWidth + width * 0.5) + jointArcSize - jointArcRadius, jointHeight);
          //context.lineTo((jointWidth + width * 0.5) + jointArcSize - jointArcRadius, jointHeight + jointHeight - jointArcSize);
          //context.lineTo((jointWidth + width * 0.5) - jointArcSize + jointArcRadius, jointHeight + jointHeight - jointArcSize);
          //context.closePath();
          //context.arc(pieceWidth / 2, jointHeight + jointHeight, jointArcSize, 0 * Math.PI / 180, 360 * Math.PI / 180, false);
          //context.clip("evenodd");
          // 右の ON ジョイント作成
          //context.closePath();
          //context.arc(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 0 * Math.PI / 180, 360 * Math.PI / 180, false);
          //context.clip();
          
          // 右の OFF ジョイント作成
          //context.moveTo(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize);
          //context.arc(pieceWidth - jointWidth, (jointHeight * 0.5 + height * 0.5) + jointArcSize, jointArcSize, 90 * Math.PI / 180, 270 * Math.PI / 180);
          //context.closePath();
          //context.clip("evenodd");
          // 下の ON ジョイント作成
          //context.arc(pieceWidth / 2, height + jointHeight, jointArcSize, 0 * Math.PI / 180, 360 * Math.PI / 180, false);
          //context.closePath();
          //context.clip();
          // 下の OFF ジョイント作成
          //context.moveTo(pieceWidth * 0.5, (jointHeight * 0.5 + height) + jointArcSize - 1);
          //context.arc(pieceWidth * 0.5, (jointHeight * 0.5 + height) + jointArcSize - 1, jointArcSize, 180 * Math.PI / 180, 360 * Math.PI / 180);
                   /*
          context.arc(pieceWidth / 2, jointHeight, jointArcSize, 0 * Math.PI / 180, 360 * Math.PI / 180, false);
          
          context.moveTo(0, 0);
          context.lineTo(pieceWidth, 0);
          context.lineTo(pieceWidth, jointHeight);
          context.lineTo(0, jointHeight);

          context.moveTo((jointWidth + width * 0.5) - jointArcSize + (jointArcRadius / 2), 0);
          context.lineTo((jointWidth + width * 0.5) + jointArcSize, 0);
          context.lineTo((jointWidth + width * 0.5) + jointArcSize, jointHeight - jointArcSize);
          context.lineTo((jointWidth + width * 0.5) - jointArcSize + (jointArcRadius / 2), jointHeight - jointArcSize);
          */
         



          context.drawImage(this.image, 
            (width * x) - jointWidth, (height * y) - jointHeight, pieceWidth, pieceHeight, 
            0, 0, pieceWidth, pieceHeight
          );

          context.restore();
          dataURLList.push(canvas.toDataURL());
        }
      }

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
            pieceList[i] = new PuzzlePiece(pieceImage, jointWidth, jointHeight);
          }
          return pieceList;
        }
      );
    }
  };
  JigsawPuzzle.Core.JigsawPuzzleMaker = JigsawPuzzleMaker;

  /**
   * ピースを作成
   * @param {*} context 
   * @param {*} param 
   * @returns 
   */
  let clipPiece0 = function(context, param) {
    switch (param.pattern) {
      case PiecePattern.P0011:
        context.beginPath();
        context.moveTo(94, 75);
        context.lineTo(65, 75);
        context.lineTo(65, 79);
        context.lineTo(67, 83);
        context.lineTo(69, 87);
        context.lineTo(67, 91);
        context.lineTo(63, 94);
        context.lineTo(59, 95);
        context.lineTo(55, 95);
        context.lineTo(51, 94);
        context.lineTo(48, 91);
        context.lineTo(46, 87);
        context.lineTo(48, 83);
        context.lineTo(51, 80);
        context.lineTo(50, 77);
        context.lineTo(49, 75);
        context.lineTo(20, 74);
        context.lineTo(20, 45);
        context.lineTo(16, 44);
        context.lineTo(13, 44);
        context.lineTo(10, 47);
        context.lineTo(7, 47);
        context.lineTo(4, 46);
        context.lineTo(1, 44);
        context.lineTo(0, 40);
        context.lineTo(0, 35);
        context.lineTo(1, 30);
        context.lineTo(3, 27);
        context.lineTo(6, 26);
        context.lineTo(10, 26);
        context.lineTo(13, 28);
        context.lineTo(16, 30);
        context.lineTo(20, 28);
        context.lineTo(20, 0);
        context.lineTo(50, 0);
        context.lineTo(50, 4);
        context.lineTo(48, 8);
        context.lineTo(47, 12);
        context.lineTo(49, 16);
        context.lineTo(54, 19);
        context.lineTo(59, 20);
        context.lineTo(63, 18);
        context.lineTo(66, 15);
        context.lineTo(68, 11);
        context.lineTo(66, 7);
        context.lineTo(64, 4);
        context.lineTo(65, 0);
        context.lineTo(95, 0);
        context.lineTo(95, 31);
        context.lineTo(89, 30);
        context.lineTo(85, 26);
        context.lineTo(81, 27);
        context.lineTo(77, 30);
        context.lineTo(75, 35);
        context.lineTo(75, 40);
        context.lineTo(77, 44);
        context.lineTo(80, 47);
        context.lineTo(84, 47);
        context.lineTo(89, 45);
        context.lineTo(92, 43);
        context.lineTo(95, 46);
        context.closePath();
        context.clip();
        return;
      case PiecePattern.P0012:
        context.beginPath();
        context.moveTo(74, 75);
        context.lineTo(45, 75);
        context.lineTo(45, 79);
        context.lineTo(47, 83);
        context.lineTo(49, 87);
        context.lineTo(47, 91);
        context.lineTo(43, 94);
        context.lineTo(39, 95);
        context.lineTo(35, 95);
        context.lineTo(31, 94);
        context.lineTo(28, 91);
        context.lineTo(26, 87);
        context.lineTo(28, 83);
        context.lineTo(31, 80);
        context.lineTo(30, 77);
        context.lineTo(29, 75);
        context.lineTo(0, 74);
        context.lineTo(0, 0);
        context.lineTo(30, 0);
        context.lineTo(30, 4);
        context.lineTo(28, 8);
        context.lineTo(27, 12);
        context.lineTo(29, 16);
        context.lineTo(34, 19);
        context.lineTo(39, 20);
        context.lineTo(43, 18);
        context.lineTo(46, 15);
        context.lineTo(48, 11);
        context.lineTo(46, 7);
        context.lineTo(44, 4);
        context.lineTo(45, 0);
        context.lineTo(75, 0);
        context.lineTo(75, 31);
        context.lineTo(69, 30);
        context.lineTo(65, 26);
        context.lineTo(61, 27);
        context.lineTo(57, 30);
        context.lineTo(55, 35);
        context.lineTo(55, 40);
        context.lineTo(57, 44);
        context.lineTo(60, 47);
        context.lineTo(64, 47);
        context.lineTo(69, 45);
        context.lineTo(72, 43);
        context.lineTo(75, 46);
        context.closePath();
        context.clip();
        return;
      case PiecePattern.P0100:
        context.beginPath();
        context.moveTo(75, 0);
        context.lineTo(75, 29);
        context.lineTo(78, 31);
        context.lineTo(82, 29);
        context.lineTo(87, 26);
        context.lineTo(91, 27);
        context.lineTo(93, 31);
        context.lineTo(95, 35);
        context.lineTo(94, 40);
        context.lineTo(92, 45);
        context.lineTo(87, 48);
        context.lineTo(82, 45);
        context.lineTo(78, 43);
        context.lineTo(75, 46);
        context.lineTo(75, 74);
        context.lineTo(45, 75);
        context.lineTo(44, 71);
        context.lineTo(45, 69);
        context.lineTo(47, 66);
        context.lineTo(48, 63);
        context.lineTo(47, 59);
        context.lineTo(43, 56);
        context.lineTo(38, 55);
        context.lineTo(33, 55);
        context.lineTo(29, 57);
        context.lineTo(27, 60);
        context.lineTo(26, 64);
        context.lineTo(28, 66);
        context.lineTo(30, 68);
        context.lineTo(31, 71);
        context.lineTo(30, 75);
        context.lineTo(0, 75);
        context.lineTo(0, 44);
        context.lineTo(3, 43);
        context.lineTo(7, 47);
        context.lineTo(11, 48);
        context.lineTo(15, 48);
        context.lineTo(18, 44);
        context.lineTo(20, 38);
        context.lineTo(19, 32);
        context.lineTo(15, 27);
        context.lineTo(10, 26);
        context.lineTo(7, 29);
        context.lineTo(4, 30);
        context.lineTo(0, 30);
        context.lineTo(0, 0);
        context.lineTo(31, 0);
        context.lineTo(30, 5);
        context.lineTo(27, 8);
        context.lineTo(27, 13);
        context.lineTo(29, 17);
        context.lineTo(33, 19);
        context.lineTo(38, 20);
        context.lineTo(43, 18);
        context.lineTo(47, 15);
        context.lineTo(47, 10);
        context.lineTo(44, 5);
        context.lineTo(44, 0);
        context.closePath();
        context.clip();
        return;
      case PiecePattern.P0101:
        context.beginPath();
        context.moveTo(95, 29);
        context.lineTo(98, 31);
        context.lineTo(101, 29);
        context.lineTo(105, 26);
        context.lineTo(109, 27);
        context.lineTo(113, 31);
        context.lineTo(115, 35);
        context.lineTo(115, 39);
        context.lineTo(114, 43);
        context.lineTo(112, 46);
        context.lineTo(108, 48);
        context.lineTo(104, 47);
        context.lineTo(100, 45);
        context.lineTo(97, 43);
        context.lineTo(95, 45);
        context.lineTo(95, 75);
        context.lineTo(65, 75);
        context.lineTo(63, 71);
        context.lineTo(65, 67);
        context.lineTo(67, 63);
        context.lineTo(65, 58);
        context.lineTo(61, 55);
        context.lineTo(56, 55);
        context.lineTo(52, 56);
        context.lineTo(48, 58);
        context.lineTo(46, 62);
        context.lineTo(47, 66);
        context.lineTo(49, 69);
        context.lineTo(51, 71);
        context.lineTo(49, 75);
        context.lineTo(19, 75);
        context.lineTo(19, 45);
        context.lineTo(17, 43);
        context.lineTo(14, 44);
        context.lineTo(12, 46);
        context.lineTo(8, 47);
        context.lineTo(4, 46);
        context.lineTo(0, 42);
        context.lineTo(0, 37);
        context.lineTo(0, 31);
        context.lineTo(5, 26);
        context.lineTo(9, 26);
        context.lineTo(12, 28);
        context.lineTo(15, 30);
        context.lineTo(19, 30);
        context.lineTo(19, 0);
        context.lineTo(49, 0);
        context.lineTo(50, 5);
        context.lineTo(47, 9);
        context.lineTo(47, 13);
        context.lineTo(50, 17);
        context.lineTo(55, 19);
        context.lineTo(60, 19);
        context.lineTo(65, 17);
        context.lineTo(67, 13);
        context.lineTo(67, 9);
        context.lineTo(65, 7);
        context.lineTo(63, 4);
        context.lineTo(65, 0);
        context.lineTo(95, 0);
        context.closePath();
        context.clip();
        return;
      case PiecePattern.P0102:
        context.beginPath();
        context.moveTo(44, 74);
        context.lineTo(44, 71);
        context.lineTo(45, 68);
        context.lineTo(48, 65);
        context.lineTo(48, 62);
        context.lineTo(47, 59);
        context.lineTo(43, 56);
        context.lineTo(39, 55);
        context.lineTo(35, 55);
        context.lineTo(31, 56);
        context.lineTo(28, 59);
        context.lineTo(27, 63);
        context.lineTo(28, 67);
        context.lineTo(31, 70);
        context.lineTo(31, 75);
        context.lineTo(0, 75);
        context.lineTo(0, 0);
        context.lineTo(30, 0);
        context.lineTo(31, 4);
        context.lineTo(28, 7);
        context.lineTo(27, 12);
        context.lineTo(28, 16);
        context.lineTo(32, 19);
        context.lineTo(37, 20);
        context.lineTo(42, 19);
        context.lineTo(46, 16);
        context.lineTo(48, 12);
        context.lineTo(47, 8);
        context.lineTo(44, 4);
        context.lineTo(45, 0);
        context.lineTo(75, 0);
        context.lineTo(75, 29);
        context.lineTo(78, 31);
        context.lineTo(82, 30);
        context.lineTo(84, 27);
        context.lineTo(88, 27);
        context.lineTo(92, 29);
        context.lineTo(95, 33);
        context.lineTo(95, 39);
        context.lineTo(93, 45);
        context.lineTo(90, 48);
        context.lineTo(86, 49);
        context.lineTo(82, 47);
        context.lineTo(79, 44);
        context.lineTo(75, 45);
        context.lineTo(75, 75);
        context.closePath();
        context.clip();
        return;
      case PiecePattern.P0201:
        context.beginPath();
        context.moveTo(62, 54);
        context.lineTo(55, 54);
        context.lineTo(50, 56);
        context.lineTo(48, 61);
        context.lineTo(48, 66);
        context.lineTo(52, 70);
        context.lineTo(49, 74);
        context.lineTo(20, 74);
        context.lineTo(20, 45);
        context.lineTo(16, 43);
        context.lineTo(11, 47);
        context.lineTo(7, 47);
        context.lineTo(3, 44);
        context.lineTo(1, 41);
        context.lineTo(0, 36);
        context.lineTo(2, 30);
        context.lineTo(5, 26);
        context.lineTo(10, 26);
        context.lineTo(15, 29);
        context.lineTo(20, 29);
        context.lineTo(20, 0);
        context.lineTo(51, 0);
        context.lineTo(50, 5);
        context.lineTo(47, 9);
        context.lineTo(48, 14);
        context.lineTo(52, 17);
        context.lineTo(57, 18);
        context.lineTo(62, 19);
        context.lineTo(66, 16);
        context.lineTo(68, 12);
        context.lineTo(68, 7);
        context.lineTo(64, 4);
        context.lineTo(64, 0);
        context.lineTo(96, 0);
        context.lineTo(95, 74);
        context.lineTo(65, 74);
        context.lineTo(64, 70);
        context.lineTo(68, 66);
        context.lineTo(69, 61);
        context.lineTo(67, 57);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P0210:
        context.beginPath();
        context.moveTo(0, 45);
        context.lineTo(2, 44);
        context.lineTo(5, 45);
        context.lineTo(8, 48);
        context.lineTo(12, 49);
        context.lineTo(15, 47);
        context.lineTo(17, 44);
        context.lineTo(19, 39);
        context.lineTo(19, 35);
        context.lineTo(17, 31);
        context.lineTo(14, 28);
        context.lineTo(10, 27);
        context.lineTo(6, 30);
        context.lineTo(3, 31);
        context.lineTo(0, 31);
        context.lineTo(0, 0);
        context.lineTo(29, 0);
        context.lineTo(30, 5);
        context.lineTo(27, 8);
        context.lineTo(26, 12);
        context.lineTo(27, 15);
        context.lineTo(30, 18);
        context.lineTo(34, 20);
        context.lineTo(40, 20);
        context.lineTo(44, 18);
        context.lineTo(47, 15);
        context.lineTo(47, 12);
        context.lineTo(46, 9);
        context.lineTo(44, 6);
        context.lineTo(43, 3);
        context.lineTo(45, 0);
        context.lineTo(75, 0);
        context.lineTo(75, 75);
        context.lineTo(44, 75);
        context.lineTo(43, 79);
        context.lineTo(45, 82);
        context.lineTo(47, 85);
        context.lineTo(47, 89);
        context.lineTo(45, 92);
        context.lineTo(42, 95);
        context.lineTo(36, 95);
        context.lineTo(31, 95);
        context.lineTo(28, 92);
        context.lineTo(26, 87);
        context.lineTo(27, 83);
        context.lineTo(30, 80);
        context.lineTo(30, 77);
        context.lineTo(29, 75);
        context.lineTo(0, 75);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P0221:
        context.beginPath();
        context.moveTo(19, 0);
        context.lineTo(49, 0);
        context.lineTo(50, 4);
        context.lineTo(48, 7);
        context.lineTo(46, 10);
        context.lineTo(46, 13);
        context.lineTo(48, 16);
        context.lineTo(52, 19);
        context.lineTo(56, 20);
        context.lineTo(59, 20);
        context.lineTo(62, 19);
        context.lineTo(65, 17);
        context.lineTo(67, 14);
        context.lineTo(67, 11);
        context.lineTo(66, 8);
        context.lineTo(64, 5);
        context.lineTo(63, 3);
        context.lineTo(64, 0);
        context.lineTo(95, 0);
        context.lineTo(95, 75);
        context.lineTo(18, 75);
        context.lineTo(18, 46);
        context.lineTo(16, 44);
        context.lineTo(13, 45);
        context.lineTo(10, 47);
        context.lineTo(7, 48);
        context.lineTo(3, 47);
        context.lineTo(1, 44);
        context.lineTo(0, 39);
        context.lineTo(0, 34);
        context.lineTo(1, 29);
        context.lineTo(4, 27);
        context.lineTo(8, 26);
        context.lineTo(12, 29);
        context.lineTo(15, 30);
        context.lineTo(18, 29);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P1000:
        context.beginPath();
        context.moveTo(74, 96);
        context.lineTo(44, 96);
        context.lineTo(44, 92);
        context.lineTo(45, 89);
        context.lineTo(47, 86);
        context.lineTo(48, 83);
        context.lineTo(46, 80);
        context.lineTo(43, 77);
        context.lineTo(37, 76);
        context.lineTo(33, 76);
        context.lineTo(29, 78);
        context.lineTo(26, 81);
        context.lineTo(26, 85);
        context.lineTo(27, 88);
        context.lineTo(29, 90);
        context.lineTo(30, 92);
        context.lineTo(30, 96);
        context.lineTo(0, 96);
        context.lineTo(0, 66);
        context.lineTo(6, 66);
        context.lineTo(8, 69);
        context.lineTo(11, 69);
        context.lineTo(14, 68);
        context.lineTo(17, 66);
        context.lineTo(18, 63);
        context.lineTo(19, 60);
        context.lineTo(19, 57);
        context.lineTo(18, 53);
        context.lineTo(17, 51);
        context.lineTo(15, 49);
        context.lineTo(12, 48);
        context.lineTo(9, 48);
        context.lineTo(6, 51);
        context.lineTo(0, 51);
        context.lineTo(0, 21);
        context.lineTo(29, 21);
        context.lineTo(30, 18);
        context.lineTo(29, 15);
        context.lineTo(26, 11);
        context.lineTo(26, 7);
        context.lineTo(28, 3);
        context.lineTo(32, 1);
        context.lineTo(37, 0);
        context.lineTo(41, 1);
        context.lineTo(45, 3);
        context.lineTo(47, 6);
        context.lineTo(48, 10);
        context.lineTo(46, 13);
        context.lineTo(44, 17);
        context.lineTo(45, 21);
        context.lineTo(75, 21);
        context.lineTo(75, 51);
        context.lineTo(71, 52);
        context.lineTo(68, 51);
        context.lineTo(66, 49);
        context.lineTo(62, 48);
        context.lineTo(58, 50);
        context.lineTo(55, 53);
        context.lineTo(55, 57);
        context.lineTo(55, 61);
        context.lineTo(56, 64);
        context.lineTo(59, 67);
        context.lineTo(62, 69);
        context.lineTo(66, 68);
        context.lineTo(69, 66);
        context.lineTo(72, 65);
        context.lineTo(75, 67);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P1010:
        context.beginPath();
        context.moveTo(74, 94);
        context.lineTo(44, 94);
        context.lineTo(43, 97);
        context.lineTo(44, 100);
        context.lineTo(46, 103);
        context.lineTo(47, 106);
        context.lineTo(46, 109);
        context.lineTo(44, 112);
        context.lineTo(41, 114);
        context.lineTo(37, 115);
        context.lineTo(34, 114);
        context.lineTo(31, 113);
        context.lineTo(29, 111);
        context.lineTo(27, 109);
        context.lineTo(26, 106);
        context.lineTo(27, 103);
        context.lineTo(29, 101);
        context.lineTo(30, 98);
        context.lineTo(30, 94);
        context.lineTo(0, 94);
        context.lineTo(0, 64);
        context.lineTo(6, 64);
        context.lineTo(8, 67);
        context.lineTo(11, 67);
        context.lineTo(14, 66);
        context.lineTo(17, 64);
        context.lineTo(18, 61);
        context.lineTo(19, 58);
        context.lineTo(19, 55);
        context.lineTo(18, 51);
        context.lineTo(17, 49);
        context.lineTo(15, 47);
        context.lineTo(12, 46);
        context.lineTo(9, 46);
        context.lineTo(6, 49);
        context.lineTo(0, 49);
        context.lineTo(0, 19);
        context.lineTo(29, 19);
        context.lineTo(30, 16);
        context.lineTo(29, 13);
        context.lineTo(26, 9);
        context.lineTo(27, 4);
        context.lineTo(30, 0);
        context.lineTo(37, 0);
        context.lineTo(43, 0);
        context.lineTo(47, 4);
        context.lineTo(48, 8);
        context.lineTo(46, 11);
        context.lineTo(44, 15);
        context.lineTo(45, 19);
        context.lineTo(75, 19);
        context.lineTo(75, 49);
        context.lineTo(71, 50);
        context.lineTo(68, 49);
        context.lineTo(66, 47);
        context.lineTo(62, 46);
        context.lineTo(58, 48);
        context.lineTo(55, 51);
        context.lineTo(55, 55);
        context.lineTo(55, 59);
        context.lineTo(56, 62);
        context.lineTo(59, 65);
        context.lineTo(62, 67);
        context.lineTo(66, 66);
        context.lineTo(69, 64);
        context.lineTo(72, 63);
        context.lineTo(75, 65);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P1021:
        context.beginPath();
        context.moveTo(19, 21);
        context.lineTo(49, 21);
        context.lineTo(51, 17);
        context.lineTo(49, 13);
        context.lineTo(47, 11);
        context.lineTo(46, 7);
        context.lineTo(48, 4);
        context.lineTo(51, 1);
        context.lineTo(56, 1);
        context.lineTo(61, 1);
        context.lineTo(64, 2);
        context.lineTo(66, 5);
        context.lineTo(68, 9);
        context.lineTo(66, 12);
        context.lineTo(64, 14);
        context.lineTo(63, 17);
        context.lineTo(65, 21);
        context.lineTo(95, 21);
        context.lineTo(95, 51);
        context.lineTo(92, 52);
        context.lineTo(89, 51);
        context.lineTo(86, 48);
        context.lineTo(82, 47);
        context.lineTo(79, 48);
        context.lineTo(76, 51);
        context.lineTo(75, 55);
        context.lineTo(75, 58);
        context.lineTo(75, 61);
        context.lineTo(76, 64);
        context.lineTo(79, 67);
        context.lineTo(82, 68);
        context.lineTo(85, 68);
        context.lineTo(87, 66);
        context.lineTo(90, 64);
        context.lineTo(94, 65);
        context.lineTo(94, 96);
        context.lineTo(18, 96);
        context.lineTo(18, 67);
        context.lineTo(16, 65);
        context.lineTo(13, 66);
        context.lineTo(10, 68);
        context.lineTo(7, 69);
        context.lineTo(3, 68);
        context.lineTo(1, 65);
        context.lineTo(0, 60);
        context.lineTo(0, 55);
        context.lineTo(1, 50);
        context.lineTo(4, 48);
        context.lineTo(8, 47);
        context.lineTo(12, 50);
        context.lineTo(15, 51);
        context.lineTo(18, 50);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P1022:
        context.beginPath();
        context.moveTo(0, 20);
        context.lineTo(30, 20);
        context.lineTo(32, 16);
        context.lineTo(30, 12);
        context.lineTo(28, 10);
        context.lineTo(27, 6);
        context.lineTo(29, 3);
        context.lineTo(32, 0);
        context.lineTo(37, 0);
        context.lineTo(42, 0);
        context.lineTo(45, 1);
        context.lineTo(47, 4);
        context.lineTo(49, 8);
        context.lineTo(47, 11);
        context.lineTo(45, 13);
        context.lineTo(44, 16);
        context.lineTo(46, 20);
        context.lineTo(76, 20);
        context.lineTo(76, 50);
        context.lineTo(73, 51);
        context.lineTo(70, 50);
        context.lineTo(67, 47);
        context.lineTo(63, 46);
        context.lineTo(60, 47);
        context.lineTo(57, 50);
        context.lineTo(56, 54);
        context.lineTo(56, 57);
        context.lineTo(56, 60);
        context.lineTo(57, 63);
        context.lineTo(60, 66);
        context.lineTo(63, 67);
        context.lineTo(66, 67);
        context.lineTo(68, 65);
        context.lineTo(71, 63);
        context.lineTo(75, 64);
        context.lineTo(76, 95);
        context.lineTo(0, 95);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P1101:
        context.beginPath();
        context.moveTo(95, 96);
        context.lineTo(64, 96);
        context.lineTo(64, 92);
        context.lineTo(65, 89);
        context.lineTo(67, 86);
        context.lineTo(68, 83);
        context.lineTo(66, 80);
        context.lineTo(63, 77);
        context.lineTo(57, 76);
        context.lineTo(53, 76);
        context.lineTo(49, 78);
        context.lineTo(46, 81);
        context.lineTo(46, 85);
        context.lineTo(47, 88);
        context.lineTo(49, 90);
        context.lineTo(50, 92);
        context.lineTo(50, 96);
        context.lineTo(20, 96);
        context.lineTo(20, 66);
        context.lineTo(17, 65);
        context.lineTo(14, 65);
        context.lineTo(12, 67);
        context.lineTo(9, 69);
        context.lineTo(6, 69);
        context.lineTo(3, 67);
        context.lineTo(0, 63);
        context.lineTo(0, 58);
        context.lineTo(0, 53);
        context.lineTo(3, 50);
        context.lineTo(6, 48);
        context.lineTo(10, 48);
        context.lineTo(13, 52);
        context.lineTo(17, 52);
        context.lineTo(20, 51);
        context.lineTo(20, 21);
        context.lineTo(49, 21);
        context.lineTo(50, 18);
        context.lineTo(49, 15);
        context.lineTo(46, 11);
        context.lineTo(46, 7);
        context.lineTo(48, 3);
        context.lineTo(52, 1);
        context.lineTo(57, 0);
        context.lineTo(61, 1);
        context.lineTo(65, 3);
        context.lineTo(67, 6);
        context.lineTo(68, 10);
        context.lineTo(66, 13);
        context.lineTo(64, 17);
        context.lineTo(65, 21);
        context.lineTo(95, 21);
        context.lineTo(95, 51);
        context.lineTo(99, 52);
        context.lineTo(101, 51);
        context.lineTo(104, 49);
        context.lineTo(106, 48);
        context.lineTo(110, 49);
        context.lineTo(112, 51);
        context.lineTo(114, 53);
        context.lineTo(115, 56);
        context.lineTo(115, 60);
        context.lineTo(114, 63);
        context.lineTo(112, 67);
        context.lineTo(109, 69);
        context.lineTo(106, 69);
        context.lineTo(103, 67);
        context.lineTo(101, 66);
        context.lineTo(97, 65);
        context.lineTo(95, 67);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P1112:
        context.beginPath();
        context.moveTo(75, 94);
        context.lineTo(44, 94);
        context.lineTo(44, 97);
        context.lineTo(44, 100);
        context.lineTo(46, 102);
        context.lineTo(48, 105);
        context.lineTo(48, 109);
        context.lineTo(46, 112);
        context.lineTo(42, 114);
        context.lineTo(37, 115);
        context.lineTo(33, 114);
        context.lineTo(30, 112);
        context.lineTo(27, 109);
        context.lineTo(27, 105);
        context.lineTo(29, 102);
        context.lineTo(31, 100);
        context.lineTo(31, 97);
        context.lineTo(30, 94);
        context.lineTo(0, 94);
        context.lineTo(0, 19);
        context.lineTo(29, 19);
        context.lineTo(31, 16);
        context.lineTo(30, 13);
        context.lineTo(27, 10);
        context.lineTo(27, 6);
        context.lineTo(28, 2);
        context.lineTo(31, 0);
        context.lineTo(37, 0);
        context.lineTo(43, 0);
        context.lineTo(46, 1);
        context.lineTo(48, 4);
        context.lineTo(48, 8);
        context.lineTo(46, 11);
        context.lineTo(44, 15);
        context.lineTo(45, 19);
        context.lineTo(75, 19);
        context.lineTo(75, 49);
        context.lineTo(79, 50);
        context.lineTo(81, 49);
        context.lineTo(84, 47);
        context.lineTo(86, 46);
        context.lineTo(90, 47);
        context.lineTo(92, 49);
        context.lineTo(94, 51);
        context.lineTo(95, 54);
        context.lineTo(95, 58);
        context.lineTo(94, 61);
        context.lineTo(92, 65);
        context.lineTo(89, 67);
        context.lineTo(86, 67);
        context.lineTo(83, 65);
        context.lineTo(81, 64);
        context.lineTo(77, 63);
        context.lineTo(75, 65);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P1210:
        context.beginPath();
        context.moveTo(74, 94);
        context.lineTo(44, 94);
        context.lineTo(43, 97);
        context.lineTo(44, 100);
        context.lineTo(46, 103);
        context.lineTo(47, 106);
        context.lineTo(46, 109);
        context.lineTo(44, 112);
        context.lineTo(41, 114);
        context.lineTo(37, 115);
        context.lineTo(34, 114);
        context.lineTo(31, 113);
        context.lineTo(29, 111);
        context.lineTo(27, 109);
        context.lineTo(26, 106);
        context.lineTo(27, 103);
        context.lineTo(29, 101);
        context.lineTo(30, 98);
        context.lineTo(30, 94);
        context.lineTo(0, 94);
        context.lineTo(0, 64);
        context.lineTo(6, 64);
        context.lineTo(8, 67);
        context.lineTo(11, 67);
        context.lineTo(14, 66);
        context.lineTo(17, 64);
        context.lineTo(18, 61);
        context.lineTo(19, 58);
        context.lineTo(19, 55);
        context.lineTo(18, 51);
        context.lineTo(17, 49);
        context.lineTo(15, 47);
        context.lineTo(12, 46);
        context.lineTo(9, 46);
        context.lineTo(6, 49);
        context.lineTo(0, 49);
        context.lineTo(0, 19);
        context.lineTo(29, 19);
        context.lineTo(30, 16);
        context.lineTo(29, 13);
        context.lineTo(26, 9);
        context.lineTo(27, 4);
        context.lineTo(30, 0);
        context.lineTo(37, 0);
        context.lineTo(43, 0);
        context.lineTo(47, 4);
        context.lineTo(48, 8);
        context.lineTo(46, 11);
        context.lineTo(44, 15);
        context.lineTo(45, 19);
        context.lineTo(75, 19);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P2010:
        context.beginPath();
        context.moveTo(0, 45);
        context.lineTo(2, 44);
        context.lineTo(5, 45);
        context.lineTo(9, 47);
        context.lineTo(12, 47);
        context.lineTo(15, 46);
        context.lineTo(18, 43);
        context.lineTo(19, 39);
        context.lineTo(19, 35);
        context.lineTo(17, 31);
        context.lineTo(14, 28);
        context.lineTo(10, 27);
        context.lineTo(6, 30);
        context.lineTo(3, 31);
        context.lineTo(0, 31);
        context.lineTo(0, 0);
        context.lineTo(75, 0);
        context.lineTo(75, 29);
        context.lineTo(73, 30);
        context.lineTo(70, 30);
        context.lineTo(67, 28);
        context.lineTo(64, 26);
        context.lineTo(60, 27);
        context.lineTo(57, 30);
        context.lineTo(55, 34);
        context.lineTo(54, 38);
        context.lineTo(55, 41);
        context.lineTo(57, 45);
        context.lineTo(61, 47);
        context.lineTo(65, 47);
        context.lineTo(68, 45);
        context.lineTo(71, 43);
        context.lineTo(75, 44);
        context.lineTo(75, 75);
        context.lineTo(44, 75);
        context.lineTo(43, 79);
        context.lineTo(45, 82);
        context.lineTo(47, 85);
        context.lineTo(47, 89);
        context.lineTo(45, 92);
        context.lineTo(42, 95);
        context.lineTo(36, 95);
        context.lineTo(31, 95);
        context.lineTo(28, 92);
        context.lineTo(26, 87);
        context.lineTo(27, 83);
        context.lineTo(30, 80);
        context.lineTo(30, 77);
        context.lineTo(29, 75);
        context.lineTo(0, 75);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P2100:
        context.beginPath();
        context.moveTo(75, 0);
        context.lineTo(75, 29);
        context.lineTo(78, 31);
        context.lineTo(82, 29);
        context.lineTo(87, 26);
        context.lineTo(91, 27);
        context.lineTo(93, 31);
        context.lineTo(95, 35);
        context.lineTo(94, 40);
        context.lineTo(92, 45);
        context.lineTo(87, 48);
        context.lineTo(82, 45);
        context.lineTo(78, 43);
        context.lineTo(75, 46);
        context.lineTo(75, 74);
        context.lineTo(45, 75);
        context.lineTo(44, 71);
        context.lineTo(45, 69);
        context.lineTo(47, 66);
        context.lineTo(48, 63);
        context.lineTo(47, 59);
        context.lineTo(43, 56);
        context.lineTo(38, 55);
        context.lineTo(33, 55);
        context.lineTo(29, 57);
        context.lineTo(27, 60);
        context.lineTo(26, 64);
        context.lineTo(28, 66);
        context.lineTo(30, 68);
        context.lineTo(31, 71);
        context.lineTo(30, 75);
        context.lineTo(0, 75);
        context.lineTo(0, 44);
        context.lineTo(3, 43);
        context.lineTo(7, 47);
        context.lineTo(11, 48);
        context.lineTo(15, 48);
        context.lineTo(18, 44);
        context.lineTo(20, 38);
        context.lineTo(19, 32);
        context.lineTo(15, 27);
        context.lineTo(10, 26);
        context.lineTo(7, 29);
        context.lineTo(4, 30);
        context.lineTo(0, 30);
        context.lineTo(0, 0);
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P2102:
        context.beginPath();
        context.moveTo(44, 74);
        context.lineTo(44, 71);
        context.lineTo(45, 68);
        context.lineTo(48, 65);
        context.lineTo(48, 62);
        context.lineTo(47, 59);
        context.lineTo(43, 56);
        context.lineTo(39, 55);
        context.lineTo(35, 55);
        context.lineTo(31, 56);
        context.lineTo(28, 59);
        context.lineTo(27, 63);
        context.lineTo(28, 67);
        context.lineTo(31, 70);
        context.lineTo(31, 75);
        context.lineTo(0, 75);
        context.lineTo(0, 0);
        context.lineTo(75, 0);
        context.lineTo(75, 29);
        context.lineTo(78, 31);
        context.lineTo(82, 30);
        context.lineTo(84, 27);
        context.lineTo(88, 27);
        context.lineTo(92, 29);
        context.lineTo(95, 33);
        context.lineTo(95, 39);
        context.lineTo(93, 45);
        context.lineTo(90, 48);
        context.lineTo(86, 49);
        context.lineTo(82, 47);
        context.lineTo(79, 44);
        context.lineTo(75, 45);
        context.lineTo(75, 75);
        
        context.closePath();
        context.clip();
        break;
      case PiecePattern.P2211:
        context.beginPath();
        context.moveTo(95, 75);
        context.lineTo(64, 75);
        context.lineTo(64, 79);
        context.lineTo(66, 83);
        context.lineTo(67, 87);
        context.lineTo(66, 91);
        context.lineTo(62, 94);
        context.lineTo(58, 95);
        context.lineTo(54, 95);
        context.lineTo(50, 94);
        context.lineTo(47, 91);
        context.lineTo(46, 87);
        context.lineTo(47, 83);
        context.lineTo(50, 80);
        context.lineTo(49, 77);
        context.lineTo(48, 75);
        context.lineTo(19, 75);
        context.lineTo(19, 45);
        context.lineTo(15, 44);
        context.lineTo(12, 44);
        context.lineTo(9, 47);
        context.lineTo(6, 47);
        context.lineTo(3, 46);
        context.lineTo(0, 43);
        context.lineTo(0, 37);
        context.lineTo(0, 31);
        context.lineTo(3, 28);
        context.lineTo(7, 26);
        context.lineTo(11, 28);
        context.lineTo(14, 30);
        context.lineTo(17, 30);
        context.lineTo(19, 28);
        context.lineTo(19, 0);
        context.lineTo(94, 0);
        context.closePath();
        context.clip();
        break;
    }
  };

  /**
   * 指定された画像を分割
   * @param {*} image 分割する画像
   * @param {*} row 縦の分割数
   * @param {*} column 横の分割数
   * @returns Promise オブジェクト
   */
  JigsawPuzzle.Core.createPieces = function(image) {
    const PIECE_SIZE_ONE = IMAGE_SPLIT_SIZE + PIECE_JOINT_SIZE;
    let row = Math.ceil(image.width / IMAGE_SPLIT_SIZE) + 1;
    let column = Math.ceil(image.height / IMAGE_SPLIT_SIZE);

    let width = PIECE_SIZE;
    let height = PIECE_SIZE;

    let xOffset = (image.width % PIECE_SIZE) / 2;
    let yOffset = (image.height % PIECE_SIZE) / 2;
    console.log("yOffset" + yOffset);
    console.log("image.width:" + image.width, "image.height:" + image.height);

    let canvas = document.createElement('canvas');
    canvas.setAttribute('width', width);
    canvas.setAttribute('height', height);
    canvas.setAttribute('hidden', true);
    document.body.appendChild(canvas);
    let context = canvas.getContext('2d');

    // Canvas -> DataURL に変換
    let dataURLList = []

    let patterns = []

    patterns.push(PiecePattern.P2102);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2100);
    patterns.push(PiecePattern.P2010);
    patterns.push(PiecePattern.P2211);
    
    patterns.push(PiecePattern.P1112);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P0011);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P0201);

    patterns.push(PiecePattern.P0102);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P0101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P0101);
    patterns.push(PiecePattern.P1210);

    patterns.push(PiecePattern.P1112);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P0210);

    patterns.push(PiecePattern.P0102);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P1000);
    patterns.push(PiecePattern.P1101);
    patterns.push(PiecePattern.P0210);

    patterns.push(PiecePattern.P1022);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P1021);
    patterns.push(PiecePattern.P0221);

    console.log("row:" + row, "column:" + column);
    for(let y = 0; y < column; ++y) {
      for(let x = 0; x < row; ++x) {
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.save();
        let index = x + (row * y);
        clipPiece(context, {
          pattern: patterns[index],
          width: width,
          height: height,
        });
        let startX = x * IMAGE_SPLIT_SIZE - xOffset, startY = y * IMAGE_SPLIT_SIZE - yOffset;
        context.drawImage(image, startX, startY, width, height, 0, 0, width, height);
        context.restore();
        dataURLList.push(canvas.toDataURL());
      }
    }

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
          pieceList[i] = new PuzzlePiece(patterns[i], pieceImage);
        }
        return pieceList;
      }
    );
  };
}
