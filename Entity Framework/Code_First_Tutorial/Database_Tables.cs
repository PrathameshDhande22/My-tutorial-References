using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Tutorial
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public ICollection<Patient> DoctorPatients { get; set; }
    }

    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public ICollection<Doctor> DoctorPatients { get; set; }
    }

    public class Sample
    {
        public int SampleId { get; set; }
        //public string SampleDiv { get; set; }
        public string SampleName { get; set; }
        public Roles Roles { get; set; }
    }

    public enum Roles
    {
        Admin,
        Buyer,
        Seller
    }
}
