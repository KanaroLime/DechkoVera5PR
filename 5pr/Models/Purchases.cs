//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _5pr.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchases
    {
        public int Purchases_code { get; set; }
        public int Ingredients_code { get; set; }
        public int Quantity { get; set; }
        public int Supplier_code { get; set; }
        public int Unit_code { get; set; }
    
        public virtual Ingredients Ingredients { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
