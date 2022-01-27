
namespace CommanderGQL.GraphQL
{
    public interface IValidationResult
    {
        bool IsValid { get; set; }
        IEnumerable<string> Messages { get; }

        void AddErrorMessage(string errorMessage);

        void EmptyErrorMessage();
        
    }
}