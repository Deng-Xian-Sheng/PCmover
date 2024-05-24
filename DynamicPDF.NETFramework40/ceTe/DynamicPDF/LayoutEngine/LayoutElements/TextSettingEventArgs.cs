using System;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000957 RID: 2391
	public class TextSettingEventArgs : EventArgs
	{
		// Token: 0x0600613F RID: 24895 RVA: 0x00363004 File Offset: 0x00362004
		internal TextSettingEventArgs(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x17000A93 RID: 2707
		// (get) Token: 0x06006140 RID: 24896 RVA: 0x00363018 File Offset: 0x00362018
		// (set) Token: 0x06006141 RID: 24897 RVA: 0x00363030 File Offset: 0x00362030
		public string Text
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x04003230 RID: 12848
		private string a;
	}
}
