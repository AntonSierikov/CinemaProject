using MovieDomain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDomain.AuthEntities
{
    public class Message 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Text { get; set; }

        public bool IsViewed { get; set; }

        public int FK_Sender { get; set; }

        [ForeignKey("FK_Sender")]
        public User Sender { get; set; }

        public int? FK_Receiver { get; set; }

        [ForeignKey("FK_Receiver")]
        public User Receiver { get; set; }

        public int FK_Chat { get; set; }

        public Chat Chat { get; set; }

        public DateTime DateSend { get; set; }

        public DateTime? DateLastChange { get; set; }

        //----------------------------------------------------------------//

        public Message() { }

        //----------------------------------------------------------------//

        public Message(string message, Chat chat, User sender, User receiver = null )
        {
            Text = message;
            Sender = sender;
            FK_Receiver = receiver?.Id;
            FK_Sender = sender.Id;
            Receiver = receiver;
            DateSend = DateTime.Now;
            //sender.SentMessages.Add(this);
            //receiver?.ReceiveMessages.Add(this);
            Chat = chat;
            FK_Chat = chat.Id;
        }

        //----------------------------------------------------------------//

        public void EditMessage(string newMessage)
        {
            Text = newMessage;
            DateLastChange = DateTime.Now;
        }

        //----------------------------------------------------------------//

        public bool Equals(Message msg)
        {
            if(msg != null)
            {
                return msg.DateSend == DateSend && msg.Text == Text;
            }
            return false;
        }

        //----------------------------------------------------------------//

        public bool CompareByKeyword(string keyword)
        {
            return Text == keyword;
        }

        //----------------------------------------------------------------//

        public string GetKeyword()
        {
            return Text;
        }

    }
}
