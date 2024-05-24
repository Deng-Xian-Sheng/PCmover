using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Resources
{
	// Token: 0x02000391 RID: 913
	[ComVisible(true)]
	[Serializable]
	public class MissingSatelliteAssemblyException : SystemException
	{
		// Token: 0x06002D02 RID: 11522 RVA: 0x000AA133 File Offset: 0x000A8333
		public MissingSatelliteAssemblyException() : base(Environment.GetResourceString("MissingSatelliteAssembly_Default"))
		{
			base.SetErrorCode(-2146233034);
		}

		// Token: 0x06002D03 RID: 11523 RVA: 0x000AA150 File Offset: 0x000A8350
		public MissingSatelliteAssemblyException(string message) : base(message)
		{
			base.SetErrorCode(-2146233034);
		}

		// Token: 0x06002D04 RID: 11524 RVA: 0x000AA164 File Offset: 0x000A8364
		public MissingSatelliteAssemblyException(string message, string cultureName) : base(message)
		{
			base.SetErrorCode(-2146233034);
			this._cultureName = cultureName;
		}

		// Token: 0x06002D05 RID: 11525 RVA: 0x000AA17F File Offset: 0x000A837F
		public MissingSatelliteAssemblyException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233034);
		}

		// Token: 0x06002D06 RID: 11526 RVA: 0x000AA194 File Offset: 0x000A8394
		protected MissingSatelliteAssemblyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06002D07 RID: 11527 RVA: 0x000AA19E File Offset: 0x000A839E
		public string CultureName
		{
			get
			{
				return this._cultureName;
			}
		}

		// Token: 0x04001226 RID: 4646
		private string _cultureName;
	}
}
