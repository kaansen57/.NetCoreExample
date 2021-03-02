﻿using Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        [Required(ErrorMessage = "Id girilmesi zorunludur !")]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
