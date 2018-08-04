using System;
using System.Web.Http;
using ContactDAL;
using ContactBL;
using System.Configuration;
using System.Collections.Generic;

namespace MyContacts.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        [ActionName("AddContactDetails")]
        public bool AddContactDetails([FromBody]Contact model)
        {
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            ContactData dal = new ContactData(con);
            Contact contact = new Contact();
            if (model!=null)
            {
                try
                {
                    contact.FirstName = model.FirstName;
                    contact.LastName = model.LastName;
                    contact.Email = model.Email;
                    contact.PhoneNumber = model.PhoneNumber;
                    contact.AddressLine1 = model.AddressLine1;
                    contact.AddressLine2 = model.AddressLine2;
                    contact.City = model.City;
                    contact.PinCode = model.PinCode;
                    contact.State = model.State;
                    contact.Country = model.Country;
                    contact.Status = model.Status;
                    dal.AddContact(contact);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
            }                        
            return false;
        }       
        [HttpGet]
        [ActionName("GetContactDetail")]
        public Contact GetContactDetail([FromBody]Contact model)
        {
            Contact contact = new Contact();
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            ContactData dal = new ContactData(con);
            try
            {                
                return dal.GetContact(model.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        [HttpGet]
        [ActionName("GetContactsDetails")]
        public List<Contact> GetContactsDetails()
        {
            Contact contact = new Contact();
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            ContactData dal = new ContactData(con);
            try
            {
                return dal.GetContacts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        [HttpPost]
        [ActionName("DeleteContactDetails")]
        public bool DeleteContactDetails([FromBody]Contact model)
        {
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            ContactData dal = new ContactData(con);
            try
            {
                dal.DeleteContact(model.Id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        [HttpPost]
        [ActionName("UpdateContactDetails")]
        public bool UpdateContactDetails([FromBody]Contact model)
        {
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            ContactData dal = new ContactData(con);
            Contact contact = new Contact();
            if (model != null)
            {
                try
                {
                    contact.FirstName = model.FirstName;
                    contact.LastName = model.LastName;
                    contact.Email = model.Email;
                    contact.PhoneNumber = model.PhoneNumber;
                    contact.AddressLine1 = model.AddressLine1;
                    contact.AddressLine2 = model.AddressLine2;
                    contact.City = model.City;
                    contact.PinCode = model.PinCode;
                    contact.State = model.State;
                    contact.Country = model.Country;
                    contact.Status = model.Status;
                    dal.UpdateContact(contact);
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
                return true;
            }

            return false;
        }
        [HttpPost]
        [ActionName("ActivateContact")]
        public bool ActivateContact([FromBody]Contact model)
        {
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            ContactData dal = new ContactData(con);
            Contact contact = new Contact();
            if (model != null)
            {                
                dal.ActivateContact(contact,(ContactStatus)model.Status);
                return true;
            }

            return false;
        }
               

    }
}
