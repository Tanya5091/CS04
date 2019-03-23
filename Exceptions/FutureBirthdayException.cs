using System;

namespace CS4.Exceptions
{
	class FutureBirthdayException : Exception
	{
		private string _title;
		private string _body;
		public FutureBirthdayException(DateTime date)

			: base($"Birth date is out of range {date.Date}")

		{

			Body = "You were not born yet";
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
