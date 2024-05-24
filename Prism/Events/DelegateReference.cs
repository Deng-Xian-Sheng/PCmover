using System;
using System.Reflection;

namespace Prism.Events
{
	// Token: 0x02000010 RID: 16
	public class DelegateReference : IDelegateReference
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000026A0 File Offset: 0x000008A0
		public DelegateReference(Delegate @delegate, bool keepReferenceAlive)
		{
			if (@delegate == null)
			{
				throw new ArgumentNullException("delegate");
			}
			if (keepReferenceAlive)
			{
				this._delegate = @delegate;
				return;
			}
			this._weakReference = new WeakReference(@delegate.Target);
			this._method = @delegate.GetMethodInfo();
			this._delegateType = @delegate.GetType();
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000026F5 File Offset: 0x000008F5
		public Delegate Target
		{
			get
			{
				if (this._delegate != null)
				{
					return this._delegate;
				}
				return this.TryGetDelegate();
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000270C File Offset: 0x0000090C
		private Delegate TryGetDelegate()
		{
			if (this._method.IsStatic)
			{
				return this._method.CreateDelegate(this._delegateType, null);
			}
			object target = this._weakReference.Target;
			if (target != null)
			{
				return this._method.CreateDelegate(this._delegateType, target);
			}
			return null;
		}

		// Token: 0x04000017 RID: 23
		private readonly Delegate _delegate;

		// Token: 0x04000018 RID: 24
		private readonly WeakReference _weakReference;

		// Token: 0x04000019 RID: 25
		private readonly MethodInfo _method;

		// Token: 0x0400001A RID: 26
		private readonly Type _delegateType;
	}
}
