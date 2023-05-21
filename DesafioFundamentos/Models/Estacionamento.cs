namespace DesafioFundamentos.Models
{
    using System.Text.RegularExpressions;
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string pattern = @"^[a-zA-Z]{3}-\d{4}$";
            bool controleLoop = false;
            while (controleLoop == false)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:" + "\n" + "(Tecle 5 para cancelar)");
                string placaCarro = Console.ReadLine();
                if (placaCarro != "5")
                {
                    if (Regex.IsMatch(placaCarro, pattern, RegexOptions.IgnoreCase))
                    {
                        veiculos.Add(placaCarro);
                        controleLoop = true;
                        Console.WriteLine("Veículo cadastrado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Formato de placa inválido, favor inserir no formato 'XXX-YYYY'");
                    }
                }
                else
                {
                    controleLoop = true;
                }
            }
        }

        public void RemoverVeiculo()
        {
            bool controleLoop = false;

            while (controleLoop == false)
            {
                Console.WriteLine("Digite a placa do veículo para remover:" + "\n" + "(Tecle 5 para cancelar)");
                string placa = Console.ReadLine();
                if (placa != "5")
                {
                    // Verifica se o veículo está cadastrado
                    if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        int horas = int.Parse(Console.ReadLine());
                        decimal valorTotal = precoInicial + (precoPorHora * horas);
                        veiculos.Remove(placa);
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        controleLoop = true;
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    }
                }
                else
                {
                    controleLoop = true;
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine(veiculos[i]);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
