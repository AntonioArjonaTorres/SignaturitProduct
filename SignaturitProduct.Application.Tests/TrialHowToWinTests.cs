using Xunit;
using SignaturitProduct.Domain;

namespace SignaturitProduct.Application.Tests
{
    public class TrialHowToWinTests
    {
        //Testing checkMaxMinCharacters() function
        [Fact]
        public void CheckMaxMinCharacters_Request_Empty()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        [Fact]
        public void CheckMaxMinCharacters_Request_Not_Completed()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "#NN";
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        [Fact]
        public void CheckMaxMinCharacters_Success_All_Characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "#NN";
            apiRequest.Plaintiff = "VNN";
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.True(resultError);
        }

        [Fact]
        public void CheckMaxMinCharacters_Fails_Not_All_Characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "N#";
            apiRequest.Plaintiff = "NN";
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.checkMaxMinCharacters();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        //Testing allowedCharacters() function
        [Fact]
        public void AllowedCharacters_Request_Wrong_Characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "NQ#";
            apiRequest.Plaintiff = "QNN";
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.allowedCharacters();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        [Fact]
        public void AllowedCharacters_Request_Correct_Characters()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "KV#";
            apiRequest.Plaintiff = "KKN";
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.allowedCharacters();
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
            apiRequest.Defendant = "##N";
            apiRequest.Plaintiff = "NNN";
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.validateInput();
            //Assert
            var resultError = actionResult;
            Assert.False(resultError);
        }

        [Fact]
        public void ValidateInput_Validate_Success()
        {
            //Arrange
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Defendant = "#NN";
            apiRequest.Plaintiff = "VNN";
            TrialHowToWin trialHowToWin = new TrialHowToWin(apiRequest);
            //Act
            var actionResult = trialHowToWin.validateInput();
            //Assert
            var resultError = actionResult;
            Assert.True(resultError);
        }
    }
}