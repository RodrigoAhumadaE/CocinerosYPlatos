#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CocinerosYPlatos.Models;

public class Chef{

    [Key]
    public int ChefId {get;set;}

    [Required]
    public string Nombre {get;set;}

    [Required]
    public string Apellido {get;set;}

    [Required]
    [CheckFecha]
    public DateTime FechaNacimiento {get;set;}

    public DateTime FechaCreacion {get;set;} = DateTime.Now;
    public DateTime FechaActualizacion {get;set;} = DateTime.Now;

    public List<Plato> ListaPlatos  {get;set;} = new List<Plato>();

    public int CalculaEdad(){
        DateTime ahora = DateTime.Now;
        int edad;
        edad = ahora.Year - FechaNacimiento.Year;
        return edad;
    }
}

public class CheckFechaAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime ahora = DateTime.Now;
        DateTime mayorDeEdad = ahora.AddYears(-18);
        if ((DateTime?)value > ahora){
            return new ValidationResult("La fecha no puede ser despues de la fecha de hoy");         
        }else if ((DateTime?)value > mayorDeEdad){
            return new ValidationResult("Debes ser mayor de edad para registrarte");         
        }else{
            return ValidationResult.Success;
        }
    }
}