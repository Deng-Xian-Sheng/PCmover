using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020006CE RID: 1742
	public class FormCalculationOrder : IEnumerable
	{
		// Token: 0x0600436F RID: 17263 RVA: 0x0022FA14 File Offset: 0x0022EA14
		internal FormCalculationOrder()
		{
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06004370 RID: 17264 RVA: 0x0022FA2C File Offset: 0x0022EA2C
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x1700037C RID: 892
		public FormField this[int index]
		{
			get
			{
				return (FormField)this.a[index];
			}
		}

		// Token: 0x06004372 RID: 17266 RVA: 0x0022FA70 File Offset: 0x0022EA70
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x06004373 RID: 17267 RVA: 0x0022FA90 File Offset: 0x0022EA90
		public int Add(FormField formField)
		{
			return this.a.Add(formField);
		}

		// Token: 0x06004374 RID: 17268 RVA: 0x0022FAB0 File Offset: 0x0022EAB0
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteName(FormCalculationOrder.b);
			A_0.WriteArrayOpen();
			for (int i = 0; i < this.a.Count; i++)
			{
				A_0.WriteReference((Resource)this.a[i]);
			}
			A_0.WriteArrayClose();
		}

		// Token: 0x04002583 RID: 9603
		private ArrayList a = new ArrayList();

		// Token: 0x04002584 RID: 9604
		private static byte[] b = new byte[]
		{
			67,
			79
		};
	}
}
