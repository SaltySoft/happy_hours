//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HhBackend.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_User
    {
        public T_User()
        {
            this.T_Cocktail = new HashSet<T_Cocktail>();
            this.T_Favorite = new HashSet<T_Favorite>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int admin { get; set; }
    
        public virtual ICollection<T_Cocktail> T_Cocktail { get; set; }
        public virtual ICollection<T_Favorite> T_Favorite { get; set; }
    }
}
