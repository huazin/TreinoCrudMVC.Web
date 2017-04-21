using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinoCrudMVC.Domain;
using TreinoCrudMVC.Web.ViewModel;

namespace TreinoCrudMVC.Web.AutoMapper
{
    public class AutoMapperConfig
    {

        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Genero, GeneroViewModel>();
                x.CreateMap<GeneroViewModel, Genero>();

                x.CreateMap<Editora, EditoraViewModel>();
                x.CreateMap<EditoraViewModel, Editora>();

                x.CreateMap<Livro, LivroViewModel>();
                x.CreateMap<LivroViewModel, Livro>();
            });
        }
    }
}