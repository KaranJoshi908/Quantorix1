using Microsoft.EntityFrameworkCore;
using ProjectCommons.CommonContracts;
using ProjectCommons.CommonsInfo;
using QuantorixProject.Models;

namespace QuantorixProject.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly QuantorixContext _context;
        private readonly ILoggerService _logger;

        public ProductRepository(QuantorixContext context,ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }


        public List<ProductInfo> GetAllProducts()
        {
            _logger.Log(LoggerLevel.Info, "Get ALL Products -> START");
            var productList = _context.ProductInfos.ToList();
            if (productList.Count > 0)
            {
                _logger.Log(LoggerLevel.Info, "Get ALL Products -> END");
                return productList;
            }
            else
            {
                // _logger.Log(LoggerLevel.Warn, "Returning NULL from GetAllCarList");
                _logger.Log(LoggerLevel.Debug, "No Products FOUND!!");
                return null;
            }
        }

        public int CreateProductDetail(ProductInfo productInfo)
        {
            try
            {
                if (productInfo != null)
                {
                    if (productInfo.Id == 0)
                    {
                        _context.ProductInfos.Add(productInfo);

                    }
                    else
                    {
                        _context.Entry(productInfo).State = EntityState.Modified;

                    }
                }
                else
                {
                    return 0;
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteProductDetail(ProductInfo productInfo)
        {
            try
            {
                _context.ProductInfos.Remove(productInfo);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public ProductInfo GetProductInfoByID(int id)
        {
            var productDetail = _context.ProductInfos.Find(id);
            return productDetail;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
        
    }
}
