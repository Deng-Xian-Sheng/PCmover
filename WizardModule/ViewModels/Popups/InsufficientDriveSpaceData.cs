using System;
using System.Collections.Generic;
using System.Threading;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A5 RID: 165
	public class InsufficientDriveSpaceData
	{
		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x00027118 File Offset: 0x00025318
		// (set) Token: 0x06000E94 RID: 3732 RVA: 0x00027120 File Offset: 0x00025320
		public AutoResetEvent ResetEvent { get; set; }

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x00027129 File Offset: 0x00025329
		// (set) Token: 0x06000E96 RID: 3734 RVA: 0x00027131 File Offset: 0x00025331
		public bool Customize { get; set; }

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06000E97 RID: 3735 RVA: 0x0002713A File Offset: 0x0002533A
		// (set) Token: 0x06000E98 RID: 3736 RVA: 0x00027142 File Offset: 0x00025342
		public IEnumerable<DriveSpaceAndNeeded> Drives { get; set; }

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06000E99 RID: 3737 RVA: 0x0002714B File Offset: 0x0002534B
		// (set) Token: 0x06000E9A RID: 3738 RVA: 0x00027153 File Offset: 0x00025353
		public TaskStats Stats { get; set; }
	}
}
