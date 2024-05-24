using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003B3 RID: 947
	[ComVisible(true)]
	[Serializable]
	public class DaylightTime
	{
		// Token: 0x06002F3B RID: 12091 RVA: 0x000B5894 File Offset: 0x000B3A94
		private DaylightTime()
		{
		}

		// Token: 0x06002F3C RID: 12092 RVA: 0x000B589C File Offset: 0x000B3A9C
		public DaylightTime(DateTime start, DateTime end, TimeSpan delta)
		{
			this.m_start = start;
			this.m_end = end;
			this.m_delta = delta;
		}

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06002F3D RID: 12093 RVA: 0x000B58B9 File Offset: 0x000B3AB9
		public DateTime Start
		{
			get
			{
				return this.m_start;
			}
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06002F3E RID: 12094 RVA: 0x000B58C1 File Offset: 0x000B3AC1
		public DateTime End
		{
			get
			{
				return this.m_end;
			}
		}

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06002F3F RID: 12095 RVA: 0x000B58C9 File Offset: 0x000B3AC9
		public TimeSpan Delta
		{
			get
			{
				return this.m_delta;
			}
		}

		// Token: 0x040013FE RID: 5118
		internal DateTime m_start;

		// Token: 0x040013FF RID: 5119
		internal DateTime m_end;

		// Token: 0x04001400 RID: 5120
		internal TimeSpan m_delta;
	}
}
