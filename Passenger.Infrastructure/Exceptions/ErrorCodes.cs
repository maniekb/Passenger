namespace Passenger.Infrastructure.Exceptions
{
    public static class ErroCodes
    {
        public static string EmailInUse => "email_in_use";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidCredentials => "invalid_credentials";
        public static string DriverNotFound => "driver_not_found";
        public static string DriverArleadyExists => "driver_arleady_exists";
        public static string UserNotFound => "user_not_found";

    }
}