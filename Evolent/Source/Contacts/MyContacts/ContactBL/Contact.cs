using System;

namespace ContactBL
{
    
    public class Contact:IContact
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;        
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _pinCode;
        private string _state;
        private string _country;
        private int _status;

        public int Id
        {
            get { return _id; }            
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }        
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }
        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string PinCode
        {
            get { return _pinCode; }
            set { _pinCode = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string getContactName()
        {
            string fullName = FirstName + ' ' + LastName;
            return fullName;
        }
    }
    public enum ContactStatus
    {
        Off = 0,
        On = 1
    }
}
