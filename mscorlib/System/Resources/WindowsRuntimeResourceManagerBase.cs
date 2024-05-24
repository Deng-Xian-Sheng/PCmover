using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Resources
{
	// Token: 0x02000394 RID: 916
	[FriendAccessAllowed]
	[SecurityCritical]
	internal class WindowsRuntimeResourceManagerBase
	{
		// Token: 0x06002D0F RID: 11535 RVA: 0x000AA285 File Offset: 0x000A8485
		[SecurityCritical]
		public virtual bool Initialize(string libpath, string reswFilename, out PRIExceptionInfo exceptionInfo)
		{
			exceptionInfo = null;
			return false;
		}

		// Token: 0x06002D10 RID: 11536 RVA: 0x000AA28B File Offset: 0x000A848B
		[SecurityCritical]
		public virtual string GetString(string stringName, string startingCulture, string neutralResourcesCulture)
		{
			return null;
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06002D11 RID: 11537 RVA: 0x000AA28E File Offset: 0x000A848E
		public virtual CultureInfo GlobalResourceContextBestFitCultureInfo
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x06002D12 RID: 11538 RVA: 0x000AA291 File Offset: 0x000A8491
		[SecurityCritical]
		public virtual bool SetGlobalResourceContextDefaultCulture(CultureInfo ci)
		{
			return false;
		}
	}
}
