using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Application.ViewModels
{
    public class EstadoViewModel
    {
        public string UF { get; set; }
        public string Nome { get; set; }

        public static List<EstadoViewModel> ListarEstados()
        {
            return new List<EstadoViewModel>()
            {
            new EstadoViewModel() { Nome = "Acre", UF =  "AC" },
            new EstadoViewModel() { Nome = "Alagoas", UF =  "AL" },
            new EstadoViewModel() { Nome = "Amapá", UF =  "AP" },
            new EstadoViewModel() { Nome = "Amazonas", UF =  "AM" },
            new EstadoViewModel() { Nome = "Bahia", UF =  "BA" },
            new EstadoViewModel() { Nome = "Ceará", UF =  "CE" },
            new EstadoViewModel() { Nome = "Distrito Federal", UF =  "DF" },
            new EstadoViewModel() { Nome = "Espírito Santo", UF =  "ES" },
            new EstadoViewModel() { Nome = "Goiás", UF =  "GO" },
            new EstadoViewModel() { Nome = "Maranhão", UF =  "MA" },
            new EstadoViewModel() { Nome = "Mato Grosso", UF =  "MT" },
            new EstadoViewModel() { Nome = "Mato Grosso do Sul", UF =  "MS" },
            new EstadoViewModel() { Nome = "Minas Gerais", UF =  "MG" },
            new EstadoViewModel() { Nome = "Pará", UF =  "PA" },
            new EstadoViewModel() { Nome = "Paraíba", UF =  "PB" },
            new EstadoViewModel() { Nome = "Paraná", UF =  "PR" },
            new EstadoViewModel() { Nome = "Pernambuco", UF =  "PE" },
            new EstadoViewModel() { Nome = "Piauí", UF =  "PI" },
            new EstadoViewModel() { Nome = "Rio de Janeiro", UF =  "RJ" },
            new EstadoViewModel() { Nome = "Rio Grande do Norte", UF =  "RN" },
            new EstadoViewModel() { Nome = "Rio Grande do Sul", UF =  "RS" },
            new EstadoViewModel() { Nome = "Rondônia", UF =  "RO" },
            new EstadoViewModel() { Nome = "Roraima", UF =  "RR" },
            new EstadoViewModel() { Nome = "Santa Catarina", UF =  "SC" },
            new EstadoViewModel() { Nome = "São Paulo", UF =  "SP" },
            new EstadoViewModel() { Nome = "Sergipe", UF =  "SE" },
            new EstadoViewModel() { Nome = "Tocantins", UF =  "TO"}};
        }
    }
}
