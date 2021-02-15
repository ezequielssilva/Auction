public class ValidationModel
{
    public string Attribute { get; private set; }
    public string Message { get; private set; }

    public ValidationModel(string attribute, string message)
    {
        this.Attribute = attribute;
        this.Message = message;
    }
}