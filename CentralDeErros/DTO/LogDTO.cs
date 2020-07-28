using CentralDeErros.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Environment = CentralDeErros.Domain.Enum.Environment;

namespace CentralDeErros.Api.DTO
{
    public class LogDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Frequency { get; set; }
        [Required]
        public int LevelId { get; set; }
        [Required]
        public Environment Environment { get; set; }
        [Required]
        public DateTime Created_at { get; set; }
    }
}
