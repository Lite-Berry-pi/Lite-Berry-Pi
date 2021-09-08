import React, { useEffect, useState } from 'react';
import LED from './components/LEDs/LEDHelpers.js'
import Card from "react-bootstrap/Card";
import LEDMatrixDisplay from './components/LEDs/LedMatrixDisplay.js'
import Button from 'react-bootstrap/Button'
import Container from 'react-bootstrap/Container'
const LEDLightMatrix = () => {
  const [LEDMatrix, setLEDMatrix] = useState(LED.createMatrix());

  const handleClick = (e) => {
    (e.color == 'green') ? e.UpdateColor('grey') : e.UpdateColor('green');
    console.log(e);
    setLEDMatrix([...LEDMatrix]);

  }
  console.log('state: ', LEDMatrix)
  return (
    <>
      <Card className="bg-success" style={{ width: '25rem' }} >
        <Card.Header className="bg-grey">
          <Card.Title className="text-center">LiteBerry Pi Viewer</Card.Title>
        </Card.Header>
        <Card.Body >
          {(LEDMatrix.length > 0) ? <LEDMatrixDisplay matrix={LEDMatrix}
            handleClick={handleClick} /> : <h2>No Matrix</h2>}
          <Container className="center">
            <Button className="m-2">Reset</Button>
            <Button className="m-2">Convert To Send</Button>
          </Container>

        </Card.Body>
      </Card>
    </>
  );
};

export default LEDLightMatrix