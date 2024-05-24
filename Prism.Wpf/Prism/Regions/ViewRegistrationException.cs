using System;
using System.Runtime.Serialization;

namespace Prism.Regions
{
	// Token: 0x02000036 RID: 54
	[Serializable]
	public class ViewRegistrationException : Exception
	{
		// Token: 0x06000162 RID: 354 RVA: 0x00004844 File Offset: 0x00002A44
		public ViewRegistrationException()
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000484C File Offset: 0x00002A4C
		public ViewRegistrationException(string message) : base(message)
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004855 File Offset: 0x00002A55
		public ViewRegistrationException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000485F File Offset: 0x00002A5F
		protected ViewRegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
