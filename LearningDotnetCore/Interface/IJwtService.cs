namespace LearningDotnetCore.Interface
{
    public interface IJwtService
    {

        string GenerateToken(string Username);
    }
}
