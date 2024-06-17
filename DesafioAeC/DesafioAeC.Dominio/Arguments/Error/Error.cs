namespace DesafioAeC.Dominio.Arguments.Error
{
    public class Error
    {
        public string Message { get; private set; }
        public string Code { get; private set; }
        
        public Error(string message, string code)
        {
            this.Message = message;
            this.Code = code;
        }
    }
}
