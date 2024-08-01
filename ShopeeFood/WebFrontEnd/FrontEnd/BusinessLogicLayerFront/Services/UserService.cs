using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.Services.Contrast;
using Newtonsoft.Json;
using System.Text;

namespace BusinessLogicLayerFront.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("api/user");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonString);

            return users;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var response = await _httpClient.GetAsync("api/user/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(jsonString);

            return user;
        }

        public async Task<UserDto> GetUserByEmailPassword(string email, string password)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User/GetByEmailPassword?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserDto>(jsonString);
                    return user;
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the user by email and password.", ex);
            }
        }

       

        public async Task<UserDto> GetUserByEmail(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User/GetUserByEmail?email={Uri.EscapeDataString(email)}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserDto>(jsonString);
                    return user;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the user by email and password.", ex);
            }
            
        }

        public async Task<UserDto> InsertUser(UserDto userDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/user/Insertuser", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserDto>(jsonString);
                return user;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
            }
        }

        
    }
}
