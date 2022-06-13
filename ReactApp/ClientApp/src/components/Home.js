import React, { useEffect, useState } from 'react';
import axios from 'axios';
import {Table} from 'react-bootstrap';
import SolutionAdd from './SolutionAdd';
import LoadingSpinner from './LoadingSpinner';

export function Home() {
    const [solutionList, setSolutionList] = useState([]);
    const [errorMessage, setErrorMessage] = useState("");
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        refreshList();
    });

    const refreshList = () => {
        axios.get(process.env.REACT_APP_API +`/api/CodeSolutions/`, ) 
        .then(res => {
          setSolutionList(res.data);
          setIsLoading(false);
        })
        .catch( error => {
          setErrorMessage(error.message);
          setIsLoading(false);
        });
    };

    const renderSolutions = (
      <div>
        <SolutionAdd/>
        <Table className='mt-4' striped bordered hover size='sm'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>SolutionCode</th>
            <th>Result</th>
          </tr>
        </thead>
        <tbody>
          {solutionList.map(sol =>
            <tr key={sol.id}>
              <td>{sol.id}</td>
              <td>{sol.name}</td>
              <td>{sol.solutionCode}</td>
              <td>{sol.result}</td>
            </tr>
        )}
        </tbody>
        </Table>
      </div>
    );

    return (
        <div>         
          {isLoading ? <LoadingSpinner/> : errorMessage ? <div className='error'> {errorMessage} </div> : renderSolutions}
        </div>
      );
}
