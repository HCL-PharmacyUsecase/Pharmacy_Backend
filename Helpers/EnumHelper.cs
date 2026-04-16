namespace Pharmacy.API.Helpers
{
    public static class EnumHelper
    {
        // Define your statuses here to avoid magic strings
        public const string RoleAdmin = "Admin";
        public const string RoleCustomer = "Customer";

        public const string OrderPending = "Pending";
        public const string OrderConfirmed = "Confirmed";
        public const string OrderShipped = "Shipped";
        public const string OrderCancelled = "Cancelled";

        public const string PrescriptionPending = "Pending";
        public const string PrescriptionVerified = "Verified";
        public const string PrescriptionRejected = "Rejected";
    }
}