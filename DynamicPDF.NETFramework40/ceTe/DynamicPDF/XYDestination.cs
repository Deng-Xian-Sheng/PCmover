using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006BC RID: 1724
	public class XYDestination : Destination
	{
		// Token: 0x0600428E RID: 17038 RVA: 0x0022B5CA File Offset: 0x0022A5CA
		public XYDestination(int pageNumber, float x, float y) : base(pageNumber)
		{
			base.a(750795497);
			this.a = x;
			this.b = y;
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x0600428F RID: 17039 RVA: 0x0022B5F0 File Offset: 0x0022A5F0
		// (set) Token: 0x06004290 RID: 17040 RVA: 0x0022B608 File Offset: 0x0022A608
		public float X
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

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06004291 RID: 17041 RVA: 0x0022B614 File Offset: 0x0022A614
		// (set) Token: 0x06004292 RID: 17042 RVA: 0x0022B62C File Offset: 0x0022A62C
		public float Y
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06004293 RID: 17043 RVA: 0x0022B638 File Offset: 0x0022A638
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteName(Destination.b);
			writer.WriteArrayOpen();
			writer.WriteReferenceShallow(writer.GetPageObject(base.PageNumber));
			writer.WriteName(Destination.c);
			writer.WriteNumber(writer.Document.Pages[base.PageNumber - 1].Dimensions.GetPdfX(this.a));
			writer.WriteNumber(writer.Document.Pages[base.PageNumber - 1].Dimensions.GetPdfY(this.b));
			writer.WriteNull();
			writer.WriteArrayClose();
		}

		// Token: 0x04002505 RID: 9477
		private new float a;

		// Token: 0x04002506 RID: 9478
		private new float b;
	}
}
