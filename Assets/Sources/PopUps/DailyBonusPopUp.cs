using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace Sources.PopUps
{
    public class DailyBonusPopUp : PopUpItem
    {
        [SerializeField] private TextMeshProUGUI CoinsText;
        
        private void OnEnable()
        {
            CoinsText.text = CalculateCoins().ToString(CultureInfo.InvariantCulture);
        }

        private decimal CalculateCoins()
        {
            var currentYear = DateTime.UtcNow.ToLocalTime().Date.Year;
            var currentMonth = DateTime.UtcNow.ToLocalTime().Date.Month;
            var currentDayOfYear = DateTime.UtcNow.ToLocalTime().Date.DayOfYear;

            // test
            // var currentYear = 2023;
            // var currentMonth = 5;
            // var currentDayOfYear = 151;

            var is366DayInYear = currentYear % 4 == 0 && 
                                 (currentYear % 100 != 0 || 
                                  (currentYear % 100 == 0 && currentYear % 400 == 0));
            int[] firstDayInSeasons = { 60, 152, 244, 335 };

            if (is366DayInYear)
            {
                for (var i = 0; i < firstDayInSeasons.Length; i++)
                {
                    ++firstDayInSeasons[i];
                }
            }

            var indexFirstDayInSeasons = 3;
            var numberCurrentDayInSeasons = 0;

            switch (currentMonth)
            {
                case 3:
                case 4:
                case 5:
                    indexFirstDayInSeasons = 0;
                    break;
                case 6:
                case 7:
                case 8:
                    indexFirstDayInSeasons = 1;
                    break;
                case 9:
                case 10:
                case 11:
                    indexFirstDayInSeasons = 2;
                    break;
            }

            if (currentDayOfYear >= firstDayInSeasons[0])
            {
                numberCurrentDayInSeasons = currentDayOfYear - firstDayInSeasons[indexFirstDayInSeasons] + 1;
            }
            else
            {
                numberCurrentDayInSeasons = currentDayOfYear + 31;
            }

            if (numberCurrentDayInSeasons == 1 || numberCurrentDayInSeasons == 2)
            {
                return numberCurrentDayInSeasons + 1;
            }

            decimal coinsForBeforeLastDay = 2;
            decimal coinsForLastDay = 3;

            for (var i = 3; i <= numberCurrentDayInSeasons; i++)
            {
                var coinsForLastDayTemp = coinsForLastDay;
                coinsForLastDay = coinsForBeforeLastDay + coinsForLastDay * (decimal)0.6;
                coinsForBeforeLastDay = coinsForLastDayTemp;
            }

            return Math.Round(coinsForLastDay);
        }
    }
}