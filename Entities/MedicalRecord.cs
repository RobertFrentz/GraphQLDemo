using System.ComponentModel.DataAnnotations;

namespace GettingStarted.Entities;

public class MedicalRecord
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
}