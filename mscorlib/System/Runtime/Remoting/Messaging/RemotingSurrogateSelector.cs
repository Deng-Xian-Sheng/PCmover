using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200087A RID: 2170
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class RemotingSurrogateSelector : ISurrogateSelector
	{
		// Token: 0x06005C48 RID: 23624 RVA: 0x001436A7 File Offset: 0x001418A7
		public RemotingSurrogateSelector()
		{
			this._messageSurrogate = new MessageSurrogate(this);
		}

		// Token: 0x17000FDE RID: 4062
		// (get) Token: 0x06005C4A RID: 23626 RVA: 0x001436DA File Offset: 0x001418DA
		// (set) Token: 0x06005C49 RID: 23625 RVA: 0x001436D1 File Offset: 0x001418D1
		public MessageSurrogateFilter Filter
		{
			get
			{
				return this._filter;
			}
			set
			{
				this._filter = value;
			}
		}

		// Token: 0x06005C4B RID: 23627 RVA: 0x001436E4 File Offset: 0x001418E4
		public void SetRootObject(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			this._rootObj = obj;
			SoapMessageSurrogate soapMessageSurrogate = this._messageSurrogate as SoapMessageSurrogate;
			if (soapMessageSurrogate != null)
			{
				soapMessageSurrogate.SetRootObject(this._rootObj);
			}
		}

		// Token: 0x06005C4C RID: 23628 RVA: 0x00143721 File Offset: 0x00141921
		public object GetRootObject()
		{
			return this._rootObj;
		}

		// Token: 0x06005C4D RID: 23629 RVA: 0x00143729 File Offset: 0x00141929
		[SecurityCritical]
		public virtual void ChainSelector(ISurrogateSelector selector)
		{
			this._next = selector;
		}

		// Token: 0x06005C4E RID: 23630 RVA: 0x00143734 File Offset: 0x00141934
		[SecurityCritical]
		public virtual ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector ssout)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type.IsMarshalByRef)
			{
				ssout = this;
				return this._remotingSurrogate;
			}
			if (RemotingSurrogateSelector.s_IMethodCallMessageType.IsAssignableFrom(type) || RemotingSurrogateSelector.s_IMethodReturnMessageType.IsAssignableFrom(type))
			{
				ssout = this;
				return this._messageSurrogate;
			}
			if (RemotingSurrogateSelector.s_ObjRefType.IsAssignableFrom(type))
			{
				ssout = this;
				return this._objRefSurrogate;
			}
			if (this._next != null)
			{
				return this._next.GetSurrogate(type, context, out ssout);
			}
			ssout = null;
			return null;
		}

		// Token: 0x06005C4F RID: 23631 RVA: 0x001437BD File Offset: 0x001419BD
		[SecurityCritical]
		public virtual ISurrogateSelector GetNextSelector()
		{
			return this._next;
		}

		// Token: 0x06005C50 RID: 23632 RVA: 0x001437C5 File Offset: 0x001419C5
		public virtual void UseSoapFormat()
		{
			this._messageSurrogate = new SoapMessageSurrogate(this);
			((SoapMessageSurrogate)this._messageSurrogate).SetRootObject(this._rootObj);
		}

		// Token: 0x040029A7 RID: 10663
		private static Type s_IMethodCallMessageType = typeof(IMethodCallMessage);

		// Token: 0x040029A8 RID: 10664
		private static Type s_IMethodReturnMessageType = typeof(IMethodReturnMessage);

		// Token: 0x040029A9 RID: 10665
		private static Type s_ObjRefType = typeof(ObjRef);

		// Token: 0x040029AA RID: 10666
		private object _rootObj;

		// Token: 0x040029AB RID: 10667
		private ISurrogateSelector _next;

		// Token: 0x040029AC RID: 10668
		private RemotingSurrogate _remotingSurrogate = new RemotingSurrogate();

		// Token: 0x040029AD RID: 10669
		private ObjRefSurrogate _objRefSurrogate = new ObjRefSurrogate();

		// Token: 0x040029AE RID: 10670
		private ISerializationSurrogate _messageSurrogate;

		// Token: 0x040029AF RID: 10671
		private MessageSurrogateFilter _filter;
	}
}
