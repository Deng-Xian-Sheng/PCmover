using System;
using System.Collections;
using System.IO;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Html
{
	// Token: 0x020007F6 RID: 2038
	public class HtmlArea : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x060052BE RID: 21182 RVA: 0x0028F124 File Offset: 0x0028E124
		public HtmlArea(Uri uri, float x, float y, float width, float height) : base(x, y, height)
		{
			byte[] array = n9.a(uri);
			if (array != null && array.Length > 0)
			{
				base.d(1);
				this.d = n9.b(uri);
				this.b = width;
				this.a = this.c(array);
				this.f = new Hashtable();
				this.k();
			}
		}

		// Token: 0x060052BF RID: 21183 RVA: 0x0028F1C8 File Offset: 0x0028E1C8
		public HtmlArea(Uri uri, float x, float y, Uri baseHref, float width, float height) : base(x, y, height)
		{
			byte[] array = n9.a(uri);
			if (array != null && array.Length > 0)
			{
				base.d(1);
				this.d = baseHref;
				this.b = width;
				this.a = this.c(array);
				this.f = new Hashtable();
				this.k();
			}
		}

		// Token: 0x060052C0 RID: 21184 RVA: 0x0028F268 File Offset: 0x0028E268
		public HtmlArea(Stream stream, float x, float y, float width, float height) : base(x, y, height)
		{
			if (stream != null && stream.Length > 0L)
			{
				base.d(1);
				byte[] array = new byte[stream.Length - stream.Position];
				stream.Read(array, (int)stream.Position, array.Length);
				this.a = this.c(array);
				this.f = new Hashtable();
				this.b = width;
				this.k();
			}
		}

		// Token: 0x060052C1 RID: 21185 RVA: 0x0028F324 File Offset: 0x0028E324
		public HtmlArea(Stream stream, float x, float y, Uri baseHref, float width, float height) : base(x, y, height)
		{
			if (stream != null && stream.Length > 0L)
			{
				base.d(1);
				byte[] array = new byte[stream.Length - stream.Position];
				stream.Read(array, (int)stream.Position, array.Length);
				this.d = baseHref;
				this.a = this.c(array);
				this.f = new Hashtable();
				this.b = width;
				this.k();
			}
		}

		// Token: 0x060052C2 RID: 21186 RVA: 0x0028F3E6 File Offset: 0x0028E3E6
		public HtmlArea(string text, float x, float y, float width, float height) : this(text, x, y, null, width, height)
		{
		}

		// Token: 0x060052C3 RID: 21187 RVA: 0x0028F3FC File Offset: 0x0028E3FC
		public HtmlArea(string text, float x, float y, Uri baseHref, float width, float height) : base(x, y, height)
		{
			base.d(1);
			if (text != null)
			{
				this.a = text.ToCharArray();
				this.d = baseHref;
				if (this.a.Length > 0)
				{
					this.g = Encoding.Unicode;
					this.f = new Hashtable();
					this.b = width;
					this.k();
				}
			}
		}

		// Token: 0x060052C4 RID: 21188 RVA: 0x0028F4A8 File Offset: 0x0028E4A8
		internal HtmlArea(HtmlArea A_0, float A_1, float A_2, float A_3, float A_4) : base(A_1, A_2, A_4)
		{
			this.b = A_3;
			this.f = A_0.f;
			this.e = ((A_0.e != null) ? A_0.e.a() : null);
			if (this.e != null)
			{
				this.e.c(this.e.n());
				this.e.a(this);
			}
		}

		// Token: 0x060052C5 RID: 21189 RVA: 0x0028F558 File Offset: 0x0028E558
		internal Uri c()
		{
			return this.d;
		}

		// Token: 0x060052C6 RID: 21190 RVA: 0x0028F570 File Offset: 0x0028E570
		internal lc d()
		{
			return this.e;
		}

		// Token: 0x060052C7 RID: 21191 RVA: 0x0028F588 File Offset: 0x0028E588
		internal gn e()
		{
			return this.j;
		}

		// Token: 0x060052C8 RID: 21192 RVA: 0x0028F5A0 File Offset: 0x0028E5A0
		internal void a(gn A_0)
		{
			this.j = A_0;
		}

		// Token: 0x060052C9 RID: 21193 RVA: 0x0028F5AC File Offset: 0x0028E5AC
		internal ij f()
		{
			return this.h;
		}

		// Token: 0x060052CA RID: 21194 RVA: 0x0028F5C4 File Offset: 0x0028E5C4
		internal void a(ij A_0)
		{
			this.h = A_0;
		}

		// Token: 0x060052CB RID: 21195 RVA: 0x0028F5D0 File Offset: 0x0028E5D0
		internal bool g()
		{
			return this.i;
		}

		// Token: 0x060052CC RID: 21196 RVA: 0x0028F5E8 File Offset: 0x0028E5E8
		internal void a(bool A_0)
		{
			this.i = A_0;
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x060052CD RID: 21197 RVA: 0x0028F5F4 File Offset: 0x0028E5F4
		// (set) Token: 0x060052CE RID: 21198 RVA: 0x0028F60C File Offset: 0x0028E60C
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (base.Height != value)
				{
					base.Height = value;
				}
			}
		}

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x060052CF RID: 21199 RVA: 0x0028F634 File Offset: 0x0028E634
		// (set) Token: 0x060052D0 RID: 21200 RVA: 0x0028F64C File Offset: 0x0028E64C
		public float Width
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

		// Token: 0x060052D1 RID: 21201 RVA: 0x0028F658 File Offset: 0x0028E658
		internal Hashtable h()
		{
			return this.f;
		}

		// Token: 0x060052D2 RID: 21202 RVA: 0x0028F670 File Offset: 0x0028E670
		internal Encoding i()
		{
			return this.g;
		}

		// Token: 0x060052D3 RID: 21203 RVA: 0x0028F688 File Offset: 0x0028E688
		private void b()
		{
			this.a();
			if (this.e != null)
			{
				this.e.a(this);
				if (!this.e.b())
				{
					this.e.i(x5.a(this.X));
					this.e.j(x5.a(this.Y));
					this.e.dj(x5.a(this.b), x5.a(this.Height));
				}
			}
		}

		// Token: 0x060052D4 RID: 21204 RVA: 0x0028F720 File Offset: 0x0028E720
		internal ij j()
		{
			ij result;
			if (this.e == null)
			{
				this.a();
				lc lc = this.e;
				this.e = null;
				result = lc.c();
			}
			else
			{
				result = this.e.c();
			}
			return result;
		}

		// Token: 0x060052D5 RID: 21205 RVA: 0x0028F770 File Offset: 0x0028E770
		private void a()
		{
			eh eh = null;
			if (this.c != null)
			{
				for (int i = 0; i < this.c.h(); i++)
				{
					if (this.c.b(i) is eh)
					{
						eh = (eh)this.c.b(i);
						break;
					}
				}
				if (eh == null)
				{
					eh = new eh();
					for (int i = 0; i < this.c.h(); i++)
					{
						eh.cg().a(this.c.b(i));
					}
				}
				if (eh.cg().h() > 0)
				{
					this.c.q().s();
					this.a(eh);
					if (this.c.q().d() == null)
					{
						this.c.q().a(this.d);
					}
					if (this.h == null)
					{
						this.e = (lc)eh.cm(this.c.q(), null);
					}
					else
					{
						this.h.b(this.i);
						this.e = (lc)eh.cm(this.h, null);
					}
				}
			}
		}

		// Token: 0x060052D6 RID: 21206 RVA: 0x0028F8EC File Offset: 0x0028E8EC
		private char[] c(byte[] A_0)
		{
			Encoding[] array = new Encoding[]
			{
				Encoding.BigEndianUnicode,
				Encoding.Unicode,
				Encoding.UTF8,
				Encoding.UTF32
			};
			int num = 0;
			while (this.g == null && num < array.Length)
			{
				byte[] preamble = array[num].GetPreamble();
				bool flag = true;
				int num2 = 0;
				while (flag && num2 < preamble.Length)
				{
					flag = (preamble[num2] == A_0[num2]);
					num2++;
				}
				if (flag)
				{
					this.g = array[num];
				}
				num++;
			}
			if (this.g == null)
			{
				this.g = this.b(A_0);
			}
			return this.g.GetString(A_0).Trim().ToCharArray();
		}

		// Token: 0x060052D7 RID: 21207 RVA: 0x0028F9D8 File Offset: 0x0028E9D8
		private Encoding b(byte[] A_0)
		{
			string text = this.a(A_0);
			Encoding result;
			if (text != string.Empty)
			{
				kg a_ = new kg(text.ToCharArray(), this);
				result = d3.a(a_);
			}
			else
			{
				result = Encoding.UTF8;
			}
			return result;
		}

		// Token: 0x060052D8 RID: 21208 RVA: 0x0028FA20 File Offset: 0x0028EA20
		private string a(byte[] A_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			bool flag2 = false;
			int num4 = 0;
			while (num4 < A_0.Length && !flag)
			{
				while (num4 < A_0.Length && A_0[num4] <= 32)
				{
					num4++;
				}
				if (num4 + 3 < A_0.Length && A_0[num4] == 60 && A_0[num4 + 1] == 33 && A_0[num4 + 2] == 45 && A_0[num4 + 3] == 45)
				{
					num4 += 4;
					bool flag3 = true;
					while (flag3)
					{
						if (num4 + 2 < A_0.Length && A_0[num4] == 45 && A_0[num4 + 1] == 45 && A_0[num4 + 2] == 62)
						{
							num4 += 3;
							flag3 = false;
						}
						else
						{
							num4++;
						}
					}
				}
				if (num4 + 4 < A_0.Length && A_0[num4] == 60 && (A_0[num4 + 1] == 109 || A_0[num4 + 1] == 77) && (A_0[num4 + 2] == 101 || A_0[num4 + 2] == 69) && (A_0[num4 + 3] == 116 || A_0[num4 + 3] == 84) && (A_0[num4 + 4] == 97 || A_0[num4 + 4] == 65))
				{
					bool flag4 = false;
					num = num4;
					num3++;
					while (!flag4)
					{
						if (num4 + 6 < A_0.Length && (A_0[num4] == 99 || A_0[num4] == 67) && (A_0[num4 + 1] == 104 || A_0[num4 + 1] == 72) && (A_0[num4 + 2] == 97 || A_0[num4 + 2] == 65) && (A_0[num4 + 3] == 114 || A_0[num4 + 3] == 82) && (A_0[num4 + 4] == 115 || A_0[num4 + 4] == 83) && (A_0[num4 + 5] == 101 || A_0[num4 + 5] == 69) && (A_0[num4 + 6] == 116 || A_0[num4 + 6] == 84))
						{
							num3 += 6;
							num4 += 6;
							flag2 = true;
						}
						else if (A_0[num4] == 62)
						{
							if (flag2)
							{
								num2 = num4 + 1;
							}
							flag4 = true;
						}
						else
						{
							num4++;
							num3++;
						}
					}
				}
				if (num4 + 5 < A_0.Length && A_0[num4] == 60 && A_0[num4 + 1] == 47 && (A_0[num4 + 2] == 104 || A_0[num4 + 2] == 72) && (A_0[num4 + 3] == 101 || A_0[num4 + 3] == 69) && (A_0[num4 + 4] == 97 || A_0[num4 + 4] == 65) && (A_0[num4 + 5] == 100 || A_0[num4 + 5] == 68))
				{
					num4 += 6;
					flag = true;
				}
				else if (!flag2)
				{
					num4++;
				}
				else
				{
					flag = true;
				}
			}
			string result = string.Empty;
			if (flag2 && num2 - num > 0)
			{
				result = ae5.a(1252).GetString(A_0, num, num2 - num);
			}
			return result;
		}

		// Token: 0x060052D9 RID: 21209 RVA: 0x0028FD7C File Offset: 0x0028ED7C
		private void a(eh A_0)
		{
			if (this.j != gn.e)
			{
				((ej)A_0.ch()).a(this.j);
			}
		}

		// Token: 0x060052DA RID: 21210 RVA: 0x0028FDB0 File Offset: 0x0028EDB0
		protected override void DrawRotated(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				this.a(writer);
			}
			else
			{
				if (this.e == null)
				{
					this.b();
				}
				if (this.e != null)
				{
					this.e.a(this);
					if (!this.e.b())
					{
						this.e.i(x5.a(this.X));
						this.e.j(x5.a(this.Y));
						this.e.dj(x5.a(this.b), x5.a(this.Height));
					}
					writer.DocumentWriter.a(this, writer.PageNumber);
					this.e.dk(writer, x5.a(base.X), x5.a(base.Y));
				}
			}
		}

		// Token: 0x060052DB RID: 21211 RVA: 0x0028FEB4 File Offset: 0x0028EEB4
		private void a(PageWriter A_0)
		{
			A_0.SetTextMode();
			if (A_0.Document.Tag != null)
			{
				if (this.Tag == null)
				{
					new StructureElement(TagType.Html, true)
					{
						Order = this.TagOrder
					}.e(A_0, this);
				}
				else
				{
					this.Tag.e(A_0, this);
				}
			}
			if (this.e == null)
			{
				this.b();
			}
			if (this.e != null)
			{
				A_0.DocumentWriter.a(this, A_0.PageNumber);
				this.e.dk(A_0, x5.a(base.X), x5.a(base.Y));
				Tag.a(A_0);
			}
			A_0.SetCharacterSpacing(0f);
		}

		// Token: 0x060052DC RID: 21212 RVA: 0x0028FF98 File Offset: 0x0028EF98
		internal void k()
		{
			if (this.c == null)
			{
				kg a_ = new kg(this.a, this);
				this.c = new d3(a_);
				this.c.a(new ij());
				this.c.a(this.d);
				this.c.cq();
			}
		}

		// Token: 0x060052DD RID: 21213 RVA: 0x00290000 File Offset: 0x0028F000
		public HtmlArea GetOverflowHtmlArea(float x, float y, float height)
		{
			if (this.e == null)
			{
				this.b();
			}
			else if (!this.e.b())
			{
				this.e.dj(x5.a(this.b), x5.a(height));
			}
			HtmlArea result;
			if (this.e != null)
			{
				if (this.e.a() == null)
				{
					result = null;
				}
				else
				{
					result = new HtmlArea(this, x, y, this.b, height);
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060052DE RID: 21214 RVA: 0x0029009C File Offset: 0x0028F09C
		public HtmlArea GetOverflowHtmlArea()
		{
			return this.GetOverflowHtmlArea(base.X, base.Y, this.Height);
		}

		// Token: 0x060052DF RID: 21215 RVA: 0x002900C8 File Offset: 0x0028F0C8
		public float GetRequiredHeight()
		{
			float result = 0f;
			if (this.e == null)
			{
				this.a();
				if (this.e != null)
				{
					result = this.e.b(x5.a(this.b));
					this.e = null;
				}
			}
			else if (!this.e.b())
			{
				lc lc = new lc();
				lc.c(this.e.n().p());
				lc.dc(this.e.db().du());
				lc.a((lk)this.e.c5().du());
				lc.c9(this.e.c8());
				lc.b(this.e.bw());
				lc.a(this.e.c());
				result = lc.b(x5.a(this.b));
			}
			else
			{
				result = x5.b(this.e.ar());
			}
			return result;
		}

		// Token: 0x060052E0 RID: 21216 RVA: 0x002901F4 File Offset: 0x0028F1F4
		internal float a(float A_0, ref bool A_1)
		{
			float result = 0f;
			if (this.e == null)
			{
				this.a();
				if (this.e != null)
				{
					result = this.e.a(x5.a(this.b), x5.a(A_0), ref A_1);
					this.e = null;
				}
			}
			else if (!this.e.b())
			{
				lc lc = new lc();
				lc.c(this.e.n().p());
				result = lc.a(x5.a(this.b), x5.a(A_0), ref A_1);
			}
			else
			{
				result = x5.b(this.e.ar());
			}
			return result;
		}

		// Token: 0x04002C3D RID: 11325
		private new char[] a;

		// Token: 0x04002C3E RID: 11326
		private float b;

		// Token: 0x04002C3F RID: 11327
		private d3 c = null;

		// Token: 0x04002C40 RID: 11328
		private new Uri d;

		// Token: 0x04002C41 RID: 11329
		private lc e = null;

		// Token: 0x04002C42 RID: 11330
		private Hashtable f = null;

		// Token: 0x04002C43 RID: 11331
		private Encoding g = null;

		// Token: 0x04002C44 RID: 11332
		private ij h = null;

		// Token: 0x04002C45 RID: 11333
		private bool i = false;

		// Token: 0x04002C46 RID: 11334
		private gn j = gn.e;
	}
}
