import { useState } from "react";
import { LoginModel } from "../../Models/Login";
import './Login.css'
import { userLoginAPICall } from "../../Services/AuthenticationService";

const Login = ()=>{
const [user,setUser] = useState(new LoginModel());




const changeUser = (event)=>{
    if(event.target.name==="username"){
        setUser({
            ...user,
            username:event.target.value
        })
    }
    if(event.target.name==="password"){
        setUser({
            ...user,
            password:event.target.value
        })
    }
}
const login = ()=>{
    event.preventDefault();
    userLoginAPICall(user).then((response)=>{
        console.log(response.data);
        if(response.status===200){
           alert("Login Success")
           sessionStorage.setItem("user",JSON.stringify(response.data));
        }else{
            alert("inccorect username or password")
        }
    }).catch((error)=>{
        console.log(error);
       
    }  )
}
    return(
        <div>
            <h1>Login</h1>

            <form className="login-form">
                <label className="form-control">Username</label>
                <input 
                    name="username"
                    value={user.username} 
                    className="form-control" 
                    type="text" 
                    placeholder="Username"
                    onChange={changeUser}  />
                <label className="form-control">Password</label>
                <input name="password" value={user.password} className="form-control" onChange={changeUser} type="password"  />
                <button type="submit" className="btn btn-primary" onClick={login}>Login</button>
            </form>
        </div>
    )
}


export default Login;