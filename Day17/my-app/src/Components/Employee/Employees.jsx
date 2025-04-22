import { useState } from "react"

export default function Employees(props){
const [employees,setEmployees] = useState(props.employees);

const like = (id)=>{
   props.onLikedEmployee(id);//raised the event
}

    return(
        <div className="container">
                    <div className="row">
                        <div className="col-md-12">
                            <h2>Employee List</h2>
                            <table className="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Employee ID</th>
                                        <th>Employee Name</th>
                                        <th>Employee Phone</th>
                                        <th>Employee Age</th>
                                        <th>Department</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        employees.map((employee)=>{
                                            return(
                                                <tr key={employee.id}>
                                                    <td>{employee.id}</td>
                                                    <td>{employee.name}</td>
                                                    <td>{employee.phone}</td>
                                                    <td>{employee.age}</td>
                                                    <td>{employee.departmentId}</td>
                                                    <td><button onClick={()=>like(employee.id)}>Like</button></td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>  
    )
}