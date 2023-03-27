using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;
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
                Result result = new(_Results);

                using (var context = _ContextFactory.CreateDbContext())
                {
                    if (result.Gkey == Guid.Empty || result?.Gkey == null)
                    {
                        result!.Gkey = Guid.NewGuid();
                        await context.Results.AddAsync(result);
                        context.SaveChanges();
                    }
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



    }
}
