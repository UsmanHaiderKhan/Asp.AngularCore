using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.AngularCore.git.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }

    }
}
