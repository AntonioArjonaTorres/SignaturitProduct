using SignaturitProduct.Domain;
using System.Reflection;

namespace SignaturitProduct.Application
{
    public class TrialLogic : ITrialLogic
    {
        public string startBattle(ApiRequest inputData)
        {
            //Let's start with the plaintinff
            int plaintinffSignatureValue = getSignatureValue(inputData.Plaintiff);

            //Now go with defendant
            int defendantSignatureValue = getSignatureValue(inputData.Defendant);

            if (plaintinffSignatureValue > defendantSignatureValue) return "Plaintinff Wins!";
            if (plaintinffSignatureValue < defendantSignatureValue) return "Defendant Wins!";
            else return "Draw!";
        }

        public string getWinnerSign(ApiRequest inputData)
        {
            throw new NotImplementedException();
        }

        public int getSignatureValue(string signatures)
        {
            int counterValue = 0;
            char[] arrayCharacters = signatures.ToCharArray();
            foreach (char c in arrayCharacters)
            {
                Roles roles = new Roles();
                PropertyInfo[] properties = typeof(Roles).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (c.ToString() == property.Name) counterValue += Convert.ToInt32(property.GetValue(roles));
                }
            }
            return counterValue;
        }

        public string getValidCharsForBattle()
        {
            List<string> validCharacters = new List<string>();
            Roles roles = new Roles();
            PropertyInfo[] properties = typeof(Roles).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "emptyChar") validCharacters.Add(property.Name);
            }
            return String.Join(",", validCharacters);
        }
    }
}
