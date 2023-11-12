using Microsoft.EntityFrameworkCore;
using PlanesTuristicos.Models;
using PlanesTuristicos.Servicios.Contrato;

namespace PlanesTuristicos.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {

        private readonly PlanesTuristicosContext _dbcontext;

        public UsuarioService(PlanesTuristicosContext dbcontext)
        {
            _dbcontext = dbcontext;
            }

        public async Task<Turista> GetUsuario(string correo, string clave)
        {
           Turista usuario_encontrado = await _dbcontext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Turista> SaveUsuario(Turista modelo)
        {
            _dbcontext.Usuarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return modelo;
        }
        public async Task<List<Turista>> ObtenerTurista()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }
    }
}
