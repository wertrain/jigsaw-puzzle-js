{
  'use strict';

  JigsawPuzzle.Core = {};

  let PiecePattern = {
    P0011: 0, P0012: 1, P0100: 2, P0101: 3,
    P0102: 4, P0201: 5, P0210: 6, P0221: 7,
    P1000: 8, P1010: 9, P1021:10, P1022:11,
    P1101:12, P1112:13, P1210:14, P2010:15,
    P2100:16, P2102:17, P2211:18
  };

  let createPieces = function(context, param) {
    switch (param.pattern) {
      case PiecePattern.P0011:
        context.beginPath();
        context.moveTo(75, 50);
        context.lineTo(100, 75);
        context.lineTo(100, 25);
        context.clip();
        return;
    }
  };

  /**
   * 指定された画像を分割
   * @param {*} image 分割する画像
   * @param {*} row 縦の分割数
   * @param {*} column 横の分割数
   * @returns Promise オブジェクト
   */
  JigsawPuzzle.Core.createPieces = function(image, row, column) {
    let width = image.width / row;
    let jointWidth = width / 6;
    let height = image.height / column;
    let jointHeight = height / 6;
    let canvas = document.createElement('canvas');
    canvas.setAttribute('width', width + (jointWidth * 2));
    canvas.setAttribute('height', height + (jointHeight * 2));
    canvas.setAttribute('hidden', true);
    document.body.appendChild(canvas);
    let context = canvas.getContext('2d');

    // Canvas -> DataURL に変換
    let dataURLList = []
    for(let num = 0; num < row * column; num++) {
      context.clearRect(0,0, canvas.width, canvas.height);
      createPieces(context, {
        pattern: PiecePattern.P0011,
        width: width,
        jointWidth: jointWidth,
        height: height,
        jointHeight: jointHeight,
      });
      context.drawImage(image, width * (num % row), height * Math.floor(num / row), width, height, 0, 0, width, height);

      dataURLList.push(canvas.toDataURL());
    }

    // DataURL から Image にロード
    return new Promise(
      (resolve, _) => {
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
