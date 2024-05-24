using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Practices.Unity
{
	// Token: 0x02000008 RID: 8
	public static class WithLifetime
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00002A9D File Offset: 0x00000C9D
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager None(Type type)
		{
			return null;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002AA0 File Offset: 0x00000CA0
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The purpose of the method is to return a new instance")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager ContainerControlled(Type type)
		{
			return new ContainerControlledLifetimeManager();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002AA7 File Offset: 0x00000CA7
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager ExternallyControlled(Type type)
		{
			return new ExternallyControlledLifetimeManager();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002AAE File Offset: 0x00000CAE
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The purpose of the method is to return a new instance")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager Hierarchical(Type type)
		{
			return new HierarchicalLifetimeManager();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002AB5 File Offset: 0x00000CB5
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager PerResolve(Type type)
		{
			return new PerResolveLifetimeManager();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002ABC File Offset: 0x00000CBC
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager Transient(Type type)
		{
			return new TransientLifetimeManager();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002AC3 File Offset: 0x00000CC3
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "As designed")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager Custom<T>(Type type) where T : LifetimeManager, new()
		{
			return Activator.CreateInstance<T>();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002ACF File Offset: 0x00000CCF
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "type", Justification = "Need to match signature Func<Type, string>")]
		public static LifetimeManager PerThread(Type type)
		{
			return new PerThreadLifetimeManager();
		}
	}
}
