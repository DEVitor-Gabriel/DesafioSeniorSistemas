using System.Text.RegularExpressions;

namespace DesafioSeniorSistemas.Domain.Pessoa.ValueObject
{
    public class CPF
    {
        public readonly long Raiz;
        public readonly int DigitoVerificador;
        public string Numero => $"{Raiz:D9}{DigitoVerificador:D2}";

        public CPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("CPF não pode ser nulo ou vazio");

            if (!Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") && !Regex.IsMatch(cpf, @"^\d{11}$"))
                throw new ArgumentException("CPF deve estar no formato 999.999.999-99 ou 99999999999");

            string cpfNumeros = cpf.Replace(".", "").Replace("-", "");

            Raiz = long.Parse(cpfNumeros[..9]);
            DigitoVerificador = int.Parse(cpfNumeros.Substring(9, 2));
            
        }
    }
}