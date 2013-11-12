using NUnit.Framework;
using RomanNumerals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Correct_value_for_1()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(1);

            Assert.AreEqual("I", actual);
        }

        [Test]
        public void Correct_value_for_5()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(5);

            Assert.AreEqual("V", actual);
        }

        [Test]
        public void Correct_value_for_10()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(10);

            Assert.AreEqual("X", actual);
        }

        [Test]
        public void Correct_value_for_50()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(50);

            Assert.AreEqual("L", actual);
        }

        [Test]
        public void Correct_value_for_100()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(100);

            Assert.AreEqual("C", actual);
        }

        [Test]
        public void Correct_value_for_500()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(500);

            Assert.AreEqual("D", actual);
        }

        [Test]
        public void Correct_value_for_1000()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(1000);

            Assert.AreEqual("M", actual);
        }

        [Test]
        public void Correct_value_for_2()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(2);

            Assert.AreEqual("II", actual);
        }

        [Test]
        public void Correct_value_for_3()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(3);

            Assert.AreEqual("III", actual);
        }

        [Test]
        public void Correct_value_for_4()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(4);

            Assert.AreEqual("IV", actual);
        }

        [Test]
        public void Correct_value_for_6()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(6);

            Assert.AreEqual("VI", actual);
        }
        [Test]
        public void Correct_value_for_9()
        {
            var converter = new Converter();
            var actual = converter.ToRoman(9);

            Assert.AreEqual("IX", actual);
        }

        [Test]
        public void Correct_value_for_11()
        {
            var converter = new Converter();
            var a = converter.ToRoman(11);

            Assert.AreEqual("XI", a);
        }

        [Test]
        public void Correct_value_for_14()
        {
            var converter = new Converter();
            var a = converter.ToRoman(14);

            Assert.AreEqual("XIV", a);
        }

        [Test]
        public void Correct_value_for_19()
        {
            var converter = new Converter();
            var a = converter.ToRoman(19);

            Assert.AreEqual("XIX", a);
        }
    }
}
