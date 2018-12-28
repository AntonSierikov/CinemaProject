using System;
using MovieDomain.Abstract;

namespace MovieDomain.AuthEntities
{
    public class User : DbObject<int>
                                 
    {

        //----------------------------------------------------------------//

        public User()
        {
            //Comments = new List<Comment>();
            //Chats = new List<Chat>();
            //LikedMovies = new List<Movie>();
            //LikedPeople = new List<People>();
            //WillWatch = new List<Movie>();
            //Appreciated = new List<Movie>();
            //SentMessages = new List<Message>();
            //ReceiveMessages = new List<Message>();
            //AddedDate = DateTime.Now;
        }

        //----------------------------------------------------------------//

        public User(string gender)
            : this()
        {}

        //----------------------------------------------------------------//

        public string ConnectionId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public bool IsOnline { get; set; }

        public string UserPassword { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? LastVisitDate { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public int? RoleId { get; set; }

        public bool? Gender { get; set; }

        public string UserStatus { get; set; }

        public string PathOfPhoto { get; set; }

        //----------------------------------------------------------------//

        //public IList<User> UserFriends { get; set; }

        //----------------------------------------------------------------//

        //public IList<User> UserSubscribers { get; set; }

        //----------------------------------------------------------------//

        //public ICollection<Chat> Chats { get; set; }

        //public ICollection<Comment> Comments { get; set; }

        //public ICollection<Movie> LikedMovies { get; set; }

        //public ICollection<Movie> WillWatch { get; set; }

        //public ICollection<Movie> Appreciated { get; set; }

        //public ICollection<People> LikedPeople { get; set; }

        //public ICollection<Message> SentMessages { get; set; }

        //public ICollection<Message> ReceiveMessages { get; set; }


        //----------------------------------------------------------------//

        public bool Equals(User user)
        {
            if (user != null)
            {
                return Email == user.Email
                         && UserPassword == user.UserPassword;
            }
            return false;
        }

        //----------------------------------------------------------------//

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ AddedDate.GetHashCode();
        }

        //----------------------------------------------------------------//



    }
}
