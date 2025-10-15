namespace CustomerManagement.Repository
{
    public interface IDashboard
    {
        int GetCustomerCount();
        int GetServiceCount();
        string GetUserName(int userId);
    }
}
