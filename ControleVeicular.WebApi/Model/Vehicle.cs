using System;

namespace ControleVeicular.WebApi.Model
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; }
        public string ModelSpecification { get; set; }
        public int EngineDisplacement { get; set; }
        public string Bodytype { get; set; }
        public string EngineSpecification { get; set; }
    }
}