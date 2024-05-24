using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Prism.Regions.Behaviors
{
	// Token: 0x02000039 RID: 57
	public class AutoPopulateRegionBehavior : RegionBehavior
	{
		// Token: 0x06000181 RID: 385 RVA: 0x00004DEA File Offset: 0x00002FEA
		public AutoPopulateRegionBehavior(IRegionViewRegistry regionViewRegistry)
		{
			this.regionViewRegistry = regionViewRegistry;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00004DF9 File Offset: 0x00002FF9
		protected override void OnAttach()
		{
			if (string.IsNullOrEmpty(base.Region.Name))
			{
				base.Region.PropertyChanged += this.Region_PropertyChanged;
				return;
			}
			this.StartPopulatingContent();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00004E2C File Offset: 0x0000302C
		private void StartPopulatingContent()
		{
			foreach (object viewToAdd in this.CreateViewsToAutoPopulate())
			{
				this.AddViewIntoRegion(viewToAdd);
			}
			this.regionViewRegistry.ContentRegistered += this.OnViewRegistered;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00004E94 File Offset: 0x00003094
		protected virtual IEnumerable<object> CreateViewsToAutoPopulate()
		{
			return this.regionViewRegistry.GetContents(base.Region.Name);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00004EAC File Offset: 0x000030AC
		protected virtual void AddViewIntoRegion(object viewToAdd)
		{
			base.Region.Add(viewToAdd);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00004EBC File Offset: 0x000030BC
		private void Region_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Name" && !string.IsNullOrEmpty(base.Region.Name))
			{
				base.Region.PropertyChanged -= this.Region_PropertyChanged;
				this.StartPopulatingContent();
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00004F0A File Offset: 0x0000310A
		public virtual void OnViewRegistered(object sender, ViewRegisteredEventArgs e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (e.RegionName == base.Region.Name)
			{
				this.AddViewIntoRegion(e.GetView());
			}
		}

		// Token: 0x04000049 RID: 73
		public const string BehaviorKey = "AutoPopulate";

		// Token: 0x0400004A RID: 74
		private readonly IRegionViewRegistry regionViewRegistry;
	}
}
