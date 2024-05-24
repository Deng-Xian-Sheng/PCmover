using System;
using System.Windows;

namespace Prism.Regions
{
	// Token: 0x02000008 RID: 8
	internal class DefaultRegionManagerAccessor : IRegionManagerAccessor
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000023 RID: 35 RVA: 0x00002462 File Offset: 0x00000662
		// (remove) Token: 0x06000024 RID: 36 RVA: 0x0000246A File Offset: 0x0000066A
		public event EventHandler UpdatingRegions
		{
			add
			{
				RegionManager.UpdatingRegions += value;
			}
			remove
			{
				RegionManager.UpdatingRegions -= value;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002472 File Offset: 0x00000672
		public string GetRegionName(DependencyObject element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return element.GetValue(RegionManager.RegionNameProperty) as string;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002492 File Offset: 0x00000692
		public IRegionManager GetRegionManager(DependencyObject element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return element.GetValue(RegionManager.RegionManagerProperty) as IRegionManager;
		}
	}
}
