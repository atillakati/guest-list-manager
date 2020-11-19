using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Guestlist.Data.Entities
{
    public class GuestEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string StreetAndNr { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public bool HasConfirmed { get; set; }
        public DateTime LastChangeAt { get; set; }
    }
}
