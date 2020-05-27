using System;

namespace ControleVeicular.WebApi.Model
{
    public class AdvertisementPicture
    {
        public Guid Id { get; set; }
        public Guid AdvertisementId { get; set; }
        public string PictureUrl { get; set; }
    }
}