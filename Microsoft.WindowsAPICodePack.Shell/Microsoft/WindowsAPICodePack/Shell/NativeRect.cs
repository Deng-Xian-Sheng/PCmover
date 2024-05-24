using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000006 RID: 6
	public struct NativeRect
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000022D4 File Offset: 0x000004D4
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000022EB File Offset: 0x000004EB
		public int Left { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000022F4 File Offset: 0x000004F4
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000230B File Offset: 0x0000050B
		public int Top { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002314 File Offset: 0x00000514
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000232B File Offset: 0x0000052B
		public int Right { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002334 File Offset: 0x00000534
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000234B File Offset: 0x0000054B
		public int Bottom { get; set; }

		// Token: 0x0600001E RID: 30 RVA: 0x00002354 File Offset: 0x00000554
		public NativeRect(int left, int top, int right, int bottom)
		{
			this = default(NativeRect);
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002380 File Offset: 0x00000580
		public static bool operator ==(NativeRect first, NativeRect second)
		{
			return first.Left == second.Left && first.Top == second.Top && first.Right == second.Right && first.Bottom == second.Bottom;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000023D8 File Offset: 0x000005D8
		public static bool operator !=(NativeRect first, NativeRect second)
		{
			return !(first == second);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000023F4 File Offset: 0x000005F4
		public override bool Equals(object obj)
		{
			return obj != null && obj is NativeRect && this == (NativeRect)obj;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002428 File Offset: 0x00000628
		public override int GetHashCode()
		{
			int num = this.Left.GetHashCode();
			num = num * 31 + this.Top.GetHashCode();
			num = num * 31 + this.Right.GetHashCode();
			return num * 31 + this.Bottom.GetHashCode();
		}
	}
}
