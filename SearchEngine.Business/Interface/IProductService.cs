using SearchEngine.Entities.Dto;
using System.Collections.Generic;
using SearchEngine.Core.Utilities.Enums;
using SearchEngine.Core.Utilities.Results.Interface;

namespace SearchEngine.Business.Interface
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByProductName(string productName);
        IDataResult<List<Product>> GetListByText(string text);
        IDataResult<List<Product>> GetListByProductType(ProductType productType);
        IDataResult<List<Product>> GetListByProductStatus(bool productStatus);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}
