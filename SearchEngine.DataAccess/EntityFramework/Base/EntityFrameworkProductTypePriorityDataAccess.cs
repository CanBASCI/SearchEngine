using SearchEngine.Core.DataAccess.Base;
using SearchEngine.DataAccess.EntityFramework.Context;
using SearchEngine.DataAccess.Interface;
using SearchEngine.Entities.Dto;

namespace SearchEngine.DataAccess.EntityFramework.Base
{
    public class EntityFrameworkProductTypePriorityDataAccess : BaseRepository<ProductTypePriority, DataBaseContext>, IProductTypePriorityDataAccess
    {

    }
}
