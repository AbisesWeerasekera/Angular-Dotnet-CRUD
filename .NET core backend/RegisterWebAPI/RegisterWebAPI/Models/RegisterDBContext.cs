using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterWebAPI.Models
{
  //inherit by ms.entityframework class dbcontext
  public class RegisterDBContext:DbContext
  {

    //calling the constructor of the parent class(DbContext) from the child constructor by using base keyword
    //This is the child constructor
    public RegisterDBContext(DbContextOptions<RegisterDBContext> options) : base(options)
    {
      
    }

    //add the "users" class which we created as a property of RegisterDBContext class
    public DbSet<Users> Users { get; set; }

  }
}
