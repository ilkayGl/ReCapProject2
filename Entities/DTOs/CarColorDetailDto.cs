using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarColorDetailDto : IDto
    {
        public int ColorId { get; set; }
        public int CarId { get; set; }
        public int RentalId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}