using System;
using System.Text;

namespace core
{
    public static class authenticateUser
    {
        public static int checkForUser(string uname,string password)
        {
            if (uname=="Pooja"&&password=="Mohite")
            {
                return 1;
            }
            else
            {
                return 0;
            }
           
        }
    }
}