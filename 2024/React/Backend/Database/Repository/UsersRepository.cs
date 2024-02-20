using Application.Backend.Database.Models;

namespace Application.Backend.Database.Repository;

public class UsersRepository(DataContext dataContext)
{
    public IReadOnlyCollection<User> Get()
    {
        return dataContext.Users.ToList();
    }
}