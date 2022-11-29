import React from 'react'

import '../CSS/Product.css'

const ProductListHeader = () => {
    return (
        <div className="product-row-header-parent">             
            <div className="header-customer product-row-header-element">Customer</div>
            <div className="header-product product-row-header-element">Product</div>
            <div className="header-price product-row-header-element">Price</div>
        </div>
    );
}

export default ProductListHeader