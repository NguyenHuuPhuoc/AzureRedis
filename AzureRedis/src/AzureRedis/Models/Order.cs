using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AzureRedis.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public int? CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        public int ShopId { get; set; }
        [DataMember]
        public string ServedPerson { get; set; }
        [DataMember]
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
        [DataMember]
        public string DeliveryCustomer { get; set; }
        public int StoreId { get; set; }
        [DataMember]
        public string OrderCode { get; set; }
        [DataMember]
        public System.DateTime CheckInDate { get; set; }
        public Nullable<System.DateTime> CheckOutDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public double TotalAmount { get; set; }
        [DataMember]
        public double FinalAmount { get; set; }
        [DataMember]
        public OrderStatus OrderStatus { get; set; }
        [DataMember]
        public string CheckInPerson { get; set; }
        [DataMember]
        public string CheckOutPerson { get; set; }
        [DataMember]
        public string ApprovePerson { get; set; }
        [DataMember]
        public DateTime? CancelDate { get; set; }
        public string CancelBy { get; set; }
        [DataMember]
        public string ApiLog { get; set; }
        public DiscountType DiscountType { get; set; }
        public  IList<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        New = 8,
        PosProcessing = 17,
        Processing = 10,
        PosFinished = 11,
        Finish = 2,
        PosCancel = 13,
        Cancel = 3,
        PosPreCancel = 12,
        PreCancel = 4
    }

    public enum DiscountType
    {
        None = 0,
        OneGetOne = 1,
        _20kDiscount = 2,
        FiveGetOne = 3,
        Delivery = 4,
        Sharing = 5,
        UseActiveBonus = 6
    }
}
