using AnyChat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyChat.Data;

class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string connectionString = $@"Server=(localdb)\MSSQLLocalDB;DataBase=AnyChat;";
		optionsBuilder.UseSqlServer(connectionString);
	}

	public DbSet<User> Users { get; set; }
}
