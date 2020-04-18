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
            string signature = this.CreateSignature(header_byte, payload_byte);
            return base64HeaderString + "." + base64PayloadString + "." + signature;
        }
        public bool DecodeAndVerifyToken(string token)
        {
            string[] split_token = token.Split(".");
            this.header = JsonConvert.DeserializeObject<JWTHeader>(Encoding.UTF8.GetString(Convert.FromBase64String(split_token[0])));
            this.payload = JsonConvert.DeserializeObject<JWTPayload>(Encoding.UTF8.GetString(Convert.FromBase64String(split_token[1])));
            return this.VerifySignature(split_token[2]);
        }
        private bool VerifySignature(string signature)
        {
            string[] verified_token = CreateJWTString().Split(".");
            string verified_signature = verified_token[2];
            return (verified_signature == signature);
        }
        private void CreateHeader()
        {
            this.header = new JWTHeader();
            this.header.algorithm = "HMAC256";
            this.header.type = "JWT";
        }
        private string CreateSignature(byte[] header, byte[] payload)
        {
            string signature = "";
            switch (this.header.algorithm) {
                case "HMAC256":
                        HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(server_secret));
                        signature = Convert.ToBase64String(hmac.ComputeHash(header.Concat(payload).ToArray()));
                        break;
            }
            return signature;
        }
    }
}
