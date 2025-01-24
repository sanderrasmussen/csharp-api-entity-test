using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        private List<Patient> patient;

        public int Id { get; set; }
        public string FullName { get; set; }
        

        public PatientDTO(Patient patient) 
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }

        public PatientDTO(List<Patient> patient)
        {
            this.patient = patient;
        }
    }
    
}
