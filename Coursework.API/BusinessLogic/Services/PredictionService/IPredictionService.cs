namespace BusinessLogic.Services.PredictionService
{
    public interface IPredictionService
    {
        void Train();
        bool Predict(string matchId);
    }
}
