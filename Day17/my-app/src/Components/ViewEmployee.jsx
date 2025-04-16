import { useState } from "react";
import { EmployeeModel } from "../Models/EmployeeModel";

export default function ViewEmployee() {

    const [employee,setEmployee] = useState({
        name: "John Doe",
        age: 30,
        salary: 50000
    });

    const changeNme =() => { setEmployee({...employee,name:"Jane Doe"})}
    return (
        <div>
            <h1>Employee Details</h1>
            <p>Name: {employee.name} 
                <button onClick={changeNme}>Change Name</button>
            </p>
            <p>Age: {employee.age}  <button onClick={()=>{setEmployee({...employee,age:25})}}>Change Age</button></p>
            <p>Salary: {employee.salary}<button onClick={()=>{setEmployee({...employee,salary:2500000})}}>Change Salary</button></p>
        </div>
    );
}