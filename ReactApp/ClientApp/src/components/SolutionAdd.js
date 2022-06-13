import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { Form, Row, Col, Button } from 'react-bootstrap';
import CodeEditorWindow from "./CodeEditorWindow"

const csharpscriptDefault = "// you can write your csharp code there";

export default function SolutionAdd () {
    const [name, setName] = useState("");
    const [solutionCode, setSolutionCode] = useState(csharpscriptDefault);
    const [btnText, changeText] = useState("Add");
    const [theme, setTheme] = useState("cobalt");

    useEffect(() => {
        if (!name) {
            changeText("Add");
        }
    }); 

    const handleChangeName = event => {
        setName(event.target.value);
    };

    const handleChangeSolutionCode = (code) => {
        setSolutionCode(code);
    };

    const handleSubmit = event => {
        event.preventDefault();
        axios.post(process.env.REACT_APP_API + `/api/CodeSolutions/`,  
        {name: name,
        solutionCode: solutionCode,
        result: ''})
            .then(res => {
            console.log(res);
            console.log(res.data);
            changeText("Add");
            })
            .catch(error => {
                console.log(error);
                changeText("Error");
        });
    };

    return (
        <div>
            <Row>
                <Col sm={6}>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group controlId = "Name">
                            <Form.Label>Name</Form.Label>
                            <Form.Control type="text" name="name" onChange={handleChangeName} required />
                        </Form.Group>
                        <Form.Group controlId = "solutionCode">
                            <Form.Label>Solution Code</Form.Label>
                            <CodeEditorWindow 
                            code={solutionCode}
                            onChange={handleChangeSolutionCode}
                            theme={theme} required />
                        </Form.Group>
                        <Form.Group controlId="submitBtn">
                        <Button id='submitBtn' variant="primary" type="submit"
                            onClick={ () => {changeText("Loading")}  } >{btnText}</Button>
                        </Form.Group>
                    </Form>
                </Col>
            </Row>
        </div>
    );
}