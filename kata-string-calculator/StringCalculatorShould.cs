﻿using Xunit;

namespace kata_string_calculator
{
    public class StringCalculatorShould
    {
        [Fact]
        public void ignore_empty()
        {
            Assert.Equal(new StringCalculator().Add(""), 0);
        }

        [Fact]
        public void give_the_same_number()
        {
            Assert.Equal(new StringCalculator().Add("1"), 1);
            Assert.Equal(new StringCalculator().Add("2"), 2);
        }

        [Fact]
        public void sum_numbers()
        {
            Assert.Equal(new StringCalculator().Add("1,2"), 3);
        }
    }
}