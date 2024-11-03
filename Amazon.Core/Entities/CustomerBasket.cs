﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Entities
{
    public class CustomerBasket:BaseEntity
    {
        public CustomerBasket(int id)
        {
            Id = id;
            Items = new List<BasketItem>();
        }

        public List<BasketItem> Items { get; set; }

        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public int? DeliveryMethodId { get; set; }
    }
}
