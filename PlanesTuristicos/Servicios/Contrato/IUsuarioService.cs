using Microsoft.EntityFrameworkCore;
using PlanesTuristicos.Models;


namespace PlanesTuristicos.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Turista> GetUsuario(string correo, string clave);
        Task<Turista> SaveUsuario(Turista modelo);
        Task<List<Turista>> ObtenerTurista();
    }



}
