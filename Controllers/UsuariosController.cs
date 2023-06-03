using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Models;
using ProyectoProgra5.Models.Usuarios;

namespace ProyectoProgra5.Controllers
{
	public class UsuariosController : Controller
	{
		private readonly ProyectoProgra5Context _context;

		public UsuariosController(ProyectoProgra5Context context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			List<User> users = _context.Users.Include(x => x.UserxRols)
										     .ThenInclude(x => x.IdRolNavigation).ToList();
			return View(users);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Usuario userModel)
		{
			User user = new User()
			{
				Nombre = userModel.Nombre,
				Contraseña = userModel.Contraseña,
				Usuario = userModel.Username,
			};

            UserxRol newUserxRol = new UserxRol
            {
                IdRol = userModel.rolID
            };

			user.UserxRols.Add(newUserxRol);
			_context.Users.Add(user);
			_context.SaveChanges();

            return RedirectToAction("Index");
		}

        public IActionResult Edit(int id)
        {
			User? user = _context.Users.Include(x => x.UserxRols).FirstOrDefault(x => x.Id == id);
			if (user != null)
			{
				Usuario usuario = new Usuario()
				{
					Nombre = user.Nombre,
					Contraseña = user.Contraseña,
					Username = user.Usuario,
					UserID = user.Id,
					rolID = user.UserxRols.FirstOrDefault().IdRol.Value
				};
                return View(usuario);
            }
            return RedirectToAction("Index");
        }

		[HttpPost]
        public IActionResult Edit(int id, Usuario userModel)
        {
			User? user = _context.Users.Include(x => x.UserxRols).FirstOrDefault(x => x.Id == id);
			if (user != null)
			{
				user.Nombre = userModel.Nombre;
				user.Usuario = userModel.Username;
				user.Contraseña = userModel.Contraseña;
				user.UserxRols.FirstOrDefault().IdRol = userModel.rolID;
				_context.Users.Update(user);
				_context.SaveChanges();

			}
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
		{
			User? user = _context.Users.Include(x => x.UserxRols)
									   .FirstOrDefault(x => x.Id == id);
			if(user != null)
			{
				_context.UserxRols.RemoveRange(user.UserxRols);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
			return RedirectToAction("Index");
		}
	}
}
