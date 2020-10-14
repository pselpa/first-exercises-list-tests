using System;
using System.Linq;

namespace Domain
{
    public class Candidate
    {
        public Guid Id {get; private set;}

        public string Name {get; private set;}

        public string Cpf {get; private set;}

        public int Votes {get; private set;}

        public Candidate(string name, string cpf)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Cpf = cpf;
            this.Votes = 0;
        }

        
        public bool Validate()
        {
            if (string.IsNullOrEmpty(Cpf))
            {
                return false;
            }

            var cpf = Cpf.Replace(".", "").Replace("-", "");
            
            if (cpf.Length != 11)
            {
                return false;
            }

            if (!cpf.All(char.IsNumber))
            {
                return false;
            }

            // var first = cpf[0];
            // if (cpf.Substring(1, 11).All(x => x == first))
            // {
            //     return false;
            // }

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp;
            string digit;
            int sum;
            int rest;

            temp = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(temp[i].ToString()) * multiplier1[i];
            }

            rest = sum % 11;

            rest = rest < 2 ? 0 : 11 - rest;

            digit = rest.ToString();
            temp += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(temp[i].ToString()) * multiplier2[i];
            }

            rest = sum % 11;

            rest = rest < 2 ? 0 : 11 - rest;

            digit += rest.ToString();

            if (cpf.EndsWith(digit))
            {
                return true;
            }

            return false;
        }

        public void Vote()
        {
            if (Validate() != false)
            {
                Votes++;
            }
            
        }
    }
}