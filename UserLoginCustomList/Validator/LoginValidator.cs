using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginCustomList.Validator
{
    public class LoginValidator
    {
        private string _Username;

        private string _Password;

        private string _ErrorMessage;

        private DateTime _StartOfLoginAttempts;

        private int _UsernameAttemptsCount;

        private int _PassowrdAttemptsCount;

        public delegate void ActionOnError(string errorMessage);

        private ActionOnError _ErrorAction;

        private LoginValidator(String username, String password, ActionOnError action)
        {
            _Username = username;
            _Password = password;
            _ErrorAction = action;
            _StartOfLoginAttempts = DateTime.Now;
            _UsernameAttemptsCount = 0;
            _PassowrdAttemptsCount = 0;
        }

        public static LoginValidator From(String username, String password, ActionOnError action)
        {
            return new LoginValidator(username, password, action);
        }

        public bool ValidCredentials()
        {
            return IsUsernameValid() && IsPasswordValid();
        }

        public bool LoginAttemptsExceeded()
        {
            DateTime now = DateTime.Now;

            return (_UsernameAttemptsCount > 2 || _PassowrdAttemptsCount > 2) && ((now - _StartOfLoginAttempts).Minutes <= 2);
        }

        private bool IsUsernameValid()
        {
            if (_Username.Equals(String.Empty) || _Username.Length < 5)
            {
                _UsernameAttemptsCount += 1;
                _ErrorMessage = "Username field is mandatory with minimal lenght of 5";

                _ErrorAction(_ErrorMessage);

                return false;
            }

            return true;
        }

        private bool IsPasswordValid()
        {
            if (_Password.Equals(String.Empty) || _Password.Length < 5)
            {
                _PassowrdAttemptsCount += 1;
                _ErrorMessage = "Password field is mandatory with minimal lenght of 5";

                _ErrorAction(_ErrorMessage);

                return false;
            }

            return true;
        }
    }
}
