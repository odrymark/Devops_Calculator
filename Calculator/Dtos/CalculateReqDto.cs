using System.ComponentModel.DataAnnotations;

namespace Calculator1.Dtos;

public class CalculateReqDto
{
    [Required]
    public int a { get; set; }
    
    [Required]
    public int b { get; set; }
}