using Rovers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rovers.Entity
{
    public class Base :IEntity
    {
        [Key]//Data Anatotation ile tanımladık. primary Key olduğunu gösterir...
        public int ID { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public Nullable<DateTime> UPDATE_DATE { get; set; }
        public DateTime? DELETE_DATE { get; set; }
    }
}
