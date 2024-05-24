using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000049 RID: 73
	public abstract class Resource
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0003DE06 File Offset: 0x0003CE06
		protected Resource() : this(Resource.NewUid())
		{
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0003DE16 File Offset: 0x0003CE16
		protected Resource(long uid)
		{
			this.k = uid;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000296 RID: 662 RVA: 0x0003DE30 File Offset: 0x0003CE30
		public long Uid
		{
			get
			{
				return this.k;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0003DE48 File Offset: 0x0003CE48
		public virtual int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000298 RID: 664
		public abstract void Draw(DocumentWriter writer);

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0003DE5C File Offset: 0x0003CE5C
		public virtual ResourceType ResourceType
		{
			get
			{
				return ResourceType.Default;
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0003DE70 File Offset: 0x0003CE70
		public static long NewUid()
		{
			if ((Resource.j += 1L) < 0L)
			{
				Resource.j = 0L;
			}
			return Resource.j;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0003DEAC File Offset: 0x0003CEAC
		internal virtual int b()
		{
			return -1;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0003DEBF File Offset: 0x0003CEBF
		internal virtual void c(int A_0)
		{
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0003DEC4 File Offset: 0x0003CEC4
		internal virtual bool d()
		{
			return false;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0003DED8 File Offset: 0x0003CED8
		internal virtual bool hn()
		{
			return false;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0003DEEC File Offset: 0x0003CEEC
		internal FormFieldOutput ag()
		{
			return this.l;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0003DF04 File Offset: 0x0003CF04
		internal void a(FormFieldOutput A_0)
		{
			this.l = A_0;
		}

		// Token: 0x040001B4 RID: 436
		internal static byte[] a = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x040001B5 RID: 437
		internal static byte[] b = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x040001B6 RID: 438
		internal static byte[] c = new byte[]
		{
			70,
			105,
			108,
			116,
			101,
			114
		};

		// Token: 0x040001B7 RID: 439
		internal static byte[] d = new byte[]
		{
			70,
			108,
			97,
			116,
			101,
			68,
			101,
			99,
			111,
			100,
			101
		};

		// Token: 0x040001B8 RID: 440
		internal static byte[] e = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x040001B9 RID: 441
		internal static byte[] f = new byte[]
		{
			70,
			111,
			114,
			109
		};

		// Token: 0x040001BA RID: 442
		internal static byte[] g = new byte[]
		{
			88,
			79,
			98,
			106,
			101,
			99,
			116
		};

		// Token: 0x040001BB RID: 443
		internal static byte[] h = new byte[]
		{
			73,
			109,
			97,
			103,
			101
		};

		// Token: 0x040001BC RID: 444
		internal static byte[] i = new byte[]
		{
			70,
			111,
			110,
			116
		};

		// Token: 0x040001BD RID: 445
		private static long j = 0L;

		// Token: 0x040001BE RID: 446
		private long k;

		// Token: 0x040001BF RID: 447
		private FormFieldOutput l = FormFieldOutput.Inherit;
	}
}
