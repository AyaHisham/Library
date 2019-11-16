using System.ComponentModel.DataAnnotations;
using Library.Models.EntityDataModel;

namespace Library.Models.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public static explicit operator UserViewModel(User user)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Id = user.Id;
            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.PhoneNumber = user.PhoneNumber;

            return userViewModel;
        }
    }
}
