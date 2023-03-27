using System.ComponentModel.DataAnnotations;
using WordleDashboard.DataTransferObjects;

namespace WordleDashboard.EFModels
{
    public partial class Result
    {
        int AmtOfGuesses = 0;
        
        public Result()
        {

        }

        public Result(ResultsModel result)
        {
            int.TryParse(result?.AmountOfGuesses, out AmtOfGuesses);
            PlayerId = result!.PlayerId;
            PlayerName = result.PlayerName;
            AmountOfGuesses = AmtOfGuesses;
            TimeOfSubmission = result.TimeOfSubmission;
        }
    }
}
