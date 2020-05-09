using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Linq;

namespace eWAN.Core.Infrastructure.OAuth
{
    public class JWTToken
    {
        public JWTHeader header { get; set; }
        public JWTPayload payload { get; set; }

        public string server_secret { get; set; }
        public JWTToken(string server_secret)
        {
            this.server_secret = server_secret;
        }
        public string CreateNewToken(string name, string permission_code)
        {
            this.CreateHeader();
            this.payload = new JWTPayload();
            this.payload.name = name;
            this.payload.permission_code = permission_code;
            this.RenewToken();
            return this.CreateJWTString();
        }
        public void RenewToken()
        {
            DateTime now = DateTime.Now;
            this.payload.expire_date = now.Add(new TimeSpan(0, 30, 0));
        }
        private string CreateJWTString()
        {
            byte[] header_byte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this.header));
            string base64HeaderString = Convert.ToBase64String(header_byte);
            byte[] payload_byte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this.payload));
            string base64PayloadString = Convert.ToBase64String(payload_byte);
            string signature = this.CreateSignature(base64HeaderString, base64PayloadString);
            return base64HeaderString + "." + base64PayloadString + "." + signature;
        }
        public bool DecodeAndVerifyToken(string token)
        {
            string[] split_token = token.Split(".");
            if (this.CreateSignature(split_token[0], split_token[1]) == split_token[2])
            {
                this.header = JsonConvert.DeserializeObject<JWTHeader>(Encoding.UTF8.GetString(Convert.FromBase64String(split_token[0])));
                this.payload = JsonConvert.DeserializeObject<JWTPayload>(Encoding.UTF8.GetString(Convert.FromBase64String(split_token[1])));
                return true;
            }
            return false;
        }
        private void CreateHeader()
        {
            this.header = new JWTHeader();
            this.header.algorithm = "HMAC256";
            this.header.type = "JWT";
        }
        private string CreateSignature(string header, string payload)
        {
            byte[] to_hash = Encoding.UTF8.GetBytes(header + "." + payload);
            string signature = "";
            switch (this.header.algorithm) {
                case "HMAC256":
                        HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(server_secret));
                        signature = Convert.ToBase64String(hmac.ComputeHash(to_hash));
                        break;
            }
            return signature;
        }
    }
}
