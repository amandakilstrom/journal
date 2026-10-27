using System;

namespace Journal.Api.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool IsDraft { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}