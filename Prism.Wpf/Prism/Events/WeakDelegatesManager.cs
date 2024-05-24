using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism.Events
{
	// Token: 0x0200007E RID: 126
	internal class WeakDelegatesManager
	{
		// Token: 0x060003A0 RID: 928 RVA: 0x00009459 File Offset: 0x00007659
		public void AddListener(Delegate listener)
		{
			this.listeners.Add(new DelegateReference(listener, false));
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00009470 File Offset: 0x00007670
		public void RemoveListener(Delegate listener)
		{
			this.listeners.RemoveAll(delegate(DelegateReference reference)
			{
				Delegate target = reference.Target;
				return listener.Equals(target) || target == null;
			});
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000094A4 File Offset: 0x000076A4
		public void Raise(params object[] args)
		{
			this.listeners.RemoveAll((DelegateReference listener) => listener.Target == null);
			foreach (Delegate @delegate in from listener in this.listeners.ToList<DelegateReference>()
			select listener.Target into listener
			where listener != null
			select listener)
			{
				@delegate.DynamicInvoke(args);
			}
		}

		// Token: 0x040000B6 RID: 182
		private readonly List<DelegateReference> listeners = new List<DelegateReference>();
	}
}
