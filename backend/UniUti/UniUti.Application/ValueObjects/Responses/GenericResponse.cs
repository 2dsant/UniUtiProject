namespace UniUti.Application.ValueObjects.Responses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public List<string>? Messages { get; set; }
    }
}