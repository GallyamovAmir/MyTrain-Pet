//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTrain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tickets
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int WagonId { get; set; }
        public int PlaceId { get; set; }
        public int UserId { get; set; }
    
        public virtual Places Places { get; set; }
        public virtual Routes Routes { get; set; }
        public virtual Users Users { get; set; }
        public virtual Wagons Wagons { get; set; }
    }
}