import React, { useState } from 'react';
import LEDLightMatrix from '../LEDLightMatrix.js';
import LED from '../components/LEDs/LEDHelpers'
import Header from './Header.js';
import DeviceStatus from '../components/DeviceStatus.js'
import DesignsList from './DesignsList.js';
import Container from 'react-bootstrap/Container'


const Main = () => {
  const [lightString, setLightString] = useState('');
  const lightConv = (mtrx) => {
    let stringConv = LED.convertToLightString(mtrx);
    console.log(stringConv);
    setLightString(stringConv);


  }
  return (
    <>
      <Header />
      <Container className="d-flex">
        <LEDLightMatrix lightConv={lightConv} />
        <DeviceStatus lightString={lightString} />
        <DesignsList />
      </Container>
      <h1>Last Conversion Performed:</h1>
      {(lightString) ? <h2>{lightString}</h2> : <h2>No string</h2>}

    </>
  )

}
export default Main