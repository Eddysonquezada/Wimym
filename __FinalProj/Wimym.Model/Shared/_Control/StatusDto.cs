namespace Wimym.Model.Shared._Control
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StatusDto
    {       
        public int StatusId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        public string Table { get; set; }

      
    }
}
