using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;
using System.Xml.Linq;
using WordleDashboard.DataTransferObjects;
using WordleDashboard.EFContexts;
using WordleDashboard.EFModels;
using static MudBlazor.Colors;

namespace WordleDashboard.Modules
{
   
    public class DataLayer
    {

        IDbContextFactory<WordleDashboardContext> _ContextFactory;

        public DataLayer(IDbContextFactory<WordleDashboardContext> ContextFactory)
        {
            _ContextFactory = ContextFactory;
        }

        public async Task SaveData(ResultsModel _Results)
        {
            try
            {
                Player player = await CalculatePlayerStats(_Results);

                Result result = new(_Results);

                using (var context = _ContextFactory.CreateDbContext())
                {
                    if (result.Gkey == Guid.Empty || result?.Gkey == null)
                    {
                        result!.Gkey = Guid.NewGuid();
                        await context.Results.AddAsync(result);
                    }

                    context.Attach(player);
                    context.Entry(player).State = EntityState.Modified;

                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex?.ToString());
            }
        }


        public async Task<List<DropdownValue>> GetSubmitResultsDropdownValues(int dropdownId = 0)
        {
            WordleDashboardContext context = _ContextFactory.CreateDbContext();
            List<DropdownValue> Values = new();
            try
            {
                return dropdownId != 0 ? await context.DropdownValues.Where(x => x.DropdownId == dropdownId).OrderBy(x => x.Order).ToListAsync()
                                         :
                                         await context.DropdownValues.OrderBy(x => x.Order).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex!?.ToString());
                return null!;
            }
        }

        public async Task<int>GetPlayerIdFromPlayerName(ResultsModel result)
        {
            WordleDashboardContext context = _ContextFactory.CreateDbContext();
            return await context.DropdownValues.Where(x => x.Value == result.PlayerName).Select(y => y.Id).FirstOrDefaultAsync();
        }

        public async Task<Player> CalculatePlayerStats(ResultsModel result)
        {
            WordleDashboardContext context = _ContextFactory.CreateDbContext();
            result.TimeOfSubmission = DateTime.Now;
            result.PlayerId = await GetPlayerIdFromPlayerName(result);

            Player player = await context.Players.Where(x => x.Id == result.PlayerId).FirstOrDefaultAsync() ?? new();

            //Overall games played
            player.OverallGamesPlayed++;

            //Amount of guesses
            int AmtOfGuessesResult = 0;
            int.TryParse(result?.AmountOfGuesses, out AmtOfGuessesResult);
            player.TotalGuesses += AmtOfGuessesResult;
            
            //Average total guesses
            player.AvgTotalGuesses = (decimal?)((player.OneGuessInRound +
                                                 player.TwoGuessesInRound +
                                                 player.ThreeGuessesInRound +
                                                 player.FourGuessesInRound +
                                                 player.FiveGuessesInRound +
                                                 player.SixGuessesInRound +
                                                 player.MissesInRound)
                                               / player.TotalGuesses);
            //Guesses per round increment
            switch (AmtOfGuessesResult)
            {
                case 1:
                    player.OneGuessInRound++;
                    break;
                case 2:
                    player.TwoGuessesInRound++;
                    break;
                case 3:
                    player.ThreeGuessesInRound++;
                    break;
                case 4:
                    player.FourGuessesInRound++;
                    break;
                case 5:
                    player.FiveGuessesInRound++;
                    break;
                case 6:
                    player.SixGuessesInRound++;
                    break;
                default:
                    player.MissesInRound++;
                    player.MissedEntriesTotal++;
                    break;
            }

            return player;


        }



    }
}
