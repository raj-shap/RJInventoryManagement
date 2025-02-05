namespace InventoryManagement.Common
{
    public class MessageContants
    {
        public static string Successful = "success";
        public static string SomethingWentWrong = "Something went wrong. Please try again later.";
        public static string LoginError = "Invalid username or password.";
        public static string UserAlreadyExist = "The user already exists.";
        public static string UserNotFound = "User not found.";
        public static string SendOtpError = "Failed to send OTP. Please try again.";
        public static string InvalidOtpError = "Invalid OTP. Please enter a valid OTP.";
        public static string OtpExpiredError = "OTP has expired. Please request a new one.";
        public static string ChangePasswordSuccess = "Password changed successfully.";
        public static string ChangePasswordError = "Failed to change password. Please try again.";
        public static string InvalidOldPasswordError = "The old password is incorrect.";
        public static string DuplicateCustomerError = "A customer with the same details already exists.";

        public enum Status
        {
            Success = 1,
            Failed = 0,
            NotFound = 2,
            AlreadyExist = 3,
            TokenExpire = 4,
            MultipleData = 5,
            CodeAlreadyExist = 6
        };
    }
}
