using System;
using System.Windows.Markup;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
	// Token: 0x0200007B RID: 123
	[ContentProperty("Items")]
	public abstract class CommonFileDialogProminentControl : CommonFileDialogControl
	{
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00010A5C File Offset: 0x0000EC5C
		// (set) Token: 0x06000449 RID: 1097 RVA: 0x00010A74 File Offset: 0x0000EC74
		public bool IsProminent
		{
			get
			{
				return this.isProminent;
			}
			set
			{
				this.isProminent = value;
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00010A7E File Offset: 0x0000EC7E
		protected CommonFileDialogProminentControl()
		{
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00010A89 File Offset: 0x0000EC89
		protected CommonFileDialogProminentControl(string text) : base(text)
		{
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00010A95 File Offset: 0x0000EC95
		protected CommonFileDialogProminentControl(string name, string text) : base(name, text)
		{
		}

		// Token: 0x040002D5 RID: 725
		private bool isProminent;
	}
}
