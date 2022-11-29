using QuantorixProject.Models;

namespace QuantorixProject.Repository.ProductRepository
{
    public interface IProductRepository
    {

        public List<ProductInfo> GetAllProducts();

        public bool SaveChanges();

        public int CreateProductDetail(ProductInfo productInfo);

        public int DeleteProductDetail(ProductInfo productInfo);

        public ProductInfo GetProductInfoByID(int id);
    }
}
