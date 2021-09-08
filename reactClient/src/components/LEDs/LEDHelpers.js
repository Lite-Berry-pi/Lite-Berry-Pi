import React, { useEffect, useState } from 'react';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Image from 'react-bootstrap/Image'
class LEDObj {
  constructor(lightNum, inRow, inColumn) {
    this.keyId = `${lightNum}-${inRow}-${inColumn}`
    this.row = inRow,
      this.column = inColumn,
      this.num = lightNum,
      this.color = 'grey',
      this.src = `./assets/${this.color}LED.png`
  }
}
LEDObj.prototype.UpdateColor = function (colour) {
  this.color = colour;
  this.src = `./assets/${colour}LED.png`
}
const createMatrix = () => {
  const LEDMatrixArr = [];
  let counter = 0
  for (let i = 0; i < 5; i++) {
    LEDMatrixArr.push([]);
    for (let j = 0; j < 5; j++) {
      LEDMatrixArr[i].push(new LEDObj(counter++, i, j));
    }
  }
  return LEDMatrixArr;
}
const updateMatrix = (arr, led, color) => {
  console.log('updateMatrix:', arr, led, color);
  arr[led.row][led.column].color = color
  return arr;
}
export default { LEDObj, createMatrix, updateMatrix, }

