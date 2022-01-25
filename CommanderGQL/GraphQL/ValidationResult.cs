namespace CommanderGQL.GraphQL
{
    public class ValidationResult : IValidationResult
    {
        public ValidationResult()
        {
            messages = new List<string>();
        }

        public bool IsValid { get; set; }

        private List<string> messages;

        public IEnumerable<string> Messages
        {
            get { return messages; }
        }

        public void AddErrorMessage(string errorMessage)
        {
            messages.Add(errorMessage);
        }
    }
}
