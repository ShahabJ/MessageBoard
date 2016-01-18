using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.Service
{
    public class MockMailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            Debug.WriteLine(string.Concat("Mail Subject: ", subject));
            return true;
        }
    }
}
