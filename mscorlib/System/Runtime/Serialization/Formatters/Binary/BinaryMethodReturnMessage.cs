using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x020007A6 RID: 1958
	[Serializable]
	internal class BinaryMethodReturnMessage
	{
		// Token: 0x060054F4 RID: 21748 RVA: 0x0012E08C File Offset: 0x0012C28C
		[SecurityCritical]
		internal BinaryMethodReturnMessage(object returnValue, object[] args, Exception e, LogicalCallContext callContext, object[] properties)
		{
			this._returnValue = returnValue;
			if (args == null)
			{
				args = new object[0];
			}
			this._outargs = args;
			this._args = args;
			this._exception = e;
			if (callContext == null)
			{
				this._logicalCallContext = new LogicalCallContext();
			}
			else
			{
				this._logicalCallContext = callContext;
			}
			this._properties = properties;
		}

		// Token: 0x17000DEA RID: 3562
		// (get) Token: 0x060054F5 RID: 21749 RVA: 0x0012E0E7 File Offset: 0x0012C2E7
		public Exception Exception
		{
			get
			{
				return this._exception;
			}
		}

		// Token: 0x17000DEB RID: 3563
		// (get) Token: 0x060054F6 RID: 21750 RVA: 0x0012E0EF File Offset: 0x0012C2EF
		public object ReturnValue
		{
			get
			{
				return this._returnValue;
			}
		}

		// Token: 0x17000DEC RID: 3564
		// (get) Token: 0x060054F7 RID: 21751 RVA: 0x0012E0F7 File Offset: 0x0012C2F7
		public object[] Args
		{
			get
			{
				return this._args;
			}
		}

		// Token: 0x17000DED RID: 3565
		// (get) Token: 0x060054F8 RID: 21752 RVA: 0x0012E0FF File Offset: 0x0012C2FF
		public LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this._logicalCallContext;
			}
		}

		// Token: 0x17000DEE RID: 3566
		// (get) Token: 0x060054F9 RID: 21753 RVA: 0x0012E107 File Offset: 0x0012C307
		public bool HasProperties
		{
			get
			{
				return this._properties != null;
			}
		}

		// Token: 0x060054FA RID: 21754 RVA: 0x0012E114 File Offset: 0x0012C314
		internal void PopulateMessageProperties(IDictionary dict)
		{
			foreach (DictionaryEntry dictionaryEntry in this._properties)
			{
				dict[dictionaryEntry.Key] = dictionaryEntry.Value;
			}
		}

		// Token: 0x04002712 RID: 10002
		private object[] _outargs;

		// Token: 0x04002713 RID: 10003
		private Exception _exception;

		// Token: 0x04002714 RID: 10004
		private object _returnValue;

		// Token: 0x04002715 RID: 10005
		private object[] _args;

		// Token: 0x04002716 RID: 10006
		[SecurityCritical]
		private LogicalCallContext _logicalCallContext;

		// Token: 0x04002717 RID: 10007
		private object[] _properties;
	}
}
