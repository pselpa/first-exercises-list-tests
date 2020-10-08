using System;

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

        public void Vote()
        {
            Votes++;
        }
    }
}