# FormularioMVC

<img width="2550" height="1079" alt="image" src="https://github.com/user-attachments/assets/64e7737a-6f95-422b-9458-4d8ee17d1f85" />

<img width="2542" height="1079" alt="image" src="https://github.com/user-attachments/assets/698de27f-2fe4-44fc-8ffa-d01c4275e232" />

¡Perfecto! Te guiaré paso a paso para crear una aplicación MVC en Visual Studio 2022 con un formulario simple, 
por ejemplo, un formulario de registro de usuario.

✅ Paso 1: Crear el proyecto

Abre Visual Studio 2022.

Selecciona "Crear un nuevo proyecto".

Busca y selecciona "ASP.NET Core Web App (Model-View-Controller)".

Haz clic en "Siguiente".

Ponle un nombre al proyecto, por ejemplo: FormularioMVC.

Elige una ubicación y haz clic en "Siguiente".

En "Framework", selecciona .NET 6.0 (o superior).

Asegúrate de que Authentication Type esté en "None" y Enable Docker esté desactivado.

Haz clic en "Crear".

✅ Paso 2: Crear el Modelo

Vamos a crear una clase Usuario.

En el Explorador de soluciones, haz clic derecho en la carpeta Models.

Selecciona Agregar > Clase... y nómbrala Usuario.cs.

using System.ComponentModel.DataAnnotations;

namespace FormularioMVC.Models
{
    public class Usuario
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}

✅ Paso 3: Crear el Controlador

Haz clic derecho en la carpeta Controllers.

Elige Agregar > Controlador...

Selecciona MVC Controller - Empty y haz clic en Agregar.

Nómbralo UsuarioController.cs.

using Microsoft.AspNetCore.Mvc;
using FormularioMVC.Models;

namespace FormularioMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes guardar en una base de datos o procesar la información
                ViewBag.Mensaje = "Usuario registrado correctamente.";
                return View("Resultado", usuario);
            }
            return View(usuario);
        }
    }
}

✅ Paso 4: Crear la Vista del Formulario

Haz clic derecho sobre la carpeta Views, luego en Usuario (créala si no existe).

Agrega una nueva vista llamada Crear.cshtml.

@model FormularioMVC.Models.Usuario

@{
    ViewData["Title"] = "Formulario de Usuario";
}

<h2>@ViewData["Title"]</h2>

<form asp-action="Crear" method="post">
    <div class="form-group">
        <label asp-for="Nombre"></label>
        <input asp-for="Nombre" class="form-control" />
        <span asp-validation-for="Nombre" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Correo"></label>
        <input asp-for="Correo" class="form-control" />
        <span asp-validation-for="Correo" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Contraseña"></label>
        <input asp-for="Contraseña" class="form-control" />
        <span asp-validation-for="Contraseña" class="text-danger"></span>
    </div>
    <button type="submit" class="btn btn-primary mt-2">Registrar</button>
</form>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}

✅ Paso 5: Crear la Vista de Resultado

Agrega una nueva vista llamada Resultado.cshtml dentro de Views/Usuario.

@model FormularioMVC.Models.Usuario

@{
    ViewData["Title"] = "Resultado del Registro";
}

<h2>@ViewData["Title"]</h2>

<p><strong>Nombre:</strong> @Model.Nombre</p>
<p><strong>Correo:</strong> @Model.Correo</p>
<p><strong>Mensaje:</strong> @ViewBag.Mensaje</p>

✅ Paso 6: Ejecutar la Aplicación

Ve al archivo Startup.cs o Program.cs (dependiendo de tu versión).

Asegúrate de que el controlador de inicio sea Usuario.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Crear}/{id?}");


Presiona Ctrl + F5 o haz clic en Iniciar para ejecutar.
