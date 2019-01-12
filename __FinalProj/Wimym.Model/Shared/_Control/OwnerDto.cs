namespace Wimym.Model.Shared._Control
{
    using Model.Shared._General;
    using System.Collections.Generic;

    public class OwnerDto
    {
        public int OwnerId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        //public string Prefix { get; set; }

        public string PrefixFact { get; set; }

        public string PrefixOrder { get; set; }

        public string PrefixNcf { get; set; }

        public string PrefixFinalFact { get; set; }

        public string NcfEnds { get; set; }

        public int SeqNcf { get; set; }

        public int SeqFact { get; set; }

        public string Password { get; set; }

        public bool Deleted { get; set; }

        //public  ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public List<ShopDto> Shops { get; set; }

        public List<TagDto> Tags { get; set; }

        public List<WalletDto> Wallets { get; set; }



    }

    public class OwnerGetFilter
    {
        public int? OwnerId { get; set; }

        public string Email { get; set; }
    }

    public class OwnerListFilter
    {
        public int? OwnerId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }     

        public string Tel { get; set; }
    }

    public class OwnerList
    {
       // public int OwnerId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        //public string Prefix { get; set; }

        public string PrefixFact { get; set; }

        public string PrefixOrder { get; set; }

        public string PrefixNcf { get; set; }

        public string PrefixFinalFact { get; set; }

        public string NcfEnds { get; set; }

        public int SeqNcf { get; set; }

        public int SeqFact { get; set; }
         
        //public  ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public List<ShopDto> Shops { get; set; }

        public List<TagDto> Tags { get; set; }

        public List<WalletDto> Wallets { get; set; }
    }
}

