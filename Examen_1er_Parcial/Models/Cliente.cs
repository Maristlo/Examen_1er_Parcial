using System;
using System.Collections.Generic;

namespace Examen_1er_Parcial.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Compania { get; set; } = null!;

    public string Nota { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
