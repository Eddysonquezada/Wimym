namespace Wimym.Model.Shared._Control
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserTypeDto
    {        
        public int UserTypeId { get; set; }
       
        public string Name { get; set; }

        public List<UserDto> ApplicationUsers { get; set; }
    }

    public class UserTypeGetFilter
    {
        public int? UserTypeId { get; set; }       
    }

    public class UserTypeListFilter
    {
        public int? UserTypeId { get; set; }

        public string Name { get; set; }       
    }

    public class UserTypeList
    {
       // public int UserTypeId { get; set; }

        public string Name { get; set; }

        public List<UserDto> Users { get; set; }
    }
}
