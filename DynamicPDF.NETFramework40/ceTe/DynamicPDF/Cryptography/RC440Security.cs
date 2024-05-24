using System;
using System.Security.Cryptography;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Cryptography
{
	// Token: 0x020006C8 RID: 1736
	public class RC440Security : Security
	{
		// Token: 0x06004314 RID: 17172 RVA: 0x0022E429 File Offset: 0x0022D429
		public RC440Security()
		{
		}

		// Token: 0x06004315 RID: 17173 RVA: 0x0022E434 File Offset: 0x0022D434
		public RC440Security(string ownerPassword, string userPassword) : base(ownerPassword, userPassword)
		{
		}

		// Token: 0x06004316 RID: 17174 RVA: 0x0022E441 File Offset: 0x0022D441
		public RC440Security(string password) : base(password)
		{
		}

		// Token: 0x06004317 RID: 17175 RVA: 0x0022E450 File Offset: 0x0022D450
		internal override PdfVersion u()
		{
			return PdfVersion.v1_4;
		}

		// Token: 0x06004318 RID: 17176 RVA: 0x0022E464 File Offset: 0x0022D464
		internal override b5 a()
		{
			return b5.a;
		}

		// Token: 0x06004319 RID: 17177 RVA: 0x0022E478 File Offset: 0x0022D478
		public override Encrypter GetEncrypter(byte[] id)
		{
			MD5 a_ = new MD5CryptoServiceProvider();
			byte[] user = new byte[32];
			byte[] array = new byte[5];
			int num = this.b();
			byte[] array2 = this.a(a_);
			array = this.a(a_, id, array2, num);
			user = this.a(array);
			return new Encrypter(array2, user, array, num);
		}

		// Token: 0x0600431A RID: 17178 RVA: 0x0022E4D4 File Offset: 0x0022D4D4
		public override void Draw(DocumentWriter writer, Encrypter encrypter)
		{
			writer.WriteDictionaryOpen();
			writer.WriteName(Security.c);
			writer.WriteName(Security.d);
			writer.WriteName(82);
			writer.WriteNumber(2);
			writer.WriteName(86);
			writer.WriteNumber1();
			writer.WriteName(Security.e);
			writer.WriteNumber(40);
			encrypter.Draw(writer);
			writer.WriteDictionaryClose();
		}

		// Token: 0x0600431B RID: 17179 RVA: 0x0022E548 File Offset: 0x0022D548
		private byte[] a(MD5 A_0)
		{
			byte[] array = new byte[5];
			byte[] buffer = base.BinPassword(base.OwnerPassword);
			byte[] sourceArray = A_0.ComputeHash(buffer);
			Array.Copy(sourceArray, array, 5);
			byte[] array2 = base.BinPassword(base.UserPassword);
			RC440Security.a.a(array2, array);
			return array2;
		}

		// Token: 0x0600431C RID: 17180 RVA: 0x0022E59C File Offset: 0x0022D59C
		private byte[] a(byte[] A_0)
		{
			byte[] array = new byte[32];
			Security.Filler.CopyTo(array, 0);
			RC440Security.a.a(array, A_0);
			return array;
		}

		// Token: 0x0600431D RID: 17181 RVA: 0x0022E5D4 File Offset: 0x0022D5D4
		private byte[] a(MD5 A_0, byte[] A_1, byte[] A_2, int A_3)
		{
			byte[] array = new byte[5];
			byte[] array2 = new byte[84];
			Array.Copy(base.BinPassword(base.UserPassword), 0, array2, 0, 32);
			Array.Copy(A_2, 0, array2, 32, 32);
			Array.Copy(BitConverter.GetBytes(A_3), 0, array2, 64, 4);
			Array.Copy(A_1, 0, array2, 68, 16);
			Array.Copy(A_0.ComputeHash(array2), 0, array, 0, 5);
			return array;
		}

		// Token: 0x0600431E RID: 17182 RVA: 0x0022E64C File Offset: 0x0022D64C
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
			return num;
		}

		// Token: 0x04002557 RID: 9559
		private static yw a = new yw();
	}
}
