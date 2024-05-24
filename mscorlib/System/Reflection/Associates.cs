﻿using System;
using System.Collections.Generic;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005CB RID: 1483
	internal static class Associates
	{
		// Token: 0x060044AF RID: 17583 RVA: 0x000FCD36 File Offset: 0x000FAF36
		internal static bool IncludeAccessor(MethodInfo associate, bool nonPublic)
		{
			return associate != null && (nonPublic || associate.IsPublic);
		}

		// Token: 0x060044B0 RID: 17584 RVA: 0x000FCD50 File Offset: 0x000FAF50
		[SecurityCritical]
		private static RuntimeMethodInfo AssignAssociates(int tkMethod, RuntimeType declaredType, RuntimeType reflectedType)
		{
			if (MetadataToken.IsNullToken(tkMethod))
			{
				return null;
			}
			bool flag = declaredType != reflectedType;
			IntPtr[] array = null;
			int typeInstCount = 0;
			RuntimeType[] instantiationInternal = declaredType.GetTypeHandleInternal().GetInstantiationInternal();
			if (instantiationInternal != null)
			{
				typeInstCount = instantiationInternal.Length;
				array = new IntPtr[instantiationInternal.Length];
				for (int i = 0; i < instantiationInternal.Length; i++)
				{
					array[i] = instantiationInternal[i].GetTypeHandleInternal().Value;
				}
			}
			RuntimeMethodHandleInternal runtimeMethodHandleInternal = ModuleHandle.ResolveMethodHandleInternalCore(RuntimeTypeHandle.GetModule(declaredType), tkMethod, array, typeInstCount, null, 0);
			if (flag)
			{
				MethodAttributes attributes = RuntimeMethodHandle.GetAttributes(runtimeMethodHandleInternal);
				if (!CompatibilitySwitches.IsAppEarlierThanWindowsPhone8 && (attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Private)
				{
					return null;
				}
				if ((attributes & MethodAttributes.Virtual) != MethodAttributes.PrivateScope)
				{
					bool flag2 = (RuntimeTypeHandle.GetAttributes(declaredType) & TypeAttributes.ClassSemanticsMask) == TypeAttributes.NotPublic;
					if (flag2)
					{
						int slot = RuntimeMethodHandle.GetSlot(runtimeMethodHandleInternal);
						runtimeMethodHandleInternal = RuntimeTypeHandle.GetMethodAt(reflectedType, slot);
					}
				}
			}
			RuntimeMethodInfo runtimeMethodInfo = RuntimeType.GetMethodBase(reflectedType, runtimeMethodHandleInternal) as RuntimeMethodInfo;
			if (runtimeMethodInfo == null)
			{
				runtimeMethodInfo = (reflectedType.Module.ResolveMethod(tkMethod, null, null) as RuntimeMethodInfo);
			}
			return runtimeMethodInfo;
		}

		// Token: 0x060044B1 RID: 17585 RVA: 0x000FCE48 File Offset: 0x000FB048
		[SecurityCritical]
		internal static void AssignAssociates(MetadataImport scope, int mdPropEvent, RuntimeType declaringType, RuntimeType reflectedType, out RuntimeMethodInfo addOn, out RuntimeMethodInfo removeOn, out RuntimeMethodInfo fireOn, out RuntimeMethodInfo getter, out RuntimeMethodInfo setter, out MethodInfo[] other, out bool composedOfAllPrivateMethods, out BindingFlags bindingFlags)
		{
			RuntimeMethodInfo runtimeMethodInfo;
			setter = (runtimeMethodInfo = null);
			getter = (runtimeMethodInfo = runtimeMethodInfo);
			fireOn = (runtimeMethodInfo = runtimeMethodInfo);
			removeOn = (runtimeMethodInfo = runtimeMethodInfo);
			addOn = runtimeMethodInfo;
			Associates.Attributes attributes = Associates.Attributes.ComposedOfAllVirtualMethods | Associates.Attributes.ComposedOfAllPrivateMethods | Associates.Attributes.ComposedOfNoPublicMembers | Associates.Attributes.ComposedOfNoStaticMembers;
			while (RuntimeTypeHandle.IsGenericVariable(reflectedType))
			{
				reflectedType = (RuntimeType)reflectedType.BaseType;
			}
			bool isInherited = declaringType != reflectedType;
			List<MethodInfo> list = null;
			MetadataEnumResult metadataEnumResult;
			scope.Enum(MetadataTokenType.MethodDef, mdPropEvent, out metadataEnumResult);
			int num = metadataEnumResult.Length / 2;
			for (int i = 0; i < num; i++)
			{
				int tkMethod = metadataEnumResult[i * 2];
				MethodSemanticsAttributes methodSemanticsAttributes = (MethodSemanticsAttributes)metadataEnumResult[i * 2 + 1];
				RuntimeMethodInfo runtimeMethodInfo2 = Associates.AssignAssociates(tkMethod, declaringType, reflectedType);
				if (!(runtimeMethodInfo2 == null))
				{
					MethodAttributes attributes2 = runtimeMethodInfo2.Attributes;
					bool flag = (attributes2 & MethodAttributes.MemberAccessMask) == MethodAttributes.Private;
					bool flag2 = (attributes2 & MethodAttributes.Virtual) > MethodAttributes.PrivateScope;
					MethodAttributes methodAttributes = attributes2 & MethodAttributes.MemberAccessMask;
					bool flag3 = methodAttributes == MethodAttributes.Public;
					bool flag4 = (attributes2 & MethodAttributes.Static) > MethodAttributes.PrivateScope;
					if (flag3)
					{
						attributes &= ~Associates.Attributes.ComposedOfNoPublicMembers;
						attributes &= ~Associates.Attributes.ComposedOfAllPrivateMethods;
					}
					else if (!flag)
					{
						attributes &= ~Associates.Attributes.ComposedOfAllPrivateMethods;
					}
					if (flag4)
					{
						attributes &= ~Associates.Attributes.ComposedOfNoStaticMembers;
					}
					if (!flag2)
					{
						attributes &= ~Associates.Attributes.ComposedOfAllVirtualMethods;
					}
					if (methodSemanticsAttributes == MethodSemanticsAttributes.Setter)
					{
						setter = runtimeMethodInfo2;
					}
					else if (methodSemanticsAttributes == MethodSemanticsAttributes.Getter)
					{
						getter = runtimeMethodInfo2;
					}
					else if (methodSemanticsAttributes == MethodSemanticsAttributes.Fire)
					{
						fireOn = runtimeMethodInfo2;
					}
					else if (methodSemanticsAttributes == MethodSemanticsAttributes.AddOn)
					{
						addOn = runtimeMethodInfo2;
					}
					else if (methodSemanticsAttributes == MethodSemanticsAttributes.RemoveOn)
					{
						removeOn = runtimeMethodInfo2;
					}
					else
					{
						if (list == null)
						{
							list = new List<MethodInfo>(num);
						}
						list.Add(runtimeMethodInfo2);
					}
				}
			}
			bool isPublic = (attributes & Associates.Attributes.ComposedOfNoPublicMembers) == (Associates.Attributes)0;
			bool isStatic = (attributes & Associates.Attributes.ComposedOfNoStaticMembers) == (Associates.Attributes)0;
			bindingFlags = RuntimeType.FilterPreCalculate(isPublic, isInherited, isStatic);
			composedOfAllPrivateMethods = ((attributes & Associates.Attributes.ComposedOfAllPrivateMethods) > (Associates.Attributes)0);
			other = ((list != null) ? list.ToArray() : null);
		}

		// Token: 0x02000C37 RID: 3127
		[Flags]
		internal enum Attributes
		{
			// Token: 0x0400372F RID: 14127
			ComposedOfAllVirtualMethods = 1,
			// Token: 0x04003730 RID: 14128
			ComposedOfAllPrivateMethods = 2,
			// Token: 0x04003731 RID: 14129
			ComposedOfNoPublicMembers = 4,
			// Token: 0x04003732 RID: 14130
			ComposedOfNoStaticMembers = 8
		}
	}
}
