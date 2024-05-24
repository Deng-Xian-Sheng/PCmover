using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007E9 RID: 2025
	public class BorderStyle
	{
		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06005238 RID: 21048 RVA: 0x0028C7E8 File Offset: 0x0028B7E8
		public static BorderStyle Solid
		{
			get
			{
				return new BorderStyle(83);
			}
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06005239 RID: 21049 RVA: 0x0028C804 File Offset: 0x0028B804
		public static BorderStyle Dashed
		{
			get
			{
				return new BorderStyle(68);
			}
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x0600523A RID: 21050 RVA: 0x0028C820 File Offset: 0x0028B820
		public static BorderStyle Beveled
		{
			get
			{
				return new BorderStyle(66);
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x0600523B RID: 21051 RVA: 0x0028C83C File Offset: 0x0028B83C
		public static BorderStyle Inset
		{
			get
			{
				return new BorderStyle(73);
			}
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x0600523C RID: 21052 RVA: 0x0028C858 File Offset: 0x0028B858
		public static BorderStyle Underline
		{
			get
			{
				return new BorderStyle(85);
			}
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x0600523D RID: 21053 RVA: 0x0028C874 File Offset: 0x0028B874
		// (set) Token: 0x0600523E RID: 21054 RVA: 0x0028C88C File Offset: 0x0028B88C
		public BorderThickness Thickness
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x0600523F RID: 21055 RVA: 0x0028C896 File Offset: 0x0028B896
		public void SetThin()
		{
			this.g = BorderThickness.Thin;
		}

		// Token: 0x06005240 RID: 21056 RVA: 0x0028C8A0 File Offset: 0x0028B8A0
		public void SetMedium()
		{
			this.g = BorderThickness.Medium;
		}

		// Token: 0x06005241 RID: 21057 RVA: 0x0028C8AA File Offset: 0x0028B8AA
		public void SetThick()
		{
			this.g = BorderThickness.Thick;
		}

		// Token: 0x06005242 RID: 21058 RVA: 0x0028C8B4 File Offset: 0x0028B8B4
		private BorderStyle(int A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06005243 RID: 21059 RVA: 0x0028C8D0 File Offset: 0x0028B8D0
		internal int a()
		{
			return this.h;
		}

		// Token: 0x06005244 RID: 21060 RVA: 0x0028C8E8 File Offset: 0x0028B8E8
		internal void a(int A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06005245 RID: 21061 RVA: 0x0028C8F4 File Offset: 0x0028B8F4
		internal int b()
		{
			return (int)this.g;
		}

		// Token: 0x06005246 RID: 21062 RVA: 0x0028C90C File Offset: 0x0028B90C
		internal void c()
		{
			this.g = (BorderThickness)0;
		}

		// Token: 0x06005247 RID: 21063 RVA: 0x0028C918 File Offset: 0x0028B918
		public void Draw(DocumentWriter writer)
		{
			writer.WriteName(BorderStyle.f);
			writer.WriteDictionaryOpen();
			if (this.g != BorderThickness.Thin)
			{
				writer.WriteName(87);
				writer.WriteNumber((int)this.g);
			}
			writer.WriteName(83);
			writer.WriteName((byte)this.h);
			if (this.a() == 68)
			{
				writer.WriteName(68);
				writer.WriteArrayOpen();
				writer.WriteNumber(3);
				writer.WriteArrayClose();
			}
			writer.WriteDictionaryClose();
		}

		// Token: 0x04002BF7 RID: 11255
		internal const int a = 83;

		// Token: 0x04002BF8 RID: 11256
		internal const int b = 68;

		// Token: 0x04002BF9 RID: 11257
		internal const int c = 66;

		// Token: 0x04002BFA RID: 11258
		internal const int d = 73;

		// Token: 0x04002BFB RID: 11259
		internal const int e = 85;

		// Token: 0x04002BFC RID: 11260
		private static byte[] f = new byte[]
		{
			66,
			83
		};

		// Token: 0x04002BFD RID: 11261
		private BorderThickness g = BorderThickness.Thin;

		// Token: 0x04002BFE RID: 11262
		private int h;
	}
}
