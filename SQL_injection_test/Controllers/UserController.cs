using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQL_injection_test.Data;

namespace SQL_injection_test.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string userName)
        {
            var query = $"SELECT * FROM users WHERE user_name = '{userName}'";
            var users = _context.Users.FromSqlRaw(query).ToList();
            return View(users);
        }

        //// Использование хранимых процедур (Stored Procedures)
        //public IActionResult Index(string userName)
        //{
        //    var query = $"CALL get_user_by_user_name('{userName}');";
        //    var users = _context.Users.FromSqlRaw(query).ToList();
        //    return View(users);
        //}        
    }
}