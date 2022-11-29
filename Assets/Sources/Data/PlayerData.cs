using System;

namespace Sources.Data
{
    public class PlayerData
    {
        public int Lives { get; private set; }
        public long StartLifeGenerationTimestamp { get; private set; }

        public PlayerData()
        {
            Lives = ProfileData.MAX_LIVES;
            StartLifeGenerationTimestamp = DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds();
        }

        public void IncreaseLives()
        {
            ++Lives;
            StartLifeGenerationTimestamp = DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds();
        }

        public void ReduceLives()
        {
            --Lives;
            if (Lives == 4)
            {
                StartLifeGenerationTimestamp = DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeMilliseconds();
            }
        }

        public void SetFullLives()
        {
            Lives = ProfileData.MAX_LIVES;
        }
    }
}