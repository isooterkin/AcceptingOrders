using Dadata;
using Dadata.Model;

namespace AcceptingOrders.Tools
{
    public class AddressValidation
    {
        private static readonly CleanClient _cleanClient = new("1fc045b2b04909dd5c289f1079497abfdb0e568a", "3e05c84620d3e70e705a5050c9763955e12bbdab");



        public Address Address;
        public bool IsCorrect = false;



        public AddressValidation(string addressForVerification)
        {
            Address = GetAddress(addressForVerification);
            CheckValidationAddress();
        }



        private static Address GetAddress(string addressForVerification) 
            => _cleanClient.Clean<Address>(addressForVerification);



        private void CheckValidationAddress()
            => IsCorrect = (Address.city != null || Address.region != null) && Address.street != null && Address.house != null;



        public string GetCorrectAddress()
            => Address.city != null ? $"г. {Address.city}, ул. {Address.street}, д. {Address.house}" 
            : $"г. {Address.region}, ул. {Address.street}, д. {Address.house}";
    }
}