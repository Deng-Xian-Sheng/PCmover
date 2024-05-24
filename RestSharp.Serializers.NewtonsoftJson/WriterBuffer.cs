using System;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace RestSharp.Serializers.NewtonsoftJson
{
	// Token: 0x02000005 RID: 5
	public sealed class WriterBuffer : IDisposable
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000022B0 File Offset: 0x000004B0
		public WriterBuffer(JsonSerializer jsonSerializer)
		{
			this._stringWriter = new StringWriter(new StringBuilder(256), CultureInfo.InvariantCulture);
			this._jsonTextWriter = new JsonTextWriter(this._stringWriter)
			{
				Formatting = jsonSerializer.Formatting,
				CloseOutput = false
			};
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002301 File Offset: 0x00000501
		public JsonTextWriter GetJsonTextWriter()
		{
			return this._jsonTextWriter;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002309 File Offset: 0x00000509
		public StringWriter GetStringWriter()
		{
			return this._stringWriter;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002311 File Offset: 0x00000511
		public void Dispose()
		{
			this._stringWriter.GetStringBuilder().Clear();
		}

		// Token: 0x04000007 RID: 7
		private readonly StringWriter _stringWriter;

		// Token: 0x04000008 RID: 8
		private readonly JsonTextWriter _jsonTextWriter;
	}
}
