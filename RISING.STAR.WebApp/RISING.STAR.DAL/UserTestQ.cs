//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RISING.STAR.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserTestQ
    {
        public System.Guid Id { get; set; }
        public System.Guid ProfessorId { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Didatica { get; set; }
        public Nullable<int> CoerenciaAulaProva { get; set; }
        public Nullable<int> Dominio { get; set; }
        public Nullable<int> Auxilio { get; set; }
    
        public virtual UserTest UserTest { get; set; }
        public virtual UserTestP UserTestP { get; set; }
    }
}
