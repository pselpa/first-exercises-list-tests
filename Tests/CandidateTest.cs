using Xunit;
using Domain;

namespace Tests
{
    public class CandidateTest
    {
        [Fact]
        public void Should_contain_same_parameters_provided()
        {
            var name = "Rafael";
            var CPF = "123.456.789.10";
            
            var candidate = new Candidate(name, CPF);

            Assert.Equal(name, candidate.Name);
            Assert.Equal(CPF, candidate.Cpf);
        }

        [Fact]
        public void Should_contain_votes_equals_zero()
        {
            var name = "Rafael";
            var CPF = "123.456.789.10";

            var candidate = new Candidate(name, CPF);

            Assert.Equal(0, candidate.Votes);
        }

        [Fact]
        public void Should_contain_votes_equals_2_when_voted_twice()
        {
            var name = "Rafael";
            var CPF = "123.456.789.10";
            var candidate = new Candidate(name, CPF);

            candidate.Vote();
            candidate.Vote();

            Assert.Equal(2, candidate.Votes);
        }

        [Fact]
        public void Should_not_generate_same_id_for_both_candidates()
        {
            var Jose = new Candidate("Rafael", "123.456.789.10");
            var Ana = new Candidate("Fernanda", "109.876.543.21");
            
            Assert.NotEqual(Jose.Id, Ana.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("000.000.000-00")]
        [InlineData("000.000.000-01")]
        [InlineData("100.000.000-00")]
        [InlineData("999.999.999-99")]
        [InlineData("000.368.560-00")]
        [InlineData("640.3685606")]
        [InlineData("640.368.560-6")]
        [InlineData("640.368.560-6a")]
        [InlineData("640.368.560-061")]
        public void Should_return_false_when_CPF_is_invalid(string CPF)
        {
            // Dado / Setup
            var Jose = new Candidate("José", CPF);

            // When / Ação
            var isValid = Jose.Validate().isValid;
            
            // Deve / Asserções
            Assert.False(isValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1234")]
        [InlineData(" Rafael")]
        [InlineData("Rafael ")]
        [InlineData("Rafael  ")]
        [InlineData("Rafael I")]
        [InlineData("Rafael 0")]
        [InlineData("Rafael --")]
        [InlineData("R4fael Rodrigues")]
        [InlineData("Rafael Rodrigues Fernande$")]
        [InlineData("Raf@el Rodrigues")]
        public void Should_return_false_when_name_is_invalid(string name)
        {
            // Dado / Setup
            var validCPF = "640.368.560-06";
            var candidate = new Candidate(name, validCPF);

            // When / Ação
            var isValid = candidate.Validate().isValid;
            
            // Deve / Asserções
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("Rafael Fernandes", "49402677097")]
        [InlineData("Fernanda Albuquerque", "045.398.630-70")]
        public void Should_return_true_when_CPF_and_name_is_valid(string name, string CPF)
        {
            // Dado / Setup
            var candidate = new Candidate(name, CPF);

            // When / Ação
            var isValid = candidate.Validate().isValid;
            
            // Deve / Asserções
            Assert.True(isValid);
        }
    }
}
