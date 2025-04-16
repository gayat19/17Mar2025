import { useState } from "react";
import { useEffect } from "react";
import { getSalaries } from "../../Services/SalaryAPIService";

export default function Salary(){
  const [salaries,setSalaries] = useState([])
    useEffect(()=>{
        getSalaries().then((response)=>{
            setSalaries(response.data);
        });
    },[]);
    return(
        <div>
            <h1>Salary</h1>
            {
                salaries.length==0?
                <p>Yet to load...</p>
                :
                <table border="1">
                    <tbody>
                    <tr>
                        <th>Id</th>
                        <th>Baisic</th>
                        <th>HRA</th>
                        <th>DA</th>
                        <th>Allowance</th>
                        <th>PF</th>
                    </tr>
                    {
                        salaries.map((salary)=>(
                            <tr key={salary.id}>
                                <td>{salary.id}</td>
                                <td>{salary.basic}</td>
                                <td>{salary.hra}</td>
                                <td>{salary.da}</td>
                                <td>{salary.allowance}</td>
                                <td>{salary.pf}</td>
                            </tr>
                        ))
                    }   
                    </tbody>
                </table>
            }
        </div>
    );
}