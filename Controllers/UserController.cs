using Microsoft.AspNetCore.Mvc;
using WebAPIExample.Model;

[ApiController]
[Route("user/")]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    public async Task<object> Register(
        [FromBody]Usuario usuario,
        [FromServices]UserService userService,
        [FromServices]CpfService cpf)
    {
        List<Error> errors = new List<Error>();
        
        if (usuario.Email == null)
            errors.Add(Error.Create("email", "Email é requirido."));
        else
        {
            usuario.Email = usuario.Email.Trim();
            if (usuario.Email == "")
                errors.Add(Error.Create("email", "Email é requirido."));
        }

        if (errors.Count > 0)
        {
            return new {
                Status = "Fail",
                Message = "Existem errors de validação",
                Data = errors
            };
        }

        await userService.Register(usuario);
        return new {
            Status = "Success",
            Message = "Usuário registrado com sucesso",
            Data = usuario.Id
        };
    }
}