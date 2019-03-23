using System;

namespace CS4.Exceptions
{
	class InvalidEmailException : Exception
	{
		private string _title;
		private string _body;

		public InvalidEmailException(string email)

			: base($"Your email is incorrect {email}")

		{

			Body = $"Your email address is incorrect {email}";
			Title = "Invalid Email Exception";
		}


		internal string Title
		{
			get { return _title; }
			private set => _title = value;
		}

		internal string Body
		{
			get { return _body; }
			private set => _body = value;
		}
	}
}
