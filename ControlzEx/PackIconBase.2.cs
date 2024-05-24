using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace ControlzEx
{
	// Token: 0x02000007 RID: 7
	public abstract class PackIconBase<TKind> : PackIconBase
	{
		// Token: 0x0600001F RID: 31 RVA: 0x0000258F File Offset: 0x0000078F
		protected PackIconBase(Func<IDictionary<TKind, string>> dataIndexFactory)
		{
			if (dataIndexFactory == null)
			{
				throw new ArgumentNullException("dataIndexFactory");
			}
			if (PackIconBase<TKind>._dataIndex == null)
			{
				PackIconBase<TKind>._dataIndex = new Lazy<IDictionary<TKind, string>>(dataIndexFactory);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000025B7 File Offset: 0x000007B7
		private static void KindPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((PackIconBase)dependencyObject).UpdateData();
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000025C4 File Offset: 0x000007C4
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000025D6 File Offset: 0x000007D6
		public TKind Kind
		{
			get
			{
				return (TKind)((object)base.GetValue(PackIconBase<TKind>.KindProperty));
			}
			set
			{
				base.SetValue(PackIconBase<TKind>.KindProperty, value);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000025E9 File Offset: 0x000007E9
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000025FB File Offset: 0x000007FB
		[TypeConverter(typeof(GeometryConverter))]
		public string Data
		{
			get
			{
				return (string)base.GetValue(PackIconBase<TKind>.DataProperty);
			}
			private set
			{
				base.SetValue(PackIconBase<TKind>.DataPropertyKey, value);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002609 File Offset: 0x00000809
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.UpdateData();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002618 File Offset: 0x00000818
		internal override void UpdateData()
		{
			string data = null;
			if (PackIconBase<TKind>._dataIndex.Value != null)
			{
				PackIconBase<TKind>._dataIndex.Value.TryGetValue(this.Kind, out data);
			}
			this.Data = data;
		}

		// Token: 0x04000019 RID: 25
		private static Lazy<IDictionary<TKind, string>> _dataIndex;

		// Token: 0x0400001A RID: 26
		public static readonly DependencyProperty KindProperty = DependencyProperty.Register("Kind", typeof(TKind), typeof(PackIconBase<TKind>), new PropertyMetadata(default(TKind), new PropertyChangedCallback(PackIconBase<TKind>.KindPropertyChangedCallback)));

		// Token: 0x0400001B RID: 27
		private static readonly DependencyPropertyKey DataPropertyKey = DependencyProperty.RegisterReadOnly("Data", typeof(string), typeof(PackIconBase<TKind>), new PropertyMetadata(""));

		// Token: 0x0400001C RID: 28
		public static readonly DependencyProperty DataProperty = PackIconBase<TKind>.DataPropertyKey.DependencyProperty;
	}
}
