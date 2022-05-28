using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniUti.Models.Base
{
    public class EntidadeBase
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
    }
}