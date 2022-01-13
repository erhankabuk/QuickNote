import axios from "axios";
import { useContext, useState } from "react";
import { Button, Card, Form } from "react-bootstrap";
import AppContext from "./AppContext";
import logo from './logo.png';
const API_URL = process.env.REACT_APP_API_URL;

function Enterance() {
    const [name, setName] = useState("");
    const ctx = useContext(AppContext);
    
    const handleSubmit = function(event) {
        event.preventDefault();
        // todo: get notebook through api
        axios.post(API_URL + "NoteBooks", { name })
            .then(function(response) {
                ctx.setNoteBook(response.data);
            });
    };

    return (
        <div className="h-100 d-flex align-items-center justify-content-center">
            <Card>
                <Card.Body className="p-5">
                    <form onSubmit={handleSubmit}>
                        <img src={logo} alt="logo" />
                        <Form.Control className="mt-4" value={name} onChange={e => setName(e.target.value)} 
                            type="text" placeholder="Name of the NoteBook" required maxLength={50} />
                        <div className="text-center">
                            <Button type="submit" className="mt-2 d-block w-100">Open</Button>
                        </div>
                        
                    </form>
                </Card.Body>
            </Card>
        </div>
    );
}

export default Enterance
