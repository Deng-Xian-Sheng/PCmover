using System;
using System.Collections;
using System.IO;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200005F RID: 95
	internal class b1 : DocumentWriter
	{
		// Token: 0x06000322 RID: 802 RVA: 0x0004169C File Offset: 0x0004069C
		internal b1(Stream A_0, Document A_1) : base(A_1)
		{
			this.f = A_0;
			this.h = A_1.Security;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00041710 File Offset: 0x00040710
		public override DocumentResourceList get_Resources()
		{
			return this.g;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00041728 File Offset: 0x00040728
		public override void Draw()
		{
			if (this.h != null)
			{
				base.Document.RequireLicense(3);
				this.i = this.h.GetEncrypter(this.k);
			}
			PageList pages = base.Document.Pages;
			this.b = 2 + pages.b();
			for (int i = 0; i < pages.Count; i++)
			{
				if (pages[i].fg() != null)
				{
					base.a(pages[i], this.b + i);
				}
			}
			switch (base.Document.PdfVersion)
			{
			case PdfVersion.v1_3:
				this.Write(DocumentWriter.f);
				break;
			case PdfVersion.v1_4:
				this.Write(DocumentWriter.g);
				break;
			case PdfVersion.v1_5:
				this.Write(DocumentWriter.h);
				break;
			case PdfVersion.v1_6:
				this.Write(DocumentWriter.i);
				break;
			case PdfVersion.v1_7:
				this.Write(DocumentWriter.j);
				break;
			default:
				this.Write(DocumentWriter.g);
				break;
			}
			base.Document.d(this);
			int num = this.b + base.Document.Pages.Count + 1;
			if (base.Document.Optimization != null && base.Document.Optimization.Images)
			{
				base.Document.RequireLicense(3);
				this.g = new bx(num);
			}
			else
			{
				this.g = new DocumentResourceList(num);
			}
			pages.a(this, this.b, num - 2);
			this.f();
			this.g.t();
			base.g(this.c);
			base.Document.e(this);
			base.a(this.g);
			this.g.a(this);
			this.b();
			this.c();
			this.a();
			base.t();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00041934 File Offset: 0x00040934
		private new void f()
		{
			bool flag = base.Document.Sections.b() != 0;
			int i = 0;
			int num = 1;
			int num2 = 2;
			if (base.Document.Pages.Count > 16)
			{
				num2++;
			}
			while (i < base.Document.Pages.Count)
			{
				if (flag && base.e(i))
				{
					num = base.CurrentSection.StartingPageNumber;
				}
				i++;
				base.Document.Pages[i - 1].b(this.c);
				base.Document.Pages[i - 1].a(this, num2, i, num);
				num++;
				if (i % 16 == 0)
				{
					num2++;
				}
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00041A1C File Offset: 0x00040A1C
		public override int GetObjectNumber()
		{
			return this.c;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00041A34 File Offset: 0x00040A34
		public override int GetObjectNumber(int offset)
		{
			return this.c + offset;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00041A50 File Offset: 0x00040A50
		public override int GetPageObject(int pageNumber)
		{
			if (pageNumber <= base.Document.Pages.Count && pageNumber >= 1)
			{
				return this.b + (pageNumber - 1);
			}
			if (base.Document.Pages.Count > 0)
			{
				throw new GeneratorException("Invalid page number.");
			}
			throw new EmptyDocumentException("Document has no pages.");
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00041AC4 File Offset: 0x00040AC4
		public override void Write(byte[] data)
		{
			if (data.Length > 256)
			{
				this.g();
				this.a += data.Length;
				this.f.Write(data, 0, data.Length);
			}
			else
			{
				this.c(data.Length);
				data.CopyTo(this.l, this.m);
				this.m += data.Length;
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00041B40 File Offset: 0x00040B40
		public override void Write(byte[] data, int length)
		{
			if (length > 256)
			{
				this.g();
				this.a += length;
				this.f.Write(data, 0, length);
			}
			else
			{
				this.c(length);
				Array.Copy(data, 0, this.l, this.m, length);
				this.m += length;
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00041BB4 File Offset: 0x00040BB4
		public override void Write(byte[] data, int start, int length)
		{
			if (length > 256)
			{
				this.g();
				this.a += length;
				this.f.Write(data, start, length);
			}
			else
			{
				this.c(length);
				Array.Copy(data, start, this.l, this.m, length);
				this.m += length;
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00041C28 File Offset: 0x00040C28
		public override void WriteArrayClose()
		{
			this.c(1);
			this.l[this.m++] = 93;
			this.j = false;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00041C60 File Offset: 0x00040C60
		public override void WriteArrayOpen()
		{
			this.c(1);
			this.l[this.m++] = 91;
			this.j = false;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00041C98 File Offset: 0x00040C98
		public override int WriteBeginObject()
		{
			this.e.Add(this.a + this.m);
			this.c(17);
			this.a(this.c);
			DocumentWriter.a.CopyTo(this.l, this.m);
			this.m += 7;
			this.j = true;
			return this.c;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00041D10 File Offset: 0x00040D10
		public override void WriteBoolean(bool value)
		{
			this.d();
			if (value)
			{
				this.c(4);
				DocumentWriter.k.CopyTo(this.l, this.m);
				this.m += 4;
			}
			else
			{
				this.c(5);
				DocumentWriter.l.CopyTo(this.l, this.m);
				this.m += 5;
			}
			this.j = true;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00041D94 File Offset: 0x00040D94
		public override void WriteDictionaryClose()
		{
			this.c(2);
			this.l[this.m++] = 62;
			this.l[this.m++] = 62;
			this.j = false;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00041DE8 File Offset: 0x00040DE8
		public override void WriteDictionaryOpen()
		{
			this.c(2);
			this.l[this.m++] = 60;
			this.l[this.m++] = 60;
			this.j = false;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00041E3C File Offset: 0x00040E3C
		public override void WriteEndObject()
		{
			this.c(8);
			DocumentWriter.c.CopyTo(this.l, this.m);
			this.m += 8;
			this.j = false;
			this.c++;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00041E8C File Offset: 0x00040E8C
		public override void WriteName(string name)
		{
			this.c(1);
			this.l[this.m++] = 47;
			this.b(name);
			this.j = true;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00041ECC File Offset: 0x00040ECC
		public override void WriteName(byte[] name)
		{
			this.c(name.Length + 1);
			this.l[this.m++] = 47;
			name.CopyTo(this.l, this.m);
			this.m += name.Length;
			this.j = true;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00041F2C File Offset: 0x00040F2C
		public override void WriteName(byte[] name, string nameSufix)
		{
			this.c(name.Length + 1);
			this.l[this.m++] = 47;
			name.CopyTo(this.l, this.m);
			this.m += name.Length;
			this.b(nameSufix);
			this.j = true;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00041F94 File Offset: 0x00040F94
		public override void WriteName(byte nameByte)
		{
			this.c(2);
			this.l[this.m++] = 47;
			this.l[this.m++] = nameByte;
			this.j = true;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00041FE4 File Offset: 0x00040FE4
		public override void WriteName(byte nameCharacter, int nameNumber)
		{
			this.c(12);
			this.l[this.m++] = 47;
			this.l[this.m++] = nameCharacter;
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
					this.l[this.m++] = (byte)(num + 48);
					flag = true;
				}
				nameNumber -= num * i;
			}
			if (!flag)
			{
				this.l[this.m++] = 48;
			}
			this.j = true;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x000420D0 File Offset: 0x000410D0
		public override void WriteName(byte[] name, int start, int length)
		{
			this.Write(name, start, length);
			this.j = true;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000420E4 File Offset: 0x000410E4
		public override void WriteNull()
		{
			this.d();
			this.c(4);
			DocumentWriter.m.CopyTo(this.l, this.m);
			this.m += 4;
			this.j = true;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00042124 File Offset: 0x00041124
		public override void WriteNumber(int value)
		{
			this.d();
			this.c(11);
			if (value < 0)
			{
				value = -value;
				this.l[this.m++] = 45;
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
					this.l[this.m++] = (byte)(num + 48);
					flag = true;
				}
				value -= num * i;
				i /= 10;
			}
			if (!flag)
			{
				this.l[this.m++] = 48;
			}
			this.j = true;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00042258 File Offset: 0x00041258
		public override void WriteNumber(short value)
		{
			this.d();
			this.c(11);
			int num = (int)value;
			if (value < 0)
			{
				num = -num;
				this.l[this.m++] = 45;
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
					this.l[this.m++] = (byte)(num2 + 48);
					flag = true;
				}
				num -= num2 * i;
				i /= 10;
			}
			if (!flag)
			{
				this.l[this.m++] = 48;
			}
			this.j = true;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00042384 File Offset: 0x00041384
		public override void WriteNumber(byte[] data, int start, int length)
		{
			this.d();
			this.Write(data, start, length);
			this.j = true;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000423A0 File Offset: 0x000413A0
		internal override void y(byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			int num = A_0.Length - A_1;
			this.Write(A_0, A_1, num);
			this.Write(A_3, A_2 - num);
			this.j = true;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000423D4 File Offset: 0x000413D4
		internal override void z(byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			this.d();
			int num = A_0.Length - A_1;
			this.Write(A_0, A_1, num);
			this.Write(A_3, A_2 - num);
			this.j = true;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0004240C File Offset: 0x0004140C
		public override void WriteNumber(float value)
		{
			this.d();
			this.c(10);
			int i = (int)(value * 100f);
			bool flag = false;
			if (i < 0)
			{
				i = -i;
				this.l[this.m++] = 45;
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
					this.l[this.m++] = (byte)(num + 48);
					flag = true;
				}
				i -= num * j;
				j /= 10;
			}
			if (i > 0)
			{
				this.l[this.m++] = 46;
			}
			while (i > 0)
			{
				int num = i / j;
				this.l[this.m++] = (byte)(num + 48);
				flag = true;
				i -= num * j;
				j /= 10;
			}
			if (!flag)
			{
				this.l[this.m++] = 48;
			}
			this.j = true;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00042634 File Offset: 0x00041634
		public override void WriteNumber0()
		{
			this.d();
			this.c(1);
			this.l[this.m++] = 48;
			this.j = true;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00042674 File Offset: 0x00041674
		public override void WriteNumber1()
		{
			this.d();
			this.c(1);
			this.l[this.m++] = 49;
			this.j = true;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000426B4 File Offset: 0x000416B4
		public override void WriteNumberColor(float value)
		{
			this.d();
			int i = (int)(value * 10000f);
			this.c(5);
			if (i <= 0)
			{
				this.l[this.m++] = 48;
			}
			else if (i >= 10000)
			{
				this.l[this.m++] = 49;
			}
			else
			{
				bool flag = false;
				int num = 1000;
				this.l[this.m++] = 46;
				while (i > 0)
				{
					int num2 = (int)((byte)(i / num));
					this.l[this.m++] = (byte)(num2 + 48);
					flag = true;
					i -= num2 * num;
					num /= 10;
				}
				if (!flag)
				{
					this.m--;
					this.l[this.m++] = 48;
				}
			}
			this.j = true;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000427D8 File Offset: 0x000417D8
		public override void WriteNumberNeg1()
		{
			this.d();
			this.c(2);
			this.l[this.m++] = 45;
			this.l[this.m++] = 49;
			this.j = true;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00042830 File Offset: 0x00041830
		public override void WriteReferenceShallow(int objectNumber)
		{
			this.WriteReference(objectNumber);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0004283C File Offset: 0x0004183C
		public override void WriteReference(int objectNumber)
		{
			this.d();
			this.c(18);
			int i;
			if (objectNumber < 10)
			{
				i = 1;
			}
			else if (objectNumber < 100)
			{
				i = 10;
			}
			else if (objectNumber < 1000)
			{
				i = 100;
			}
			else if (objectNumber < 10000)
			{
				i = 1000;
			}
			else if (objectNumber < 100000)
			{
				i = 10000;
			}
			else if (objectNumber < 1000000)
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
				int num = (int)((byte)(objectNumber / i));
				if (flag || num > 0)
				{
					this.l[this.m++] = (byte)(num + 48);
					flag = true;
				}
				objectNumber -= num * i;
				i /= 10;
			}
			if (!flag)
			{
				this.l[this.m++] = 48;
			}
			DocumentWriter.b.CopyTo(this.l, this.m);
			this.m += 4;
			this.j = true;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0004297E File Offset: 0x0004197E
		public override void WriteStream(byte[] data, int length)
		{
			this.WriteStream(data, 0, length);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0004298B File Offset: 0x0004198B
		public override void WriteStream(byte[] data, int start, int length)
		{
			this.ag(data, start, length);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00042998 File Offset: 0x00041998
		internal override void aa(agx A_0, int A_1)
		{
			this.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			this.g();
			A_0.f(this, A_1);
			this.c(10);
			DocumentWriter.e.CopyTo(this.l, this.m);
			this.m += 10;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00042A12 File Offset: 0x00041A12
		internal override void ab(agx A_0, int A_1)
		{
			this.aa(A_0, A_1);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00042A20 File Offset: 0x00041A20
		internal override void ac(bp A_0)
		{
			this.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			this.g();
			A_0.p(this.f);
			this.a += A_0.s();
			DocumentWriter.e.CopyTo(this.l, 0);
			this.m = 10;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00042A9C File Offset: 0x00041A9C
		internal override void ad(byte[] A_0, int A_1)
		{
			this.ae(A_0, 0, A_1);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00042AAC File Offset: 0x00041AAC
		internal override void ae(byte[] A_0, int A_1, int A_2)
		{
			this.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			this.g();
			this.i.Reset(this.c);
			this.i.Encrypt(this.f, A_0, A_1, A_2);
			this.a += A_2 + 16 + (16 - A_2 % 16);
			this.c(10);
			DocumentWriter.e.CopyTo(this.l, this.m);
			this.m += 10;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00042B5D File Offset: 0x00041B5D
		internal override void af(byte[] A_0, int A_1)
		{
			this.ag(A_0, 0, A_1);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00042B6C File Offset: 0x00041B6C
		internal override void ag(byte[] A_0, int A_1, int A_2)
		{
			this.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			this.g();
			this.Write(A_0, A_1, A_2);
			this.c(10);
			DocumentWriter.e.CopyTo(this.l, this.m);
			this.m += 10;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00042BE8 File Offset: 0x00041BE8
		public override int WriteStreamWithCompression(byte[] data, int length)
		{
			this.c(7);
			DocumentWriter.d.CopyTo(this.l, this.m);
			this.m += 7;
			this.g();
			y0 y = new y0();
			y.b(data, 0, length);
			y.b();
			int num = y.a(this.f);
			this.a += num;
			DocumentWriter.e.CopyTo(this.l, 0);
			this.m = 10;
			return num;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00042C80 File Offset: 0x00041C80
		public override void WriteText(string text)
		{
			this.c(text.Length * 4 + 4);
			this.l[this.m++] = 40;
			int num = this.m;
			bool flag = false;
			for (int i = 0; i < text.Length; i++)
			{
				byte b = base.b(text[i]);
				if (b == 0)
				{
					flag = true;
					break;
				}
				this.c(b);
			}
			if (flag)
			{
				this.m = num;
				this.l[this.m++] = 254;
				this.l[this.m++] = byte.MaxValue;
				for (int i = 0; i < text.Length; i++)
				{
					this.c((byte)(text[i] >> 8));
					this.c((byte)text[i]);
				}
			}
			this.l[this.m++] = 41;
			this.j = false;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00042DB8 File Offset: 0x00041DB8
		internal override void ah(byte[] A_0, bool A_1)
		{
			this.c(A_0.Length * 4 + 4);
			this.l[this.m++] = 40;
			this.l[this.m++] = 254;
			this.l[this.m++] = byte.MaxValue;
			for (int i = 0; i < A_0.Length; i++)
			{
				this.c((byte)(A_0[i] >> 8));
				this.c(A_0[i]);
			}
			this.l[this.m++] = 41;
			this.j = false;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00042E74 File Offset: 0x00041E74
		internal override void ai(int A_0)
		{
			this.WriteNumber(A_0);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00042E80 File Offset: 0x00041E80
		public override void WriteText(byte[] text)
		{
			this.c(text.Length * 2 + 2);
			this.l[this.m++] = 40;
			for (int i = 0; i < text.Length; i++)
			{
				this.c(text[i]);
			}
			this.l[this.m++] = 41;
			this.j = false;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00042EF5 File Offset: 0x00041EF5
		public override void WriteTextRawWithoutEncryption(byte[] text, int startIndex, int count)
		{
			this.Write(text, startIndex, count);
			this.j = false;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00042F0C File Offset: 0x00041F0C
		public override void WriteTextWithoutEncryption(byte[] text)
		{
			this.c(text.Length * 2 + 2);
			this.l[this.m++] = 40;
			for (int i = 0; i < text.Length; i++)
			{
				this.c(text[i]);
			}
			this.l[this.m++] = 41;
			this.j = false;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00042F81 File Offset: 0x00041F81
		internal override void aj()
		{
			this.g();
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00042F8C File Offset: 0x00041F8C
		internal override void ak(byte A_0)
		{
			this.c(1);
			this.l[this.m++] = A_0;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00042FBC File Offset: 0x00041FBC
		internal override int al()
		{
			return 2;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00042FD0 File Offset: 0x00041FD0
		internal override int am()
		{
			return this.m + ((this.f != null) ? ((int)this.f.Position) : 0);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00043004 File Offset: 0x00042004
		internal override void an(string A_0)
		{
			this.c(1);
			this.l[this.m++] = 40;
			this.a(A_0);
			this.c(1);
			this.l[this.m++] = 41;
			this.j = true;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00043068 File Offset: 0x00042068
		internal override void ao(byte[] A_0)
		{
			this.c(A_0.Length + 2);
			this.l[this.m++] = 40;
			A_0.CopyTo(this.l, this.m);
			this.m += A_0.Length;
			this.l[this.m++] = 41;
			this.j = true;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000430E0 File Offset: 0x000420E0
		internal override void ap()
		{
			this.c(4);
			this.l[this.m++] = 116;
			this.l[this.m++] = 114;
			this.l[this.m++] = 117;
			this.l[this.m++] = 101;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00043160 File Offset: 0x00042160
		private new void e()
		{
			this.c(1);
			this.l[this.m++] = 32;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00043190 File Offset: 0x00042190
		private new void b(string A_0)
		{
			this.c(A_0.Length);
			for (int i = 0; i < A_0.Length; i++)
			{
				this.l[this.m++] = (byte)A_0[i];
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000431E0 File Offset: 0x000421E0
		private new void a(string A_0)
		{
			this.c(A_0.Length * 2);
			foreach (byte b in A_0)
			{
				byte b2 = b;
				if (b2 != 13)
				{
					switch (b2)
					{
					case 40:
						this.l[this.m++] = 92;
						break;
					case 41:
						this.l[this.m++] = 92;
						break;
					default:
						if (b2 == 92)
						{
							this.l[this.m++] = 92;
						}
						break;
					}
					this.l[this.m++] = b;
				}
				else
				{
					this.l[this.m++] = 92;
					this.l[this.m++] = 114;
				}
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000432EC File Offset: 0x000422EC
		private new void d()
		{
			if (this.j)
			{
				this.e();
			}
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00043310 File Offset: 0x00042310
		internal new void c(int A_0)
		{
			if (A_0 + this.m > this.l.Length)
			{
				this.g();
				if (A_0 > this.l.Length)
				{
					this.l = new byte[A_0];
				}
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0004335E File Offset: 0x0004235E
		internal new void g()
		{
			this.a += this.m;
			this.f.Write(this.l, 0, this.m);
			this.m = 0;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00043394 File Offset: 0x00042394
		private new void c()
		{
			this.d = this.a + this.m;
			this.Write(DocumentWriter.v);
			this.a(this.c);
			this.Write(DocumentWriter.w);
			foreach (object obj in this.e)
			{
				int a_ = (int)obj;
				this.b(a_);
			}
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00043434 File Offset: 0x00042434
		private new void b(int A_0)
		{
			this.c(10);
			for (int i = 1000000000; i >= 1; i /= 10)
			{
				int num = (int)((byte)(A_0 / i));
				this.l[this.m++] = (byte)(num + 48);
				A_0 -= num * i;
			}
			this.Write(DocumentWriter.x);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0004349C File Offset: 0x0004249C
		private new void a(int A_0)
		{
			this.c(10);
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
					this.l[this.m++] = (byte)(num + 48);
					flag = true;
				}
				A_0 -= num * i;
				i /= 10;
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00043574 File Offset: 0x00042574
		private new void b()
		{
			if (this.h != null)
			{
				base.h(this.WriteBeginObject());
				this.h.Draw(this, this.i);
				this.WriteEndObject();
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000435B8 File Offset: 0x000425B8
		private new void a()
		{
			this.Write(DocumentWriter.n);
			this.WriteDictionaryOpen();
			this.WriteName(DocumentWriter.o);
			this.WriteNumber(this.GetObjectNumber(0));
			this.WriteName(DocumentWriter.p);
			this.WriteReference(base.ab());
			this.WriteName(DocumentWriter.s);
			this.WriteReference(1);
			if (this.h != null)
			{
				this.WriteName(DocumentWriter.q);
				this.WriteReference(base.ac());
			}
			this.WriteName(DocumentWriter.r);
			this.WriteArrayOpen();
			this.a(this.k);
			this.a(this.k);
			this.WriteArrayClose();
			this.WriteDictionaryClose();
			this.Write(DocumentWriter.t);
			this.WriteNumber(this.d);
			this.Write(DocumentWriter.u);
			this.g();
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000436B0 File Offset: 0x000426B0
		private new void a(byte[] A_0)
		{
			this.c(A_0.Length * 2 + 2);
			this.l[this.m++] = 60;
			for (int i = 0; i < A_0.Length; i++)
			{
				this.b(A_0[i]);
			}
			this.l[this.m++] = 62;
			this.j = false;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00043725 File Offset: 0x00042725
		private new void b(byte A_0)
		{
			this.a(A_0 / 16);
			this.a(A_0 % 16);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00043740 File Offset: 0x00042740
		private new void a(byte A_0)
		{
			if (A_0 < 10)
			{
				this.l[this.m++] = A_0 + 48;
			}
			else
			{
				this.l[this.m++] = A_0 + 87;
			}
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0004379C File Offset: 0x0004279C
		internal new void c(byte A_0)
		{
			switch (A_0)
			{
			case 8:
				this.l[this.m++] = 92;
				this.l[this.m++] = 98;
				return;
			case 9:
				this.l[this.m++] = 92;
				this.l[this.m++] = 116;
				return;
			case 10:
				this.l[this.m++] = 92;
				this.l[this.m++] = 110;
				return;
			case 11:
				break;
			case 12:
				this.l[this.m++] = 92;
				this.l[this.m++] = 102;
				return;
			case 13:
				this.l[this.m++] = 92;
				this.l[this.m++] = 114;
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
					this.l[this.m++] = 92;
					this.l[this.m++] = 92;
					return;
				}
				this.l[this.m++] = 92;
				break;
			}
			IL_1B2:
			this.l[this.m++] = A_0;
		}

		// Token: 0x04000223 RID: 547
		internal new int a = 0;

		// Token: 0x04000224 RID: 548
		private new int b;

		// Token: 0x04000225 RID: 549
		internal new int c = 1;

		// Token: 0x04000226 RID: 550
		private new int d = 0;

		// Token: 0x04000227 RID: 551
		private new ArrayList e = new ArrayList();

		// Token: 0x04000228 RID: 552
		internal new Stream f;

		// Token: 0x04000229 RID: 553
		private new DocumentResourceList g;

		// Token: 0x0400022A RID: 554
		internal new Security h;

		// Token: 0x0400022B RID: 555
		internal new Encrypter i;

		// Token: 0x0400022C RID: 556
		internal new bool j = false;

		// Token: 0x0400022D RID: 557
		private new byte[] k = Guid.NewGuid().ToByteArray();

		// Token: 0x0400022E RID: 558
		internal new byte[] l = new byte[1024];

		// Token: 0x0400022F RID: 559
		internal new int m;
	}
}
