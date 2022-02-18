import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Table, Button, CardHeader, Container } from 'reactstrap';


export default function Motor(params) {
    const [motors, setMotor] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:44343/api/motor/' )
            .then((response) => {
                console.log(response.data)
                setMotor(response.data);
            })
    }, []);

    const getData = () => {
        axios.get('https://localhost:44343/api/motor')
            .then((getData) => {
                setMotor(getData.data);
            })
    }
    const onEdit = (id) => {
        axios.put('https://localhost:44343/api/motor/' + id)
        .then(() => {
            getData();
        })
    }


    const onDelete = (id) => {
        axios.delete('https://localhost:44343/api/motor/' + id)
        .then(() => {
            getData();
        })
    }
    let motorList = motors.map((motor) => {
        return (
          <tr key={motor.Id}>
            <td>{motor.Id}</td>
            <td>{motor.Name}</td>
            <td>
                <Button color="success" size="sm" onClick={() => onEdit(motor.Id)}>Edit</Button>
                <Button color="danger" size="sm" onClick={() => onDelete(motor.Id)}>Delete</Button>
            </td>            
          </tr>
        )
      });
    return (
        <Container>
            <h1>Motor table</h1>
            <Button className="my-3" color="primary">Add motor</Button>
            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {motorList}
                </tbody>
            </Table>
        </Container>
    )
}