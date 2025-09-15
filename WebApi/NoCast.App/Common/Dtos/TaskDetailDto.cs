namespace NoCast.App.Common.Dtos
{
    public class TaskDetailDto
    {
        public Guid Id { get; set; }
        public byte TodayCnt { get; set; }
        public byte GiftCnt { get; set; }
        public TaskSessionDto Detail { get; set; }
    }
}
