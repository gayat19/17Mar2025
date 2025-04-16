import axios from 'axios';
import { baseUrl } from '../environments/environment.dev';


export function getSalaries(){
    const url = baseUrl + '/Salary';
    return axios.get(url);
}