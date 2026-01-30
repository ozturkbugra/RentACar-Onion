using System;
using System.Collections.Generic;
using System.Text;

namespace RentACarApp.Domain.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int KM { get; set; }

        // Otomatik veya manuel
        public string Transmission { get; set; }

        // Araba kapasitesi
        public byte Seat { get; set; }

        // Bagaj kapasitesi
        public byte Luggage { get; set; }

        // yakıt tipi
        public string FuelType { get; set; }
        public string BigImageUrl { get; set; }
    }
}
