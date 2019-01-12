namespace WeddingRental.Models.Views.User
{
    public class SignUpModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int? TerritoryId{ get; set; }
    }
}