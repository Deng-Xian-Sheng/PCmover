using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	// Token: 0x02000644 RID: 1604
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_LocalBuilder))]
	[ComVisible(true)]
	public sealed class LocalBuilder : LocalVariableInfo, _LocalBuilder
	{
		// Token: 0x06004B07 RID: 19207 RVA: 0x0010FD93 File Offset: 0x0010DF93
		private LocalBuilder()
		{
		}

		// Token: 0x06004B08 RID: 19208 RVA: 0x0010FD9B File Offset: 0x0010DF9B
		internal LocalBuilder(int localIndex, Type localType, MethodInfo methodBuilder) : this(localIndex, localType, methodBuilder, false)
		{
		}

		// Token: 0x06004B09 RID: 19209 RVA: 0x0010FDA7 File Offset: 0x0010DFA7
		internal LocalBuilder(int localIndex, Type localType, MethodInfo methodBuilder, bool isPinned)
		{
			this.m_isPinned = isPinned;
			this.m_localIndex = localIndex;
			this.m_localType = localType;
			this.m_methodBuilder = methodBuilder;
		}

		// Token: 0x06004B0A RID: 19210 RVA: 0x0010FDCC File Offset: 0x0010DFCC
		internal int GetLocalIndex()
		{
			return this.m_localIndex;
		}

		// Token: 0x06004B0B RID: 19211 RVA: 0x0010FDD4 File Offset: 0x0010DFD4
		internal MethodInfo GetMethodBuilder()
		{
			return this.m_methodBuilder;
		}

		// Token: 0x17000BAD RID: 2989
		// (get) Token: 0x06004B0C RID: 19212 RVA: 0x0010FDDC File Offset: 0x0010DFDC
		public override bool IsPinned
		{
			get
			{
				return this.m_isPinned;
			}
		}

		// Token: 0x17000BAE RID: 2990
		// (get) Token: 0x06004B0D RID: 19213 RVA: 0x0010FDE4 File Offset: 0x0010DFE4
		public override Type LocalType
		{
			get
			{
				return this.m_localType;
			}
		}

		// Token: 0x17000BAF RID: 2991
		// (get) Token: 0x06004B0E RID: 19214 RVA: 0x0010FDEC File Offset: 0x0010DFEC
		public override int LocalIndex
		{
			get
			{
				return this.m_localIndex;
			}
		}

		// Token: 0x06004B0F RID: 19215 RVA: 0x0010FDF4 File Offset: 0x0010DFF4
		public void SetLocalSymInfo(string name)
		{
			this.SetLocalSymInfo(name, 0, 0);
		}

		// Token: 0x06004B10 RID: 19216 RVA: 0x0010FE00 File Offset: 0x0010E000
		public void SetLocalSymInfo(string name, int startOffset, int endOffset)
		{
			MethodBuilder methodBuilder = this.m_methodBuilder as MethodBuilder;
			if (methodBuilder == null)
			{
				throw new NotSupportedException();
			}
			ModuleBuilder moduleBuilder = (ModuleBuilder)methodBuilder.Module;
			if (methodBuilder.IsTypeCreated())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TypeHasBeenCreated"));
			}
			if (moduleBuilder.GetSymWriter() == null)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NotADebugModule"));
			}
			SignatureHelper fieldSigHelper = SignatureHelper.GetFieldSigHelper(moduleBuilder);
			fieldSigHelper.AddArgument(this.m_localType);
			int num;
			byte[] sourceArray = fieldSigHelper.InternalGetSignature(out num);
			byte[] array = new byte[num - 1];
			Array.Copy(sourceArray, 1, array, 0, num - 1);
			int currentActiveScopeIndex = methodBuilder.GetILGenerator().m_ScopeTree.GetCurrentActiveScopeIndex();
			if (currentActiveScopeIndex == -1)
			{
				methodBuilder.m_localSymInfo.AddLocalSymInfo(name, array, this.m_localIndex, startOffset, endOffset);
				return;
			}
			methodBuilder.GetILGenerator().m_ScopeTree.AddLocalSymInfoToCurrentScope(name, array, this.m_localIndex, startOffset, endOffset);
		}

		// Token: 0x06004B11 RID: 19217 RVA: 0x0010FEE7 File Offset: 0x0010E0E7
		void _LocalBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004B12 RID: 19218 RVA: 0x0010FEEE File Offset: 0x0010E0EE
		void _LocalBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004B13 RID: 19219 RVA: 0x0010FEF5 File Offset: 0x0010E0F5
		void _LocalBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004B14 RID: 19220 RVA: 0x0010FEFC File Offset: 0x0010E0FC
		void _LocalBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001EFF RID: 7935
		private int m_localIndex;

		// Token: 0x04001F00 RID: 7936
		private Type m_localType;

		// Token: 0x04001F01 RID: 7937
		private MethodInfo m_methodBuilder;

		// Token: 0x04001F02 RID: 7938
		private bool m_isPinned;
	}
}
