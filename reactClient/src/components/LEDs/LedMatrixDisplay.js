import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Image from 'react-bootstrap/Image'

const LEDMatrixDisplay = (props) => {
  console.log(props);

  return (
    <>
      {(props.matrix.length > 0) ?
        props.matrix.map((row, idx) => {
          return <Row
            key={`row-${idx}`}
            className="p-0 m-0 bg-dark"
          >
            {row.map((col, idx) => {
              return <Col
                key={`col-${col.keyId}`}
                className="p-0 m-0 d-flex bg-dark"
              >
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