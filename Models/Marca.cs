using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Webapi.Models
{
  [Table("Marcas")]
  public class Marca
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [MaxLength(150)]
    [Required]
    public string Nome { get;set; }
    [JsonIgnore]

    public ICollection<Carro> Carros { get;set; }
  }
}