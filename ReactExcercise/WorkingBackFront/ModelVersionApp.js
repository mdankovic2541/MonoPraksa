import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import SingleModelVersion from './SingleModelVersion';


import ModelVersion from './ModelVersion'
import { Container } from 'reactstrap';


function ModelVersionApp() {
 
  return (
    <Container className="App container">
      
      <SingleModelVersion Id="679DA10D-530D-4FE8-B28B-5FDB95415BCB"/>
      
    </Container>
  );
}

export default ModelVersionApp;
