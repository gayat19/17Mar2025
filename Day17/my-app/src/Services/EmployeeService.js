import axios from "axios";
import { baseUrl } from "../environments/environment.dev";

export function addEmployeeAPICall(employee){
    const url = baseUrl+"/Employee";
    var user =  JSON.parse(sessionStorage.getItem("user"))
    console.log(user.token);
    const httpHeaders = {
        "Content-Type": "application/json",
        "Accept": "application/json",
        "Authorization": "Bearer "+user.token
    };
    return axios.post(url, employee, {headers:httpHeaders})
}