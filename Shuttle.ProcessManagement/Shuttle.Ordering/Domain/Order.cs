﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shuttle.Ordering.Domain
{
    public class Order
    {
        private readonly List<OrderItem> _items = new List<OrderItem>();

        public Order(string orderNumber, DateTime orderDate)
            : this(Guid.NewGuid(), orderNumber, orderDate)
        {
        }

        public Order(Guid id, string orderNumber, DateTime orderDate)
        {
            Id = id;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }

        public Guid Id { get; private set; }
        public string OrderNumber { get; private set; }
        public OrderCustomer Customer { get; set; }

        public IEnumerable<OrderItem> Items
        {
            get { return new ReadOnlyCollection<OrderItem>(_items); }
        }

        public DateTime OrderDate { get; private set; }

        public void AddItem(string description, decimal price)
        {
            _items.Add(new OrderItem(description, price));
        }
    }
}