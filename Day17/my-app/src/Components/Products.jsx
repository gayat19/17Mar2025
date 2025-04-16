import { useState } from "react";
import './Product.css'
import { useEffect } from "react";

const Products =()=>{
    const [products,setProducts] = useState([]);
    const fetchData = ()=>{
            fetch('https://dummyjson.com/products').then(
                (data)=>{
                    return data.json()  
                }).then(
                    (jsonData)=>{
                        setProducts(jsonData.products);
                        
                    })
    }
    useEffect(()=>{
        fetch('https://dummyjson.com/products').then(
            (data)=>{
                return data.json()  
            }).then(
                (jsonData)=>{
                    setProducts(jsonData.products);
                    
                })
    },[]);
    return(
        <div>
            <h1>Products</h1>
            <p><button onClick={fetchData}>Get Products</button></p>
            <div>
                {
                products.length==0?
                    <div className="spinner-border text-success" role="status">
                        <span className="sr-only"></span>
                    </div>
                    :
                   <div className="flex-container">
                    {
                         products.map((product)=>{
                            return(<div key={product.id} className="card flex-item" >
                            <img className="card-img-top" src={product.thumbnail} alt="Card image cap"/>
                              <h5 className="card-title">{product.title}</h5>
                              <p className="card-text">{product.description}</p>
                              <a href="#" className="btn btn-primary">Buy for ${product.price}</a>
                            </div>)})
                    }
                  </div>

            }
            </div>
        </div>
    )
}

export default Products;