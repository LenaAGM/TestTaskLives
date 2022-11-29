using System;
using Sources.Data;

namespace Sources
{
    public sealed class GameModel
    {
        public PlayerData PlayerData;

        public GameModel()
        {
            PlayerData = new PlayerData();
        }

        public string GetTimeToLifeGeneration()
        {
            var leftMilliSeconds = ProfileData.LIFE_GENERATION_TIME_IN_MILLISECONDS -
                              (DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds() -
                               PlayerData.StartLifeGenerationTimestamp) + 1000;

            if (PlayerData.Lives < 5)
            {
                if (leftMilliSeconds < 500)
                {
                    PlayerData.IncreaseLives();
                }

                var leftSeconds = leftMilliSeconds / 1000;
                var minutes = leftSeconds % 3600 / 60;
                var seconds = leftSeconds % 60;
                return (minutes > 0
                    ? (minutes < 10 ? "0" : "") + minutes + ":"
                    : "00:") + (seconds < 10 ? "0" : "") + seconds;
            }

            return "";
        }
    }
}