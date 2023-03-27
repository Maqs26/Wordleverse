using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WordleDashboard.EFModels
{
    public partial class Result
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Guid Gkey { get; set; }
        public string? PlayerName { get; set; }
        [Required]
        public int? AmountOfGuesses { get; set; }
        public DateTime? TimeOfSubmission { get; set; }

    }
}
