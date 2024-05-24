using System;
using System.Security.Cryptography;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Cryptography
{
	// Token: 0x020006C5 RID: 1733
	public class Aes128Security : Security
	{
		// Token: 0x060042E3 RID: 17123 RVA: 0x0022D042 File Offset: 0x0022C042
		public Aes128Security()
		{
		}

		// Token: 0x060042E4 RID: 17124 RVA: 0x0022D054 File Offset: 0x0022C054
		public Aes128Security(string ownerPassword, string userPassword) : base(ownerPassword, userPassword)
		{
		}

		// Token: 0x060042E5 RID: 17125 RVA: 0x0022D068 File Offset: 0x0022C068
		public Aes128Security(string password) : base(password)
		{
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060042E7 RID: 17127 RVA: 0x0022D088 File Offset: 0x0022C088
		// (set) Token: 0x060042E6 RID: 17126 RVA: 0x0022D07B File Offset: 0x0022C07B
		public bool AllowFormFilling
		{
			get
			{
				return base.f();
			}
			set
			{
				base.d(value);
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060042E9 RID: 17129 RVA: 0x0022D0AC File Offset: 0x0022C0AC
		// (set) Token: 0x060042E8 RID: 17128 RVA: 0x0022D0A0 File Offset: 0x0022C0A0
		public bool AllowAccessibility
		{
			get
			{
				return base.g();
			}
			set
			{
				base.e(value);
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060042EB RID: 17131 RVA: 0x0022D0D0 File Offset: 0x0022C0D0
		// (set) Token: 0x060042EA RID: 17130 RVA: 0x0022D0C4 File Offset: 0x0022C0C4
		public bool AllowDocumentAssembly
		{
			get
			{
				return base.h();
			}
			set
			{
				base.f(value);
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060042ED RID: 17133 RVA: 0x0022D0F4 File Offset: 0x0022C0F4
		// (set) Token: 0x060042EC RID: 17132 RVA: 0x0022D0E8 File Offset: 0x0022C0E8
		public bool AllowHighResolutionPrinting
		{
			get
			{
				return base.i();
			}
			set
			{
				base.g(value);
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060042EF RID: 17135 RVA: 0x0022D17C File Offset: 0x0022C17C
		// (set) Token: 0x060042EE RID: 17134 RVA: 0x0022D10C File Offset: 0x0022C10C
		public EncryptDocumentComponents DocumentComponents
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
				if (value == EncryptDocumentComponents.AllExceptMetadata)
				{
					base.a(false);
					base.b(false);
				}
				else if (value == EncryptDocumentComponents.OnlyFileAttachments)
				{
					base.b(true);
					base.a(true);
				}
				else if (value == EncryptDocumentComponents.All)
				{
					base.a(true);
					base.b(false);
				}
			}
		}

		// Token: 0x060042F0 RID: 17136 RVA: 0x0022D194 File Offset: 0x0022C194
		internal override b5 a()
		{
			return b5.b;
		}

		// Token: 0x060042F1 RID: 17137 RVA: 0x0022D1A8 File Offset: 0x0022C1A8
		public override Encrypter GetEncrypter(byte[] id)
		{
			MD5 a_ = new MD5CryptoServiceProvider();
			byte[] a_2 = new byte[32];
			byte[] a_3 = new byte[5];
			int a_4 = this.b();
			byte[] array = this.a(a_);
			a_3 = this.a(a_, id, array, a_4);
			a_2 = this.a(a_, id, a_3);
			return new bz(array, a_2, a_3, a_4, this.DocumentComponents);
		}

		// Token: 0x060042F2 RID: 17138 RVA: 0x0022D20C File Offset: 0x0022C20C
		public override void Draw(DocumentWriter writer, Encrypter encrypter)
		{
			writer.WriteDictionaryOpen();
			writer.WriteName(Security.c);
			writer.WriteName(Security.d);
			writer.WriteName(Security.f);
			writer.WriteDictionaryOpen();
			writer.WriteName(Security.g);
			writer.WriteDictionaryOpen();
			writer.WriteName(Security.e);
			writer.WriteNumber(16);
			writer.WriteName(Security.h);
			if (this.DocumentComponents == EncryptDocumentComponents.OnlyFileAttachments)
			{
				writer.WriteName(Aes128Security.b);
			}
			else
			{
				writer.WriteName(Security.i);
			}
			writer.WriteName(Security.j);
			writer.WriteName(Aes128Security.c);
			writer.WriteDictionaryClose();
			writer.WriteDictionaryClose();
			writer.WriteName(82);
			writer.WriteNumber(4);
			writer.WriteName(86);
			writer.WriteNumber(4);
			writer.WriteName(Security.e);
			writer.WriteNumber(128);
			if (this.DocumentComponents == EncryptDocumentComponents.AllExceptMetadata)
			{
				writer.WriteName(Security.m);
				writer.WriteBoolean(false);
			}
			if (this.DocumentComponents == EncryptDocumentComponents.OnlyFileAttachments)
			{
				writer.WriteName(Aes128Security.d);
				writer.WriteName(Security.g);
				writer.WriteName(Security.k);
				writer.WriteName(Aes128Security.e);
				writer.WriteName(Security.l);
				writer.WriteName(Aes128Security.e);
			}
			else
			{
				writer.WriteName(Security.k);
				writer.WriteName(Security.g);
				writer.WriteName(Security.l);
				writer.WriteName(Security.g);
			}
			encrypter.Draw(writer);
			writer.WriteDictionaryClose();
		}

		// Token: 0x060042F3 RID: 17139 RVA: 0x0022D3D0 File Offset: 0x0022C3D0
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[48];
			Security.Filler.CopyTo(array2, 0);
			A_1.CopyTo(array2, 32);
			byte[] array3 = A_0.ComputeHash(array2);
			Aes128Security.a.a(array3, A_2);
			for (int i = 1; i < 20; i++)
			{
				byte[] a_ = this.a(A_2, (byte)i);
				Aes128Security.a.a(array3, a_);
			}
			Array.Copy(array3, 0, array, 0, 16);
			Array.Copy(Security.Filler, 0, array, 16, 16);
			return array;
		}

		// Token: 0x060042F4 RID: 17140 RVA: 0x0022D470 File Offset: 0x0022C470
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2, int A_3)
		{
			byte[] array = new byte[16];
			byte[] array2;
			if (this.DocumentComponents == EncryptDocumentComponents.AllExceptMetadata)
			{
				array2 = new byte[88];
			}
			else
			{
				array2 = new byte[84];
			}
			Array.Copy(base.BinPassword(base.UserPassword), 0, array2, 0, 32);
			Array.Copy(A_2, 0, array2, 32, 32);
			Array.Copy(BitConverter.GetBytes(A_3), 0, array2, 64, 4);
			Array.Copy(A_1, 0, array2, 68, 16);
			if (this.DocumentComponents == EncryptDocumentComponents.AllExceptMetadata)
			{
				array2[84] = byte.MaxValue;
				array2[85] = byte.MaxValue;
				array2[86] = byte.MaxValue;
				array2[87] = byte.MaxValue;
			}
			byte[] array3 = A_0.ComputeHash(array2);
			for (int i = 0; i < 50; i++)
			{
				array3 = A_0.ComputeHash(array3);
			}
			Array.Copy(array3, 0, array, 0, 16);
			return array;
		}

		// Token: 0x060042F5 RID: 17141 RVA: 0x0022D564 File Offset: 0x0022C564
		private int b()
		{
			int num = -4;
			if (!base.AllowPrint)
			{
				num &= -5;
			}
			if (!base.AllowEdit)
			{
				num &= -9;
			}
			if (!base.AllowCopy)
			{
				num &= -17;
			}
			if (!base.AllowUpdateAnnotsAndFields)
			{
				num &= -33;
			}
			if (!this.AllowFormFilling)
			{
				num &= -257;
			}
			if (!this.AllowAccessibility)
			{
				num &= -513;
			}
			if (!this.AllowDocumentAssembly)
			{
				num &= -1025;
			}
			if (!this.AllowHighResolutionPrinting)
			{
				num &= -2049;
			}
			return num;
		}

		// Token: 0x060042F6 RID: 17142 RVA: 0x0022D600 File Offset: 0x0022C600
		private byte[] a(MD5 A_0)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[16];
			byte[] buffer = base.BinPassword(base.OwnerPassword);
			byte[] array3 = A_0.ComputeHash(buffer);
			for (int i = 0; i < 50; i++)
			{
				array3 = A_0.ComputeHash(array3);
			}
			Array.Copy(array3, array2, 16);
			array = base.BinPassword(base.UserPassword);
			Aes128Security.a.a(array, array2);
			for (int i = 1; i < 20; i++)
			{
				byte[] a_ = this.a(array2, (byte)i);
				Aes128Security.a.a(array, a_);
			}
			return array;
		}

		// Token: 0x060042F7 RID: 17143 RVA: 0x0022D6B4 File Offset: 0x0022C6B4
		private byte[] a(byte[] A_0, byte A_1)
		{
			byte[] array = new byte[A_0.Length];
			A_0.CopyTo(array, 0);
			for (int i = 0; i < A_0.Length; i++)
			{
				byte[] array2 = array;
				int num = i;
				array2[num] ^= A_1;
			}
			return array;
		}

		// Token: 0x04002547 RID: 9543
		private static yw a = new yw();

		// Token: 0x04002548 RID: 9544
		private static byte[] b = new byte[]
		{
			69,
			70,
			79,
			112,
			101,
			110
		};

		// Token: 0x04002549 RID: 9545
		private new static byte[] c = new byte[]
		{
			65,
			69,
			83,
			86,
			50
		};

		// Token: 0x0400254A RID: 9546
		private new static byte[] d = new byte[]
		{
			69,
			70,
			70
		};

		// Token: 0x0400254B RID: 9547
		private new static byte[] e = new byte[]
		{
			73,
			100,
			101,
			110,
			116,
			105,
			116,
			121
		};

		// Token: 0x0400254C RID: 9548
		private new EncryptDocumentComponents f = EncryptDocumentComponents.All;
	}
}
