namespace NoCast.App.Common.Dtos
{
    public class UserSessionDto
    {
        public decimal Balance { get; set; }
        public decimal Block { get; set; }
        public List<Guid> RemainingTasks { get; set; } = new();
        public byte DoneTask { get; set; }
    }
}
