import { createContext, useContext,useState } from "react";


const AuthContext = createContext();

export const useAuth = ()=> useContext(AuthContext);

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);

    const login = (userData) => {
        setUser(userData);
        sessionStorage.setItem("user", JSON.stringify(userData));
    };
    const logout = () => {
        setUser(null);
        sessionStorage.removeItem("user");
    };

    return(
        <AuthContext.Provider value={{ user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
}