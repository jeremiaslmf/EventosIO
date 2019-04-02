using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public SelectList Categorias()
        {
            return new SelectList(ListarCategorias(), "Id", "Nome");
        }

        public List<CategoriaViewModel> ListarCategorias()
        {
            var categorias = new List<CategoriaViewModel>()
            {
                new CategoriaViewModel() { Id = new Guid("e892add4-f221-40f5-86d7-1fe17893cd8f"), Nome = "Congresso" },
                new CategoriaViewModel() { Id = new Guid("ce990484-0e37-4716-93a5-1eb0b8834c54"), Nome = "Meetup" },
                new CategoriaViewModel() { Id = new Guid("43837448-f57f-4e53-b3a8-f3524cc1ad17"), Nome = "Workshop" },
            };
            return categorias;
        }
    }
}
