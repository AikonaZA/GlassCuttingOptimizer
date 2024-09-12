namespace GlassCutting.Application.Interfaces;

public interface IDatabaseService
{
    Task ClearDatabaseAsync();
    Task ResetDatabaseAsync();
}
