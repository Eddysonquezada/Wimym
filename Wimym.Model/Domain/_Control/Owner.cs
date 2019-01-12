namespace Wimym.Model.Domain._Control
{

    using Model.Domain.DbHelper;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Model.Domain._General;

    //Use to be Author
    public class Owner :AuditEntity, ISoftDeleted
    {
       // [Key]
        public int OwnerId { get; set; }

        //[Required(ErrorMessage = "El Campo es requerido")]
        //[MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[Display(Name = "Codigo")]
        public string Code { get; set; }

        //[Required(ErrorMessage = "El Campo es requerido")]
        //[MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[Display(Name = "Nombre")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "El Campo es requerido")]
        //[MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[Display(Name = "Apellido")]
        public string LastName { get; set; }

        //[MaxLength(50, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "Correo")]
        public string Email { get; set; }

        //[MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[Display(Name = "Telefono")]
        public string Tel { get; set; }

        //[Display(Name = "Prefijo de Exp")]
        //[MaxLength(8, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //public string Prefix { get; set; }

        //[Display(Name = "Prefijo de Recibo")]
        //[MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string PrefixFact { get; set; }

        //[Display(Name = "Prefijo de Orden")]
        //[MaxLength(10, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string PrefixOrder { get; set; }

        //[Display(Name = "Prefijo de NCF")]
        //[MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string PrefixNcf { get; set; }

        //[Display(Name = "Prefijo de Factura Final")]
        //[MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string PrefixFinalFact { get; set; }

        //[Display(Name = "Vencimiento NCF")]
        //[MaxLength(25, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string NcfEnds { get; set; }

       // [Display(Name = "Secuencia Inicial NCF")]
        public int SeqNcf { get; set; }

        //[Display(Name = "Secuencia Inicial Factura Final")]
        public int SeqFact { get; set; }            

        [NotMapped]
       // [MaxLength(25, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string Password { get; set; }

        public bool Deleted { get; set; }

        //public  ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public  ICollection<Shop> Shops { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Wallet> Wallets { get; set; }



    }
}
