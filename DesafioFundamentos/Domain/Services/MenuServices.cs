using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Models;

namespace DesafioFundamentos.Domain.Services
{
    public class MenuServices
    {
        private static Estacionamento _service;

        public MenuServices(Estacionamento service)
        {
            _service = service;
        }

        public static void Menu()
        {
            decimal precoInicial;
            decimal precoPorHora;

            Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
            precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Agora digite o preço por hora:");
            precoPorHora = Convert.ToDecimal(Console.ReadLine());

            _service = new Estacionamento(precoInicial, precoPorHora);

            ExibirOpcao();
        }

        public static void ExibirOpcao()
        {
            bool exibirMenu = true;

            while (exibirMenu)
            {
                Console.WriteLine(@"Digite a sua opção:
                1 - Cadastrar veículo
                2 - Remover veículo
                3 - Listar veículos
                4 - Encerrar");


                switch (Console.ReadLine())
                {
                    case "1":
                        _service.AdicionarVeiculo();
                        break;

                    case "2":
                        _service.RemoverVeiculo();
                        break;

                    case "3":
                        _service.ListarVeiculos();
                        break;

                    case "4":
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
            Console.WriteLine("O programa se encerrou");



        }
    }




}
