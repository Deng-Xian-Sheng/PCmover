using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x02000066 RID: 102
	[StructLayout(LayoutKind.Explicit)]
	internal class PROPVARIANT : IDisposable
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0000880D File Offset: 0x00006A0D
		public VarEnum VarType
		{
			get
			{
				return (VarEnum)this.vt;
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008815 File Offset: 0x00006A15
		public string GetValue()
		{
			if (this.vt == 31)
			{
				return Marshal.PtrToStringUni(this.pointerVal);
			}
			return null;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000882E File Offset: 0x00006A2E
		public void SetValue(bool f)
		{
			this.Clear();
			this.vt = 11;
			this.boolVal = (f ? -1 : 0);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000884C File Offset: 0x00006A4C
		public void SetValue(string val)
		{
			this.Clear();
			this.vt = 31;
			this.pointerVal = Marshal.StringToCoTaskMemUni(val);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00008868 File Offset: 0x00006A68
		public void Clear()
		{
			PROPVARIANT.NativeMethods.PropVariantClear(this);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008871 File Offset: 0x00006A71
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00008880 File Offset: 0x00006A80
		~PROPVARIANT()
		{
			this.Dispose(false);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000088B0 File Offset: 0x00006AB0
		private void Dispose(bool disposing)
		{
			this.Clear();
		}

		// Token: 0x0400054B RID: 1355
		[FieldOffset(0)]
		private ushort vt;

		// Token: 0x0400054C RID: 1356
		[FieldOffset(8)]
		private IntPtr pointerVal;

		// Token: 0x0400054D RID: 1357
		[FieldOffset(8)]
		private byte byteVal;

		// Token: 0x0400054E RID: 1358
		[FieldOffset(8)]
		private long longVal;

		// Token: 0x0400054F RID: 1359
		[FieldOffset(8)]
		private short boolVal;

		// Token: 0x020000D3 RID: 211
		private static class NativeMethods
		{
			// Token: 0x0600044D RID: 1101
			[DllImport("ole32.dll")]
			internal static extern HRESULT PropVariantClear(PROPVARIANT pvar);
		}
	}
}
