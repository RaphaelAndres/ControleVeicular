using System;

namespace ControleVeicular.Domain.Model
{
    public class AdvertisementPhoto
    {
        public Guid Id { get; set; }
        public Guid AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public string PhotoURL { get; set; }
    }
}