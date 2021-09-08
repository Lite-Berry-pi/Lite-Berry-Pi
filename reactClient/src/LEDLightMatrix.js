import React, { useEffect, useState } from 'react';
import LED from './components/LEDs/LEDHelpers.js'
import Card from "react-bootstrap/Card";
import LEDMatrixDisplay from './components/LEDs/LedMatrixDisplay.js'
import Container from "react-bootstrap/Container";
import Image from "react-bootstrap/Image";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col"


const LEDLightMatrix = () => {

  // ['green', 'green', 'green', 'green', 'green'],
  // ['green', 'green', 'green', 'green', 'green'],
  // ['green', 'green', 'green', 'green', 'green'],
  // ['green', 'green', 'green', 'grey', 'green'],
  const [LEDMatrix, setLEDMatrix] = useState(LED.createMatrix());



  const handleClick = (e) => {
    (e.color == 'green') ? e.UpdateColor('grey') : e.UpdateColor('green');
    console.log(e);
    setLEDMatrix([...LEDMatrix]);

  }
  console.log('state: ', LEDMatrix)

  return (
    <>
      <Card style={{ width: '15rem' }}>
        <Card.Header>
          <Card.Title className="text-center">LiteBerry Pi Viewer</Card.Title>
        </Card.Header>
        <Card.Body>
          {(LEDMatrix.length > 0) ? <LEDMatrixDisplay matrix={LEDMatrix}
            handleClick={handleClick}
          />
            : <h2>No Matrix</h2>}
        </Card.Body>
      </Card>
    </>
  );
};

export default LEDLightMatrix