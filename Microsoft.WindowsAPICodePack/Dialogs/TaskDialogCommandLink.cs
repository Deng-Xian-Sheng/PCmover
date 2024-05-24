using System;
using System.Globalization;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000054 RID: 84
	public class TaskDialogCommandLink : TaskDialogButton
	{
		// Token: 0x06000263 RID: 611 RVA: 0x00008C0A File Offset: 0x00006E0A
		public TaskDialogCommandLink()
		{
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00008C15 File Offset: 0x00006E15
		public TaskDialogCommandLink(string name, string text) : base(name, text)
		{
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00008C22 File Offset: 0x00006E22
		public TaskDialogCommandLink(string name, string text, string instruction) : base(name, text)
		{
			this.instruction = instruction;
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00008C38 File Offset: 0x00006E38
		// (set) Token: 0x06000267 RID: 615 RVA: 0x00008C50 File Offset: 0x00006E50
		public string Instruction
		{
			get
			{
				return this.instruction;
			}
			set
			{
				this.instruction = value;
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00008C5C File Offset: 0x00006E5C
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}", new object[]
			{
				base.Text ?? string.Empty,
				(!string.IsNullOrEmpty(base.Text) && !string.IsNullOrEmpty(this.instruction)) ? Environment.NewLine : string.Empty,
				this.instruction ?? string.Empty
			});
		}

		// Token: 0x04000294 RID: 660
		private string instruction;
	}
}
