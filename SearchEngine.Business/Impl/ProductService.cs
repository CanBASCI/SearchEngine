using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchEngine.Business.Contants;
using SearchEngine.Business.Interface;
using SearchEngine.Common.Helpers;
using SearchEngine.Core.Utilities.Enums;
using SearchEngine.Core.Utilities.Results.Impl;
using SearchEngine.Core.Utilities.Results.Interface;
using SearchEngine.DataAccess.Interface;
using SearchEngine.Entities.Dto;

namespace SearchEngine.Business.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductDataAccess productDataAccess;

        public ProductService(IProductDataAccess productDataAccess)
        {
            this.productDataAccess = productDataAccess;
        }

        public IDataResult<Product> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Product>(productDataAccess.Get(p => p.Id == Id));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList().ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetListByProductName(string productName)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList(p => p.ProductName == productName)
                    .ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetListByText(string text)
        {
            try
            {
                var productList = productDataAccess.GetList().ToList();
                var productListByText = Algorithm.GetProductListByText(text, productList);
                var productListByIndex = Algorithm.GetProductListByIndex(text, productListByText);
                //var productListLength = Algorithm.GetProductListByLength(text, productListByIndex);

                return new SuccessDataResult<List<Product>>(productListByText);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetListByProductStatus(bool productStatus)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList(p => p.IsActive == productStatus).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetListByProductType(ProductType productType)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList(p => p.ProductType == productType).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IResult Add(Product product)
        {
            try
            {
                productDataAccess.Add(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            try
            {
                productDataAccess.Delete(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            try
            {
                productDataAccess.Updated(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductAdded);
        }

    }
}
