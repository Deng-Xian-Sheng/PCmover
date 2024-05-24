using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000955 RID: 2389
	[SecurityCritical]
	[__DynamicallyInvokable]
	public abstract class SafeBuffer : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x060061BD RID: 25021 RVA: 0x0014E5C9 File Offset: 0x0014C7C9
		[__DynamicallyInvokable]
		protected SafeBuffer(bool ownsHandle) : base(ownsHandle)
		{
			this._numBytes = SafeBuffer.Uninitialized;
		}

		// Token: 0x060061BE RID: 25022 RVA: 0x0014E5E0 File Offset: 0x0014C7E0
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public void Initialize(ulong numBytes)
		{
			if (numBytes < 0UL)
			{
				throw new ArgumentOutOfRangeException("numBytes", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (IntPtr.Size == 4 && numBytes > (ulong)-1)
			{
				throw new ArgumentOutOfRangeException("numBytes", Environment.GetResourceString("ArgumentOutOfRange_AddressSpace"));
			}
			if (numBytes >= (ulong)SafeBuffer.Uninitialized)
			{
				throw new ArgumentOutOfRangeException("numBytes", Environment.GetResourceString("ArgumentOutOfRange_UIntPtrMax-1"));
			}
			this._numBytes = (UIntPtr)numBytes;
		}

		// Token: 0x060061BF RID: 25023 RVA: 0x0014E658 File Offset: 0x0014C858
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public void Initialize(uint numElements, uint sizeOfEachElement)
		{
			if (numElements < 0U)
			{
				throw new ArgumentOutOfRangeException("numElements", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (sizeOfEachElement < 0U)
			{
				throw new ArgumentOutOfRangeException("sizeOfEachElement", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (IntPtr.Size == 4 && numElements * sizeOfEachElement > 4294967295U)
			{
				throw new ArgumentOutOfRangeException("numBytes", Environment.GetResourceString("ArgumentOutOfRange_AddressSpace"));
			}
			if ((ulong)(numElements * sizeOfEachElement) >= (ulong)SafeBuffer.Uninitialized)
			{
				throw new ArgumentOutOfRangeException("numElements", Environment.GetResourceString("ArgumentOutOfRange_UIntPtrMax-1"));
			}
			this._numBytes = (UIntPtr)(checked(numElements * sizeOfEachElement));
		}

		// Token: 0x060061C0 RID: 25024 RVA: 0x0014E6ED File Offset: 0x0014C8ED
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public void Initialize<T>(uint numElements) where T : struct
		{
			this.Initialize(numElements, Marshal.AlignedSizeOf<T>());
		}

		// Token: 0x060061C1 RID: 25025 RVA: 0x0014E6FC File Offset: 0x0014C8FC
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public unsafe void AcquirePointer(ref byte* pointer)
		{
			if (this._numBytes == SafeBuffer.Uninitialized)
			{
				throw SafeBuffer.NotInitialized();
			}
			pointer = (IntPtr)((UIntPtr)0);
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
			}
			finally
			{
				bool flag = false;
				base.DangerousAddRef(ref flag);
				pointer = (void*)this.handle;
			}
		}

		// Token: 0x060061C2 RID: 25026 RVA: 0x0014E754 File Offset: 0x0014C954
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public void ReleasePointer()
		{
			if (this._numBytes == SafeBuffer.Uninitialized)
			{
				throw SafeBuffer.NotInitialized();
			}
			base.DangerousRelease();
		}

		// Token: 0x060061C3 RID: 25027 RVA: 0x0014E774 File Offset: 0x0014C974
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public unsafe T Read<T>(ulong byteOffset) where T : struct
		{
			if (this._numBytes == SafeBuffer.Uninitialized)
			{
				throw SafeBuffer.NotInitialized();
			}
			uint num = Marshal.SizeOfType(typeof(T));
			byte* ptr = (byte*)((void*)this.handle) + byteOffset;
			this.SpaceCheck(ptr, (ulong)num);
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			T result;
			try
			{
				base.DangerousAddRef(ref flag);
				SafeBuffer.GenericPtrToStructure<T>(ptr, out result, num);
			}
			finally
			{
				if (flag)
				{
					base.DangerousRelease();
				}
			}
			return result;
		}

		// Token: 0x060061C4 RID: 25028 RVA: 0x0014E7F8 File Offset: 0x0014C9F8
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public unsafe void ReadArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct
		{
			if (array == null)
			{
				throw new ArgumentNullException("array", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (array.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (this._numBytes == SafeBuffer.Uninitialized)
			{
				throw SafeBuffer.NotInitialized();
			}
			uint sizeofT = Marshal.SizeOfType(typeof(T));
			uint num = Marshal.AlignedSizeOf<T>();
			byte* ptr = (byte*)((void*)this.handle) + byteOffset;
			this.SpaceCheck(ptr, checked(unchecked((ulong)num) * (ulong)(unchecked((long)count))));
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				base.DangerousAddRef(ref flag);
				for (int i = 0; i < count; i++)
				{
					SafeBuffer.GenericPtrToStructure<T>(ptr + (ulong)num * (ulong)((long)i), out array[i + index], sizeofT);
				}
			}
			finally
			{
				if (flag)
				{
					base.DangerousRelease();
				}
			}
		}

		// Token: 0x060061C5 RID: 25029 RVA: 0x0014E90C File Offset: 0x0014CB0C
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public unsafe void Write<T>(ulong byteOffset, T value) where T : struct
		{
			if (this._numBytes == SafeBuffer.Uninitialized)
			{
				throw SafeBuffer.NotInitialized();
			}
			uint num = Marshal.SizeOfType(typeof(T));
			byte* ptr = (byte*)((void*)this.handle) + byteOffset;
			this.SpaceCheck(ptr, (ulong)num);
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				base.DangerousAddRef(ref flag);
				SafeBuffer.GenericStructureToPtr<T>(ref value, ptr, num);
			}
			finally
			{
				if (flag)
				{
					base.DangerousRelease();
				}
			}
		}

		// Token: 0x060061C6 RID: 25030 RVA: 0x0014E990 File Offset: 0x0014CB90
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public unsafe void WriteArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct
		{
			if (array == null)
			{
				throw new ArgumentNullException("array", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (array.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (this._numBytes == SafeBuffer.Uninitialized)
			{
				throw SafeBuffer.NotInitialized();
			}
			uint sizeofT = Marshal.SizeOfType(typeof(T));
			uint num = Marshal.AlignedSizeOf<T>();
			byte* ptr = (byte*)((void*)this.handle) + byteOffset;
			this.SpaceCheck(ptr, checked(unchecked((ulong)num) * (ulong)(unchecked((long)count))));
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				base.DangerousAddRef(ref flag);
				for (int i = 0; i < count; i++)
				{
					SafeBuffer.GenericStructureToPtr<T>(ref array[i + index], ptr + (ulong)num * (ulong)((long)i), sizeofT);
				}
			}
			finally
			{
				if (flag)
				{
					base.DangerousRelease();
				}
			}
		}

		// Token: 0x17001104 RID: 4356
		// (get) Token: 0x060061C7 RID: 25031 RVA: 0x0014EAA4 File Offset: 0x0014CCA4
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public ulong ByteLength
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[__DynamicallyInvokable]
			get
			{
				if (this._numBytes == SafeBuffer.Uninitialized)
				{
					throw SafeBuffer.NotInitialized();
				}
				return (ulong)this._numBytes;
			}
		}

		// Token: 0x060061C8 RID: 25032 RVA: 0x0014EAC9 File Offset: 0x0014CCC9
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private unsafe void SpaceCheck(byte* ptr, ulong sizeInBytes)
		{
			if ((ulong)this._numBytes < sizeInBytes)
			{
				SafeBuffer.NotEnoughRoom();
			}
			if ((long)((byte*)ptr - (byte*)((void*)this.handle)) > (long)((ulong)this._numBytes - sizeInBytes))
			{
				SafeBuffer.NotEnoughRoom();
			}
		}

		// Token: 0x060061C9 RID: 25033 RVA: 0x0014EB02 File Offset: 0x0014CD02
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static void NotEnoughRoom()
		{
			throw new ArgumentException(Environment.GetResourceString("Arg_BufferTooSmall"));
		}

		// Token: 0x060061CA RID: 25034 RVA: 0x0014EB13 File Offset: 0x0014CD13
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static InvalidOperationException NotInitialized()
		{
			return new InvalidOperationException(Environment.GetResourceString("InvalidOperation_MustCallInitialize"));
		}

		// Token: 0x060061CB RID: 25035 RVA: 0x0014EB24 File Offset: 0x0014CD24
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal unsafe static void GenericPtrToStructure<T>(byte* ptr, out T structure, uint sizeofT) where T : struct
		{
			structure = default(T);
			SafeBuffer.PtrToStructureNative(ptr, __makeref(structure), sizeofT);
		}

		// Token: 0x060061CC RID: 25036
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void PtrToStructureNative(byte* ptr, TypedReference structure, uint sizeofT);

		// Token: 0x060061CD RID: 25037 RVA: 0x0014EB3A File Offset: 0x0014CD3A
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal unsafe static void GenericStructureToPtr<T>(ref T structure, byte* ptr, uint sizeofT) where T : struct
		{
			SafeBuffer.StructureToPtrNative(__makeref(structure), ptr, sizeofT);
		}

		// Token: 0x060061CE RID: 25038
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void StructureToPtrNative(TypedReference structure, byte* ptr, uint sizeofT);

		// Token: 0x04002B76 RID: 11126
		private static readonly UIntPtr Uninitialized = (UIntPtr.Size == 4) ? ((UIntPtr)uint.MaxValue) : ((UIntPtr)ulong.MaxValue);

		// Token: 0x04002B77 RID: 11127
		private UIntPtr _numBytes;
	}
}
