//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace EventoFactory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public Usuarios()
        {
            this.Compras = new HashSet<Compras>();
            this.Feedbacks = new HashSet<Feedbacks>();
        }
    
        public int ID_Usuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]     
        public string Nome { get; set; }

        public string Usuario { get; set; }
            
        public string Senha { get; set; }
       
        public string Email { get; set; }

        public string Perfil { get; set; }
    
        public virtual ICollection<Compras> Compras { get; set; }
        public virtual ICollection<Feedbacks> Feedbacks { get; set; }
    }
}
