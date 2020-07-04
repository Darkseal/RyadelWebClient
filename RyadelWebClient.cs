using System;
using System.Net;

namespace Ryadel.Components.Web
{
	/// <summary>
	/// An extension of the standard System.Net.WebClient
	/// featuring a customizable constructor and [Timeout] property.
	/// </summary>
	public class RyadelWebClient : WebClient
	{
		/// <summary>
		/// Default constructor (30000 ms timeout)
		/// NOTE: timeout can be changed later on using the [Timeout] property.
		/// </summary>
		public RyadelWebClient() : this(30000) { }

		/// <summary>
		/// Constructor with customizable timeout
		/// </summary>
		/// <param name="timeout">
		/// Web request timeout (in milliseconds)
		/// </param>
		public RyadelWebClient(int timeout)
		{
			Timeout = timeout;
		}

		#region Methods
		protected override WebRequest GetWebRequest(Uri uri)
		{
			WebRequest w = base.GetWebRequest(uri);
			w.Timeout = Timeout;
			return w;
		}
		#endregion

		/// <summary>
		/// Web request timeout (in milliseconds)
		/// </summary>
		public int Timeout { get; set; }
	}
}