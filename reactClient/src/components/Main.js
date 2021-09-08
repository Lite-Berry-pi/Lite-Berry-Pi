import React, { useState } from 'react';
import LEDLightMatrix from '../LEDLightMatrix.js';
import Header from './Header.js';
import DeviceStatus from '../components/DeviceStatus.js'
import DesignsList from './DesignsList.js';
import Container from 'react-bootstrap/Container'


const Main = () => {
  const [lightString, setLightString] = useState('');

  return (
    <>
      <Header />
      <Container className="d-flex">
        <LEDLightMatrix />
        <DeviceStatus lightString={lightString} />
        <DesignsList />

      </Container>

    </>
  )

}
export default Main