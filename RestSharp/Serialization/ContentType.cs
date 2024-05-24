using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RestSharp.Serialization
{
	// Token: 0x0200003B RID: 59
	[NullableContext(1)]
	[Nullable(0)]
	public static class ContentType
	{
		// Token: 0x04000116 RID: 278
		public const string Json = "application/json";

		// Token: 0x04000117 RID: 279
		public const string Xml = "application/xml";

		// Token: 0x04000118 RID: 280
		public static readonly Dictionary<DataFormat, string> FromDataFormat = new Dictionary<DataFormat, string>
		{
			{
				DataFormat.Xml,
				"application/xml"
			},
			{
				DataFormat.Json,
				"application/json"
			}
		};

		// Token: 0x04000119 RID: 281
		public static readonly string[] JsonAccept = new string[]
		{
			"application/json",
			"text/json",
			"text/x-json",
			"text/javascript",
			"*+json"
		};

		// Token: 0x0400011A RID: 282
		public static readonly string[] XmlAccept = new string[]
		{
			"application/xml",
			"text/xml",
			"*+xml",
			"*"
		};
	}
}
