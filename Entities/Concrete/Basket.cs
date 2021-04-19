using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    //Varsayılan internal
    // PK
    // FK
    // Other columns
    public class Basket : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int Count { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Active { get; set; }
    }
}
