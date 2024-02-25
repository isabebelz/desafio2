namespace ContaBancaria.Servicos
{
    public class Validacao
    {
        public static bool ValidarCPF(string cpf)
        {
            if ((cpf.Length != 11 || !cpf.All(char.IsDigit)) && cpf.Distinct().Count() == 1)
            {
                Console.WriteLine("CPF inválido");
                return false;
            }

            int[] cpfArray = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            int somaDV1 = 0;
            for (int i = 0; i < 9; i++)
            {
                somaDV1 += cpfArray[i] * (10 - i);
            }

            int restoDV1 = somaDV1 % 11;
            int digitoVerificador1 = restoDV1 < 2 ? 0 : 11 - restoDV1;

            int somaDV2 = 0;
            for (int i = 0; i < 10; i++)
            {
                somaDV2 += cpfArray[i] * (11 - i);
            }

            int restoDV2 = somaDV2 % 11;
            int digitoVerificador2 = restoDV2 < 2 ? 0 : 11 - restoDV2;

            if(cpfArray[9] == digitoVerificador1 && cpfArray[10] == digitoVerificador2)
            {
                return true;
            }
            return false;

        }

    }
}