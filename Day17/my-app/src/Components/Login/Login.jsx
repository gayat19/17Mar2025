import { useState } from "react";
import { LoginModel } from "../../Models/Login";
import './Login.css'
import { userLoginAPICall } from "../../Services/AuthenticationService";
// import { useAuth } from "../../AuthContext";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import{login} from "../../redux/authSlice";

const Login = ()=>{
const [user,setUser] = useState(new LoginModel());
const [error,setError] = useState({
    username:"",
    password:""
});




const changeUser = (event)=>{

    if(event.target.name==="username"){
        if(event.target.value.length==0){
            setError({
                ...error,
                username:"Username is required"
            })
        }
        else{
            setError({
                ...error,
                username: null          
             })
        setUser({
            ...user,
            username:event.target.value
        })
    }
    }
    if(event.target.name==="password"){
        if(event.target.value.length==0){
            setError({
                ...error,
                password:"Password is required"
            })
        }
        else{
            setError({
                ...error,
                password: null
            })
        
        setUser({
            ...user,
            password:event.target.value
        })
    }
    }

}
// const {login} = useAuth();
const dispatch = useDispatch();
const navigate = useNavigate();
const userLogin = ()=>{
    event.preventDefault();
    if(!error.username && !error.password){
    userLoginAPICall(user).then((response)=>{
        console.log(response.data);
        if(response.status===200){
           //login(response.data);
           dispatch(login(response.data));
           alert("Login Success")
           sessionStorage.setItem("user",JSON.stringify(response.data));
           navigate("/first");
        }else{
            alert("inccorect username or password")
        }
    }).catch((error)=>{
        console.log(error);
       
    }  )}
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
                    onChange={changeUser} required  />
                    {error.username?
                    <span className="alert alert-danger">{error.username}</span>:""}
                <label className="form-control">Password</label>
                <input name="password" value={user.password} className="form-control" onChange={changeUser} type="password"  />
                {error.password?<span className="alert alert-danger">error.password</span>:""}
                <button type="submit" className="btn btn-primary" onClick={userLogin}>Login</button>
            </form>
        </div>
    )
}


export default Login;