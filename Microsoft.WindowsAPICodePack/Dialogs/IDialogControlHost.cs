using System;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200000E RID: 14
	public interface IDialogControlHost
	{
		// Token: 0x06000037 RID: 55
		bool IsCollectionChangeAllowed();

		// Token: 0x06000038 RID: 56
		void ApplyCollectionChanged();

		// Token: 0x06000039 RID: 57
		bool IsControlPropertyChangeAllowed(string propertyName, DialogControl control);

		// Token: 0x0600003A RID: 58
		void ApplyControlPropertyChange(string propertyName, DialogControl control);
	}
}
