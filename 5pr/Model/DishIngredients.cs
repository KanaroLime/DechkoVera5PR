//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _5pr.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DishIngredients
    {
        public int DishIngredients_code { get; set; }
        public int Ingredients_code { get; set; }
        public int Dishes_code { get; set; }
    
        public virtual Dishes Dishes { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }
}
