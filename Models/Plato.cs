#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CocinerosYPlatos.Models;

public class Plato{

    [Key]
    public int PlatoID {get;set;}

    [Required(ErrorMessage = "Debe ingresar un nombre.")]
    public string Nombre {get;set;}

    [Required(ErrorMessage = "Debe ingresar el nº de calorias.")]
    [Range(0,Int32.MaxValue, ErrorMessage = "Debe ingresar un valor positivo.")]
    public int Calorias {get;set;}

    [Required(ErrorMessage = "Debe seleccionar una opción.")]
    [Range(1, 6, ErrorMessage = "Debe elegir una opción entre 1 y 5.")]
    public int Sabor {get;set;}

    public DateTime FechaCreacion {get;set;} = DateTime.Now;
    public DateTime FechaActualizacion {get;set;} = DateTime.Now;

    [Required(ErrorMessage = "Debe seleccionar un Chef.")]
    public int ChefId {get;set;}

    public Chef? Creador {get;set;}
}