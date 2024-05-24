using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x020002B9 RID: 697
	public abstract class Encoder
	{
		// Token: 0x0600200B RID: 8203 RVA: 0x0013C1F9 File Offset: 0x0013B1F9
		protected Encoder(bool spaceIs0x20)
		{
			this.j = spaceIs0x20;
		}

		// Token: 0x0600200C RID: 8204
		public abstract byte[] Encode(FontSubsetter subsetter, char[] text, int start, int length, bool rightToLeft);

		// Token: 0x0600200D RID: 8205 RVA: 0x0013C20B File Offset: 0x0013B20B
		public virtual void DrawEncoding(DocumentWriter writer)
		{
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600200E RID: 8206 RVA: 0x0013C210 File Offset: 0x0013B210
		public bool SpaceIs0x20
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600200F RID: 8207 RVA: 0x0013C228 File Offset: 0x0013B228
		public static SingleByteEncoder CentralEurope
		{
			get
			{
				if (Encoder.a == null)
				{
					Encoder.a = new ac0();
				}
				return Encoder.a;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06002010 RID: 8208 RVA: 0x0013C258 File Offset: 0x0013B258
		public static SingleByteEncoder Latin1
		{
			get
			{
				if (Encoder.b == null)
				{
					Encoder.b = new ac7();
				}
				return Encoder.b;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06002011 RID: 8209 RVA: 0x0013C288 File Offset: 0x0013B288
		public static SingleByteEncoder Turkish
		{
			get
			{
				if (Encoder.c == null)
				{
					Encoder.c = new aec();
				}
				return Encoder.c;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06002012 RID: 8210 RVA: 0x0013C2B8 File Offset: 0x0013B2B8
		public static SingleByteEncoder Baltic
		{
			get
			{
				if (Encoder.d == null)
				{
					Encoder.d = new acz();
				}
				return Encoder.d;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06002013 RID: 8211 RVA: 0x0013C2E8 File Offset: 0x0013B2E8
		public static SingleByteEncoder Latin2
		{
			get
			{
				if (Encoder.e == null)
				{
					Encoder.e = new ac8();
				}
				return Encoder.e;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06002014 RID: 8212 RVA: 0x0013C318 File Offset: 0x0013B318
		public static SingleByteEncoder Latin9
		{
			get
			{
				if (Encoder.f == null)
				{
					Encoder.f = new ac9();
				}
				return Encoder.f;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06002015 RID: 8213 RVA: 0x0013C348 File Offset: 0x0013B348
		public static Encoder Unicode
		{
			get
			{
				if (Encoder.h == null)
				{
					Encoder.h = new aed();
				}
				return Encoder.h;
			}
		}

		// Token: 0x06002016 RID: 8214 RVA: 0x0013C378 File Offset: 0x0013B378
		internal static Encoder a()
		{
			if (Encoder.g == null)
			{
				Encoder.g = new r4();
			}
			return Encoder.g;
		}

		// Token: 0x06002017 RID: 8215
		internal abstract int fl();

		// Token: 0x06002018 RID: 8216 RVA: 0x0013C3A8 File Offset: 0x0013B3A8
		internal virtual void fm(br A_0, FontSubsetter A_1, char[] A_2, int A_3, int A_4, bool A_5)
		{
			byte[] a_ = this.Encode(A_1, A_2, A_3, A_4, A_5);
			A_0.b(a_);
		}

		// Token: 0x04000DDC RID: 3548
		private static SingleByteEncoder a = null;

		// Token: 0x04000DDD RID: 3549
		private static SingleByteEncoder b = null;

		// Token: 0x04000DDE RID: 3550
		private static SingleByteEncoder c = null;

		// Token: 0x04000DDF RID: 3551
		private static SingleByteEncoder d = null;

		// Token: 0x04000DE0 RID: 3552
		private static SingleByteEncoder e = null;

		// Token: 0x04000DE1 RID: 3553
		private static SingleByteEncoder f = null;

		// Token: 0x04000DE2 RID: 3554
		private static SingleByteEncoder g = null;

		// Token: 0x04000DE3 RID: 3555
		private static Encoder h = null;

		// Token: 0x04000DE4 RID: 3556
		internal static byte[] i = new byte[]
		{
			69,
			110,
			99,
			111,
			100,
			105,
			110,
			103
		};

		// Token: 0x04000DE5 RID: 3557
		private bool j;
	}
}
