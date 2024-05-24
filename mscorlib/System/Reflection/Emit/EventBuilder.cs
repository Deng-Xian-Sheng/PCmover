using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	// Token: 0x02000638 RID: 1592
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_EventBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class EventBuilder : _EventBuilder
	{
		// Token: 0x06004A5D RID: 19037 RVA: 0x0010D2D7 File Offset: 0x0010B4D7
		private EventBuilder()
		{
		}

		// Token: 0x06004A5E RID: 19038 RVA: 0x0010D2DF File Offset: 0x0010B4DF
		internal EventBuilder(ModuleBuilder mod, string name, EventAttributes attr, TypeBuilder type, EventToken evToken)
		{
			this.m_name = name;
			this.m_module = mod;
			this.m_attributes = attr;
			this.m_evToken = evToken;
			this.m_type = type;
		}

		// Token: 0x06004A5F RID: 19039 RVA: 0x0010D30C File Offset: 0x0010B50C
		public EventToken GetEventToken()
		{
			return this.m_evToken;
		}

		// Token: 0x06004A60 RID: 19040 RVA: 0x0010D314 File Offset: 0x0010B514
		[SecurityCritical]
		private void SetMethodSemantics(MethodBuilder mdBuilder, MethodSemanticsAttributes semantics)
		{
			if (mdBuilder == null)
			{
				throw new ArgumentNullException("mdBuilder");
			}
			this.m_type.ThrowIfCreated();
			TypeBuilder.DefineMethodSemantics(this.m_module.GetNativeHandle(), this.m_evToken.Token, semantics, mdBuilder.GetToken().Token);
		}

		// Token: 0x06004A61 RID: 19041 RVA: 0x0010D36A File Offset: 0x0010B56A
		[SecuritySafeCritical]
		public void SetAddOnMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.AddOn);
		}

		// Token: 0x06004A62 RID: 19042 RVA: 0x0010D374 File Offset: 0x0010B574
		[SecuritySafeCritical]
		public void SetRemoveOnMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.RemoveOn);
		}

		// Token: 0x06004A63 RID: 19043 RVA: 0x0010D37F File Offset: 0x0010B57F
		[SecuritySafeCritical]
		public void SetRaiseMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Fire);
		}

		// Token: 0x06004A64 RID: 19044 RVA: 0x0010D38A File Offset: 0x0010B58A
		[SecuritySafeCritical]
		public void AddOtherMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Other);
		}

		// Token: 0x06004A65 RID: 19045 RVA: 0x0010D394 File Offset: 0x0010B594
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			if (binaryAttribute == null)
			{
				throw new ArgumentNullException("binaryAttribute");
			}
			this.m_type.ThrowIfCreated();
			TypeBuilder.DefineCustomAttribute(this.m_module, this.m_evToken.Token, this.m_module.GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		// Token: 0x06004A66 RID: 19046 RVA: 0x0010D3FB File Offset: 0x0010B5FB
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			this.m_type.ThrowIfCreated();
			customBuilder.CreateCustomAttribute(this.m_module, this.m_evToken.Token);
		}

		// Token: 0x06004A67 RID: 19047 RVA: 0x0010D42D File Offset: 0x0010B62D
		void _EventBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004A68 RID: 19048 RVA: 0x0010D434 File Offset: 0x0010B634
		void _EventBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004A69 RID: 19049 RVA: 0x0010D43B File Offset: 0x0010B63B
		void _EventBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004A6A RID: 19050 RVA: 0x0010D442 File Offset: 0x0010B642
		void _EventBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001EA7 RID: 7847
		private string m_name;

		// Token: 0x04001EA8 RID: 7848
		private EventToken m_evToken;

		// Token: 0x04001EA9 RID: 7849
		private ModuleBuilder m_module;

		// Token: 0x04001EAA RID: 7850
		private EventAttributes m_attributes;

		// Token: 0x04001EAB RID: 7851
		private TypeBuilder m_type;
	}
}
