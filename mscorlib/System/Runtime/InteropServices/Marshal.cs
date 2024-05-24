using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Threading;
using Microsoft.Win32;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200094F RID: 2383
	[__DynamicallyInvokable]
	public static class Marshal
	{
		// Token: 0x060060BC RID: 24764 RVA: 0x0014C9F8 File Offset: 0x0014ABF8
		private static bool IsWin32Atom(IntPtr ptr)
		{
			long num = (long)ptr;
			return (num & -65536L) == 0L;
		}

		// Token: 0x060060BD RID: 24765 RVA: 0x0014CA18 File Offset: 0x0014AC18
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static bool IsNotWin32Atom(IntPtr ptr)
		{
			long num = (long)ptr;
			return (num & -65536L) != 0L;
		}

		// Token: 0x060060BE RID: 24766
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSystemMaxDBCSCharSize();

		// Token: 0x060060BF RID: 24767 RVA: 0x0014CA38 File Offset: 0x0014AC38
		[SecurityCritical]
		public unsafe static string PtrToStringAnsi(IntPtr ptr)
		{
			if (IntPtr.Zero == ptr)
			{
				return null;
			}
			if (Marshal.IsWin32Atom(ptr))
			{
				return null;
			}
			if (Win32Native.lstrlenA(ptr) == 0)
			{
				return string.Empty;
			}
			return new string((sbyte*)((void*)ptr));
		}

		// Token: 0x060060C0 RID: 24768 RVA: 0x0014CA79 File Offset: 0x0014AC79
		[SecurityCritical]
		public unsafe static string PtrToStringAnsi(IntPtr ptr, int len)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentNullException("ptr");
			}
			if (len < 0)
			{
				throw new ArgumentException("len");
			}
			return new string((sbyte*)((void*)ptr), 0, len);
		}

		// Token: 0x060060C1 RID: 24769 RVA: 0x0014CAAF File Offset: 0x0014ACAF
		[SecurityCritical]
		public unsafe static string PtrToStringUni(IntPtr ptr, int len)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentNullException("ptr");
			}
			if (len < 0)
			{
				throw new ArgumentException("len");
			}
			return new string((char*)((void*)ptr), 0, len);
		}

		// Token: 0x060060C2 RID: 24770 RVA: 0x0014CAE5 File Offset: 0x0014ACE5
		[SecurityCritical]
		public static string PtrToStringAuto(IntPtr ptr, int len)
		{
			return Marshal.PtrToStringUni(ptr, len);
		}

		// Token: 0x060060C3 RID: 24771 RVA: 0x0014CAEE File Offset: 0x0014ACEE
		[SecurityCritical]
		public unsafe static string PtrToStringUni(IntPtr ptr)
		{
			if (IntPtr.Zero == ptr)
			{
				return null;
			}
			if (Marshal.IsWin32Atom(ptr))
			{
				return null;
			}
			return new string((char*)((void*)ptr));
		}

		// Token: 0x060060C4 RID: 24772 RVA: 0x0014CB14 File Offset: 0x0014AD14
		[SecurityCritical]
		public static string PtrToStringAuto(IntPtr ptr)
		{
			return Marshal.PtrToStringUni(ptr);
		}

		// Token: 0x060060C5 RID: 24773 RVA: 0x0014CB1C File Offset: 0x0014AD1C
		[ComVisible(true)]
		public static int SizeOf(object structure)
		{
			if (structure == null)
			{
				throw new ArgumentNullException("structure");
			}
			return Marshal.SizeOfHelper(structure.GetType(), true);
		}

		// Token: 0x060060C6 RID: 24774 RVA: 0x0014CB38 File Offset: 0x0014AD38
		public static int SizeOf<T>(T structure)
		{
			return Marshal.SizeOf(structure);
		}

		// Token: 0x060060C7 RID: 24775 RVA: 0x0014CB48 File Offset: 0x0014AD48
		public static int SizeOf(Type t)
		{
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			if (!(t is RuntimeType))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"), "t");
			}
			if (t.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "t");
			}
			return Marshal.SizeOfHelper(t, true);
		}

		// Token: 0x060060C8 RID: 24776 RVA: 0x0014CBAA File Offset: 0x0014ADAA
		public static int SizeOf<T>()
		{
			return Marshal.SizeOf(typeof(T));
		}

		// Token: 0x060060C9 RID: 24777 RVA: 0x0014CBBC File Offset: 0x0014ADBC
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		internal static uint AlignedSizeOf<T>() where T : struct
		{
			uint num = Marshal.SizeOfType(typeof(T));
			if (num == 1U || num == 2U)
			{
				return num;
			}
			if (IntPtr.Size == 8 && num == 4U)
			{
				return num;
			}
			return Marshal.AlignedSizeOfType(typeof(T));
		}

		// Token: 0x060060CA RID: 24778
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint SizeOfType(Type type);

		// Token: 0x060060CB RID: 24779
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint AlignedSizeOfType(Type type);

		// Token: 0x060060CC RID: 24780
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int SizeOfHelper(Type t, bool throwIfNotMarshalable);

		// Token: 0x060060CD RID: 24781 RVA: 0x0014CC00 File Offset: 0x0014AE00
		public static IntPtr OffsetOf(Type t, string fieldName)
		{
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			FieldInfo field = t.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_OffsetOfFieldNotFound", new object[]
				{
					t.FullName
				}), "fieldName");
			}
			RtFieldInfo rtFieldInfo = field as RtFieldInfo;
			if (rtFieldInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeFieldInfo"), "fieldName");
			}
			return Marshal.OffsetOfHelper(rtFieldInfo);
		}

		// Token: 0x060060CE RID: 24782 RVA: 0x0014CC83 File Offset: 0x0014AE83
		public static IntPtr OffsetOf<T>(string fieldName)
		{
			return Marshal.OffsetOf(typeof(T), fieldName);
		}

		// Token: 0x060060CF RID: 24783
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr OffsetOfHelper(IRuntimeFieldInfo f);

		// Token: 0x060060D0 RID: 24784
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr UnsafeAddrOfPinnedArrayElement(Array arr, int index);

		// Token: 0x060060D1 RID: 24785 RVA: 0x0014CC95 File Offset: 0x0014AE95
		[SecurityCritical]
		public static IntPtr UnsafeAddrOfPinnedArrayElement<T>(T[] arr, int index)
		{
			return Marshal.UnsafeAddrOfPinnedArrayElement(arr, index);
		}

		// Token: 0x060060D2 RID: 24786 RVA: 0x0014CC9E File Offset: 0x0014AE9E
		[SecurityCritical]
		public static void Copy(int[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060D3 RID: 24787 RVA: 0x0014CCA9 File Offset: 0x0014AEA9
		[SecurityCritical]
		public static void Copy(char[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060D4 RID: 24788 RVA: 0x0014CCB4 File Offset: 0x0014AEB4
		[SecurityCritical]
		public static void Copy(short[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060D5 RID: 24789 RVA: 0x0014CCBF File Offset: 0x0014AEBF
		[SecurityCritical]
		public static void Copy(long[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060D6 RID: 24790 RVA: 0x0014CCCA File Offset: 0x0014AECA
		[SecurityCritical]
		public static void Copy(float[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060D7 RID: 24791 RVA: 0x0014CCD5 File Offset: 0x0014AED5
		[SecurityCritical]
		public static void Copy(double[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060D8 RID: 24792 RVA: 0x0014CCE0 File Offset: 0x0014AEE0
		[SecurityCritical]
		public static void Copy(byte[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060D9 RID: 24793 RVA: 0x0014CCEB File Offset: 0x0014AEEB
		[SecurityCritical]
		public static void Copy(IntPtr[] source, int startIndex, IntPtr destination, int length)
		{
			Marshal.CopyToNative(source, startIndex, destination, length);
		}

		// Token: 0x060060DA RID: 24794
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CopyToNative(object source, int startIndex, IntPtr destination, int length);

		// Token: 0x060060DB RID: 24795 RVA: 0x0014CCF6 File Offset: 0x0014AEF6
		[SecurityCritical]
		public static void Copy(IntPtr source, int[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060DC RID: 24796 RVA: 0x0014CD01 File Offset: 0x0014AF01
		[SecurityCritical]
		public static void Copy(IntPtr source, char[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060DD RID: 24797 RVA: 0x0014CD0C File Offset: 0x0014AF0C
		[SecurityCritical]
		public static void Copy(IntPtr source, short[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060DE RID: 24798 RVA: 0x0014CD17 File Offset: 0x0014AF17
		[SecurityCritical]
		public static void Copy(IntPtr source, long[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060DF RID: 24799 RVA: 0x0014CD22 File Offset: 0x0014AF22
		[SecurityCritical]
		public static void Copy(IntPtr source, float[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060E0 RID: 24800 RVA: 0x0014CD2D File Offset: 0x0014AF2D
		[SecurityCritical]
		public static void Copy(IntPtr source, double[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060E1 RID: 24801 RVA: 0x0014CD38 File Offset: 0x0014AF38
		[SecurityCritical]
		public static void Copy(IntPtr source, byte[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060E2 RID: 24802 RVA: 0x0014CD43 File Offset: 0x0014AF43
		[SecurityCritical]
		public static void Copy(IntPtr source, IntPtr[] destination, int startIndex, int length)
		{
			Marshal.CopyToManaged(source, destination, startIndex, length);
		}

		// Token: 0x060060E3 RID: 24803
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CopyToManaged(IntPtr source, object destination, int startIndex, int length);

		// Token: 0x060060E4 RID: 24804
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RU1")]
		public static extern byte ReadByte([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		// Token: 0x060060E5 RID: 24805 RVA: 0x0014CD50 File Offset: 0x0014AF50
		[SecurityCritical]
		public unsafe static byte ReadByte(IntPtr ptr, int ofs)
		{
			byte result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				result = *ptr2;
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		// Token: 0x060060E6 RID: 24806 RVA: 0x0014CD84 File Offset: 0x0014AF84
		[SecurityCritical]
		public static byte ReadByte(IntPtr ptr)
		{
			return Marshal.ReadByte(ptr, 0);
		}

		// Token: 0x060060E7 RID: 24807
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RI2")]
		public static extern short ReadInt16([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		// Token: 0x060060E8 RID: 24808 RVA: 0x0014CD90 File Offset: 0x0014AF90
		[SecurityCritical]
		public unsafe static short ReadInt16(IntPtr ptr, int ofs)
		{
			short result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 1) == 0)
				{
					result = *(short*)ptr2;
				}
				else
				{
					short num;
					byte* ptr3 = (byte*)(&num);
					*ptr3 = *ptr2;
					ptr3[1] = ptr2[1];
					result = num;
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		// Token: 0x060060E9 RID: 24809 RVA: 0x0014CDE0 File Offset: 0x0014AFE0
		[SecurityCritical]
		public static short ReadInt16(IntPtr ptr)
		{
			return Marshal.ReadInt16(ptr, 0);
		}

		// Token: 0x060060EA RID: 24810
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RI4")]
		public static extern int ReadInt32([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		// Token: 0x060060EB RID: 24811 RVA: 0x0014CDEC File Offset: 0x0014AFEC
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public unsafe static int ReadInt32(IntPtr ptr, int ofs)
		{
			int result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 3) == 0)
				{
					result = *(int*)ptr2;
				}
				else
				{
					int num;
					byte* ptr3 = (byte*)(&num);
					*ptr3 = *ptr2;
					ptr3[1] = ptr2[1];
					ptr3[2] = ptr2[2];
					ptr3[3] = ptr2[3];
					result = num;
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		// Token: 0x060060EC RID: 24812 RVA: 0x0014CE4C File Offset: 0x0014B04C
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int ReadInt32(IntPtr ptr)
		{
			return Marshal.ReadInt32(ptr, 0);
		}

		// Token: 0x060060ED RID: 24813 RVA: 0x0014CE55 File Offset: 0x0014B055
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs)
		{
			return (IntPtr)Marshal.ReadInt64(ptr, ofs);
		}

		// Token: 0x060060EE RID: 24814 RVA: 0x0014CE63 File Offset: 0x0014B063
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr(IntPtr ptr, int ofs)
		{
			return (IntPtr)Marshal.ReadInt64(ptr, ofs);
		}

		// Token: 0x060060EF RID: 24815 RVA: 0x0014CE71 File Offset: 0x0014B071
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr(IntPtr ptr)
		{
			return (IntPtr)Marshal.ReadInt64(ptr, 0);
		}

		// Token: 0x060060F0 RID: 24816
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_RI8")]
		public static extern long ReadInt64([MarshalAs(UnmanagedType.AsAny)] [In] object ptr, int ofs);

		// Token: 0x060060F1 RID: 24817 RVA: 0x0014CE80 File Offset: 0x0014B080
		[SecurityCritical]
		public unsafe static long ReadInt64(IntPtr ptr, int ofs)
		{
			long result;
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 7) == 0)
				{
					result = *(long*)ptr2;
				}
				else
				{
					long num;
					byte* ptr3 = (byte*)(&num);
					*ptr3 = *ptr2;
					ptr3[1] = ptr2[1];
					ptr3[2] = ptr2[2];
					ptr3[3] = ptr2[3];
					ptr3[4] = ptr2[4];
					ptr3[5] = ptr2[5];
					ptr3[6] = ptr2[6];
					ptr3[7] = ptr2[7];
					result = num;
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
			return result;
		}

		// Token: 0x060060F2 RID: 24818 RVA: 0x0014CF00 File Offset: 0x0014B100
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static long ReadInt64(IntPtr ptr)
		{
			return Marshal.ReadInt64(ptr, 0);
		}

		// Token: 0x060060F3 RID: 24819 RVA: 0x0014CF0C File Offset: 0x0014B10C
		[SecurityCritical]
		public unsafe static void WriteByte(IntPtr ptr, int ofs, byte val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				*ptr2 = val;
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		// Token: 0x060060F4 RID: 24820
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WU1")]
		public static extern void WriteByte([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, byte val);

		// Token: 0x060060F5 RID: 24821 RVA: 0x0014CF40 File Offset: 0x0014B140
		[SecurityCritical]
		public static void WriteByte(IntPtr ptr, byte val)
		{
			Marshal.WriteByte(ptr, 0, val);
		}

		// Token: 0x060060F6 RID: 24822 RVA: 0x0014CF4C File Offset: 0x0014B14C
		[SecurityCritical]
		public unsafe static void WriteInt16(IntPtr ptr, int ofs, short val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 1) == 0)
				{
					*(short*)ptr2 = val;
				}
				else
				{
					byte* ptr3 = (byte*)(&val);
					*ptr2 = *ptr3;
					ptr2[1] = ptr3[1];
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		// Token: 0x060060F7 RID: 24823
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WI2")]
		public static extern void WriteInt16([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, short val);

		// Token: 0x060060F8 RID: 24824 RVA: 0x0014CF98 File Offset: 0x0014B198
		[SecurityCritical]
		public static void WriteInt16(IntPtr ptr, short val)
		{
			Marshal.WriteInt16(ptr, 0, val);
		}

		// Token: 0x060060F9 RID: 24825 RVA: 0x0014CFA2 File Offset: 0x0014B1A2
		[SecurityCritical]
		public static void WriteInt16(IntPtr ptr, int ofs, char val)
		{
			Marshal.WriteInt16(ptr, ofs, (short)val);
		}

		// Token: 0x060060FA RID: 24826 RVA: 0x0014CFAD File Offset: 0x0014B1AD
		[SecurityCritical]
		public static void WriteInt16([In] [Out] object ptr, int ofs, char val)
		{
			Marshal.WriteInt16(ptr, ofs, (short)val);
		}

		// Token: 0x060060FB RID: 24827 RVA: 0x0014CFB8 File Offset: 0x0014B1B8
		[SecurityCritical]
		public static void WriteInt16(IntPtr ptr, char val)
		{
			Marshal.WriteInt16(ptr, 0, (short)val);
		}

		// Token: 0x060060FC RID: 24828 RVA: 0x0014CFC4 File Offset: 0x0014B1C4
		[SecurityCritical]
		public unsafe static void WriteInt32(IntPtr ptr, int ofs, int val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 3) == 0)
				{
					*(int*)ptr2 = val;
				}
				else
				{
					byte* ptr3 = (byte*)(&val);
					*ptr2 = *ptr3;
					ptr2[1] = ptr3[1];
					ptr2[2] = ptr3[2];
					ptr2[3] = ptr3[3];
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		// Token: 0x060060FD RID: 24829
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WI4")]
		public static extern void WriteInt32([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, int val);

		// Token: 0x060060FE RID: 24830 RVA: 0x0014D020 File Offset: 0x0014B220
		[SecurityCritical]
		public static void WriteInt32(IntPtr ptr, int val)
		{
			Marshal.WriteInt32(ptr, 0, val);
		}

		// Token: 0x060060FF RID: 24831 RVA: 0x0014D02A File Offset: 0x0014B22A
		[SecurityCritical]
		public static void WriteIntPtr(IntPtr ptr, int ofs, IntPtr val)
		{
			Marshal.WriteInt64(ptr, ofs, (long)val);
		}

		// Token: 0x06006100 RID: 24832 RVA: 0x0014D039 File Offset: 0x0014B239
		[SecurityCritical]
		public static void WriteIntPtr([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, IntPtr val)
		{
			Marshal.WriteInt64(ptr, ofs, (long)val);
		}

		// Token: 0x06006101 RID: 24833 RVA: 0x0014D048 File Offset: 0x0014B248
		[SecurityCritical]
		public static void WriteIntPtr(IntPtr ptr, IntPtr val)
		{
			Marshal.WriteInt64(ptr, 0, (long)val);
		}

		// Token: 0x06006102 RID: 24834 RVA: 0x0014D058 File Offset: 0x0014B258
		[SecurityCritical]
		public unsafe static void WriteInt64(IntPtr ptr, int ofs, long val)
		{
			try
			{
				byte* ptr2 = (byte*)((void*)ptr) + ofs;
				if ((ptr2 & 7) == 0)
				{
					*(long*)ptr2 = val;
				}
				else
				{
					byte* ptr3 = (byte*)(&val);
					*ptr2 = *ptr3;
					ptr2[1] = ptr3[1];
					ptr2[2] = ptr3[2];
					ptr2[3] = ptr3[3];
					ptr2[4] = ptr3[4];
					ptr2[5] = ptr3[5];
					ptr2[6] = ptr3[6];
					ptr2[7] = ptr3[7];
				}
			}
			catch (NullReferenceException)
			{
				throw new AccessViolationException();
			}
		}

		// Token: 0x06006103 RID: 24835
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("mscoree.dll", EntryPoint = "ND_WI8")]
		public static extern void WriteInt64([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object ptr, int ofs, long val);

		// Token: 0x06006104 RID: 24836 RVA: 0x0014D0D4 File Offset: 0x0014B2D4
		[SecurityCritical]
		public static void WriteInt64(IntPtr ptr, long val)
		{
			Marshal.WriteInt64(ptr, 0, val);
		}

		// Token: 0x06006105 RID: 24837
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetLastWin32Error();

		// Token: 0x06006106 RID: 24838
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void SetLastWin32Error(int error);

		// Token: 0x06006107 RID: 24839 RVA: 0x0014D0E0 File Offset: 0x0014B2E0
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int GetHRForLastWin32Error()
		{
			int lastWin32Error = Marshal.GetLastWin32Error();
			if (((long)lastWin32Error & (long)((ulong)-2147483648)) == (long)((ulong)-2147483648))
			{
				return lastWin32Error;
			}
			return (lastWin32Error & 65535) | -2147024896;
		}

		// Token: 0x06006108 RID: 24840 RVA: 0x0014D114 File Offset: 0x0014B314
		[SecurityCritical]
		public static void Prelink(MethodInfo m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			RuntimeMethodInfo runtimeMethodInfo = m as RuntimeMethodInfo;
			if (runtimeMethodInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"));
			}
			Marshal.InternalPrelink(runtimeMethodInfo);
		}

		// Token: 0x06006109 RID: 24841
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void InternalPrelink(IRuntimeMethodInfo m);

		// Token: 0x0600610A RID: 24842 RVA: 0x0014D15C File Offset: 0x0014B35C
		[SecurityCritical]
		public static void PrelinkAll(Type c)
		{
			if (c == null)
			{
				throw new ArgumentNullException("c");
			}
			MethodInfo[] methods = c.GetMethods();
			if (methods != null)
			{
				for (int i = 0; i < methods.Length; i++)
				{
					Marshal.Prelink(methods[i]);
				}
			}
		}

		// Token: 0x0600610B RID: 24843 RVA: 0x0014D1A0 File Offset: 0x0014B3A0
		[SecurityCritical]
		public static int NumParamBytes(MethodInfo m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			RuntimeMethodInfo runtimeMethodInfo = m as RuntimeMethodInfo;
			if (runtimeMethodInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"));
			}
			return Marshal.InternalNumParamBytes(runtimeMethodInfo);
		}

		// Token: 0x0600610C RID: 24844
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int InternalNumParamBytes(IRuntimeMethodInfo m);

		// Token: 0x0600610D RID: 24845
		[SecurityCritical]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetExceptionPointers();

		// Token: 0x0600610E RID: 24846
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetExceptionCode();

		// Token: 0x0600610F RID: 24847
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld);

		// Token: 0x06006110 RID: 24848 RVA: 0x0014D1E7 File Offset: 0x0014B3E7
		[SecurityCritical]
		public static void StructureToPtr<T>(T structure, IntPtr ptr, bool fDeleteOld)
		{
			Marshal.StructureToPtr(structure, ptr, fDeleteOld);
		}

		// Token: 0x06006111 RID: 24849 RVA: 0x0014D1F6 File Offset: 0x0014B3F6
		[SecurityCritical]
		[ComVisible(true)]
		public static void PtrToStructure(IntPtr ptr, object structure)
		{
			Marshal.PtrToStructureHelper(ptr, structure, false);
		}

		// Token: 0x06006112 RID: 24850 RVA: 0x0014D200 File Offset: 0x0014B400
		[SecurityCritical]
		public static void PtrToStructure<T>(IntPtr ptr, T structure)
		{
			Marshal.PtrToStructure(ptr, structure);
		}

		// Token: 0x06006113 RID: 24851 RVA: 0x0014D210 File Offset: 0x0014B410
		[SecurityCritical]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object PtrToStructure(IntPtr ptr, Type structureType)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}
			if (structureType == null)
			{
				throw new ArgumentNullException("structureType");
			}
			if (structureType.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "structureType");
			}
			RuntimeType runtimeType = structureType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "type");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			object obj = runtimeType.CreateInstanceDefaultCtor(false, false, false, ref stackCrawlMark);
			Marshal.PtrToStructureHelper(ptr, obj, true);
			return obj;
		}

		// Token: 0x06006114 RID: 24852 RVA: 0x0014D29E File Offset: 0x0014B49E
		[SecurityCritical]
		public static T PtrToStructure<T>(IntPtr ptr)
		{
			return (T)((object)Marshal.PtrToStructure(ptr, typeof(T)));
		}

		// Token: 0x06006115 RID: 24853
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PtrToStructureHelper(IntPtr ptr, object structure, bool allowValueClasses);

		// Token: 0x06006116 RID: 24854
		[SecurityCritical]
		[ComVisible(true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DestroyStructure(IntPtr ptr, Type structuretype);

		// Token: 0x06006117 RID: 24855 RVA: 0x0014D2B5 File Offset: 0x0014B4B5
		[SecurityCritical]
		public static void DestroyStructure<T>(IntPtr ptr)
		{
			Marshal.DestroyStructure(ptr, typeof(T));
		}

		// Token: 0x06006118 RID: 24856 RVA: 0x0014D2C8 File Offset: 0x0014B4C8
		[SecurityCritical]
		public static IntPtr GetHINSTANCE(Module m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			RuntimeModule runtimeModule = m as RuntimeModule;
			if (runtimeModule == null)
			{
				ModuleBuilder moduleBuilder = m as ModuleBuilder;
				if (moduleBuilder != null)
				{
					runtimeModule = moduleBuilder.InternalModule;
				}
			}
			if (runtimeModule == null)
			{
				throw new ArgumentNullException(Environment.GetResourceString("Argument_MustBeRuntimeModule"));
			}
			return Marshal.GetHINSTANCE(runtimeModule.GetNativeHandle());
		}

		// Token: 0x06006119 RID: 24857
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern IntPtr GetHINSTANCE(RuntimeModule m);

		// Token: 0x0600611A RID: 24858 RVA: 0x0014D334 File Offset: 0x0014B534
		[SecurityCritical]
		public static void ThrowExceptionForHR(int errorCode)
		{
			if (errorCode < 0)
			{
				Marshal.ThrowExceptionForHRInternal(errorCode, IntPtr.Zero);
			}
		}

		// Token: 0x0600611B RID: 24859 RVA: 0x0014D345 File Offset: 0x0014B545
		[SecurityCritical]
		public static void ThrowExceptionForHR(int errorCode, IntPtr errorInfo)
		{
			if (errorCode < 0)
			{
				Marshal.ThrowExceptionForHRInternal(errorCode, errorInfo);
			}
		}

		// Token: 0x0600611C RID: 24860
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ThrowExceptionForHRInternal(int errorCode, IntPtr errorInfo);

		// Token: 0x0600611D RID: 24861 RVA: 0x0014D352 File Offset: 0x0014B552
		[SecurityCritical]
		public static Exception GetExceptionForHR(int errorCode)
		{
			if (errorCode < 0)
			{
				return Marshal.GetExceptionForHRInternal(errorCode, IntPtr.Zero);
			}
			return null;
		}

		// Token: 0x0600611E RID: 24862 RVA: 0x0014D365 File Offset: 0x0014B565
		[SecurityCritical]
		public static Exception GetExceptionForHR(int errorCode, IntPtr errorInfo)
		{
			if (errorCode < 0)
			{
				return Marshal.GetExceptionForHRInternal(errorCode, errorInfo);
			}
			return null;
		}

		// Token: 0x0600611F RID: 24863
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Exception GetExceptionForHRInternal(int errorCode, IntPtr errorInfo);

		// Token: 0x06006120 RID: 24864
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetHRForException(Exception e);

		// Token: 0x06006121 RID: 24865
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetHRForException_WinRT(Exception e);

		// Token: 0x06006122 RID: 24866
		[SecurityCritical]
		[Obsolete("The GetUnmanagedThunkForManagedMethodPtr method has been deprecated and will be removed in a future release.", false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetUnmanagedThunkForManagedMethodPtr(IntPtr pfnMethodToWrap, IntPtr pbSignature, int cbSignature);

		// Token: 0x06006123 RID: 24867
		[SecurityCritical]
		[Obsolete("The GetManagedThunkForUnmanagedMethodPtr method has been deprecated and will be removed in a future release.", false)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetManagedThunkForUnmanagedMethodPtr(IntPtr pfnMethodToWrap, IntPtr pbSignature, int cbSignature);

		// Token: 0x06006124 RID: 24868 RVA: 0x0014D374 File Offset: 0x0014B574
		[SecurityCritical]
		[Obsolete("The GetThreadFromFiberCookie method has been deprecated.  Use the hosting API to perform this operation.", false)]
		public static Thread GetThreadFromFiberCookie(int cookie)
		{
			if (cookie == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ArgumentZero"), "cookie");
			}
			return Marshal.InternalGetThreadFromFiberCookie(cookie);
		}

		// Token: 0x06006125 RID: 24869
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Thread InternalGetThreadFromFiberCookie(int cookie);

		// Token: 0x06006126 RID: 24870 RVA: 0x0014D394 File Offset: 0x0014B594
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static IntPtr AllocHGlobal(IntPtr cb)
		{
			UIntPtr sizetdwBytes = new UIntPtr((ulong)cb.ToInt64());
			IntPtr intPtr = Win32Native.LocalAlloc_NoSafeHandle(0, sizetdwBytes);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		// Token: 0x06006127 RID: 24871 RVA: 0x0014D3CB File Offset: 0x0014B5CB
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static IntPtr AllocHGlobal(int cb)
		{
			return Marshal.AllocHGlobal((IntPtr)cb);
		}

		// Token: 0x06006128 RID: 24872 RVA: 0x0014D3D8 File Offset: 0x0014B5D8
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void FreeHGlobal(IntPtr hglobal)
		{
			if (Marshal.IsNotWin32Atom(hglobal) && IntPtr.Zero != Win32Native.LocalFree(hglobal))
			{
				Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
			}
		}

		// Token: 0x06006129 RID: 24873 RVA: 0x0014D400 File Offset: 0x0014B600
		[SecurityCritical]
		public static IntPtr ReAllocHGlobal(IntPtr pv, IntPtr cb)
		{
			IntPtr intPtr = Win32Native.LocalReAlloc(pv, cb, 2);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		// Token: 0x0600612A RID: 24874 RVA: 0x0014D42C File Offset: 0x0014B62C
		[SecurityCritical]
		public unsafe static IntPtr StringToHGlobalAnsi(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * Marshal.SystemMaxDBCSCharSize;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			UIntPtr sizetdwBytes = new UIntPtr((uint)num);
			IntPtr intPtr = Win32Native.LocalAlloc_NoSafeHandle(0, sizetdwBytes);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			s.ConvertToAnsi((byte*)((void*)intPtr), num, false, false);
			return intPtr;
		}

		// Token: 0x0600612B RID: 24875 RVA: 0x0014D49C File Offset: 0x0014B69C
		[SecurityCritical]
		public unsafe static IntPtr StringToHGlobalUni(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * 2;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			UIntPtr sizetdwBytes = new UIntPtr((uint)num);
			IntPtr intPtr = Win32Native.LocalAlloc_NoSafeHandle(0, sizetdwBytes);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				string.wstrcpy((char*)((void*)intPtr), ptr, s.Length + 1);
			}
			return intPtr;
		}

		// Token: 0x0600612C RID: 24876 RVA: 0x0014D51E File Offset: 0x0014B71E
		[SecurityCritical]
		public static IntPtr StringToHGlobalAuto(string s)
		{
			return Marshal.StringToHGlobalUni(s);
		}

		// Token: 0x0600612D RID: 24877 RVA: 0x0014D526 File Offset: 0x0014B726
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeLibName(ITypeLib pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static string GetTypeLibName(UCOMITypeLib pTLB)
		{
			return Marshal.GetTypeLibName((ITypeLib)pTLB);
		}

		// Token: 0x0600612E RID: 24878 RVA: 0x0014D534 File Offset: 0x0014B734
		[SecurityCritical]
		public static string GetTypeLibName(ITypeLib typelib)
		{
			if (typelib == null)
			{
				throw new ArgumentNullException("typelib");
			}
			string result = null;
			string text = null;
			int num = 0;
			string text2 = null;
			typelib.GetDocumentation(-1, out result, out text, out num, out text2);
			return result;
		}

		// Token: 0x0600612F RID: 24879 RVA: 0x0014D568 File Offset: 0x0014B768
		[SecurityCritical]
		internal static string GetTypeLibNameInternal(ITypeLib typelib)
		{
			if (typelib == null)
			{
				throw new ArgumentNullException("typelib");
			}
			ITypeLib2 typeLib = typelib as ITypeLib2;
			if (typeLib != null)
			{
				Guid managedNameGuid = Marshal.ManagedNameGuid;
				object obj;
				try
				{
					typeLib.GetCustData(ref managedNameGuid, out obj);
				}
				catch (Exception)
				{
					obj = null;
				}
				if (obj != null && obj.GetType() == typeof(string))
				{
					string text = (string)obj;
					text = text.Trim();
					if (text.EndsWith(".DLL", StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(0, text.Length - 4);
					}
					else if (text.EndsWith(".EXE", StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(0, text.Length - 4);
					}
					return text;
				}
			}
			return Marshal.GetTypeLibName(typelib);
		}

		// Token: 0x06006130 RID: 24880 RVA: 0x0014D624 File Offset: 0x0014B824
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeLibGuid(ITypeLib pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static Guid GetTypeLibGuid(UCOMITypeLib pTLB)
		{
			return Marshal.GetTypeLibGuid((ITypeLib)pTLB);
		}

		// Token: 0x06006131 RID: 24881 RVA: 0x0014D634 File Offset: 0x0014B834
		[SecurityCritical]
		public static Guid GetTypeLibGuid(ITypeLib typelib)
		{
			Guid result = default(Guid);
			Marshal.FCallGetTypeLibGuid(ref result, typelib);
			return result;
		}

		// Token: 0x06006132 RID: 24882
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGetTypeLibGuid(ref Guid result, ITypeLib pTLB);

		// Token: 0x06006133 RID: 24883 RVA: 0x0014D652 File Offset: 0x0014B852
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeLibLcid(ITypeLib pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static int GetTypeLibLcid(UCOMITypeLib pTLB)
		{
			return Marshal.GetTypeLibLcid((ITypeLib)pTLB);
		}

		// Token: 0x06006134 RID: 24884
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetTypeLibLcid(ITypeLib typelib);

		// Token: 0x06006135 RID: 24885
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void GetTypeLibVersion(ITypeLib typeLibrary, out int major, out int minor);

		// Token: 0x06006136 RID: 24886 RVA: 0x0014D660 File Offset: 0x0014B860
		[SecurityCritical]
		internal static Guid GetTypeInfoGuid(ITypeInfo typeInfo)
		{
			Guid result = default(Guid);
			Marshal.FCallGetTypeInfoGuid(ref result, typeInfo);
			return result;
		}

		// Token: 0x06006137 RID: 24887
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGetTypeInfoGuid(ref Guid result, ITypeInfo typeInfo);

		// Token: 0x06006138 RID: 24888 RVA: 0x0014D680 File Offset: 0x0014B880
		[SecurityCritical]
		public static Guid GetTypeLibGuidForAssembly(Assembly asm)
		{
			if (asm == null)
			{
				throw new ArgumentNullException("asm");
			}
			RuntimeAssembly runtimeAssembly = asm as RuntimeAssembly;
			if (runtimeAssembly == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"), "asm");
			}
			Guid result = default(Guid);
			Marshal.FCallGetTypeLibGuidForAssembly(ref result, runtimeAssembly);
			return result;
		}

		// Token: 0x06006139 RID: 24889
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGetTypeLibGuidForAssembly(ref Guid result, RuntimeAssembly asm);

		// Token: 0x0600613A RID: 24890
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _GetTypeLibVersionForAssembly(RuntimeAssembly inputAssembly, out int majorVersion, out int minorVersion);

		// Token: 0x0600613B RID: 24891 RVA: 0x0014D6D8 File Offset: 0x0014B8D8
		[SecurityCritical]
		public static void GetTypeLibVersionForAssembly(Assembly inputAssembly, out int majorVersion, out int minorVersion)
		{
			if (inputAssembly == null)
			{
				throw new ArgumentNullException("inputAssembly");
			}
			RuntimeAssembly runtimeAssembly = inputAssembly as RuntimeAssembly;
			if (runtimeAssembly == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeAssembly"), "inputAssembly");
			}
			Marshal._GetTypeLibVersionForAssembly(runtimeAssembly, out majorVersion, out minorVersion);
		}

		// Token: 0x0600613C RID: 24892 RVA: 0x0014D726 File Offset: 0x0014B926
		[SecurityCritical]
		[Obsolete("Use System.Runtime.InteropServices.Marshal.GetTypeInfoName(ITypeInfo pTLB) instead. http://go.microsoft.com/fwlink/?linkid=14202&ID=0000011.", false)]
		public static string GetTypeInfoName(UCOMITypeInfo pTI)
		{
			return Marshal.GetTypeInfoName((ITypeInfo)pTI);
		}

		// Token: 0x0600613D RID: 24893 RVA: 0x0014D734 File Offset: 0x0014B934
		[SecurityCritical]
		public static string GetTypeInfoName(ITypeInfo typeInfo)
		{
			if (typeInfo == null)
			{
				throw new ArgumentNullException("typeInfo");
			}
			string result = null;
			string text = null;
			int num = 0;
			string text2 = null;
			typeInfo.GetDocumentation(-1, out result, out text, out num, out text2);
			return result;
		}

		// Token: 0x0600613E RID: 24894 RVA: 0x0014D768 File Offset: 0x0014B968
		[SecurityCritical]
		internal static string GetTypeInfoNameInternal(ITypeInfo typeInfo, out bool hasManagedName)
		{
			if (typeInfo == null)
			{
				throw new ArgumentNullException("typeInfo");
			}
			ITypeInfo2 typeInfo2 = typeInfo as ITypeInfo2;
			if (typeInfo2 != null)
			{
				Guid managedNameGuid = Marshal.ManagedNameGuid;
				object obj;
				try
				{
					typeInfo2.GetCustData(ref managedNameGuid, out obj);
				}
				catch (Exception)
				{
					obj = null;
				}
				if (obj != null && obj.GetType() == typeof(string))
				{
					hasManagedName = true;
					return (string)obj;
				}
			}
			hasManagedName = false;
			return Marshal.GetTypeInfoName(typeInfo);
		}

		// Token: 0x0600613F RID: 24895 RVA: 0x0014D7E4 File Offset: 0x0014B9E4
		[SecurityCritical]
		internal static string GetManagedTypeInfoNameInternal(ITypeLib typeLib, ITypeInfo typeInfo)
		{
			bool flag;
			string typeInfoNameInternal = Marshal.GetTypeInfoNameInternal(typeInfo, out flag);
			if (flag)
			{
				return typeInfoNameInternal;
			}
			return Marshal.GetTypeLibNameInternal(typeLib) + "." + typeInfoNameInternal;
		}

		// Token: 0x06006140 RID: 24896
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Type GetLoadedTypeForGUID(ref Guid guid);

		// Token: 0x06006141 RID: 24897 RVA: 0x0014D810 File Offset: 0x0014BA10
		[SecurityCritical]
		public static Type GetTypeForITypeInfo(IntPtr piTypeInfo)
		{
			ITypeInfo typeInfo = null;
			ITypeLib typeLib = null;
			Assembly assembly = null;
			int num = 0;
			if (piTypeInfo == IntPtr.Zero)
			{
				return null;
			}
			typeInfo = (ITypeInfo)Marshal.GetObjectForIUnknown(piTypeInfo);
			Guid typeInfoGuid = Marshal.GetTypeInfoGuid(typeInfo);
			Type type = Marshal.GetLoadedTypeForGUID(ref typeInfoGuid);
			if (type != null)
			{
				return type;
			}
			try
			{
				typeInfo.GetContainingTypeLib(out typeLib, out num);
			}
			catch (COMException)
			{
				typeLib = null;
			}
			if (typeLib != null)
			{
				AssemblyName assemblyNameFromTypelib = TypeLibConverter.GetAssemblyNameFromTypelib(typeLib, null, null, null, null, AssemblyNameFlags.None);
				string fullName = assemblyNameFromTypelib.FullName;
				Assembly[] assemblies = Thread.GetDomain().GetAssemblies();
				int num2 = assemblies.Length;
				for (int i = 0; i < num2; i++)
				{
					if (string.Compare(assemblies[i].FullName, fullName, StringComparison.Ordinal) == 0)
					{
						assembly = assemblies[i];
					}
				}
				if (assembly == null)
				{
					TypeLibConverter typeLibConverter = new TypeLibConverter();
					assembly = typeLibConverter.ConvertTypeLibToAssembly(typeLib, Marshal.GetTypeLibName(typeLib) + ".dll", TypeLibImporterFlags.None, new ImporterCallback(), null, null, null, null);
				}
				type = assembly.GetType(Marshal.GetManagedTypeInfoNameInternal(typeLib, typeInfo), true, false);
				if (type != null && !type.IsVisible)
				{
					type = null;
				}
			}
			else
			{
				type = typeof(object);
			}
			return type;
		}

		// Token: 0x06006142 RID: 24898 RVA: 0x0014D940 File Offset: 0x0014BB40
		[SecuritySafeCritical]
		public static Type GetTypeFromCLSID(Guid clsid)
		{
			return RuntimeType.GetTypeFromCLSIDImpl(clsid, null, false);
		}

		// Token: 0x06006143 RID: 24899
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetITypeInfoForType(Type t);

		// Token: 0x06006144 RID: 24900 RVA: 0x0014D94A File Offset: 0x0014BB4A
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static IntPtr GetIUnknownForObject(object o)
		{
			return Marshal.GetIUnknownForObjectNative(o, false);
		}

		// Token: 0x06006145 RID: 24901 RVA: 0x0014D953 File Offset: 0x0014BB53
		[SecurityCritical]
		public static IntPtr GetIUnknownForObjectInContext(object o)
		{
			return Marshal.GetIUnknownForObjectNative(o, true);
		}

		// Token: 0x06006146 RID: 24902
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetIUnknownForObjectNative(object o, bool onlyInContext);

		// Token: 0x06006147 RID: 24903
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr GetRawIUnknownForComObjectNoAddRef(object o);

		// Token: 0x06006148 RID: 24904 RVA: 0x0014D95C File Offset: 0x0014BB5C
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static IntPtr GetIDispatchForObject(object o)
		{
			return Marshal.GetIDispatchForObjectNative(o, false);
		}

		// Token: 0x06006149 RID: 24905 RVA: 0x0014D965 File Offset: 0x0014BB65
		[SecurityCritical]
		public static IntPtr GetIDispatchForObjectInContext(object o)
		{
			return Marshal.GetIDispatchForObjectNative(o, true);
		}

		// Token: 0x0600614A RID: 24906
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetIDispatchForObjectNative(object o, bool onlyInContext);

		// Token: 0x0600614B RID: 24907 RVA: 0x0014D96E File Offset: 0x0014BB6E
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObject(object o, Type T)
		{
			return Marshal.GetComInterfaceForObjectNative(o, T, false, true);
		}

		// Token: 0x0600614C RID: 24908 RVA: 0x0014D979 File Offset: 0x0014BB79
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObject<T, TInterface>(T o)
		{
			return Marshal.GetComInterfaceForObject(o, typeof(TInterface));
		}

		// Token: 0x0600614D RID: 24909 RVA: 0x0014D990 File Offset: 0x0014BB90
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObject(object o, Type T, CustomQueryInterfaceMode mode)
		{
			bool fEnalbeCustomizedQueryInterface = mode == CustomQueryInterfaceMode.Allow;
			return Marshal.GetComInterfaceForObjectNative(o, T, false, fEnalbeCustomizedQueryInterface);
		}

		// Token: 0x0600614E RID: 24910 RVA: 0x0014D9AF File Offset: 0x0014BBAF
		[SecurityCritical]
		public static IntPtr GetComInterfaceForObjectInContext(object o, Type t)
		{
			return Marshal.GetComInterfaceForObjectNative(o, t, true, true);
		}

		// Token: 0x0600614F RID: 24911
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetComInterfaceForObjectNative(object o, Type t, bool onlyInContext, bool fEnalbeCustomizedQueryInterface);

		// Token: 0x06006150 RID: 24912
		[SecurityCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetObjectForIUnknown(IntPtr pUnk);

		// Token: 0x06006151 RID: 24913
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetUniqueObjectForIUnknown(IntPtr unknown);

		// Token: 0x06006152 RID: 24914
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetTypedObjectForIUnknown(IntPtr pUnk, Type t);

		// Token: 0x06006153 RID: 24915
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr CreateAggregatedObject(IntPtr pOuter, object o);

		// Token: 0x06006154 RID: 24916 RVA: 0x0014D9BA File Offset: 0x0014BBBA
		[SecurityCritical]
		public static IntPtr CreateAggregatedObject<T>(IntPtr pOuter, T o)
		{
			return Marshal.CreateAggregatedObject(pOuter, o);
		}

		// Token: 0x06006155 RID: 24917
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void CleanupUnusedObjectsInCurrentContext();

		// Token: 0x06006156 RID: 24918
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool AreComObjectsAvailableForCleanup();

		// Token: 0x06006157 RID: 24919
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsComObject(object o);

		// Token: 0x06006158 RID: 24920 RVA: 0x0014D9C8 File Offset: 0x0014BBC8
		[SecurityCritical]
		public static IntPtr AllocCoTaskMem(int cb)
		{
			IntPtr intPtr = Win32Native.CoTaskMemAlloc(new UIntPtr((uint)cb));
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		// Token: 0x06006159 RID: 24921 RVA: 0x0014D9F8 File Offset: 0x0014BBF8
		[SecurityCritical]
		public unsafe static IntPtr StringToCoTaskMemUni(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * 2;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			IntPtr intPtr = Win32Native.CoTaskMemAlloc(new UIntPtr((uint)num));
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				string.wstrcpy((char*)((void*)intPtr), ptr, s.Length + 1);
			}
			return intPtr;
		}

		// Token: 0x0600615A RID: 24922 RVA: 0x0014DA73 File Offset: 0x0014BC73
		[SecurityCritical]
		public static IntPtr StringToCoTaskMemAuto(string s)
		{
			return Marshal.StringToCoTaskMemUni(s);
		}

		// Token: 0x0600615B RID: 24923 RVA: 0x0014DA7C File Offset: 0x0014BC7C
		[SecurityCritical]
		public unsafe static IntPtr StringToCoTaskMemAnsi(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			int num = (s.Length + 1) * Marshal.SystemMaxDBCSCharSize;
			if (num < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			IntPtr intPtr = Win32Native.CoTaskMemAlloc(new UIntPtr((uint)num));
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			s.ConvertToAnsi((byte*)((void*)intPtr), num, false, false);
			return intPtr;
		}

		// Token: 0x0600615C RID: 24924 RVA: 0x0014DAE5 File Offset: 0x0014BCE5
		[SecurityCritical]
		public static void FreeCoTaskMem(IntPtr ptr)
		{
			if (Marshal.IsNotWin32Atom(ptr))
			{
				Win32Native.CoTaskMemFree(ptr);
			}
		}

		// Token: 0x0600615D RID: 24925 RVA: 0x0014DAF8 File Offset: 0x0014BCF8
		[SecurityCritical]
		public static IntPtr ReAllocCoTaskMem(IntPtr pv, int cb)
		{
			IntPtr intPtr = Win32Native.CoTaskMemRealloc(pv, new UIntPtr((uint)cb));
			if (intPtr == IntPtr.Zero && cb != 0)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		// Token: 0x0600615E RID: 24926 RVA: 0x0014DB2C File Offset: 0x0014BD2C
		[SecurityCritical]
		public static int ReleaseComObject(object o)
		{
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)o;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "o");
			}
			return _ComObject.ReleaseSelf();
		}

		// Token: 0x0600615F RID: 24927
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int InternalReleaseComObject(object o);

		// Token: 0x06006160 RID: 24928 RVA: 0x0014DB70 File Offset: 0x0014BD70
		[SecurityCritical]
		public static int FinalReleaseComObject(object o)
		{
			if (o == null)
			{
				throw new ArgumentNullException("o");
			}
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)o;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "o");
			}
			_ComObject.FinalReleaseSelf();
			return 0;
		}

		// Token: 0x06006161 RID: 24929
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InternalFinalReleaseComObject(object o);

		// Token: 0x06006162 RID: 24930 RVA: 0x0014DBC4 File Offset: 0x0014BDC4
		[SecurityCritical]
		public static object GetComObjectData(object obj, object key)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)obj;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "obj");
			}
			if (obj.GetType().IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjIsWinRTObject"), "obj");
			}
			return _ComObject.GetData(key);
		}

		// Token: 0x06006163 RID: 24931 RVA: 0x0014DC48 File Offset: 0x0014BE48
		[SecurityCritical]
		public static bool SetComObjectData(object obj, object key, object data)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			__ComObject _ComObject = null;
			try
			{
				_ComObject = (__ComObject)obj;
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "obj");
			}
			if (obj.GetType().IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjIsWinRTObject"), "obj");
			}
			return _ComObject.SetData(key, data);
		}

		// Token: 0x06006164 RID: 24932 RVA: 0x0014DCCC File Offset: 0x0014BECC
		[SecurityCritical]
		public static object CreateWrapperOfType(object o, Type t)
		{
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			if (!t.IsCOMObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeNotComObject"), "t");
			}
			if (t.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "t");
			}
			if (t.IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeIsWinRTType"), "t");
			}
			if (o == null)
			{
				return null;
			}
			if (!o.GetType().IsCOMObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjNotComObject"), "o");
			}
			if (o.GetType().IsWindowsRuntimeObject)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ObjIsWinRTObject"), "o");
			}
			if (o.GetType() == t)
			{
				return o;
			}
			object obj = Marshal.GetComObjectData(o, t);
			if (obj == null)
			{
				obj = Marshal.InternalCreateWrapperOfType(o, t);
				if (!Marshal.SetComObjectData(o, t, obj))
				{
					obj = Marshal.GetComObjectData(o, t);
				}
			}
			return obj;
		}

		// Token: 0x06006165 RID: 24933 RVA: 0x0014DDC3 File Offset: 0x0014BFC3
		[SecurityCritical]
		public static TWrapper CreateWrapperOfType<T, TWrapper>(T o)
		{
			return (TWrapper)((object)Marshal.CreateWrapperOfType(o, typeof(TWrapper)));
		}

		// Token: 0x06006166 RID: 24934
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern object InternalCreateWrapperOfType(object o, Type t);

		// Token: 0x06006167 RID: 24935 RVA: 0x0014DDDF File Offset: 0x0014BFDF
		[SecurityCritical]
		[Obsolete("This API did not perform any operation and will be removed in future versions of the CLR.", false)]
		public static void ReleaseThreadCache()
		{
		}

		// Token: 0x06006168 RID: 24936
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsTypeVisibleFromCom(Type t);

		// Token: 0x06006169 RID: 24937
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int QueryInterface(IntPtr pUnk, ref Guid iid, out IntPtr ppv);

		// Token: 0x0600616A RID: 24938
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int AddRef(IntPtr pUnk);

		// Token: 0x0600616B RID: 24939
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int Release(IntPtr pUnk);

		// Token: 0x0600616C RID: 24940 RVA: 0x0014DDE1 File Offset: 0x0014BFE1
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static void FreeBSTR(IntPtr ptr)
		{
			if (Marshal.IsNotWin32Atom(ptr))
			{
				Win32Native.SysFreeString(ptr);
			}
		}

		// Token: 0x0600616D RID: 24941 RVA: 0x0014DDF4 File Offset: 0x0014BFF4
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static IntPtr StringToBSTR(string s)
		{
			if (s == null)
			{
				return IntPtr.Zero;
			}
			if (s.Length + 1 < s.Length)
			{
				throw new ArgumentOutOfRangeException("s");
			}
			IntPtr intPtr = Win32Native.SysAllocStringLen(s, s.Length);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			return intPtr;
		}

		// Token: 0x0600616E RID: 24942 RVA: 0x0014DE46 File Offset: 0x0014C046
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static string PtrToStringBSTR(IntPtr ptr)
		{
			return Marshal.PtrToStringUni(ptr, (int)Win32Native.SysStringLen(ptr));
		}

		// Token: 0x0600616F RID: 24943
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GetNativeVariantForObject(object obj, IntPtr pDstNativeVariant);

		// Token: 0x06006170 RID: 24944 RVA: 0x0014DE54 File Offset: 0x0014C054
		[SecurityCritical]
		public static void GetNativeVariantForObject<T>(T obj, IntPtr pDstNativeVariant)
		{
			Marshal.GetNativeVariantForObject(obj, pDstNativeVariant);
		}

		// Token: 0x06006171 RID: 24945
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object GetObjectForNativeVariant(IntPtr pSrcNativeVariant);

		// Token: 0x06006172 RID: 24946 RVA: 0x0014DE62 File Offset: 0x0014C062
		[SecurityCritical]
		public static T GetObjectForNativeVariant<T>(IntPtr pSrcNativeVariant)
		{
			return (T)((object)Marshal.GetObjectForNativeVariant(pSrcNativeVariant));
		}

		// Token: 0x06006173 RID: 24947
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object[] GetObjectsForNativeVariants(IntPtr aSrcNativeVariant, int cVars);

		// Token: 0x06006174 RID: 24948 RVA: 0x0014DE70 File Offset: 0x0014C070
		[SecurityCritical]
		public static T[] GetObjectsForNativeVariants<T>(IntPtr aSrcNativeVariant, int cVars)
		{
			object[] objectsForNativeVariants = Marshal.GetObjectsForNativeVariants(aSrcNativeVariant, cVars);
			T[] array = null;
			if (objectsForNativeVariants != null)
			{
				array = new T[objectsForNativeVariants.Length];
				Array.Copy(objectsForNativeVariants, array, objectsForNativeVariants.Length);
			}
			return array;
		}

		// Token: 0x06006175 RID: 24949
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetStartComSlot(Type t);

		// Token: 0x06006176 RID: 24950
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetEndComSlot(Type t);

		// Token: 0x06006177 RID: 24951
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern MemberInfo GetMethodInfoForComSlot(Type t, int slot, ref ComMemberType memberType);

		// Token: 0x06006178 RID: 24952 RVA: 0x0014DEA0 File Offset: 0x0014C0A0
		[SecurityCritical]
		public static int GetComSlotForMethodInfo(MemberInfo m)
		{
			if (m == null)
			{
				throw new ArgumentNullException("m");
			}
			if (!(m is RuntimeMethodInfo))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"), "m");
			}
			if (!m.DeclaringType.IsInterface)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeInterfaceMethod"), "m");
			}
			if (m.DeclaringType.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "m");
			}
			return Marshal.InternalGetComSlotForMethodInfo((IRuntimeMethodInfo)m);
		}

		// Token: 0x06006179 RID: 24953
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int InternalGetComSlotForMethodInfo(IRuntimeMethodInfo m);

		// Token: 0x0600617A RID: 24954 RVA: 0x0014DF30 File Offset: 0x0014C130
		[SecurityCritical]
		public static Guid GenerateGuidForType(Type type)
		{
			Guid result = default(Guid);
			Marshal.FCallGenerateGuidForType(ref result, type);
			return result;
		}

		// Token: 0x0600617B RID: 24955
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FCallGenerateGuidForType(ref Guid result, Type type);

		// Token: 0x0600617C RID: 24956 RVA: 0x0014DF50 File Offset: 0x0014C150
		[SecurityCritical]
		public static string GenerateProgIdForType(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsImport)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeMustNotBeComImport"), "type");
			}
			if (type.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			if (!RegistrationServices.TypeRequiresRegistrationHelper(type))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeMustBeComCreatable"), "type");
			}
			IList<CustomAttributeData> customAttributes = CustomAttributeData.GetCustomAttributes(type);
			for (int i = 0; i < customAttributes.Count; i++)
			{
				if (customAttributes[i].Constructor.DeclaringType == typeof(ProgIdAttribute))
				{
					IList<CustomAttributeTypedArgument> constructorArguments = customAttributes[i].ConstructorArguments;
					string text = (string)constructorArguments[0].Value;
					if (text == null)
					{
						text = string.Empty;
					}
					return text;
				}
			}
			return type.FullName;
		}

		// Token: 0x0600617D RID: 24957 RVA: 0x0014E03C File Offset: 0x0014C23C
		[SecurityCritical]
		public static object BindToMoniker(string monikerName)
		{
			object result = null;
			IBindCtx pbc = null;
			Marshal.CreateBindCtx(0U, out pbc);
			IMoniker pmk = null;
			uint num;
			Marshal.MkParseDisplayName(pbc, monikerName, out num, out pmk);
			Marshal.BindMoniker(pmk, 0U, ref Marshal.IID_IUnknown, out result);
			return result;
		}

		// Token: 0x0600617E RID: 24958 RVA: 0x0014E074 File Offset: 0x0014C274
		[SecurityCritical]
		public static object GetActiveObject(string progID)
		{
			object result = null;
			Guid guid;
			try
			{
				Marshal.CLSIDFromProgIDEx(progID, out guid);
			}
			catch (Exception)
			{
				Marshal.CLSIDFromProgID(progID, out guid);
			}
			Marshal.GetActiveObject(ref guid, IntPtr.Zero, out result);
			return result;
		}

		// Token: 0x0600617F RID: 24959
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

		// Token: 0x06006180 RID: 24960
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

		// Token: 0x06006181 RID: 24961
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void CreateBindCtx(uint reserved, out IBindCtx ppbc);

		// Token: 0x06006182 RID: 24962
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void MkParseDisplayName(IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string szUserName, out uint pchEaten, out IMoniker ppmk);

		// Token: 0x06006183 RID: 24963
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("ole32.dll", PreserveSig = false)]
		private static extern void BindMoniker(IMoniker pmk, uint grfOpt, ref Guid iidResult, [MarshalAs(UnmanagedType.Interface)] out object ppvResult);

		// Token: 0x06006184 RID: 24964
		[SuppressUnmanagedCodeSecurity]
		[SecurityCritical]
		[DllImport("oleaut32.dll", PreserveSig = false)]
		private static extern void GetActiveObject(ref Guid rclsid, IntPtr reserved, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

		// Token: 0x06006185 RID: 24965
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool InternalSwitchCCW(object oldtp, object newtp);

		// Token: 0x06006186 RID: 24966
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object InternalWrapIUnknownWithComObject(IntPtr i);

		// Token: 0x06006187 RID: 24967 RVA: 0x0014E0B8 File Offset: 0x0014C2B8
		[SecurityCritical]
		private static IntPtr LoadLicenseManager()
		{
			Assembly assembly = Assembly.Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
			Type type = assembly.GetType("System.ComponentModel.LicenseManager");
			if (type == null || !type.IsVisible)
			{
				return IntPtr.Zero;
			}
			return type.TypeHandle.Value;
		}

		// Token: 0x06006188 RID: 24968
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ChangeWrapperHandleStrength(object otp, bool fIsWeak);

		// Token: 0x06006189 RID: 24969
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InitializeWrapperForWinRT(object o, ref IntPtr pUnk);

		// Token: 0x0600618A RID: 24970
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InitializeManagedWinRTFactoryObject(object o, RuntimeType runtimeClassType);

		// Token: 0x0600618B RID: 24971
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern object GetNativeActivationFactory(Type type);

		// Token: 0x0600618C RID: 24972
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void _GetInspectableIids(ObjectHandleOnStack obj, ObjectHandleOnStack guids);

		// Token: 0x0600618D RID: 24973 RVA: 0x0014E104 File Offset: 0x0014C304
		[SecurityCritical]
		internal static Guid[] GetInspectableIids(object obj)
		{
			Guid[] result = null;
			__ComObject _ComObject = obj as __ComObject;
			if (_ComObject != null)
			{
				Marshal._GetInspectableIids(JitHelpers.GetObjectHandleOnStack<__ComObject>(ref _ComObject), JitHelpers.GetObjectHandleOnStack<Guid[]>(ref result));
			}
			return result;
		}

		// Token: 0x0600618E RID: 24974
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void _GetCachedWinRTTypeByIid(ObjectHandleOnStack appDomainObj, Guid iid, out IntPtr rthHandle);

		// Token: 0x0600618F RID: 24975 RVA: 0x0014E134 File Offset: 0x0014C334
		[SecurityCritical]
		internal static Type GetCachedWinRTTypeByIid(AppDomain ad, Guid iid)
		{
			IntPtr handle;
			Marshal._GetCachedWinRTTypeByIid(JitHelpers.GetObjectHandleOnStack<AppDomain>(ref ad), iid, out handle);
			return Type.GetTypeFromHandleUnsafe(handle);
		}

		// Token: 0x06006190 RID: 24976
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void _GetCachedWinRTTypes(ObjectHandleOnStack appDomainObj, ref int epoch, ObjectHandleOnStack winrtTypes);

		// Token: 0x06006191 RID: 24977 RVA: 0x0014E158 File Offset: 0x0014C358
		[SecurityCritical]
		internal static Type[] GetCachedWinRTTypes(AppDomain ad, ref int epoch)
		{
			IntPtr[] array = null;
			Marshal._GetCachedWinRTTypes(JitHelpers.GetObjectHandleOnStack<AppDomain>(ref ad), ref epoch, JitHelpers.GetObjectHandleOnStack<IntPtr[]>(ref array));
			Type[] array2 = new Type[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = Type.GetTypeFromHandleUnsafe(array[i]);
			}
			return array2;
		}

		// Token: 0x06006192 RID: 24978 RVA: 0x0014E1A0 File Offset: 0x0014C3A0
		[SecurityCritical]
		internal static Type[] GetCachedWinRTTypes(AppDomain ad)
		{
			int num = 0;
			return Marshal.GetCachedWinRTTypes(ad, ref num);
		}

		// Token: 0x06006193 RID: 24979 RVA: 0x0014E1B8 File Offset: 0x0014C3B8
		[SecurityCritical]
		public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentNullException("ptr");
			}
			if (t == null)
			{
				throw new ArgumentNullException("t");
			}
			if (t as RuntimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"), "t");
			}
			if (t.IsGenericType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "t");
			}
			Type baseType = t.BaseType;
			if (baseType == null || (baseType != typeof(Delegate) && baseType != typeof(MulticastDelegate)))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeDelegate"), "t");
			}
			return Marshal.GetDelegateForFunctionPointerInternal(ptr, t);
		}

		// Token: 0x06006194 RID: 24980 RVA: 0x0014E281 File Offset: 0x0014C481
		[SecurityCritical]
		public static TDelegate GetDelegateForFunctionPointer<TDelegate>(IntPtr ptr)
		{
			return (TDelegate)((object)Marshal.GetDelegateForFunctionPointer(ptr, typeof(TDelegate)));
		}

		// Token: 0x06006195 RID: 24981
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Delegate GetDelegateForFunctionPointerInternal(IntPtr ptr, Type t);

		// Token: 0x06006196 RID: 24982 RVA: 0x0014E298 File Offset: 0x0014C498
		[SecurityCritical]
		public static IntPtr GetFunctionPointerForDelegate(Delegate d)
		{
			if (d == null)
			{
				throw new ArgumentNullException("d");
			}
			return Marshal.GetFunctionPointerForDelegateInternal(d);
		}

		// Token: 0x06006197 RID: 24983 RVA: 0x0014E2AE File Offset: 0x0014C4AE
		[SecurityCritical]
		public static IntPtr GetFunctionPointerForDelegate<TDelegate>(TDelegate d)
		{
			return Marshal.GetFunctionPointerForDelegate((Delegate)((object)d));
		}

		// Token: 0x06006198 RID: 24984
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr GetFunctionPointerForDelegateInternal(Delegate d);

		// Token: 0x06006199 RID: 24985 RVA: 0x0014E2C0 File Offset: 0x0014C4C0
		[SecurityCritical]
		public static IntPtr SecureStringToBSTR(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToBSTR();
		}

		// Token: 0x0600619A RID: 24986 RVA: 0x0014E2D6 File Offset: 0x0014C4D6
		[SecurityCritical]
		public static IntPtr SecureStringToCoTaskMemAnsi(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToAnsiStr(false);
		}

		// Token: 0x0600619B RID: 24987 RVA: 0x0014E2ED File Offset: 0x0014C4ED
		[SecurityCritical]
		public static IntPtr SecureStringToCoTaskMemUnicode(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToUniStr(false);
		}

		// Token: 0x0600619C RID: 24988 RVA: 0x0014E304 File Offset: 0x0014C504
		[SecurityCritical]
		public static void ZeroFreeBSTR(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)(Win32Native.SysStringLen(s) * 2U));
			Marshal.FreeBSTR(s);
		}

		// Token: 0x0600619D RID: 24989 RVA: 0x0014E31F File Offset: 0x0014C51F
		[SecurityCritical]
		public static void ZeroFreeCoTaskMemAnsi(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)Win32Native.lstrlenA(s))));
			Marshal.FreeCoTaskMem(s);
		}

		// Token: 0x0600619E RID: 24990 RVA: 0x0014E339 File Offset: 0x0014C539
		[SecurityCritical]
		public static void ZeroFreeCoTaskMemUnicode(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)(Win32Native.lstrlenW(s) * 2))));
			Marshal.FreeCoTaskMem(s);
		}

		// Token: 0x0600619F RID: 24991 RVA: 0x0014E355 File Offset: 0x0014C555
		[SecurityCritical]
		public static IntPtr SecureStringToGlobalAllocAnsi(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToAnsiStr(true);
		}

		// Token: 0x060061A0 RID: 24992 RVA: 0x0014E36C File Offset: 0x0014C56C
		[SecurityCritical]
		public static IntPtr SecureStringToGlobalAllocUnicode(SecureString s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return s.ToUniStr(true);
		}

		// Token: 0x060061A1 RID: 24993 RVA: 0x0014E383 File Offset: 0x0014C583
		[SecurityCritical]
		public static void ZeroFreeGlobalAllocAnsi(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)Win32Native.lstrlenA(s))));
			Marshal.FreeHGlobal(s);
		}

		// Token: 0x060061A2 RID: 24994 RVA: 0x0014E39D File Offset: 0x0014C59D
		[SecurityCritical]
		public static void ZeroFreeGlobalAllocUnicode(IntPtr s)
		{
			Win32Native.ZeroMemory(s, (UIntPtr)((ulong)((long)(Win32Native.lstrlenW(s) * 2))));
			Marshal.FreeHGlobal(s);
		}

		// Token: 0x04002B54 RID: 11092
		private const int LMEM_FIXED = 0;

		// Token: 0x04002B55 RID: 11093
		private const int LMEM_MOVEABLE = 2;

		// Token: 0x04002B56 RID: 11094
		private const long HIWORDMASK = -65536L;

		// Token: 0x04002B57 RID: 11095
		private static Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");

		// Token: 0x04002B58 RID: 11096
		public static readonly int SystemDefaultCharSize = 2;

		// Token: 0x04002B59 RID: 11097
		public static readonly int SystemMaxDBCSCharSize = Marshal.GetSystemMaxDBCSCharSize();

		// Token: 0x04002B5A RID: 11098
		private const string s_strConvertedTypeInfoAssemblyName = "InteropDynamicTypes";

		// Token: 0x04002B5B RID: 11099
		private const string s_strConvertedTypeInfoAssemblyTitle = "Interop Dynamic Types";

		// Token: 0x04002B5C RID: 11100
		private const string s_strConvertedTypeInfoAssemblyDesc = "Type dynamically generated from ITypeInfo's";

		// Token: 0x04002B5D RID: 11101
		private const string s_strConvertedTypeInfoNameSpace = "InteropDynamicTypes";

		// Token: 0x04002B5E RID: 11102
		internal static readonly Guid ManagedNameGuid = new Guid("{0F21F359-AB84-41E8-9A78-36D110E6D2F9}");
	}
}
