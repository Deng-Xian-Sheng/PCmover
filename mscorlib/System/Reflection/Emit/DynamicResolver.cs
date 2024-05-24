using System;
using System.Security;
using System.Threading;

namespace System.Reflection.Emit
{
	// Token: 0x02000631 RID: 1585
	internal class DynamicResolver : Resolver
	{
		// Token: 0x060049F7 RID: 18935 RVA: 0x0010BB9C File Offset: 0x00109D9C
		internal DynamicResolver(DynamicILGenerator ilGenerator)
		{
			this.m_stackSize = ilGenerator.GetMaxStackSize();
			this.m_exceptions = ilGenerator.GetExceptions();
			this.m_code = ilGenerator.BakeByteArray();
			this.m_localSignature = ilGenerator.m_localSignature.InternalGetSignatureArray();
			this.m_scope = ilGenerator.m_scope;
			this.m_method = (DynamicMethod)ilGenerator.m_methodBuilder;
			this.m_method.m_resolver = this;
		}

		// Token: 0x060049F8 RID: 18936 RVA: 0x0010BC10 File Offset: 0x00109E10
		internal DynamicResolver(DynamicILInfo dynamicILInfo)
		{
			this.m_stackSize = dynamicILInfo.MaxStackSize;
			this.m_code = dynamicILInfo.Code;
			this.m_localSignature = dynamicILInfo.LocalSignature;
			this.m_exceptionHeader = dynamicILInfo.Exceptions;
			this.m_scope = dynamicILInfo.DynamicScope;
			this.m_method = dynamicILInfo.DynamicMethod;
			this.m_method.m_resolver = this;
		}

		// Token: 0x060049F9 RID: 18937 RVA: 0x0010BC78 File Offset: 0x00109E78
		protected override void Finalize()
		{
			try
			{
				DynamicMethod method = this.m_method;
				if (!(method == null))
				{
					if (method.m_methodHandle != null)
					{
						DynamicResolver.DestroyScout destroyScout = null;
						try
						{
							destroyScout = new DynamicResolver.DestroyScout();
						}
						catch
						{
							if (!Environment.HasShutdownStarted && !AppDomain.CurrentDomain.IsFinalizingForUnload())
							{
								GC.ReRegisterForFinalize(this);
							}
							return;
						}
						destroyScout.m_methodHandle = method.m_methodHandle.Value;
					}
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x060049FA RID: 18938 RVA: 0x0010BD00 File Offset: 0x00109F00
		internal override RuntimeType GetJitContext(ref int securityControlFlags)
		{
			DynamicResolver.SecurityControlFlags securityControlFlags2 = DynamicResolver.SecurityControlFlags.Default;
			if (this.m_method.m_restrictedSkipVisibility)
			{
				securityControlFlags2 |= DynamicResolver.SecurityControlFlags.RestrictedSkipVisibilityChecks;
			}
			else if (this.m_method.m_skipVisibility)
			{
				securityControlFlags2 |= DynamicResolver.SecurityControlFlags.SkipVisibilityChecks;
			}
			RuntimeType typeOwner = this.m_method.m_typeOwner;
			if (this.m_method.m_creationContext != null)
			{
				securityControlFlags2 |= DynamicResolver.SecurityControlFlags.HasCreationContext;
				if (this.m_method.m_creationContext.CanSkipEvaluation)
				{
					securityControlFlags2 |= DynamicResolver.SecurityControlFlags.CanSkipCSEvaluation;
				}
			}
			securityControlFlags = (int)securityControlFlags2;
			return typeOwner;
		}

		// Token: 0x060049FB RID: 18939 RVA: 0x0010BD6C File Offset: 0x00109F6C
		private static int CalculateNumberOfExceptions(__ExceptionInfo[] excp)
		{
			int num = 0;
			if (excp == null)
			{
				return 0;
			}
			for (int i = 0; i < excp.Length; i++)
			{
				num += excp[i].GetNumberOfCatches();
			}
			return num;
		}

		// Token: 0x060049FC RID: 18940 RVA: 0x0010BD9C File Offset: 0x00109F9C
		internal override byte[] GetCodeInfo(ref int stackSize, ref int initLocals, ref int EHCount)
		{
			stackSize = this.m_stackSize;
			if (this.m_exceptionHeader != null && this.m_exceptionHeader.Length != 0)
			{
				if (this.m_exceptionHeader.Length < 4)
				{
					throw new FormatException();
				}
				byte b = this.m_exceptionHeader[0];
				if ((b & 64) != 0)
				{
					byte[] array = new byte[4];
					for (int i = 0; i < 3; i++)
					{
						array[i] = this.m_exceptionHeader[i + 1];
					}
					EHCount = (BitConverter.ToInt32(array, 0) - 4) / 24;
				}
				else
				{
					EHCount = (int)((this.m_exceptionHeader[1] - 2) / 12);
				}
			}
			else
			{
				EHCount = DynamicResolver.CalculateNumberOfExceptions(this.m_exceptions);
			}
			initLocals = (this.m_method.InitLocals ? 1 : 0);
			return this.m_code;
		}

		// Token: 0x060049FD RID: 18941 RVA: 0x0010BE49 File Offset: 0x0010A049
		internal override byte[] GetLocalsSignature()
		{
			return this.m_localSignature;
		}

		// Token: 0x060049FE RID: 18942 RVA: 0x0010BE51 File Offset: 0x0010A051
		internal override byte[] GetRawEHInfo()
		{
			return this.m_exceptionHeader;
		}

		// Token: 0x060049FF RID: 18943 RVA: 0x0010BE5C File Offset: 0x0010A05C
		[SecurityCritical]
		internal unsafe override void GetEHInfo(int excNumber, void* exc)
		{
			for (int i = 0; i < this.m_exceptions.Length; i++)
			{
				int numberOfCatches = this.m_exceptions[i].GetNumberOfCatches();
				if (excNumber < numberOfCatches)
				{
					((Resolver.CORINFO_EH_CLAUSE*)exc)->Flags = this.m_exceptions[i].GetExceptionTypes()[excNumber];
					((Resolver.CORINFO_EH_CLAUSE*)exc)->TryOffset = this.m_exceptions[i].GetStartAddress();
					if ((((Resolver.CORINFO_EH_CLAUSE*)exc)->Flags & 2) != 2)
					{
						((Resolver.CORINFO_EH_CLAUSE*)exc)->TryLength = this.m_exceptions[i].GetEndAddress() - ((Resolver.CORINFO_EH_CLAUSE*)exc)->TryOffset;
					}
					else
					{
						((Resolver.CORINFO_EH_CLAUSE*)exc)->TryLength = this.m_exceptions[i].GetFinallyEndAddress() - ((Resolver.CORINFO_EH_CLAUSE*)exc)->TryOffset;
					}
					((Resolver.CORINFO_EH_CLAUSE*)exc)->HandlerOffset = this.m_exceptions[i].GetCatchAddresses()[excNumber];
					((Resolver.CORINFO_EH_CLAUSE*)exc)->HandlerLength = this.m_exceptions[i].GetCatchEndAddresses()[excNumber] - ((Resolver.CORINFO_EH_CLAUSE*)exc)->HandlerOffset;
					((Resolver.CORINFO_EH_CLAUSE*)exc)->ClassTokenOrFilterOffset = this.m_exceptions[i].GetFilterAddresses()[excNumber];
					return;
				}
				excNumber -= numberOfCatches;
			}
		}

		// Token: 0x06004A00 RID: 18944 RVA: 0x0010BF4E File Offset: 0x0010A14E
		internal override string GetStringLiteral(int token)
		{
			return this.m_scope.GetString(token);
		}

		// Token: 0x06004A01 RID: 18945 RVA: 0x0010BF5C File Offset: 0x0010A15C
		internal override CompressedStack GetSecurityContext()
		{
			return this.m_method.m_creationContext;
		}

		// Token: 0x06004A02 RID: 18946 RVA: 0x0010BF6C File Offset: 0x0010A16C
		[SecurityCritical]
		internal override void ResolveToken(int token, out IntPtr typeHandle, out IntPtr methodHandle, out IntPtr fieldHandle)
		{
			typeHandle = 0;
			methodHandle = 0;
			fieldHandle = 0;
			object obj = this.m_scope[token];
			if (obj == null)
			{
				throw new InvalidProgramException();
			}
			if (obj is RuntimeTypeHandle)
			{
				typeHandle = ((RuntimeTypeHandle)obj).Value;
				return;
			}
			if (obj is RuntimeMethodHandle)
			{
				methodHandle = ((RuntimeMethodHandle)obj).Value;
				return;
			}
			if (obj is RuntimeFieldHandle)
			{
				fieldHandle = ((RuntimeFieldHandle)obj).Value;
				return;
			}
			DynamicMethod dynamicMethod = obj as DynamicMethod;
			if (dynamicMethod != null)
			{
				methodHandle = dynamicMethod.GetMethodDescriptor().Value;
				return;
			}
			GenericMethodInfo genericMethodInfo = obj as GenericMethodInfo;
			if (genericMethodInfo != null)
			{
				methodHandle = genericMethodInfo.m_methodHandle.Value;
				typeHandle = genericMethodInfo.m_context.Value;
				return;
			}
			GenericFieldInfo genericFieldInfo = obj as GenericFieldInfo;
			if (genericFieldInfo != null)
			{
				fieldHandle = genericFieldInfo.m_fieldHandle.Value;
				typeHandle = genericFieldInfo.m_context.Value;
				return;
			}
			VarArgMethod varArgMethod = obj as VarArgMethod;
			if (varArgMethod == null)
			{
				return;
			}
			if (varArgMethod.m_dynamicMethod == null)
			{
				methodHandle = varArgMethod.m_method.MethodHandle.Value;
				typeHandle = varArgMethod.m_method.GetDeclaringTypeInternal().GetTypeHandleInternal().Value;
				return;
			}
			methodHandle = varArgMethod.m_dynamicMethod.GetMethodDescriptor().Value;
		}

		// Token: 0x06004A03 RID: 18947 RVA: 0x0010C0C8 File Offset: 0x0010A2C8
		internal override byte[] ResolveSignature(int token, int fromMethod)
		{
			return this.m_scope.ResolveSignature(token, fromMethod);
		}

		// Token: 0x06004A04 RID: 18948 RVA: 0x0010C0D7 File Offset: 0x0010A2D7
		internal override MethodInfo GetDynamicMethod()
		{
			return this.m_method.GetMethodInfo();
		}

		// Token: 0x04001E80 RID: 7808
		private __ExceptionInfo[] m_exceptions;

		// Token: 0x04001E81 RID: 7809
		private byte[] m_exceptionHeader;

		// Token: 0x04001E82 RID: 7810
		private DynamicMethod m_method;

		// Token: 0x04001E83 RID: 7811
		private byte[] m_code;

		// Token: 0x04001E84 RID: 7812
		private byte[] m_localSignature;

		// Token: 0x04001E85 RID: 7813
		private int m_stackSize;

		// Token: 0x04001E86 RID: 7814
		private DynamicScope m_scope;

		// Token: 0x02000C3D RID: 3133
		private class DestroyScout
		{
			// Token: 0x06007047 RID: 28743 RVA: 0x00182F3C File Offset: 0x0018113C
			[SecuritySafeCritical]
			~DestroyScout()
			{
				if (!this.m_methodHandle.IsNullHandle())
				{
					if (RuntimeMethodHandle.GetResolver(this.m_methodHandle) != null)
					{
						if (!Environment.HasShutdownStarted && !AppDomain.CurrentDomain.IsFinalizingForUnload())
						{
							GC.ReRegisterForFinalize(this);
						}
					}
					else
					{
						RuntimeMethodHandle.Destroy(this.m_methodHandle);
					}
				}
			}

			// Token: 0x04003746 RID: 14150
			internal RuntimeMethodHandleInternal m_methodHandle;
		}

		// Token: 0x02000C3E RID: 3134
		[Flags]
		internal enum SecurityControlFlags
		{
			// Token: 0x04003748 RID: 14152
			Default = 0,
			// Token: 0x04003749 RID: 14153
			SkipVisibilityChecks = 1,
			// Token: 0x0400374A RID: 14154
			RestrictedSkipVisibilityChecks = 2,
			// Token: 0x0400374B RID: 14155
			HasCreationContext = 4,
			// Token: 0x0400374C RID: 14156
			CanSkipCSEvaluation = 8
		}
	}
}
