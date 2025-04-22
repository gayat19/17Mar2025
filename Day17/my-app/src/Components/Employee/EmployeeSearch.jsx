import { useEffect, useState } from "react";
import { getEmployeeAPICall, getSearchData } from "../../Services/EmployeeService";
import Employees from "./Employees";

export default function EmployeeSearch() {

    //const [searchData, setSearchData] = useState({});
    const [departments,setDepartmnets] = useState([]);
    const [employees,setEmployees] = useState([]);
    const [employeeSearchData, setEmployeeSearchData] = useState({ });
    const[departmnetIds,setDepartmnetIds] = useState([]);
    const [filters,setFilters] = useState({});
    const[ageRange,setAgeRange] = useState({});
    const [liked,setLiked] = useState([])

    useEffect(() => {
        getSearchData().then((response)=>{
            if(response.status == 200)
            {
                //setSearchData(response.data);
                setDepartmnets(response.data.departments);
            }
                
        })
    }, []); 
    const populateSearch = (event) => {
        switch (event.target.name) {
            case "employeeName":
                setFilters({...filters, name:event.target.value});
                setEmployeeSearchData({...employeeSearchData, filters:filters});
                break;
            case "employeePhone":
                setFilters({...filters, phone:event.target.value});
                setEmployeeSearchData({...employeeSearchData, filters:filters});
                break;
            case "employeeMinAge":
                setAgeRange({...ageRange, minAge:event.target.value});
                setFilters({...filters, age:ageRange});
                setEmployeeSearchData({...employeeSearchData, filters:filters});
                break;
            case "employeeMaxAge":
                setAgeRange({...ageRange, maxAge:event.target.value});
                setFilters({...filters, age:ageRange});
                setEmployeeSearchData({...employeeSearchData, filters:filters});
                break;
            case "departmentId":
                console.log(event.target.value);
                setDepartmnetIds(Array.from(event.target.selectedOptions,option=>option.value));
                setFilters({...filters, departments:departmnetIds});
                setEmployeeSearchData({...employeeSearchData, filters:filters});
                break;
            default:
                break;
        }
        //console.log(employeeSearchData);
    }
    const search=()=>{
        event.preventDefault();
        setEmployeeSearchData({...employeeSearchData, pagination:{pageNumber:0, pageSize:10}});
        setEmployeeSearchData({...employeeSearchData, sortBy:1});
        getEmployeeAPICall(employeeSearchData).then((response)=>{
            if(response.status == 200)
            {
                setEmployees(response.data);
                console.log(response.data);
            }
        }
        ).catch((error)=>{
            console.log(error);
        })
    }
 const addLikedId = (id)=>{
    if(!liked.includes(id))
        setLiked([...liked, id]);
 
 }
    return(
        <section>
            <div className="container">
                <div className="row">
                    <div className="col-md-12">
                        <h2>Employee Search</h2>
                        <form id="employeeSearchForm">
                            <div className="form-group">
                                <label htmlFor="employeeName">Employee Name:</label>
                                <input onChange={populateSearch} value={filters.name} type="text" className="form-control" name="employeeName" placeholder="Enter Employee Name" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="employeePhone">Employee Phone:</label>
                                <input type="text" onChange={populateSearch} value={filters.phone} className="form-control" name="employeePhone" placeholder="Enter Employee Phone" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="employeeName">Employee Age:</label>
                                <input type="text" onChange={populateSearch} value={ageRange.minAge} className="form-control" name="employeeMinAge" />
                                <input type="text" onChange={populateSearch} value={ageRange.maxAge}  className="form-control" name="employeeMaxAge"  />
                            </div>
                            <label className="form-control">Departmnet</label>
                            <div>
                                {
                                departments.length==0?<h1>No departments found</h1>:
                                <select multiple  className="form-control" onChange={populateSearch} name="departmentId" >
                                {
                                departments.map((departmnet)=>{
                                    return(
                                        <option key={departmnet.id} value={departmnet.id}>{departmnet.name}</option>
                                    )
                                })}
                            </select>
                                }
                            </div>
                            <button type="submit" onClick={search} className="btn btn-primary">Search</button>
                            Likes employees - {liked.length}
                        </form>
                    </div>
                </div>
            </div>
            <hr/>
            {employees?.length==0?<h1>No employees found</h1>:
                <Employees onLikedEmployee={addLikedId} employees={employees} />
            }
        </section>
    );

}