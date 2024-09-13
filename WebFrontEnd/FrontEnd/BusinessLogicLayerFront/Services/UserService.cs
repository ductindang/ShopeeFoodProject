using BusinessLogicLayerFront.DTOs;
using BusinessLogicLayerFront.ServicesInterface;
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
            var response = await _httpClient.GetAsync($"api/user/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(jsonString);

            return user;
        }

        public async Task<UserDto> GetUserByEmailPassword(string email, string password)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User/EmailPassword?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserDto>(jsonString);

                    if (user == null)
                    {
                        return null; // Trả về null để thông báo cho người dùng
                    }

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
                var response = await _httpClient.GetAsync($"api/User/Email?email={Uri.EscapeDataString(email)}");
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the user by email and password.", ex);
            }

        }

        public async Task<UserDto> InsertUser(UserDto userDto)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/user", content);
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while fetching the user by email and password.", ex);
            }
            
        }

        public async Task<bool> SendVerificationEmail(UserDto userDto)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/User/SendVerificationEmail", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                throw new ApplicationException("An error occurred while sending the verification email.", ex);
            }
        }

        public async Task<bool> VerifyEmail(string token)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User/VerifyEmail?token={Uri.EscapeDataString(token)}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while verifying the email.", ex);
            }
        }


        public async Task<UserDto> ForgotPassword(string email)
        {
            var content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/User/ForgotPassword?email={Uri.EscapeDataString(email)}", content);
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

        public async Task ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(resetPasswordDto), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/User/PostResetPassword", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode} and reason: {response.ReasonPhrase}. Response content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new ApplicationException("An error occured while resetting the password.", ex);
            }
        }


        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            try
            {
                // Chuyển đổi đối tượng userDto thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");

                // Gọi API bằng phương thức PUT
                var response = await _httpClient.PutAsync($"api/user/{userDto.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    // Đọc kết quả trả về từ API
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var updatedUser = JsonConvert.DeserializeObject<UserDto>(jsonString);
                    return updatedUser;
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
                throw new ApplicationException("An error occurred while updating the user.", ex);
            }
        }

    }
}