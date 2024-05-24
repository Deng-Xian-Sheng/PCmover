using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ControlzEx;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000033 RID: 51
	[StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(Flyout))]
	public class FlyoutsControl : ItemsControl
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00009733 File Offset: 0x00007933
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00009745 File Offset: 0x00007945
		public MouseButton? OverrideExternalCloseButton
		{
			get
			{
				return (MouseButton?)base.GetValue(FlyoutsControl.OverrideExternalCloseButtonProperty);
			}
			set
			{
				base.SetValue(FlyoutsControl.OverrideExternalCloseButtonProperty, value);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00009758 File Offset: 0x00007958
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x0000976A File Offset: 0x0000796A
		public bool OverrideIsPinned
		{
			get
			{
				return (bool)base.GetValue(FlyoutsControl.OverrideIsPinnedProperty);
			}
			set
			{
				base.SetValue(FlyoutsControl.OverrideIsPinnedProperty, value);
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00009780 File Offset: 0x00007980
		static FlyoutsControl()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(FlyoutsControl), new FrameworkPropertyMetadata(typeof(FlyoutsControl)));
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00009807 File Offset: 0x00007A07
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new Flyout();
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000980E File Offset: 0x00007A0E
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is Flyout;
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000981C File Offset: 0x00007A1C
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			Flyout flyout = element as Flyout;
			DataTemplate dataTemplate = (flyout != null) ? flyout.HeaderTemplate : null;
			DataTemplateSelector dataTemplateSelector = (flyout != null) ? flyout.HeaderTemplateSelector : null;
			string text = (flyout != null) ? flyout.HeaderStringFormat : null;
			base.PrepareContainerForItemOverride(element, item);
			if (flyout != null)
			{
				if (dataTemplate != null)
				{
					flyout.SetValue(HeaderedContentControl.HeaderTemplateProperty, dataTemplate);
				}
				if (dataTemplateSelector != null)
				{
					flyout.SetValue(HeaderedContentControl.HeaderTemplateSelectorProperty, dataTemplateSelector);
				}
				if (text != null)
				{
					flyout.SetValue(HeaderedContentControl.HeaderStringFormatProperty, text);
				}
				if (base.ItemTemplate != null && flyout.ContentTemplate == null)
				{
					flyout.SetValue(ContentControl.ContentTemplateProperty, base.ItemTemplate);
				}
				if (base.ItemTemplateSelector != null && flyout.ContentTemplateSelector == null)
				{
					flyout.SetValue(ContentControl.ContentTemplateSelectorProperty, base.ItemTemplateSelector);
				}
				if (base.ItemStringFormat != null && flyout.ContentStringFormat == null)
				{
					flyout.SetValue(ContentControl.ContentStringFormatProperty, base.ItemStringFormat);
				}
			}
			this.AttachHandlers((Flyout)element);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00009901 File Offset: 0x00007B01
		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			((Flyout)element).CleanUp(this);
			base.ClearContainerForItemOverride(element, item);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00009918 File Offset: 0x00007B18
		private void AttachHandlers(Flyout flyout)
		{
			PropertyChangeNotifier propertyChangeNotifier = new PropertyChangeNotifier(flyout, Flyout.IsOpenProperty);
			propertyChangeNotifier.ValueChanged += this.FlyoutStatusChanged;
			flyout.IsOpenPropertyChangeNotifier = propertyChangeNotifier;
			PropertyChangeNotifier propertyChangeNotifier2 = new PropertyChangeNotifier(flyout, Flyout.ThemeProperty);
			propertyChangeNotifier2.ValueChanged += this.FlyoutStatusChanged;
			flyout.ThemePropertyChangeNotifier = propertyChangeNotifier2;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00009970 File Offset: 0x00007B70
		private void FlyoutStatusChanged(object sender, EventArgs e)
		{
			Flyout flyout = this.GetFlyout(sender);
			this.HandleFlyoutStatusChange(flyout, this.TryFindParent<MetroWindow>());
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00009994 File Offset: 0x00007B94
		internal void HandleFlyoutStatusChange(Flyout flyout, MetroWindow parentWindow)
		{
			if (flyout == null || parentWindow == null)
			{
				return;
			}
			this.ReorderZIndices(flyout);
			List<Flyout> visibleFlyouts = (from i in this.GetFlyouts(base.Items)
			where i.IsOpen
			select i).OrderBy(new Func<Flyout, int>(Panel.GetZIndex)).ToList<Flyout>();
			parentWindow.HandleFlyoutStatusChange(flyout, visibleFlyouts);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00009A00 File Offset: 0x00007C00
		private Flyout GetFlyout(object item)
		{
			Flyout flyout = item as Flyout;
			if (flyout != null)
			{
				return flyout;
			}
			return (Flyout)base.ItemContainerGenerator.ContainerFromItem(item);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00009A2A File Offset: 0x00007C2A
		internal IEnumerable<Flyout> GetFlyouts()
		{
			return this.GetFlyouts(base.Items);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00009A38 File Offset: 0x00007C38
		private IEnumerable<Flyout> GetFlyouts(IEnumerable items)
		{
			return from object item in items
			select this.GetFlyout(item);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00009A54 File Offset: 0x00007C54
		private void ReorderZIndices(Flyout lastChanged)
		{
			IEnumerable<Flyout> enumerable = (from i in this.GetFlyouts(base.Items)
			where i.IsOpen && i != lastChanged
			select i).OrderBy(new Func<Flyout, int>(Panel.GetZIndex));
			int num = 0;
			foreach (Flyout element in enumerable)
			{
				Panel.SetZIndex(element, num);
				num++;
			}
			if (lastChanged.IsOpen)
			{
				Panel.SetZIndex(lastChanged, num);
			}
		}

		// Token: 0x040000AA RID: 170
		public static readonly DependencyProperty OverrideExternalCloseButtonProperty = DependencyProperty.Register("OverrideExternalCloseButton", typeof(MouseButton?), typeof(FlyoutsControl), new PropertyMetadata(null));

		// Token: 0x040000AB RID: 171
		public static readonly DependencyProperty OverrideIsPinnedProperty = DependencyProperty.Register("OverrideIsPinned", typeof(bool), typeof(FlyoutsControl), new PropertyMetadata(false));
	}
}
