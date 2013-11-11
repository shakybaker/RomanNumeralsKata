using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals.Models
{
    public class Converter
    {
        private List<RomanNumeral> nums = new List<RomanNumeral>();
        private List<RomanNumeral> numsDesc = new List<RomanNumeral>();

        public Converter()
        {
            nums = new List<RomanNumeral>
            {
                new RomanNumeral { Number = 1, Roman = "I" },
                new RomanNumeral { Number = 5, Roman = "V"},
                new RomanNumeral { Number = 10, Roman = "X"},
                new RomanNumeral { Number = 50, Roman = "L"},
                new RomanNumeral { Number = 100, Roman = "C"},
                new RomanNumeral { Number = 500, Roman = "D"},
                new RomanNumeral { Number = 1000, Roman = "M"}

            };
            numsDesc = nums.OrderByDescending(x => x.Number).ToList();
        }

        public string ToRoman(int number)
        {
            //TODO: validate
            var output = string.Empty;

            if (nums.Where(x => x.Number == number).Count() == 1)
                return nums.First(x => x.Number == number).Roman;
            else
            {
                nums.ForEach(map =>
                {
                    if ((number < map.Number) && (string.IsNullOrEmpty(output)))
                    {
                        var i = nums.IndexOf(map);
                        output = ReturnRoman(number, (i > 0) ? nums[i - 1].Roman : "I", 
                            (i > 1) ? nums[i - 2].Roman : nums[i].Roman, 
                            nums[i].Roman);
                    }
                });
            }

            return output;
        }

        private string ReturnRoman(int number, string mid, string inc, string max)
        {
            var retVal = string.Empty;
            var incNumber = nums.First(x => x.Roman == inc).Number;
            var div = number / incNumber;
            if (div == 4)
                return string.Format("{0}{1}", inc, mid);
            else
            {
                var midNum = nums.First(x => x.Roman == mid).Number;
                if (div > midNum)
                {
                    div = div - midNum;
                    retVal += mid;
                }
                for (var i = 1; i <= div; i++)
                    retVal += inc;
            }
            return retVal;
        }
    }
}
