//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domein
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExtraAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExtraAttribute()
        {
            this.Books = new HashSet<Book>();
            this.BookAddAttributes = new HashSet<BookAddAttribute>();
        }
    
        public int AttributeID { get; set; }
        public string Name { get; set; }
        public int AttributeTypeID { get; set; }
    
        public virtual AttributeType AttributeType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookAddAttribute> BookAddAttributes { get; set; }
    }
}
