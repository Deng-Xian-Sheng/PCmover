using System;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008E3 RID: 2275
	[Serializable]
	public sealed class RuntimeWrappedException : Exception
	{
		// Token: 0x06005DDE RID: 24030 RVA: 0x00149976 File Offset: 0x00147B76
		private RuntimeWrappedException(object thrownObject) : base(Environment.GetResourceString("RuntimeWrappedException"))
		{
			base.SetErrorCode(-2146233026);
			this.m_wrappedException = thrownObject;
		}

		// Token: 0x17001021 RID: 4129
		// (get) Token: 0x06005DDF RID: 24031 RVA: 0x0014999A File Offset: 0x00147B9A
		public object WrappedException
		{
			get
			{
				return this.m_wrappedException;
			}
		}

		// Token: 0x06005DE0 RID: 24032 RVA: 0x001499A2 File Offset: 0x00147BA2
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("WrappedException", this.m_wrappedException, typeof(object));
		}

		// Token: 0x06005DE1 RID: 24033 RVA: 0x001499D5 File Offset: 0x00147BD5
		internal RuntimeWrappedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.m_wrappedException = info.GetValue("WrappedException", typeof(object));
		}

		// Token: 0x04002A36 RID: 10806
		private object m_wrappedException;
	}
}
