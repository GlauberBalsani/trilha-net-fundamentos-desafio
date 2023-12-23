using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFundamentos.Domain.Services;

namespace DesafioFundamentos.Domain.Models
{
    public class Carro 
    {
        public string Placa { get; private set; }
        public string Modelo { get; private set; }

        private Carro(string placa, string modelo)
        {
            if (string.IsNullOrEmpty(placa) || string.IsNullOrEmpty(modelo))
            {
                throw new DomainException("Informe todos os campos");
            }
            Placa = placa;
            Modelo = modelo;
        }

        public static Carro GetCarro(string placa, string modelo)
        {
            return new Carro(placa, modelo);
        }

        public override bool Equals(object obj)
        {
            return obj is Carro carro &&
                   Placa == carro.Placa;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Placa);
        }

        public override string ToString()
        {
            return $"{Placa}, {Modelo}";
        }

        
    }
}