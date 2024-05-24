using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000075 RID: 117
	public abstract class AreaDimensions
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x0004F8AD File Offset: 0x0004E8AD
		internal AreaDimensions(Dimensions A_0, Dimensions A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0004F8C6 File Offset: 0x0004E8C6
		internal AreaDimensions(Dimensions A_0)
		{
			this.a = A_0;
			this.b = A_0;
		}

		// Token: 0x060004CE RID: 1230
		internal abstract AreaDimensions ay();

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0004F8E0 File Offset: 0x0004E8E0
		public Dimensions Body
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0004F8F8 File Offset: 0x0004E8F8
		public Dimensions Edge
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0004F910 File Offset: 0x0004E910
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0004F92D File Offset: 0x0004E92D
		public float Width
		{
			get
			{
				return this.a.Width;
			}
			set
			{
				this.b.Right += value - this.a.Width;
				this.a.Width = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0004F960 File Offset: 0x0004E960
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x0004F97D File Offset: 0x0004E97D
		public float Height
		{
			get
			{
				return this.a.Height;
			}
			set
			{
				this.b.Bottom -= this.a.Height - value;
				this.a.Height = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0004F9B0 File Offset: 0x0004E9B0
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x0004F9D9 File Offset: 0x0004E9D9
		public float LeftMargin
		{
			get
			{
				return this.b.Left - this.a.Left;
			}
			set
			{
				this.b.Left = this.a.Left + value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0004F9F8 File Offset: 0x0004E9F8
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0004FA21 File Offset: 0x0004EA21
		public float TopMargin
		{
			get
			{
				return this.b.Top - this.a.Top;
			}
			set
			{
				this.b.Top = this.a.Top + value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0004FA40 File Offset: 0x0004EA40
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x0004FA69 File Offset: 0x0004EA69
		public float RightMargin
		{
			get
			{
				return this.a.Right - this.b.Right;
			}
			set
			{
				this.b.Right = this.a.Right - value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0004FA88 File Offset: 0x0004EA88
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x0004FAB1 File Offset: 0x0004EAB1
		public float BottomMargin
		{
			get
			{
				return this.a.Bottom - this.b.Bottom;
			}
			set
			{
				this.b.Bottom = this.a.Bottom - value;
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0004FAD0 File Offset: 0x0004EAD0
		public virtual float GetPdfY(float y)
		{
			return this.a.Bottom - y;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0004FAF0 File Offset: 0x0004EAF0
		public virtual float GetPdfX(float x)
		{
			return x + this.b.Left;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0004FB10 File Offset: 0x0004EB10
		internal virtual float a3(AreaDimensions A_0, float A_1, float A_2)
		{
			return A_1;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0004FB24 File Offset: 0x0004EB24
		internal virtual float a4(AreaDimensions A_0, float A_1, float A_2)
		{
			return A_2;
		}

		// Token: 0x060004E1 RID: 1249
		internal abstract float aw(float A_0);

		// Token: 0x060004E2 RID: 1250
		internal abstract float ax(float A_0);

		// Token: 0x060004E3 RID: 1251
		internal abstract float az();

		// Token: 0x060004E4 RID: 1252
		internal abstract float a0();

		// Token: 0x060004E5 RID: 1253
		internal abstract void a1(OperatorWriter A_0);

		// Token: 0x060004E6 RID: 1254
		internal abstract void a2(OperatorWriter A_0);

		// Token: 0x040002CD RID: 717
		private Dimensions a;

		// Token: 0x040002CE RID: 718
		private Dimensions b;
	}
}
