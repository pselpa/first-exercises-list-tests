using Xunit;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Tests
{
    public class ElectionTest
    {
        [Fact]
        public void should_return_false_when_the_password_is_wrong()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var candidatesInput = new List<Candidate>{rafael};

            // Quando / Ação
            bool result = election.CreateCandidates(candidatesInput, "WrongPassword123");

            // Deve / Asserções
            Assert.False(result);
            Assert.Empty(election.Candidates);
        }
        
        [Fact]
        public void should_return_true_when_the_password_is_correct()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var candidatesInput = new List<Candidate>{rafael};

            // Quando / Ação
            bool result = election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            // Deve / Asserções
            Assert.True(result);
            Assert.Equal(1, election.Candidates.Count);
        }

        [Fact]
        public void should_return_empty_if_null_input()
        {
            // Dado / Setup
            var election = new Election();
            List<Candidate> candidatesInput = null;

            // Quando / Ação
            bool result = election.CreateCandidates(candidatesInput, "anything");

            // Deve / Asserções
            Assert.False(result);
            Assert.Empty(election.Candidates);
        }

        [Fact]
        public void should_return_different_ids()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda = new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            // Quando / Ação
            var rafaelId = election.GetCandidateIdsByName(rafael.Name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.Name)[0];

            // Deve / Asserções
            Assert.NotEqual(rafaelId, fernandaId);
        }

        [Fact]
        public void should_return_2_people_with_same_name()
        {
            // Dado / Setup
            var election = new Election();
            var rafael1 = new Candidate("Rafael", "123.456.789.10");
            var rafael2 = new Candidate("Rafael", "853.652.321-78");
            var candidatesInput = new List<Candidate>{rafael1, rafael2};
            
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            // Quando / Ação
            var foundIds = election.GetCandidateIdsByName("Rafael");

            // Deve / Asserções
            Assert.Equal(2, foundIds.Count);
        }

        [Fact]
        public void should_return_rafael_id_by_cpf()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda = new Candidate("Fernanda", "109.876.543.21");
            var joana = new Candidate("Joana", "257.323.689-01");
            var candidatesInput = new List<Candidate>{rafael, fernanda, joana};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            // Quando / Ação
            var foundId = election.GetCandidateIdByCPF(rafael.Cpf);

            // Deve / Asserções
            Assert.Equal(election.Candidates.ElementAt(0).Id, foundId);
        }

        [Fact]
        public void should_return_fernanda_id_by_cpf()
        {
            // Dado / Setup
            var election = new Election();
            var fernanda1 = new Candidate("Fernanda", "109.876.543.21");
            var fernanda2 = new Candidate("Fernanda", "125.656.987-01");
            var candidatesInput = new List<Candidate>{fernanda1, fernanda2};
            
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            // Quando / Ação
            var foundId = election.GetCandidateIdByCPF(fernanda1.Cpf);

            // Deve / Asserções
            Assert.Equal(election.Candidates.ElementAt(0).Id, foundId);
        }

        [Fact]
        public void should_return_3_votes_for_rafael_and_1_vote_for_fernanda()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            
            // Quando / Ação
            election.Vote(rafael.Cpf);
            election.Vote(rafael.Cpf);
            election.Vote(rafael.Cpf);

            election.Vote(fernanda.Cpf);

            // Deve / Asserções
            var candidateRafael = election.Candidates.First(x => x.Cpf == rafael.Cpf);
            var candidateFernanda = election.Candidates.First(x => x.Cpf == fernanda.Cpf);
            Assert.Equal(3, candidateRafael.Votes);
            Assert.Equal(1, candidateFernanda.Votes);
        }

        [Fact]
        public void should_return_null_when_the_password_is_wrong()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            // Quando / Ação
            election.Vote(rafael.Cpf);

            // Deve / Asserções
            var winners = election.PollResult("WrongPassword");
            Assert.Null(winners[0]);
        }

        [Fact]
        public void should_return_rafael_as_the_winner()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            
            // Quando / Ação
            election.Vote(rafael.Cpf);
            election.Vote(rafael.Cpf);

            election.Vote(fernanda.Cpf);

            var winners = election.PollResult("Pa$$w0rd");

            // Deve / Asserções
            Assert.Equal(rafael.Name, winners[0].Name);
        }

        [Fact]
        public void should_return_two_different_winners_if_the_vote_is_a_tie()
        {
            // Dado / Setup
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            
            // Quando / Ação
            election.Vote(rafael.Cpf);
            election.Vote(fernanda.Cpf);

            var winners = election.PollResult("Pa$$w0rd");

            // Deve / Asserções
            Assert.Equal(2, winners.Count);
            Assert.True(rafael.Cpf == winners[0].Cpf ^ fernanda.Cpf == winners[0].Cpf);
            Assert.True(rafael.Cpf == winners[1].Cpf ^ fernanda.Cpf == winners[1].Cpf);
            Assert.NotEqual(winners[0].Id, winners[1].Id);
        }
    }
}