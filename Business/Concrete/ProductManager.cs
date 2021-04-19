using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    // UI -> Business -> DataAccess

    
    public class ProductManager:IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId), Messages.ProductsListed);
        }

        public IResult Add(Product product)
        {
            if (product.CategoryId==1)
            {
                return new ErrorResult("Bu kategoriye ürün eklenemiyor!!!");
            }
            else
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
        }
    }
}
