using System;
using System.IO;

namespace zz93
{
	// Token: 0x020004DB RID: 1243
	internal class agk : IDisposable
	{
		// Token: 0x060032B3 RID: 12979 RVA: 0x001C4648 File Offset: 0x001C3648
		internal agk(string A_0)
		{
			this.a = Path.Combine(A_0, "~" + Guid.NewGuid().ToString() + ".dptmp");
		}

		// Token: 0x060032B4 RID: 12980 RVA: 0x001C469C File Offset: 0x001C369C
		~agk()
		{
			this.a(false);
		}

		// Token: 0x060032B5 RID: 12981 RVA: 0x001C46D0 File Offset: 0x001C36D0
		internal long b()
		{
			if (this.b == null)
			{
				this.a();
			}
			return this.b.Length;
		}

		// Token: 0x060032B6 RID: 12982 RVA: 0x001C4704 File Offset: 0x001C3704
		private void a()
		{
			this.b = File.Create(this.a, 4096, FileOptions.DeleteOnClose);
		}

		// Token: 0x060032B7 RID: 12983 RVA: 0x001C4722 File Offset: 0x001C3722
		internal void a(byte[] A_0)
		{
			this.a(A_0, 0, A_0.Length);
		}

		// Token: 0x060032B8 RID: 12984 RVA: 0x001C4731 File Offset: 0x001C3731
		internal void a(byte[] A_0, int A_1)
		{
			this.a(A_0, 0, A_1);
		}

		// Token: 0x060032B9 RID: 12985 RVA: 0x001C4740 File Offset: 0x001C3740
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			if (this.b == null)
			{
				this.a();
			}
			else if (this.b.Length != this.b.Position)
			{
				this.b.Seek(this.b.Length, SeekOrigin.Begin);
			}
			this.b.Write(A_0, A_1, A_2);
		}

		// Token: 0x060032BA RID: 12986 RVA: 0x001C47B0 File Offset: 0x001C37B0
		internal byte[] a(long A_0, int A_1)
		{
			if (this.b.Position != A_0)
			{
				this.b.Seek(A_0, SeekOrigin.Begin);
			}
			byte[] array = new byte[A_1];
			this.b.Read(array, 0, A_1);
			return array;
		}

		// Token: 0x060032BB RID: 12987 RVA: 0x001C47FC File Offset: 0x001C37FC
		internal void a(long A_0, int A_1, byte[] A_2, int A_3)
		{
			if (this.b.Position != A_0)
			{
				this.b.Seek(A_0, SeekOrigin.Begin);
			}
			this.b.Read(A_2, A_3, A_1);
		}

		// Token: 0x060032BC RID: 12988 RVA: 0x001C483C File Offset: 0x001C383C
		public void Dispose()
		{
			this.a(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060032BD RID: 12989 RVA: 0x001C4850 File Offset: 0x001C3850
		protected virtual void a(bool A_0)
		{
			if (!this.c)
			{
				if (A_0)
				{
					this.b.Dispose();
				}
				if (File.Exists(this.a))
				{
					this.b.Close();
					File.Delete(this.a);
				}
				this.c = true;
			}
		}

		// Token: 0x0400184C RID: 6220
		private string a;

		// Token: 0x0400184D RID: 6221
		private FileStream b = null;

		// Token: 0x0400184E RID: 6222
		private bool c = false;
	}
}
