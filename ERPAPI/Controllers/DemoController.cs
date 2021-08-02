using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        string apiUrl { get; set; } = "http://61.218.5.103/VieshowTesting/api/ticket/verify";

        string json =
            "{\"cinemaId\":\"998\"," +
            "\"transId\":\"31001296\"," +
            "\"count\":\"1\"}";

        [HttpGet]
        public string Get()
        {
            string json =
                "{\"cinemaId\":\"998\"," +
                "\"transId\":\"31001296\"," +
                "\"count\":\"1\"}";
            string demo;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(json);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://61.218.5.103/VieshowTesting/api/ticket/verify");
            request.Method = WebRequestMethods.Http.Post;
            request.Timeout = 5000;
            request.ContentType = "application/json";
            request.ContentLength = buffer.Length;
            request.AutomaticDecompression = DecompressionMethods.Deflate;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                // string json1 = new JsonConvert.SerializeObject(json);
                streamWriter.Write(json);
                streamWriter.Flush();
            }
            //Get the response handle, we have no true response yet!
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                demo = streamReader.ReadToEnd();
                //byte[] temp;

                //temp = System.Text.Encoding.UTF8.GetBytes(streamReader.ReadToEnd());

                //temp = System.Text.Encoding.Convert(System.Text.Encoding.ASCII, System.Text.Encoding.UTF8, temp);

                //string result = System.Text.Encoding.Default.GetString(temp);


                //demo = streamReader.ReadToEnd();
                streamReader.Close();
            }

            return demo;
        }
    }
}
