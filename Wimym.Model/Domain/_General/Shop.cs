namespace Wimym.Model.Domain
{
    using Wimym.Model.Domain._Control;
    using Wimym.Model.Domain.DbHelper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shop : AuditEntity, ISoftDeleted
    {
        //[Key]
        public int ShopId { get; set; }       

        //[Required(ErrorMessage = "{0} es requerido")]
        //[MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[Display(Name = "Sucursal")]
        public string Name { get; set; }

        //[MaxLength(200, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[Display(Name = "Direccion")]
        //[DataType(DataType.MultilineText)]
        public string Address { get; set; }

        //[MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[EmailAddress(ErrorMessage = "Porfavor, digite un email valido")]
        public string Email { get; set; }

        //[MaxLength(75, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]

        //[RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Entroduzca una pagina web valida")]
        //[Display(Name = "Web")]
        public string WebAddress { get; set; }

        //[MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Telefono")]
        public string Tel { get; set; }

        //[Display(Name = "Fecha de Creacion")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }

        public bool Deleted { get; set; }
        
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
