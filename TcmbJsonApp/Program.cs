using System.Net;

namespace CurrencyApplicationJson
{
    public class Program
    {
        static void Main(string[] args)
        {


            string json = GetJson();

            SaveJson(json);


        }

        static string GetJson()
        {
            DateTime today = DateTime.Now;
            DateTime lastYear = today.AddYears(-1);
            string formattedDate = lastYear.ToString("dd-MM-yyyy");
            WebRequest request = WebRequest.Create($"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.S.YTL&startDate={formattedDate}&endDate={formattedDate}&type=json&key=N5ZetAfwcG&aggregationTypes=avg&formulas=&frequency=");


            request.GetResponseAsync();


            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            string json = reader.ReadToEnd();
            reader.Close();

            return json;
        }

        static void SaveJson(string json)
        {

            string fileName = "dolar-kuru.json";
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(json);
            writer.Close();
            Console.WriteLine(json);
        }


    }
}