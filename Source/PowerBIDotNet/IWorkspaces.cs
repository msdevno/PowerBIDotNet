namespace Infrastructure.PowerBI
{
    public interface IWorkspaces
    {
        IWorkspace GetFor(Tenant tenant);
    }
}
