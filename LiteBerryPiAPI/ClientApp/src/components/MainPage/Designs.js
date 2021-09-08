import React, { useEffect, useState } from 'react';
import DesignItem from '../MainPage/DesignItem';
import Container from 'react-bootstrap/Container';

const Designs = (props) => {
    const [designs, setDesigns] = useState([]);
    useEffect(() => {
        console.log('fetching');
        fetchDesigns();
    }, []);

    const fetchDesigns = () => {
        console.log('Fetching All Designs');
        fetch('api/Designs')
            .then(data => {
                let a = data.json();
                console.log('a', a);
                return a;
            })
            .then(data => setDesigns(data));
    }
    console.log('allDesigns:', designs);
    return (
        <Container>
            {(designs.length > 0 && designs) ? designs.map(d =>
                <DesignItem key={d.id} design={d}/>) : ''}
        </Container>
        );
}


export default Designs;