using System;
using System.IO;
using System.Net;
using System.Text;

using System.Text.Json;
using System.Text.RegularExpressions;
namespace ESG
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\ESGData\ESGData.csv");
            


            foreach (var cust in data)

                {
                    //Ignoring first row 
                    if (cust.Contains("CustomerRef,CustomerName,AddressLine1,AddressLine2,Town,County,Country,Postcode"))
                    {
                        continue;
                    }

                    var dataesg = cust.Split(',');

                    // Validating customer ref is not null 
                    if(dataesg[0] == null || dataesg[0].Length < 1 || ! Regex.IsMatch(dataesg[0], @"\d"))
                    {
                        continue;
                    }
                    
                    CustomerDetails customerDetails = new CustomerDetails(int.Parse(dataesg[0]) , dataesg[1] , dataesg[2] ,  dataesg[3] , dataesg[4] ,  dataesg[5] , dataesg[6] , dataesg[7]);
                    
                    // Creating Json 
                    string jsonString = JsonSerializer.Serialize(customerDetails);
           

                //call to REST api
                Boolean resp = restRecordData(jsonString);
                if (!resp)
                {
                    Console.WriteLine("Error in creating record for customer ref " + customerDetails.CustomerRef);
                }
                else
                {
                    Console.WriteLine("\nData recorded for " + customerDetails.CustomerRef);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        public static Boolean restRecordData(String jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:47537/esgcustomer");
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType =   "application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if(response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
               
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    
                    // Log errorText
                    Console.WriteLine("\nApi Response : "  + errorText);
                   
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }
            return false;
        }
    }
}
