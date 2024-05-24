using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000005 RID: 5
	public struct NativePoint
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000021B9 File Offset: 0x000003B9
		public NativePoint(int x, int y)
		{
			this = default(NativePoint);
			this.X = x;
			this.Y = y;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000021D4 File Offset: 0x000003D4
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000021EB File Offset: 0x000003EB
		public int X { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000021F4 File Offset: 0x000003F4
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000220B File Offset: 0x0000040B
		public int Y { get; set; }

		// Token: 0x06000012 RID: 18 RVA: 0x00002214 File Offset: 0x00000414
		public static bool operator ==(NativePoint first, NativePoint second)
		{
			return first.X == second.X && first.Y == second.Y;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000224C File Offset: 0x0000044C
		public static bool operator !=(NativePoint first, NativePoint second)
		{
			return !(first == second);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002268 File Offset: 0x00000468
		public override bool Equals(object obj)
		{
			return obj != null && obj is NativePoint && this == (NativePoint)obj;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000229C File Offset: 0x0000049C
		public override int GetHashCode()
		{
			int hashCode = this.X.GetHashCode();
			return hashCode * 31 + this.Y.GetHashCode();
		}
	}
}
