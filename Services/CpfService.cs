public class CpfService
{
    public CpfService(int seed)
    {
        this.rand = new Random(seed);
    }
    Random rand;

    public bool Validate(string cpf)
    {
        throw new NotImplementedException();
    }

    public string Generate()
    {
        throw new NotImplementedException();
    }

    // detalhes em: https://www.calculadorafacil.com.br/computacao/validar-cpf
    private string getValidationDigits(string cpf9digits)
    {
        int digit0 = 0, digit1 = 0;
        for (int i = 0; i < cpf9digits.Length; i++)
        {
            var digit = cpf9digits[i] - '0';
            digit0 += digit * (i + 1);
            digit1 += digit * i;
        }
        digit0 %= 11;
        digit0 %= 10;
        
        digit1 += 9 * digit0;
        digit1 %= 11;
        digit1 %= 10;

        return digit0.ToString() + digit1.ToString();
    }
}