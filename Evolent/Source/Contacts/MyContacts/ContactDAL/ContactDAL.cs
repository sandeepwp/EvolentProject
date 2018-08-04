using ContactBL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDAL
{
    public class ContactData
    {
        private SqlConnection conn;
        private static string connString;
        private SqlCommand command;
        private static List<Contact> contactList;
        private ErrorHandler.ErrorHandler err;

        public ContactData(string _connString)
        {            
            err = new ErrorHandler.ErrorHandler();
            connString = _connString;
        }
        
        public void AddContact(Contact contact)
        {
            try
            {
                using (conn)
                {

                    string sqlInserString = "exec SPInsertContacts @FirstName,@LastName,@Email,@PhoneNumber,@Status ";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlInserString;

                    SqlParameter firstNameparam = new SqlParameter("@FirstName", contact.FirstName);
                    SqlParameter lastNameparam = new SqlParameter("@LastName", contact.LastName);
                    SqlParameter emailparam = new SqlParameter("@Email", contact.Email);
                    SqlParameter phoneNumberParam = new SqlParameter("@PhoneNumber", contact.PhoneNumber);
                    SqlParameter addressLine1Param = new SqlParameter("@AddressLine1", contact.AddressLine1);
                    SqlParameter addressLine2Param = new SqlParameter("@AddressLine2", contact.AddressLine2);
                    SqlParameter cityParam = new SqlParameter("@City", contact.City);
                    SqlParameter pinCodeParam = new SqlParameter("@PinCode ", contact.PinCode);
                    SqlParameter stateParam = new SqlParameter("@State", contact.State);
                    SqlParameter countryParam = new SqlParameter("@Country", contact.Country);
                    SqlParameter statusParam = new SqlParameter("@Status", contact.Status);

                    command.Parameters.AddRange(new SqlParameter[] { firstNameparam, lastNameparam, emailparam, phoneNumberParam, addressLine1Param, addressLine2Param, cityParam, pinCodeParam, stateParam, countryParam, statusParam });
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                }
            }
            catch (Exception ex)
            {
                err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                using (conn)
                {
                    string sqlUpdateString = "exec SPUpdateContacts  @FirstName,@LastName,@Email,@PhoneNumber,@AddressLine1,@AddressLine2,@City,@PinCode,@State,@Country,@Status,@Id";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlUpdateString;

                    SqlParameter firstNameparam = new SqlParameter("@FirstName", contact.FirstName);
                    SqlParameter lastNameparam = new SqlParameter("@LastName", contact.LastName);
                    SqlParameter emailparam = new SqlParameter("@Email", contact.Email);
                    SqlParameter phoneNumberParam = new SqlParameter("@PhoneNumber", contact.PhoneNumber);                    
                    SqlParameter addressLine1Param = new SqlParameter("@AddressLine1", contact.AddressLine1);
                    SqlParameter addressLine2Param = new SqlParameter("@AddressLine2", contact.AddressLine2);
                    SqlParameter cityParam = new SqlParameter("@City", contact.City);
                    SqlParameter pinCodeParam = new SqlParameter("@PinCode", contact.PinCode);
                    SqlParameter stateParam = new SqlParameter("@State", contact.State);
                    SqlParameter countryParam = new SqlParameter("@Country", contact.Country);
                    SqlParameter statusParam = new SqlParameter("@Status", contact.Status);
                    SqlParameter statusId = new SqlParameter("@Id", contact.Id);

                    command.Parameters.AddRange(new SqlParameter[] { firstNameparam, lastNameparam, emailparam, phoneNumberParam, statusParam, statusId });
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public void ActivateContact(Contact contact, ContactStatus activateContact)
        {
            try
            {
                using (conn)
                {
                    string sqlUpdateString = "exec SPActivateContacts  @Id,@Status";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlUpdateString;

                    SqlParameter statusParam = new SqlParameter("@Status", activateContact);
                    SqlParameter statusId = new SqlParameter("@Id", contact.Id);

                    command.Parameters.AddRange(new SqlParameter[] { statusParam, statusId });
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public void DeleteContact(int iD)
        {
            try
            {
                using (conn)
                {
                    string sqlDeleteString = "exec SPDeleteContact @ID ";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlDeleteString;

                    SqlParameter IDparam = new SqlParameter("@ID", iD);
                    command.Parameters.Add(IDparam);
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public Contact GetContact(int ID)
        {
            try
            {
                if (contactList == null)
                {
                    contactList = GetContacts();
                }

                foreach (Contact contact in contactList)
                {
                    if (contact.Id == ID)
                    {
                        return contact;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        public List<Contact> GetContacts()
        {
            try
            {
                using (conn)
                {
                    contactList = new List<Contact>();

                    conn = new SqlConnection(connString);

                    string sqlSelectString = "exec SPGetContacts";
                    command = new SqlCommand(sqlSelectString, conn);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contact contact = new Contact();
                        contact.FirstName = reader[0].ToString();
                        contact.LastName = reader[1].ToString();
                        contact.Email = reader[2].ToString();
                        contact.PhoneNumber = reader[3].ToString();
                        contact.AddressLine1 = reader[4].ToString();
                        contact.AddressLine2 = reader[5].ToString();
                        contact.City = reader[6].ToString();
                        contact.PinCode = reader[7].ToString();
                        contact.State = reader[8].ToString();
                        contact.Country = reader[9].ToString();
                        contact.Status =Convert.ToInt32(reader[10].ToString());
                        contactList.Add(contact);
                    }
                    command.Connection.Close();
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                err.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }
        
        public string GetException()
        {
            return err.ErrorMessage.ToString();
        }
    }

}
