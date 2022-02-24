using SignaturitProduct.Domain;

namespace SignaturitProduct.Application
{
    public class TrialBattle: ITrialBattle
    {
        public ApiRequest inputData;
        public ApiResponse apiResponse = new ApiResponse();
        public TrialLogic trialLogic = new TrialLogic();

        public TrialBattle(ApiRequest inputData) { this.inputData = inputData; }

        public ApiResponse prepareBattle()
        {
            if (this.validateInput())
            {
                string verdict = trialLogic.startBattle(this.inputData);

                apiResponse.Error = false;
                apiResponse.ResponseText = verdict;
            }
            return apiResponse;
        }

        public bool allowedCharacters()
        {
            var validCharacters = trialLogic.getValidCharsForBattle().Split(',');
            for (int i = 0; i < this.inputData.Plaintiff.Length; i++)
            {
                if (Array.IndexOf(validCharacters, this.inputData.Plaintiff[i].ToString()) < 0)
                {
                    apiResponse.ResponseText = $"Invalid character '{this.inputData.Plaintiff[i]}' found in the Plaintiff contract.";
                    apiResponse.Error = true;
                    return false;
                }
            }

            for (int i = 0; i < this.inputData.Defendant.Length; i++)
            {
                if (Array.IndexOf(validCharacters, this.inputData.Defendant[i].ToString()) < 0)
                {
                    apiResponse.ResponseText = $"Invalid character '{this.inputData.Defendant[i]}' found in the Defendant contract.";
                    apiResponse.Error = true;
                    return false;
                }
            }
            return true;
        }

        public bool checkMaxMinCharacters()
        {
            if (this.inputData.Plaintiff.Length > 0 && this.inputData.Plaintiff.Length < 4 && this.inputData.Defendant.Length > 0 && this.inputData.Defendant.Length < 4)
                return true;
            else
            {
                apiResponse.ResponseText = $"Invalid number of characters found in a contract.";
                apiResponse.Error = true;
                return false;
            }
        }

        public bool validateInput()
        {
            if (this.checkMaxMinCharacters() && this.allowedCharacters()) return true;
            else return false;
        }
    }
}
