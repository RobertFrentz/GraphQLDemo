using GettingStarted.Context;
using GettingStarted.Mappers;

namespace GettingStarted.Types;

[MutationType]
public static class Mutation
{
    public static async Task<Patient> AddPatient(Patient patient, AppDbContext dbContext)
    {
        var entity = dbContext.Patients.Add(patient.ToEntity());
        var numberOfEntitiesUpdated = await dbContext.SaveChangesAsync();
        Console.WriteLine(numberOfEntitiesUpdated);
        
        return (numberOfEntitiesUpdated > 0 ? entity.Entity.ToDTO() : null) ?? throw new InvalidOperationException();
    }

    public static async Task<MedicalRecord> AddMedicalRecord(MedicalRecord medicalRecord, AppDbContext dbContext)
    {
        var entity = dbContext.MedicalRecords.Add(medicalRecord.ToEntity());
        var numberOfEntitiesUpdated = await dbContext.SaveChangesAsync();
        Console.WriteLine(numberOfEntitiesUpdated);
        
        return (numberOfEntitiesUpdated > 0 ? entity.Entity.ToDTO() : null) ?? throw new InvalidOperationException();
    }
}