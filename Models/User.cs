using System.ComponentModel.DataAnnotations;

namespace aspnet_crud_sample.Models {
    public class User {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }
    }
}
