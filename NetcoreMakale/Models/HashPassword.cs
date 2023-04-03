using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetcoreMakale.Models
{
    public class HashPassword
    {
        public string Encode(String Password)
        {
            try
            {
                byte[] Encdatabyte = new byte[Password.Length];
                Encdatabyte = System.Text.Encoding.UTF32.GetBytes(Password);
                
                string EncryptedData = Convert.ToBase64String(Encdatabyte);
                return EncryptedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Encode: " + ex.Message);
            }
        }
        public string Decode(String Password)
        {
            try
            {
                var base64Bytes = System.Convert.FromBase64String(Password);
                return System.Text.Encoding.UTF32.GetString(base64Bytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Encode: " + ex.Message);
            }
        }
    }
    
}
