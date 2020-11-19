using System;

namespace Guestlist.Core
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string StreetAndNr { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }               
    }
}