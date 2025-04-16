import axios from "axios"
import { baseUrl } from "../environments/environment.dev"

export function getDepartments(){
    const url = baseUrl+ "/Department"
    return axios.get(url);
}