
import axiosInstance from "../Filters/AxiosFilter";
import { baseUrl } from "../environments/environment.dev";

export function addEmployeeAPICall(employee){
    const url = baseUrl+"/Employee";
    // var user =  JSON.parse(sessionStorage.getItem("user"))
    // console.log(user.token);
    // const httpHeaders = {
    //     "Content-Type": "application/json",
    //     "Accept": "application/json",
    //     "Authorization": "Bearer "+user.token
    // };
    // return axios.post(url, employee, {headers:httpHeaders})
    return axiosInstance.post(url, employee);
}

export function getSearchData(){
    const url = baseUrl+"/Employee/EmployeeLoadData";
    return axiosInstance.get(url);
}

export function getEmployeeAPICall(searchData){
    const url = baseUrl+"/Employee/EmployeeSearch";
    return axiosInstance.post(url, searchData);
}