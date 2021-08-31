import React from 'react';
import Card from 'react-bootstrap/Card'

const DesignItem = (props) => {
    console.log(props);
    return (
        <Card>
            <Card.Body>
                <Card.Title>{props.design.title}</Card.Title>
                <Card.Text>{props.design.designCoords}</Card.Text>
            </Card.Body>
        </Card>
        )
}
export default DesignItem;