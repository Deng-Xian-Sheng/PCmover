using System;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020006CF RID: 1743
	public class FormEventArgs : EventArgs
	{
		// Token: 0x06004376 RID: 17270 RVA: 0x0022FB30 File Offset: 0x0022EB30
		internal FormEventArgs(Form A_0)
		{
			this.a = A_0;
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06004377 RID: 17271 RVA: 0x0022FB44 File Offset: 0x0022EB44
		public Form Form
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x04002585 RID: 9605
		private Form a;
	}
}
