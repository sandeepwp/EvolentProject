using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBL
{
    interface IContact
    {
        int Id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }        
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string PinCode { get; set; }
        string State { get; set; }
        string Country { get; set; }
        int Status { get; set; }
    }
}
