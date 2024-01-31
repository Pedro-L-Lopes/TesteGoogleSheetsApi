using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace DesafioTuntsRocks
{
    // GoogleSheetsService class responsible for initializing and providing access to the Google Sheets API
    class GoogleSheetsService
    {
        // Path to the JSON file containing Google Sheets API credentials
        private static readonly string CredentialsPath = @"C:YOUR PATH\\credentials.json";

        // Scopes required for accessing Google Sheets
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

        // Method to initialize and return a SheetsService instance
        public static SheetsService InitializeSheetsService()
        {
            try
            {
                // Open and read the credentials JSON file
                using (var stream = new FileStream(CredentialsPath, FileMode.Open, FileAccess.Read))
                {
                    // Create Google credentials from the JSON file and specify required scopes
                    var credential = GoogleCredential.FromStream(stream)
                        .CreateScoped(Scopes);

                    // Initialize a new SheetsService with the created credential
                    var service = new SheetsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "DesafioTuntsRocks",
                    });

                    return service;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing Google Sheets service: {ex.Message}");

                return null;
            }
        }
    }
}
