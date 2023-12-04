using System.Text.Json.Serialization;

namespace HernandezJorge_API_Ej2.Models
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
    }
}
