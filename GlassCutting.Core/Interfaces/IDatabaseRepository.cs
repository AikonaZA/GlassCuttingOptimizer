namespace GlassCutting.Core.Interfaces;

public interface IDatabaseRepository
{
    Task ClearDatabaseAsync();
    Task ResetDatabaseAsync();
}
