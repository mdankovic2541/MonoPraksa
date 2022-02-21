import axios from "axios";
import React, { useEffect, useState } from 'react';
import { Table, Button, CardHeader, Container } from 'reactstrap';
import BodyShape from "./BodyShape";
import Transmission from "./Transmission";
import Motor from "./Motor";



export default function SingleModelVersion(params){
    const [modelVersions, setModelVersion] = useState({});
   
    useEffect(() => {
        axios.get('https://localhost:44343/api/modelVersion/' + params.Id)
            .then((response) => {
                console.log(response.data)
                console.log("before");  
                console.log(modelVersions);
                setModelVersion(response.data); 
                console.log("after"); 
                console.log(modelVersions);            
            })
    }, []);

    const getData = () => {
        axios.get('https://localhost:44343/api/modelVersion/' + params.Id)
            .then((getData) => {
                setModelVersion(getData.data)
            })
    }
    const onEdit = (id) => {
        axios.put('https://localhost:44343/api/modelVersion/' + params.Id)
        .then(() => {
            getData()
        })
    }


    const onDelete = (id) => {
        axios.delete('https://localhost:44343/api/modelVersion/' + params.Id)
        .then(() => {
            getData()
        })
    }
   
        return (
            modelVersions == null ? <p>Loading...</p>:
          <div key={modelVersions.Id} className=".bg-info">
             <BodyShape BodyShape={modelVersions.BodyShape}/>
             <Transmission Transmission={modelVersions.Transmission}/>
             <Motor Motor={modelVersions.Motor}/>
          </div>
        )
        
}