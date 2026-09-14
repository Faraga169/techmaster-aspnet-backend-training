using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace TrainingCenter.DAL.presistent.Models
{
    public class Student:BaseEntity<int>
    {
        public string FullName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        public bool IsActive{ get; set; }
    }
}
