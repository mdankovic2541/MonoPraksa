import axios from "axios";
import React, { useEffect, useState } from 'react';
import { Table, Button, CardHeader, Container } from 'reactstrap';



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
            
          <div key={modelVersions.Id} className=".bg-info">
             
            <p>Model Version Acceleration:{modelVersions.Acceleration}</p>
            <p>Model Version Name:{modelVersions.Name}</p>
            <p>Model Version Doors:{modelVersions.Doors}</p>
            <p>Model Version Fuel Consumption:{modelVersions.FuelConsumption}</p>
            <p>Model Name:{modelVersions.Model.Name}</p>
            <p>Motor Type:{modelVersions.Type}</p>
            <p>Motor MaxHP:{modelVersions.MaxHP}</p>
            <p>Motor Engine Size:{modelVersions.EngineSize}</p>
            <p>Motor Name:{modelVersions.Name}</p>
            <p>Review Comment:{modelVersions.Comment}</p>
            <p>Review Rating:{modelVersions.Rating}</p>
            <p>Body Shape Name:{modelVersions.Name}</p>
            <p>Transmission Gears:{modelVersions.Gears}</p>
            <p>Transmission Year:{modelVersions.Year}</p>            
            <p>
                <Button color="success" size="sm" onClick={() => onEdit(modelVersions.Id)}>Edit</Button>
                <Button color="danger" size="sm" onClick={() => onDelete(modelVersions.Id)}>Delete</Button>
            </p>            
          </div>
        )
        
}