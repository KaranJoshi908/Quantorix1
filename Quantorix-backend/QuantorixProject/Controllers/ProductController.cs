using Microsoft.AspNetCore.Mvc;
using ProjectCommons.CommonContracts;
using ProjectCommons.CommonsInfo;
using QuantorixProject.Models;
using QuantorixProject.Repository.ProductRepository;

namespace QuantorixProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ILoggerService _logger;

        public ProductController(IProductRepository productRepository, ILoggerService loggerService)
        {
            _productRepository = productRepository;
            _logger = loggerService;
        }


        [HttpGet(Name = "getproducts")]
        public JsonResult getProducts()
        {
            _logger.Log(LoggerLevel.Info, "API Controller -> START | GetProducts");
            try
            {
                var productList = _productRepository.GetAllProducts();
                if (productList != null)
                {
                    return Json(new { status = true, message = "Data Retreived", productData = productList });
                }
                else
                {
                    throw new Exception("No Product retreived");
                }

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Error Occurred while Getting Product Data", productData = "" });
            }
        }

        [HttpPost]
        [Route("addProduct")]
        public JsonResult addProduct(ProductInfo productInfo)
        {
            try
            {



                if (_productRepository.CreateProductDetail(productInfo) > 0)
                {
                    if (_productRepository.SaveChanges())
                    {
                        return Json(new { status = true, message = "Product Creation Successfull!" });
                    }
                    else
                    {
                        throw new Exception("Product Creation failed at Save Changes");
                    }
                }
                else
                {
                    throw new Exception("Product Creation failed");
                }





            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Product Creation Failed!" });
            }
        }

        [HttpDelete("{id}")]
        public JsonResult deleteProduct(int id)
        {
            try
            {
                var product = _productRepository.GetProductInfoByID(id);
                if (product != null)
                {
                    if (_productRepository.DeleteProductDetail(product) > 0)
                    {

                        _productRepository.SaveChanges();

                        return Json(new { status = true, message = "Delete Product Successful" });
                    }
                    else
                    {
                        throw new Exception("Product Deletion Failed");
                    }
                }
                else
                {
                    throw new Exception("Product not found for this ID");
                }

            }
            catch (Exception ex)
            {
                //_logger.Log(LoggerLevel.Error, "Error Occurred while deleting Car Details : " + ex.ToString());
                return Json(new { status = false, message = "Delete product Failed", reason = ex.Message }) ;
            }
        }

        [HttpGet]
        [Route("sortedProducts")]
        public JsonResult getSortedProducts(int order)
        {
            _logger.Log(LoggerLevel.Info, "API Controller -> START | GetSortedProducts");
            List<ProductInfo> sortedProductList;
            try
            {
                var productList = _productRepository.GetAllProducts();
                

                if (productList != null)
                {
                    if (order == 1)
                        sortedProductList = productList.OrderBy(col => col.Price).ToList();
                    else if (order == 2)
                        sortedProductList = productList.OrderByDescending(col => col.Price).ToList();
                    else
                        sortedProductList = productList;

                    return Json(new { status = true, message = "Data Retreived", productData = sortedProductList });
                }
                else
                {
                    throw new Exception("No Product retreived");
                }

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Error Occurred while Getting Product Data", productData = "" });
            }
        }

    }
}
