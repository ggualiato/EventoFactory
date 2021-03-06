//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventoFactory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Eventos
    {
        public Eventos()
        {
            this.Feedbacks = new HashSet<Feedbacks>();
        }
    
        public int ID_Evento { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Capacidade { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public int ID_Local { get; set; }
        public int ID_Ingresso { get; set; }
    
        public virtual Ingressos Ingressos { get; set; }
        public virtual Locais Locais { get; set; }
        public virtual ICollection<Feedbacks> Feedbacks { get; set; }
    }
}
