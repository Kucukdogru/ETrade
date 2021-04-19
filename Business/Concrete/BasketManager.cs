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
    public class BasketManager:IBasketService
    {
        //Bir servis sadece kendi servisini enjekte edebilir
        //Buraya ICategoryDal enjekte edemeyiz.
        //Bir servis sadece kendi DataAcces'ini enjekte edebilir
        //Servis tarafında web ve mobil aynı olacak

        private IBasketDal _basketDal;
        private IProductService _productService;

        public BasketManager(IBasketDal basketDal, IProductService productService)
        {
            _basketDal = basketDal;
            _productService = productService;
        }

        public IDataResult<List<Basket>> GetAll()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetAll(), Messages.BasketListed);
        }

        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);
            return new SuccessResult(Messages.BasketAdded);
        }
    }
}
