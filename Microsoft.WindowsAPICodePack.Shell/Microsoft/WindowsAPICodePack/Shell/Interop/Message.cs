using System;

namespace Microsoft.WindowsAPICodePack.Shell.Interop
{
	// Token: 0x02000040 RID: 64
	public struct Message
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0000A8C4 File Offset: 0x00008AC4
		public IntPtr WindowHandle
		{
			get
			{
				return this.windowHandle;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000265 RID: 613 RVA: 0x0000A8DC File Offset: 0x00008ADC
		public uint Msg
		{
			get
			{
				return this.msg;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000A8F4 File Offset: 0x00008AF4
		public IntPtr WParam
		{
			get
			{
				return this.wparam;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000A90C File Offset: 0x00008B0C
		public IntPtr LParam
		{
			get
			{
				return this.lparam;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000268 RID: 616 RVA: 0x0000A924 File Offset: 0x00008B24
		public int Time
		{
			get
			{
				return this.time;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000A93C File Offset: 0x00008B3C
		public NativePoint Point
		{
			get
			{
				return this.point;
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000A954 File Offset: 0x00008B54
		internal Message(IntPtr windowHandle, uint msg, IntPtr wparam, IntPtr lparam, int time, NativePoint point)
		{
			this = default(Message);
			this.windowHandle = windowHandle;
			this.msg = msg;
			this.wparam = wparam;
			this.lparam = lparam;
			this.time = time;
			this.point = point;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000A98C File Offset: 0x00008B8C
		public static bool operator ==(Message first, Message second)
		{
			return first.WindowHandle == second.WindowHandle && first.Msg == second.Msg && first.WParam == second.WParam && first.LParam == second.LParam && first.Time == second.Time && first.Point == second.Point;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000AA14 File Offset: 0x00008C14
		public static bool operator !=(Message first, Message second)
		{
			return !(first == second);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000AA30 File Offset: 0x00008C30
		public override bool Equals(object obj)
		{
			return obj != null && obj is Message && this == (Message)obj;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000AA64 File Offset: 0x00008C64
		public override int GetHashCode()
		{
			int num = this.WindowHandle.GetHashCode();
			num = num * 31 + this.Msg.GetHashCode();
			num = num * 31 + this.WParam.GetHashCode();
			num = num * 31 + this.LParam.GetHashCode();
			num = num * 31 + this.Time.GetHashCode();
			return num * 31 + this.Point.GetHashCode();
		}

		// Token: 0x040000F5 RID: 245
		private IntPtr windowHandle;

		// Token: 0x040000F6 RID: 246
		private uint msg;

		// Token: 0x040000F7 RID: 247
		private IntPtr wparam;

		// Token: 0x040000F8 RID: 248
		private IntPtr lparam;

		// Token: 0x040000F9 RID: 249
		private int time;

		// Token: 0x040000FA RID: 250
		private NativePoint point;
	}
}
