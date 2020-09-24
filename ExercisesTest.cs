using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace entra21_tests
{
    public class ExercisesTest
    {
        [Fact]
        public void should_return_an_array_from_1_to_10()
        {
            // BDD - Behavior Driven Design
            // Dado, Quando, Deve

            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1,
            // então a aplicação deverá retornar todos os número de 1 a 10

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            var result = exercises.Exercise1A();

            // Deve / Asserções
            var expectedOutput = new int[10]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], result[i]);
            }
        }


        [Fact]
        public void should_return_an_array_from_10_to_1()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1b,
            // então a aplicação deverá retornar todos os números de 1 a 10 de forma decrescente

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] returnedValues = exercises.Exercise1B();

            // Deve / Asserções
            var expectedOutput = new int[10]
            {
                10,9,8,7,6,5,4,3,2,1
            };

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], returnedValues[i]);
            }
        }
        

        [Fact]
        public void should_return_an_array_from_1_to_10_but_only_even()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1c,
            // então a aplicação deverá retornar os números de 1 a 10, mas somente os pares

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] returnedValues = exercises.Exercise1C();

            // Deve / Asserções
            var expectedOutput = new int[5]
            {
                2,4,6,8,10
            };

            Assert.Equal(5, returnedValues.Length);

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], returnedValues[i]);
            }
        }


        [Fact]
        public void should_return_the_sum_from_the_numbers_1_to_100()
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int returnedSum = exercises.Exercise2();

            // Deve / Asserções
            Assert.Equal(5050,returnedSum);
        }


        [Fact]
        public void should_return_an_array_containing_all_odd_numbers_from_1_to_200()
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] returnedValues = exercises.Exercise3();

            // Deve / Asserções
            var expectedOutput = new int[100]
            {
                1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55,57,59,61,63,65,67,69,71,73,75,77,79,81,83,85,87,89,91,93,95,97,99,101,103,105,107,109,111,113,115,117,119,121,123,125,127,129,131,133,135,137,139,141,143,145,147,149,151,153,155,157,159,161,163,165,167,169,171,173,175,177,179,181,183,185,187,189,191,193,195,197,199
            };

            Assert.Equal(100, returnedValues.Length);

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], returnedValues[i]);
            }
        }


        [Theory]
        [InlineData(new int[4]{1, 2, 3, 4}, 2.5)]
        [InlineData(new int[6]{7, 9, 8, 10, 11, 12}, 9.5)]
        [InlineData(new int[5]{12, 15, 13, 14, 11}, 13)]
        public void should_return_the_average_number(int[] ages, double expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            double returnedValue = exercises.Exercise4(ages.ToList());

            // Deve / Asserções
            Assert.Equal(expected, returnedValue);
        }


        [Theory]
        [InlineData(new int[5]{25, 40, 30, 32, 50}, 60)]
        [InlineData(new int[5]{18, 20, 19, 55, 30}, 80)]
        [InlineData(new int[5]{27, 33, 22, 27, 19}, 100)]
        [InlineData(new int[5]{84, 49, 72, 60, 100}, 0)]
        public void should_return_the_percentage_of_women_between_18_and_35(int[] ages, double expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            double returnedValue = exercises.Exercise5(ages.ToList());

            // Deve / Asserções
            Assert.Equal(expected, returnedValue);
        }


         // Pular o 6 por enquanto
        [Theory]
        [InlineData(5, 10, 8, 7304)]
        [InlineData(1, 5, 20, 1840)]
        public void should_return_the_value_spent_on_cigarettes(double smokingYears, double cigarretesPerDay, double cigarretesPrice, double expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            double returnedValue = exercises.Exercise7(smokingYears, cigarretesPerDay, cigarretesPrice);

            // Deve / Asserções
            Assert.Equal(expected,returnedValue);
        }


        [Theory]
        [InlineData(5, 0, "ERRO. Divisão por zero.")]
        [InlineData(25, 5, "X é múltiplo de Y.")]
        [InlineData(13, 7, "X não é múltiplo de Y.")]
        public void should_return_a_message_about_the_result_of_a_division(int x, int y, string expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            string returnedValue = exercises.Exercise8(x, y);

            // Deve / Asserções
            Assert.Equal(expected, returnedValue);
        }


        [Theory]
        [InlineData(125, 72, 34, "Primeiro número é maior que soma dos outros dois.")]
        [InlineData(-25, 19, 0, "Primeiro número não é maior que soma dos outros dois.")]
        [InlineData(-10, -70, -20, "Primeiro número é maior que soma dos outros dois.")]
        [InlineData(64, 82, 55, "Primeiro número não é maior que soma dos outros dois.")]

        public void should_return_if_a_number_is_bigger_than_the_sum_of_the_other_two(int firstNumber, int secondNumber, int thirdNumber, string expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            string returnedValue = exercises.Exercise9(firstNumber, secondNumber, thirdNumber);

            // Deve / Asserções
            Assert.Equal(expected, returnedValue);
        }


        [Theory]
        [InlineData(72, 23, "A > B.")]
        [InlineData(-3, 17, "B > A.")]
        [InlineData(15, 15, "A = B.")]
        public void should_return_A_is_bigger_than_B_when_passed_72_and_23(int varA, int varB, string expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            string returnedValue = exercises.Exercise10(varA, varB);

            // Deve / Asserções
            Assert.Equal(expected, returnedValue);
        }


        [Theory]
        [InlineData(100, 4, "Divisão = 25")]
        [InlineData(17, 0, "DIVISÃO POR ZERO!")]
        [InlineData(15, -5, "Divisão = -3")]
        [InlineData(27, 4, "Divisão = 6,75")]
        public void should_return_the_result_of_a_division(int firstNumber, int secondNumber, string expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            string returnedValue = exercises.Exercise11(firstNumber, secondNumber);

            // Deve / Asserções
            Assert.Equal(expected,returnedValue);
        }


        [Theory]
        [InlineData(new int[4]{8, 4, 11, 7}, 12, 18)]
        [InlineData(new int[4]{-5, 0, 12, 8}, 20, -5)]
        [InlineData(new int[4]{7, 5, 31, 29}, 0, 72)]
        [InlineData(new int[4]{6, 8, 16, -22}, 8, 0)]
        [InlineData(new int[4]{0, 0, 0, 0}, 0, 0)]
        public void should_return_the_sum_of_odd_and_even_numbers(int[] numbers, int sumEvenNumbers, int sumOddNumbers)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            var returnedValue = exercises.Exercise12(numbers.ToList());

            // Deve / Asserções
            Assert.Equal((sumEvenNumbers, sumOddNumbers), returnedValue);
        }


        [Theory]
        [InlineData(new double[10]{10, 5, 9, 13, 7, 19, 34, 52, 57, 25}, 57)]
        [InlineData(new double[10]{9, 112, 78, -500, -25, 780, 432, 125478936, 974, 37}, 125478936)]
        [InlineData(new double[10]{-700, -45, -300, -78, -92, -15, -46, -134, -800, -20}, -15)]
        public void should_return_the_biggest_among_10_numbers(double[] numbers, double greatestNumber)
        {           
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            var returnedValue = exercises.Exercise13(numbers.ToList());

            // Deve / Asserções
            Assert.Equal(greatestNumber, returnedValue);
        }


        [Theory]
        [InlineData(new double[3]{1, 5, 7}, new double[3]{1, 5, 7})]
        [InlineData(new double[3]{0, 17, 5}, new double[3]{0, 5, 17})]
        [InlineData(new double[3]{15, -3, 35}, new double[3]{-3, 15, 35})]
        [InlineData(new double[3]{5, 12, 0}, new double[3]{0, 5, 12})]
        [InlineData(new double[3]{33, -2, 1}, new double[3]{-2, 1, 33})]
        [InlineData(new double[3]{50, 35, 20}, new double[3]{20, 35, 50})]
        public void should_return_ordered_numbers(double[] numbers, double[] orderedNumbers) 
        {
            //Dado / Setup            
            var exercises = new Exercises();

            // Quando / Ação
            double[] result = exercises.Exercise14(numbers);

            //Deve / Asserções
            Assert.Equal (orderedNumbers, result);
        }


        [Theory]
        [InlineData(new double[2]{3,5}, 1, 1)]
        [InlineData(new double[6]{13, 0, 75, 33, 27, 20}, 4, 3)]
        [InlineData(new double[7]{-5, 0, 7, 9, 22, 45, 60}, 4, 4)]
        public void should_return_the_amount_of_numbers_multiple_of_3_and_5(double[] numbers, int counter3, int counter5)
        {
            var exercises = new Exercises();

            // Quando / Ação
            var result = exercises.Exercise15(numbers.ToList());

            //Deve / Asserções
            Assert.Equal ((counter3, counter5), result);
        }


        [Theory]
        [InlineData(-700, "ERRO. O salário não pode ser um valor negativo.")]
        [InlineData(500, "Salário = R$ 500,00. ISENTO.")]
        [InlineData(1200, "Salário líquido é R$ 960,00.")]
        [InlineData(1500, "Salário líquido é R$ 1125,00.")]
        [InlineData(2200, "Salário líquido é R$ 1540,00.")]
        public void should_return_the_salary_with_discounts(double income, string expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            string returnedValue = exercises.Exercise16(income);

            // Deve / Asserções
            Assert.Equal(expected,returnedValue);
        }


        [Theory]
        [InlineData(6, new int[10]{6, 12, 18, 24, 30, 36, 42, 48, 54, 60})]
        [InlineData(5, new int[10]{5, 10, 15, 20, 25, 30, 35, 40, 45, 50})]
        [InlineData(-7, new int[10]{-7, -14, -21, -28, -35, -42, -49, -56, -63, -70})]
        public void should_return_6_multiplied_by_1_to_10_when_passed_6(int number, int[] expectedResult)
        {
            // Dado / Setup
            var exercises = new Exercises();
            
            // Quando / Ação
            var result = exercises.Exercise17(number);

            // Deve / Asserções
            Assert.Equal(result, expectedResult);
        }


        [Theory]
        [InlineData(5, "6,50")]
        [InlineData(10, "13,00")]
        [InlineData(12, "12,00")]
        [InlineData(3, "3,90")]
        [InlineData(4, "5,20")]
        public void should_return_the_price_of_apples_according_to_the_amount_informed(int appleAmount, string expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            string returnedValue = exercises.Exercise18(appleAmount);

            // Deve / Asserções
            Assert.Equal(expected,returnedValue);
        }
    }
}