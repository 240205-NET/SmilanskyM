using Microsoft.EntityFrameworkCore;

namespace ToDoController.API.Models
{
    // Our context is our app's equiv of what's going on in the db
    public class ToDoContext : DbContext
    {
        // our ToDoContext class doesn't have any special construction, but our BASE class needs to receive those options
        // effectively a list of ToDo items - usually you just pluralize (ToDos) whatever it is
        // "every table in our db would end up as a field - one of these DbSets"
        public DbSet<ToDo> ToDos { get; set; } = null!;

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }
   

    }
}
