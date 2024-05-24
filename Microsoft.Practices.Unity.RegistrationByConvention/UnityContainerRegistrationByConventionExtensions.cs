using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity
{
	// Token: 0x02000007 RID: 7
	public static class UnityContainerRegistrationByConventionExtensions
	{
		// Token: 0x06000027 RID: 39 RVA: 0x000027FC File Offset: 0x000009FC
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Simplify API")]
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "API is easier to use with nested generics")]
		[SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Validation done by Guard class")]
		public static IUnityContainer RegisterTypes(this IUnityContainer container, IEnumerable<Type> types, Func<Type, IEnumerable<Type>> getFromTypes = null, Func<Type, string> getName = null, Func<Type, LifetimeManager> getLifetimeManager = null, Func<Type, IEnumerable<InjectionMember>> getInjectionMembers = null, bool overwriteExistingMappings = false)
		{
			Guard.ArgumentNotNull(container, "container");
			Guard.ArgumentNotNull(types, "types");
			if (getFromTypes == null)
			{
				getFromTypes = ((Type t) => UnityContainerRegistrationByConventionExtensions.EmptyTypes);
			}
			if (getName == null)
			{
				getName = ((Type t) => null);
			}
			if (getLifetimeManager == null)
			{
				getLifetimeManager = ((Type t) => null);
			}
			if (getInjectionMembers == null)
			{
				getInjectionMembers = ((Type t) => Enumerable.Empty<InjectionMember>());
			}
			Dictionary<NamedTypeBuildKey, Type> dictionary;
			if (overwriteExistingMappings)
			{
				dictionary = null;
			}
			else
			{
				dictionary = (from r in container.Registrations
				where r.RegisteredType != r.MappedToType
				select r).ToDictionary((ContainerRegistration r) => new NamedTypeBuildKey(r.RegisteredType, r.Name), (ContainerRegistration r) => r.MappedToType);
			}
			Dictionary<NamedTypeBuildKey, Type> mappings = dictionary;
			foreach (Type type in types)
			{
				IEnumerable<Type> fromTypes = getFromTypes(type);
				string name = getName(type);
				LifetimeManager lifetimeManager = getLifetimeManager(type);
				InjectionMember[] array = getInjectionMembers(type).ToArray<InjectionMember>();
				UnityContainerRegistrationByConventionExtensions.RegisterTypeMappings(container, overwriteExistingMappings, type, name, fromTypes, mappings);
				if (lifetimeManager != null || array.Length > 0)
				{
					container.RegisterType(type, name, lifetimeManager, array);
				}
			}
			return container;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000029A0 File Offset: 0x00000BA0
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Justification = "Validated with Guard class")]
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Simplify API")]
		public static IUnityContainer RegisterTypes(this IUnityContainer container, RegistrationConvention convention, bool overwriteExistingMappings = false)
		{
			Guard.ArgumentNotNull(convention, "convention");
			container.RegisterTypes(convention.GetTypes(), convention.GetFromTypes(), convention.GetName(), convention.GetLifetimeManager(), convention.GetInjectionMembers(), overwriteExistingMappings);
			return container;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000029E8 File Offset: 0x00000BE8
		private static void RegisterTypeMappings(IUnityContainer container, bool overwriteExistingMappings, Type type, string name, IEnumerable<Type> fromTypes, Dictionary<NamedTypeBuildKey, Type> mappings)
		{
			foreach (Type type2 in from t in fromTypes
			where t != typeof(IDisposable)
			select t)
			{
				if (!overwriteExistingMappings)
				{
					NamedTypeBuildKey key = new NamedTypeBuildKey(type2, name);
					Type type3;
					if (mappings.TryGetValue(key, out type3) && type != type3)
					{
						throw new DuplicateTypeMappingException(name, type2, type3, type);
					}
					mappings[key] = type;
				}
				container.RegisterType(type2, type, name, new InjectionMember[0]);
			}
		}

		// Token: 0x0400000D RID: 13
		private static readonly Type[] EmptyTypes = new Type[0];
	}
}
