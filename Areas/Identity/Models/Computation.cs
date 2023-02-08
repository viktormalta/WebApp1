using System.ComponentModel.DataAnnotations;
using WebApp1.Areas.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Areas.Identity.Models
{
    public class Computation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComputationId {get; set; }

        public string ComputationName { get; set; }

        //Navigation properties
        public IList<Revenue> Revenues {get; set;}
    }
}