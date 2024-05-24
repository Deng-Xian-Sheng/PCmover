using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000BA RID: 186
	public class StylizedBehaviors
	{
		// Token: 0x06000A15 RID: 2581 RVA: 0x00027065 File Offset: 0x00025265
		[Category("MahApps.Metro")]
		public static StylizedBehaviorCollection GetBehaviors(DependencyObject uie)
		{
			return (StylizedBehaviorCollection)uie.GetValue(StylizedBehaviors.BehaviorsProperty);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00027077 File Offset: 0x00025277
		public static void SetBehaviors(DependencyObject uie, StylizedBehaviorCollection value)
		{
			uie.SetValue(StylizedBehaviors.BehaviorsProperty, value);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00027088 File Offset: 0x00025288
		private static void OnPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = dpo as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			StylizedBehaviorCollection stylizedBehaviorCollection = e.NewValue as StylizedBehaviorCollection;
			StylizedBehaviorCollection stylizedBehaviorCollection2 = e.OldValue as StylizedBehaviorCollection;
			if (stylizedBehaviorCollection == stylizedBehaviorCollection2)
			{
				return;
			}
			BehaviorCollection behaviors = Interaction.GetBehaviors(frameworkElement);
			frameworkElement.Unloaded -= StylizedBehaviors.FrameworkElementUnloaded;
			if (stylizedBehaviorCollection2 != null)
			{
				foreach (Behavior behavior in stylizedBehaviorCollection2)
				{
					int indexOf = StylizedBehaviors.GetIndexOf(behaviors, behavior);
					if (indexOf >= 0)
					{
						behaviors.RemoveAt(indexOf);
					}
				}
			}
			if (stylizedBehaviorCollection != null)
			{
				foreach (Behavior behavior2 in stylizedBehaviorCollection)
				{
					if (StylizedBehaviors.GetIndexOf(behaviors, behavior2) < 0)
					{
						Behavior behavior3 = (Behavior)behavior2.Clone();
						StylizedBehaviors.SetOriginalBehavior(behavior3, behavior2);
						behaviors.Add(behavior3);
					}
				}
			}
			if (behaviors.Count > 0)
			{
				frameworkElement.Unloaded += StylizedBehaviors.FrameworkElementUnloaded;
			}
			frameworkElement.Dispatcher.ShutdownStarted += StylizedBehaviors.Dispatcher_ShutdownStarted;
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x000271C8 File Offset: 0x000253C8
		private static void Dispatcher_ShutdownStarted(object sender, EventArgs e)
		{
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x000271CC File Offset: 0x000253CC
		private static void FrameworkElementUnloaded(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			foreach (Behavior behavior in Interaction.GetBehaviors(frameworkElement))
			{
				behavior.Detach();
			}
			frameworkElement.Loaded += StylizedBehaviors.FrameworkElementLoaded;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0002723C File Offset: 0x0002543C
		private static void FrameworkElementLoaded(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			if (frameworkElement == null)
			{
				return;
			}
			frameworkElement.Loaded -= StylizedBehaviors.FrameworkElementLoaded;
			foreach (Behavior behavior in Interaction.GetBehaviors(frameworkElement))
			{
				behavior.Attach(frameworkElement);
			}
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x000272AC File Offset: 0x000254AC
		private static int GetIndexOf(BehaviorCollection itemBehaviors, Behavior behavior)
		{
			int result = -1;
			Behavior originalBehavior = StylizedBehaviors.GetOriginalBehavior(behavior);
			for (int i = 0; i < itemBehaviors.Count; i++)
			{
				Behavior behavior2 = itemBehaviors[i];
				if (behavior2 == behavior || behavior2 == originalBehavior)
				{
					result = i;
					break;
				}
				Behavior originalBehavior2 = StylizedBehaviors.GetOriginalBehavior(behavior2);
				if (originalBehavior2 == behavior || originalBehavior2 == originalBehavior)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x000272FE File Offset: 0x000254FE
		private static Behavior GetOriginalBehavior(DependencyObject obj)
		{
			return obj.GetValue(StylizedBehaviors.OriginalBehaviorProperty) as Behavior;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00027310 File Offset: 0x00025510
		private static void SetOriginalBehavior(DependencyObject obj, Behavior value)
		{
			obj.SetValue(StylizedBehaviors.OriginalBehaviorProperty, value);
		}

		// Token: 0x0400046D RID: 1133
		public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.RegisterAttached("Behaviors", typeof(StylizedBehaviorCollection), typeof(StylizedBehaviors), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(StylizedBehaviors.OnPropertyChanged)));

		// Token: 0x0400046E RID: 1134
		private static readonly DependencyProperty OriginalBehaviorProperty = DependencyProperty.RegisterAttached("OriginalBehavior", typeof(Behavior), typeof(StylizedBehaviors), new UIPropertyMetadata(null));
	}
}
