using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200063A RID: 1594
	public abstract class Security
	{
		// Token: 0x06003B85 RID: 15237 RVA: 0x001FC7F0 File Offset: 0x001FB7F0
		protected Security()
		{
		}

		// Token: 0x06003B86 RID: 15238 RVA: 0x001FC86C File Offset: 0x001FB86C
		protected Security(string ownerPassword, string userPassword)
		{
			this.r = ownerPassword;
			this.s = userPassword;
		}

		// Token: 0x06003B87 RID: 15239 RVA: 0x001FC8F4 File Offset: 0x001FB8F4
		protected Security(string password)
		{
			this.r = password;
			this.s = password;
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06003B89 RID: 15241 RVA: 0x001FC988 File Offset: 0x001FB988
		// (set) Token: 0x06003B88 RID: 15240 RVA: 0x001FC97B File Offset: 0x001FB97B
		public string OwnerPassword
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

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06003B8B RID: 15243 RVA: 0x001FC9AC File Offset: 0x001FB9AC
		// (set) Token: 0x06003B8A RID: 15242 RVA: 0x001FC9A0 File Offset: 0x001FB9A0
		public string UserPassword
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

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06003B8D RID: 15245 RVA: 0x001FC9D0 File Offset: 0x001FB9D0
		// (set) Token: 0x06003B8C RID: 15244 RVA: 0x001FC9C4 File Offset: 0x001FB9C4
		public bool AllowPrint
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

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06003B8F RID: 15247 RVA: 0x001FC9F4 File Offset: 0x001FB9F4
		// (set) Token: 0x06003B8E RID: 15246 RVA: 0x001FC9E8 File Offset: 0x001FB9E8
		public bool AllowEdit
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

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06003B91 RID: 15249 RVA: 0x001FCA18 File Offset: 0x001FBA18
		// (set) Token: 0x06003B90 RID: 15248 RVA: 0x001FCA0C File Offset: 0x001FBA0C
		public bool AllowCopy
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

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06003B93 RID: 15251 RVA: 0x001FCA3C File Offset: 0x001FBA3C
		// (set) Token: 0x06003B92 RID: 15250 RVA: 0x001FCA30 File Offset: 0x001FBA30
		public bool AllowUpdateAnnotsAndFields
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

		// Token: 0x06003B94 RID: 15252 RVA: 0x001FCA54 File Offset: 0x001FBA54
		internal void a(bool A_0)
		{
			this.x = A_0;
		}

		// Token: 0x06003B95 RID: 15253 RVA: 0x001FCA60 File Offset: 0x001FBA60
		internal bool c()
		{
			return this.x;
		}

		// Token: 0x06003B96 RID: 15254 RVA: 0x001FCA78 File Offset: 0x001FBA78
		internal void b(bool A_0)
		{
			this.y = A_0;
		}

		// Token: 0x06003B97 RID: 15255 RVA: 0x001FCA84 File Offset: 0x001FBA84
		internal bool d()
		{
			return this.y;
		}

		// Token: 0x06003B98 RID: 15256 RVA: 0x001FCA9C File Offset: 0x001FBA9C
		internal void c(bool A_0)
		{
			this.z = A_0;
		}

		// Token: 0x06003B99 RID: 15257 RVA: 0x001FCAA8 File Offset: 0x001FBAA8
		internal bool e()
		{
			return this.z;
		}

		// Token: 0x06003B9A RID: 15258 RVA: 0x001FCAC0 File Offset: 0x001FBAC0
		internal void d(bool A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06003B9B RID: 15259 RVA: 0x001FCACC File Offset: 0x001FBACC
		internal bool f()
		{
			return this.n;
		}

		// Token: 0x06003B9C RID: 15260 RVA: 0x001FCAE4 File Offset: 0x001FBAE4
		internal void e(bool A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06003B9D RID: 15261 RVA: 0x001FCAF0 File Offset: 0x001FBAF0
		internal bool g()
		{
			return this.o;
		}

		// Token: 0x06003B9E RID: 15262 RVA: 0x001FCB08 File Offset: 0x001FBB08
		internal void f(bool A_0)
		{
			this.p = A_0;
		}

		// Token: 0x06003B9F RID: 15263 RVA: 0x001FCB14 File Offset: 0x001FBB14
		internal bool h()
		{
			return this.p;
		}

		// Token: 0x06003BA0 RID: 15264 RVA: 0x001FCB2C File Offset: 0x001FBB2C
		internal void g(bool A_0)
		{
			this.q = A_0;
		}

		// Token: 0x06003BA1 RID: 15265 RVA: 0x001FCB38 File Offset: 0x001FBB38
		internal bool i()
		{
			return this.q;
		}

		// Token: 0x06003BA2 RID: 15266 RVA: 0x001FCB50 File Offset: 0x001FBB50
		internal virtual PdfVersion u()
		{
			return PdfVersion.v1_5;
		}

		// Token: 0x06003BA3 RID: 15267 RVA: 0x001FCB64 File Offset: 0x001FBB64
		internal virtual b5 a()
		{
			return b5.c;
		}

		// Token: 0x06003BA4 RID: 15268
		public abstract void Draw(DocumentWriter writer, Encrypter encrypter);

		// Token: 0x06003BA5 RID: 15269
		public abstract Encrypter GetEncrypter(byte[] id);

		// Token: 0x06003BA6 RID: 15270 RVA: 0x001FCB78 File Offset: 0x001FBB78
		protected byte[] BinPassword(string password)
		{
			byte[] array = new byte[32];
			byte[] bytes = Security.a.GetBytes(password);
			Array.Copy(bytes, array, bytes.Length);
			Array.Copy(Security.b, 0, array, bytes.Length, 32 - bytes.Length);
			return array;
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06003BA7 RID: 15271 RVA: 0x001FCBC0 File Offset: 0x001FBBC0
		protected static byte[] Filler
		{
			get
			{
				return Security.b;
			}
		}

		// Token: 0x04002082 RID: 8322
		private static Encoding a = Encoding.ASCII;

		// Token: 0x04002083 RID: 8323
		private static byte[] b = new byte[]
		{
			40,
			191,
			78,
			94,
			78,
			117,
			138,
			65,
			100,
			0,
			78,
			86,
			byte.MaxValue,
			250,
			1,
			8,
			46,
			46,
			0,
			182,
			208,
			104,
			62,
			128,
			47,
			12,
			169,
			254,
			100,
			83,
			105,
			122
		};

		// Token: 0x04002084 RID: 8324
		internal static byte[] c = new byte[]
		{
			70,
			105,
			108,
			116,
			101,
			114
		};

		// Token: 0x04002085 RID: 8325
		internal static byte[] d = new byte[]
		{
			83,
			116,
			97,
			110,
			100,
			97,
			114,
			100
		};

		// Token: 0x04002086 RID: 8326
		internal static byte[] e = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x04002087 RID: 8327
		internal static byte[] f = new byte[]
		{
			67,
			70
		};

		// Token: 0x04002088 RID: 8328
		internal static byte[] g = new byte[]
		{
			83,
			116,
			100,
			67,
			70
		};

		// Token: 0x04002089 RID: 8329
		internal static byte[] h = new byte[]
		{
			65,
			117,
			116,
			104,
			69,
			118,
			101,
			110,
			116
		};

		// Token: 0x0400208A RID: 8330
		internal static byte[] i = new byte[]
		{
			68,
			111,
			99,
			79,
			112,
			101,
			110
		};

		// Token: 0x0400208B RID: 8331
		internal static byte[] j = new byte[]
		{
			67,
			70,
			77
		};

		// Token: 0x0400208C RID: 8332
		internal static byte[] k = new byte[]
		{
			83,
			116,
			114,
			70
		};

		// Token: 0x0400208D RID: 8333
		internal static byte[] l = new byte[]
		{
			83,
			116,
			109,
			70
		};

		// Token: 0x0400208E RID: 8334
		internal static byte[] m = new byte[]
		{
			69,
			110,
			99,
			114,
			121,
			112,
			116,
			77,
			101,
			116,
			97,
			100,
			97,
			116,
			97
		};

		// Token: 0x0400208F RID: 8335
		private bool n = false;

		// Token: 0x04002090 RID: 8336
		private bool o = true;

		// Token: 0x04002091 RID: 8337
		private bool p = false;

		// Token: 0x04002092 RID: 8338
		private bool q = true;

		// Token: 0x04002093 RID: 8339
		private string r = "";

		// Token: 0x04002094 RID: 8340
		private string s = "";

		// Token: 0x04002095 RID: 8341
		private bool t = true;

		// Token: 0x04002096 RID: 8342
		private bool u = true;

		// Token: 0x04002097 RID: 8343
		private bool v = true;

		// Token: 0x04002098 RID: 8344
		private bool w = true;

		// Token: 0x04002099 RID: 8345
		private bool x = true;

		// Token: 0x0400209A RID: 8346
		private bool y = false;

		// Token: 0x0400209B RID: 8347
		private bool z = false;
	}
}
