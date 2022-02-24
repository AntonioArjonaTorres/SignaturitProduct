using SignaturitProduct.Domain;

namespace SignaturitProduct.Application
{
    public class TrialHowToWin : ITrialHowToWin
    {
        public ApiRequest inputData;
        public ApiResponse apiResponse = new ApiResponse();
        public TrialLogic trialLogic = new TrialLogic();

        public TrialHowToWin(ApiRequest inputData) { this.inputData = inputData; }

        public ApiResponse getNecessaryToWin()
        {
            if (this.validateInput())
            {
                string verdict = trialLogic.getWinnerSign(this.inputData);

                apiResponse.Error = false;
                apiResponse.ResponseText = verdict;
            }
            return apiResponse;
        }

        public bool validateInput()
        {
            if (this.checkMaxMinCharacters() && this.allowedCharacters()) return true;
            else return false;
        }

        public bool checkMaxMinCharacters()
        {
            if (this.inputData.Plaintiff.Length == 3 && this.inputData.Defendant.Length == 3) return true;
            else
            {
                apiResponse.ResponseText = $"Invalid number of characters found in a contract. If you have an empty signature please insert #.";
                apiResponse.Error = true;
                return false;
            }
        }

        public bool allowedCharacters()
        {
            var validCharacters = trialLogic.getValidCharsForHowToWin().Split(',');
            int keyPadCounter = 0;
            for (int i = 0; i < this.inputData.Plaintiff.Length; i++)
            {
                if (Array.IndexOf(validCharacters, this.inputData.Plaintiff[i].ToString()) < 0)
                {
                    apiResponse.ResponseText = $"Invalid character '{this.inputData.Plaintiff[i]}' found in the Plaintiff contract.";
                    apiResponse.Error = true;
                    return false;
                }
                else if (this.inputData.Plaintiff[i].ToString() == trialLogic.getEmptyChar()) keyPadCounter++;

                if (keyPadCounter > 1)
                {
                    apiResponse.ResponseText = $"You cannot insert more than one '{trialLogic.getEmptyChar()}'";
                    apiResponse.Error = true;
                    return false;
                }
            }

            keyPadCounter = 0;

            for (int i = 0; i < this.inputData.Defendant.Length; i++)
            {
                if (Array.IndexOf(validCharacters, this.inputData.Defendant[i].ToString()) < 0)
                {
                    apiResponse.ResponseText = $"Invalid character '{this.inputData.Defendant[i]}' found in the Defendant contract.";
                    apiResponse.Error = true;
                    return false;
                }
                else if (this.inputData.Defendant[i].ToString() == trialLogic.getEmptyChar()) keyPadCounter++;

                if (keyPadCounter > 1)
                {
                    apiResponse.ResponseText = $"You cannot insert more than one '{trialLogic.getEmptyChar()}'";
                    apiResponse.Error = true;
                    return false;
                }
            }
            return true;
        }
    }
}
