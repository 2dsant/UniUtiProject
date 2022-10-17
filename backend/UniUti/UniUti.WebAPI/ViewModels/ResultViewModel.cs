namespace UniUti.WebAPI.ViewModels
{
    public class ResultViewModel
    {
        public ICollection<string>? Errors { get; set; }
        public bool Success { get; set; }
        public dynamic? Data { get; set; }
    }
}
