import { useState } from "react"

const Counter =()=>{
    const [counter,setCounter] = useState(0);

    return(
        <div>
            <h1>Counter</h1>
            <p>
                <button onClick={()=>setCounter(counter+1)}>+</button>
                
                {counter}
                <button onClick={()=>setCounter(counter-1)}>-</button>
            </p>

        </div>
    );
}

export default Counter;