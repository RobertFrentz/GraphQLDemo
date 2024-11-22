using System.Text.Json;
using System.Text.Json.Serialization;
using GettingStarted.Context;
using GettingStarted.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GettingStarted.Types;

[QueryType]
public static class Query
{
    /*public static IList<MedicalRecord> MedicalRecords = new List<MedicalRecord>
    {
        new("Diagnosis 1", new Patient("Jon Skeet")),
        new("Diagnosis 2", new Patient("John Doe"))
    };

    public static IList<MedicalRecord> GetMedicalRecords()
        => MedicalRecords;

    public static MedicalRecord? GetMedicalRecord(string id)
        => MedicalRecords.FirstOrDefault(record => record.Title == id);*/

    public static async Task<MedicalRecord?> GetMedicalRecordAsync(Guid id, AppDbContext dbContext)
    {
        var medicalRecord = await dbContext.MedicalRecords
            .Include(m => m.Patient)
            .FirstOrDefaultAsync(m => m.Id == id);
        return medicalRecord.ToDTO();
    }
    
    public static async Task<Patient?> GetPatientAsync(Guid id, AppDbContext dbContext)
    {
        Console.WriteLine(id);
        var patient = await dbContext.Patients
            .Include(p => p.MedicalRecords)
            .FirstOrDefaultAsync(p => p.Id == id);
        return patient.ToDTO();
    }
}