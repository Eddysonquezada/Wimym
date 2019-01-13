using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wymim.Domain
{
    public class Wallet
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
}
