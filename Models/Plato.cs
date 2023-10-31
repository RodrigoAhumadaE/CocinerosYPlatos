#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CocinerosYPlatos.Models;

public class Plato{

    [Key]
    public int PlatoID {get;set;}

    [Required]
    public string Nombre {get;set;}

    [Required]
    public int Calorias {get;set;}

    [Required]
    public int Sabor {get;set;}

    public DateTime FechaCreacion {get;set;} = DateTime.Now;
    public DateTime FechaActualizacion {get;set;} = DateTime.Now;

    public int ChefId {get;set;}

    public Chef? Creador {get;set;}
}