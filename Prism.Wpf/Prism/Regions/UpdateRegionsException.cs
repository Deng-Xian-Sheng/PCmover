using System;
using System.Runtime.Serialization;

namespace Prism.Regions
{
	// Token: 0x02000034 RID: 52
	[Serializable]
	public class UpdateRegionsException : Exception
	{
		// Token: 0x06000159 RID: 345 RVA: 0x00004844 File Offset: 0x00002A44
		public UpdateRegionsException()
		{
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000484C File Offset: 0x00002A4C
		public UpdateRegionsException(string message) : base(message)
		{
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004855 File Offset: 0x00002A55
		public UpdateRegionsException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000485F File Offset: 0x00002A5F
		protected UpdateRegionsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
