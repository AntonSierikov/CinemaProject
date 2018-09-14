using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using MovieDomain.Entities;
using MovieDomain.Abstract;

namespace MovieDomain.AuthEntities 
{
    public class Comment : DbObject<int>
    {
        [Required]
        [StringLength(300)]
        public string Text { get; set; }

        public DateTime? AddComment{ get; set;}

        public DateTime? LastChange { get; set; }

        public int Vote { get; set; }

        public int FK_User { get; set; }

        public User User { get; set; }

        public int? FK_Movie { get; set; }

        [ForeignKey("FK_Movie")]
        public Movie movie { get; set; }

        public IList<Comment> UnderComments { get; set; }

        public int? FK_ParentComment { get; set; }

        [ForeignKey("FK_ParentComment")]
        public Comment ParentComment { get; set; }

        //----------------------------------------------------------------//

        public Comment()
        {
            UnderComments = new List<Comment>();
        }

        //----------------------------------------------------------------//

        public Comment(string comment, User users )
            : this()
        {
            Text = comment;
            AddComment = DateTime.Now;
            //users.Comments.Add(this);
            User = users;
            FK_User = User.Id;
        }

        //----------------------------------------------------------------//

        public Comment(string comment, User users, Movie movie )
            : this(comment, users)
        {
            UnderComments = new List<Comment>();
            this.movie = movie;
            movie?.Comments.Add(this);
            FK_Movie = movie.Id;
        }

        //----------------------------------------------------------------//

        public Comment(string comment, User users, Comment parentComment)
            :this(comment, users)
        {
            parentComment?.UnderComments.Add(this);
            ParentComment = parentComment;
            FK_ParentComment = parentComment.Id;
            FK_Movie = parentComment.FK_Movie;
            movie = parentComment.movie;
        }

        //----------------------------------------------------------------//

        public bool Equals(Comment comment)
        {
            if(comment != null)
            {
                return comment.Text == Text
                    && AddComment == comment.AddComment;
            }
            return false;
        }

        //----------------------------------------------------------------//

    }
}
