using System;
using System.IO;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000062 RID: 98
	internal class b3 : DocumentWriter
	{
		// Token: 0x060003E1 RID: 993 RVA: 0x000453A4 File Offset: 0x000443A4
		internal b3(Stream A_0, Document A_1) : base(A_1)
		{
			this.f = A_0;
			this.h = A_1.Security;
			this.e = new z0(base.Document.Pages.Count);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00045480 File Offset: 0x00044480
		public override DocumentResourceList get_Resources()
		{
			return this.g;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00045498 File Offset: 0x00044498
		public override void Draw()
		{
			if (this.h != null)
			{
				base.Document.RequireLicense(3);
				this.i = this.h.GetEncrypter(this.o);
			}
			PageList pages = base.Document.Pages;
			this.c = 1 + pages.b();
			for (int i = 0; i < pages.Count; i++)
			{
				if (pages[i].fg() != null)
				{
					base.a(pages[i], this.c + i);
				}
			}
			switch (base.Document.PdfVersion)
			{
			case PdfVersion.v1_3:
				this.f.Write(DocumentWriter.f, 0, DocumentWriter.f.Length);
				break;
			case PdfVersion.v1_4:
				this.f.Write(DocumentWriter.g, 0, DocumentWriter.g.Length);
				break;
			case PdfVersion.v1_5:
				this.f.Write(DocumentWriter.h, 0, DocumentWriter.h.Length);
				break;
			case PdfVersion.v1_6:
				this.f.Write(DocumentWriter.i, 0, DocumentWriter.i.Length);
				break;
			case PdfVersion.v1_7:
				this.f.Write(DocumentWriter.j, 0, DocumentWriter.j.Length);
				break;
			default:
				this.f.Write(DocumentWriter.g, 0, DocumentWriter.g.Length);
				break;
			}
			int num = this.c + base.Document.Pages.Count + 1;
			if (base.Document.Optimization != null && base.Document.Optimization.Images)
			{
				base.Document.RequireLicense(3);
				this.g = new bx(num, base.Document.Pages.Count);
			}
			else
			{
				this.g = new bw(num, base.Document.Pages.Count);
			}
			this.m = 2147483645;
			base.Document.d(this);
			pages.a(this, this.c, num - 2);
			this.m = 2147483645;
			this.d();
			this.m = 2147483646;
			base.g(this.d);
			base.Document.e(this);
			base.a(this.g);
			this.m = 2147483645;
			this.g.a(this);
			this.y.e();
			this.m = 2147483646;
			this.a();
			z4 z = this.e.a(this);
			if (base.ad() != null && base.ad().Length > 0)
			{
				this.e();
			}
			z.a(this.f);
			base.t();
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0004578C File Offset: 0x0004478C
		private new void e()
		{
			for (int i = 0; i < base.ad().Length; i++)
			{
				zz zz = this.e.b(base.ad()[i].b());
				int num = zz.c() + zz.b().ToString().Length + 18;
				base.ad()[i].b(num);
				num += base.ad()[i].g() + 10;
				base.ad()[i].c(num);
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00045830 File Offset: 0x00044830
		private new void d()
		{
			int count = base.Document.Pages.Count;
			this.y = new z7(count);
			bool flag = base.Document.Sections.b() != 0;
			int i = 0;
			int num = 1;
			int num2 = this.c;
			int num3 = int.MinValue;
			int num4 = 1;
			if (base.Document.Pages.Count > 16)
			{
				num4++;
			}
			while (i < base.Document.Pages.Count)
			{
				if (flag && base.e(i))
				{
					num = base.CurrentSection.StartingPageNumber;
				}
				i++;
				base.Document.Pages[i - 1].b(this.d);
				base.Document.Pages[i - 1].a(this, num4, i, num);
				this.y.a(this.l);
				if (i == 1)
				{
					zz zz = this.e.a(num2++);
					zz.c(int.MaxValue);
				}
				else
				{
					this.e.a(num2++).c(num3);
					num3++;
				}
				this.g.a();
				num++;
				if (i % 16 == 0)
				{
					num4++;
				}
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000459C0 File Offset: 0x000449C0
		public override int GetObjectNumber()
		{
			return this.d;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x000459D8 File Offset: 0x000449D8
		public override int GetObjectNumber(int offset)
		{
			return this.d + offset;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x000459F4 File Offset: 0x000449F4
		public override int GetPageObject(int pageNumber)
		{
			if (pageNumber <= base.Document.Pages.Count && pageNumber >= 1)
			{
				return this.c + (pageNumber - 1);
			}
			if (base.Document.Pages.Count > 0)
			{
				throw new GeneratorException("Invalid page number.");
			}
			throw new EmptyDocumentException("Document has no pages.");
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00045A65 File Offset: 0x00044A65
		public override void Write(byte[] data)
		{
			this.a(data.Length);
			Array.Copy(data, 0, this.s, this.u, data.Length);
			this.u += data.Length;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00045A99 File Offset: 0x00044A99
		public override void Write(byte[] data, int length)
		{
			this.a(length);
			Array.Copy(data, 0, this.s, this.u, length);
			this.u += length;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00045AC7 File Offset: 0x00044AC7
		public override void Write(byte[] data, int start, int length)
		{
			this.a(length);
			Array.Copy(data, start, this.s, this.u, length);
			this.u += length;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00045AF8 File Offset: 0x00044AF8
		public override void WriteArrayClose()
		{
			this.a(1);
			this.s[this.u++] = 93;
			this.j = false;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00045B30 File Offset: 0x00044B30
		public override void WriteArrayOpen()
		{
			this.a(1);
			this.s[this.u++] = 91;
			this.j = false;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00045B68 File Offset: 0x00044B68
		public override int WriteBeginObject()
		{
			this.k = this.e.b(this.d);
			this.k.c(this.m);
			this.k.a(this.n);
			this.j = false;
			return this.d;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00045BC4 File Offset: 0x00044BC4
		internal new void f()
		{
			if (this.v != this.u)
			{
				this.k.l().a(new z8(this.s, this.v, this.u - this.v));
				this.v = this.u;
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00045C24 File Offset: 0x00044C24
		public override void WriteBoolean(bool value)
		{
			this.b();
			if (value)
			{
				this.a(4);
				DocumentWriter.k.CopyTo(this.s, this.u);
				this.u += 4;
			}
			else
			{
				this.a(5);
				DocumentWriter.l.CopyTo(this.s, this.u);
				this.u += 5;
			}
			this.j = true;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00045CA8 File Offset: 0x00044CA8
		public override void WriteDictionaryClose()
		{
			this.a(2);
			this.s[this.u++] = 62;
			this.s[this.u++] = 62;
			this.j = false;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00045CFC File Offset: 0x00044CFC
		public override void WriteDictionaryOpen()
		{
			this.a(2);
			this.s[this.u++] = 60;
			this.s[this.u++] = 60;
			this.j = false;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00045D4D File Offset: 0x00044D4D
		public override void WriteEndObject()
		{
			this.f();
			this.l = this.k;
			this.k = null;
			this.d++;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00045D78 File Offset: 0x00044D78
		public override void WriteName(string name)
		{
			this.a(1);
			this.s[this.u++] = 47;
			this.b(name);
			this.j = true;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00045DB8 File Offset: 0x00044DB8
		public override void WriteName(byte[] name)
		{
			this.a(1);
			this.s[this.u++] = 47;
			this.Write(name);
			this.j = true;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00045DF8 File Offset: 0x00044DF8
		public override void WriteName(byte[] name, string nameSufix)
		{
			this.a(1);
			this.s[this.u++] = 47;
			this.Write(name);
			this.b(nameSufix);
			this.j = true;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00045E40 File Offset: 0x00044E40
		public override void WriteName(byte nameByte)
		{
			this.a(2);
			this.s[this.u++] = 47;
			this.s[this.u++] = nameByte;
			this.j = true;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00045E90 File Offset: 0x00044E90
		public override void WriteName(byte nameCharacter, int nameNumber)
		{
			this.a(12);
			this.s[this.u++] = 47;
			this.s[this.u++] = nameCharacter;
			int i = 100000000;
			bool flag = false;
			if (nameNumber >= i)
			{
				throw new Exception("Maximum Integer Value Exceeded.");
			}
			for (i /= 10; i >= 1; i /= 10)
			{
				int num = (int)((byte)(nameNumber / i));
				if (flag || num > 0)
				{
					this.s[this.u++] = (byte)(num + 48);
					flag = true;
				}
				nameNumber -= num * i;
			}
			if (!flag)
			{
				this.s[this.u++] = 48;
			}
			this.j = true;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00045F7C File Offset: 0x00044F7C
		public override void WriteName(byte[] name, int start, int length)
		{
			this.Write(name, start, length);
			this.j = true;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00045F90 File Offset: 0x00044F90
		public override void WriteNull()
		{
			this.b();
			this.a(4);
			DocumentWriter.m.CopyTo(this.s, this.u);
			this.u += 4;
			this.j = true;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00045FD0 File Offset: 0x00044FD0
		public override void WriteNumber(int value)
		{
			this.b();
			this.a(11);
			if (value < 0)
			{
				value = -value;
				this.s[this.u++] = 45;
			}
			int i;
			if (value < 10)
			{
				i = 1;
			}
			else if (value < 100)
			{
				i = 10;
			}
			else if (value < 1000)
			{
				i = 100;
			}
			else if (value < 10000)
			{
				i = 1000;
			}
			else if (value < 1000000)
			{
				i = 100000;
			}
			else
			{
				i = 1000000000;
			}
			bool flag = false;
			while (i >= 1)
			{
				int num = (int)((byte)(value / i));
				if (flag || num > 0)
				{
					this.s[this.u++] = (byte)(num + 48);
					flag = true;
				}
				value -= num * i;
				i /= 10;
			}
			if (!flag)
			{
				this.s[this.u++] = 48;
			}
			this.j = true;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00046104 File Offset: 0x00045104
		public override void WriteNumber(short value)
		{
			this.b();
			this.a(11);
			int num = (int)value;
			if (value < 0)
			{
				num = -num;
				this.s[this.u++] = 45;
			}
			int i;
			if (num < 10)
			{
				i = 1;
			}
			else if (num < 100)
			{
				i = 10;
			}
			else if (num < 1000)
			{
				i = 100;
			}
			else if (num < 10000)
			{
				i = 1000;
			}
			else
			{
				i = 10000;
			}
			bool flag = false;
			while (i >= 1)
			{
				int num2 = (int)((byte)(num / i));
				if (flag || num2 > 0)
				{
					this.s[this.u++] = (byte)(num2 + 48);
					flag = true;
				}
				num -= num2 * i;
				i /= 10;
			}
			if (!flag)
			{
				this.s[this.u++] = 48;
			}
			this.j = true;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00046230 File Offset: 0x00045230
		public override void WriteNumber(byte[] data, int start, int length)
		{
			this.b();
			this.Write(data, start, length);
			this.j = true;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0004624C File Offset: 0x0004524C
		internal override void y(byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			int num = A_0.Length - A_1;
			this.Write(A_0, A_1, num);
			this.Write(A_3, A_2 - num);
			this.j = true;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00046280 File Offset: 0x00045280
		internal override void z(byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			this.b();
			int num = A_0.Length - A_1;
			this.Write(A_0, A_1, num);
			this.Write(A_3, A_2 - num);
			this.j = true;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000462B8 File Offset: 0x000452B8
		public override void WriteNumber(float value)
		{
			this.b();
			this.a(10);
			int i = (int)(value * 100f);
			bool flag = false;
			if (i < 0)
			{
				i = -i;
				this.s[this.u++] = 45;
			}
			int j;
			if (i < 10)
			{
				j = 1;
			}
			else if (i < 100)
			{
				j = 10;
			}
			else if (i < 1000)
			{
				j = 100;
			}
			else if (i < 10000)
			{
				j = 1000;
			}
			else if (i < 100000)
			{
				j = 10000;
			}
			else if (i < 1000000)
			{
				j = 100000;
			}
			else if (i < 10000000)
			{
				j = 1000000;
			}
			else if (i < 100000000)
			{
				j = 10000000;
			}
			else
			{
				if (i >= 1000000000)
				{
					throw new Exception("Maximum Float Value Exceeded.");
				}
				j = 100000000;
			}
			while (j >= 100)
			{
				int num = i / j;
				if (flag || num > 0)
				{
					this.s[this.u++] = (byte)(num + 48);
					flag = true;
				}
				i -= num * j;
				j /= 10;
			}
			if (i > 0)
			{
				this.s[this.u++] = 46;
			}
			while (i > 0)
			{
				int num = i / j;
				this.s[this.u++] = (byte)(num + 48);
				flag = true;
				i -= num * j;
				j /= 10;
			}
			if (!flag)
			{
				this.s[this.u++] = 48;
			}
			this.j = true;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000464E0 File Offset: 0x000454E0
		public override void WriteNumber0()
		{
			this.b();
			this.a(1);
			this.s[this.u++] = 48;
			this.j = true;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00046520 File Offset: 0x00045520
		public override void WriteNumber1()
		{
			this.b();
			this.a(1);
			this.s[this.u++] = 49;
			this.j = true;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00046560 File Offset: 0x00045560
		public override void WriteNumberColor(float value)
		{
			this.b();
			int i = (int)(value * 10000f);
			this.a(5);
			if (i <= 0)
			{
				this.s[this.u++] = 48;
			}
			else if (i >= 10000)
			{
				this.s[this.u++] = 49;
			}
			else
			{
				bool flag = false;
				int num = 1000;
				this.s[this.u++] = 46;
				while (i > 0)
				{
					int num2 = (int)((byte)(i / num));
					this.s[this.u++] = (byte)(num2 + 48);
					flag = true;
					i -= num2 * num;
					num /= 10;
				}
				if (!flag)
				{
					this.u--;
					this.s[this.u++] = 48;
				}
			}
			this.j = true;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00046684 File Offset: 0x00045684
		public override void WriteNumberNeg1()
		{
			this.b();
			this.a(2);
			this.s[this.u++] = 45;
			this.s[this.u++] = 49;
			this.j = true;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000466DC File Offset: 0x000456DC
		public override void WriteReference(int objectNumber)
		{
			this.b();
			this.f();
			this.k.l().a(new z9(this.e.b(objectNumber)));
			this.j = true;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00046716 File Offset: 0x00045716
		public override void WriteReferenceShallow(int objectNumber)
		{
			this.b();
			this.f();
			this.k.l().b(new z9(this.e.b(objectNumber)));
			this.j = true;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00046750 File Offset: 0x00045750
		public override void WriteStream(byte[] data, int length)
		{
			this.WriteStream(data, 0, length);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0004675D File Offset: 0x0004575D
		internal override void af(byte[] A_0, int A_1)
		{
			this.ag(A_0, 0, A_1);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0004676C File Offset: 0x0004576C
		public override void WriteStream(byte[] data, int start, int length)
		{
			zz zz = this.k;
			zz.a(zz.k() | 128);
			this.w += length;
			this.f();
			this.k.l().a(new aac(data, start, length));
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000467C4 File Offset: 0x000457C4
		internal override void ag(byte[] A_0, int A_1, int A_2)
		{
			zz zz = this.k;
			zz.a(zz.k() | 128);
			this.w += A_2;
			this.f();
			this.k.l().a(new aac(A_0, A_1, A_2));
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00046819 File Offset: 0x00045819
		internal override void ad(byte[] A_0, int A_1)
		{
			this.ae(A_0, 0, A_1);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00046828 File Offset: 0x00045828
		internal override void ae(byte[] A_0, int A_1, int A_2)
		{
			zz zz = this.k;
			zz.a(zz.k() | 128);
			this.w += A_2 + 16 + (16 - A_2 % 16);
			this.f();
			this.k.l().a(new zt(A_0, A_1, A_2));
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00046888 File Offset: 0x00045888
		internal override void ac(bp A_0)
		{
			zz zz = this.k;
			zz.a(zz.k() | 128);
			this.w += A_0.s();
			this.f();
			this.k.l().a(new aab(A_0));
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x000468E0 File Offset: 0x000458E0
		internal override void ab(agx A_0, int A_1)
		{
			zz zz = this.k;
			zz.a(zz.k() | 128);
			this.w += A_1;
			this.f();
			this.k.l().a(new afd(A_0, A_1));
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00046934 File Offset: 0x00045934
		internal override void aa(agx A_0, int A_1)
		{
			throw new NotImplementedException("Linearized WriteSegmentedStreamWithoutEncryption is not implemented.");
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00046944 File Offset: 0x00045944
		public override int WriteStreamWithCompression(byte[] data, int length)
		{
			zz zz = this.k;
			zz.a(zz.k() | 128);
			this.f();
			int num = (int)((float)length * 1.002f + 12f);
			this.a(num);
			y0 y = new y0();
			y.b(data, 0, length);
			y.b();
			num = y.c(this.s, this.u, num);
			this.k.l().a(new aac(this.s, this.u, num));
			this.u += num;
			this.v = this.u;
			this.w += num;
			return num;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00046A08 File Offset: 0x00045A08
		public override void WriteText(string text)
		{
			this.a(text.Length * 4 + 4);
			this.s[this.u++] = 40;
			int num = this.u;
			bool flag = false;
			for (int i = 0; i < text.Length; i++)
			{
				byte b = base.b(text[i]);
				if (b == 0)
				{
					flag = true;
					break;
				}
				this.a(b);
			}
			if (flag)
			{
				this.u = num;
				this.s[this.u++] = 254;
				this.s[this.u++] = byte.MaxValue;
				for (int i = 0; i < text.Length; i++)
				{
					this.a((byte)(text[i] >> 8));
					this.a((byte)text[i]);
				}
			}
			this.s[this.u++] = 41;
			this.j = false;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00046B40 File Offset: 0x00045B40
		internal override void ah(byte[] A_0, bool A_1)
		{
			this.a(A_0.Length * 4 + 4);
			this.s[this.u++] = 40;
			this.s[this.u++] = 254;
			this.s[this.u++] = byte.MaxValue;
			for (int i = 0; i < A_0.Length; i++)
			{
				this.a((byte)(A_0[i] >> 8));
				this.a(A_0[i]);
			}
			this.s[this.u++] = 41;
			this.j = false;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00046BFC File Offset: 0x00045BFC
		public override void WriteText(byte[] text)
		{
			this.a(1);
			this.s[this.u++] = 40;
			this.a(text.Length * 2 + 2);
			for (int i = 0; i < text.Length; i++)
			{
				this.a(text[i]);
			}
			this.s[this.u++] = 41;
			this.j = false;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00046C79 File Offset: 0x00045C79
		public override void WriteTextRawWithoutEncryption(byte[] text, int startIndex, int count)
		{
			this.Write(text, startIndex, count);
			this.j = false;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00046C90 File Offset: 0x00045C90
		public override void WriteTextWithoutEncryption(byte[] text)
		{
			this.a(text.Length * 2 + 2);
			this.s[this.u++] = 40;
			for (int i = 0; i < text.Length; i++)
			{
				this.a(text[i]);
			}
			this.s[this.u++] = 41;
			this.j = false;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00046D08 File Offset: 0x00045D08
		private new void c()
		{
			this.a(1);
			this.s[this.u++] = 32;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00046D38 File Offset: 0x00045D38
		private new void b(string A_0)
		{
			this.a(A_0.Length);
			for (int i = 0; i < A_0.Length; i++)
			{
				this.s[this.u++] = (byte)A_0[i];
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00046D88 File Offset: 0x00045D88
		private new void a(string A_0)
		{
			this.a(A_0.Length * 2);
			foreach (byte b in A_0)
			{
				byte b2 = b;
				if (b2 != 13)
				{
					switch (b2)
					{
					case 40:
						this.s[this.u++] = 92;
						break;
					case 41:
						this.s[this.u++] = 92;
						break;
					default:
						if (b2 == 92)
						{
							this.s[this.u++] = 92;
						}
						break;
					}
					this.s[this.u++] = b;
				}
				else
				{
					this.s[this.u++] = 92;
					this.s[this.u++] = 114;
				}
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00046E94 File Offset: 0x00045E94
		private new void b()
		{
			if (this.j)
			{
				this.c();
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00046EB8 File Offset: 0x00045EB8
		internal new void a(int A_0)
		{
			if (A_0 + this.u > this.s.Length)
			{
				if (this.k != null)
				{
					this.f();
				}
				if (this.r == this.p.Length)
				{
					byte[][] array = new byte[this.p.Length * 3][];
					int[] array2 = new int[this.p.Length * 3];
					this.p.CopyTo(array, 0);
					this.q.CopyTo(array2, 0);
					this.p = array;
					this.q = array2;
				}
				this.p[this.r] = this.s;
				this.q[this.r++] = this.u;
				if (this.t < A_0)
				{
					this.s = new byte[A_0];
				}
				else
				{
					this.s = new byte[this.t];
				}
				this.u = (this.v = 0);
				this.x += this.s.Length;
				this.t += 4096;
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00046FF4 File Offset: 0x00045FF4
		internal new void b(int A_0)
		{
			this.a(10);
			int i;
			if (A_0 < 10)
			{
				i = 1;
			}
			else if (A_0 < 100)
			{
				i = 10;
			}
			else if (A_0 < 1000)
			{
				i = 100;
			}
			else if (A_0 < 10000)
			{
				i = 1000;
			}
			else if (A_0 < 1000000)
			{
				i = 100000;
			}
			else
			{
				i = 1000000000;
			}
			bool flag = false;
			while (i >= 1)
			{
				int num = (int)((byte)(A_0 / i));
				if (flag || num > 0)
				{
					this.s[this.u++] = (byte)(num + 48);
					flag = true;
				}
				A_0 -= num * i;
				i /= 10;
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x000470CC File Offset: 0x000460CC
		internal new int g()
		{
			return this.u;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000470E4 File Offset: 0x000460E4
		internal new byte[] h()
		{
			return this.s;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000470FC File Offset: 0x000460FC
		private new void a()
		{
			if (this.h != null)
			{
				base.h(this.d);
				this.WriteBeginObject();
				this.h.Draw(this, this.i);
				this.WriteEndObject();
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00047148 File Offset: 0x00046148
		internal new void a(byte A_0)
		{
			switch (A_0)
			{
			case 8:
				this.s[this.u++] = 92;
				this.s[this.u++] = 98;
				return;
			case 9:
				this.s[this.u++] = 92;
				this.s[this.u++] = 116;
				return;
			case 10:
				this.s[this.u++] = 92;
				this.s[this.u++] = 110;
				return;
			case 11:
				break;
			case 12:
				this.s[this.u++] = 92;
				this.s[this.u++] = 102;
				return;
			case 13:
				this.s[this.u++] = 92;
				this.s[this.u++] = 114;
				return;
			default:
				switch (A_0)
				{
				case 40:
					break;
				case 41:
					break;
				default:
					if (A_0 != 92)
					{
						goto IL_1B2;
					}
					this.s[this.u++] = 92;
					this.s[this.u++] = 92;
					return;
				}
				this.s[this.u++] = 92;
				break;
			}
			IL_1B2:
			this.s[this.u++] = A_0;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00047324 File Offset: 0x00046324
		internal new int i()
		{
			return this.x + this.w;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00047344 File Offset: 0x00046344
		internal override void ak(byte A_0)
		{
			this.a(1);
			this.s[this.u++] = A_0;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00047374 File Offset: 0x00046374
		internal new Encrypter j()
		{
			return this.i;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0004738C File Offset: 0x0004638C
		internal new void c(int A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00047396 File Offset: 0x00046396
		internal new void b(byte A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x000473A0 File Offset: 0x000463A0
		internal new zz k()
		{
			return this.e.a(base.ab());
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x000473C4 File Offset: 0x000463C4
		internal new zz l()
		{
			return this.e.a(0);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000473E4 File Offset: 0x000463E4
		internal new zz m()
		{
			zz result;
			if (base.ac() < 0)
			{
				result = null;
			}
			else
			{
				result = this.e.a(base.ac());
			}
			return result;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0004741C File Offset: 0x0004641C
		internal new byte[] n()
		{
			return this.o;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00047434 File Offset: 0x00046434
		internal new z7 o()
		{
			return this.y;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0004744C File Offset: 0x0004644C
		internal new z0 p()
		{
			return this.e;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00047464 File Offset: 0x00046464
		internal override int al()
		{
			return 1;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00047478 File Offset: 0x00046478
		internal override int am()
		{
			return this.u + ((this.f != null) ? ((int)this.f.Position) : 0);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000474AC File Offset: 0x000464AC
		internal override void ap()
		{
			this.a(4);
			this.s[this.u++] = 116;
			this.s[this.u++] = 114;
			this.s[this.u++] = 117;
			this.s[this.u++] = 101;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0004752C File Offset: 0x0004652C
		internal override void an(string A_0)
		{
			this.a(1);
			this.s[this.u++] = 40;
			this.a(A_0);
			this.a(1);
			this.s[this.u++] = 41;
			this.j = true;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00047590 File Offset: 0x00046590
		internal override void ao(byte[] A_0)
		{
			this.a(A_0.Length + 2);
			this.s[this.u++] = 40;
			A_0.CopyTo(this.s, this.u);
			this.u += A_0.Length;
			this.s[this.u++] = 41;
			this.j = true;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00047608 File Offset: 0x00046608
		internal override void ai(int A_0)
		{
			if (this.h != null && this.h.a() == b5.b)
			{
				if (this.h.d())
				{
					this.WriteNumber(A_0);
				}
				else
				{
					this.WriteNumber(A_0 + 16 + 16 - A_0 % 16);
				}
			}
			else
			{
				this.WriteNumber(A_0);
			}
		}

		// Token: 0x04000262 RID: 610
		private new const int a = 4096;

		// Token: 0x04000263 RID: 611
		private new const int b = 4096;

		// Token: 0x04000264 RID: 612
		private new int c;

		// Token: 0x04000265 RID: 613
		private new int d = 0;

		// Token: 0x04000266 RID: 614
		private new z0 e;

		// Token: 0x04000267 RID: 615
		private new Stream f;

		// Token: 0x04000268 RID: 616
		private new bw g;

		// Token: 0x04000269 RID: 617
		internal new Security h;

		// Token: 0x0400026A RID: 618
		private new Encrypter i;

		// Token: 0x0400026B RID: 619
		internal new bool j = false;

		// Token: 0x0400026C RID: 620
		internal new zz k = null;

		// Token: 0x0400026D RID: 621
		private new zz l = null;

		// Token: 0x0400026E RID: 622
		private new int m = int.MinValue;

		// Token: 0x0400026F RID: 623
		private new byte n = 0;

		// Token: 0x04000270 RID: 624
		private new byte[] o = Guid.NewGuid().ToByteArray();

		// Token: 0x04000271 RID: 625
		private new byte[][] p = new byte[3][];

		// Token: 0x04000272 RID: 626
		private new int[] q = new int[3];

		// Token: 0x04000273 RID: 627
		private new int r = 0;

		// Token: 0x04000274 RID: 628
		internal new byte[] s = new byte[4096];

		// Token: 0x04000275 RID: 629
		private new int t = 8192;

		// Token: 0x04000276 RID: 630
		internal new int u;

		// Token: 0x04000277 RID: 631
		internal new int v;

		// Token: 0x04000278 RID: 632
		internal new int w = 0;

		// Token: 0x04000279 RID: 633
		private new int x = 4096;

		// Token: 0x0400027A RID: 634
		private new z7 y = null;
	}
}
