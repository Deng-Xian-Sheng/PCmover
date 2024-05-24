using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Practices.ServiceLocation;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x02000026 RID: 38
	public class RegionBehaviorFactory : IRegionBehaviorFactory, IEnumerable<string>, IEnumerable
	{
		// Token: 0x060000EA RID: 234 RVA: 0x0000361A File Offset: 0x0000181A
		public RegionBehaviorFactory(IServiceLocator serviceLocator)
		{
			this.serviceLocator = serviceLocator;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003634 File Offset: 0x00001834
		public void AddIfMissing(string behaviorKey, Type behaviorType)
		{
			if (behaviorKey == null)
			{
				throw new ArgumentNullException("behaviorKey");
			}
			if (behaviorType == null)
			{
				throw new ArgumentNullException("behaviorType");
			}
			if (!typeof(IRegionBehavior).IsAssignableFrom(behaviorType))
			{
				throw new ArgumentException(string.Format(Thread.CurrentThread.CurrentCulture, Resources.CanOnlyAddTypesThatInheritIFromRegionBehavior, new object[]
				{
					behaviorType.Name
				}), "behaviorType");
			}
			if (this.registeredBehaviors.ContainsKey(behaviorKey))
			{
				return;
			}
			this.registeredBehaviors.Add(behaviorKey, behaviorType);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000036C0 File Offset: 0x000018C0
		public IRegionBehavior CreateFromKey(string key)
		{
			if (!this.ContainsKey(key))
			{
				throw new ArgumentException(string.Format(Thread.CurrentThread.CurrentCulture, Resources.TypeWithKeyNotRegistered, new object[]
				{
					key
				}), "key");
			}
			return (IRegionBehavior)this.serviceLocator.GetInstance(this.registeredBehaviors[key]);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000371B File Offset: 0x0000191B
		public IEnumerator<string> GetEnumerator()
		{
			return this.registeredBehaviors.Keys.GetEnumerator();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003732 File Offset: 0x00001932
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000373A File Offset: 0x0000193A
		public bool ContainsKey(string behaviorKey)
		{
			return this.registeredBehaviors.ContainsKey(behaviorKey);
		}

		// Token: 0x04000020 RID: 32
		private readonly IServiceLocator serviceLocator;

		// Token: 0x04000021 RID: 33
		private readonly Dictionary<string, Type> registeredBehaviors = new Dictionary<string, Type>();
	}
}
