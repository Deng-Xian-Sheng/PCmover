using System;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000741 RID: 1857
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Use Table2 class instead.", false)]
	public class Table : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06004B1D RID: 19229 RVA: 0x00263358 File Offset: 0x00262358
		public Table(float x, float y, float width, float height) : this(x, y, width, height, Table.j, 12f, Table.k, Table.l)
		{
		}

		// Token: 0x06004B1E RID: 19230 RVA: 0x00263388 File Offset: 0x00262388
		public Table(float x, float y, float width, float height, Font font, float size) : this(x, y, width, height, font, size, Table.k, Table.l)
		{
		}

		// Token: 0x06004B1F RID: 19231 RVA: 0x002633B4 File Offset: 0x002623B4
		public Table(float x, float y, float width, float height, Font font, float size, Color textColor, Color backColor)
		{
			this.h = true;
			this.i = true;
			base..ctor(x, y, height);
			this.c = width;
			this.b = new acy();
			this.b.f = font;
			this.b.g = size;
			this.b.i = textColor;
			this.b.e = backColor;
			this.d = 0;
			this.f = 0;
		}

		// Token: 0x06004B20 RID: 19232 RVA: 0x00263430 File Offset: 0x00262430
		internal Table(Table A_0, int A_1, int A_2, float A_3, float A_4, float A_5, float A_6)
		{
			this.h = true;
			this.i = true;
			base..ctor(A_3, A_4, A_6);
			this.c = A_5;
			this.d = A_1;
			this.f = A_2;
			this.b = A_0.b;
		}

		// Token: 0x06004B21 RID: 19233 RVA: 0x0026347C File Offset: 0x0026247C
		public Table GetOverflowRows()
		{
			return this.GetOverflowRows(this.X, this.Y, this.c, this.Height);
		}

		// Token: 0x06004B22 RID: 19234 RVA: 0x002634AC File Offset: 0x002624AC
		public Table GetOverflowRows(float x, float y)
		{
			return this.GetOverflowRows(x, y, this.c, this.Height);
		}

		// Token: 0x06004B23 RID: 19235 RVA: 0x002634D4 File Offset: 0x002624D4
		public Table GetOverflowRows(float x, float y, float width, float height)
		{
			Table result;
			if (this.b.b.Count == 0)
			{
				result = null;
			}
			else
			{
				if (this.h || this.b.s)
				{
					this.e = this.b.a(this.d, this.Height);
					this.h = false;
				}
				if (this.e == this.b.b.Count - 1)
				{
					result = null;
				}
				else
				{
					result = new Table(this, this.e + 1, this.f, x, y, width, height)
					{
						Tag = this.Tag,
						TagOrder = this.TagOrder
					};
				}
			}
			return result;
		}

		// Token: 0x06004B24 RID: 19236 RVA: 0x002635A8 File Offset: 0x002625A8
		public Table GetOverflowColumns()
		{
			return this.GetOverflowColumns(this.X, this.Y, this.c, this.Height);
		}

		// Token: 0x06004B25 RID: 19237 RVA: 0x002635D8 File Offset: 0x002625D8
		public Table GetOverflowColumns(float x, float y)
		{
			return this.GetOverflowColumns(x, y, this.c, this.Height);
		}

		// Token: 0x06004B26 RID: 19238 RVA: 0x00263600 File Offset: 0x00262600
		public Table GetOverflowColumns(float x, float y, float width, float height)
		{
			Table result;
			if (this.b.a.Count == 0)
			{
				result = null;
			}
			else
			{
				if (this.i || this.b.t)
				{
					this.g = this.b.b(this.f, this.c);
					this.i = false;
				}
				if (this.g == this.b.a.Count - 1)
				{
					result = null;
				}
				else
				{
					result = new Table(this, this.d, this.g + 1, x, y, width, height)
					{
						Tag = this.Tag,
						TagOrder = this.TagOrder
					};
				}
			}
			return result;
		}

		// Token: 0x06004B27 RID: 19239 RVA: 0x002636D4 File Offset: 0x002626D4
		public float GetVisibleWidth()
		{
			if (this.i || this.b.t)
			{
				this.g = this.b.b(this.f, this.c);
				this.i = false;
			}
			float num = 0f;
			if (this.b.k > 0 && this.f > 0)
			{
				num += this.b.b();
			}
			for (int i = this.f; i <= this.g; i++)
			{
				num += this.b.a[i].Width;
			}
			return num;
		}

		// Token: 0x06004B28 RID: 19240 RVA: 0x00263798 File Offset: 0x00262798
		public float GetVisibleHeight()
		{
			if (this.h || this.b.s)
			{
				this.e = this.b.a(this.d, this.Height);
				this.h = false;
			}
			float num = 0f;
			if (this.b.n > 0 && this.d > 0)
			{
				num += this.b.a();
			}
			for (int i = this.d; i <= this.e; i++)
			{
				num += this.b.b[i].d();
			}
			return num;
		}

		// Token: 0x06004B29 RID: 19241 RVA: 0x0026385C File Offset: 0x0026285C
		public float GetRequiredWidth()
		{
			float num = 0f;
			if (this.b.k > 0 && this.f > 0)
			{
				num += this.b.b();
			}
			for (int i = this.f; i <= this.b.a.Count - 1; i++)
			{
				num += this.b.a[i].Width;
			}
			return num;
		}

		// Token: 0x06004B2A RID: 19242 RVA: 0x002638E8 File Offset: 0x002628E8
		public float GetRequiredHeight()
		{
			float num = 0f;
			if (this.b.n > 0 && this.d > 0)
			{
				num += this.b.a();
			}
			for (int i = this.d; i <= this.b.b.Count - 1; i++)
			{
				num += this.b.b[i].ActualRowHeight;
			}
			return num;
		}

		// Token: 0x06004B2B RID: 19243 RVA: 0x00263974 File Offset: 0x00262974
		public bool HasOverflowRows()
		{
			if (this.h || this.b.s)
			{
				this.e = this.b.a(this.d, this.Height);
				this.h = false;
			}
			return this.e != this.b.b.Count - 1;
		}

		// Token: 0x06004B2C RID: 19244 RVA: 0x002639F0 File Offset: 0x002629F0
		public bool HasOverflowColumns()
		{
			if (this.i || this.b.t)
			{
				this.g = this.b.b(this.f, this.c);
				this.i = false;
			}
			return this.g != this.b.a.Count - 1;
		}

		// Token: 0x06004B2D RID: 19245 RVA: 0x00263A6C File Offset: 0x00262A6C
		public int GetVisibleRowCount()
		{
			if (this.h || this.b.s)
			{
				this.e = this.b.a(this.d, this.Height);
				this.h = false;
			}
			int result;
			if (this.d > 0 && this.b.n > 0)
			{
				result = this.e - this.d + this.b.o + 1;
			}
			else
			{
				result = this.e - this.d + 1;
			}
			return result;
		}

		// Token: 0x06004B2E RID: 19246 RVA: 0x00263B14 File Offset: 0x00262B14
		public int GetVisibleColumnCount()
		{
			if (this.i || this.b.t)
			{
				this.g = this.b.b(this.f, this.c);
				this.i = false;
			}
			int result;
			if (this.f > 0 && this.b.k > 0)
			{
				result = this.g - this.f + this.b.l + 1;
			}
			else
			{
				result = this.g - this.f + 1;
			}
			return result;
		}

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06004B2F RID: 19247 RVA: 0x00263BBC File Offset: 0x00262BBC
		// (set) Token: 0x06004B30 RID: 19248 RVA: 0x00263BD4 File Offset: 0x00262BD4
		public override float X
		{
			get
			{
				return base.X;
			}
			set
			{
				base.X = value;
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06004B31 RID: 19249 RVA: 0x00263BE0 File Offset: 0x00262BE0
		// (set) Token: 0x06004B32 RID: 19250 RVA: 0x00263BF8 File Offset: 0x00262BF8
		public override float Y
		{
			get
			{
				return base.Y;
			}
			set
			{
				base.Y = value;
			}
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06004B33 RID: 19251 RVA: 0x00263C04 File Offset: 0x00262C04
		// (set) Token: 0x06004B34 RID: 19252 RVA: 0x00263C1C File Offset: 0x00262C1C
		public float Width
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
				this.b.t = true;
			}
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06004B35 RID: 19253 RVA: 0x00263C34 File Offset: 0x00262C34
		// (set) Token: 0x06004B36 RID: 19254 RVA: 0x00263C4C File Offset: 0x00262C4C
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
				this.b.s = true;
			}
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06004B37 RID: 19255 RVA: 0x00263C64 File Offset: 0x00262C64
		public RowList Rows
		{
			get
			{
				return this.b.b;
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06004B38 RID: 19256 RVA: 0x00263C84 File Offset: 0x00262C84
		public ColumnList Columns
		{
			get
			{
				return this.b.a;
			}
		}

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06004B39 RID: 19257 RVA: 0x00263CA4 File Offset: 0x00262CA4
		// (set) Token: 0x06004B3A RID: 19258 RVA: 0x00263CC1 File Offset: 0x00262CC1
		public Font Font
		{
			get
			{
				return this.b.f;
			}
			set
			{
				this.b.f = value;
				this.b.s = true;
				this.b.u = true;
			}
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06004B3B RID: 19259 RVA: 0x00263CE8 File Offset: 0x00262CE8
		// (set) Token: 0x06004B3C RID: 19260 RVA: 0x00263D05 File Offset: 0x00262D05
		public float FontSize
		{
			get
			{
				return this.b.g;
			}
			set
			{
				this.b.g = value;
				this.b.s = true;
				this.b.u = true;
			}
		}

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06004B3D RID: 19261 RVA: 0x00263D2C File Offset: 0x00262D2C
		// (set) Token: 0x06004B3E RID: 19262 RVA: 0x00263D49 File Offset: 0x00262D49
		public Color TextColor
		{
			get
			{
				return this.b.i;
			}
			set
			{
				this.b.i = value;
			}
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x06004B3F RID: 19263 RVA: 0x00263D58 File Offset: 0x00262D58
		// (set) Token: 0x06004B40 RID: 19264 RVA: 0x00263D75 File Offset: 0x00262D75
		public Color BackgroundColor
		{
			get
			{
				return this.b.e;
			}
			set
			{
				this.b.e = value;
			}
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06004B41 RID: 19265 RVA: 0x00263D84 File Offset: 0x00262D84
		// (set) Token: 0x06004B42 RID: 19266 RVA: 0x00263DA1 File Offset: 0x00262DA1
		public TextAlign Align
		{
			get
			{
				return this.b.d;
			}
			set
			{
				this.b.d = value;
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06004B43 RID: 19267 RVA: 0x00263DB0 File Offset: 0x00262DB0
		// (set) Token: 0x06004B44 RID: 19268 RVA: 0x00263DCD File Offset: 0x00262DCD
		public VAlign VAlign
		{
			get
			{
				return this.b.j;
			}
			set
			{
				this.b.j = value;
			}
		}

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06004B45 RID: 19269 RVA: 0x00263DDC File Offset: 0x00262DDC
		// (set) Token: 0x06004B46 RID: 19270 RVA: 0x00263DFC File Offset: 0x00262DFC
		public float Padding
		{
			get
			{
				return this.b.h;
			}
			set
			{
				if (value <= 0f)
				{
					this.b.h = 0f;
				}
				else
				{
					this.b.h = value;
				}
				this.b.s = true;
				this.b.u = true;
			}
		}

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06004B47 RID: 19271 RVA: 0x00263E4C File Offset: 0x00262E4C
		// (set) Token: 0x06004B48 RID: 19272 RVA: 0x00263E6C File Offset: 0x00262E6C
		public int RepeatRowHeaderCount
		{
			get
			{
				return this.b.k;
			}
			set
			{
				if (value <= 0)
				{
					this.b.k = 0;
				}
				else
				{
					this.b.k = value;
				}
				this.b.t = true;
				this.b.z = true;
				this.b.aa = false;
			}
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06004B49 RID: 19273 RVA: 0x00263EC0 File Offset: 0x00262EC0
		// (set) Token: 0x06004B4A RID: 19274 RVA: 0x00263EE0 File Offset: 0x00262EE0
		public int RepeatColumnHeaderCount
		{
			get
			{
				return this.b.n;
			}
			set
			{
				if (value <= 0)
				{
					this.b.n = 0;
				}
				else
				{
					this.b.n = value;
				}
				this.b.s = true;
				this.b.y = true;
				this.b.ab = false;
			}
		}

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06004B4B RID: 19275 RVA: 0x00263F34 File Offset: 0x00262F34
		// (set) Token: 0x06004B4C RID: 19276 RVA: 0x00263F54 File Offset: 0x00262F54
		public float BorderWidth
		{
			get
			{
				return this.b.q;
			}
			set
			{
				if (value <= 0f)
				{
					this.b.q = 0f;
				}
				else
				{
					this.b.q = value;
				}
			}
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06004B4D RID: 19277 RVA: 0x00263F8C File Offset: 0x00262F8C
		// (set) Token: 0x06004B4E RID: 19278 RVA: 0x00263FA9 File Offset: 0x00262FA9
		public Color BorderColor
		{
			get
			{
				return this.b.r;
			}
			set
			{
				this.b.r = value;
			}
		}

		// Token: 0x06004B4F RID: 19279 RVA: 0x00263FB8 File Offset: 0x00262FB8
		internal override byte cb()
		{
			return 48;
		}

		// Token: 0x06004B50 RID: 19280 RVA: 0x00263FCC File Offset: 0x00262FCC
		protected override void DrawRotated(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				this.b(writer);
			}
			else
			{
				if (this.h || this.b.s)
				{
					this.e = this.b.a(this.d, this.Height);
					this.h = false;
				}
				if (this.i || this.b.t)
				{
					this.g = this.b.b(this.f, this.c);
					this.i = false;
				}
				acx acx = new acx(this, writer);
				this.b.b.a(acx, false);
				acx.a(this.X);
				acx.b(this.Y);
				this.b.b.a(acx, true);
				if (this.b.q > 0f)
				{
					this.a(writer);
				}
			}
		}

		// Token: 0x06004B51 RID: 19281 RVA: 0x002640EC File Offset: 0x002630EC
		private void b(PageWriter A_0)
		{
			TagOptions tag = null;
			acx acx = new acx(this, A_0);
			if (this.Tag != null && !this.Tag.g())
			{
				this.Tag.e(A_0, this);
				tag = A_0.Document.Tag;
				A_0.Document.Tag = null;
			}
			if (this.h || this.b.s)
			{
				this.e = this.b.a(this.d, this.Height);
				this.h = false;
			}
			if (this.i || this.b.t)
			{
				this.g = this.b.b(this.f, this.c);
				this.i = false;
			}
			if (A_0.Document.Tag != null)
			{
				A_0.SetGraphicsMode();
				Artifact.a(A_0);
			}
			this.b.b.b(acx, false);
			acx.a(this.X);
			acx.b(this.Y);
			if (A_0.Document.Tag != null)
			{
				Tag.a(A_0);
			}
			this.b.b.b(acx, true);
			if (this.b.q > 0f)
			{
				this.a(A_0);
			}
			if (this.Tag != null && !this.Tag.g())
			{
				Tag.a(A_0);
				A_0.Document.Tag = tag;
			}
		}

		// Token: 0x06004B52 RID: 19282 RVA: 0x002642A0 File Offset: 0x002632A0
		private void a(PageWriter A_0)
		{
			A_0.SetGraphicsMode();
			if (A_0.Document.Tag != null)
			{
				Artifact.a(A_0);
			}
			A_0.SetStrokeColor(this.b.r);
			A_0.SetLineWidth(this.b.q);
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.Write_re(base.X, base.Y, this.GetVisibleWidth(), this.GetVisibleHeight());
			A_0.Write_s_();
			if (A_0.Document.Tag != null)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06004B53 RID: 19283 RVA: 0x00264340 File Offset: 0x00263340
		internal acy a()
		{
			return this.b;
		}

		// Token: 0x06004B54 RID: 19284 RVA: 0x00264358 File Offset: 0x00263358
		internal int b()
		{
			return this.d;
		}

		// Token: 0x06004B55 RID: 19285 RVA: 0x00264370 File Offset: 0x00263370
		internal int c()
		{
			return this.e;
		}

		// Token: 0x06004B56 RID: 19286 RVA: 0x00264388 File Offset: 0x00263388
		internal int d()
		{
			return this.f;
		}

		// Token: 0x06004B57 RID: 19287 RVA: 0x002643A0 File Offset: 0x002633A0
		internal int e()
		{
			return this.g;
		}

		// Token: 0x040028B1 RID: 10417
		private new const float a = 12f;

		// Token: 0x040028B2 RID: 10418
		private acy b;

		// Token: 0x040028B3 RID: 10419
		private float c;

		// Token: 0x040028B4 RID: 10420
		private new int d;

		// Token: 0x040028B5 RID: 10421
		private int e;

		// Token: 0x040028B6 RID: 10422
		private int f;

		// Token: 0x040028B7 RID: 10423
		private int g;

		// Token: 0x040028B8 RID: 10424
		private bool h;

		// Token: 0x040028B9 RID: 10425
		private bool i;

		// Token: 0x040028BA RID: 10426
		private static Font j = Font.Helvetica;

		// Token: 0x040028BB RID: 10427
		private static Color k = Grayscale.Black;

		// Token: 0x040028BC RID: 10428
		private static Color l = null;
	}
}
