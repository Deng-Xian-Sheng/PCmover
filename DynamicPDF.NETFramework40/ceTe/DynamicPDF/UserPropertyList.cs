using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000669 RID: 1641
	public class UserPropertyList : AttributeType
	{
		// Token: 0x06003DEC RID: 15852 RVA: 0x00216F02 File Offset: 0x00215F02
		public UserPropertyList()
		{
			this.b = new be[2];
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06003DED RID: 15853 RVA: 0x00216F28 File Offset: 0x00215F28
		public override AttributeOwner Owner
		{
			get
			{
				return AttributeOwner.UserProperties;
			}
		}

		// Token: 0x06003DEE RID: 15854 RVA: 0x00216F3C File Offset: 0x00215F3C
		internal override int i()
		{
			return this.c;
		}

		// Token: 0x06003DEF RID: 15855 RVA: 0x00216F54 File Offset: 0x00215F54
		private void a(be A_0)
		{
			if (this.c == this.b.Length)
			{
				be[] array = new be[this.b.Length * 2];
				this.b.CopyTo(array, 0);
				this.b = array;
			}
			this.b[this.c++] = A_0;
		}

		// Token: 0x06003DF0 RID: 15856 RVA: 0x00216FB9 File Offset: 0x00215FB9
		public void Add(string name, string value)
		{
			this.a(new r1(name, value, null, false));
		}

		// Token: 0x06003DF1 RID: 15857 RVA: 0x00216FCC File Offset: 0x00215FCC
		public void Add(string name, string value, string format)
		{
			this.a(new r1(name, value, format, false));
		}

		// Token: 0x06003DF2 RID: 15858 RVA: 0x00216FDF File Offset: 0x00215FDF
		public void Add(string name, string value, string format, bool isHidden)
		{
			this.a(new r1(name, value, format, isHidden));
		}

		// Token: 0x06003DF3 RID: 15859 RVA: 0x00216FF3 File Offset: 0x00215FF3
		public void Add(string name, bool value)
		{
			this.a(new bf(name, null, false));
		}

		// Token: 0x06003DF4 RID: 15860 RVA: 0x00217005 File Offset: 0x00216005
		public void Add(string name, bool value, string format)
		{
			this.a(new bf(name, format, false));
		}

		// Token: 0x06003DF5 RID: 15861 RVA: 0x00217017 File Offset: 0x00216017
		public void Add(string name, bool value, string format, bool isHidden)
		{
			this.a(new bf(name, format, isHidden));
		}

		// Token: 0x06003DF6 RID: 15862 RVA: 0x0021702A File Offset: 0x0021602A
		public void Add(string name, float value)
		{
			this.a(new dm(name, value, null, false));
		}

		// Token: 0x06003DF7 RID: 15863 RVA: 0x0021703D File Offset: 0x0021603D
		public void Add(string name, float value, string format)
		{
			this.a(new dm(name, value, format, false));
		}

		// Token: 0x06003DF8 RID: 15864 RVA: 0x00217050 File Offset: 0x00216050
		public void Add(string name, float value, string format, bool isHidden)
		{
			this.a(new dm(name, value, format, isHidden));
		}

		// Token: 0x06003DF9 RID: 15865 RVA: 0x00217064 File Offset: 0x00216064
		internal override void j(DocumentWriter A_0)
		{
			A_0.WriteDictionaryOpen();
			A_0.WriteName(79);
			A_0.WriteName(UserPropertyList.a);
			A_0.WriteName(80);
			A_0.WriteArrayOpen();
			for (int i = 0; i < this.c; i++)
			{
				this.b[i].n(A_0);
			}
			A_0.WriteArrayClose();
			A_0.WriteDictionaryClose();
		}

		// Token: 0x04002171 RID: 8561
		private static byte[] a = new byte[]
		{
			85,
			115,
			101,
			114,
			80,
			114,
			111,
			112,
			101,
			114,
			116,
			105,
			101,
			115
		};

		// Token: 0x04002172 RID: 8562
		private be[] b = null;

		// Token: 0x04002173 RID: 8563
		private int c = 0;
	}
}
