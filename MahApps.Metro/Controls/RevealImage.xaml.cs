using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200007F RID: 127
	public partial class RevealImage : UserControl
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060006AF RID: 1711 RVA: 0x0001BE14 File Offset: 0x0001A014
		// (set) Token: 0x060006B0 RID: 1712 RVA: 0x0001BE26 File Offset: 0x0001A026
		public string Text
		{
			get
			{
				return (string)base.GetValue(RevealImage.TextProperty);
			}
			set
			{
				base.SetValue(RevealImage.TextProperty, value);
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x0001BE34 File Offset: 0x0001A034
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x0001BE46 File Offset: 0x0001A046
		public ImageSource Image
		{
			get
			{
				return (ImageSource)base.GetValue(RevealImage.ImageProperty);
			}
			set
			{
				base.SetValue(RevealImage.ImageProperty, value);
			}
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001BE54 File Offset: 0x0001A054
		public RevealImage()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0001BE64 File Offset: 0x0001A064
		private static void TypewriteTextblock(string textToAnimate, TextBlock txt, TimeSpan timeSpan)
		{
			Storyboard storyboard = new Storyboard
			{
				FillBehavior = FillBehavior.HoldEnd
			};
			StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames
			{
				Duration = new Duration(timeSpan)
			};
			string text = string.Empty;
			foreach (char c in textToAnimate)
			{
				DiscreteStringKeyFrame discreteStringKeyFrame = new DiscreteStringKeyFrame
				{
					KeyTime = KeyTime.Paced
				};
				text += c.ToString();
				discreteStringKeyFrame.Value = text;
				stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
			}
			Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
			Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
			storyboard.Children.Add(stringAnimationUsingKeyFrames);
			storyboard.Begin(txt);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0001BF1C File Offset: 0x0001A11C
		private void GridMouseEnter(object sender, MouseEventArgs e)
		{
			RevealImage.TypewriteTextblock(this.Text.ToUpper(), this.textBlock, TimeSpan.FromSeconds(0.25));
		}

		// Token: 0x040002B0 RID: 688
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(RevealImage), new UIPropertyMetadata(""));

		// Token: 0x040002B1 RID: 689
		public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(RevealImage), new UIPropertyMetadata(null));
	}
}
