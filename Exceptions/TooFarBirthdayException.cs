using System;

namespace CS4.Exceptions
{
	class TooFarBirthdayException : Exception
	{
		private string _title;
		private string _body;
		public TooFarBirthdayException(DateTime date)

			: base($"Birth date is out of range {date.Date}")

		{

			Body = "You are too old";
			Title = "Birthday out of range exception";
		}


		public string Title
		{
			get { return _title; }
			private set => _title = value;
		}

		public string Body
		{
			get { return _body; }
			private set => _body = value;
		}
	}
}
