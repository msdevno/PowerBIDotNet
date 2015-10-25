namespace PowerBIDotNet
{
    public interface IWorkspaces
    {
        IWorkspace GetFor(Tenant tenant);
    }
}
