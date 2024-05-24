using System;
using System.Windows;

namespace Prism.Regions
{
	// Token: 0x0200001A RID: 26
	public class ItemMetadata : DependencyObject
	{
		// Token: 0x06000080 RID: 128 RVA: 0x000024B2 File Offset: 0x000006B2
		public ItemMetadata(object item)
		{
			this.Item = item;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000024C1 File Offset: 0x000006C1
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000024C9 File Offset: 0x000006C9
		public object Item { get; private set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000024D2 File Offset: 0x000006D2
		// (set) Token: 0x06000084 RID: 132 RVA: 0x000024E4 File Offset: 0x000006E4
		public string Name
		{
			get
			{
				return (string)base.GetValue(ItemMetadata.NameProperty);
			}
			set
			{
				base.SetValue(ItemMetadata.NameProperty, value);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000024F2 File Offset: 0x000006F2
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00002504 File Offset: 0x00000704
		public bool IsActive
		{
			get
			{
				return (bool)base.GetValue(ItemMetadata.IsActiveProperty);
			}
			set
			{
				base.SetValue(ItemMetadata.IsActiveProperty, value);
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000087 RID: 135 RVA: 0x00002518 File Offset: 0x00000718
		// (remove) Token: 0x06000088 RID: 136 RVA: 0x00002550 File Offset: 0x00000750
		public event EventHandler MetadataChanged;

		// Token: 0x06000089 RID: 137 RVA: 0x00002588 File Offset: 0x00000788
		public void InvokeMetadataChanged()
		{
			EventHandler metadataChanged = this.MetadataChanged;
			if (metadataChanged != null)
			{
				metadataChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000025AC File Offset: 0x000007AC
		private static void DependencyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			ItemMetadata itemMetadata = dependencyObject as ItemMetadata;
			if (itemMetadata != null)
			{
				itemMetadata.InvokeMetadataChanged();
			}
		}

		// Token: 0x04000005 RID: 5
		public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ItemMetadata), null);

		// Token: 0x04000006 RID: 6
		public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(ItemMetadata), new PropertyMetadata(new PropertyChangedCallback(ItemMetadata.DependencyPropertyChanged)));
	}
}
