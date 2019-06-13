using System;
using System.ComponentModel.DataAnnotations;

namespace HomeWork
{
    public partial class Realtor
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Division { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
    }
}
