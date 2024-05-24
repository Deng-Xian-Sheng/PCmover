using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200074B RID: 1867
	public abstract class Watermark : TaggablePageElement, IAnnotation
	{
		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x06004BC8 RID: 19400 RVA: 0x00266190 File Offset: 0x00265190
		// (set) Token: 0x06004BC9 RID: 19401 RVA: 0x002661A8 File Offset: 0x002651A8
		public string Name
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x06004BCA RID: 19402 RVA: 0x002661B4 File Offset: 0x002651B4
		// (set) Token: 0x06004BCB RID: 19403 RVA: 0x002661CC File Offset: 0x002651CC
		public string AlternateName
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06004BCC RID: 19404 RVA: 0x002661D8 File Offset: 0x002651D8
		// (set) Token: 0x06004BCD RID: 19405 RVA: 0x002661F0 File Offset: 0x002651F0
		public float XOffset
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06004BCE RID: 19406 RVA: 0x002661FC File Offset: 0x002651FC
		// (set) Token: 0x06004BCF RID: 19407 RVA: 0x00266214 File Offset: 0x00265214
		public float YOffset
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06004BD0 RID: 19408 RVA: 0x00266220 File Offset: 0x00265220
		// (set) Token: 0x06004BD1 RID: 19409 RVA: 0x00266238 File Offset: 0x00265238
		public WatermarkPosition Position
		{
			get
			{
				return this.s;
			}
			set
			{
				this.s = value;
			}
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06004BD2 RID: 19410 RVA: 0x00266244 File Offset: 0x00265244
		// (set) Token: 0x06004BD3 RID: 19411 RVA: 0x0026625C File Offset: 0x0026525C
		public float Angle
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06004BD4 RID: 19412 RVA: 0x00266268 File Offset: 0x00265268
		// (set) Token: 0x06004BD5 RID: 19413 RVA: 0x00266280 File Offset: 0x00265280
		public float Opacity
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x06004BD6 RID: 19414 RVA: 0x0026628A File Offset: 0x0026528A
		public override void Draw(PageWriter writer)
		{
		}

		// Token: 0x06004BD7 RID: 19415 RVA: 0x00266290 File Offset: 0x00265290
		public virtual void DrawAnnotation(DocumentWriter writer)
		{
			writer.WriteName(Watermark.i);
			writer.WriteName(Watermark.j);
			if (this.n.Length > 0)
			{
				writer.WriteName(84);
				writer.WriteText(this.Name);
			}
			if (this.r.Length > 0)
			{
				writer.WriteName(Watermark.l);
				writer.WriteText(this.r);
			}
			writer.WriteName(FormField.y);
			writer.WriteNumber(4);
		}

		// Token: 0x06004BD8 RID: 19416 RVA: 0x00266328 File Offset: 0x00265328
		internal void a(PageWriter A_0)
		{
			float left = A_0.Page.Dimensions.Edge.Left;
			float bottom = A_0.Page.Dimensions.Edge.Bottom;
			float right = A_0.Page.Dimensions.Edge.Right;
			float top = A_0.Page.Dimensions.Edge.Top;
			if (this.b == null || left != this.b.Left || bottom != this.b.Top || right != this.b.Right || top != this.b.Bottom || (A_0.Document.Tag != null && this.Tag == null && this.b.a() == null) || (this.b.a() != null && this.Tag != this.b.a()))
			{
				this.b = new Annotation(left, bottom, right, top, this);
			}
			A_0.Annotations.Add(this.b);
			if (A_0.Document.Tag != null && A_0.Page.ha())
			{
				if (this.Tag == null)
				{
					this.Tag = new StructureElement(TagType.Annotation, true);
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

		// Token: 0x06004BD9 RID: 19417 RVA: 0x002664E7 File Offset: 0x002654E7
		internal virtual void ki(DocumentWriter A_0)
		{
		}

		// Token: 0x06004BDA RID: 19418 RVA: 0x002664EC File Offset: 0x002654EC
		internal void a(string A_0, float A_1, Rectangle A_2, Font A_3, ref float A_4, ref float A_5)
		{
			float num;
			float num2;
			if (A_0 == "")
			{
				num = A_5;
				num2 = A_4;
			}
			else
			{
				int num3 = 12;
				num2 = A_3.GetTextWidth(A_0.ToCharArray(), (float)num3);
				TextLineList textLines = A_3.GetTextLines(A_0.ToCharArray(), num2, (float)num3);
				num = textLines.GetTextHeight();
			}
			double num4 = Math.Sqrt((double)(num * num + num2 * num2));
			double num5 = Math.Asin((double)num / num4);
			num5 /= 0.0174532925;
			double num6 = (double)num / num4;
			double num7 = (double)num2 / num4;
			double value = (double)A_2.Width / Math.Cos(((double)A_1 - num5) * 0.0174532925);
			double value2 = (double)A_2.Width / Math.Cos(((double)A_1 + num5) * 0.0174532925);
			double value3 = (double)A_2.Height / Math.Sin(((double)A_1 - num5) * 0.0174532925);
			double value4 = (double)A_2.Height / Math.Sin(((double)A_1 + num5) * 0.0174532925);
			double value5 = Math.Min(Math.Abs(value), Math.Abs(value2));
			double value6 = Math.Min(Math.Abs(value3), Math.Abs(value4));
			double num8 = Math.Min(Math.Abs(value5), Math.Abs(value6));
			A_5 = (float)(num8 * num6);
			A_4 = (float)(num8 * num7);
		}

		// Token: 0x06004BDB RID: 19419 RVA: 0x00266648 File Offset: 0x00265648
		internal void a(float A_0, float A_1, float A_2, ref float A_3, ref float A_4)
		{
			if (A_2 >= 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_3 = (float)((double)A_1 * Math.Cos((double)(90f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(A_2 - 90f) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(90f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Sin((double)(A_2 - 90f) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(A_2 - 180f) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(A_2 - 180f) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(A_2 - 180f) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_4 = (float)((double)A_0 * Math.Cos((double)(A_2 - 270f) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_4 = (float)((double)A_0 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(A_2 + 180f) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(A_2 + 180f) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(A_2 + 180f) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(270f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Cos((double)(-(double)(180f + A_2)) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_3 = (float)((double)A_1 * Math.Cos((double)(-(double)(270f + A_2)) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BDC RID: 19420 RVA: 0x00266938 File Offset: 0x00265938
		internal void a(float A_0, float A_1, float A_2, float A_3, float A_4)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			this.a(this.c(), this.d(), A_2, ref num, ref num2, ref num3);
			if (A_2 >= 0f)
			{
				if (A_2 >= 0f && A_2 <= 90f)
				{
					this.a(A_0 / 2f - (num / 2f - num3) + A_3);
					this.b(num2 + A_4);
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					this.a(A_0 / 2f + num / 2f + A_3);
					this.b(num2 + A_4);
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					this.a(A_3 + A_0 / 2f + (num / 2f - num3));
					this.b(A_4 + num2);
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					this.a(A_3 + A_0 / 2f - num / 2f);
					this.b(A_4 + num2);
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					this.a(A_3 + A_0 / 2f - num / 2f);
					this.b(A_4 + num2);
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					this.a(A_3 + A_0 / 2f + (num / 2f - num3));
					this.b(num2 + A_4);
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					this.a(A_3 + A_0 / 2f + num / 2f);
					this.b(A_4 + num2);
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					this.a(A_3 + A_0 / 2f - (num / 2f - num3));
					this.b(A_4 + num2);
				}
			}
		}

		// Token: 0x06004BDD RID: 19421 RVA: 0x00266BC8 File Offset: 0x00265BC8
		internal void a(float A_0, float A_1, float A_2, ref float A_3, ref float A_4, ref float A_5)
		{
			if (A_2 > 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)A_2 * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(A_2 - 90f) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(A_2 - 90f) * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Sin((double)(A_2 - 90f) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(A_2 - 180f) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(A_2 - 180f) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(A_2 - 180f) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(A_2 - 180f) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(A_2 - 270f) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(A_2 - 270f) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Cos((double)(A_2 - 270f) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(180f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BDE RID: 19422 RVA: 0x00266FD4 File Offset: 0x00265FD4
		internal void b(float A_0, float A_1, float A_2, ref float A_3, ref float A_4)
		{
			if (A_2 >= 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_4 = (float)((double)A_1 * Math.Cos((double)(180f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_3 = (float)((double)A_1 * Math.Sin((double)(A_2 - 180f) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(A_2 - 180f) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(A_2 - 180f) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(A_2 - 270f) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(A_2 - 270f) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Cos((double)(A_2 - 270f) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(90f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_3 = (float)((double)A_1 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(180f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_4 = (float)((double)A_1 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BDF RID: 19423 RVA: 0x002672B8 File Offset: 0x002662B8
		internal void b(float A_0, float A_1, float A_2, float A_3, float A_4)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			this.b(this.c(), this.d(), A_2, ref num, ref num2, ref num3);
			if (A_2 >= 0f)
			{
				if (A_2 >= 0f && A_2 <= 90f)
				{
					this.a(num + A_3);
					this.b(-A_4 + (A_1 - num2) / 2f);
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					this.a(num + A_3);
					this.b(-A_4 + A_1 / 2f - (num2 / 2f - num3));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					this.a(num + A_3);
					this.b(-A_4 + A_1 / 2f + num2 / 2f);
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					this.a(num + A_3);
					this.b(-A_4 + A_1 / 2f + (num2 / 2f - num3));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					this.a(A_3);
					this.b(-A_4 + A_1 / 2f + (num2 / 2f - num3));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					this.a(num + A_3);
					this.b(-A_4 + A_1 / 2f + num2 / 2f);
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					this.a(num + A_3);
					this.b(-A_4 + A_1 / 2f - (num2 / 2f - num3));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					this.a(num + A_3);
					this.b(-A_4 + A_1 / 2f - num2 / 2f);
				}
			}
		}

		// Token: 0x06004BE0 RID: 19424 RVA: 0x00267550 File Offset: 0x00266550
		internal void b(float A_0, float A_1, float A_2, ref float A_3, ref float A_4, ref float A_5)
		{
			if (A_2 >= 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_3 = (float)((double)A_1 * Math.Sin((double)A_2 * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Cos((double)A_2 * 0.017453292519943) + (double)A_0 * Math.Sin((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(A_2 - 90f) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(A_2 - 90f) * 0.017453292519943));
					A_5 = (float)((double)A_1 * Math.Sin((double)(A_2 - 90f) * 0.017453292519943));
					A_4 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(A_2 - 90f) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(A_2 - 180f) * 0.017453292519943));
					A_5 = (float)((double)A_1 * Math.Cos((double)(A_2 - 180f) * 0.017453292519943));
					A_4 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(A_2 - 180f) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(A_2 - 270f) * 0.017453292519943));
					A_4 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(A_2 - 270f) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(180f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(270f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
					A_5 = (float)((double)A_1 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_3 = (float)((double)A_1 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
					A_5 = (float)((double)A_1 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BE1 RID: 19425 RVA: 0x00267944 File Offset: 0x00266944
		internal void c(float A_0, float A_1, float A_2, float A_3, float A_4)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			this.a(this.c(), this.d(), A_2, ref num, ref num2, ref num3, ref num4);
			if (A_2 >= 0f)
			{
				if (A_2 >= 0f && A_2 <= 90f)
				{
					this.a(A_3 + A_0 / 2f - (num / 2f - num3));
					this.b(-A_4 + (A_1 - num2) / 2f);
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					this.a(A_3 + A_0 / 2f + num / 2f);
					this.b(-A_4 + A_1 / 2f - (num2 / 2f - num4));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					this.a(A_3 + (A_0 + (num - 2f * num3)) / 2f);
					this.b(-A_4 + (A_1 + num2) / 2f);
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					this.a(A_3 + (A_0 - num) / 2f);
					this.b(-A_4 + (A_1 + (num2 - 2f * num4)) / 2f);
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					this.a(A_3 + (A_0 - num) / 2f);
					this.b(-A_4 + (A_1 + (num2 - 2f * num4)) / 2f);
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					this.a(A_3 + (A_0 + (num - 2f * num3)) / 2f);
					this.b(-A_4 + (A_1 + num2) / 2f);
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					this.a(A_3 + A_0 / 2f + num / 2f);
					this.b(-A_4 + A_1 / 2f - (num2 / 2f - num4));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					this.a(A_3 + A_0 / 2f - (num / 2f - num3));
					this.b(-A_4 + (A_1 - num2) / 2f);
				}
			}
		}

		// Token: 0x06004BE2 RID: 19426 RVA: 0x00267C48 File Offset: 0x00266C48
		internal void a(float A_0, float A_1, float A_2, ref float A_3, ref float A_4, ref float A_5, ref float A_6)
		{
			if (A_2 > 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)A_2 * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)A_2 * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)A_2 * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(180f - A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(180f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(270f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Sin((double)(270f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Cos((double)(270f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(360f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(360f - A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(360f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(360f - A_2) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BE3 RID: 19427 RVA: 0x00268180 File Offset: 0x00267180
		internal void d(float A_0, float A_1, float A_2, float A_3, float A_4)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			this.b(this.c(), this.d(), A_2, ref num, ref num2, ref num3, ref num4);
			if (A_2 >= 0f)
			{
				if (A_2 >= 0f && A_2 <= 90f)
				{
					this.a(-A_3 + A_0 - num);
					this.b(-A_4 + A_1 / 2f - num2 / 2f);
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					this.a(-A_3 + A_0);
					this.b(-A_4 + A_1 / 2f - (num2 / 2f - num4));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					this.a(-A_3 + A_0 - num3);
					this.b(-A_4 + A_1 / 2f + num2 / 2f);
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					this.a(-A_3 + A_0 - num);
					this.b(-A_4 + A_1 / 2f + num2 / 2f - num4);
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					this.a(-A_3 + A_0 - num);
					this.b(-A_4 + A_1 / 2f + num2 / 2f - num4);
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					this.a(-A_3 + A_0 - num3);
					this.b(-A_4 + A_1 / 2f + num2 / 2f);
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					this.a(-A_3 + A_0);
					this.b(-A_4 + A_1 / 2f - (num2 / 2f - num4));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					this.a(-A_3 + A_0 - num);
					this.b(-A_4 + A_1 / 2f - num2 / 2f);
				}
			}
		}

		// Token: 0x06004BE4 RID: 19428 RVA: 0x00268444 File Offset: 0x00267444
		internal void b(float A_0, float A_1, float A_2, ref float A_3, ref float A_4, ref float A_5, ref float A_6)
		{
			if (A_2 > 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)A_2 * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)A_2 * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_6 = (float)((double)A_1 * Math.Cos((double)(180f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(270f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(270f - A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Sin((double)(270f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Cos((double)(270f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(360f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(360f - A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(360f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(360f - A_2) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_6 = (float)((double)A_1 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BE5 RID: 19429 RVA: 0x002688AC File Offset: 0x002678AC
		internal void e(float A_0, float A_1, float A_2, float A_3, float A_4)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			this.c(this.c(), this.d(), A_2, ref num, ref num2, ref num3, ref num4);
			if (A_2 >= 0f)
			{
				if (A_2 >= 0f && A_2 <= 90f)
				{
					this.a(A_3 + A_0 / 2f - (num / 2f - num3));
					this.b(-A_4 + A_1 - num2);
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					this.a(A_3 + A_0 / 2f + num / 2f);
					this.b(-A_4 + A_1 - num2);
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					this.a(A_3 + A_0 / 2f + (num / 2f - num3));
					this.b(-A_4 + A_1);
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					this.a(A_3 + A_0 / 2f - num / 2f);
					this.b(-A_4 + A_1 - num4);
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					this.a(A_3 + A_0 / 2f - num / 2f);
					this.b(-A_4 + A_1 - num4);
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					this.a(A_3 + A_0 / 2f + num / 2f - num3);
					this.b(-A_4 + A_1);
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					this.a(A_3 + A_0 / 2f + num / 2f);
					this.b(-A_4 + A_1 - num2);
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					this.a(A_3 + A_0 / 2f - (num / 2f - num3));
					this.b(-A_4 + A_1 - num2);
				}
			}
		}

		// Token: 0x06004BE6 RID: 19430 RVA: 0x00268B68 File Offset: 0x00267B68
		internal void c(float A_0, float A_1, float A_2, ref float A_3, ref float A_4, ref float A_5, ref float A_6)
		{
			if (A_2 > 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)A_2 * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)A_2 * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)A_2 * 0.017453292519943) + (double)A_1 * Math.Cos((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(180f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(270f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(270f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(360f - A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(360f - A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(360f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(360f - A_2) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(90f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_5 = (float)((double)A_1 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Sin((double)(270f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_5 = (float)((double)A_1 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
					A_3 = (float)((double)A_5 + (double)A_0 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_6 = (float)((double)A_1 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_6 + (double)A_0 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BE7 RID: 19431 RVA: 0x00268F9C File Offset: 0x00267F9C
		internal void c(float A_0, float A_1, float A_2, ref float A_3, ref float A_4)
		{
			if (A_2 >= 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_3 = (float)((double)A_1 * Math.Sin((double)A_2 * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)A_2 * 0.017453292519943) + (double)A_1 * Math.Cos((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(180f - A_2) * 0.017453292519943) + (double)A_1 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(270f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_4 = (float)((double)A_1 * Math.Cos((double)(360f - A_2) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_4 = (float)((double)A_1 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_3 = (float)((double)A_0 * Math.Sin((double)(270f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_3 = (float)((double)A_1 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)(360f + A_2) * 0.017453292519943) + (double)A_1 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BE8 RID: 19432 RVA: 0x00269274 File Offset: 0x00268274
		internal void d(float A_0, float A_1, float A_2, ref float A_3, ref float A_4)
		{
			if (A_2 > 0f)
			{
				if (A_2 > 0f && A_2 <= 90f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)A_2 * 0.017453292519943));
					A_4 = (float)((double)A_0 * Math.Sin((double)A_2 * 0.017453292519943) + (double)A_1 * Math.Cos((double)A_2 * 0.017453292519943));
				}
				else if (A_2 > 90f && A_2 <= 180f)
				{
					A_4 = (float)((double)A_0 * Math.Sin((double)(180f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 180f && A_2 <= 270f)
				{
					A_3 = (float)((double)A_1 * Math.Cos((double)(270f - A_2) * 0.017453292519943));
				}
				else if (A_2 > 270f && A_2 <= 360f)
				{
					A_3 = (float)((double)A_1 * Math.Cos((double)(A_2 - 270f) * 0.017453292519943) + (double)A_0 * Math.Sin((double)(A_2 - 270f) * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Sin((double)(A_2 - 270f) * 0.017453292519943));
				}
			}
			else if (A_2 < 0f)
			{
				if (A_2 < 0f && A_2 >= -90f)
				{
					A_3 = (float)((double)A_1 * Math.Cos((double)(90f + A_2) * 0.017453292519943) + (double)A_0 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Sin((double)(90f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -90f && A_2 >= -180f)
				{
					A_3 = (float)((double)A_1 * Math.Sin((double)(180f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -180f && A_2 >= -270f)
				{
					A_4 = (float)((double)A_0 * Math.Cos((double)(270f + A_2) * 0.017453292519943));
				}
				else if (A_2 < -270f && A_2 >= -360f)
				{
					A_3 = (float)((double)A_0 * Math.Cos((double)(360f + A_2) * 0.017453292519943));
					A_4 = (float)((double)A_1 * Math.Cos((double)(360f + A_2) * 0.017453292519943) + (double)A_0 * Math.Sin((double)(360f + A_2) * 0.017453292519943));
				}
			}
		}

		// Token: 0x06004BE9 RID: 19433
		internal abstract void kj(float A_0, float A_1);

		// Token: 0x06004BEA RID: 19434 RVA: 0x00269554 File Offset: 0x00268554
		internal float a()
		{
			return this.c;
		}

		// Token: 0x06004BEB RID: 19435 RVA: 0x0026956C File Offset: 0x0026856C
		internal void a(float A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06004BEC RID: 19436 RVA: 0x00269578 File Offset: 0x00268578
		internal float b()
		{
			return x5.b(this.d);
		}

		// Token: 0x06004BED RID: 19437 RVA: 0x00269596 File Offset: 0x00268596
		internal void b(float A_0)
		{
			this.d = x5.a(A_0);
		}

		// Token: 0x06004BEE RID: 19438 RVA: 0x002695A8 File Offset: 0x002685A8
		internal float c()
		{
			return this.e;
		}

		// Token: 0x06004BEF RID: 19439 RVA: 0x002695C0 File Offset: 0x002685C0
		internal void c(float A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06004BF0 RID: 19440 RVA: 0x002695CC File Offset: 0x002685CC
		internal float d()
		{
			return x5.b(this.f);
		}

		// Token: 0x06004BF1 RID: 19441 RVA: 0x002695EA File Offset: 0x002685EA
		internal void d(float A_0)
		{
			this.f = x5.a(A_0);
		}

		// Token: 0x040028F4 RID: 10484
		private new const double a = 0.017453292519943;

		// Token: 0x040028F5 RID: 10485
		private Annotation b = null;

		// Token: 0x040028F6 RID: 10486
		private float c;

		// Token: 0x040028F7 RID: 10487
		private new x5 d;

		// Token: 0x040028F8 RID: 10488
		private float e;

		// Token: 0x040028F9 RID: 10489
		private x5 f;

		// Token: 0x040028FA RID: 10490
		internal static byte g = 86;

		// Token: 0x040028FB RID: 10491
		internal static byte h = 78;

		// Token: 0x040028FC RID: 10492
		internal static byte[] i = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x040028FD RID: 10493
		internal static byte[] j = new byte[]
		{
			87,
			97,
			116,
			101,
			114,
			109,
			97,
			114,
			107
		};

		// Token: 0x040028FE RID: 10494
		internal static byte[] k = new byte[]
		{
			65,
			80
		};

		// Token: 0x040028FF RID: 10495
		internal static byte[] l = new byte[]
		{
			84,
			85
		};

		// Token: 0x04002900 RID: 10496
		private float m = -45f;

		// Token: 0x04002901 RID: 10497
		private string n = "";

		// Token: 0x04002902 RID: 10498
		private new float o = 50f;

		// Token: 0x04002903 RID: 10499
		private float p = 0f;

		// Token: 0x04002904 RID: 10500
		private float q = 0f;

		// Token: 0x04002905 RID: 10501
		private string r = "";

		// Token: 0x04002906 RID: 10502
		private WatermarkPosition s = WatermarkPosition.Center;
	}
}
