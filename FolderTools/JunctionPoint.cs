using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000006 RID: 6
	public static class JunctionPoint
	{
		// Token: 0x06000030 RID: 48
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr InBuffer, int nInBufferSize, IntPtr OutBuffer, int nOutBufferSize, out int pBytesReturned, IntPtr lpOverlapped);

		// Token: 0x06000031 RID: 49
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateFile(string lpFileName, JunctionPoint.EFileAccess dwDesiredAccess, JunctionPoint.EFileShare dwShareMode, IntPtr lpSecurityAttributes, JunctionPoint.ECreationDisposition dwCreationDisposition, JunctionPoint.EFileAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

		// Token: 0x06000032 RID: 50 RVA: 0x00002970 File Offset: 0x00000B70
		public static void Create(string junctionPoint, string targetDir, bool overwrite)
		{
			targetDir = Path.GetFullPath(targetDir);
			if (Directory.Exists(junctionPoint))
			{
				if (!overwrite)
				{
					throw new IOException("Directory already exists and overwrite parameter is false.");
				}
			}
			else
			{
				Directory.CreateDirectory(junctionPoint);
			}
			using (SafeFileHandle safeFileHandle = JunctionPoint.OpenReparsePoint(junctionPoint, JunctionPoint.EFileAccess.GenericWrite))
			{
				byte[] bytes = Encoding.Unicode.GetBytes("\\??\\" + Path.GetFullPath(targetDir));
				JunctionPoint.REPARSE_DATA_BUFFER reparse_DATA_BUFFER = new JunctionPoint.REPARSE_DATA_BUFFER
				{
					ReparseTag = 2684354563U,
					ReparseDataLength = (ushort)(bytes.Length + 12),
					SubstituteNameOffset = 0,
					SubstituteNameLength = (ushort)bytes.Length,
					PrintNameOffset = (ushort)(bytes.Length + 2),
					PrintNameLength = 0,
					PathBuffer = new byte[16368]
				};
				Array.Copy(bytes, reparse_DATA_BUFFER.PathBuffer, bytes.Length);
				IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf<JunctionPoint.REPARSE_DATA_BUFFER>(reparse_DATA_BUFFER));
				try
				{
					Marshal.StructureToPtr<JunctionPoint.REPARSE_DATA_BUFFER>(reparse_DATA_BUFFER, intPtr, false);
					int num;
					if (!JunctionPoint.DeviceIoControl(safeFileHandle.DangerousGetHandle(), 589988U, intPtr, bytes.Length + 20, IntPtr.Zero, 0, out num, IntPtr.Zero))
					{
						JunctionPoint.ThrowLastWin32Error("Unable to create junction point.");
					}
				}
				finally
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public static void Delete(string junctionPoint)
		{
			if (Directory.Exists(junctionPoint))
			{
				using (SafeFileHandle safeFileHandle = JunctionPoint.OpenReparsePoint(junctionPoint, JunctionPoint.EFileAccess.GenericWrite))
				{
					JunctionPoint.REPARSE_DATA_BUFFER structure = new JunctionPoint.REPARSE_DATA_BUFFER
					{
						ReparseTag = 2684354563U,
						ReparseDataLength = 0,
						PathBuffer = new byte[16368]
					};
					IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf<JunctionPoint.REPARSE_DATA_BUFFER>(structure));
					try
					{
						Marshal.StructureToPtr<JunctionPoint.REPARSE_DATA_BUFFER>(structure, intPtr, false);
						int num;
						if (!JunctionPoint.DeviceIoControl(safeFileHandle.DangerousGetHandle(), 589996U, intPtr, 8, IntPtr.Zero, 0, out num, IntPtr.Zero))
						{
							JunctionPoint.ThrowLastWin32Error("Unable to delete junction point.");
						}
					}
					finally
					{
						Marshal.FreeHGlobal(intPtr);
					}
					try
					{
						Directory.Delete(junctionPoint);
					}
					catch (IOException innerException)
					{
						throw new IOException("Unable to delete junction point.", innerException);
					}
				}
				return;
			}
			if (File.Exists(junctionPoint))
			{
				throw new IOException("Path is not a junction point.");
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002B9C File Offset: 0x00000D9C
		public static bool Exists(string path)
		{
			if (!Directory.Exists(path))
			{
				return false;
			}
			bool result;
			using (SafeFileHandle safeFileHandle = JunctionPoint.OpenReparsePoint(path, (JunctionPoint.EFileAccess)2147483648U))
			{
				result = (JunctionPoint.InternalGetTarget(safeFileHandle) != null);
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002BE8 File Offset: 0x00000DE8
		public static string GetTarget(string junctionPoint)
		{
			string result;
			using (SafeFileHandle safeFileHandle = JunctionPoint.OpenReparsePoint(junctionPoint, (JunctionPoint.EFileAccess)2147483648U))
			{
				string text = JunctionPoint.InternalGetTarget(safeFileHandle);
				if (text == null)
				{
					throw new IOException("Path is not a junction point.");
				}
				result = text;
			}
			return result;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002C34 File Offset: 0x00000E34
		private static string InternalGetTarget(SafeFileHandle handle)
		{
			int num = Marshal.SizeOf(typeof(JunctionPoint.REPARSE_DATA_BUFFER));
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			string result;
			try
			{
				int num2;
				if (!JunctionPoint.DeviceIoControl(handle.DangerousGetHandle(), 589992U, IntPtr.Zero, 0, intPtr, num, out num2, IntPtr.Zero))
				{
					if (Marshal.GetLastWin32Error() == 4390)
					{
						return null;
					}
					JunctionPoint.ThrowLastWin32Error("Unable to get information about junction point.");
				}
				JunctionPoint.REPARSE_DATA_BUFFER reparse_DATA_BUFFER = (JunctionPoint.REPARSE_DATA_BUFFER)Marshal.PtrToStructure(intPtr, typeof(JunctionPoint.REPARSE_DATA_BUFFER));
				if (reparse_DATA_BUFFER.ReparseTag != 2684354563U)
				{
					result = null;
				}
				else
				{
					string text = Encoding.Unicode.GetString(reparse_DATA_BUFFER.PathBuffer, (int)reparse_DATA_BUFFER.SubstituteNameOffset, (int)reparse_DATA_BUFFER.SubstituteNameLength);
					if (text.StartsWith("\\??\\"))
					{
						text = text.Substring("\\??\\".Length);
					}
					result = text;
				}
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002D1C File Offset: 0x00000F1C
		private static SafeFileHandle OpenReparsePoint(string reparsePoint, JunctionPoint.EFileAccess accessMode)
		{
			SafeFileHandle safeFileHandle = new SafeFileHandle(JunctionPoint.CreateFile(reparsePoint, accessMode, JunctionPoint.EFileShare.Read | JunctionPoint.EFileShare.Write | JunctionPoint.EFileShare.Delete, IntPtr.Zero, JunctionPoint.ECreationDisposition.OpenExisting, JunctionPoint.EFileAttributes.BackupSemantics | JunctionPoint.EFileAttributes.OpenReparsePoint, IntPtr.Zero), true);
			if (safeFileHandle.IsInvalid && Marshal.GetLastWin32Error() == 5)
			{
				safeFileHandle = new SafeFileHandle(JunctionPoint.CreateFile(reparsePoint, (JunctionPoint.EFileAccess)0U, JunctionPoint.EFileShare.Read | JunctionPoint.EFileShare.Write | JunctionPoint.EFileShare.Delete, IntPtr.Zero, JunctionPoint.ECreationDisposition.OpenExisting, JunctionPoint.EFileAttributes.BackupSemantics | JunctionPoint.EFileAttributes.OpenReparsePoint, IntPtr.Zero), true);
			}
			if (safeFileHandle.IsInvalid)
			{
				JunctionPoint.ThrowLastWin32Error(string.Format("Unable to open reparse point {0} as {1}", reparsePoint, accessMode));
			}
			return safeFileHandle;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002D96 File Offset: 0x00000F96
		private static void ThrowLastWin32Error(string message)
		{
			throw new IOException(message, Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
		}

		// Token: 0x04000018 RID: 24
		private const int ERROR_ACCESS_DENIED = 5;

		// Token: 0x04000019 RID: 25
		private const int ERROR_NOT_A_REPARSE_POINT = 4390;

		// Token: 0x0400001A RID: 26
		private const int ERROR_REPARSE_ATTRIBUTE_CONFLICT = 4391;

		// Token: 0x0400001B RID: 27
		private const int ERROR_INVALID_REPARSE_DATA = 4392;

		// Token: 0x0400001C RID: 28
		private const int ERROR_REPARSE_TAG_INVALID = 4393;

		// Token: 0x0400001D RID: 29
		private const int ERROR_REPARSE_TAG_MISMATCH = 4394;

		// Token: 0x0400001E RID: 30
		private const int FSCTL_SET_REPARSE_POINT = 589988;

		// Token: 0x0400001F RID: 31
		private const int FSCTL_GET_REPARSE_POINT = 589992;

		// Token: 0x04000020 RID: 32
		private const int FSCTL_DELETE_REPARSE_POINT = 589996;

		// Token: 0x04000021 RID: 33
		private const uint IO_REPARSE_TAG_MOUNT_POINT = 2684354563U;

		// Token: 0x04000022 RID: 34
		private const string NonInterpretedPathPrefix = "\\??\\";

		// Token: 0x0200000C RID: 12
		[Flags]
		private enum EFileAccess : uint
		{
			// Token: 0x0400003C RID: 60
			GenericRead = 2147483648U,
			// Token: 0x0400003D RID: 61
			GenericWrite = 1073741824U,
			// Token: 0x0400003E RID: 62
			GenericExecute = 536870912U,
			// Token: 0x0400003F RID: 63
			GenericAll = 268435456U
		}

		// Token: 0x0200000D RID: 13
		[Flags]
		private enum EFileShare : uint
		{
			// Token: 0x04000041 RID: 65
			None = 0U,
			// Token: 0x04000042 RID: 66
			Read = 1U,
			// Token: 0x04000043 RID: 67
			Write = 2U,
			// Token: 0x04000044 RID: 68
			Delete = 4U
		}

		// Token: 0x0200000E RID: 14
		private enum ECreationDisposition : uint
		{
			// Token: 0x04000046 RID: 70
			New = 1U,
			// Token: 0x04000047 RID: 71
			CreateAlways,
			// Token: 0x04000048 RID: 72
			OpenExisting,
			// Token: 0x04000049 RID: 73
			OpenAlways,
			// Token: 0x0400004A RID: 74
			TruncateExisting
		}

		// Token: 0x0200000F RID: 15
		[Flags]
		private enum EFileAttributes : uint
		{
			// Token: 0x0400004C RID: 76
			Readonly = 1U,
			// Token: 0x0400004D RID: 77
			Hidden = 2U,
			// Token: 0x0400004E RID: 78
			System = 4U,
			// Token: 0x0400004F RID: 79
			Directory = 16U,
			// Token: 0x04000050 RID: 80
			Archive = 32U,
			// Token: 0x04000051 RID: 81
			Device = 64U,
			// Token: 0x04000052 RID: 82
			Normal = 128U,
			// Token: 0x04000053 RID: 83
			Temporary = 256U,
			// Token: 0x04000054 RID: 84
			SparseFile = 512U,
			// Token: 0x04000055 RID: 85
			ReparsePoint = 1024U,
			// Token: 0x04000056 RID: 86
			Compressed = 2048U,
			// Token: 0x04000057 RID: 87
			Offline = 4096U,
			// Token: 0x04000058 RID: 88
			NotContentIndexed = 8192U,
			// Token: 0x04000059 RID: 89
			Encrypted = 16384U,
			// Token: 0x0400005A RID: 90
			Write_Through = 2147483648U,
			// Token: 0x0400005B RID: 91
			Overlapped = 1073741824U,
			// Token: 0x0400005C RID: 92
			NoBuffering = 536870912U,
			// Token: 0x0400005D RID: 93
			RandomAccess = 268435456U,
			// Token: 0x0400005E RID: 94
			SequentialScan = 134217728U,
			// Token: 0x0400005F RID: 95
			DeleteOnClose = 67108864U,
			// Token: 0x04000060 RID: 96
			BackupSemantics = 33554432U,
			// Token: 0x04000061 RID: 97
			PosixSemantics = 16777216U,
			// Token: 0x04000062 RID: 98
			OpenReparsePoint = 2097152U,
			// Token: 0x04000063 RID: 99
			OpenNoRecall = 1048576U,
			// Token: 0x04000064 RID: 100
			FirstPipeInstance = 524288U
		}

		// Token: 0x02000010 RID: 16
		private struct REPARSE_DATA_BUFFER
		{
			// Token: 0x04000065 RID: 101
			public uint ReparseTag;

			// Token: 0x04000066 RID: 102
			public ushort ReparseDataLength;

			// Token: 0x04000067 RID: 103
			public ushort Reserved;

			// Token: 0x04000068 RID: 104
			public ushort SubstituteNameOffset;

			// Token: 0x04000069 RID: 105
			public ushort SubstituteNameLength;

			// Token: 0x0400006A RID: 106
			public ushort PrintNameOffset;

			// Token: 0x0400006B RID: 107
			public ushort PrintNameLength;

			// Token: 0x0400006C RID: 108
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16368)]
			public byte[] PathBuffer;
		}
	}
}
