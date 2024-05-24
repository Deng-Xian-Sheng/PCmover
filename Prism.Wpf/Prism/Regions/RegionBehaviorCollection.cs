using System;
using System.Collections;
using System.Collections.Generic;

namespace Prism.Regions
{
	// Token: 0x02000025 RID: 37
	public class RegionBehaviorCollection : IRegionBehaviorCollection, IEnumerable<KeyValuePair<string, IRegionBehavior>>, IEnumerable
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x0000356C File Offset: 0x0000176C
		public RegionBehaviorCollection(IRegion region)
		{
			this.region = region;
		}

		// Token: 0x17000030 RID: 48
		public IRegionBehavior this[string key]
		{
			get
			{
				return this.behaviors[key];
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003594 File Offset: 0x00001794
		public void Add(string key, IRegionBehavior regionBehavior)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (regionBehavior == null)
			{
				throw new ArgumentNullException("regionBehavior");
			}
			if (this.behaviors.ContainsKey(key))
			{
				throw new ArgumentException("Could not add duplicate behavior with same key.", "key");
			}
			this.behaviors.Add(key, regionBehavior);
			regionBehavior.Region = this.region;
			regionBehavior.Attach();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000035FA File Offset: 0x000017FA
		public bool ContainsKey(string key)
		{
			return this.behaviors.ContainsKey(key);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00003608 File Offset: 0x00001808
		public IEnumerator<KeyValuePair<string, IRegionBehavior>> GetEnumerator()
		{
			return this.behaviors.GetEnumerator();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00003608 File Offset: 0x00001808
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.behaviors.GetEnumerator();
		}

		// Token: 0x0400001E RID: 30
		private readonly IRegion region;

		// Token: 0x0400001F RID: 31
		private readonly Dictionary<string, IRegionBehavior> behaviors = new Dictionary<string, IRegionBehavior>();
	}
}
