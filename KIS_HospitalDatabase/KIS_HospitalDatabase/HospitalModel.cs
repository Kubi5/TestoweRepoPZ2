using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KIS_HospitalDatabase.Data.Models
{
    internal class HospitalModel
    {
        public class Patient
        {
            public int PatientID { get; set; }

            //[Unicode(true)]
            [MaxLength(50)]
            public string FirstName { get; set; }
            //[Unicode(true)]
            [MaxLength(50)]
            public string LastName { get; set; }
            //[Unicode(true)]
            [MaxLength(250)]
            public string Address { get; set; }
            //[Unicode(false)]
            [MaxLength(80)]
            public string Email { get; set; }

            public Boolean HasInsurance { get; set; }
        }

        public class Visitation
        {
            public int VisitationID { get; set; }
            public DateTime Date { get; set; }
            //[Unicode(true)]
            [MaxLength(250)]
            public string Comments { get; set; }

            public Patient Patient { get; set; }

        }

        public class Diagnose
        {
            public int DiagnoseID { get; set; }
            //[Unicode(true)]
            [MaxLength(50)]
            public string Name { get; set; }
            //[Unicode(true)]
            [MaxLength(250)]
            public string Comments { get; set; }

            public Patient Patient { get; set; }
        }

        public class Medicament
        {
            public int MedicamentID { get; set; }
            //[Unicode(true)]
            [MaxLength(50)]
            public string Name { get; set; }
        }

        public class PatientMedicament
        {

        }

    }
}
