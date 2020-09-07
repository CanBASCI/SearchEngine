using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchEngine.Business.Contants;
using SearchEngine.Business.Interface;
using SearchEngine.Core.Utilities.Enums;
using SearchEngine.Core.Utilities.Results.Impl;
using SearchEngine.Core.Utilities.Results.Interface;
using SearchEngine.DataAccess.Interface;
using SearchEngine.Entities.Dto;

namespace SearchEngine.Business.Impl
{
    public class ProductTypePriorityService : IProductTypePriorityService
    {
        private readonly IProductTypePriorityDataAccess productTypePriorityDataAccess;

        public ProductTypePriorityService(IProductTypePriorityDataAccess productTypePriorityDataAccess)
        {
            this.productTypePriorityDataAccess = productTypePriorityDataAccess;
        }

        public IDataResult<ProductTypePriority> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<ProductTypePriority>(productTypePriorityDataAccess.Get(p => p.Id == Id));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProductTypePriority>(null, ex.Message);
            }
        }

        public IDataResult<List<ProductTypePriority>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<ProductTypePriority>>(productTypePriorityDataAccess.GetList().ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductTypePriority>>(null, ex.Message);
            }
        }


        public IDataResult<List<ProductTypePriority>> GetPriorityByProductType(ProductType productType)
        {
            try
            {
                return new SuccessDataResult<List<ProductTypePriority>>(productTypePriorityDataAccess.GetList(p => p.ProductType == productType).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ProductTypePriority>>(null, ex.Message);
            }
        }

        public IResult Add(ProductTypePriority product)
        {
            try
            {
                productTypePriorityDataAccess.Add(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(ProductTypePriority product)
        {
            try
            {
                productTypePriorityDataAccess.Delete(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(ProductTypePriority product)
        {
            try
            {
                productTypePriorityDataAccess.Updated(product);
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
