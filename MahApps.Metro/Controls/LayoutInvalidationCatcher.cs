using System;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200005B RID: 91
	public class LayoutInvalidationCatcher : Decorator
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0000FB92 File Offset: 0x0000DD92
		public Planerator PlaParent
		{
			get
			{
				return base.Parent as Planerator;
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000FBA0 File Offset: 0x0000DDA0
		protected override Size MeasureOverride(Size constraint)
		{
			Planerator plaParent = this.PlaParent;
			if (plaParent != null)
			{
				plaParent.InvalidateMeasure();
			}
			return base.MeasureOverride(constraint);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000FBC4 File Offset: 0x0000DDC4
		protected override Size ArrangeOverride(Size arrangeSize)
		{
			Planerator plaParent = this.PlaParent;
			if (plaParent != null)
			{
				plaParent.InvalidateArrange();
			}
			return base.ArrangeOverride(arrangeSize);
		}
	}
}
