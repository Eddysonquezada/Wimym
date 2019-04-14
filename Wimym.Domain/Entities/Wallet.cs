using System;
using System.Collections.Generic;
using System.Text;

namespace Wimym.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Wymim.Domain.Helper;
    public class Wallet : AuditEntity
    {
        //first lets especify the Identifier, or the primary key, its a good 
        //practice use ID, Id, or the Model name Pluss Id, you can use what 
        //you want, but I prefer Model+Id, if we use ID, word we dont have to 
        //indicate to the Entity than we are using this as identity, but its a 
        //good practice specified it anyway
        //we have to specify the restrictions of each properties, or on the database 
        //it will asume restriction data than will let too much heavy our database
        //we can use customs names for those things, but, i dont recoment it
        [Key]
        public int WalletId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Wallet Name")]
        public string Name { get; set; } //it will be an nvarchar (max), and optional

        [MaxLength(100)]
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool State { get; set; }
        //here we specify the other part of the relation, wich maby objects(Tables)
        //have relation or depends of me? give a name, normal the same than the object
        //but in plural
        public ICollection<Account> Accounts { get; set; }
        //but, in this particular case, its a much part, so, you need a collection
        //or a list of that object table

    }

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
   // using Wimym.Domain.DataEntities.Configuration;

    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Wallet")]
        public string Description { get; set; }

        public int StatusId { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //[Display(Name = "Gastos")]
        //public decimal Amount2 { get; set; }
        //public decimal PreviousAmount { get; set; }

        //[Display(Name = "Usuario")]
        //public int UserId { get; set; }

        public int OwnerId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }

    }
}
