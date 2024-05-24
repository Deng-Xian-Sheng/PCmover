using System;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A1 RID: 161
	public class CustomDialog : BaseMetroDialog
	{
		// Token: 0x060008CC RID: 2252 RVA: 0x00023390 File Offset: 0x00021590
		public CustomDialog() : this(null, null)
		{
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0002339A File Offset: 0x0002159A
		public CustomDialog(MetroWindow parentWindow) : this(parentWindow, null)
		{
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x000233A4 File Offset: 0x000215A4
		public CustomDialog(MetroDialogSettings settings) : this(null, settings)
		{
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x000233AE File Offset: 0x000215AE
		public CustomDialog(MetroWindow parentWindow, MetroDialogSettings settings) : base(parentWindow, settings)
		{
		}
	}
}
