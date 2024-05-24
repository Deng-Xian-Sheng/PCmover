using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x020007A5 RID: 1957
	[Serializable]
	internal sealed class BinaryMethodCallMessage
	{
		// Token: 0x060054EB RID: 21739 RVA: 0x0012DFA0 File Offset: 0x0012C1A0
		[SecurityCritical]
		internal BinaryMethodCallMessage(string uri, string methodName, string typeName, Type[] instArgs, object[] args, object methodSignature, LogicalCallContext callContext, object[] properties)
		{
			this._methodName = methodName;
			this._typeName = typeName;
			if (args == null)
			{
				args = new object[0];
			}
			this._inargs = args;
			this._args = args;
			this._instArgs = instArgs;
			this._methodSignature = methodSignature;
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

		// Token: 0x17000DE3 RID: 3555
		// (get) Token: 0x060054EC RID: 21740 RVA: 0x0012E00E File Offset: 0x0012C20E
		public string MethodName
		{
			get
			{
				return this._methodName;
			}
		}

		// Token: 0x17000DE4 RID: 3556
		// (get) Token: 0x060054ED RID: 21741 RVA: 0x0012E016 File Offset: 0x0012C216
		public string TypeName
		{
			get
			{
				return this._typeName;
			}
		}

		// Token: 0x17000DE5 RID: 3557
		// (get) Token: 0x060054EE RID: 21742 RVA: 0x0012E01E File Offset: 0x0012C21E
		public Type[] InstantiationArgs
		{
			get
			{
				return this._instArgs;
			}
		}

		// Token: 0x17000DE6 RID: 3558
		// (get) Token: 0x060054EF RID: 21743 RVA: 0x0012E026 File Offset: 0x0012C226
		public object MethodSignature
		{
			get
			{
				return this._methodSignature;
			}
		}

		// Token: 0x17000DE7 RID: 3559
		// (get) Token: 0x060054F0 RID: 21744 RVA: 0x0012E02E File Offset: 0x0012C22E
		public object[] Args
		{
			get
			{
				return this._args;
			}
		}

		// Token: 0x17000DE8 RID: 3560
		// (get) Token: 0x060054F1 RID: 21745 RVA: 0x0012E036 File Offset: 0x0012C236
		public LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this._logicalCallContext;
			}
		}

		// Token: 0x17000DE9 RID: 3561
		// (get) Token: 0x060054F2 RID: 21746 RVA: 0x0012E03E File Offset: 0x0012C23E
		public bool HasProperties
		{
			get
			{
				return this._properties != null;
			}
		}

		// Token: 0x060054F3 RID: 21747 RVA: 0x0012E04C File Offset: 0x0012C24C
		internal void PopulateMessageProperties(IDictionary dict)
		{
			foreach (DictionaryEntry dictionaryEntry in this._properties)
			{
				dict[dictionaryEntry.Key] = dictionaryEntry.Value;
			}
		}

		// Token: 0x0400270A RID: 9994
		private object[] _inargs;

		// Token: 0x0400270B RID: 9995
		private string _methodName;

		// Token: 0x0400270C RID: 9996
		private string _typeName;

		// Token: 0x0400270D RID: 9997
		private object _methodSignature;

		// Token: 0x0400270E RID: 9998
		private Type[] _instArgs;

		// Token: 0x0400270F RID: 9999
		private object[] _args;

		// Token: 0x04002710 RID: 10000
		[SecurityCritical]
		private LogicalCallContext _logicalCallContext;

		// Token: 0x04002711 RID: 10001
		private object[] _properties;
	}
}
