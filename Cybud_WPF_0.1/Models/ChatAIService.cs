using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cybud_WPF_0._1.Models
{
    public class ChatAIService
    {
        // sk-idHroRBIE_imfWHlp51PseP6R82lUdqAj9ZkDcRm86T3BlbkFJpD5esr1azj4wqWlGZcTwLGHMkQLuiinDEDUqC5iNIA
        // Authorization: Bearer sk-idHroRBIE_imfWHlp51PseP6R82lUdqAj9ZkDcRm86T3BlbkFJpD5esr1azj4wqWlGZcTwLGHMkQLuiinDEDUqC5iNIA
        private readonly string _apiKey = "sk-idHroRBIE_imfWHlp51PseP6R82lUdqAj9ZkDcRm86T3BlbkFJpD5esr1azj4wqWlGZcTwLGHMkQLuiinDEDUqC5iNIA";  // Your API Key

        // Method to send user input and get AI response asynchronously
        public async Task<string> GetAIResponseAsync(string userInput)
        {
            var client = new HttpClient();

            // OpenAI API Endpoint
            string apiUrl = "https://api.openai.com/v1/completions";

            // Request content - depending on the GPT model you want to use
            var requestBody = new
            {
                model = "text-davinci-003",  // GPT Model
                prompt = userInput,          // User's message to the AI
                max_tokens = 150,            // Max tokens in response
                temperature = 0.7            // Creativity of the AI
            };

            // Serialize the request body to JSON
            var jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Add Authorization header
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            // Make the POST request asynchronously
            var response = await client.PostAsync(apiUrl, content);

            // Parse the response
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);

                // Return the generated text from the API response
                return jsonResponse.choices[0].text.ToString();
            }
            else
            {
                // Handle error responses
                return $"Error: {response.StatusCode}";
            }
        }
    }
}
