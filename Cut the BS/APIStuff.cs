using Newtonsoft.Json;
namespace Cut_the_BS.Models
{
    internal class APIStuff
    {
        //static string url = "www.themealdb.com/api/json/v1/1/search.php?s=Arrabiata";
        static string url = "https://randomuser.me/api/?results=5000";

        static public async void LoadData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result; // Make API Call

            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result; // Get the response as a String

            var result = JsonConvert.DeserializeObject(responseBody); // Use NewtonSoft.Json to parse it

            Console.WriteLine(result);
        }
    }

}