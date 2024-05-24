using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x02000036 RID: 54
	public class NetworkConnectionCollection : IEnumerable<NetworkConnection>, IEnumerable
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00004029 File Offset: 0x00002229
		internal NetworkConnectionCollection(IEnumerable networkConnectionEnumerable)
		{
			this.networkConnectionEnumerable = networkConnectionEnumerable;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000041D4 File Offset: 0x000023D4
		public IEnumerator<NetworkConnection> GetEnumerator()
		{
			foreach (object obj in this.networkConnectionEnumerable)
			{
				INetworkConnection networkConnection = (INetworkConnection)obj;
				yield return new NetworkConnection(networkConnection);
			}
			yield break;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000438C File Offset: 0x0000258C
		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (object obj in this.networkConnectionEnumerable)
			{
				INetworkConnection networkConnection = (INetworkConnection)obj;
				yield return new NetworkConnection(networkConnection);
			}
			yield break;
		}

		// Token: 0x04000206 RID: 518
		private IEnumerable networkConnectionEnumerable;
	}
}
