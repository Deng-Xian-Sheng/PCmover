using System;
using System.Runtime.Serialization;
using System.Security;

namespace System.Diagnostics.Contracts
{
	// Token: 0x02000417 RID: 1047
	[Serializable]
	internal sealed class ContractException : Exception
	{
		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x0600341F RID: 13343 RVA: 0x000C6B63 File Offset: 0x000C4D63
		public ContractFailureKind Kind
		{
			get
			{
				return this._Kind;
			}
		}

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x06003420 RID: 13344 RVA: 0x000C6B6B File Offset: 0x000C4D6B
		public string Failure
		{
			get
			{
				return this.Message;
			}
		}

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x06003421 RID: 13345 RVA: 0x000C6B73 File Offset: 0x000C4D73
		public string UserMessage
		{
			get
			{
				return this._UserMessage;
			}
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x06003422 RID: 13346 RVA: 0x000C6B7B File Offset: 0x000C4D7B
		public string Condition
		{
			get
			{
				return this._Condition;
			}
		}

		// Token: 0x06003423 RID: 13347 RVA: 0x000C6B83 File Offset: 0x000C4D83
		private ContractException()
		{
			base.HResult = -2146233022;
		}

		// Token: 0x06003424 RID: 13348 RVA: 0x000C6B96 File Offset: 0x000C4D96
		public ContractException(ContractFailureKind kind, string failure, string userMessage, string condition, Exception innerException) : base(failure, innerException)
		{
			base.HResult = -2146233022;
			this._Kind = kind;
			this._UserMessage = userMessage;
			this._Condition = condition;
		}

		// Token: 0x06003425 RID: 13349 RVA: 0x000C6BC2 File Offset: 0x000C4DC2
		private ContractException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._Kind = (ContractFailureKind)info.GetInt32("Kind");
			this._UserMessage = info.GetString("UserMessage");
			this._Condition = info.GetString("Condition");
		}

		// Token: 0x06003426 RID: 13350 RVA: 0x000C6C00 File Offset: 0x000C4E00
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Kind", this._Kind);
			info.AddValue("UserMessage", this._UserMessage);
			info.AddValue("Condition", this._Condition);
		}

		// Token: 0x04001717 RID: 5911
		private readonly ContractFailureKind _Kind;

		// Token: 0x04001718 RID: 5912
		private readonly string _UserMessage;

		// Token: 0x04001719 RID: 5913
		private readonly string _Condition;
	}
}
