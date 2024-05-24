using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace Prism.Unity
{
	// Token: 0x02000003 RID: 3
	public class UnityBootstrapperExtension : UnityContainerExtension
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002560 File Offset: 0x00000760
		public static bool IsTypeRegistered(IUnityContainer container, Type type)
		{
			UnityBootstrapperExtension unityBootstrapperExtension = container.Configure<UnityBootstrapperExtension>();
			return unityBootstrapperExtension != null && unityBootstrapperExtension.Context.Policies.Get(new NamedTypeBuildKey(type)) != null;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002592 File Offset: 0x00000792
		protected override void Initialize()
		{
		}
	}
}
