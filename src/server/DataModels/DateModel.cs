using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.DataModels
{
    public class DateModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateBefore { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateAfter { get; set; }
    }
}