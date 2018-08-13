namespace SportsLiveScoreboard.Services.RandomCodes
{
    public interface IRandomCodeProvider
    {
        string GenerateCode(int length);
        string GenerateCode(int length, char[] characters);
    }
}