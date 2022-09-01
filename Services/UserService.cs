using WebAPIExample.Model;

public class UserService
{
    public async Task Register(Usuario usuario)
    {
        using var context = new RedeSocialContext();
        context.Add(usuario);
        await context.SaveChangesAsync();
    }
}