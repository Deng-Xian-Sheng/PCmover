using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000643 RID: 1603
	[ComVisible(true)]
	[Serializable]
	public struct Label
	{
		// Token: 0x06004B00 RID: 19200 RVA: 0x0010FD3C File Offset: 0x0010DF3C
		internal Label(int label)
		{
			this.m_label = label;
		}

		// Token: 0x06004B01 RID: 19201 RVA: 0x0010FD45 File Offset: 0x0010DF45
		internal int GetLabelValue()
		{
			return this.m_label;
		}

		// Token: 0x06004B02 RID: 19202 RVA: 0x0010FD4D File Offset: 0x0010DF4D
		public override int GetHashCode()
		{
			return this.m_label;
		}

		// Token: 0x06004B03 RID: 19203 RVA: 0x0010FD55 File Offset: 0x0010DF55
		public override bool Equals(object obj)
		{
			return obj is Label && this.Equals((Label)obj);
		}

		// Token: 0x06004B04 RID: 19204 RVA: 0x0010FD6D File Offset: 0x0010DF6D
		public bool Equals(Label obj)
		{
			return obj.m_label == this.m_label;
		}

		// Token: 0x06004B05 RID: 19205 RVA: 0x0010FD7D File Offset: 0x0010DF7D
		public static bool operator ==(Label a, Label b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004B06 RID: 19206 RVA: 0x0010FD87 File Offset: 0x0010DF87
		public static bool operator !=(Label a, Label b)
		{
			return !(a == b);
		}

		// Token: 0x04001EFE RID: 7934
		internal int m_label;
	}
}
