using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio2021.Models
{
    public class QueueMessage
    {
        private string strFullname = string.Empty;
        public string Fullname
        {
            get { return strFullname; }
            set { strFullname = value; }
        }

        private string strEmail = string.Empty;
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        private string strMessage = string.Empty;
        public string Message
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        private string strPhoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return strPhoneNumber; }
            set { strPhoneNumber = value; }
        }

        private string strCompany = string.Empty;
        public string Company
        {
            get { return strCompany; }
            set { strCompany = value; }
        }

        public string MessageJson()
        {
            string result = @$"Fullname: {Fullname}
Company: {Company}
Email: {Email}
Phone: {PhoneNumber}
Message: {Message}";

            return result;
        }
    }
}
