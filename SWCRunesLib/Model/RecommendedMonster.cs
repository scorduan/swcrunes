using System;
namespace SWCRunesLib
{


    public class RecommendedMonster  {

        public RecommendedMonster(Monster original, Monster updated, Request request)
        {

            Original = original;
            Updated = updated;
            SourceRequest = request;
        }

        public Monster Original
        {
            get;
            set;
        }

        public Monster Updated
        {
            get;
            set;
        }

        public Request SourceRequest
        {
            get;
            set;
        }

        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public int ThirdValue { get; set; }

    }
}

