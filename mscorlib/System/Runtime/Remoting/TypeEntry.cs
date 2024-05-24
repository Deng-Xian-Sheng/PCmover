using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting
{
	// Token: 0x020007BF RID: 1983
	[ComVisible(true)]
	public class TypeEntry
	{
		// Token: 0x060055E8 RID: 21992 RVA: 0x00130EC0 File Offset: 0x0012F0C0
		protected TypeEntry()
		{
		}

		// Token: 0x17000E29 RID: 3625
		// (get) Token: 0x060055E9 RID: 21993 RVA: 0x00130EC8 File Offset: 0x0012F0C8
		// (set) Token: 0x060055EA RID: 21994 RVA: 0x00130ED0 File Offset: 0x0012F0D0
		public string TypeName
		{
			get
			{
				return this._typeName;
			}
			set
			{
				this._typeName = value;
			}
		}

		// Token: 0x17000E2A RID: 3626
		// (get) Token: 0x060055EB RID: 21995 RVA: 0x00130ED9 File Offset: 0x0012F0D9
		// (set) Token: 0x060055EC RID: 21996 RVA: 0x00130EE1 File Offset: 0x0012F0E1
		public string AssemblyName
		{
			get
			{
				return this._assemblyName;
			}
			set
			{
				this._assemblyName = value;
			}
		}

		// Token: 0x060055ED RID: 21997 RVA: 0x00130EEA File Offset: 0x0012F0EA
		internal void CacheRemoteAppEntry(RemoteAppEntry entry)
		{
			this._cachedRemoteAppEntry = entry;
		}

		// Token: 0x060055EE RID: 21998 RVA: 0x00130EF3 File Offset: 0x0012F0F3
		internal RemoteAppEntry GetRemoteAppEntry()
		{
			return this._cachedRemoteAppEntry;
		}

		// Token: 0x04002776 RID: 10102
		private string _typeName;

		// Token: 0x04002777 RID: 10103
		private string _assemblyName;

		// Token: 0x04002778 RID: 10104
		private RemoteAppEntry _cachedRemoteAppEntry;
	}
}
