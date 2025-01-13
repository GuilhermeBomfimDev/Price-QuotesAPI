using System.Net;
using System.Globalization;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Conversão Dolár para Real - API");

            double priceDolarToday = SearchPriceDolar();

            Console.Write("\nInforme o valor em Dólar: ");
            double dolar = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double real = dolar * priceDolarToday;

            Console.WriteLine($"\nCotação do dolar hoje: R$ {priceDolarToday.ToString("F2")}");

            Console.WriteLine($"\nValor em Reais: R$ {real.ToString("F2")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }

    public static double SearchPriceDolar()
    {
        string url = "https://economia.awesomeapi.com.br/json/last/USD-BRL";

        using (WebClient client = new WebClient())
        {
            string responseApi = client.DownloadString(url);

            JObject json = JObject.Parse(responseApi);
            string cotacao = json["USDBRL"]["bid"].ToString();

            return double.Parse(cotacao, CultureInfo.InvariantCulture);
        }
    }
}