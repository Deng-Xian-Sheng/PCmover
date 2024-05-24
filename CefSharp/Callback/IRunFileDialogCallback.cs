using System;
using System.Collections.Generic;

namespace CefSharp.Callback
{
	// Token: 0x02000454 RID: 1108
	public interface IRunFileDialogCallback
	{
		// Token: 0x06002010 RID: 8208
		void OnFileDialogDismissed(int selectedAcceptFilter, IList<string> filePaths);
	}
}
