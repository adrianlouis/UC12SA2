using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
    public class PessoaFisica : Pessoa , iPessoaFisica
    {

        public string? cpf { get; set;}

        public string? dataNascimento { get; set; }



            public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime parseData;
            if (DateTime.TryParse(dataNasc, out parseData))
            {

                // Console.WriteLine($"{parseData}");
           DateTime dataAtual = DateTime.Today;

           double anos = (dataAtual - parseData).TotalDays / 365;

           if (anos >= 18 && anos < 120){
               return true;
           }
               return false;
        }
        return false;
        }




          public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }else if(rendimento > 1500 && rendimento <= 3500)
            {
                return (rendimento / 100) * 2;
            }else if(rendimento > 3500 && rendimento < 6000)
            {
                return (rendimento / 100) * 3.5f;
            }else
            {
                return (rendimento / 100) * 5;
            }
        }
    }
}