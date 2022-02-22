namespace SignaturitProduct.Domain
{
    public class ApiRequest
    {
        public ApiRequest() 
        {
            Plaintiff = "";
            Defendant = "";
        }

        public string Plaintiff { get; set; }
        public string Defendant { get; set; }
    }
}
