using System;
using System.Collections.Generic;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x02000009 RID: 9
	public class ComputersInfo
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002808 File Offset: 0x00000A08
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002810 File Offset: 0x00000A10
		public List<ConnectableMachine> ConnectableMachines { get; private set; }

		// Token: 0x06000041 RID: 65 RVA: 0x0000281C File Offset: 0x00000A1C
		public ComputersInfo(string FirstPCName, string SecondPCName, string NetworkName, bool IsFirstPCOld, bool IsFirstPCFound)
		{
			this.ConnectableMachines = new List<ConnectableMachine>();
			ConnectableMachine connectableMachine = new ConnectableMachine();
			connectableMachine.FriendlyName = SecondPCName;
			this.ConnectableMachines.Add(connectableMachine);
		}
	}
}
