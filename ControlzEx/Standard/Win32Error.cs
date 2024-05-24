using System;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200001B RID: 27
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Explicit)]
	public struct Win32Error
	{
		// Token: 0x06000148 RID: 328 RVA: 0x000077CE File Offset: 0x000059CE
		public Win32Error(int i)
		{
			this._value = i;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000077D7 File Offset: 0x000059D7
		public static explicit operator HRESULT(Win32Error error)
		{
			if (error._value <= 0)
			{
				return new HRESULT((uint)error._value);
			}
			return HRESULT.Make(true, Facility.Win32, error._value & 65535);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00007801 File Offset: 0x00005A01
		public HRESULT ToHRESULT()
		{
			return (HRESULT)this;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000780E File Offset: 0x00005A0E
		public static Win32Error GetLastError()
		{
			return new Win32Error(Marshal.GetLastWin32Error());
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000781C File Offset: 0x00005A1C
		public override bool Equals(object obj)
		{
			bool result;
			try
			{
				result = (((Win32Error)obj)._value == this._value);
			}
			catch (InvalidCastException)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00007858 File Offset: 0x00005A58
		public override int GetHashCode()
		{
			return this._value.GetHashCode();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00007873 File Offset: 0x00005A73
		public static bool operator ==(Win32Error errLeft, Win32Error errRight)
		{
			return errLeft._value == errRight._value;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007883 File Offset: 0x00005A83
		public static bool operator !=(Win32Error errLeft, Win32Error errRight)
		{
			return !(errLeft == errRight);
		}

		// Token: 0x040000CB RID: 203
		[FieldOffset(0)]
		private readonly int _value;

		// Token: 0x040000CC RID: 204
		public static readonly Win32Error ERROR_SUCCESS = new Win32Error(0);

		// Token: 0x040000CD RID: 205
		public static readonly Win32Error ERROR_INVALID_FUNCTION = new Win32Error(1);

		// Token: 0x040000CE RID: 206
		public static readonly Win32Error ERROR_FILE_NOT_FOUND = new Win32Error(2);

		// Token: 0x040000CF RID: 207
		public static readonly Win32Error ERROR_PATH_NOT_FOUND = new Win32Error(3);

		// Token: 0x040000D0 RID: 208
		public static readonly Win32Error ERROR_TOO_MANY_OPEN_FILES = new Win32Error(4);

		// Token: 0x040000D1 RID: 209
		public static readonly Win32Error ERROR_ACCESS_DENIED = new Win32Error(5);

		// Token: 0x040000D2 RID: 210
		public static readonly Win32Error ERROR_INVALID_HANDLE = new Win32Error(6);

		// Token: 0x040000D3 RID: 211
		public static readonly Win32Error ERROR_OUTOFMEMORY = new Win32Error(14);

		// Token: 0x040000D4 RID: 212
		public static readonly Win32Error ERROR_NO_MORE_FILES = new Win32Error(18);

		// Token: 0x040000D5 RID: 213
		public static readonly Win32Error ERROR_SHARING_VIOLATION = new Win32Error(32);

		// Token: 0x040000D6 RID: 214
		public static readonly Win32Error ERROR_INVALID_PARAMETER = new Win32Error(87);

		// Token: 0x040000D7 RID: 215
		public static readonly Win32Error ERROR_INSUFFICIENT_BUFFER = new Win32Error(122);

		// Token: 0x040000D8 RID: 216
		public static readonly Win32Error ERROR_NESTING_NOT_ALLOWED = new Win32Error(215);

		// Token: 0x040000D9 RID: 217
		public static readonly Win32Error ERROR_KEY_DELETED = new Win32Error(1018);

		// Token: 0x040000DA RID: 218
		public static readonly Win32Error ERROR_NOT_FOUND = new Win32Error(1168);

		// Token: 0x040000DB RID: 219
		public static readonly Win32Error ERROR_NO_MATCH = new Win32Error(1169);

		// Token: 0x040000DC RID: 220
		public static readonly Win32Error ERROR_BAD_DEVICE = new Win32Error(1200);

		// Token: 0x040000DD RID: 221
		public static readonly Win32Error ERROR_CANCELLED = new Win32Error(1223);

		// Token: 0x040000DE RID: 222
		public static readonly Win32Error ERROR_CANNOT_FIND_WND_CLASS = new Win32Error(1407);

		// Token: 0x040000DF RID: 223
		public static readonly Win32Error ERROR_CLASS_ALREADY_EXISTS = new Win32Error(1410);

		// Token: 0x040000E0 RID: 224
		public static readonly Win32Error ERROR_INVALID_DATATYPE = new Win32Error(1804);
	}
}
