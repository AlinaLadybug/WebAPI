using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.DataModels
{
    public class DateModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateBefore { get; set; }
        public DateTime? DateAfter { get; set; }
    }
}