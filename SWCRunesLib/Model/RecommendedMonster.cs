using System;
namespace SWCRunesLib
{
	public class RecommendedMonster : Monster
	{

		public RecommendedMonster(Monster m)
		{
            ATK = m.ATK;
            DEF = m.DEF;
            HP = m.HP;

            SPD = m.SPD;

            CR = m.CR;
            CD = m.CD;

            ACC = m.ACC;
            RES = m.RES;

            PR = m.PR;
            EV = m.EV;

            Runes = m.Runes;

        }

			public int FirstValue {get; set;}
			public int SecondValue { get; set; }
			public int ThirdValue { get; set; }

	}
} 

