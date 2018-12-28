using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.ValidationMessages
{
    public static class UserValidationMessage
    {
        public const string UserNotAdded = "Some error ocurred. User hasn't added!";

        //----------------------------------------------------------------//
            
        public static string EmailExist(string email) => $"Email {email} already taken";

    }
}
