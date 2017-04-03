using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;//hashSHA512

namespace Homework2
{
    class Member
    {
        public static List<Member> memberData = new List<Member>();
        public static Member signinMember;

        private string _username;
        private string _password;
        private int _seatNumber;
        private int _film;
        
        public Member(string username, string password)
        {
            setUsername(username);
            setPassword(password);
            setSeatNumber(-1);
            setFilm(-1);
        }

        public static string hashSHA512(string password)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            return Convert.ToBase64String(sha512.ComputeHash(Encoding.Default.GetBytes(password)));
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
            this._password = hashSHA512(password);
            //System.Diagnostics.Debug.WriteLine(this._password);
        }
        public int getSeatNumber()
        {
            return this._seatNumber;
        }
        public void setSeatNumber(int seatNumber)
        {
            this._seatNumber = seatNumber;
        }
        public int getFilm()
        {
            return this._film;
        }
        public void setFilm(int film)
        {
            this._film = film;
        }
    }
}
