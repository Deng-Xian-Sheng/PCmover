using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000731 RID: 1841
	public class Link : TaggablePageElement, IAnnotation, IArea, ICoordinate
	{
		// Token: 0x06004984 RID: 18820 RVA: 0x0025AF78 File Offset: 0x00259F78
		public Link(float x, float y, float width, float height, Action action)
		{
			this.c = x;
			this.d = x5.a(y);
			this.e = width;
			this.f = x5.a(height);
			this.a = action;
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06004985 RID: 18821 RVA: 0x0025AFD0 File Offset: 0x00259FD0
		// (set) Token: 0x06004986 RID: 18822 RVA: 0x0025AFE8 File Offset: 0x00259FE8
		public float X
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

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06004987 RID: 18823 RVA: 0x0025AFF4 File Offset: 0x00259FF4
		// (set) Token: 0x06004988 RID: 18824 RVA: 0x0025B012 File Offset: 0x0025A012
		public float Y
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06004989 RID: 18825 RVA: 0x0025B024 File Offset: 0x0025A024
		// (set) Token: 0x0600498A RID: 18826 RVA: 0x0025B03C File Offset: 0x0025A03C
		public float Width
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

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x0600498B RID: 18827 RVA: 0x0025B048 File Offset: 0x0025A048
		// (set) Token: 0x0600498C RID: 18828 RVA: 0x0025B066 File Offset: 0x0025A066
		public float Height
		{
			get
			{
				return x5.b(this.f);
			}
			set
			{
				this.f = x5.a(value);
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600498D RID: 18829 RVA: 0x0025B078 File Offset: 0x0025A078
		public Action Action
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x0600498E RID: 18830 RVA: 0x0025B090 File Offset: 0x0025A090
		// (set) Token: 0x0600498F RID: 18831 RVA: 0x0025B0A8 File Offset: 0x0025A0A8
		public override Tag Tag
		{
			get
			{
				return base.Tag;
			}
			set
			{
				if (value != null && value.TagType == TagType.a())
				{
					throw new GeneratorException("Tag cannot be Artifact for link");
				}
				base.Tag = value;
			}
		}

		// Token: 0x06004990 RID: 18832 RVA: 0x0025B0E4 File Offset: 0x0025A0E4
		public override void Draw(PageWriter writer)
		{
			base.Draw(writer);
			this.a(writer);
		}

		// Token: 0x06004991 RID: 18833 RVA: 0x0025B0F8 File Offset: 0x0025A0F8
		internal void a(PageWriter A_0)
		{
			float num = A_0.Dimensions.aw(this.c);
			float num2 = A_0.Dimensions.ax(x5.b(this.d));
			float num3 = A_0.Dimensions.aw(this.c + this.e);
			float num4 = A_0.Dimensions.ax(x5.b(x5.f(this.d, this.f)));
			if (this.b == null || num != this.b.Left || num2 != this.b.Top || num3 != this.b.Right || num4 != this.b.Bottom || (A_0.Document.Tag != null && this.Tag == null && this.b.a() == null) || (this.b.a() != null && this.Tag != this.b.a()))
			{
				this.b = new Annotation(num, num2, num3, num4, this);
			}
			A_0.Annotations.Add(this.b);
			if (A_0.Document.Tag != null && A_0.Page.ha())
			{
				if (this.Tag == null)
				{
					this.Tag = new StructureElement(TagType.Link, true);
					((StructureElement)this.Tag).Order = this.TagOrder;
				}
				this.b.a(this.Tag);
				((StructureElement)this.Tag).a(A_0, this, this.b);
			}
			else
			{
				this.b.a(false);
			}
		}

		// Token: 0x06004992 RID: 18834 RVA: 0x0025B2C8 File Offset: 0x0025A2C8
		public void DrawAnnotation(DocumentWriter writer)
		{
			writer.WriteName(Link.g);
			writer.WriteName(Link.h);
			writer.WriteName(Link.i);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteArrayClose();
			if (this.a != null)
			{
				if (this.a.c() != 750795497 && this.a.c() != 514009796)
				{
					writer.WriteName(65);
				}
				this.a.Draw(writer);
			}
			writer.WriteName(FormField.y);
			writer.WriteNumber(4);
		}

		// Token: 0x06004993 RID: 18835 RVA: 0x0025B384 File Offset: 0x0025A384
		internal override x5 b7()
		{
			return this.d;
		}

		// Token: 0x06004994 RID: 18836 RVA: 0x0025B39C File Offset: 0x0025A39C
		internal override x5 b8()
		{
			return x5.f(this.d, this.f);
		}

		// Token: 0x06004995 RID: 18837 RVA: 0x0025B3C0 File Offset: 0x0025A3C0
		internal override byte cb()
		{
			return 53;
		}

		// Token: 0x04002803 RID: 10243
		private new Action a = null;

		// Token: 0x04002804 RID: 10244
		private Annotation b = null;

		// Token: 0x04002805 RID: 10245
		private float c;

		// Token: 0x04002806 RID: 10246
		private new x5 d;

		// Token: 0x04002807 RID: 10247
		private float e;

		// Token: 0x04002808 RID: 10248
		private x5 f;

		// Token: 0x04002809 RID: 10249
		private static byte[] g = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x0400280A RID: 10250
		private static byte[] h = new byte[]
		{
			76,
			105,
			110,
			107
		};

		// Token: 0x0400280B RID: 10251
		private static byte[] i = new byte[]
		{
			66,
			111,
			114,
			100,
			101,
			114
		};
	}
}
