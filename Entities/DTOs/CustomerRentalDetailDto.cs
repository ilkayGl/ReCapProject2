using System;
using Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerRentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
