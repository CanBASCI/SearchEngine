using System.Collections;
using System.Linq;
using SearchEngine.Entities.Dto;
using System.Collections.Generic;

namespace SearchEngine.Common.Helpers
{
    public class Algorithm
    {
        private const string Space = " ";
        public static List<Product> GetProductListByText(string text, List<Product> products)
        {
            //var textList = text.Split(Space);
            //var searchTextList = new string[textList.Length];

            //for (int i = textList.Length; i > 0; i--)
            //{
            //    searchTextList[textList.Length - i] = text.Replace(textList[i], "");
            //}

            return products.Where(x => x.ProductName.Contains(text) && x.IsActive)
                .OrderBy(y => y.ProductName).ToList();
        }

        public static Dictionary<Product, int> GetProductListByIndex(string text, List<Product> products)
        {


            Dictionary<Product, int> dictionary = new Dictionary<Product, int>();
            foreach (var product in products)
            {
                int index = product.ProductName.IndexOf(text);
                dictionary.Add(product, index);
            }

            var productOrdered = dictionary.OrderBy(x => x.Value);

            return productOrdered.ToDictionary(x => x.Key, y => y.Value);
        }

        public static Dictionary<Product, int> GetProductListByLength(string text, List<Product> products)
        {
            Dictionary<Product, int> dictionary = new Dictionary<Product, int>();
            foreach (var product in products)
            {
                int length = product.ProductName.Length;
                dictionary.Add(product, length);
            }

            var productOrdered = dictionary.OrderBy(x => x.Value);

            return productOrdered.ToDictionary(x => x.Key, y => y.Value);
        }
    }
}
