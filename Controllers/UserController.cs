using Microsoft.AspNetCore.Mvc;
using WebAPIExample.Model;
using System.Security.Cryptography;
using static System.Text.Encoding;
using static System.Convert;

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

        byte[] data = ASCII.GetBytes(usuario.Senha);
        using SHA256 sha = SHA256.Create();
        var hash = sha.ComputeHash(data);
        usuario.Senha = ToBase64String(hash);

        await userService.Register(usuario);
        return new {
            Status = "Success",
            Message = "Usuário registrado com sucesso",
            Data = usuario.Id
        };
    }

    [HttpPost("login")]
    public async Task<object> Login(
        [FromBody]Usuario usuario,
        [FromServices]UserService userService)
    {
        throw new NotImplementedException();
    }
}