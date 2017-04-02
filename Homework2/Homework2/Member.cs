using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Member
    {
        public static List<Member> memberData = new List<Member>();

        private string _username;
        private string _password;
        private string _seatNumber;

        
        public Member(string username, string password)
        {
            setUsername(username);
            setPassword(password);
        }

        public string getUsername()
        {
            return this._username;
        }
        public void setUsername(string username)
        {
            this._username = username;
        }
        public string getPassword()
        {
            return this._password;
        }
        public void setPassword(string password)
        {
            this._password = password;
        }
        public string getSeatNumber()
        {
            return this._seatNumber;
        }
        public void setSeatNumber(string seatNumber)
        {
            this._seatNumber = seatNumber;
        }
    }
}
