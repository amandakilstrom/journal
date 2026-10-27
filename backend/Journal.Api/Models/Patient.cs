using System;

namespace Journal.Api.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Note> Notes { get; set; } = new();
    }
}