using System.ComponentModel.DataAnnotations;

namespace GettingStarted.Entities;

public class Patient
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<MedicalRecord> MedicalRecords { get; set; }
}