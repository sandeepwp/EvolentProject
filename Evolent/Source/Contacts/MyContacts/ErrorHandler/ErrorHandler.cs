using System;
using System.Text;

namespace ErrorHandler
{
    //Class responsible for handling error messages
    public class ErrorHandler
    {
        static StringBuilder errMessage = new StringBuilder();

        //Make class immutable
        static ErrorHandler()
        {
        }

        public string ErrorMessage
        {
            get
            {
                return errMessage.ToString();
            }
            set
            {
                errMessage.AppendLine(value);
            }
        }
    }
}
