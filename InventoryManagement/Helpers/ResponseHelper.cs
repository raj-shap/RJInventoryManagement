using InventoryManagement.Models;

namespace InventoryManagement.Helpers
{
    public class ResponseHelper
    {
        private readonly ServiceResponse response;
        public ResponseHelper(bool success, string message)
        {
            response.Success = success;
            response.Message = message;
        }

        public static ResponseHelper SuccessMessage(string message = "Operation Successful")
        {
            Console.WriteLine($"Message : {message}");
            return new ResponseHelper(true, message);
        }
        public static ResponseHelper FailureMessage(string message = "Operation Failed")
        {
            Console.WriteLine($"Message : {message}");
            return new ResponseHelper(false, message);  
        }
    }
}
