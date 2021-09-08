import React, { useState } from 'react'
import { ListGroupItem } from 'react-bootstrap'
import Card from 'react-bootstrap/Card'
import ListGroup from 'react-bootstrap/ListGroup'

const DeviceStatus = (props) => {
  return (
    <Card className="m-2" style={{ width: '25rem' }} >
      <Card.Header className="bg-light">
        <Card.Title className="text-center">System Status</Card.Title>
      </Card.Header>
      <Card.Body>
        <Card.Title>Client User Information</Card.Title>

        <ListGroup>
          <ListGroup.Item>User Name: <strong>4a50</strong></ListGroup.Item>
          <ListGroupItem>User Email: <strong>jp@4a50.net</strong></ListGroupItem>
        </ListGroup>
        <Card.Title>Device</Card.Title>
        <ListGroup>
          <ListGroup.Item>LiteBerryPi Connected: <strong className="text-danger">Disconnected</strong></ListGroup.Item>
          <ListGroup.Item>LiteBerryPi ID: <strong>213hjg3g212gsmnb2</strong></ListGroup.Item>
          <ListGroup.Item>Client Version Number: <strong>1.3.223</strong></ListGroup.Item>
          <ListGroup.Item>Socket Server Version Number: <strong>1.0.0</strong></ListGroup.Item>
        </ListGroup>
      </Card.Body>
    </Card>
  )
}
export default DeviceStatus