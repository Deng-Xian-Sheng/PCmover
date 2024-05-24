using System;

namespace Prism.Events
{
	// Token: 0x0200001C RID: 28
	public class SubscriptionToken : IEquatable<SubscriptionToken>, IDisposable
	{
		// Token: 0x06000072 RID: 114 RVA: 0x0000306C File Offset: 0x0000126C
		public SubscriptionToken(Action<SubscriptionToken> unsubscribeAction)
		{
			this._unsubscribeAction = unsubscribeAction;
			this._token = Guid.NewGuid();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003086 File Offset: 0x00001286
		public bool Equals(SubscriptionToken other)
		{
			return other != null && object.Equals(this._token, other._token);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000030A8 File Offset: 0x000012A8
		public override bool Equals(object obj)
		{
			return this == obj || this.Equals(obj as SubscriptionToken);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000030BC File Offset: 0x000012BC
		public override int GetHashCode()
		{
			return this._token.GetHashCode();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000030DD File Offset: 0x000012DD
		public virtual void Dispose()
		{
			if (this._unsubscribeAction != null)
			{
				this._unsubscribeAction(this);
				this._unsubscribeAction = null;
			}
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000026 RID: 38
		private readonly Guid _token;

		// Token: 0x04000027 RID: 39
		private Action<SubscriptionToken> _unsubscribeAction;
	}
}
