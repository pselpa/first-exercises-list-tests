using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace entra21_tests
{
    public class ElectionTest
    {
        [Fact]
        public void should_return_false_when_the_password_is_wrong()
        {
            var election = new Election();
            var candidatesInput = new List<(string name, string cpf)>{("Rafael", "123.456.789-10")};

            bool result = election.CreateCandidates(candidatesInput, "WrongPassword123");

            Assert.False(result);
            Assert.Empty(election.Candidates);
        }
        
        [Fact]
        public void should_return_true_when_the_password_is_correct()
        {
            var election = new Election();
            var candidatesInput = new List<(string name, string cpf)>{("Rafael", "123.456.789-10")};

            bool result = election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            Assert.True(result);
            Assert.Equal(1, election.Candidates.Count);
        }

        [Fact]
        public void should_return_empty_if_null_input()
        {
            var election = new Election();
            List<(string name, string cpf)> candidatesInput = null;

            bool result = election.CreateCandidates(candidatesInput, "anything");

            Assert.False(result);
            Assert.Empty(election.Candidates);
        }

        [Fact]
        public void should_return_different_ids()
        {
            var election = new Election();
            (string name, string cpf) rafael = ("Rafael", "123.456.789-10");
            (string name, string cpf) fernanda = ("Fernanda", "109.876.543.21");
            var candidatesInput = new List<(string name, string cpf)>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var rafaelId = election.GetCandidateIdsByName(rafael.name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.name)[0];

            Assert.NotEqual(rafaelId, fernandaId);
        }

        [Fact]
        public void should_return_2_people_with_same_name()
        {
            var election = new Election();
            (string name, string cpf) rafael1 = ("Rafael", "123.456.789.10");
            (string name, string cpf) rafael2 = ("Rafael", "853.652.321-78");
            var candidatesInput = new List<(string name, string cpf)>{rafael1, rafael2};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var foundIds = election.GetCandidateIdsByName("Rafael");

            Assert.Equal(2, foundIds.Count);
        }

        [Fact]
        public void should_return_rafael_id_by_cpf()
        {
            var election = new Election();
            (string name, string cpf) rafael = ("Rafael", "123.456.789.10");
            (string name, string cpf) fernanda = ("Fernanda", "109.876.543.21");
            (string name, string cpf) joana = ("Joana", "257.323.689-01");
            var candidatesInput = new List<(string name, string cpf)>{rafael, fernanda, joana};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var foundId = election.GetCandidateIdByCPF(rafael.cpf);

            Assert.Equal(election.Candidates.ElementAt(0).Id, foundId);
        }

        [Fact]
        public void should_return_fernanda_id_by_cpf()
        {
            var election = new Election();
            (string name, string cpf) fernanda1 = ("Fernanda", "109.876.543.21");
            (string name, string cpf) fernanda2 = ("Fernanda", "125.656.987-01");
            var candidatesInput = new List<(string name, string cpf)>{fernanda1, fernanda2};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");

            var foundId = election.GetCandidateIdByCPF(fernanda1.cpf);

            Assert.Equal(election.Candidates.ElementAt(0).Id, foundId);
        }

        [Fact]
        public void should_return_3_votes_for_rafael_and_1_vote_for_fernanda()
        {
            var election = new Election();
            (string name, string cpf) rafael = ("Rafael", "123.456.789.10");
            (string name, string cpf) fernanda = ("Fernanda", "109.876.543.21");
            var candidatesInput = new List<(string name, string cpf)>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.name)[0];

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
            (string name, string cpf) rafael = ("Rafael", "123.456.789.10");
            (string name, string cpf) fernanda = ("Fernanda", "109.876.543.21");
            var candidatesInput = new List<(string name, string cpf)>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.name)[0];

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
            (string name, string cpf) rafael = ("Rafael", "123.456.789.10");
            (string name, string cpf) fernanda = ("Fernanda", "109.876.543.21");
            var candidatesInput = new List<(string name, string cpf)>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.name)[0];
            election.Vote(rafaelId);

            var winners = election.Voting("WrongPassword");

            Assert.Null(winners[0]);
        }

        [Fact]
        public void should_return_rafael_as_the_winner()
        {
            var election = new Election();
            (string name, string cpf) rafael = ("Rafael", "123.456.789.10");
            (string name, string cpf) fernanda = ("Fernanda", "109.876.543.21");
            var candidatesInput = new List<(string name, string cpf)>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.name)[0];
            election.Vote(rafaelId);

            var winners = election.Voting("Pa$$w0rd");

            Assert.Equal(rafael.name, winners[0].Name);
        }

        [Fact]
        public void should_return_two_different_winners_if_the_vote_is_a_tie()
        {
            var election = new Election();
            (string name, string cpf) rafael = ("Rafael", "123.456.789.10");
            (string name, string cpf) fernanda = ("Fernanda", "109.876.543.21");
            var candidatesInput = new List<(string name, string cpf)>{rafael, fernanda};
            election.CreateCandidates(candidatesInput, "Pa$$w0rd");
            var rafaelId = election.GetCandidateIdsByName(rafael.name)[0];
            var fernandaId = election.GetCandidateIdsByName(fernanda.name)[0];
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