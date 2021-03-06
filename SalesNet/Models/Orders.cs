﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SalesNet.Models
{
    public class Orders
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }
        [XmlAttribute("TotalRows")]
        public int TotalRows { get; set; }
        [XmlAttribute("PageStartRow")]
        public int PageStartRow { get; set; }
        [XmlAttribute("PageRows")]
        public int PageRows { get; set; }
        [XmlElement("Order")]
        public List<Order> OrderList { get; set; }

        public Orders()
        {
            OrderList = new List<Order>();
        }
    }

    public class Order
    {
        public string Id { get; set; }
        public string RowNumber { get; set; }
        public string TransNumber { get; set; }
        public string CustomerReference { get; set; }
        public string TransactionType { get; set; }
        public string DueDateFrom { get; set; }
        public string DueDateTo { get; set; }
        public string CreatedDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CarrierId { get; set; }
        public string CarrierCode { get; set; }
        public string CarrierName { get; set; }
        public string CarrierUrl { get; set; }
        public string ConNote { get; set; }
        public string OrderState { get; set; }
        public string DeliveryInstructions { get; set; }
        public string SpecialInstructions { get; set; }
        public string SupplyFromWarehouseId { get; set; }
        public string SupplyFromWarehouseCode { get; set; }
        public string SupplyFromWarehouseName { get; set; }
        public string CreditStatusFlag { get; set; }
        public string CreditStatus { get; set; }
        public string Lines { get; set; }
        [XmlElement("Link")]
        public Link Link { get; set; }
        //CurrencyType definition shared with Persons model
        public CurrencyType Currency { get; set; }
        public TransactionValues Ordered { get; set; }
        public TransactionValues Outstanding { get; set; }
        public TransactionValues Invoiced { get; set; }
        //Addresses definition shared with Persons model
        public Addresses Addresses { get; set; }
        public OrderDetails OrderDetails { get; set; }
        //public Invoices Invoices{ get; set; }
        //public FromOrders FromOrders{ get; set; }
    }

    public class TransactionValues
    {
        public int Quantity { get; set; }
        public float Gross { get; set; }
        public float Discount { get; set; }
        public float Net { get; set; }
        public float Tax { get; set; }
        public float Value { get; set; }
    }

    public class OrderDetails
    {
        [XmlAttribute("Type")]
        public string Type { get; set; }
        [XmlAttribute("TotalRows")]
        public string TotalRows { get; set; }
        [XmlElement("OrderDetail")]
        public List<Product> ProductList { get; set; }

        public OrderDetails()
        {
            ProductList = new List<Product>();
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Sequence { get; set; }
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Clrs Clrs { get; set; }
        public TransactionValues Ordered { get; set; }
        public TransactionValues Outstanding { get; set; }
        public TransactionValues Invoiced { get; set; }
    }

    public class Clrs
    {
        [XmlElement("Clr")]
        public List<Clr> ClrList { get; set; }
        [XmlAttribute("Type")]
        public string Type { get; set; }
        [XmlAttribute("TotalRows")]
        public string TotalRows { get; set; }

        public Clrs()
        {
            ClrList = new List<Clr>();
        }
    }

    public class Clr
    {
        public string DueDateFrom { get; set; }
        public string DueDateTo { get; set; }
        public string Id { get; set; }
        public string ClrId { get; set; }
        public string ClrCode { get; set; }
        public string ClrName { get; set; }
        public string Sequence { get; set; }
        public string OrderState { get; set; }
        public string DiscountPercent { get; set; }
        public string TaxPercent { get; set; }
        public TransactionValues Ordered { get; set; }
        public TransactionValues Outstanding { get; set; }
        public TransactionValues Invoiced { get; set; }
        public SKUs SKUs { get; set; }
    }

    public class SKUs
    {
        [XmlElement("SKU")]
        public List<SKU> SKUList { get; set; }
        [XmlAttribute("Type")]
        public string Type { get; set; }
        [XmlAttribute("TotalRows")]
        public string TotalRows { get; set; }

        public SKUs()
        {
            SKUList = new List<SKU>();
        }
    }

    public class SKU
    {
        public string Id { get; set; }
        public string SkuId { get; set; }
        public string SizeCode { get; set; }
        public string Sequence { get; set; }
        public string Price { get; set; }
        public TransactionValues Ordered { get; set; }
        public TransactionValues Outstanding { get; set; }
        public TransactionValues Invoiced { get; set; }
    }

    public class Invoices
    {
        public string Type { get; set; }
        public string TotalRows { get; set; }
    }

    public class FromOrders
    {
        public string Type { get; set; }
        public string TotalRows { get; set; }
    }

    public class Link
    {
        [XmlAttribute("Rel")]
        public string Rel { get; set; }
        [XmlText]
        public string Value { get; set; }
    }

    public class OrderFilters
    {
        public int Id { get; set; }
        public int RequestPersonId { get; set; }
        public int RequestCustomerId { get; set; }
        [FilterField]
        public string TransNumber { get; set; }
        [FilterField]
        public string CustRef { get; set; }
        [FilterField]
        public string CreatedDateFrom { get; set; }
        [FilterField]
        public string CreatedDateTo { get; set; }
        [FilterField]
        public string DueDateFrom { get; set; }
        [FilterField]
        public string DueDateTo { get; set; }
        [FilterField]
        public string ProductFilter { get; set; }
        [FilterField]
        public string TransType { get; set; }
        public int StartRow { get; set; }
        public int PageRows { get; set; }
    }

    public class OrderPageData
    {
        public OrderFilters Filters { get; set; }
        public Orders Orders { get; set; }
    }
}