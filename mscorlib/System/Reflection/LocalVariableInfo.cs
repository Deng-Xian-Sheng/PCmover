using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000613 RID: 1555
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public class LocalVariableInfo
	{
		// Token: 0x06004806 RID: 18438 RVA: 0x00105FE6 File Offset: 0x001041E6
		[__DynamicallyInvokable]
		protected LocalVariableInfo()
		{
		}

		// Token: 0x06004807 RID: 18439 RVA: 0x00105FF0 File Offset: 0x001041F0
		[__DynamicallyInvokable]
		public override string ToString()
		{
			string text = this.LocalType.ToString() + " (" + this.LocalIndex.ToString() + ")";
			if (this.IsPinned)
			{
				text += " (pinned)";
			}
			return text;
		}

		// Token: 0x17000B22 RID: 2850
		// (get) Token: 0x06004808 RID: 18440 RVA: 0x0010603B File Offset: 0x0010423B
		[__DynamicallyInvokable]
		public virtual Type LocalType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x17000B23 RID: 2851
		// (get) Token: 0x06004809 RID: 18441 RVA: 0x00106043 File Offset: 0x00104243
		[__DynamicallyInvokable]
		public virtual bool IsPinned
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_isPinned != 0;
			}
		}

		// Token: 0x17000B24 RID: 2852
		// (get) Token: 0x0600480A RID: 18442 RVA: 0x0010604E File Offset: 0x0010424E
		[__DynamicallyInvokable]
		public virtual int LocalIndex
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_localIndex;
			}
		}

		// Token: 0x04001DD6 RID: 7638
		private RuntimeType m_type;

		// Token: 0x04001DD7 RID: 7639
		private int m_isPinned;

		// Token: 0x04001DD8 RID: 7640
		private int m_localIndex;
	}
}
