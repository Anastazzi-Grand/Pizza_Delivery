namespace Pizza_server.Repositories
{
    public class Storage
    {
        public static readonly ClientStorage ClientStorage = new();
        public static readonly DeliveryStorage DeliveryStorage = new();
        public static readonly EmployeeStorage EmployeeStorage = new();
        public static readonly LineNumberStorage LineNumberStorage = new();
        public static readonly OrderStorage OrderStorage = new();
        public static readonly PizzaStorage PizzaStorage = new();
        public static readonly PostStorage PostStorage = new();
    }
}
