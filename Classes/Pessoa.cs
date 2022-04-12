using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
    public abstract class Pessoa : iPessoa
    {

        public string? nome { get; set; }

        public Endereco? endereco { get; set; }

        public float rendimento { get; set; }
        

      public abstract float PagarImposto(float rendimento);

        public float PagaImposto(float rendimento)
        {
            throw new NotImplementedException();
        }

        public void VerificarPastaArquivo(string caminho){

            string pasta = caminho.Split("/")[0];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                using (File.Create(caminho)){}
                // File.Create(caminho);
                
            }
        }


    }
}