using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanesTuristicos.Models;

public partial class Turista
{
    public int IdUsuario { get; set; }

    public string? NombreTurista { get; set; }

    public string? Correo { get; set; }

    public int? Cedula { get; set; }

    public string? Direccion { get; set; }

    public int? Telefono { get; set; }

    public string? Clave { get; set; }

    
}
