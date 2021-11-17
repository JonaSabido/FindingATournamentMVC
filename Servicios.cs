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
    using System.Linq;
    using System.Threading.Tasks;

    public partial class Servicios
    {
        public int idService { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public int Num_Personas { get; set; }
        public bool EquipoEspecial { get; set; }
        [Display(Name = "Descripción del equipo Especial")]
        public string EquipoEspecialDescripction { get; set; }
        public bool PersonasDiscapacitadas { get; set; }
        
        public int ClubId { get; set; }
        
        public int DisciplineId { get; set; }
        [Display(Name ="Club")]
        public virtual Clubes Clubes { get; set; }
        [Display(Name = "Disciplina")]
        public virtual Discipline Discipline { get; set; }
    }
}