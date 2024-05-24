using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x020000A0 RID: 160
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct PKEY
	{
		// Token: 0x0600028A RID: 650 RVA: 0x00009822 File Offset: 0x00007A22
		public PKEY(Guid fmtid, uint pid)
		{
			this._fmtid = fmtid;
			this._pid = pid;
		}

		// Token: 0x040006AC RID: 1708
		private readonly Guid _fmtid;

		// Token: 0x040006AD RID: 1709
		private readonly uint _pid;

		// Token: 0x040006AE RID: 1710
		public static readonly PKEY Title = new PKEY(new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9"), 2U);

		// Token: 0x040006AF RID: 1711
		public static readonly PKEY AppUserModel_ID = new PKEY(new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3"), 5U);

		// Token: 0x040006B0 RID: 1712
		public static readonly PKEY AppUserModel_IsDestListSeparator = new PKEY(new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3"), 6U);

		// Token: 0x040006B1 RID: 1713
		public static readonly PKEY AppUserModel_RelaunchCommand = new PKEY(new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3"), 2U);

		// Token: 0x040006B2 RID: 1714
		public static readonly PKEY AppUserModel_RelaunchDisplayNameResource = new PKEY(new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3"), 4U);

		// Token: 0x040006B3 RID: 1715
		public static readonly PKEY AppUserModel_RelaunchIconResource = new PKEY(new Guid("9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3"), 3U);
	}
}
