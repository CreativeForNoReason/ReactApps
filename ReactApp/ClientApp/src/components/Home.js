import React, { Component } from 'react';
import axios from 'axios';
import {Table} from 'react-bootstrap';
import SolutionAdd from './SolutionAdd';
import LoadingSpinner from './LoadingSpinner';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props){
    super(props);
    this.state = {solutionList: [],
                  isLoading: true};
    this._isMounted = false;
  }

  refreshList(){
    axios.get(process.env.REACT_APP_API +`/api/CodeSolutions/`, ) 
    .then(res => {
      const solutionList = res.data;
      this._isMounted && this.setState({ solutionList, isLoading: false });
    });
  }

  componentDidMount() {
    this._isMounted = true;
    this._isMounted && this.refreshList()
  }

  componentDidUpdate() {
    this.refreshList()
  }

  componentWillUnmount() {
    this._isMounted = false;
 }

  render () {
    const {solutionList}=this.state;
    return (
      <div>
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
        {this.state.isLoading ? <LoadingSpinner/> : <SolutionAdd/>}
      </div>
    );
  }  
}
