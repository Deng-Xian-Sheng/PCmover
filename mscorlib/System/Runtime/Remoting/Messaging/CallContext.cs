﻿using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200088A RID: 2186
	[SecurityCritical]
	[ComVisible(true)]
	[Serializable]
	public sealed class CallContext
	{
		// Token: 0x06005CA6 RID: 23718 RVA: 0x00144EF4 File Offset: 0x001430F4
		private CallContext()
		{
		}

		// Token: 0x06005CA7 RID: 23719 RVA: 0x00144EFC File Offset: 0x001430FC
		internal static LogicalCallContext SetLogicalCallContext(LogicalCallContext callCtx)
		{
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			LogicalCallContext logicalCallContext = mutableExecutionContext.LogicalCallContext;
			mutableExecutionContext.LogicalCallContext = callCtx;
			return logicalCallContext;
		}

		// Token: 0x06005CA8 RID: 23720 RVA: 0x00144F24 File Offset: 0x00143124
		[SecurityCritical]
		public static void FreeNamedDataSlot(string name)
		{
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			mutableExecutionContext.LogicalCallContext.FreeNamedDataSlot(name);
			mutableExecutionContext.IllogicalCallContext.FreeNamedDataSlot(name);
		}

		// Token: 0x06005CA9 RID: 23721 RVA: 0x00144F54 File Offset: 0x00143154
		[SecurityCritical]
		public static object LogicalGetData(string name)
		{
			return Thread.CurrentThread.GetExecutionContextReader().LogicalCallContext.GetData(name);
		}

		// Token: 0x06005CAA RID: 23722 RVA: 0x00144F7C File Offset: 0x0014317C
		private static object IllogicalGetData(string name)
		{
			return Thread.CurrentThread.GetExecutionContextReader().IllogicalCallContext.GetData(name);
		}

		// Token: 0x17000FEB RID: 4075
		// (get) Token: 0x06005CAB RID: 23723 RVA: 0x00144FA4 File Offset: 0x001431A4
		// (set) Token: 0x06005CAC RID: 23724 RVA: 0x00144FCB File Offset: 0x001431CB
		internal static IPrincipal Principal
		{
			[SecurityCritical]
			get
			{
				return Thread.CurrentThread.GetExecutionContextReader().LogicalCallContext.Principal;
			}
			[SecurityCritical]
			set
			{
				Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext.Principal = value;
			}
		}

		// Token: 0x17000FEC RID: 4076
		// (get) Token: 0x06005CAD RID: 23725 RVA: 0x00144FE4 File Offset: 0x001431E4
		// (set) Token: 0x06005CAE RID: 23726 RVA: 0x00145020 File Offset: 0x00143220
		public static object HostContext
		{
			[SecurityCritical]
			get
			{
				ExecutionContext.Reader executionContextReader = Thread.CurrentThread.GetExecutionContextReader();
				object hostContext = executionContextReader.IllogicalCallContext.HostContext;
				if (hostContext == null)
				{
					hostContext = executionContextReader.LogicalCallContext.HostContext;
				}
				return hostContext;
			}
			[SecurityCritical]
			set
			{
				ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
				if (value is ILogicalThreadAffinative)
				{
					mutableExecutionContext.IllogicalCallContext.HostContext = null;
					mutableExecutionContext.LogicalCallContext.HostContext = value;
					return;
				}
				mutableExecutionContext.IllogicalCallContext.HostContext = value;
				mutableExecutionContext.LogicalCallContext.HostContext = null;
			}
		}

		// Token: 0x06005CAF RID: 23727 RVA: 0x00145074 File Offset: 0x00143274
		[SecurityCritical]
		public static object GetData(string name)
		{
			object obj = CallContext.LogicalGetData(name);
			if (obj == null)
			{
				return CallContext.IllogicalGetData(name);
			}
			return obj;
		}

		// Token: 0x06005CB0 RID: 23728 RVA: 0x00145094 File Offset: 0x00143294
		[SecurityCritical]
		public static void SetData(string name, object data)
		{
			if (data is ILogicalThreadAffinative)
			{
				CallContext.LogicalSetData(name, data);
				return;
			}
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			mutableExecutionContext.LogicalCallContext.FreeNamedDataSlot(name);
			mutableExecutionContext.IllogicalCallContext.SetData(name, data);
		}

		// Token: 0x06005CB1 RID: 23729 RVA: 0x001450D8 File Offset: 0x001432D8
		[SecurityCritical]
		public static void LogicalSetData(string name, object data)
		{
			ExecutionContext mutableExecutionContext = Thread.CurrentThread.GetMutableExecutionContext();
			mutableExecutionContext.IllogicalCallContext.FreeNamedDataSlot(name);
			mutableExecutionContext.LogicalCallContext.SetData(name, data);
		}

		// Token: 0x06005CB2 RID: 23730 RVA: 0x0014510C File Offset: 0x0014330C
		[SecurityCritical]
		public static Header[] GetHeaders()
		{
			LogicalCallContext logicalCallContext = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			return logicalCallContext.InternalGetHeaders();
		}

		// Token: 0x06005CB3 RID: 23731 RVA: 0x00145130 File Offset: 0x00143330
		[SecurityCritical]
		public static void SetHeaders(Header[] headers)
		{
			LogicalCallContext logicalCallContext = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			logicalCallContext.InternalSetHeaders(headers);
		}
	}
}
