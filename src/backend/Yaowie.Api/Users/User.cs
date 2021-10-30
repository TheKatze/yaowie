using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yaowie.Api.Users
{
    public class User
    {

        private User(string name, byte[] publicKey)
        {
            Name = name;
            PublicKey = publicKey;
        }

        public string Name { get ; private set; }
        public byte[] PublicKey { get; private set; }

        public static User Create(string name, byte[] publicKey)
        {
            return new User(name, publicKey);
        }
    }
}
