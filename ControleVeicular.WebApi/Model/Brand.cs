using System;

namespace ControleVeicular.WebApi.Model
{
    public class Brand
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; }
        public string Pais { get; set; }
    }
}