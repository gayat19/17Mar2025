import { useEffect, useState } from "react";
import { getDepartments } from "../../Services/DepartmentService";
import { addEmployeeAPICall } from "../../Services/EmployeeService";

const CreateEmployee =()=>{

const [departments,setDepartmnets] = useState([]);
const [employee,setEmployee] = useState({});

useEffect(()=>{

    getDepartments().then((response)=>{
        if(response.status===200){
            
            setDepartmnets(response.data.departments);
        }
    }).catch((error)=>{
        console.log(error);
    });

},[]);

const populateEmployee = (event)=>{
switch (event.target.name) {
    case "name":
        setEmployee({...employee, name:event.target.value});
        break;
    case "phone":
        setEmployee({...employee, phone:event.target.value});
        break;
    case "password":
        setEmployee({...employee, password:event.target.value});
        break;
    case "departmentId":
        setEmployee({...employee, departmentId:event.target.value});
        break;
    default:
        break;
}
}
const addEmployee=()=>{
    event.preventDefault();
   addEmployeeAPICall(employee).then((response)=>{
        if(response.status===201){
            alert("Employee Created Successfully")
        }else{
            alert("Error in creating employee")
        }
    }).catch((error)=>{
        console.log(error);
    })
    
}

return(
    <div>
        <form>
            <h1>Create Employee</h1>
            <label className="form-control">Name</label>
            <input className="form-control" name="name" value={employee.name} onChange={populateEmployee} type="text" placeholder="Name" />
            <label className="form-control">Phone</label>
            <input className="form-control" name="phone" value={employee.phone} onChange={populateEmployee} type="text" placeholder="Phone" />
            <label className="form-control">Password</label>
            <input className="form-control" name= "password" value={employee.password} onChange={populateEmployee} type="password" placeholder="Password" />
            <label className="form-control">Departmnet</label>
            <div>
                {
                departments.length==0?<h1>No departments found</h1>:
                <select  className="form-control" onChange={populateEmployee} name="departmentId" >
                {
                departments.map((departmnet)=>{
                    return(
                        <option key={departmnet.id} value={departmnet.id}>{departmnet.name}</option>
                    )
                })}
            </select>
                }
            </div>
            <button type="submit" onClick={addEmployee} className="btn btn-primary">Create Employee</button>
        </form>
           
    </div>
)
}

export default CreateEmployee;