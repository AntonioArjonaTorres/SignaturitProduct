using SignaturitProduct.Domain;

namespace SignaturitProduct.Application
{
    public interface ITrialBattle
    {
        public ApiResponse prepareBattle();
        public bool validateInput();
    }
}
