using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaInserida = Console.ReadLine();
            if (placaInserida == "" || placaInserida.Length < 7 || placaInserida.Length > 7)
            {
                Console.WriteLine("Digite uma placa valida com 7 digitos.");
            }
            else
            {
                veiculos.Add(placaInserida.ToUpper());
                Console.WriteLine("Veiculo cadastrado com sucesso.");
            }
        }

        public void RemoverVeiculo()
        {
            IEnumerable<string> buscaOrdenada = from placas in veiculos orderby placas[..1] ascending select placas;  
            Console.WriteLine("Veiculos estacionados:");
            foreach (string placaConsulta in buscaOrdenada)
            {
                Console.Write(placaConsulta + ", ");

            }
            Console.WriteLine();
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string stringHoras = Console.ReadLine();
                if (int.TryParse(stringHoras, out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas; 
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa.ToUpper()} foi removido, permaneceu durante {horas} horas e o preço total foi de: R$ {valorTotal.ToString("N2")}");
                    Console.WriteLine($"Valor da primeira hora: {this.precoInicial} - Demais horas: {this.precoPorHora}");
                }
                else
                {
                    Console.WriteLine("Caracteres digitados são inválidos, favor tente novamente!");
                }                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                IEnumerable<string> buscaOrdenada = from placas in veiculos  
                            orderby placas[..1] ascending  
                            select placas;
                foreach(string carros in buscaOrdenada)
                {
                    Console.WriteLine(carros);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
