using System;
namespace SWCRunesLib
{


    public class RecommendedMonster : IComparable
    {

        public RecommendedMonster(Monster original, Monster updated, Request request)
        {

            Original = original;
            Updated = updated;
            SourceRequest = request;

            FirstValue = updated.Stats[request.PrimaryAttribute];
            SecondValue = updated.Stats[request.SecondaryAttribute];
            ThirdValue = updated.Stats[request.TertiaryAttribute];
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

        public int FirstValue { get; private set; }
        public int SecondValue { get; private set; }
        public int ThirdValue { get; private set; }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            int result = 0;

            RecommendedMonster? other = (RecommendedMonster)obj;
            float thresholdPercent = .01f;
            int firstThreshAmount = (int)((float)Math.Max(this.FirstValue, other.FirstValue) * thresholdPercent);
            int secondThreshAmount = (int)((float)Math.Max(this.SecondValue, other.SecondValue) * thresholdPercent);
            int thirdThreshAmount = (int)((float)Math.Max(this.ThirdValue, other.ThirdValue) * thresholdPercent);

            if (this.FirstValue - firstThreshAmount > other.FirstValue)
            {
                result = 1;
            }
            else if (other.FirstValue - firstThreshAmount > this.FirstValue)
            {
                result = -1;
            }
            else
            {
                if (this.SecondValue - secondThreshAmount > other.SecondValue)
                {
                    result = 1;
                }
                else if (other.SecondValue - secondThreshAmount > this.SecondValue)
                {
                    result = -1;
                }
                else
                {
                    if (this.ThirdValue - thirdThreshAmount > other.ThirdValue)
                    {
                        result = 1;
                    }
                    else if (other.ThirdValue - thirdThreshAmount > this.ThirdValue)
                    {
                        result = -1;
                    }
                }
            }

            return result * -1;
        }
    }


}

