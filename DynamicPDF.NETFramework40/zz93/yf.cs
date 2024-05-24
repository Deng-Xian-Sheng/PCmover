using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003A5 RID: 933
	internal class yf : ye
	{
		// Token: 0x060027B2 RID: 10162 RVA: 0x0016BB3C File Offset: 0x0016AB3C
		internal yf(Stream A_0) : base(A_0)
		{
		}

		// Token: 0x060027B3 RID: 10163 RVA: 0x0016BB48 File Offset: 0x0016AB48
		internal override ushort gt(uint A_0)
		{
			base.a(A_0);
			return (ushort)(base.a().ReadByte() << 8 | base.a().ReadByte());
		}

		// Token: 0x060027B4 RID: 10164 RVA: 0x0016BB7C File Offset: 0x0016AB7C
		internal override uint gu(uint A_0)
		{
			base.a(A_0);
			return (uint)(base.a().ReadByte() << 24 | base.a().ReadByte() << 16 | base.a().ReadByte() << 8 | base.a().ReadByte());
		}

		// Token: 0x060027B5 RID: 10165 RVA: 0x0016BBD0 File Offset: 0x0016ABD0
		internal override ushort gv(byte[] A_0, uint A_1)
		{
			return (ushort)((int)A_0[(int)((UIntPtr)(A_1++))] << 8 | (int)A_0[(int)((UIntPtr)A_1)]);
		}

		// Token: 0x060027B6 RID: 10166 RVA: 0x0016BBF4 File Offset: 0x0016ABF4
		internal override uint gw(byte[] A_0, uint A_1)
		{
			return (uint)((int)A_0[(int)((UIntPtr)(A_1++))] << 24 | (int)A_0[(int)((UIntPtr)(A_1++))] << 16 | (int)A_0[(int)((UIntPtr)(A_1++))] << 8 | (int)A_0[(int)((UIntPtr)A_1)]);
		}
	}
}
