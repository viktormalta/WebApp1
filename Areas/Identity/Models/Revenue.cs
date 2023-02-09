using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp1.Areas.Identity.Models;

public class Revenue
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RevenueId { get; set; }
    public string RevenueName { get; set; }
    public int Hours { get; set; }
    public double HourPrice { get; set; }
}