
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import Login from './Components/Login/LOGIN.JSX'
import Menu from './Components/Menu/Menu'
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom'
import First from './Components/First'
import Salary from './Components/Salary/Salary'
import CreateEmployee from './Components/Employee/CreateEmployee'



function App() {
  // const [count, setCount] = useState(0)
  // const element = <h1>Hello from react</h1>
  return (
    <div>
   <BrowserRouter>
      <Menu/>
      <Routes>
        <Route path="/" element={<h1>Home</h1>} />
        <Route path="/first" element={<First/>} />
        <Route path="/salary" element={<Salary/> } />
        <Route path="/login" element={<Login/>} />
        <Route path="/create" element={ <CreateEmployee/> } />
      </Routes>
      </BrowserRouter>  
      </div>
  )
}

export default App
