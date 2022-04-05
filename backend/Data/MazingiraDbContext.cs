using Microsoft.EntityFrameworkCore;

namespace MazingiraBora.Data{

public class MazingiraDbContext: DbContext{
 public DbSet <SignUp> SignUpDetails { get; set; }
 public DbSet <Login> LoginDetails {get;set;}
 public DbSet <Nominees> NomineesTable {get;set;}
 public DbSet <Voter>Voters {get;set;}



 protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MazingiraDb;Integrated Security=true");
}
}

 