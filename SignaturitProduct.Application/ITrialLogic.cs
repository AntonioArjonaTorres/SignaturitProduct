using SignaturitProduct.Domain;

namespace SignaturitProduct.Application
{
    internal interface ITrialLogic
    {
        public string startBattle(ApiRequest inputData);
        public string getWinnerSign(ApiRequest inputData);
        public int getSignatureValue(string signatures);
    }
}
