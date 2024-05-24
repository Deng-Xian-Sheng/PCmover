using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Cryptography
{
	// Token: 0x020006C6 RID: 1734
	public class Aes256Security : Security
	{
		// Token: 0x060042F9 RID: 17145 RVA: 0x0022D773 File Offset: 0x0022C773
		public Aes256Security()
		{
		}

		// Token: 0x060042FA RID: 17146 RVA: 0x0022D790 File Offset: 0x0022C790
		public Aes256Security(string ownerPassword, string userPassword) : base(ownerPassword, userPassword)
		{
		}

		// Token: 0x060042FB RID: 17147 RVA: 0x0022D7AF File Offset: 0x0022C7AF
		public Aes256Security(string password) : base(password)
		{
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060042FD RID: 17149 RVA: 0x0022D7D8 File Offset: 0x0022C7D8
		// (set) Token: 0x060042FC RID: 17148 RVA: 0x0022D7CD File Offset: 0x0022C7CD
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

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x060042FF RID: 17151 RVA: 0x0022D7FC File Offset: 0x0022C7FC
		// (set) Token: 0x060042FE RID: 17150 RVA: 0x0022D7F0 File Offset: 0x0022C7F0
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

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06004301 RID: 17153 RVA: 0x0022D820 File Offset: 0x0022C820
		// (set) Token: 0x06004300 RID: 17152 RVA: 0x0022D814 File Offset: 0x0022C814
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

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06004303 RID: 17155 RVA: 0x0022D844 File Offset: 0x0022C844
		// (set) Token: 0x06004302 RID: 17154 RVA: 0x0022D838 File Offset: 0x0022C838
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

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06004305 RID: 17157 RVA: 0x0022D8CC File Offset: 0x0022C8CC
		// (set) Token: 0x06004304 RID: 17156 RVA: 0x0022D85C File Offset: 0x0022C85C
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

		// Token: 0x06004306 RID: 17158 RVA: 0x0022D8E4 File Offset: 0x0022C8E4
		internal override b5 a()
		{
			return b5.b;
		}

		// Token: 0x06004307 RID: 17159 RVA: 0x0022D8F8 File Offset: 0x0022C8F8
		public override Encrypter GetEncrypter(byte[] id)
		{
			SHA256 a_ = new SHA256CryptoServiceProvider();
			byte[] array = new byte[48];
			byte[] array2 = new byte[32];
			byte[] a_2 = new byte[48];
			byte[] array3 = new byte[32];
			byte[] array4 = new byte[32];
			byte[] a_3 = new byte[16];
			int num = this.b();
			this.e.NextBytes(array4);
			this.a(a_, a_2, array3, array, array2, array4);
			a_3 = this.a(num, array4);
			return new b0(array, a_2, array4, num, array3, array2, a_3);
		}

		// Token: 0x06004308 RID: 17160 RVA: 0x0022D988 File Offset: 0x0022C988
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
			writer.WriteNumber(32);
			writer.WriteName(Security.h);
			if (this.DocumentComponents == EncryptDocumentComponents.OnlyFileAttachments)
			{
				writer.WriteName(Aes256Security.a);
			}
			else
			{
				writer.WriteName(Security.i);
			}
			writer.WriteName(Security.j);
			writer.WriteName(Aes256Security.b);
			writer.WriteDictionaryClose();
			writer.WriteDictionaryClose();
			writer.WriteName(82);
			writer.WriteNumber(6);
			writer.WriteName(86);
			writer.WriteNumber(5);
			writer.WriteName(Security.e);
			writer.WriteNumber(256);
			if (this.DocumentComponents == EncryptDocumentComponents.AllExceptMetadata)
			{
				writer.WriteName(Security.m);
				writer.WriteBoolean(false);
			}
			if (this.DocumentComponents == EncryptDocumentComponents.OnlyFileAttachments)
			{
				writer.WriteName(Aes256Security.c);
				writer.WriteName(Security.g);
				writer.WriteName(Security.k);
				writer.WriteName(Aes256Security.d);
				writer.WriteName(Security.l);
				writer.WriteName(Aes256Security.d);
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

		// Token: 0x06004309 RID: 17161 RVA: 0x0022DB4C File Offset: 0x0022CB4C
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

		// Token: 0x0600430A RID: 17162 RVA: 0x0022DBE8 File Offset: 0x0022CBE8
		private byte[] a(string A_0)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(A_0);
			int num = (bytes.Length > 127) ? 127 : bytes.Length;
			byte[] array = new byte[num];
			Array.Copy(bytes, array, num);
			return array;
		}

		// Token: 0x0600430B RID: 17163 RVA: 0x0022DC28 File Offset: 0x0022CC28
		private void a(SHA256 A_0, byte[] A_1, byte[] A_2, byte[] A_3, byte[] A_4, byte[] A_5)
		{
			SHA384 a_ = new SHA384CryptoServiceProvider();
			SHA512 a_2 = new SHA512CryptoServiceProvider();
			byte[] array = new byte[16];
			this.e.NextBytes(array);
			byte[] array2 = this.a(base.UserPassword);
			byte[] array3 = new byte[array2.Length + 8];
			Array.Copy(array2, 0, array3, 0, array2.Length);
			Array.Copy(array, 0, array3, array2.Length, 8);
			byte[] array4 = this.a(A_0, a_, a_2, array2, array3);
			Array.Copy(array4, 0, A_1, 0, 32);
			Array.Copy(array, 0, A_1, 32, 16);
			Array.Copy(array, 8, array3, array2.Length, 8);
			array4 = this.a(A_0, a_, a_2, array2, array3);
			byte[] sourceArray = this.a(A_5, array4, CipherMode.CBC);
			Array.Copy(sourceArray, 0, A_2, 0, 32);
			if (base.UserPassword != base.OwnerPassword)
			{
				array2 = this.a(base.OwnerPassword);
			}
			array3 = new byte[array2.Length + 8 + 48];
			this.e.NextBytes(array);
			Array.Copy(array2, 0, array3, 0, array2.Length);
			Array.Copy(array, 0, array3, array2.Length, 8);
			Array.Copy(A_1, 0, array3, array2.Length + 8, 48);
			array4 = this.a(A_0, a_, a_2, array2, array3, A_1);
			Array.Copy(array4, 0, A_3, 0, 32);
			Array.Copy(array, 0, A_3, 32, 16);
			Array.Copy(array, 8, array3, array2.Length, 8);
			Array.Copy(A_1, 0, array3, array2.Length + 8, 48);
			array4 = this.a(A_0, a_, a_2, array2, array3, A_1);
			sourceArray = this.a(A_5, array4, CipherMode.CBC);
			Array.Copy(sourceArray, 0, A_4, 0, 32);
		}

		// Token: 0x0600430C RID: 17164 RVA: 0x0022DDD0 File Offset: 0x0022CDD0
		private byte[] a(SHA256 A_0, SHA384 A_1, SHA512 A_2, byte[] A_3, byte[] A_4, byte[] A_5)
		{
			byte[] sourceArray = A_0.ComputeHash(A_4);
			byte[] array = null;
			int num = 0;
			for (int i = 0; i < 64; i++)
			{
				this.a(A_0, A_1, A_2, ref sourceArray, ref array, A_3, A_5);
				num++;
				if (num >= 64)
				{
					while ((int)array[array.Length - 1] > num - 32)
					{
						this.a(A_0, A_1, A_2, ref sourceArray, ref array, A_3, A_5);
						num++;
					}
				}
			}
			byte[] array2 = new byte[32];
			Array.Copy(sourceArray, array2, 32);
			return array2;
		}

		// Token: 0x0600430D RID: 17165 RVA: 0x0022DE6C File Offset: 0x0022CE6C
		private void a(SHA256 A_0, SHA384 A_1, SHA512 A_2, ref byte[] A_3, ref byte[] A_4, byte[] A_5, byte[] A_6)
		{
			byte[] array = new byte[A_5.Length + A_3.Length + 48];
			Array.Copy(A_5, array, A_5.Length);
			Array.Copy(A_3, 0, array, A_5.Length, A_3.Length);
			Array.Copy(A_6, 0, array, A_5.Length + A_3.Length, 48);
			byte[] array2 = new byte[array.Length * 64];
			for (int i = 0; i < 64; i++)
			{
				Array.Copy(array, 0, array2, array.Length * i, array.Length);
			}
			A_4 = this.a(array2, A_3);
			byte[] array3 = new byte[16];
			Array.Copy(A_4, 0, array3, 0, 16);
			h a_ = new h(array3);
			h h = zz93.h.d(a_, zz93.h.a(3));
			switch (h.b())
			{
			case 0:
				A_3 = A_0.ComputeHash(A_4);
				break;
			case 1:
				A_3 = A_1.ComputeHash(A_4);
				break;
			case 2:
				A_3 = A_2.ComputeHash(A_4);
				break;
			}
		}

		// Token: 0x0600430E RID: 17166 RVA: 0x0022DF78 File Offset: 0x0022CF78
		private byte[] a(SHA256 A_0, SHA384 A_1, SHA512 A_2, byte[] A_3, byte[] A_4)
		{
			byte[] sourceArray = A_0.ComputeHash(A_4);
			byte[] array = null;
			int num = 0;
			for (int i = 0; i < 64; i++)
			{
				this.a(A_0, A_1, A_2, ref sourceArray, ref array, A_3);
				num++;
				if (num >= 64)
				{
					while ((int)array[array.Length - 1] > num - 32)
					{
						this.a(A_0, A_1, A_2, ref sourceArray, ref array, A_3);
						num++;
					}
				}
			}
			byte[] array2 = new byte[32];
			Array.Copy(sourceArray, array2, 32);
			return array2;
		}

		// Token: 0x0600430F RID: 17167 RVA: 0x0022E010 File Offset: 0x0022D010
		private void a(SHA256 A_0, SHA384 A_1, SHA512 A_2, ref byte[] A_3, ref byte[] A_4, byte[] A_5)
		{
			byte[] array = new byte[A_5.Length + A_3.Length];
			Array.Copy(A_5, array, A_5.Length);
			Array.Copy(A_3, 0, array, A_5.Length, A_3.Length);
			byte[] array2 = new byte[array.Length * 64];
			for (int i = 0; i < 64; i++)
			{
				Array.Copy(array, 0, array2, array.Length * i, array.Length);
			}
			A_4 = this.a(array2, A_3);
			byte[] array3 = new byte[16];
			Array.Copy(A_4, 0, array3, 0, 16);
			h a_ = new h(array3);
			h h = zz93.h.d(a_, zz93.h.a(3));
			switch (h.b())
			{
			case 0:
				A_3 = A_0.ComputeHash(A_4);
				break;
			case 1:
				A_3 = A_1.ComputeHash(A_4);
				break;
			case 2:
				A_3 = A_2.ComputeHash(A_4);
				break;
			}
		}

		// Token: 0x06004310 RID: 17168 RVA: 0x0022E104 File Offset: 0x0022D104
		private byte[] a(byte[] A_0, byte[] A_1)
		{
			byte[] result;
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.Padding = PaddingMode.None;
				aesCryptoServiceProvider.KeySize = 128;
				byte[] array = new byte[16];
				byte[] array2 = new byte[16];
				Array.Copy(A_1, array, 16);
				Array.Copy(A_1, 16, array2, 0, 16);
				aesCryptoServiceProvider.Key = array;
				aesCryptoServiceProvider.IV = array2;
				ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
				byte[] array3 = new byte[A_0.Length];
				using (MemoryStream memoryStream = new MemoryStream(A_0))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array3, 0, array3.Length);
						memoryStream.Close();
						cryptoStream.Close();
					}
				}
				aesCryptoServiceProvider.Clear();
				result = array3;
			}
			return result;
		}

		// Token: 0x06004311 RID: 17169 RVA: 0x0022E238 File Offset: 0x0022D238
		private byte[] a(int A_0, byte[] A_1)
		{
			byte[] array = new byte[16];
			byte[] bytes = BitConverter.GetBytes(A_0);
			Array.Copy(bytes, 0, array, 0, bytes.Length);
			for (int i = 4; i < 8; i++)
			{
				array[i] = byte.MaxValue;
			}
			if (this.DocumentComponents == EncryptDocumentComponents.AllExceptMetadata)
			{
				array[8] = 70;
			}
			else
			{
				array[8] = 84;
			}
			array[9] = 97;
			array[10] = 100;
			array[11] = 98;
			array[12] = 1;
			array[13] = 2;
			array[14] = 3;
			array[15] = 4;
			return this.a(array, A_1, CipherMode.ECB);
		}

		// Token: 0x06004312 RID: 17170 RVA: 0x0022E2D4 File Offset: 0x0022D2D4
		private byte[] a(byte[] A_0, byte[] A_1, CipherMode A_2)
		{
			byte[] result;
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				aesCryptoServiceProvider.IV = new byte[16];
				aesCryptoServiceProvider.Padding = PaddingMode.None;
				aesCryptoServiceProvider.Mode = A_2;
				aesCryptoServiceProvider.KeySize = 256;
				ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor(A_1, aesCryptoServiceProvider.IV);
				byte[] array = new byte[A_0.Length];
				using (MemoryStream memoryStream = new MemoryStream(A_0))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array, 0, array.Length);
						memoryStream.Close();
						cryptoStream.Close();
						result = array;
					}
				}
			}
			return result;
		}

		// Token: 0x0400254D RID: 9549
		private static byte[] a = new byte[]
		{
			69,
			70,
			79,
			112,
			101,
			110
		};

		// Token: 0x0400254E RID: 9550
		private static byte[] b = new byte[]
		{
			65,
			69,
			83,
			86,
			51
		};

		// Token: 0x0400254F RID: 9551
		private new static byte[] c = new byte[]
		{
			69,
			70,
			70
		};

		// Token: 0x04002550 RID: 9552
		private new static byte[] d = new byte[]
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

		// Token: 0x04002551 RID: 9553
		private new Random e = new Random();

		// Token: 0x04002552 RID: 9554
		private new EncryptDocumentComponents f = EncryptDocumentComponents.All;
	}
}
