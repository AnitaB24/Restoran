using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("FastFood")]
    public class FastFood
    {
        [Key]
        [Column("ID")]
        public int ID {get;set;}
          /*this.naziv=naziv;
        this.n=n;
        this.m=m;
        this.kapacitet=kapacitet;
        this.cena=cena;
        this.kontejner =null;
        this.lokacije=[];
        this.racun=[];*/
        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Column("N")]

        public int N { get; set; }
        [Column("M")]
        public int M { get; set; }

        [Column("Kapacitet")]

         public int Kapacitet { get; set; }

          [Column("Cena")]

         public int Cena { get; set; }

         public virtual List<Lokacija> Lokacije {get; set;}
         public virtual List<Obracun> Racuni{get;set;}




    }
}