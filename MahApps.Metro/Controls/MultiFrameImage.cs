using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200006D RID: 109
	public class MultiFrameImage : Image
	{
		// Token: 0x06000548 RID: 1352 RVA: 0x000148BC File Offset: 0x00012ABC
		static MultiFrameImage()
		{
			Image.SourceProperty.OverrideMetadata(typeof(MultiFrameImage), new FrameworkPropertyMetadata(new PropertyChangedCallback(MultiFrameImage.OnSourceChanged)));
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0001491E File Offset: 0x00012B1E
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x00014930 File Offset: 0x00012B30
		public MultiFrameImageMode MultiFrameImageMode
		{
			get
			{
				return (MultiFrameImageMode)base.GetValue(MultiFrameImage.MultiFrameImageModeProperty);
			}
			set
			{
				base.SetValue(MultiFrameImage.MultiFrameImageModeProperty, value);
			}
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00014943 File Offset: 0x00012B43
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((MultiFrameImage)d).UpdateFrameList();
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00014950 File Offset: 0x00012B50
		private void UpdateFrameList()
		{
			this._frames.Clear();
			BitmapFrame bitmapFrame = base.Source as BitmapFrame;
			if (bitmapFrame == null)
			{
				return;
			}
			BitmapDecoder decoder = bitmapFrame.Decoder;
			if (decoder == null || decoder.Frames.Count == 0)
			{
				return;
			}
			this._frames.AddRange(from f in decoder.Frames
			group f by f.PixelWidth * f.PixelHeight into g
			orderby g.Key
			select (from f in g
			orderby f.Format.BitsPerPixel descending
			select f).First<BitmapFrame>());
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00014A10 File Offset: 0x00012C10
		protected override void OnRender(DrawingContext dc)
		{
			if (this._frames.Count == 0)
			{
				base.OnRender(dc);
				return;
			}
			MultiFrameImageMode multiFrameImageMode = this.MultiFrameImageMode;
			if (multiFrameImageMode == MultiFrameImageMode.ScaleDownLargerFrame)
			{
				double minSize = Math.Max(base.RenderSize.Width, base.RenderSize.Height);
				BitmapSource imageSource = this._frames.FirstOrDefault((BitmapSource f) => f.Width >= minSize && f.Height >= minSize) ?? this._frames.Last<BitmapSource>();
				dc.DrawImage(imageSource, new Rect(0.0, 0.0, base.RenderSize.Width, base.RenderSize.Height));
				return;
			}
			if (multiFrameImageMode != MultiFrameImageMode.NoScaleSmallerFrame)
			{
				throw new ArgumentOutOfRangeException();
			}
			double maxSize = Math.Min(base.RenderSize.Width, base.RenderSize.Height);
			BitmapSource bitmapSource = this._frames.LastOrDefault((BitmapSource f) => f.Width <= maxSize && f.Height <= maxSize) ?? this._frames.First<BitmapSource>();
			dc.DrawImage(bitmapSource, new Rect((base.RenderSize.Width - bitmapSource.Width) / 2.0, (base.RenderSize.Height - bitmapSource.Height) / 2.0, bitmapSource.Width, bitmapSource.Height));
		}

		// Token: 0x04000206 RID: 518
		public static readonly DependencyProperty MultiFrameImageModeProperty = DependencyProperty.Register("MultiFrameImageMode", typeof(MultiFrameImageMode), typeof(MultiFrameImage), new FrameworkPropertyMetadata(MultiFrameImageMode.ScaleDownLargerFrame, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000207 RID: 519
		private readonly List<BitmapSource> _frames = new List<BitmapSource>();
	}
}
