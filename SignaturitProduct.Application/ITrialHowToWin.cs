using SignaturitProduct.Domain;

namespace SignaturitProduct.Application
{
    internal interface ITrialHowToWin
    {
        public ApiResponse getNecessaryToWin();
        public bool validateInput();
    }
}
