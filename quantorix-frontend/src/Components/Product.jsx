import React from 'react'

import '../CSS/Product.css'

const Product = ({productInfo,isAlternateRow}) => {

    const rowClass = isAlternateRow ? 'product-row-parent product-row-parent-alternate' : 'product-row-parent'

    return (
        <div 
             key = {productInfo.id} 
             className={rowClass}
        >             
            <div className="product-row-element row-customer">{productInfo.customer}</div>
            <div className="product-row-element row-product">{productInfo.product}</div>
            <div className="product-row-element row-price">{productInfo.price}</div>
        </div>
    );
}

export default Product