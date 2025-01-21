using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SQL_injection_test.Data;
using SQL_injection_test.Models;

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

        public IActionResult Index2(string userName)
        {
            var users = new List<User>();
            var connectionString = "Server=localhost;Database=sql_injection;Uid=root;Pwd=;";
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM users WHERE user_name = @userName";
            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@userName", userName);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var user = new User
                {
                    id = reader.GetInt32("id"),
                    user_name = reader.GetString("user_name")
                };
                users.Add(user);
            }
            return View(users);
        }

        public IActionResult Index3(string userName)
        {
            var users = new List<User>();
            var connectionString = "Server=localhost;Database=sql_injection;Uid=root;Pwd=;";
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            using var command = new MySqlCommand("get_user_by_user_name", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("p_user_name", userName);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var user = new User
                {
                    id = reader.GetInt32("id"),
                    user_name = reader.GetString("user_name")
                };
                users.Add(user);
            }
            return View(users);
        }
    }
}