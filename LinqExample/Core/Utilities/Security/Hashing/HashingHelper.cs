using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                /*algoritmanın key değerini kullanıyoruz başka şeylerde kullanabiliriz 
                herhangi bir standart şifreyi çözerken lazım olacağı için bir standart olması gerekli*/

                //bir stringin byte değerini öğrnemk için encoding sınıfını kullanabiliriz.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }      
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
                return true;
        }
    }
}
