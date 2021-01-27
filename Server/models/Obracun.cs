using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Models
{
    public class Obracun
    {
        
        [Key]
        [Column("ID")]

        public int ID {get;set;}
        
        [Column("UkupnaCena")]
        public int UkupnaCena { get; set; }


        [Column("X")]

        public int X { get; set; }

        [Column("Y")]
        public int Y { get; set; }

        
      //  [JsonIgnore]

        public FastFood FastFood {get; set;}
    }
}