using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003AF RID: 943
	internal class yp : ye
	{
		// Token: 0x0600280E RID: 10254 RVA: 0x00171F7A File Offset: 0x00170F7A
		internal yp(Stream A_0) : base(A_0)
		{
		}

		// Token: 0x0600280F RID: 10255 RVA: 0x00171F88 File Offset: 0x00170F88
		internal override ushort gt(uint A_0)
		{
			base.a(A_0);
			return (ushort)(base.a().ReadByte() | base.a().ReadByte() << 8);
		}

		// Token: 0x06002810 RID: 10256 RVA: 0x00171FBC File Offset: 0x00170FBC
		internal override uint gu(uint A_0)
		{
			base.a(A_0);
			return (uint)(base.a().ReadByte() | base.a().ReadByte() << 8 | base.a().ReadByte() << 16 | base.a().ReadByte() << 24);
		}

		// Token: 0x06002811 RID: 10257 RVA: 0x00172010 File Offset: 0x00171010
		internal override ushort gv(byte[] A_0, uint A_1)
		{
			return (ushort)((int)A_0[(int)((UIntPtr)(A_1++))] | (int)A_0[(int)((UIntPtr)A_1)] << 8);
		}

		// Token: 0x06002812 RID: 10258 RVA: 0x00172034 File Offset: 0x00171034
		internal override uint gw(byte[] A_0, uint A_1)
		{
			return (uint)((int)A_0[(int)((UIntPtr)(A_1++))] | (int)A_0[(int)((UIntPtr)(A_1++))] << 8 | (int)A_0[(int)((UIntPtr)(A_1++))] << 16 | (int)A_0[(int)((UIntPtr)A_1)] << 24);
		}
	}
}
