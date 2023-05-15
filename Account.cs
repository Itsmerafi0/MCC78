

using System.ComponentModel;

namespace BasicConnection
{
    public class Account
    {
        public string id {get;set;}
        public string password { get;set;}
        public bool is_deleted { get;set;}
        public char otp {get;set;}
        public bool is_used { get;set;}
        public DateTime expired_time { get;set;}

    }

}
