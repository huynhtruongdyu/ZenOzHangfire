namespace ZenOzHangfire.Applications.Jobs.Common
{
    public interface IRecurringJob
    {
        void Execute(params object[] parameters);
    }
}