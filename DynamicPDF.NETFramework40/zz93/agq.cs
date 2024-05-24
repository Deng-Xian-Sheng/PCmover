using System;
using System.IO;

namespace zz93
{
	// Token: 0x020004E1 RID: 1249
	internal class agq : agp
	{
		// Token: 0x060032E4 RID: 13028 RVA: 0x001C52BE File Offset: 0x001C42BE
		internal agq(FileInfo A_0) : base(A_0.Length)
		{
			this.a = A_0;
		}

		// Token: 0x060032E5 RID: 13029 RVA: 0x001C52D8 File Offset: 0x001C42D8
		internal override void k9()
		{
			if (this.b == null)
			{
				this.b = new FileStream(this.a.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
				base.a(this.b);
			}
		}

		// Token: 0x060032E6 RID: 13030 RVA: 0x001C531C File Offset: 0x001C431C
		internal override void la()
		{
			if (this.b != null)
			{
				FileStream fileStream = this.b;
				base.e();
				this.b = null;
				fileStream.Close();
			}
		}

		// Token: 0x04001862 RID: 6242
		private new FileInfo a;

		// Token: 0x04001863 RID: 6243
		private new FileStream b;
	}
}
