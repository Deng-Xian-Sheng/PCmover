using System;
using System.Collections;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020006D5 RID: 1749
	public class TextFieldList : IEnumerable
	{
		// Token: 0x0600438A RID: 17290 RVA: 0x002300CF File Offset: 0x0022F0CF
		internal TextFieldList(Form A_0)
		{
			this.a(A_0.Fields);
		}

		// Token: 0x0600438B RID: 17291 RVA: 0x002300F2 File Offset: 0x0022F0F2
		internal TextFieldList(FormFieldList A_0)
		{
			this.a(A_0);
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x0600438C RID: 17292 RVA: 0x00230110 File Offset: 0x0022F110
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x17000383 RID: 899
		public TextField this[int index]
		{
			get
			{
				return (TextField)this.a[index];
			}
		}

		// Token: 0x0600438E RID: 17294 RVA: 0x00230154 File Offset: 0x0022F154
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x0600438F RID: 17295 RVA: 0x00230174 File Offset: 0x0022F174
		private void a(FormFieldList A_0)
		{
			for (int i = 0; i < A_0.Count; i++)
			{
				if (A_0[i] is TextField && !A_0[i].InheritsName)
				{
					this.a.Add(A_0[i]);
				}
				if (A_0[i].HasChildFields)
				{
					this.a(A_0[i].ChildFields);
				}
			}
		}

		// Token: 0x040025A7 RID: 9639
		private ArrayList a = new ArrayList();
	}
}
