import { useNavigate } from "react-router-dom";
import { useAuth } from "../AuthContext";
import { useDispatch } from "react-redux";

export default function Logout(){
    const navigate = useNavigate();
    const {logout} = useAuth();
    const dispatch = useDispatch();
    const handleLogout = () => {
       /// logout();
       dispatch(logout());
       navigate("/login");
    };
    return(
        <div>
            <h1>Logout</h1>
            <button onClick={handleLogout}>Logout</button>
        </div>
    )
}