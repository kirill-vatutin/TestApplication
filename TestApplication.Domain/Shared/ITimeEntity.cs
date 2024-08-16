namespace TestApplication.Domain.Shared
{
    public interface ITimeEntity
    {
        DateTime CreatedTime { get; }

        DateTime? UpdatedTime { get; }

        void UpdateCreatedTime();
        void UpdateUpdatedTime();
    }
}
