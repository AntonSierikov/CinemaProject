using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using MovieDomain.Abstract;

namespace MovieDomain.AuthEntities
{
    public class Chat : DbObject<int>
    {

        [StringLength(70)]
        public string Name { get; set; }

        public bool IsPersonal { get; set; }

        [StringLength(150)]
        public string PathOfPhoto { get; set; }

        public IList<Message> messages { get; set; }

        public IList<User> users { get; set; }

        //----------------------------------------------------------------//     

        public Chat()
        {
            messages = new List<Message>();
        }

        //----------------------------------------------------------------//

        public Chat(params User[] users)
            : this()
        {
            this.users = users;
            //foreach(var user in users)
            //{
            //    user.Chats.Add(this);
            //}
            Id = GetHashCode();
            IsPersonal = this.users.Count == 2
                         ? true : false;
        }

        //----------------------------------------------------------------//

        public Chat(string name, params User[] users)
            : this(users)
        {
            Name = name;
        }

        //----------------------------------------------------------------//

        public bool Equals(Chat chat)
        {
            if( chat != null)
            {
                return chat.Id == chat.Id;
            }
            return false;
        }

    }
}
