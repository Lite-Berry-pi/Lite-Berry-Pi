import React, { useState } from 'react'
import { ListGroupItem } from 'react-bootstrap'
import Card from 'react-bootstrap/Card'
import ListGroup from 'react-bootstrap/ListGroup'

const DesignsList = (props) => {
  return (
    <Card className="m-2" style={{ width: '25rem' }} >
      <Card.Header className="bg-light">
        <Card.Title className="text-center">Designs</Card.Title>
      </Card.Header>
      <Card.Body>
        <Card.Title>Custom Designs</Card.Title>
        <ListGroup>
          <ListGroup.Item>Design1</ListGroup.Item>
          <ListGroup.Item>Design2</ListGroup.Item>
          <ListGroup.Item>Design3</ListGroup.Item>
        </ListGroup>
        <Card.Title>Standard Designs</Card.Title>
        <ListGroup>
          <ListGroup.Item>Square</ListGroup.Item>
          <ListGroup.Item>CheckerBoard-1</ListGroup.Item>
          <ListGroup.Item>CheckerBoard-2</ListGroup.Item>
        </ListGroup>

      </Card.Body>
    </Card>
  )
}
export default DesignsList