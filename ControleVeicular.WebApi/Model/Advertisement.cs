using System;

namespace ControleVeicular.WebApi.Model
{
    public class Advertisement
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public float BuyPrice { get; set; }
        public float SellPrice { get; set; }
        public int FabricationYear { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public DateTime SellDate { get; set; }
        public string DriveTrain { get; set; }
        public string TransmissionType { get; set; }
    }
}