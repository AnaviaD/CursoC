using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriptoEgipto.Controller
{
    internal class GetTest
    {
        //Variables
        private static readonly HttpClient client = new HttpClient();

        public async Task btnGetData_ClickAsync()
        {
            string apiUrl = "https://api.example.com/data"; // Reemplaza esto con la URL de tu API
            try
            {
                string response = await GetApiDataAsync(apiUrl);
                await Console.Out.WriteLineAsync(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task<string> GetApiDataAsync(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        /*
         * public async Task btnGetData_ClickAsync()
        {
            string apiUrl = "https://api.example.com/data"; // Reemplaza esto con la URL de tu API
            try
            {
                string response = await GetApiDataAsync(apiUrl);
                await Console.Out.WriteLineAsync(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task<string> GetApiDataAsync(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
         */
    }
}
