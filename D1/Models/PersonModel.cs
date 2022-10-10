﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D1.Models
{
    public class PersonModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public int Age
        {
            get
            {
               return DateTime.Now.Year - (DateOfBirth?.Year ?? 0);
            }
        }

        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }
    }
}
