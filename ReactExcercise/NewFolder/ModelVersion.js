import axios from "axios";
import React, { useEffect, useState } from 'react';
import { Table, Button, CardHeader, Container } from 'reactstrap';



export default function ModelVersion(params){
    const [modelVersions, setModelVersion] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:44343/api/modelVersion')
            .then((response) => {
                console.log(response.data)
                setModelVersion(response.data);
            })
    }, []);

    const getData = () => {
        axios.get('https://localhost:44343/api/modelVersion')
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
    let modelVersionList = modelVersions.map((modelVersion) => {
        return (
          <tr key={modelVersion.Id}>
            <td>{modelVersion.Id}</td>
            <td>{modelVersion.Model.Name}</td>
            <td><img src={modelVersion.Model.ImageURL} alt="" /></td>
            <td>{modelVersion.Model.Manufacturer.Name}</td>
            <td><img src={modelVersion.Model.Manufacturer.ImageURL} alt="" /></td>
            
            <td>
                <Button color="success" size="sm" onClick={() => onEdit(modelVersion.Id)}>Edit</Button>
                <Button color="danger" size="sm" onClick={() => onDelete(modelVersion.Id)}>Delete</Button>
            </td>            
          </tr>
        )
        });
    return (
        <Container>
            <h1>Model Version table</h1>
            <Button className="my-3" color="primary">Add new model version</Button>
            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Image</th>
                        <th>Name</th>
                        <th>Image</th>
                    </tr>
                </thead>
                <tbody>
                    {modelVersionList}
                </tbody>
            </Table>
        </Container>
    )
}