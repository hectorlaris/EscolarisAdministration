using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace ESC.AdministrationCore.Entities.DbSet
{
    public class User
    {
        [Key]
        [DataMember(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} no debe exceder de {1} caracteres.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El campo {0} no debe exceder de {1} caracteres.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "El campo {0} no debe exceder de {1} caracteres.")]
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        // Constructor por defecto
        public User() { }

        public User(string firstName, string lastName, string userName, string password)
        { 
            // Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
        }
            
    }
}
