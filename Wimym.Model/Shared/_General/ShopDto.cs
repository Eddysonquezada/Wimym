namespace Wimym.Model.Shared._General
{
    using Model.Shared._Control;
    using System;
    using System.Collections.Generic;

    public class ShopDto 
    {       
        public int ShopId { get; set; }       
               
        public string Name { get; set; }
             
        public string Address { get; set; }
              
        public string Email { get; set; }
               
        public string WebAddress { get; set; }
              
        public string Tel { get; set; }
             
        public DateTime? CreationDate { get; set; }

        public bool Deleted { get; set; }
        
        public OwnerDto Owner { get; set; }
        public int OwnerId { get; set; }

        public List<UserDto> Users { get; set; }
    }

    public class ShopGetFilter
    {
        public int? ShopId { get; set; }       
    }

    public class ShopListFilter
    {
        public int? ShopId { get; set; }

        public string Name { get; set; }       

        public string Email { get; set; }       

        public string Tel { get; set; }
               
        public int OwnerId { get; set; }      
    }

    public class ShopList
    {
       // public int ShopId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string WebAddress { get; set; }

        public string Tel { get; set; }

        public DateTime? CreationDate { get; set; }

        public bool Deleted { get; set; }
      
        public string Owner { get; set; }

        public List<UserDto> Users { get; set; }
    }
}
