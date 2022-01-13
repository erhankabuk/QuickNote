import axios from "axios";
import { useContext, useEffect, useState } from "react";
import { Navbar, Container, Nav,  Row, Col } from "react-bootstrap";
import AppContext from "./AppContext";
const API_URL = process.env.REACT_APP_API_URL;

function NoteBook() {
    const [notes, setNotes] = useState([]);
    const ctx = useContext(AppContext);

    useEffect(() => {
        axios.get(API_URL + "Notes?noteBookId=" + ctx.noteBook.id)
            .then(function (response) {
                setNotes(response.data);
            });
    }, [])

    const handleClose = function (event) {
        event.preventDefault();
        ctx.setNoteBook(null);
    }



    return (
        <div>
            <Navbar bg="light" expand="lg">
                <Container fluid>
                    <Navbar.Brand >QuickNote</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="ms-auto">
                            <Nav.Link onClick={handleClose}>Close the Notebook</Nav.Link>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>

            <Row>
                <Col className="bg-primary" sm={4} md={3} >1</Col>
                <Col className="bg-success" sm={8} md={9} >2</Col>
             
            </Row>
            <h1>Notes of '{ctx.noteBook.name}'</h1>

            <ul>
                {notes.map(x => <li key={x.id}>{x.title}</li>)}
            </ul>
        </div>
    )
}

export default NoteBook
