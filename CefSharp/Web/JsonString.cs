using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CefSharp.Web
{
	// Token: 0x020000A2 RID: 162
	public class JsonString
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x00007FDB File Offset: 0x000061DB
		// (set) Token: 0x060004FD RID: 1277 RVA: 0x00007FE3 File Offset: 0x000061E3
		public string Json { get; private set; }

		// Token: 0x060004FE RID: 1278 RVA: 0x00007FEC File Offset: 0x000061EC
		public JsonString(string json)
		{
			if (json == null)
			{
				throw new ArgumentNullException("json");
			}
			this.Json = json;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00008009 File Offset: 0x00006209
		public override string ToString()
		{
			return this.Json;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00008014 File Offset: 0x00006214
		public static JsonString FromObject(object obj, DataContractJsonSerializerSettings settings = null)
		{
			if (obj == null)
			{
				return null;
			}
			JsonString result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(obj.GetType(), settings);
				dataContractJsonSerializer.WriteObject(memoryStream, obj);
				string @string = Encoding.UTF8.GetString(memoryStream.ToArray());
				if (string.IsNullOrEmpty(@string))
				{
					result = null;
				}
				else
				{
					result = new JsonString(@string);
				}
			}
			return result;
		}
	}
}
