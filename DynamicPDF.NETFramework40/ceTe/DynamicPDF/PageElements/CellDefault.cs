using System;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000707 RID: 1799
	public class CellDefault
	{
		// Token: 0x060046BC RID: 18108 RVA: 0x0024483E File Offset: 0x0024383E
		internal CellDefault(qy A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060046BD RID: 18109 RVA: 0x00244850 File Offset: 0x00243850
		internal q1 a()
		{
			return this.a;
		}

		// Token: 0x060046BE RID: 18110 RVA: 0x00244868 File Offset: 0x00243868
		internal void a(q1 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060046BF RID: 18111 RVA: 0x00244874 File Offset: 0x00243874
		internal CellPadding b()
		{
			return this.b;
		}

		// Token: 0x060046C0 RID: 18112 RVA: 0x0024488C File Offset: 0x0024388C
		internal void a(CellPadding A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060046C1 RID: 18113 RVA: 0x00244898 File Offset: 0x00243898
		internal Border c()
		{
			return this.c;
		}

		// Token: 0x060046C2 RID: 18114 RVA: 0x002448B0 File Offset: 0x002438B0
		internal void a(Border A_0)
		{
			this.c = A_0;
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x060046C3 RID: 18115 RVA: 0x002448BC File Offset: 0x002438BC
		// (set) Token: 0x060046C4 RID: 18116 RVA: 0x002448F4 File Offset: 0x002438F4
		public Font Font
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.g();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.a(value);
				this.d.a(true);
				this.d.c(true);
				this.d.a(null);
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x060046C5 RID: 18117 RVA: 0x00244954 File Offset: 0x00243954
		// (set) Token: 0x060046C6 RID: 18118 RVA: 0x0024498C File Offset: 0x0024398C
		public float? FontSize
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.h();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.d(value);
				this.d.a(true);
				this.d.c(true);
				this.d.a(null);
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x060046C7 RID: 18119 RVA: 0x002449EC File Offset: 0x002439EC
		// (set) Token: 0x060046C8 RID: 18120 RVA: 0x00244A24 File Offset: 0x00243A24
		public Color TextColor
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.i();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.a(value);
				this.d.a(null);
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x060046C9 RID: 18121 RVA: 0x00244A68 File Offset: 0x00243A68
		// (set) Token: 0x060046CA RID: 18122 RVA: 0x00244AA0 File Offset: 0x00243AA0
		public TextAlign? Align
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.j();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.a(value);
				this.d.a(null);
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x060046CB RID: 18123 RVA: 0x00244AE4 File Offset: 0x00243AE4
		// (set) Token: 0x060046CC RID: 18124 RVA: 0x00244B1C File Offset: 0x00243B1C
		public VAlign? VAlign
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.k();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.a(value);
				this.d.a(null);
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x060046CD RID: 18125 RVA: 0x00244B60 File Offset: 0x00243B60
		// (set) Token: 0x060046CE RID: 18126 RVA: 0x00244B98 File Offset: 0x00243B98
		public Color BackgroundColor
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.l();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.b(value);
				this.d.a(null);
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x060046CF RID: 18127 RVA: 0x00244BDC File Offset: 0x00243BDC
		// (set) Token: 0x060046D0 RID: 18128 RVA: 0x00244C14 File Offset: 0x00243C14
		public bool? AutoLeading
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.a();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.a(value);
				this.d.a(true);
				this.d.c(true);
				this.d.a(null);
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x060046D1 RID: 18129 RVA: 0x00244C74 File Offset: 0x00243C74
		// (set) Token: 0x060046D2 RID: 18130 RVA: 0x00244CAC File Offset: 0x00243CAC
		public float? Leading
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.b();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.a(value);
				this.d.a(true);
				this.d.c(true);
				this.d.a(null);
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x060046D3 RID: 18131 RVA: 0x00244D0C File Offset: 0x00243D0C
		// (set) Token: 0x060046D4 RID: 18132 RVA: 0x00244D44 File Offset: 0x00243D44
		public float? ParagraphIndent
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.c();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.b(value);
				this.d.a(true);
				this.d.c(true);
				this.d.a(null);
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x060046D5 RID: 18133 RVA: 0x00244DA4 File Offset: 0x00243DA4
		// (set) Token: 0x060046D6 RID: 18134 RVA: 0x00244DDC File Offset: 0x00243DDC
		public float? ParagraphSpacing
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.d();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.c(value);
				this.d.a(true);
				this.d.c(true);
				this.d.a(null);
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x060046D7 RID: 18135 RVA: 0x00244E3C File Offset: 0x00243E3C
		// (set) Token: 0x060046D8 RID: 18136 RVA: 0x00244E74 File Offset: 0x00243E74
		public bool? RightToLeft
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.e();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.b(value);
				this.d.a(null);
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x060046D9 RID: 18137 RVA: 0x00244EB8 File Offset: 0x00243EB8
		// (set) Token: 0x060046DA RID: 18138 RVA: 0x00244EF0 File Offset: 0x00243EF0
		public bool? Underline
		{
			get
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				return this.a.f();
			}
			set
			{
				if (this.a == null)
				{
					this.a = new q1();
				}
				this.a.c(value);
				this.d.a(null);
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x060046DB RID: 18139 RVA: 0x00244F34 File Offset: 0x00243F34
		// (set) Token: 0x060046DC RID: 18140 RVA: 0x00244F70 File Offset: 0x00243F70
		public CellPadding Padding
		{
			get
			{
				if (this.b == null)
				{
					this.b = new CellPadding(this.d);
				}
				return this.b;
			}
			set
			{
				this.b = value;
				this.b.a(this.d);
				this.d.a(true);
				this.d.c(true);
				this.d.a(null);
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x060046DD RID: 18141 RVA: 0x00244FC0 File Offset: 0x00243FC0
		public Border Border
		{
			get
			{
				if (this.c == null)
				{
					this.c = new Border(this.d);
				}
				return this.c;
			}
		}

		// Token: 0x04002707 RID: 9991
		private q1 a;

		// Token: 0x04002708 RID: 9992
		private CellPadding b;

		// Token: 0x04002709 RID: 9993
		private Border c;

		// Token: 0x0400270A RID: 9994
		private qy d;
	}
}
