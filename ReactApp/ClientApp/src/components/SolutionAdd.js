import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { Form, Row, Col, Button } from 'react-bootstrap';


export default class SolutionAdd extends React.Component {

    constructor(props){
        super(props);
        this.state = {btnText: 'Add'};
    }

    handleChangeName = event => {
        this.setState({ 
            name: event.target.value
        });
    }

    handleChangeSolutionCode = event => {
        this.setState({ 
            solutionCode: event.target.value
        });
    }

    handleSubmit = event => {
        event.preventDefault();
        const user = {
            name: this.state.name,
            solutionCode: this.state.solutionCode,
            result: ''
        };

        axios.post(process.env.REACT_APP_API + `/api/CodeSolutions/`,  
        {name: user.name,
        solutionCode: user.solutionCode,
        result: user.result})
            .then(res => {
            console.log(res);
            console.log(res.data);
            this.changeText("Add");
            })
            .catch(error => {
                console.log(error);
                this.changeText("Error");
        });
    }

    changeText = (text) => {
        this.setState({ btnText: text }); 
    } 

    render() {
        return (
                <div>
                    <Row>
                        <Col sm={6}>
                            <Form onSubmit={this.handleSubmit}>
                                <Form.Group controlId = "Name">
                                    <Form.Label>Name</Form.Label>
                                    <Form.Control type="text" name="name" onChange={this.handleChangeName} required />
                                </Form.Group>
                                <Form.Group controlId = "solutionCode">
                                    <Form.Label>Solution Code</Form.Label>
                                    <textarea className='form-control' type="textarea" name="solutionCode" onChange={this.handleChangeSolutionCode} required />
                                </Form.Group>
                                <Form.Group controlId="submitBtn">
                                <Button id='submitBtn' variant="primary" type="submit"
                                    onClick={ () => { this.changeText("Loading")}  } >{this.state.btnText}</Button>
                                </Form.Group>
                            </Form>
                        </Col>
                    </Row>
                </div>
            )
    }
}
