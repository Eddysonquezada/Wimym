using System.Collections.Generic;

namespace Wymim.Models
{
    public class WalletDto
    {        
        public int WalletId { get; set; }
             
        public string Code { get; set; }
              
        public string Name { get; set; } 
            
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool State { get; set; }

       // public List<AccountDto> Accounts { get; set; }
     
    }
}
