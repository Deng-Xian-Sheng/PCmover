using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	// Token: 0x020005EE RID: 1518
	[ComVisible(true)]
	[Serializable]
	public class InvalidFilterCriteriaException : ApplicationException
	{
		// Token: 0x0600465B RID: 18011 RVA: 0x001025A9 File Offset: 0x001007A9
		public InvalidFilterCriteriaException() : base(Environment.GetResourceString("Arg_InvalidFilterCriteriaException"))
		{
			base.SetErrorCode(-2146232831);
		}

		// Token: 0x0600465C RID: 18012 RVA: 0x001025C6 File Offset: 0x001007C6
		public InvalidFilterCriteriaException(string message) : base(message)
		{
			base.SetErrorCode(-2146232831);
		}

		// Token: 0x0600465D RID: 18013 RVA: 0x001025DA File Offset: 0x001007DA
		public InvalidFilterCriteriaException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232831);
		}

		// Token: 0x0600465E RID: 18014 RVA: 0x001025EF File Offset: 0x001007EF
		protected InvalidFilterCriteriaException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
