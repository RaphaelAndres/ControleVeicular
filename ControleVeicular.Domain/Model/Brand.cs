using System;

namespace ControleVeicular.Domain.Model
{
    public class Brand
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; }
        public string Pais { get; set; }
    }
}