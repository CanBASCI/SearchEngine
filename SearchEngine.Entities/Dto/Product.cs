using System;
using SearchEngine.Core.Entities;
using SearchEngine.Core.Utilities.Enums;

namespace SearchEngine.Entities.Dto
{
    public class Product : IEntity
    {
        public Product()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public bool IsActive { get; private set; }
        public DateTime Date { get; private set; }
    }
}
