using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006EF RID: 1775
	public class ImportedDestination : Action
	{
		// Token: 0x06004469 RID: 17513 RVA: 0x00234A2C File Offset: 0x00233A2C
		private ImportedDestination()
		{
		}

		// Token: 0x0600446A RID: 17514 RVA: 0x00234A37 File Offset: 0x00233A37
		internal ImportedDestination(abd A_0)
		{
			this.b = A_0;
			base.a(237062808);
		}

		// Token: 0x0600446B RID: 17515 RVA: 0x00234A55 File Offset: 0x00233A55
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteName(ImportedDestination.a);
			this.b.hz(writer);
		}

		// Token: 0x04002634 RID: 9780
		private new static byte[] a = new byte[]
		{
			68,
			101,
			115,
			116
		};

		// Token: 0x04002635 RID: 9781
		private new abd b;
	}
}
