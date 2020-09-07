using SearchEngine.Entities.Dto;
using System.Collections.Generic;
using SearchEngine.Core.Utilities.Enums;
using SearchEngine.Core.Utilities.Results.Interface;

namespace SearchEngine.Business.Interface
{
    public interface IProductTypePriorityService
    {
        IDataResult<ProductTypePriority> GetById(int id);
        IDataResult<List<ProductTypePriority>> GetList();
        IDataResult<List<ProductTypePriority>> GetPriorityByProductType(ProductType productType);
        IResult Add(ProductTypePriority product);
        IResult Delete(ProductTypePriority product);
        IResult Update(ProductTypePriority product);
    }
}
