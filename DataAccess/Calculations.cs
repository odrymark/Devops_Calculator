using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess;

public class Calculations
{
    public Guid id { get; set; }

    [Required]
    public char type { get; set; } = ' ';

    [Required]
    public double result { get; set; } = 0;
    
    [Required]
    public DateTime date { get; set; } = DateTime.Now;
}