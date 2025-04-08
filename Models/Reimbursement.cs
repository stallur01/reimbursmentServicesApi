using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace reimbursmentServicesApi.Models
{
    public class Reimbursement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
       
        public string? Id { get; set; }
        public string? Description { get; set; }
        public string? ReceiptFileName { get; set; }
        public string? ReceiptFilePath { get; set; }

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
