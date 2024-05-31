using System;
using System.Collections.Generic;

namespace Examen_1er_Parcial.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public int Cedula { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Departamento { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public string? Teléfono { get; set; }

    public string? Celular { get; set; }

    public string? Correo { get; set; }

    public DateTime FechaIngreso { get; set; }

    public string? Profesión { get; set; }

    public string? Puesto { get; set; }

    public string Salario { get; set; } = null!;
}
