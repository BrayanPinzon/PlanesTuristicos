using Microsoft.AspNetCore.Mvc;
using PlanesTuristicos.Models;
using PlanesTuristicos.Recursos;
using PlanesTuristicos.Servicios.Contrato;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using PlanesTuristicos.Data;
using PlanesTuristicos.Servicios.Implementacion;
using System.Numerics;
using Microsoft.Extensions.Logging;

namespace PlanesTuristicos.Controllers


{

    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        private readonly IProveedorService _proveedorService;
        private readonly IPlanesTService _planesTServicio;
        

        public InicioController(IUsuarioService usuarioServicio, IProveedorService proveedorService, IPlanesTService planesTServicio)
        {
            _usuarioServicio = usuarioServicio;
            _proveedorService = proveedorService;
            _planesTServicio = planesTServicio;
            



        }
        public IActionResult Elegir()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Elegir(string tipo)
        {
            if (tipo == "Turista")
            {
                return RedirectToAction("IniciarSesion", "Inicio");

            } else if (tipo == "Proveedor")
            {
                return RedirectToAction("IniciarSesion2", "Inicio");

            }else if(tipo == "Administrador")
            {
                return RedirectToAction("IniciarSesion3", "Inicio");
            }
            else
            {
                return RedirectToAction("ElegirTipo");
            }
        }

        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(Turista modelo)
        {
            modelo.Clave = Utilidades.EncriptarClave(modelo.Clave);
            Turista usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if (usuario_creado.IdUsuario > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el Usuario";

            return View();
        }
        public IActionResult Registrarse2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse2(Proveedor modelo1)
        {
            modelo1.Clave = Utilidades.EncriptarClave(modelo1.Clave);
            Proveedor proveedor_creado = await _proveedorService.SaveProveedor(modelo1);

            if (proveedor_creado.Id_Proveedor > 0)
                return RedirectToAction("IniciarSesion2", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el Usuario";

            return View();
        }
        public IActionResult GuardarPlan()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GuardarPlan(PlanesT modelo2)
        {
            PlanesT planesT_creado = await _planesTServicio.SavePlanesT(modelo2);

            if (planesT_creado.Id_PlanTuristicos > 0)

                ViewData["Mensaje"] = "SE GUARDO EL PLAN TURISTICO";

            return View();
        }
        public IActionResult IniciarSesion()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(String Correo, String Clave, Admin _admin)

        {
            DA_Logica _da_admin = new DA_Logica();
            Turista usuario_encontrado = await _usuarioServicio.GetUsuario(Correo, Utilidades.EncriptarClave(Clave));

            var admin = _da_admin.ValidarAdmin(_admin.Correo, _admin.Clave);
            if (admin != null)
            {
                return RedirectToAction("Index3", "Home3");

            }

            if (usuario_encontrado == null)
            {

                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreTurista)


               };


            {

            }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true

            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index", "Home");

        }
        public IActionResult IniciarSesion2()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion2(String Correo, String Clave, int Rut)

        {

            Proveedor proveedor_encontrado = await _proveedorService.GetProveedor(Correo, Utilidades.EncriptarClave(Clave), Rut);

            if (proveedor_encontrado == null)
            {

                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, proveedor_encontrado.nombreProveedor)


               };


            {

            }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true

            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index2", "Home2");

        }
        public IActionResult IniciarSesion3()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion3(String Correo, String Clave, Admin _admin)

        {
            DA_Logica _da_admin = new DA_Logica();
            Turista usuario_encontrado = await _usuarioServicio.GetUsuario(Correo, Utilidades.EncriptarClave(Clave));

            var admin = _da_admin.ValidarAdmin(_admin.Correo, _admin.Clave);
            if (admin != null)
            {
                return RedirectToAction("Index3", "Home3");

            }

            if (usuario_encontrado == null)
            {

                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreTurista)


               };


            {

            }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true

            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index", "Home");

        }






        public async Task<IActionResult> MostrarPlanes()
        {


            var planesTuristicos = await _planesTServicio.ObtenerPlanesTuristicos();

          
            return View(planesTuristicos);
        }
        public async Task<IActionResult> MostrarTuristas()
        {


            var usuarios = await _usuarioServicio.ObtenerTurista();


            return View(usuarios);
        }
        public async Task<IActionResult> MostrarProveedor()
        {


            var proveedor = await _proveedorService.ObtenerProveedor();


            return View(proveedor);
        }
        public async Task<IActionResult> MirarPlanes()
        {


            var planesT = await _planesTServicio.ObtenerPlanes();


            return View(planesT);
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Elegir", "Inicio");
        }
    } 
}
     
    







