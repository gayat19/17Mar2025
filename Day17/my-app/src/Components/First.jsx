import { useState } from "react";

export default function First(){
    const [counter,setCounter] = useState(0)
    const [msg,setMsg]= useState("Hello from First Component")
   
    const change = () => {
        setMsg("Hello from First Component - Changed")
    }
    const changeCounter=()=>{
        setCounter(counter+1)
       
    }
    return(
        <section>
            <h1>First Component</h1>
           {counter}<button onClick={changeCounter}>Change Counter</button>
             {/* interpollation */}<p>{msg} <button onClick={change}>Change Value</button>

             </p>
        </section>
    );
}