using Cybud_WPF_0._1.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged; // Make sure to include this for Fody

namespace Cybud_WPF_0._1.ViewModels
{
    [AddINotifyPropertyChangedInterface] // Fody will generate INotifyPropertyChanged for this class
    public class ChatAiServiceViewModel
    {
        private readonly ChatAIService _chatAIService;

        // User input property. Fody will automatically handle INotifyPropertyChanged.
        public string UserInput { get; set; }

        // Chat output property. Fody will automatically handle INotifyPropertyChanged.
        public string ChatOutput { get; set; }

        // Constructor initializes ChatAIService
        public ChatAiServiceViewModel()
        {
            _chatAIService = new ChatAIService();
            ChatOutput = string.Empty; // Initialize ChatOutput to prevent null reference errors
        }

        // Async method to send user input to the API and get the AI response
        public async Task SendMessageAsync()
        {
            if (!string.IsNullOrWhiteSpace(UserInput))
            {
                // Append user input to the chat output
                ChatOutput += $"\nUser: {UserInput}";

                try
                {
                    // Get AI response asynchronously
                    var aiResponse = await _chatAIService.GetAIResponseAsync(UserInput);

                    // Append AI response to chat output
                    ChatOutput += $"\nAI: {aiResponse}";
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the API call
                    ChatOutput += $"\nError: {ex.Message}";
                }

                // Clear the user input field after sending the message
                UserInput = string.Empty;
            }
        }
    }

    public class ChatAIService
    {
        private readonly string _apiKey =  ""; // Replace with your actual API key

        // Async method to get the AI response from the API
        public async Task<string> GetAIResponseAsync(string userInput)
        {
            var client = new HttpClient();

            // OpenAI API endpoint
            string apiUrl = "https://api.openai.com/v1/completions";

            // API request body
            var requestBody = new
            {
                model = "gpt-4o-mini",  // GPT model
                prompt = userInput,          // User's message
                max_tokens = 150,            // Limit on response length
                temperature = 0.7            // Creativity level of the AI response
            };

            // Convert request body to JSON
            var jsonBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Add API key to the request header
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {""}");

            // Send POST request to the API and get the response
            var response = await client.PostAsync(apiUrl, content);

            // Check if the response was successful
            if (response.IsSuccessStatusCode)
            {
                // Read response content as string
                var responseString = await response.Content.ReadAsStringAsync();

                // Parse the JSON response
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);

                // Return the AI's generated response
                return jsonResponse.choices[0].text.ToString();
            }
            else
            {
                // Return an error message if the API call fails
                return $"Error: {response.StatusCode}";
            }
        }
    }
}
