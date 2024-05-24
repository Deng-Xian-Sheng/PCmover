using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace RestSharp.Extensions
{
	// Token: 0x0200004A RID: 74
	public static class ResponseStatusExtensions
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x0000BCEC File Offset: 0x00009EEC
		[NullableContext(1)]
		public static WebException ToWebException(this ResponseStatus responseStatus)
		{
			switch (responseStatus)
			{
			case ResponseStatus.None:
				return new WebException("The request could not be processed.", WebExceptionStatus.ServerProtocolViolation);
			case ResponseStatus.Error:
				return new WebException("An error occurred while processing the request.", WebExceptionStatus.ServerProtocolViolation);
			case ResponseStatus.TimedOut:
				return new WebException("The request timed-out.", WebExceptionStatus.Timeout);
			case ResponseStatus.Aborted:
				return new WebException("The request was aborted.", WebExceptionStatus.Timeout);
			}
			throw new ArgumentOutOfRangeException("responseStatus");
		}
	}
}
