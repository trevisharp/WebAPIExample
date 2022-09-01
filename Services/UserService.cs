using WebAPIExample.Model;

public class UserService
{
    public async Task Register(Usuario usuario)
    {
        using var context = new RedeSocialContext();
        context.Add(usuario);
        await context.SaveChangesAsync();
    }

    public async Task<object> Login(Usuario usuario)
    {
        // implementa eu
        throw new NotImplementedException();
    }
}