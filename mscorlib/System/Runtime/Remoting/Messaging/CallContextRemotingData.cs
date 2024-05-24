using System;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200088F RID: 2191
	[Serializable]
	internal class CallContextRemotingData : ICloneable
	{
		// Token: 0x17000FF9 RID: 4089
		// (get) Token: 0x06005CDB RID: 23771 RVA: 0x00145880 File Offset: 0x00143A80
		// (set) Token: 0x06005CDC RID: 23772 RVA: 0x00145888 File Offset: 0x00143A88
		internal string LogicalCallID
		{
			get
			{
				return this._logicalCallID;
			}
			set
			{
				this._logicalCallID = value;
			}
		}

		// Token: 0x17000FFA RID: 4090
		// (get) Token: 0x06005CDD RID: 23773 RVA: 0x00145891 File Offset: 0x00143A91
		internal bool HasInfo
		{
			get
			{
				return this._logicalCallID != null;
			}
		}

		// Token: 0x06005CDE RID: 23774 RVA: 0x0014589C File Offset: 0x00143A9C
		public object Clone()
		{
			return new CallContextRemotingData
			{
				LogicalCallID = this.LogicalCallID
			};
		}

		// Token: 0x040029DC RID: 10716
		private string _logicalCallID;
	}
}
