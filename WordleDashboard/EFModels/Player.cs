using System.ComponentModel.DataAnnotations;

namespace WordleDashboard.EFModels
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Round { get; set; }
        public int? TotalRoundWins { get; set; }
        public int? AvgGuessesPerRound { get; set; }
        public int? TotalTies { get; set; }
        public int? TotalRoundTies {get; set;}
        public int? TotalGuesses { get; set; }
        public decimal? AvgTotalGuesses { get; set; }
        public decimal? Winpercentage { get; set; }

        public double OneGuessInRound { get; set; }
        public double TwoGuessesInRound { get; set; }
        public double ThreeGuessesInRound { get; set; }
        public double FourGuessesInRound { get; set; }
        public double FiveGuessesInRound { get; set; }
        public double SixGuessesInRound { get; set; }

        public int? MissesInRound { get; set; }
        public int? MissedEntriesTotal { get; set; }
        public int? MissedEntriesInRound { get; set; }
        public int? AvgMissedEntriesPerRound { get; set; }
        public decimal? RoundWinPercentage { get; set; }
    }
}
