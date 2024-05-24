using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006BD RID: 1725
	public class ZoomDestination : Destination
	{
		// Token: 0x06004294 RID: 17044 RVA: 0x0022B6E4 File Offset: 0x0022A6E4
		public ZoomDestination(int pageNumber, PageZoom zoom) : base(pageNumber)
		{
			this.a = zoom;
			base.a(514009796);
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06004295 RID: 17045 RVA: 0x0022B704 File Offset: 0x0022A704
		// (set) Token: 0x06004296 RID: 17046 RVA: 0x0022B71C File Offset: 0x0022A71C
		public PageZoom Zoom
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x06004297 RID: 17047 RVA: 0x0022B728 File Offset: 0x0022A728
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteName(Destination.b);
			writer.WriteArrayOpen();
			writer.WriteReferenceShallow(writer.GetPageObject(base.PageNumber));
			switch (this.a)
			{
			case PageZoom.Retain:
				writer.WriteName(Destination.c);
				writer.WriteNull();
				writer.WriteNull();
				writer.WriteNull();
				writer.WriteArrayClose();
				break;
			case PageZoom.FitPage:
				writer.WriteName(ZoomDestination.b);
				writer.WriteArrayClose();
				break;
			case PageZoom.FitWidth:
				writer.WriteName(ZoomDestination.c);
				writer.WriteArrayClose();
				break;
			case PageZoom.FitHeight:
				writer.WriteName(ZoomDestination.d);
				writer.WriteArrayClose();
				break;
			case PageZoom.FitBox:
				writer.WriteName(ZoomDestination.e);
				writer.WriteArrayClose();
				break;
			}
		}

		// Token: 0x04002507 RID: 9479
		private new PageZoom a;

		// Token: 0x04002508 RID: 9480
		private new static byte[] b = new byte[]
		{
			70,
			105,
			116
		};

		// Token: 0x04002509 RID: 9481
		private new static byte[] c = new byte[]
		{
			70,
			105,
			116,
			72
		};

		// Token: 0x0400250A RID: 9482
		private new static byte[] d = new byte[]
		{
			70,
			105,
			116,
			86
		};

		// Token: 0x0400250B RID: 9483
		private static byte[] e = new byte[]
		{
			70,
			105,
			116,
			66
		};
	}
}
