using System;
using System.Security.Cryptography;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Cryptography
{
	// Token: 0x020006C9 RID: 1737
	public class RC4128Security : Security
	{
		// Token: 0x06004320 RID: 17184 RVA: 0x0022E6AA File Offset: 0x0022D6AA
		public RC4128Security()
		{
		}

		// Token: 0x06004321 RID: 17185 RVA: 0x0022E6B5 File Offset: 0x0022D6B5
		public RC4128Security(string ownerPassword, string userPassword) : base(ownerPassword, userPassword)
		{
		}

		// Token: 0x06004322 RID: 17186 RVA: 0x0022E6C2 File Offset: 0x0022D6C2
		public RC4128Security(string password) : base(password)
		{
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06004324 RID: 17188 RVA: 0x0022E6DC File Offset: 0x0022D6DC
		// (set) Token: 0x06004323 RID: 17187 RVA: 0x0022E6CE File Offset: 0x0022D6CE
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

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06004326 RID: 17190 RVA: 0x0022E700 File Offset: 0x0022D700
		// (set) Token: 0x06004325 RID: 17189 RVA: 0x0022E6F4 File Offset: 0x0022D6F4
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

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06004328 RID: 17192 RVA: 0x0022E724 File Offset: 0x0022D724
		// (set) Token: 0x06004327 RID: 17191 RVA: 0x0022E718 File Offset: 0x0022D718
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

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x0600432A RID: 17194 RVA: 0x0022E748 File Offset: 0x0022D748
		// (set) Token: 0x06004329 RID: 17193 RVA: 0x0022E73C File Offset: 0x0022D73C
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

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x0600432C RID: 17196 RVA: 0x0022E76C File Offset: 0x0022D76C
		// (set) Token: 0x0600432B RID: 17195 RVA: 0x0022E760 File Offset: 0x0022D760
		public bool EncryptMetadata
		{
			get
			{
				return base.c();
			}
			set
			{
				base.a(value);
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x0600432E RID: 17198 RVA: 0x0022E790 File Offset: 0x0022D790
		// (set) Token: 0x0600432D RID: 17197 RVA: 0x0022E784 File Offset: 0x0022D784
		public bool UseCryptFilter
		{
			get
			{
				return base.e();
			}
			set
			{
				base.c(value);
			}
		}

		// Token: 0x0600432F RID: 17199 RVA: 0x0022E7A8 File Offset: 0x0022D7A8
		internal override PdfVersion u()
		{
			PdfVersion result;
			if (this.UseCryptFilter)
			{
				result = base.u();
			}
			else
			{
				result = PdfVersion.v1_4;
			}
			return result;
		}

		// Token: 0x06004330 RID: 17200 RVA: 0x0022E7D4 File Offset: 0x0022D7D4
		internal override b5 a()
		{
			return b5.a;
		}

		// Token: 0x06004331 RID: 17201 RVA: 0x0022E7E8 File Offset: 0x0022D7E8
		public override Encrypter GetEncrypter(byte[] id)
		{
			MD5 a_ = new MD5CryptoServiceProvider();
			byte[] user = new byte[32];
			byte[] array = new byte[5];
			int num = this.b();
			byte[] array2 = this.a(a_);
			array = this.a(a_, id, array2, num);
			user = this.a(a_, id, array);
			return new Encrypter(array2, user, array, num);
		}

		// Token: 0x06004332 RID: 17202 RVA: 0x0022E844 File Offset: 0x0022D844
		public override void Draw(DocumentWriter writer, Encrypter encrypter)
		{
			if (this.UseCryptFilter)
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
				writer.WriteName(Security.i);
				writer.WriteName(Security.j);
				writer.WriteName(RC4128Security.b);
				writer.WriteDictionaryClose();
				writer.WriteDictionaryClose();
				writer.WriteName(82);
				writer.WriteNumber(4);
				writer.WriteName(86);
				writer.WriteNumber(4);
				writer.WriteName(Security.e);
				writer.WriteNumber(128);
				writer.WriteName(Security.k);
				writer.WriteName(Security.g);
				writer.WriteName(Security.l);
				writer.WriteName(Security.g);
				if (!this.EncryptMetadata)
				{
					writer.WriteName(Security.m);
					writer.WriteBoolean(false);
				}
				encrypter.Draw(writer);
				writer.WriteDictionaryClose();
			}
			else
			{
				writer.WriteDictionaryOpen();
				writer.WriteName(Security.c);
				writer.WriteName(Security.d);
				writer.WriteName(82);
				writer.WriteNumber(3);
				writer.WriteName(86);
				writer.WriteNumber(2);
				writer.WriteName(Security.e);
				writer.WriteNumber(128);
				encrypter.Draw(writer);
				writer.WriteDictionaryClose();
			}
		}

		// Token: 0x06004333 RID: 17203 RVA: 0x0022EA04 File Offset: 0x0022DA04
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2)
		{
			byte[] array = new byte[32];
			byte[] array2 = new byte[48];
			Security.Filler.CopyTo(array2, 0);
			A_1.CopyTo(array2, 32);
			byte[] array3 = A_0.ComputeHash(array2);
			RC4128Security.a.a(array3, A_2);
			for (int i = 1; i < 20; i++)
			{
				byte[] a_ = this.a(A_2, (byte)i);
				RC4128Security.a.a(array3, a_);
			}
			Array.Copy(array3, 0, array, 0, 16);
			Array.Copy(Security.Filler, 0, array, 16, 16);
			return array;
		}

		// Token: 0x06004334 RID: 17204 RVA: 0x0022EAA4 File Offset: 0x0022DAA4
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2, int A_3)
		{
			byte[] result;
			if (this.UseCryptFilter)
			{
				byte[] array = new byte[16];
				byte[] array2;
				if (!this.EncryptMetadata)
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
				if (!this.EncryptMetadata)
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
				result = array;
			}
			else
			{
				byte[] array = new byte[16];
				byte[] array2 = new byte[84];
				Array.Copy(base.BinPassword(base.UserPassword), 0, array2, 0, 32);
				Array.Copy(A_2, 0, array2, 32, 32);
				Array.Copy(BitConverter.GetBytes(A_3), 0, array2, 64, 4);
				Array.Copy(A_1, 0, array2, 68, 16);
				byte[] array4 = A_0.ComputeHash(array2);
				for (int i = 0; i < 50; i++)
				{
					array4 = A_0.ComputeHash(array4);
				}
				Array.Copy(array4, 0, array, 0, 16);
				result = array;
			}
			return result;
		}

		// Token: 0x06004335 RID: 17205 RVA: 0x0022EC30 File Offset: 0x0022DC30
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

		// Token: 0x06004336 RID: 17206 RVA: 0x0022ECCC File Offset: 0x0022DCCC
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
			RC4128Security.a.a(array, array2);
			for (int i = 1; i < 20; i++)
			{
				byte[] a_ = this.a(array2, (byte)i);
				RC4128Security.a.a(array, a_);
			}
			return array;
		}

		// Token: 0x06004337 RID: 17207 RVA: 0x0022ED80 File Offset: 0x0022DD80
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

		// Token: 0x04002558 RID: 9560
		private static yw a = new yw();

		// Token: 0x04002559 RID: 9561
		private static byte[] b = new byte[]
		{
			86,
			50
		};
	}
}
