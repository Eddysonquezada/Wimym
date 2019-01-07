using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wimym.Domain.DataEntities.Configuration;

namespace Wimym.Domain.DataEntities.App
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
            public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
            public string LastName { get; set; }
            
        public int UserTypeId { get; set; }
      
        //public int? Level { get; set; }
            
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int StatusId { get; set; }       

        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public DateTime TokenExpires { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }


        [JsonIgnore]
        public virtual UserType UserType { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }       
        //[JsonIgnore]
        //public virtual ICollection<Wallet> Wallets { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tag> Tags { get; set; }
        [JsonIgnore]
        public virtual ICollection<Budget> Budgets { get; set; }
    }
}
