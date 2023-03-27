using System.ComponentModel.DataAnnotations;

namespace WordleDashboard.EFModels
{
    public class DropdownValue
    {
        [Key]
        public int Id { get; set; }
        public int DropdownId { get; set; }
        public string DropdownName { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
    }
}
