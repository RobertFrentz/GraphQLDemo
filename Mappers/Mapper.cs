using GettingStarted.Entities;

namespace GettingStarted.Mappers;

public static class Mapper
{
    public static MedicalRecord ToEntity(this Types.MedicalRecord medicalRecord) =>
        new()
        {
            Id = Guid.NewGuid(),
            Patient = new()
            {
                Id = Guid.NewGuid(),
                Age = medicalRecord.Patient.Age,
                Name = medicalRecord.Patient.Name,
            },
            Title = medicalRecord.Title
        };

    public static Types.MedicalRecord ToDTO(this MedicalRecord? medicalRecord) =>
        new(
            medicalRecord.Id,
            medicalRecord.Title, 
            new Types.Patient(medicalRecord.Patient.Id, 
                medicalRecord.Patient.Name, 
                medicalRecord.Patient.Age, 
                medicalRecord.Patient.MedicalRecords.Select(m => new Types.MedicalRecord(m.Id, m.Title, null)).ToList()));
    
    
    public static Patient ToEntity(this Types.Patient patient) =>
        new()
        {
            Id = Guid.NewGuid(),
            Name = patient.Name,
            Age = patient.Age,
        };

    public static Types.Patient ToDTO(this Patient? patient) =>
        new(patient.Id, 
            patient.Name, 
            patient.Age, 
            patient.MedicalRecords.Select(m => new Types.MedicalRecord(m.Id, m.Title, null)).ToList());

}