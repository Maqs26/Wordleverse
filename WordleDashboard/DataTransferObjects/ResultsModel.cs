
using WordleDashboard.EFModels;
using System.Net.NetworkInformation;
using Results = WordleDashboard.EFModels.Result;


namespace WordleDashboard.DataTransferObjects
{
    
    public class ResultsModel
    {
        public ResultsModel()
        {
            
        }

        public ResultsModel(Results results)
        {
            PlayerId = results.PlayerId;
            AmountOfGuesses = results.AmountOfGuesses?.ToString();
            TimeOfSubmission = results.TimeOfSubmission;
        }

        public ResultsModel(Player player)
        {
            PlayerId = player.Id;
        }

        public int PlayerId { get; set; }
        public string? PlayerName { get; set; }

        public string? AmountOfGuesses { get; set; }

        public DateTime? TimeOfSubmission { get; set; }
        public List<Player> PlayersList{ get; set; }
        public List<ResultsModel> ResultsList { get; set; }


    }
}
