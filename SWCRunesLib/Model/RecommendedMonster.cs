using System;
namespace SWCRunesLib
{
    public interface IRecommendedMonster : IMonster
    {

    }

    public class RecommendedMonster : Monster, IRecommendedMonster
	{

		public RecommendedMonster(Monster newMonster, Monster origMonster)
		{
            ATK = newMonster.ATK;
            DEF = newMonster.DEF;
            HP = newMonster.HP;

            SPD = newMonster.SPD;

            CR = newMonster.CR;
            CD = newMonster.CD;

            ACC = newMonster.ACC;
            RES = newMonster.RES;

            PR = newMonster.PR;
            EV = newMonster.EV;

            Runes = newMonster.Runes;

            OriginalMonster = origMonster;
        }

        public Monster OriginalMonster
        {
            get;
            set;
        }

			public int FirstValue {get; set;}
			public int SecondValue { get; set; }
			public int ThirdValue { get; set; }

	}
} 

