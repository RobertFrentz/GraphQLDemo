namespace GettingStarted.Types;

public record Patient(Guid? Id, string Name, int Age, List<MedicalRecord>? MedicalRecords);
