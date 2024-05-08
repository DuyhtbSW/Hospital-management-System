using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class PatientReport
    {
        public int Id { get; set; }
        public string Diagnose { get; set; }
        public string MedicineName { get; set; }

        // Define foreign key properties
        public string DoctorId { get; set; }
        public string PatientId { get; set; }

        // Navigation properties
        [ForeignKey("DoctorId")]
        public ApplicationUser Doctor { get; set; }

        [ForeignKey("PatientId")]
        public ApplicationUser Patient { get; set; }

        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    }
}
