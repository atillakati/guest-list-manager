using System;
using System.Collections.Generic;
using System.Text;

namespace Guestlist.Data.Models
{
    public class GuestModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string StreetAndNr { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public bool HasConfirmed { get; set; }
        public DateTime LastChangeAt { get; set; }
    }
}
