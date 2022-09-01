using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("cep/")]
public class CEPController : ControllerBase
{
    [HttpGet("query/{cep}")]
    public async Task<object> QueryCEP(
        [FromServices]CEPService cepService,
        string cep)
    {
        try
        {
            cep = cep
                .Replace(".", "")
                .Replace("-", "");
            
            if (!int.TryParse(cep, out _))
            {
                return new {
                    Status = "Fail",
                    Message = "Invalid data."
                };
            }

            if (cep.Length != 8)
            {
                return new {
                    Status = "Fail",
                    Message = "Invalid data."
                };
            }

            var cepData = await cepService.RequestCEP(cep);
            
            return new {
                Status = "Success",
                Message = "CEP encontrado com sucesso.",
                Data = cepData
            };
        }
        catch (Exception ex)
        {
            return new {
                Status = "Fail",
                Message = ex.Message
            };
        }
    }
}