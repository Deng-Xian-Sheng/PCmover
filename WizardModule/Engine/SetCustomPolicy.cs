using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PCmover.Infrastructure;

namespace WizardModule.Engine
{
	// Token: 0x020000C0 RID: 192
	public static class SetCustomPolicy
	{
		// Token: 0x0600102E RID: 4142 RVA: 0x00029A6C File Offset: 0x00027C6C
		private static Task<FolderDetail> GetFolderDetailAsync(List<FolderDetail> folders, string requestedPath)
		{
			SetCustomPolicy.<GetFolderDetailAsync>d__0 <GetFolderDetailAsync>d__;
			<GetFolderDetailAsync>d__.<>t__builder = AsyncTaskMethodBuilder<FolderDetail>.Create();
			<GetFolderDetailAsync>d__.folders = folders;
			<GetFolderDetailAsync>d__.requestedPath = requestedPath;
			<GetFolderDetailAsync>d__.<>1__state = -1;
			<GetFolderDetailAsync>d__.<>t__builder.Start<SetCustomPolicy.<GetFolderDetailAsync>d__0>(ref <GetFolderDetailAsync>d__);
			return <GetFolderDetailAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00029AB8 File Offset: 0x00027CB8
		private static Task<FileDetail> GetFileDetailAsync(List<FolderDetail> folders, string path)
		{
			SetCustomPolicy.<GetFileDetailAsync>d__1 <GetFileDetailAsync>d__;
			<GetFileDetailAsync>d__.<>t__builder = AsyncTaskMethodBuilder<FileDetail>.Create();
			<GetFileDetailAsync>d__.folders = folders;
			<GetFileDetailAsync>d__.path = path;
			<GetFileDetailAsync>d__.<>1__state = -1;
			<GetFileDetailAsync>d__.<>t__builder.Start<SetCustomPolicy.<GetFileDetailAsync>d__1>(ref <GetFileDetailAsync>d__);
			return <GetFileDetailAsync>d__.<>t__builder.Task;
		}
	}
}
