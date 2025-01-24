using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            var patientsDTO = new List<PatientDTO>();
            var patients = await _databaseContext.Patients.ToListAsync();
            patients.ForEach(p => patientsDTO.Add(new PatientDTO(p))); //converting each Patient to PatientDTO
            return patientsDTO;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<PatientDTO> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.FindAsync(id);
            
            return new PatientDTO(patient);
        }
    }
}
