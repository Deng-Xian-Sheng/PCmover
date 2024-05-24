using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000083 RID: 131
	public class GridLengthAnimation : AnimationTimeline
	{
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x0001CC49 File Offset: 0x0001AE49
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x0001CC5B File Offset: 0x0001AE5B
		public GridLength From
		{
			get
			{
				return (GridLength)base.GetValue(GridLengthAnimation.FromProperty);
			}
			set
			{
				base.SetValue(GridLengthAnimation.FromProperty, value);
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x0001CC6E File Offset: 0x0001AE6E
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x0001CC80 File Offset: 0x0001AE80
		public GridLength To
		{
			get
			{
				return (GridLength)base.GetValue(GridLengthAnimation.ToProperty);
			}
			set
			{
				base.SetValue(GridLengthAnimation.ToProperty, value);
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x0001CC93 File Offset: 0x0001AE93
		public override Type TargetPropertyType
		{
			get
			{
				return typeof(GridLength);
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0001CCA0 File Offset: 0x0001AEA0
		public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
		{
			GridLength gridLength = (GridLength)base.GetValue(GridLengthAnimation.FromProperty);
			GridLength gridLength2 = (GridLength)base.GetValue(GridLengthAnimation.ToProperty);
			if (gridLength.GridUnitType != gridLength2.GridUnitType)
			{
				return gridLength2;
			}
			double value = gridLength.Value;
			double value2 = gridLength2.Value;
			if (value > value2)
			{
				return new GridLength((1.0 - animationClock.CurrentProgress.Value) * (value - value2) + value2, GridUnitType.Star);
			}
			return new GridLength(animationClock.CurrentProgress.Value * (value2 - value) + value, GridUnitType.Star);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0001CD45 File Offset: 0x0001AF45
		protected override Freezable CreateInstanceCore()
		{
			return new GridLengthAnimation();
		}

		// Token: 0x040002CD RID: 717
		public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(GridLength), typeof(GridLengthAnimation));

		// Token: 0x040002CE RID: 718
		public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(GridLength), typeof(GridLengthAnimation));
	}
}
