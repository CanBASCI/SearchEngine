using System.Linq;
using SearchEngine.Entities.Dto;
using System.Collections.Generic;
using SearchEngine.Common.Dto;

namespace SearchEngine.Common.Helpers
{
    public class Algorithm
    {
        public static List<Product> GetProductListByText(string text, List<Product> products, List<ProductTypePriority> productTypePriorityList)
        {
            List<Product> outputProductList = new List<Product>();
            string[] searchKeyList = GetSearchKeyList(text);

            for (int i = 0; i < searchKeyList.Length; i++)
            {
                List<Product> allProductList = GetProductList(products, searchKeyList[i]);
                Dictionary<Product, SortProperty> searchProductList = new Dictionary<Product, SortProperty>();

                if (allProductList.Count == 0)
                {
                    continue;
                }
                searchProductList = SetProductListIndex(allProductList, searchKeyList[i]);

                searchProductList = SetProductListLength(searchProductList);

                searchProductList = SetProductListCategory(searchProductList, productTypePriorityList);

                searchProductList = searchProductList.OrderByDescending(x => x.Value.CategoryPoint)
                                                     .OrderBy(x => x.Value.Index)
                                                     .OrderBy(x => x.Value.Length)
                                                     .ToDictionary(x => x.Key, x => x.Value);

                foreach (var searchProduct in searchProductList)
                {
                    products.Remove(searchProduct.Key);
                    outputProductList.Add(searchProduct.Key);
                }
            }

            return outputProductList;
        }

        private static string[] GetSearchKeyList(string searchKey)
        {
            string[] searchKeyList = searchKey.Split(' ');
            string[] criteriaList = new string[searchKeyList.Length + 1];

            for (int i = searchKeyList.Length; i >= 0; i--)
            {
                if (i == 0) criteriaList[i] = searchKey;
                else
                {
                    criteriaList[i] = searchKeyList[i - 1];
                }
            }

            return criteriaList;
        }

        private static List<Product> GetProductList(List<Product> allProductList, string searchKey)
        {
            List<Product> searchProductList = new List<Product>();

            if (allProductList.Count > 0)
            {
                searchProductList = allProductList.Where(x => x.ProductName.Contains(searchKey) && x.IsActive)
                                                                .OrderBy(x => x.ProductName)
                                                                .ToList();
            }

            return searchProductList;
        }

        private static Dictionary<Product, SortProperty> SetProductListIndex(List<Product> allProductList, string searchKey)
        {
            Dictionary<Product, SortProperty> productListWithIndex = new Dictionary<Product, SortProperty>();

            foreach (var product in allProductList)
            {
                int index = product.ProductName.IndexOf(searchKey);
                SortProperty sortProperty = new SortProperty()
                {
                    Index = index
                };
                productListWithIndex.Add(product, sortProperty);
            }
            return productListWithIndex;
        }

        private static Dictionary<Product, SortProperty> SetProductListLength(Dictionary<Product, SortProperty> allProductList)
        {
            foreach (var product in allProductList)
            {
                int totalChar = product.Key.ProductName.Length;
                product.Value.Length = totalChar;
            }
            return allProductList;
        }

        private static Dictionary<Product, SortProperty> SetProductListCategory(Dictionary<Product, SortProperty> allProductList, List<ProductTypePriority> productTypePriorityList)
        {
            foreach (var product in allProductList)
            {
                ProductTypePriority productTypePriority = productTypePriorityList.Where(x => x.ProductType == product.Key.ProductType).FirstOrDefault();
                product.Value.CategoryPoint = productTypePriority.Priority;
            }

            return allProductList;
        }
    }
}
