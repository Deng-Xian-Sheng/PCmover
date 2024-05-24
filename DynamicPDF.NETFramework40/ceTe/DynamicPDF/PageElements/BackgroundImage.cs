using System;
using System.IO;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200071C RID: 1820
	public class BackgroundImage : TaggablePageElement
	{
		// Token: 0x06004850 RID: 18512 RVA: 0x00255F76 File Offset: 0x00254F76
		public BackgroundImage(string filePath) : this(ImageData.GetImage(filePath))
		{
		}

		// Token: 0x06004851 RID: 18513 RVA: 0x00255F87 File Offset: 0x00254F87
		public BackgroundImage(Stream stream) : this(ImageData.GetImage(stream))
		{
		}

		// Token: 0x06004852 RID: 18514 RVA: 0x00255F98 File Offset: 0x00254F98
		public BackgroundImage(ImageData imageData)
		{
			this.a = imageData;
		}

		// Token: 0x06004853 RID: 18515 RVA: 0x00255FD0 File Offset: 0x00254FD0
		public override void Draw(PageWriter writer)
		{
			base.Draw(writer);
			if (writer.Document.Tag != null)
			{
				if (this.Tag == null)
				{
					Artifact artifact = new Artifact();
					artifact.SetType(ArtifactType.Background);
					BoundingBox boundingBox = new BoundingBox(writer.Dimensions.Edge.Left, writer.Dimensions.Edge.Bottom, writer.Dimensions.Edge.Right, writer.Dimensions.Edge.Top);
					artifact.SetBoundingBox(boundingBox);
					this.Tag = artifact;
				}
				this.Tag.e(writer, this);
			}
			if (this.f)
			{
				float width = writer.Dimensions.Body.Width - (float)this.c - (float)this.b;
				float num = writer.Dimensions.Body.Height - (float)this.d - (float)this.e;
				float pdfX = writer.Dimensions.GetPdfX((float)this.b);
				float pdfY = writer.Dimensions.GetPdfY(num) - (float)this.d;
				this.a.Draw(writer, pdfX, pdfY, width, num);
			}
			else
			{
				Dimensions edge = writer.Dimensions.Edge;
				float width = edge.Width - (float)this.c - (float)this.b;
				float num = edge.Height - (float)this.d - (float)this.e;
				this.a.Draw(writer, edge.Left + (float)this.b, edge.Top + (float)this.d, width, num);
			}
			if (writer.Document.Tag != null)
			{
				writer.z();
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06004854 RID: 18516 RVA: 0x002561A4 File Offset: 0x002551A4
		public ImageData ImageData
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06004855 RID: 18517 RVA: 0x002561BC File Offset: 0x002551BC
		// (set) Token: 0x06004856 RID: 18518 RVA: 0x002561D4 File Offset: 0x002551D4
		public int LeftPadding
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

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06004857 RID: 18519 RVA: 0x002561E0 File Offset: 0x002551E0
		// (set) Token: 0x06004858 RID: 18520 RVA: 0x002561F8 File Offset: 0x002551F8
		public int RightPadding
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06004859 RID: 18521 RVA: 0x00256204 File Offset: 0x00255204
		// (set) Token: 0x0600485A RID: 18522 RVA: 0x0025621C File Offset: 0x0025521C
		public int TopPadding
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x0600485B RID: 18523 RVA: 0x00256228 File Offset: 0x00255228
		// (set) Token: 0x0600485C RID: 18524 RVA: 0x00256240 File Offset: 0x00255240
		public int BottomPadding
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x0600485D RID: 18525 RVA: 0x0025624C File Offset: 0x0025524C
		// (set) Token: 0x0600485E RID: 18526 RVA: 0x00256264 File Offset: 0x00255264
		public bool UseMargins
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x0600485F RID: 18527 RVA: 0x0025626E File Offset: 0x0025526E
		internal override x5 b7()
		{
			throw new GeneratorException("BackgroundImage does not support the Top property.");
		}

		// Token: 0x06004860 RID: 18528 RVA: 0x0025627B File Offset: 0x0025527B
		internal override x5 b8()
		{
			throw new GeneratorException("BackgroundImage does not support the Bottom property.");
		}

		// Token: 0x06004861 RID: 18529 RVA: 0x00256288 File Offset: 0x00255288
		internal override byte cb()
		{
			return 57;
		}

		// Token: 0x04002793 RID: 10131
		private new ImageData a;

		// Token: 0x04002794 RID: 10132
		private int b = 0;

		// Token: 0x04002795 RID: 10133
		private int c = 0;

		// Token: 0x04002796 RID: 10134
		private new int d = 0;

		// Token: 0x04002797 RID: 10135
		private int e = 0;

		// Token: 0x04002798 RID: 10136
		private bool f = false;
	}
}
