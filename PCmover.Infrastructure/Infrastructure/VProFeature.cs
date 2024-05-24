using System;

namespace PCmover.Infrastructure
{
	// Token: 0x02000040 RID: 64
	public class VProFeature
	{
		// Token: 0x0600033F RID: 831 RVA: 0x000089F1 File Offset: 0x00006BF1
		public VProFeature(Type vProView)
		{
			this.VProView = vProView;
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00008A00 File Offset: 0x00006C00
		public bool ShowVProLink
		{
			get
			{
				return this.VProView != null;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000341 RID: 833 RVA: 0x00008A0E File Offset: 0x00006C0E
		// (set) Token: 0x06000342 RID: 834 RVA: 0x00008A16 File Offset: 0x00006C16
		public Type VProView { get; set; }
	}
}
