import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Image from 'react-bootstrap/Image'

const LEDMatrixDisplay = (props) => {
  console.log(props);

  return (
    <>
      {(props.matrix.length > 0) ?
        props.matrix.map((row, idx) => {
          console.log('row:', row);
          return <Row
            key={`row-${idx}`}
            className="p-1"
          >
            {row.map((col, idx) => {
              return <Col className="p-1">
                <Image
                  //style={{ width: '2rem' }}
                  key={col.keyId}
                  src={col.src}
                  onClick={() => props.handleClick(col)}
                  fluid />
              </Col>
            })}

          </Row>
        })





        : <h2>NoData</h2>
      }
    </>
  )
}
export default LEDMatrixDisplay