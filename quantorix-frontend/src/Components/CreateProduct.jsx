import React, { useState } from 'react'
import Select from 'react-select'
import { useNavigate } from "react-router-dom";

import '../CSS/CreateProduct.css'
import ProductAPI from "../API/ProductAPI";

const CreateProduct = () => {
   const [customer,setCustomer] = useState('');
   const [product,setProduct] = useState('');
   const [price,setPrice] = useState('');
   const nav = useNavigate();

  const actions = [
    { label: "Laptop", value: "Laptop" },
    { label: "Keyboard", value: "Keyboard" },
    { label: "Paper", value: "Paper" },
    { label: "Mouse", value: "Mouse"}
  ];
 
  const handleProductDropdown = (selectedOption) => {
    console.log(selectedOption.value);
    setProduct(selectedOption);
  }

  const closeCreateProduct = () => {
    nav('/');
  }
  const handleAddProduct = () => {
    const ProductInfo = {
      Id: 0,
      Customer: customer,
      Product: product.value,
      Price:price
    };


    ProductAPI.post('/addProduct',ProductInfo)
    .then((Response) => {
                if(Response.data.status)
                {
                    console.log(Response.data.message);                    
                    nav('/');
                }
                else 
                {
                    console.log(Response.data.message);
                }
    })
  }

  return (
    <>
      <div className='create-product-header'>
        <h1 style={{color:'#87cdf0'}}>Add Product</h1>
      </div>
    
    <div className='create-product-parent'>
        <div className='create-product-row'>          
          <div 
            
            // contentEditable="true"
            // onChange={(e) => { setCustomer(e.target.value)}}
            // data-text="Enter Customer Name..."
            // id="div-customer"
          >
            <input 
              className="create-customer-input"
              type ='text' 
              onChange={(e) => { setCustomer(e.target.value)}} 
              placeholder='Enter Customer Name...'
              value={customer}
            />
            
          </div> 
        </div>
            
        <div className='create-product-row'>          
          <div className="create-product-input">
            <Select 
            options={actions} 
            value={product}
            onChange={(e)=> {handleProductDropdown(e)}}
            placeholder="Select Product"
            />
          </div> 
        </div>    
        
        <div className='create-product-row'>          
          <div>
            <input 
              className="create-price-input"
              type ='text' 
              onChange={(e) => { setPrice(e.target.value)}} 
              placeholder='Enter Price'
              value={price}
            />
          </div> 
        </div>

        <div className='createProduct-menu-parent'>
          <div 
            className='createProduct-menu-button clear-button'
            onClick={() => {closeCreateProduct()}}
          >
            Product List
          </div>
          <div 
            className='createProduct-menu-button create-button'
            onClick={() => {handleAddProduct()}}
          >
           Add Product
          </div>
        </div>
    </div>
    </>
  )
}

export default CreateProduct