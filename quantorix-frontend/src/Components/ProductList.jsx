import React, { useEffect, useState } from 'react'
import { Link , useNavigate } from "react-router-dom";

import Product from './Product'
import ProductListHeader from './ProductListHeader';
import '../CSS/Product.css'
import ProductAPI from "../API/ProductAPI";


const ProductList = ({products,setProducts,sortOrder,setSortOrder}) => {
  const nav = useNavigate();
  let alternateRow = false;

  const rendered_product_list = products.map(product => {
    
    alternateRow = !alternateRow;
    return <Product 
       productInfo = {product} 
       isAlternateRow = {alternateRow}
    />
  }); 

  const handleSorting = () => {
    ProductAPI.get('/sortedProducts',{
      params:{
        order : sortOrder
      }
    })
    .then((Response) => {
                if(Response.data.status)
                {
                    console.log('setting sorted data');                    
                    setProducts(Response.data.productData);
                }
    })

    sortOrder == 1 ? setSortOrder(2) : setSortOrder(1);
  }

  

  return (
    <>
    <div className='create-product-header'>
      <h1 style={{color:'#87cdf0'}}>Product Catalog</h1>
    </div>
    <div className='catalog-menu-parent'>
      <div className='catalog-menu-button sort-button' onClick={() => { handleSorting()}}>
        {sortOrder == 1 ? 'Sort ⬇' : 'Sort ⬆'}
        
        </div>
      <div className='catalog-menu-button add-button' onClick={()=> nav('/addProduct')}
      >Add Product</div> 
    </div>
    {/* <input type='button' onClick={() => {nav('/addProduct')}} value='Add Product'/> */}
    <div className='product-list-container'>
      <ProductListHeader />
      {rendered_product_list}
    </div>  
    </>
  )
}

export default ProductList