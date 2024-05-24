using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	// Token: 0x02000620 RID: 1568
	[ComVisible(true)]
	[Serializable]
	public class TargetException : ApplicationException
	{
		// Token: 0x060048AD RID: 18605 RVA: 0x0010782F File Offset: 0x00105A2F
		public TargetException()
		{
			base.SetErrorCode(-2146232829);
		}

		// Token: 0x060048AE RID: 18606 RVA: 0x00107842 File Offset: 0x00105A42
		public TargetException(string message) : base(message)
		{
			base.SetErrorCode(-2146232829);
		}

		// Token: 0x060048AF RID: 18607 RVA: 0x00107856 File Offset: 0x00105A56
		public TargetException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232829);
		}

		// Token: 0x060048B0 RID: 18608 RVA: 0x0010786B File Offset: 0x00105A6B
		protected TargetException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
