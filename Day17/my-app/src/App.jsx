
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import Login from './Components/Login/LOGIN.JSX'
import Menu from './Components/Menu/Menu'
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom'
import First from './Components/First'
import Salary from './Components/Salary/Salary'
import CreateEmployee from './Components/Employee/CreateEmployee'
import EmployeeSearch from './Components/Employee/EmployeeSearch'
import ProtectedRoute from './Components/ProtectedRoute'
import { AuthProvider } from './AuthContext'
import Logout from './Components/Logout'
import { Provider } from 'react-redux'
import store from './redux/store'



function App() {

  return (

      // <AuthProvider>
      <Provider store={store}>
        <BrowserRouter>
          <Menu/>
          <Routes>
            <Route path="/" element={<h1>Home</h1>} />
            <Route path="/first" element={<First/>} />
            <Route path="/salary" element={<Salary/> } />
            <Route path="/login" element={<Login/>} />
            <Route path="/logout" element={<Logout/>} />
            <Route path="/employees" element={ <EmployeeSearch/> } />
            <Route path="/create" element=
            {<ProtectedRoute><CreateEmployee/></ProtectedRoute>}
            />          
          </Routes>
        </BrowserRouter> 
        </Provider>
      // </AuthProvider>

  )
}

export default App
