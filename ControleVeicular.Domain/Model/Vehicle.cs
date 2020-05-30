using System;

namespace ControleVeicular.Domain.Model
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public string ModelSpecification { get; set; }
        public int? EngineDisplacement { get; set; }
        public string Bodytype { get; set; }
        public string EngineSpecification { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}