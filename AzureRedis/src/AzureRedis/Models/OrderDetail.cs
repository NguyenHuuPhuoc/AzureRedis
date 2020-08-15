using System.Runtime.Serialization;

namespace AzureRedis.Models
{
    [DataContract]
    public class OrderDetail
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int ProductSizeId { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
