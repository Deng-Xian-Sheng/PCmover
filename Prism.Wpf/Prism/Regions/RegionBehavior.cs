using System;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x02000024 RID: 36
	public abstract class RegionBehavior : IRegionBehavior
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00003515 File Offset: 0x00001715
		// (set) Token: 0x060000DE RID: 222 RVA: 0x0000351D File Offset: 0x0000171D
		public IRegion Region
		{
			get
			{
				return this.region;
			}
			set
			{
				if (this.IsAttached)
				{
					throw new InvalidOperationException(Resources.RegionBehaviorRegionCannotBeSetAfterAttach);
				}
				this.region = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00003539 File Offset: 0x00001739
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00003541 File Offset: 0x00001741
		public bool IsAttached { get; private set; }

		// Token: 0x060000E1 RID: 225 RVA: 0x0000354A File Offset: 0x0000174A
		public void Attach()
		{
			if (this.region == null)
			{
				throw new InvalidOperationException(Resources.RegionBehaviorAttachCannotBeCallWithNullRegion);
			}
			this.IsAttached = true;
			this.OnAttach();
		}

		// Token: 0x060000E2 RID: 226
		protected abstract void OnAttach();

		// Token: 0x0400001C RID: 28
		private IRegion region;
	}
}
