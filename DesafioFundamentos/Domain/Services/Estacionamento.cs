using System.Linq;
using DesafioFundamentos.Domain.Models;
using DesafioFundamentos.Domain.Services;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private readonly ISet<Carro> Carros = new HashSet<Carro>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string? placa = Console.ReadLine();
            Console.WriteLine("Digite o modelo do veículo para estacionar: ");
            string? modelo = Console.ReadLine();
            var carro = Carro.GetCarro(placa, modelo);

            Carros.Add(carro);
        }

        public void ConsultarVeiculo(string placa)
        {
            if (!Carros.Any(c => c.Placa?.ToUpper() == placa.ToUpper()))
            {
                throw new DomainException("Placa não encontrada");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            string? placa;
            placa = Console.ReadLine();

            Carro? carroParaRemover = Carros.FirstOrDefault(v => v.Placa == placa);

            // Verifica se o veículo existe
            if (Carros.Any(c => c.Placa?.ToUpper() == placa?.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


                int horas = 0;
                horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = 0;


                valorTotal = precoInicial + precoPorHora * horas;


                Carros.Remove(carroParaRemover);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (Carros.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var v in Carros)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
