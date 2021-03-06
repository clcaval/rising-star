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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.InterventionEvents = new HashSet<InterventionEvent>();
            this.PatientsComments = new HashSet<PatientsComment>();
            this.User1 = new HashSet<User>();
            this.Roles = new HashSet<Role>();
        }
    
        public System.Guid Guid { get; set; }
        public bool Active { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateLastModified { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool IsADM { get; set; }
        public string EmailAddress { get; set; }
        public bool ResetPassword { get; set; }
        public Nullable<System.Guid> LastModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterventionEvent> InterventionEvents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientsComment> PatientsComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User1 { get; set; }
        public virtual User User2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
