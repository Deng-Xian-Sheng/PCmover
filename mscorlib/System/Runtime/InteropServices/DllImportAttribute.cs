using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000933 RID: 2355
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DllImportAttribute : Attribute
	{
		// Token: 0x06006034 RID: 24628 RVA: 0x0014BA68 File Offset: 0x00149C68
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeMethodInfo method)
		{
			if ((method.Attributes & MethodAttributes.PinvokeImpl) == MethodAttributes.PrivateScope)
			{
				return null;
			}
			MetadataImport metadataImport = ModuleHandle.GetMetadataImport(method.Module.ModuleHandle.GetRuntimeModule());
			string dllName = null;
			int metadataToken = method.MetadataToken;
			PInvokeAttributes pinvokeAttributes = PInvokeAttributes.CharSetNotSpec;
			string entryPoint;
			metadataImport.GetPInvokeMap(metadataToken, out pinvokeAttributes, out entryPoint, out dllName);
			CharSet charSet = CharSet.None;
			switch (pinvokeAttributes & PInvokeAttributes.CharSetMask)
			{
			case PInvokeAttributes.CharSetNotSpec:
				charSet = CharSet.None;
				break;
			case PInvokeAttributes.CharSetAnsi:
				charSet = CharSet.Ansi;
				break;
			case PInvokeAttributes.CharSetUnicode:
				charSet = CharSet.Unicode;
				break;
			case PInvokeAttributes.CharSetMask:
				charSet = CharSet.Auto;
				break;
			}
			CallingConvention callingConvention = CallingConvention.Cdecl;
			PInvokeAttributes pinvokeAttributes2 = pinvokeAttributes & PInvokeAttributes.CallConvMask;
			if (pinvokeAttributes2 <= PInvokeAttributes.CallConvCdecl)
			{
				if (pinvokeAttributes2 != PInvokeAttributes.CallConvWinapi)
				{
					if (pinvokeAttributes2 == PInvokeAttributes.CallConvCdecl)
					{
						callingConvention = CallingConvention.Cdecl;
					}
				}
				else
				{
					callingConvention = CallingConvention.Winapi;
				}
			}
			else if (pinvokeAttributes2 != PInvokeAttributes.CallConvStdcall)
			{
				if (pinvokeAttributes2 != PInvokeAttributes.CallConvThiscall)
				{
					if (pinvokeAttributes2 == PInvokeAttributes.CallConvFastcall)
					{
						callingConvention = CallingConvention.FastCall;
					}
				}
				else
				{
					callingConvention = CallingConvention.ThisCall;
				}
			}
			else
			{
				callingConvention = CallingConvention.StdCall;
			}
			bool exactSpelling = (pinvokeAttributes & PInvokeAttributes.NoMangle) > PInvokeAttributes.CharSetNotSpec;
			bool setLastError = (pinvokeAttributes & PInvokeAttributes.SupportsLastError) > PInvokeAttributes.CharSetNotSpec;
			bool bestFitMapping = (pinvokeAttributes & PInvokeAttributes.BestFitMask) == PInvokeAttributes.BestFitEnabled;
			bool throwOnUnmappableChar = (pinvokeAttributes & PInvokeAttributes.ThrowOnUnmappableCharMask) == PInvokeAttributes.ThrowOnUnmappableCharEnabled;
			bool preserveSig = (method.GetMethodImplementationFlags() & MethodImplAttributes.PreserveSig) > MethodImplAttributes.IL;
			return new DllImportAttribute(dllName, entryPoint, charSet, exactSpelling, setLastError, preserveSig, callingConvention, bestFitMapping, throwOnUnmappableChar);
		}

		// Token: 0x06006035 RID: 24629 RVA: 0x0014BBAC File Offset: 0x00149DAC
		internal static bool IsDefined(RuntimeMethodInfo method)
		{
			return (method.Attributes & MethodAttributes.PinvokeImpl) > MethodAttributes.PrivateScope;
		}

		// Token: 0x06006036 RID: 24630 RVA: 0x0014BBC0 File Offset: 0x00149DC0
		internal DllImportAttribute(string dllName, string entryPoint, CharSet charSet, bool exactSpelling, bool setLastError, bool preserveSig, CallingConvention callingConvention, bool bestFitMapping, bool throwOnUnmappableChar)
		{
			this._val = dllName;
			this.EntryPoint = entryPoint;
			this.CharSet = charSet;
			this.ExactSpelling = exactSpelling;
			this.SetLastError = setLastError;
			this.PreserveSig = preserveSig;
			this.CallingConvention = callingConvention;
			this.BestFitMapping = bestFitMapping;
			this.ThrowOnUnmappableChar = throwOnUnmappableChar;
		}

		// Token: 0x06006037 RID: 24631 RVA: 0x0014BC18 File Offset: 0x00149E18
		[__DynamicallyInvokable]
		public DllImportAttribute(string dllName)
		{
			this._val = dllName;
		}

		// Token: 0x170010E2 RID: 4322
		// (get) Token: 0x06006038 RID: 24632 RVA: 0x0014BC27 File Offset: 0x00149E27
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002B0B RID: 11019
		internal string _val;

		// Token: 0x04002B0C RID: 11020
		[__DynamicallyInvokable]
		public string EntryPoint;

		// Token: 0x04002B0D RID: 11021
		[__DynamicallyInvokable]
		public CharSet CharSet;

		// Token: 0x04002B0E RID: 11022
		[__DynamicallyInvokable]
		public bool SetLastError;

		// Token: 0x04002B0F RID: 11023
		[__DynamicallyInvokable]
		public bool ExactSpelling;

		// Token: 0x04002B10 RID: 11024
		[__DynamicallyInvokable]
		public bool PreserveSig;

		// Token: 0x04002B11 RID: 11025
		[__DynamicallyInvokable]
		public CallingConvention CallingConvention;

		// Token: 0x04002B12 RID: 11026
		[__DynamicallyInvokable]
		public bool BestFitMapping;

		// Token: 0x04002B13 RID: 11027
		[__DynamicallyInvokable]
		public bool ThrowOnUnmappableChar;
	}
}
