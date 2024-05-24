using System;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200002A RID: 42
	public class ContentControlEx : ContentControl
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00005436 File Offset: 0x00003636
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00005448 File Offset: 0x00003648
		public CharacterCasing ContentCharacterCasing
		{
			get
			{
				return (CharacterCasing)base.GetValue(ContentControlEx.ContentCharacterCasingProperty);
			}
			set
			{
				base.SetValue(ContentControlEx.ContentCharacterCasingProperty, value);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000FA RID: 250 RVA: 0x0000545B File Offset: 0x0000365B
		// (set) Token: 0x060000FB RID: 251 RVA: 0x0000546D File Offset: 0x0000366D
		public bool RecognizesAccessKey
		{
			get
			{
				return (bool)base.GetValue(ContentControlEx.RecognizesAccessKeyProperty);
			}
			set
			{
				base.SetValue(ContentControlEx.RecognizesAccessKeyProperty, value);
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00005480 File Offset: 0x00003680
		static ContentControlEx()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentControlEx), new FrameworkPropertyMetadata(typeof(ContentControlEx)));
		}

		// Token: 0x0400003E RID: 62
		public static readonly DependencyProperty ContentCharacterCasingProperty = DependencyProperty.Register("ContentCharacterCasing", typeof(CharacterCasing), typeof(ContentControlEx), new FrameworkPropertyMetadata(CharacterCasing.Normal, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.Inherits), (object value) => CharacterCasing.Normal <= (CharacterCasing)value && (CharacterCasing)value <= CharacterCasing.Upper);

		// Token: 0x0400003F RID: 63
		public static readonly DependencyProperty RecognizesAccessKeyProperty = DependencyProperty.Register("RecognizesAccessKey", typeof(bool), typeof(ContentControlEx), new FrameworkPropertyMetadata(false));
	}
}
