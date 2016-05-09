using Model;

namespace ViewModel
{

    public class StudentViewModel : BaseViewModel
    {
        public StudentViewModel(Student x) : base(x)
        {
            this.UserId = x.UserId;
            this.Roll = x.Roll;
            this.Name = x.Name;
            this.Address = x.Address;
            this.Email = x.Email;
        }

        public string UserId { get; set; }

        public string Roll { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }




    }
}
