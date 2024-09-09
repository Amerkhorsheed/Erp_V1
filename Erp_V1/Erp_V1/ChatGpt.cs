using DevExpress.XtraEditors;  // Import DevExpress.XtraEditors for DevExpress UI components
using System;  // Import basic system functionalities
using System.Windows.Forms;  // Import Windows Forms for UI elements
using Newtonsoft.Json.Linq;  // Import Newtonsoft.Json.Linq for JSON manipulation (though not used here)
using RestSharp;  // Import RestSharp for HTTP requests (though not used here)
using System.Net.Http;  // Import System.Net.Http for making HTTP requests
using System.Text;  // Import System.Text for encoding strings
using System.Threading.Tasks;  // Import System.Threading.Tasks for asynchronous programming
using System.Threading;  // Import System.Threading for threading tasks (though not used here)
using Newtonsoft.Json;  // Import Newtonsoft.Json for JSON serialization and deserialization

namespace Erp_V1
{
    // Define the ChatGpt class that inherits from DevExpress.XtraEditors.XtraForm
    public partial class ChatGpt : DevExpress.XtraEditors.XtraForm
    {
        // Create a static HttpClient instance for making HTTP requests
        private static readonly HttpClient client = new HttpClient();

        // Define the API key for authenticating requests to the OpenAI API
        private readonly string apiKey = "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";

        // Constructor for initializing the ChatGpt form
        public ChatGpt()
        {
            InitializeComponent();  // Initialize the form components (e.g., buttons, text boxes)
        }

        // Asynchronous method to get a response from ChatGPT API
        private async Task<string> GetChatGptResponseAsync(string prompt)
        {
            // Create an anonymous object to represent the request body for the API call
            var request = new
            {
                model = "gpt-3.5-turbo",  // Specify the model version
                messages = new[]
                {
                    new { role = "user", content = prompt }  // Create a message with the user input
                }
            };

            // Set the authorization header with the API key
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            // Serialize the request object to JSON format and create an HTTP content object
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Send the POST request to the OpenAI API and await the response
            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

            // Check if the response status is successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                var responseString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response to a dynamic object
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);

                // Return the content of the first choice message from the response
                return jsonResponse.choices[0].message.content;
            }
            else
            {
                // Return an error message if the response is not successful
                return "Error: " + response.ReasonPhrase;
            }
        }

        // Event handler for the button click event
        private async void buttonSend_Click(object sender, EventArgs e)
        {
            // Get the user input from the text box
            string userInput = textBoxInput.Text;

            // Call the GetChatGptResponseAsync method and await its result
            string response = await GetChatGptResponseAsync(userInput);

            // Display the response in the output text box
            textBoxOutput.Text = response;
        }
    }
}
