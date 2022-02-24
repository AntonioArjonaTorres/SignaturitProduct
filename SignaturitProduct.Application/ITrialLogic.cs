using SignaturitProduct.Domain;

namespace SignaturitProduct.Application
{
    internal interface ITrialLogic
    {
        public string startBattle(ApiRequest inputData);
        public string getWinnerSign(ApiRequest inputData);
        public int getSignatureValue(string signatures);
        public string getValidCharsForBattle();
        public string getFirstSignatureToWin(int difference);
        public string getEmptyChar();
        public string getValidCharsForHowToWin();
    }
}
