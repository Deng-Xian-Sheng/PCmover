using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x020005A5 RID: 1445
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class SystemTypeMarshaler
	{
		// Token: 0x06004320 RID: 17184 RVA: 0x000FA054 File Offset: 0x000F8254
		[SecurityCritical]
		internal unsafe static void ConvertToNative(Type managedType, TypeNameNative* pNativeType)
		{
			if (!Environment.IsWinRTSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
			}
			string text2;
			if (managedType != null)
			{
				if (managedType.GetType() != typeof(RuntimeType))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_WinRTSystemRuntimeType", new object[]
					{
						managedType.GetType().ToString()
					}));
				}
				bool flag;
				string text = WinRTTypeNameConverter.ConvertToWinRTTypeName(managedType, out flag);
				if (text != null)
				{
					text2 = text;
					if (flag)
					{
						pNativeType->typeKind = TypeKind.Primitive;
					}
					else
					{
						pNativeType->typeKind = TypeKind.Metadata;
					}
				}
				else
				{
					text2 = managedType.AssemblyQualifiedName;
					pNativeType->typeKind = TypeKind.Projection;
				}
			}
			else
			{
				text2 = "";
				pNativeType->typeKind = TypeKind.Projection;
			}
			int errorCode = UnsafeNativeMethods.WindowsCreateString(text2, text2.Length, &pNativeType->typeName);
			Marshal.ThrowExceptionForHR(errorCode, new IntPtr(-1));
		}

		// Token: 0x06004321 RID: 17185 RVA: 0x000FA11C File Offset: 0x000F831C
		[SecurityCritical]
		internal unsafe static void ConvertToManaged(TypeNameNative* pNativeType, ref Type managedType)
		{
			if (!Environment.IsWinRTSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
			}
			string text = WindowsRuntimeMarshal.HStringToString(pNativeType->typeName);
			if (string.IsNullOrEmpty(text))
			{
				managedType = null;
				return;
			}
			if (pNativeType->typeKind == TypeKind.Projection)
			{
				managedType = Type.GetType(text, true);
				return;
			}
			bool flag;
			managedType = WinRTTypeNameConverter.GetTypeFromWinRTTypeName(text, out flag);
			if (flag != (pNativeType->typeKind == TypeKind.Primitive))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_Unexpected_TypeSource"));
			}
		}

		// Token: 0x06004322 RID: 17186 RVA: 0x000FA191 File Offset: 0x000F8391
		[SecurityCritical]
		internal unsafe static void ClearNative(TypeNameNative* pNativeType)
		{
			TypeNameNative typeNameNative = *pNativeType;
			UnsafeNativeMethods.WindowsDeleteString(pNativeType->typeName);
		}
	}
}
