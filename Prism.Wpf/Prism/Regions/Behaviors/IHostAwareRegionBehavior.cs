using System;
using System.Windows;

namespace Prism.Regions.Behaviors
{
	// Token: 0x0200003D RID: 61
	public interface IHostAwareRegionBehavior : IRegionBehavior
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001A6 RID: 422
		// (set) Token: 0x060001A7 RID: 423
		DependencyObject HostControl { get; set; }
	}
}
