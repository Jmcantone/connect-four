namespace ConnectionFour.Service.Services.Validator
{
    public interface IValidatorService
    {
        string CheckForWinner(string inputBoard);

        bool CheckGameIsValid(string inputBoard);
    }
}
