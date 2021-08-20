using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.Models
{
  [Table("Carros")]
  public class Carro
  {
    [Key]
    [Column("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [MaxLength(150)]
    [Required]
    public string Nome { get;set; }

    [Column("modelo", TypeName = "varchar")]
    [MaxLength(50)]
    [Required]    
    public string Modelo { get;set; }

    [Column("marca_id")]
    [Required]
    [ForeignKey("MarcaId")]
    public int MarcaId { get; set; }
    public Marca Marca { get; set; }

    [Column("ano", TypeName = "int")]
    [Required]
    public int Ano { get;set; }
  }
}