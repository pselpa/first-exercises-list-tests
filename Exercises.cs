using System;
using System.Collections.Generic;
using System.Linq;

namespace entra21_tests
{
    class Exercises
    {
        public int[] Exercise1A()
        {
            var numbers = new int[10];

            for (int counter = 1; counter < 11; counter++)
            {
				numbers[counter - 1] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1b,
        // então a aplicação deverá retornar todos os números de 1 a 10 de forma decrescente
        public int[] Exercise1B()
        {
            int[] numbers = new int[10];
            
            for (int counter = 10; counter > 0; counter--)
            {
                numbers[numbers.Length - counter] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1c,
        // então a aplicação deverá retornar os números de 1 a 10, mas somente os pares
        public int[] Exercise1C()
        {
            var numbers = new int[5];

            for (int counter = 2; counter < 11; counter+=2)
            {
                var index = (counter / 2) - 1;
				numbers[index] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 2,
        // então a aplicação deverá retornar a soma dos números números inteiros de 1 a 100.

        public int Exercise2()
        {
            var sumIntNumbers = 0;

            for (int i = 0; i < 101; i++)
            {
                sumIntNumbers += i;
            }
            
            return sumIntNumbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 3,
        // então a aplicação deverá retornar todos os números ímpares menores de 200.

        public int[] Exercise3()
        {
            var oddNumbers = new int[100];
            int counter = 0;
            
            for (int i = 0; i < 200; i++)
            {
                if (i % 2 != 0)
                {
                    oddNumbers[counter] = i;
                    counter++;
                }
            }
            return oddNumbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 4,
        // então a aplicação deverá retornar a média de idade de uma turma.

        public double Exercise4(List<int> ages)
        {
            double sum = 0.0;
            var answers = ages.Count;

            foreach (var item in ages)
            {
				sum += item;
            }

            double average = (sum / answers);

            return average;
        }


        public double Exercise5(List<int> ages)
        {
            double agePercentage = 0;
            double counterAge = 0;

            foreach (var item in ages)
            {
				if (item >= 18 && item <= 35)
                {
                    counterAge++;
                }
            }
            agePercentage = (counterAge / 5) * 100;
            return agePercentage;
            
        }


        // Dado que a aplicação recebe o numero de anos que a pessoa fuma, o nº de cigarros por dia e o preço de uma carteira, 
        //quando o usuário chamar o exercício 7, então a aplicação deverá retornar a quantidade de dinheiro gasta nesse período.

        public double Exercise7(double smokingYears, double cigarretesPerDay, double cigarretesPrice)
        {
            double cigarretesPerYear = (cigarretesPerDay*smokingYears*365/20);
            double cigarretesPackPerYear = Math.Ceiling(cigarretesPerYear);
            double totalExpensePerYear = (cigarretesPackPerYear*cigarretesPrice);

            return totalExpensePerYear;
        }

        // Dado que a aplicação recebe 2 números inteiros, X e Y. Quando o usuário chamar o exercício 8,
        //então a aplicação deverá retornar a mensagem informando se o X é múltiplo de Y.

        public string Exercise8(int x, int y)
        {
            var result = "";

            if (y == 0)
            {
                result = "ERRO. Divisão por zero.";
            }
            else if (x % y == 0)
            {
                result = "X é múltiplo de Y.";
            }
            else
            {
                result = "X não é múltiplo de Y.";
            }
            return result;
        }
       
        // Dado que a aplicação recebe 3 números reais. Quando o usuário chamar o exercício 9, 
        //então a aplicação deverá retornar se o primeiro é maior que a soma dos outros dois.
        
        public string Exercise9(int firstNumber, int secondNumber, int thirdNumber)
        {
            var result = "";
            int sum = secondNumber + thirdNumber;

            if (firstNumber > sum)
            {
                result = "Primeiro número é maior que soma dos outros dois.";
            }
            else
            {
                result = "Primeiro número não é maior que soma dos outros dois.";
            }
            return result;
        }

        // Dado que a aplicação recebe 2 números reais, A e B. Quando o usuário chamar o exercício 10, 
        //então a aplicação deverá retornar qual deles é maior, ou a mensagem "A = B" caso sejam iguais.

        public string Exercise10(int varA, int varB)
        {
            var result = "";

            if (varA > varB)
            {
                result = "A > B.";
            }
            else if (varB > varA)
            {
                result = "B > A.";
            }
            else
            {
                result = "A = B.";
            }
            return result;
        }


        // Dado que a aplicação recebe 2 números inteiros, Quando o usuário chamar o exercício 11, se o segundo for diferente de 
        //zero, calcular e imprimir o quociente do primeiro pelo segundo. Caso contrário, imprimir a mensagem: "DIVISÃO POR ZERO".

        public string Exercise11(int firstNumber, int secondNumber)
        {
            var result  = "";

            if (secondNumber == 0)
            {
                result = "DIVISÃO POR ZERO!";
            }
            else
            {
                double division = (double)firstNumber/(double)secondNumber;
                result =$"Divisão = {division}";
            }
            return result;
        }


        // Dado que a aplicação recebe 4 números inteiros, quando o usuário chamar o exercício 12,
        //calcular a soma dos que forem pares e ímpares

        public (int, int) Exercise12(List<int> numbers)
        {
            int sumEvenNumbers = 0;
            int sumOddNumbers = 0;

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    sumEvenNumbers += item;
                }
                else if (item % 2 != 0)
                {
                    sumOddNumbers += item;
                }
            }
            return (sumEvenNumbers, sumOddNumbers);
        }


        // Dado que a aplicação recebe 10 valores, quando o usuário chamar o exercício 13,
        //determinar o maior dentre eles.
        
        public double Exercise13(List<double> numbers)
        {
            var greatestNumber = double.MinValue;

            foreach (var item in numbers)
            {
                if (item > greatestNumber)
                {
                    greatestNumber = item;
                }
            }
            return greatestNumber;
        }


        // Dado que a aplicação recebe 3 valores. Colocá-los em ordem, quando o usuário chamar o exercício 14.

        public double[] Exercise14(double[] numbers)
        {
            double temporaryNumber = 0.0;

            if (numbers[0] > numbers[2] || numbers[1] > numbers[2]) 
            {
                if (numbers[0] > numbers[2] && numbers[1] > numbers[2]) 
                {
                    if (numbers[0] > numbers[2]) 
                    {
                        temporaryNumber = numbers[2];
                        numbers[2] = numbers[0];
                        numbers[0] = temporaryNumber;
                    }
                    else if (numbers[1] > numbers[2]) 
                    {
                        temporaryNumber = numbers[2];
                        numbers[2] = numbers[1];
                        numbers[1] = temporaryNumber;
                    }
                }

                if (numbers[0] > numbers[2])
                {
                    temporaryNumber = numbers[2];
                    numbers[2] = numbers[0];
                    numbers[0] = temporaryNumber;
                }
                else if (numbers[1] > numbers[2])
                {
                    temporaryNumber = numbers[2];
                    numbers[2] = numbers[1];
                    numbers[1] = temporaryNumber;
                }
            }

            if (numbers[0] > numbers[1])
            {
                temporaryNumber = numbers[1];
                numbers[1] = numbers[0];
                numbers[0] = temporaryNumber;
            }

            return numbers;
        }


        // Dado que a aplicação recebe 10 números,  imprimir quantos são múltiplos de 3 e quantos são múltiplos de 5.
        public (int, int) Exercise15(List<double> numbers)
        {
            int counter3 = 0;
            int counter5 = 0;

            foreach (var item in numbers)
            {
                if (item%3 == 0 && item%5 == 0)
                {
                    counter3++;
                    counter5++;
                }
                else if (item%3 == 0)
                {
                    counter3++;
                }
                else if (item%5 == 0)
                {
                    counter5++;
                }
            }
            var result = (counter3, counter5);
            return result;
        }

        // 16. Ler o salário de uma pessoa e imprimir o Salário Líquido de acordo com a redução do imposto descrito ao lado:
        // Menor ou igual a R$ 600,00 - ISENTO
        // Maior que R$ 600,00 e menor ou igual a 1200 - 20% desconto
        // Maior que R$ 1.200,00 e menor ou igual a R$2000 - 25% desconto
        // Maior que R$ 2.000,00 - 30% desconto
        public string Exercise16(double income)
        {
            double finalIncome = 0;
            var result = "";
            
            if (income < 0)
            {
                result = "ERRO. O salário não pode ser um valor negativo.";
            }
            else if (income <= 600)
            {
                result = $"Salário = R$ {income.ToString("0.00")}. ISENTO.";
            }
            else if (income <= 1200)
            {
                finalIncome = income * 0.8;
                result = $"Salário líquido é R$ {finalIncome.ToString("0.00")}.";
            }
            else if (income <= 2000)
            {
                finalIncome = income * 0.75;
                result = $"Salário líquido é R$ {finalIncome.ToString("0.00")}.";
            }
            else if (income > 2000)
            {
                finalIncome = income * 0.70;
                result = $"Salário líquido é R$ {finalIncome.ToString("0.00")}.";
            }

            return result;
        }

        // DADO que a aplicação esteja pronta, QUANDO o usuário informar um número
        // DEVE retornar a tabuada de 1 a 10
        public IEnumerable<int> Exercise17(int number)
		{
            var multiplicationTable = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            return multiplicationTable.Select(item => item * number);
		}
        
        //DADO que a aplicação esteja pronta, QUANDO o usuário informar quantas maçãs foram compradas, DEVE retornar o custo total da 
        //compra, sendo que as maçãs custam R$ 1,30 cada se forem compradas menos de uma dúzia, e R$ 1,00 se forem compradas pelo menos 12.
        
        public string Exercise18(int appleAmount)
        {
            var appleCost = "";

            if (appleAmount < 12)
            {
                appleCost = (1.3 *appleAmount).ToString("0.00");
            }
            else if (appleAmount >= 12)
            {
                appleCost = appleAmount.ToString("0.00");
            }
            
            return appleCost;
        }
    }   
}

