using GlassCutting.Application.Interfaces;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Services;

public class DatabaseService(IDatabaseRepository databaseRepository) : IDatabaseService
{
    public async Task ClearDatabaseAsync()
    {
        await databaseRepository.ClearDatabaseAsync();
    }

    public async Task ResetDatabaseAsync()
    {
        await databaseRepository.ResetDatabaseAsync();
    }
}
