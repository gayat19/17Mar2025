using ClinicApplication.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Misc
{
    public class PatientIDGenerator
    {
        private readonly ClinicContext _context;

        public PatientIDGenerator(ClinicContext context)
        {
            _context = context;
        }
        public async Task<string> GeneratePatientID()
        {
            string PatientId = string.Empty;
            var outputParameter = new SqlParameter
            {
                ParameterName = "@PatientId",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 6,
                Direction = System.Data.ParameterDirection.Output
            };

            _context.Database.ExecuteSqlRaw("exec proc_GeneratePatient @PatientId out", outputParameter);
            PatientId = outputParameter.Value.ToString();
            return PatientId;
        }
    }
}
