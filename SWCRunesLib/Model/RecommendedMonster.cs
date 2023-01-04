using System;
namespace SWCRunesLib
{
    public interface IRecommendedMonster
    {
        public IMonster Original { get; }
        public IMonster Updated { get; }

        public int FirstValue { get; }
        public int SecondValue { get; }
        public int ThirdValue { get; }

    }

    public class RecommendedMonster : IRecommendedMonster
    {

        public RecommendedMonster(IMonster original, IMonster updated)
        {

            Original = original;
            Updated = updated;
        }

        public IMonster Original
        {
            get;
            set;
        }

        public IMonster Updated
        {
            get;
            set;
        }

        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public int ThirdValue { get; set; }

    }
}

