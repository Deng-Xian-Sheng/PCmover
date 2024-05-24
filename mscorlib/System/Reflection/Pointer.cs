using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	// Token: 0x02000618 RID: 1560
	[CLSCompliant(false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class Pointer : ISerializable
	{
		// Token: 0x06004847 RID: 18503 RVA: 0x00106BA1 File Offset: 0x00104DA1
		private Pointer()
		{
		}

		// Token: 0x06004848 RID: 18504 RVA: 0x00106BAC File Offset: 0x00104DAC
		[SecurityCritical]
		private Pointer(SerializationInfo info, StreamingContext context)
		{
			this._ptr = ((IntPtr)info.GetValue("_ptr", typeof(IntPtr))).ToPointer();
			this._ptrType = (RuntimeType)info.GetValue("_ptrType", typeof(RuntimeType));
		}

		// Token: 0x06004849 RID: 18505 RVA: 0x00106C08 File Offset: 0x00104E08
		[SecurityCritical]
		public unsafe static object Box(void* ptr, Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!type.IsPointer)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBePointer"), "ptr");
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBePointer"), "ptr");
			}
			return new Pointer
			{
				_ptr = ptr,
				_ptrType = runtimeType
			};
		}

		// Token: 0x0600484A RID: 18506 RVA: 0x00106C80 File Offset: 0x00104E80
		[SecurityCritical]
		public unsafe static void* Unbox(object ptr)
		{
			if (!(ptr is Pointer))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBePointer"), "ptr");
			}
			return ((Pointer)ptr)._ptr;
		}

		// Token: 0x0600484B RID: 18507 RVA: 0x00106CAA File Offset: 0x00104EAA
		internal RuntimeType GetPointerType()
		{
			return this._ptrType;
		}

		// Token: 0x0600484C RID: 18508 RVA: 0x00106CB2 File Offset: 0x00104EB2
		[SecurityCritical]
		internal object GetPointerValue()
		{
			return (IntPtr)this._ptr;
		}

		// Token: 0x0600484D RID: 18509 RVA: 0x00106CC4 File Offset: 0x00104EC4
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_ptr", new IntPtr(this._ptr));
			info.AddValue("_ptrType", this._ptrType);
		}

		// Token: 0x04001DF9 RID: 7673
		[SecurityCritical]
		private unsafe void* _ptr;

		// Token: 0x04001DFA RID: 7674
		private RuntimeType _ptrType;
	}
}
