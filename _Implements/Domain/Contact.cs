using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Contact
    {
        // user ID from AspNetUser table.
        public string OwnerID { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ContactStatus Status { get; set; }
    }

    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
