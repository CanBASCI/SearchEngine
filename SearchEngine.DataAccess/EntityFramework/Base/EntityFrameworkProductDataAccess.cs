using SearchEngine.Core.DataAccess.Base;
using SearchEngine.DataAccess.EntityFramework.Context;
using SearchEngine.DataAccess.Interface;
using SearchEngine.Entities.Dto;

namespace SearchEngine.DataAccess.EntityFramework.Base
{
    public class EntityFrameworkProductDataAccess : BaseRepository<Product, DataBaseContext>, IProductDataAccess
    {

    }
}
