using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200073A RID: 1850
	public abstract class SubList : IListProperties
	{
		// Token: 0x06004A5F RID: 19039 RVA: 0x0025FD70 File Offset: 0x0025ED70
		internal SubList(float A_0, float A_1, Font A_2, float A_3, bool A_4)
		{
			this.t = A_4;
			this.i = A_0;
			this.j = A_1;
			this.a = A_2;
			this.b = A_3;
			this.f = A_2.GetDefaultLeading(A_3);
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06004A60 RID: 19040 RVA: 0x0025FE58 File Offset: 0x0025EE58
		// (set) Token: 0x06004A61 RID: 19041 RVA: 0x0025FE70 File Offset: 0x0025EE70
		public float Leading
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

		// Token: 0x06004A62 RID: 19042 RVA: 0x0025FE7C File Offset: 0x0025EE7C
		float IListProperties.e()
		{
			return this.f;
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06004A63 RID: 19043 RVA: 0x0025FE94 File Offset: 0x0025EE94
		// (set) Token: 0x06004A64 RID: 19044 RVA: 0x0025FEAC File Offset: 0x0025EEAC
		public float FontSize
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
				this.f = this.a.GetDefaultLeading(this.b);
			}
		}

		// Token: 0x06004A65 RID: 19045 RVA: 0x0025FED0 File Offset: 0x0025EED0
		float IListProperties.f()
		{
			return this.b;
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06004A66 RID: 19046 RVA: 0x0025FEE8 File Offset: 0x0025EEE8
		// (set) Token: 0x06004A67 RID: 19047 RVA: 0x0025FF00 File Offset: 0x0025EF00
		public Font Font
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

		// Token: 0x06004A68 RID: 19048 RVA: 0x0025FF0C File Offset: 0x0025EF0C
		Font IListProperties.g()
		{
			return this.a;
		}

		// Token: 0x06004A69 RID: 19049 RVA: 0x0025FF24 File Offset: 0x0025EF24
		bool IListProperties.h()
		{
			return this.t;
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06004A6B RID: 19051 RVA: 0x0025FF48 File Offset: 0x0025EF48
		// (set) Token: 0x06004A6A RID: 19050 RVA: 0x0025FF3C File Offset: 0x0025EF3C
		public bool RightToLeft
		{
			get
			{
				return this.t;
			}
			set
			{
				this.t = value;
			}
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06004A6C RID: 19052 RVA: 0x0025FF60 File Offset: 0x0025EF60
		// (set) Token: 0x06004A6D RID: 19053 RVA: 0x0025FF78 File Offset: 0x0025EF78
		public Color TextColor
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

		// Token: 0x06004A6E RID: 19054 RVA: 0x0025FF84 File Offset: 0x0025EF84
		Color IListProperties.i()
		{
			return this.c;
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06004A6F RID: 19055 RVA: 0x0025FF9C File Offset: 0x0025EF9C
		// (set) Token: 0x06004A70 RID: 19056 RVA: 0x0025FFB4 File Offset: 0x0025EFB4
		public Color TextOutlineColor
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

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06004A71 RID: 19057 RVA: 0x0025FFC0 File Offset: 0x0025EFC0
		// (set) Token: 0x06004A72 RID: 19058 RVA: 0x0025FFD8 File Offset: 0x0025EFD8
		public float TextOutlineWidth
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

		// Token: 0x06004A73 RID: 19059 RVA: 0x0025FFE4 File Offset: 0x0025EFE4
		float IListProperties.j()
		{
			return this.e;
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06004A74 RID: 19060 RVA: 0x0025FFFC File Offset: 0x0025EFFC
		// (set) Token: 0x06004A75 RID: 19061 RVA: 0x00260014 File Offset: 0x0025F014
		public float RightIndent
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

		// Token: 0x06004A76 RID: 19062 RVA: 0x00260020 File Offset: 0x0025F020
		float IListProperties.k()
		{
			return this.g;
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06004A77 RID: 19063 RVA: 0x00260038 File Offset: 0x0025F038
		// (set) Token: 0x06004A78 RID: 19064 RVA: 0x00260050 File Offset: 0x0025F050
		public float LeftIndent
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x06004A79 RID: 19065 RVA: 0x0026005C File Offset: 0x0025F05C
		float IListProperties.l()
		{
			return this.h;
		}

		// Token: 0x06004A7A RID: 19066 RVA: 0x00260074 File Offset: 0x0025F074
		internal float m()
		{
			return this.j;
		}

		// Token: 0x06004A7B RID: 19067 RVA: 0x0026008C File Offset: 0x0025F08C
		internal void a(float A_0)
		{
			this.j = A_0;
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06004A7C RID: 19068 RVA: 0x00260098 File Offset: 0x0025F098
		// (set) Token: 0x06004A7D RID: 19069 RVA: 0x002600B0 File Offset: 0x0025F0B0
		public TextAlign TextAlign
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

		// Token: 0x06004A7E RID: 19070 RVA: 0x002600BC File Offset: 0x0025F0BC
		TextAlign IListProperties.n()
		{
			return this.s;
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06004A7F RID: 19071 RVA: 0x002600D4 File Offset: 0x0025F0D4
		// (set) Token: 0x06004A80 RID: 19072 RVA: 0x002600EC File Offset: 0x0025F0EC
		public Align BulletAlign
		{
			get
			{
				return this.u;
			}
			set
			{
				this.u = value;
			}
		}

		// Token: 0x06004A81 RID: 19073 RVA: 0x002600F8 File Offset: 0x0025F0F8
		Align IListProperties.o()
		{
			return this.u;
		}

		// Token: 0x06004A82 RID: 19074 RVA: 0x00260110 File Offset: 0x0025F110
		internal void a(int A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06004A83 RID: 19075 RVA: 0x0026011C File Offset: 0x0025F11C
		int IListProperties.p()
		{
			return this.l;
		}

		// Token: 0x06004A84 RID: 19076 RVA: 0x00260134 File Offset: 0x0025F134
		string IListProperties.q()
		{
			return string.Empty;
		}

		// Token: 0x06004A85 RID: 19077 RVA: 0x0026014C File Offset: 0x0025F14C
		string IListProperties.r()
		{
			return string.Empty;
		}

		// Token: 0x06004A86 RID: 19078 RVA: 0x00260164 File Offset: 0x0025F164
		NumberingStyle IListProperties.s()
		{
			return NumberingStyle.Numeric;
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06004A87 RID: 19079 RVA: 0x00260178 File Offset: 0x0025F178
		// (set) Token: 0x06004A88 RID: 19080 RVA: 0x00260190 File Offset: 0x0025F190
		public float ParagraphIndent
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

		// Token: 0x06004A89 RID: 19081 RVA: 0x0026019C File Offset: 0x0025F19C
		float IListProperties.t()
		{
			return this.m;
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06004A8A RID: 19082 RVA: 0x002601B4 File Offset: 0x0025F1B4
		// (set) Token: 0x06004A8B RID: 19083 RVA: 0x002601CC File Offset: 0x0025F1CC
		public float BulletAreaWidth
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

		// Token: 0x06004A8C RID: 19084 RVA: 0x002601D8 File Offset: 0x0025F1D8
		float IListProperties.u()
		{
			return this.n;
		}

		// Token: 0x06004A8D RID: 19085 RVA: 0x002601F0 File Offset: 0x0025F1F0
		internal float a(ae7 A_0)
		{
			return this.k.a(A_0);
		}

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06004A8E RID: 19086 RVA: 0x00260210 File Offset: 0x0025F210
		public ListItemList Items
		{
			get
			{
				return this.k;
			}
		}

		// Token: 0x06004A8F RID: 19087 RVA: 0x00260228 File Offset: 0x0025F228
		internal void a(ListItemList A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06004A90 RID: 19088 RVA: 0x00260234 File Offset: 0x0025F234
		internal float v()
		{
			return this.i;
		}

		// Token: 0x06004A91 RID: 19089 RVA: 0x0026024C File Offset: 0x0025F24C
		internal void b(float A_0)
		{
			this.i = A_0;
		}

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06004A92 RID: 19090 RVA: 0x00260258 File Offset: 0x0025F258
		// (set) Token: 0x06004A93 RID: 19091 RVA: 0x00260270 File Offset: 0x0025F270
		public float ListItemTopMargin
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

		// Token: 0x06004A94 RID: 19092 RVA: 0x0026027C File Offset: 0x0025F27C
		float IListProperties.w()
		{
			return this.o;
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06004A95 RID: 19093 RVA: 0x00260294 File Offset: 0x0025F294
		// (set) Token: 0x06004A96 RID: 19094 RVA: 0x002602AC File Offset: 0x0025F2AC
		public float ListItemBottomMargin
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

		// Token: 0x06004A97 RID: 19095 RVA: 0x002602B8 File Offset: 0x0025F2B8
		float IListProperties.x()
		{
			return this.p;
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06004A98 RID: 19096 RVA: 0x002602D0 File Offset: 0x0025F2D0
		// (set) Token: 0x06004A99 RID: 19097 RVA: 0x002602E8 File Offset: 0x0025F2E8
		public bool StrikeThrough
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

		// Token: 0x06004A9A RID: 19098 RVA: 0x002602F4 File Offset: 0x0025F2F4
		bool IListProperties.y()
		{
			return this.q;
		}

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06004A9B RID: 19099 RVA: 0x0026030C File Offset: 0x0025F30C
		// (set) Token: 0x06004A9C RID: 19100 RVA: 0x00260324 File Offset: 0x0025F324
		public float BulletSize
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

		// Token: 0x06004A9D RID: 19101 RVA: 0x00260330 File Offset: 0x0025F330
		float IListProperties.z()
		{
			return this.r;
		}

		// Token: 0x06004A9E RID: 19102 RVA: 0x00260348 File Offset: 0x0025F348
		internal float a(PageWriter A_0, float A_1, float A_2, ae7 A_3, float A_4)
		{
			this.k.a(this.y);
			A_2 = this.k.i8(A_0, A_1, A_2, A_3, A_4);
			return A_2;
		}

		// Token: 0x06004A9F RID: 19103 RVA: 0x00260384 File Offset: 0x0025F384
		internal ListItem aa()
		{
			return this.k.a();
		}

		// Token: 0x06004AA0 RID: 19104 RVA: 0x002603A1 File Offset: 0x0025F3A1
		internal void c(float A_0)
		{
			this.y = A_0;
		}

		// Token: 0x06004AA1 RID: 19105 RVA: 0x002603AC File Offset: 0x0025F3AC
		internal ae7 ab()
		{
			return this.z;
		}

		// Token: 0x06004AA2 RID: 19106 RVA: 0x002603C4 File Offset: 0x0025F3C4
		internal void a(ae7 A_0, ae7 A_1, float A_2)
		{
			this.k.a(this.y);
			this.k.a(A_0, A_1, A_2);
			A_1 = this.k.c();
			this.z = A_1;
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06004AA3 RID: 19107 RVA: 0x002603FC File Offset: 0x0025F3FC
		// (set) Token: 0x06004AA4 RID: 19108 RVA: 0x00260414 File Offset: 0x0025F414
		public Tag Tag
		{
			get
			{
				return this.v;
			}
			set
			{
				this.v = value;
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06004AA5 RID: 19109 RVA: 0x00260420 File Offset: 0x0025F420
		// (set) Token: 0x06004AA6 RID: 19110 RVA: 0x00260438 File Offset: 0x0025F438
		public int TagOrder
		{
			get
			{
				return this.w;
			}
			set
			{
				this.w = value;
			}
		}

		// Token: 0x06004AA7 RID: 19111 RVA: 0x00260444 File Offset: 0x0025F444
		internal ListItem ac()
		{
			return this.x;
		}

		// Token: 0x06004AA8 RID: 19112 RVA: 0x0026045C File Offset: 0x0025F45C
		internal void a(ListItem A_0)
		{
			this.x = A_0;
		}

		// Token: 0x0400286A RID: 10346
		private Font a;

		// Token: 0x0400286B RID: 10347
		private float b;

		// Token: 0x0400286C RID: 10348
		private Color c = Grayscale.Black;

		// Token: 0x0400286D RID: 10349
		private Color d;

		// Token: 0x0400286E RID: 10350
		private float e = 1f;

		// Token: 0x0400286F RID: 10351
		private float f;

		// Token: 0x04002870 RID: 10352
		private float g = 0f;

		// Token: 0x04002871 RID: 10353
		private float h = 26f;

		// Token: 0x04002872 RID: 10354
		private float i;

		// Token: 0x04002873 RID: 10355
		private float j;

		// Token: 0x04002874 RID: 10356
		private ListItemList k;

		// Token: 0x04002875 RID: 10357
		private int l = 1;

		// Token: 0x04002876 RID: 10358
		private float m = 0f;

		// Token: 0x04002877 RID: 10359
		private float n = 22f;

		// Token: 0x04002878 RID: 10360
		private float o = 0f;

		// Token: 0x04002879 RID: 10361
		private float p = 0f;

		// Token: 0x0400287A RID: 10362
		private bool q = false;

		// Token: 0x0400287B RID: 10363
		private float r = 0f;

		// Token: 0x0400287C RID: 10364
		private TextAlign s = TextAlign.Left;

		// Token: 0x0400287D RID: 10365
		private bool t = false;

		// Token: 0x0400287E RID: 10366
		private Align u = Align.Right;

		// Token: 0x0400287F RID: 10367
		private Tag v;

		// Token: 0x04002880 RID: 10368
		private int w = 0;

		// Token: 0x04002881 RID: 10369
		private ListItem x = null;

		// Token: 0x04002882 RID: 10370
		private float y = 0f;

		// Token: 0x04002883 RID: 10371
		private ae7 z;
	}
}
