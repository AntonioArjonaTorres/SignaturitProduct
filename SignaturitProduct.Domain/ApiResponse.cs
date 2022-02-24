namespace SignaturitProduct.Domain
{
    public class ApiResponse
    {
        private string responseText = "";
        private bool error;

        public ApiResponse()
        {
            ResponseText = "";
            Error = false;
        }

        public string ResponseText
        {
            get { return responseText; }
            set { responseText = value; }
        }

        public bool Error
        {
            get { return error; }
            set { error = value; }
        }
    }
}
