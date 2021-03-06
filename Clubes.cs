//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClubTournamentMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Clubes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clubes()
        {
            this.Servicios = new HashSet<Servicios>();
        }
    
        public int idClub { get; set; }
        [Required(ErrorMessage ="Por favor introduzca el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor introduzca la Direccion")]
      
        public string Dirección { get; set; }
        [Required(ErrorMessage = "Por favor introduzca el telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Por favor introduzca la Geoubicacion")]
        public string Geoubicacion { get; set; }
        [Required(ErrorMessage = "Por favor introduzca los dias laborales")]
        public string Dias_Laborales { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicios> Servicios { get; set; }
    }
}
