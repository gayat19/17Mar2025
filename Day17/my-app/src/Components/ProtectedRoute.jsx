import { Navigate } from "react-router-dom";
// import { useAuth } from "../AuthContext";
import { useSelector } from "react-redux";

const ProtectedRoute = ({ children }) => {
    //const user = sessionStorage.getItem("user") ? JSON.parse(sessionStorage.getItem("user")) : null;
   // const {user} =  useAuth();
   const user = useSelector((state)=>state.auth.user);
   console.log(user);
    
    return user ? children : <Navigate to="/login" replace />;
    }

    export default ProtectedRoute;