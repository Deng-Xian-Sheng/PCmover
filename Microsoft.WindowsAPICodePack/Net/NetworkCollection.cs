using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.Net
{
	// Token: 0x02000034 RID: 52
	public class NetworkCollection : IEnumerable<Network>, IEnumerable
	{
		// Token: 0x060000EB RID: 235 RVA: 0x00003BB1 File Offset: 0x00001DB1
		internal NetworkCollection(IEnumerable networkEnumerable)
		{
			this.networkEnumerable = networkEnumerable;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003D5C File Offset: 0x00001F5C
		public IEnumerator<Network> GetEnumerator()
		{
			foreach (object obj in this.networkEnumerable)
			{
				INetwork network = (INetwork)obj;
				yield return new Network(network);
			}
			yield break;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003F14 File Offset: 0x00002114
		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (object obj in this.networkEnumerable)
			{
				INetwork network = (INetwork)obj;
				yield return new Network(network);
			}
			yield break;
		}

		// Token: 0x04000204 RID: 516
		private IEnumerable networkEnumerable;
	}
}
