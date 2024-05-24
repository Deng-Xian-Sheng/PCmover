using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000639 RID: 1593
	[ComVisible(true)]
	[Serializable]
	public struct EventToken
	{
		// Token: 0x06004A6B RID: 19051 RVA: 0x0010D449 File Offset: 0x0010B649
		internal EventToken(int str)
		{
			this.m_event = str;
		}

		// Token: 0x17000BA0 RID: 2976
		// (get) Token: 0x06004A6C RID: 19052 RVA: 0x0010D452 File Offset: 0x0010B652
		public int Token
		{
			get
			{
				return this.m_event;
			}
		}

		// Token: 0x06004A6D RID: 19053 RVA: 0x0010D45A File Offset: 0x0010B65A
		public override int GetHashCode()
		{
			return this.m_event;
		}

		// Token: 0x06004A6E RID: 19054 RVA: 0x0010D462 File Offset: 0x0010B662
		public override bool Equals(object obj)
		{
			return obj is EventToken && this.Equals((EventToken)obj);
		}

		// Token: 0x06004A6F RID: 19055 RVA: 0x0010D47A File Offset: 0x0010B67A
		public bool Equals(EventToken obj)
		{
			return obj.m_event == this.m_event;
		}

		// Token: 0x06004A70 RID: 19056 RVA: 0x0010D48A File Offset: 0x0010B68A
		public static bool operator ==(EventToken a, EventToken b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004A71 RID: 19057 RVA: 0x0010D494 File Offset: 0x0010B694
		public static bool operator !=(EventToken a, EventToken b)
		{
			return !(a == b);
		}

		// Token: 0x04001EAC RID: 7852
		public static readonly EventToken Empty;

		// Token: 0x04001EAD RID: 7853
		internal int m_event;
	}
}
