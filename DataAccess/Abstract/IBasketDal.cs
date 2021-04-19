using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //1)Entities, 2)DataAccess
    public interface IBasketDal:IEntityRepository<Basket>
    {

    }
}
