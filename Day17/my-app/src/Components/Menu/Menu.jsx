import { Link } from "react-router-dom";

export default function Menu(){
    return(
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <a className="navbar-brand" href="#">Navbar</a>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarNav">
                <ul className="navbar-nav">
                    <li className="nav-item">
                        <Link className="nav-link" to='' >Home</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to='first'>First</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to='salary'>Salary</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="login">Login</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="employees">Employees</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="create">New Employee</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="logout">Logout</Link>
                    </li>
                </ul>
            </div>
        </nav>
    )
}