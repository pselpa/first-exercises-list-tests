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
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var candidatesInput = new List<Candidate>{rafael};

            bool result = election.CreateCandidates(candidatesInput, "WrongPassword123");

            Assert.False(result);
            Assert.Empty(election.Candidates);
        }
        
        [Fact]
        public void should_return_true_when_the_password_is_correct()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var candidatesInput = new List<Candidate>{rafael};

            bool result = election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            Assert.True(result);
            Assert.Equal(1, election.Candidates.Count);
        }

        [Fact]
        public void should_return_empty_if_null_input()
        {
            var election = new Election();
            List<Candidate> candidatesInput = null;

            bool result = election.CreateCandidates(candidatesInput, "anything");

            Assert.False(result);
            Assert.Empty(election.Candidates);
        }

        [Fact]
        public void should_return_different_ids()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda = new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var rafaelId = election.GetCandidateIdsByName(rafael.Name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.Name)[0];

            Assert.NotEqual(rafaelId, fernandaId);
        }

        [Fact]
        public void should_return_2_people_with_same_name()
        {
            var election = new Election();
            var rafael1 = new Candidate("Rafael", "123.456.789.10");
            var rafael2 = new Candidate("Rafael", "853.652.321-78");
            var candidatesInput = new List<Candidate>{rafael1, rafael2};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var foundIds = election.GetCandidateIdsByName("Rafael");

            Assert.Equal(2, foundIds.Count);
        }

        [Fact]
        public void should_return_rafael_id_by_cpf()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda = new Candidate("Fernanda", "109.876.543.21");
            var joana = new Candidate("Joana", "257.323.689-01");
            var candidatesInput = new List<Candidate>{rafael, fernanda, joana};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var foundId = election.GetCandidateIdByCPF(rafael.Cpf);

            Assert.Equal(election.Candidates.ElementAt(0).Id, foundId);
        }

        [Fact]
        public void should_return_fernanda_id_by_cpf()
        {
            var election = new Election();
            var fernanda1 = new Candidate("Fernanda", "109.876.543.21");
            var fernanda2 = new Candidate("Fernanda", "125.656.987-01");
            var candidatesInput = new List<Candidate>{fernanda1, fernanda2};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var foundId = election.GetCandidateIdByCPF(fernanda1.Cpf);

            Assert.Equal(election.Candidates.ElementAt(0).Id, foundId);
        }

        [Fact]
        public void should_return_3_votes_for_rafael_and_1_vote_for_fernanda()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.Name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.Name)[0];

            for(var i = 0; i < 3; i++)
            {
                election.Vote(rafaelId);
            }

            for(var i = 0; i < 1; i++)
            {
                election.Vote(fernandaId);
            }

            var candidateRafael = election.Candidates.First(x => x.Id == rafaelId);
            var candidateFernanda = election.Candidates.First(x => x.Id == fernandaId);
            Assert.Equal(3, candidateRafael.Votes);
            Assert.Equal(1, candidateFernanda.Votes);
        }

        [Fact]
        public void should_return_50_vote_for_rafael_and_175_vote_for_fernanda()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.Name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.Name)[0];

            for(var i = 0; i < 50; i++)
            {
                election.Vote(rafaelId);
            }

            for(var i = 0; i < 175; i++)
            {
                election.Vote(fernandaId);
            }

            var candidateRafael = election.Candidates.First(x => x.Id == rafaelId);
            var candidateFernanda = election.Candidates.First(x => x.Id == fernandaId);
            Assert.Equal(50, candidateRafael.Votes);
            Assert.Equal(175, candidateFernanda.Votes);
        }
        
        [Fact]
        public void should_return_null_when_the_password_is_wrong()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.Name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.Name)[0];
            election.Vote(rafaelId);

            var winners = election.Voting("WrongPassword");

            Assert.Null(winners[0]);
        }

        [Fact]
        public void should_return_rafael_as_the_winner()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.Name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.Name)[0];
            election.Vote(rafaelId);

            var winners = election.Voting("Pa$$w0rd");

            Assert.Equal(rafael.Name, winners[0].Name);
        }

        [Fact]
        public void should_return_two_different_winners_if_the_vote_is_a_tie()
        {
            var election = new Election();
            var rafael = new Candidate("Rafael", "123.456.789.10");
            var fernanda =  new Candidate("Fernanda", "109.876.543.21");
            var candidatesInput = new List<Candidate>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.Name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.Name)[0];
            election.Vote(rafaelId);
            election.Vote(fernandaId);

            var winners = election.Voting("Pa$$w0rd");

            Assert.Equal(2, winners.Count);
            Assert.True(rafaelId == winners[0].Id ^ fernandaId == winners[0].Id);
            Assert.True(rafaelId == winners[1].Id ^ fernandaId == winners[1].Id);
            Assert.NotEqual(winners[0].Id, winners[1].Id);
        }
    }
}