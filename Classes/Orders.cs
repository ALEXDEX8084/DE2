//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int ID_Order { get; set; }
        public Nullable<int> ID_Man { get; set; }
        public Nullable<int> ID_Good { get; set; }
        public Nullable<System.DateTime> DateOrder { get; set; }
    
        public virtual Goods Goods { get; set; }
        public virtual Mans Mans { get; set; }
    }
}
