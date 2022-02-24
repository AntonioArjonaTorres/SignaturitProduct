using Xunit;
using SignaturitProduct.Domain;

namespace SignaturitProduct.Application.Tests
{
    public class TrialBattleTests
    {
        //Testing checkMaxMinCharacters() function
        [Fact]
        public void CheckMaxMinCharacters_Request_Empty()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        [Fact]
        public void CheckMaxMinCharacters_Request_Not_Completed()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "KNN";
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        [Fact]
        public void CheckMaxMinCharacters_success_all_characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "KNN";
            apiRequest.Plaintiff = "NNN";
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.True(resultError);
        }

        [Fact]
        public void CheckMaxMinCharacters_success_some_characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "N";
            apiRequest.Plaintiff = "NN";
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.True(resultError);
        }

        //Testing allowedCharacters() function
        [Fact]
        public void AllowedCharacters_Request_Wrong_Characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "NQ";
            apiRequest.Plaintiff = "NNE";
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.allowedCharacters();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        [Fact]
        public void AllowedCharacters_Request_Correct_Characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "KNN";
            apiRequest.Plaintiff = "NNN";
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.allowedCharacters();
            //Assert
            var resultError = actionResult;
            Assert.True(resultError);
        }

        //Testing validateInput() function
        [Fact]
        public void ValidateInput_Validate_Fails()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "";
            apiRequest.Plaintiff = "NNV";
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.allowedCharacters();
            //Assert
            var resultError = actionResult;
            Assert.True(resultError);
        }

        [Fact]
        public void ValidateInput_Validate_Success()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "";
            apiRequest.Plaintiff = "NNV";
            TrialBattle trialBattle = new TrialBattle(apiRequest);
            //Act
            var actionResult = trialBattle.allowedCharacters();
            //Assert
            var resultError = actionResult;
            Assert.True(resultError);
        }
    }
}