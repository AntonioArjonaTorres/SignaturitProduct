namespace SignaturitProduct.Domain
{
    public class Contract
    {
        public string owner;
        public int contractValue;

        public Contract(String owner, int contractValue) 
        { 
            this.owner = owner;
            this.contractValue = contractValue;
        }
    }
}
