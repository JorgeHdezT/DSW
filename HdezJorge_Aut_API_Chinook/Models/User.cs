using System.Text.Json.Serialization;

namespace APIMusica_HdezJorge.Models
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
