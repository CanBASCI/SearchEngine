using SearchEngine.Core.Entities;
using SearchEngine.Core.Utilities.Enums;

namespace SearchEngine.Entities.Dto
{
    public class ProductTypePriority : IEntity
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public int Priority { get; private set; }
    }
}
