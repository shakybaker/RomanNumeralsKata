﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals.Models
{
    public class Converter
    {
        private List<RomanNumeral> numMaps = new List<RomanNumeral>();
        private List<RomanNumeral> numMapsDesc = new List<RomanNumeral>();

        public Converter()
        {
            numMaps = new List<RomanNumeral>
            {
                new RomanNumeral { Number = 1, Roman = "I", Mid = "V", Increment = "I" },
                new RomanNumeral { Number = 5, Roman = "V", Mid = "V", Increment = "I" },
                new RomanNumeral { Number = 10, Roman = "X", Mid = "V", Increment = "I" },
                new RomanNumeral { Number = 50, Roman = "L", Mid = "C", Increment = "X" },
                new RomanNumeral { Number = 100, Roman = "C", Mid = "C", Increment = "X" },
                new RomanNumeral { Number = 500, Roman = "D", Mid = "C", Increment = "C" },
                new RomanNumeral { Number = 1000, Roman = "M", Mid = "C", Increment = "C" }

            };
            numMapsDesc = numMaps.OrderByDescending(x => x.Number).ToList();
        }

        public string ToRoman(int number)
        {
            //TODO: validate
            var output = string.Empty;

            if (numMaps.Where(x => x.Number == number).Count() == 1)
                return numMaps.First(x => x.Number == number).Roman;
            else
            {
                while (number > 0)
                {
                    var mapFound = false;
                    numMapsDesc.ForEach(mapDesc =>
                    {
                        if (!mapFound)
                        {
                            var dividend = number;
                            var divisor = mapDesc.Number;
                            int remainder;
                            if ((mapDesc.Number != 5) && (mapDesc.Number != 500))
                            {
                                var quotient = Math.DivRem(dividend, divisor, out remainder);
                                if (quotient > 0)
                                {
                                    number = quotient * mapDesc.Number;
                                    if (numMaps.Where(x => x.Number == number).Count() == 1)
                                    {
                                        output += numMaps.First(x => x.Number == number).Roman;
                                        mapFound = true;
                                    }
                                    else
                                    {
                                        numMaps.ForEach(map =>
                                        {
                                            if ((number < map.Number) && (!mapFound))
                                            {
                                                output += ReturnRoman(number, map.Mid, map.Increment, map.Roman);
                                                mapFound = true;
                                            }
                                        });
                                    }
                                    number = remainder;
                                }
                            }
                        }
                    });
                }
            }

            return output;
        }

        private string ReturnRoman(int number, string mid, string inc, string max)
        {
            var retVal = string.Empty;
            var incNumber = numMaps.First(x => x.Roman == inc).Number;
            var div = number / incNumber;
            if (div == 4)
                return string.Format("{0}{1}", inc, mid);
            else if (div == 9)
                return string.Format("{0}{1}", inc, max);
            else
            {
                var midNum = numMaps.First(x => x.Roman == mid).Number;
                if ((div > midNum) && (midNum > 0))
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
