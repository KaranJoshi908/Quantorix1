import React, { useEffect, useState } from "react";
import { Routes, Route , useLocation } from "react-router-dom"

import ProductList from './ProductList'
import CreateProduct from "./CreateProduct";
import ProductAPI from "../API/ProductAPI";

const ProductWidget = () => {
  const [products ,setProducts] = useState([]);
  const [sortOrder,setSortOrder] = useState(1);
  const history = useLocation();

  useEffect(() => {
    ProductAPI.get()
              .then((Response) => {
                if(Response.data.status)
                {
                    console.log('setting data');
                    console.log(Response.data.productData);
                    setProducts(Response.data.productData);
                }
              })
  },[history])

  return(
    <>
     
     <Routes>
      <Route path='/' element= {<ProductList products={products} setProducts={setProducts} sortOrder={sortOrder} setSortOrder={setSortOrder}/>} />
      <Route path='/addProduct' element= {<CreateProduct/>} />
     </Routes>
    </>
  );
}

export default ProductWidget;