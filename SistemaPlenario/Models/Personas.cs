//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaPlenario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Personas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personas()
        {
            this.Telefonos = new HashSet<Telefonos>();
        }
    
        public int PersonaID { get; set; }
        [Required]
        [StringLength(20, MinimumLength =1, ErrorMessage ="El campo {0} debe tener al menos {2} caracter y máximo {1} caracteres")]
        public string Nombre { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d} ", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        [Required]
        //[Display(Name = "Crédito Máximo")]
        //[RegularExpression(@"^\d+\.\d{0,2}$",ErrorMessage ="El número solo acepta hasta dos decimales")]
        //[Range((double)1,double.MaxValue, ErrorMessage ="El número solo acepta hasta un entero de 18 digitos (999.999.999.999.999.999)")]
        public Nullable<decimal> CreditoMaximo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefonos> Telefonos { get; set; }
    }
}
