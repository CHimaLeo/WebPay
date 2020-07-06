using RestSharp;
using System;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace WebPay.Models
{
    public class Prueba
    {
        public void Metodo() {
            string jsonString;
            Business business = new Business("SNBX", "01SNBXBRNCH", "SNBXUSR01", "SECRETO");
            Url url = new Url("FACTURA999", 1, "MXN", "W", 0, new DateTime(2020, 01, 01));
            P p = new P(business, url);
            jsonString = JsonSerializer.Serialize(p);
            
            string xml = CovertJsonaXml(jsonString);
            string key = "5DCC67393750523CD165F17E1EFADD21";

            string encriptada = this.encripta(key, xml);
            string body = "<pgs><data0>SNBX</data0><data>" + encriptada + "</data></pgs>";
            
            var client = new RestClient("https://wppsandbox.mit.com.mx");
            var request = new RestRequest("/gen", Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("xml", body);
            
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            
            string desencriptada = this.desencripta(key, content);

            string json = CovertXmlaJSON(desencriptada);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            var link = jsonObj["P_RESPONSE"]["nb_url "];
            Console.WriteLine(link);


        }

        public string encripta(string key, string xml)
        {
            string encryptedString = AESCrypto.encrypt(xml, key);
            return encryptedString;
        }

        public string desencripta(string key, string xml)
        {
            string decryptedString = AESCrypto.decrypt(key, xml);
            return decryptedString;
        }

        public string CovertJsonaXml(string json)
        {
            XNode node = Newtonsoft.Json.JsonConvert.DeserializeXNode(json,"P");
            return node.ToString();
        }

        public string CovertXmlaJSON(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            return json;
        }
    }
}