using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x020005DE RID: 1502
	internal static class PseudoCustomAttribute
	{
		// Token: 0x06004596 RID: 17814
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _GetSecurityAttributes(RuntimeModule module, int token, bool assembly, out object[] securityAttributes);

		// Token: 0x06004597 RID: 17815 RVA: 0x0010054C File Offset: 0x000FE74C
		[SecurityCritical]
		internal static void GetSecurityAttributes(RuntimeModule module, int token, bool assembly, out object[] securityAttributes)
		{
			PseudoCustomAttribute._GetSecurityAttributes(module.GetNativeHandle(), token, assembly, out securityAttributes);
		}

		// Token: 0x06004598 RID: 17816 RVA: 0x0010055C File Offset: 0x000FE75C
		[SecurityCritical]
		static PseudoCustomAttribute()
		{
			RuntimeType[] array = new RuntimeType[]
			{
				typeof(FieldOffsetAttribute) as RuntimeType,
				typeof(SerializableAttribute) as RuntimeType,
				typeof(MarshalAsAttribute) as RuntimeType,
				typeof(ComImportAttribute) as RuntimeType,
				typeof(NonSerializedAttribute) as RuntimeType,
				typeof(InAttribute) as RuntimeType,
				typeof(OutAttribute) as RuntimeType,
				typeof(OptionalAttribute) as RuntimeType,
				typeof(DllImportAttribute) as RuntimeType,
				typeof(PreserveSigAttribute) as RuntimeType,
				typeof(TypeForwardedToAttribute) as RuntimeType
			};
			PseudoCustomAttribute.s_pcasCount = array.Length;
			Dictionary<RuntimeType, RuntimeType> dictionary = new Dictionary<RuntimeType, RuntimeType>(PseudoCustomAttribute.s_pcasCount);
			for (int i = 0; i < PseudoCustomAttribute.s_pcasCount; i++)
			{
				dictionary[array[i]] = array[i];
			}
			PseudoCustomAttribute.s_pca = dictionary;
		}

		// Token: 0x06004599 RID: 17817 RVA: 0x00100670 File Offset: 0x000FE870
		[SecurityCritical]
		[Conditional("_DEBUG")]
		private static void VerifyPseudoCustomAttribute(RuntimeType pca)
		{
			AttributeUsageAttribute attributeUsage = CustomAttribute.GetAttributeUsage(pca);
		}

		// Token: 0x0600459A RID: 17818 RVA: 0x00100684 File Offset: 0x000FE884
		internal static bool IsSecurityAttribute(RuntimeType type)
		{
			return type == (RuntimeType)typeof(SecurityAttribute) || type.IsSubclassOf(typeof(SecurityAttribute));
		}

		// Token: 0x0600459B RID: 17819 RVA: 0x001006B0 File Offset: 0x000FE8B0
		[SecurityCritical]
		internal static Attribute[] GetCustomAttributes(RuntimeType type, RuntimeType caType, bool includeSecCa, out int count)
		{
			count = 0;
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			if (!flag && PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null && !PseudoCustomAttribute.IsSecurityAttribute(caType))
			{
				return new Attribute[0];
			}
			List<Attribute> list = new List<Attribute>();
			if (flag || caType == (RuntimeType)typeof(SerializableAttribute))
			{
				Attribute customAttribute = SerializableAttribute.GetCustomAttribute(type);
				if (customAttribute != null)
				{
					list.Add(customAttribute);
				}
			}
			if (flag || caType == (RuntimeType)typeof(ComImportAttribute))
			{
				Attribute customAttribute = ComImportAttribute.GetCustomAttribute(type);
				if (customAttribute != null)
				{
					list.Add(customAttribute);
				}
			}
			if (includeSecCa && (flag || PseudoCustomAttribute.IsSecurityAttribute(caType)) && !type.IsGenericParameter && type.GetElementType() == null)
			{
				if (type.IsGenericType)
				{
					type = (RuntimeType)type.GetGenericTypeDefinition();
				}
				object[] array;
				PseudoCustomAttribute.GetSecurityAttributes(type.Module.ModuleHandle.GetRuntimeModule(), type.MetadataToken, false, out array);
				if (array != null)
				{
					foreach (object obj in array)
					{
						if (caType == obj.GetType() || obj.GetType().IsSubclassOf(caType))
						{
							list.Add((Attribute)obj);
						}
					}
				}
			}
			count = list.Count;
			return list.ToArray();
		}

		// Token: 0x0600459C RID: 17820 RVA: 0x00100834 File Offset: 0x000FEA34
		[SecurityCritical]
		internal static bool IsDefined(RuntimeType type, RuntimeType caType)
		{
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			int num;
			return (flag || !(PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null) || PseudoCustomAttribute.IsSecurityAttribute(caType)) && (((flag || caType == (RuntimeType)typeof(SerializableAttribute)) && SerializableAttribute.IsDefined(type)) || ((flag || caType == (RuntimeType)typeof(ComImportAttribute)) && ComImportAttribute.IsDefined(type)) || ((flag || PseudoCustomAttribute.IsSecurityAttribute(caType)) && PseudoCustomAttribute.GetCustomAttributes(type, caType, true, out num).Length != 0));
		}

		// Token: 0x0600459D RID: 17821 RVA: 0x001008F4 File Offset: 0x000FEAF4
		[SecurityCritical]
		internal static Attribute[] GetCustomAttributes(RuntimeMethodInfo method, RuntimeType caType, bool includeSecCa, out int count)
		{
			count = 0;
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			if (!flag && PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null && !PseudoCustomAttribute.IsSecurityAttribute(caType))
			{
				return new Attribute[0];
			}
			List<Attribute> list = new List<Attribute>();
			if (flag || caType == (RuntimeType)typeof(DllImportAttribute))
			{
				Attribute customAttribute = DllImportAttribute.GetCustomAttribute(method);
				if (customAttribute != null)
				{
					list.Add(customAttribute);
				}
			}
			if (flag || caType == (RuntimeType)typeof(PreserveSigAttribute))
			{
				Attribute customAttribute = PreserveSigAttribute.GetCustomAttribute(method);
				if (customAttribute != null)
				{
					list.Add(customAttribute);
				}
			}
			if (includeSecCa && (flag || PseudoCustomAttribute.IsSecurityAttribute(caType)))
			{
				object[] array;
				PseudoCustomAttribute.GetSecurityAttributes(method.Module.ModuleHandle.GetRuntimeModule(), method.MetadataToken, false, out array);
				if (array != null)
				{
					foreach (object obj in array)
					{
						if (caType == obj.GetType() || obj.GetType().IsSubclassOf(caType))
						{
							list.Add((Attribute)obj);
						}
					}
				}
			}
			count = list.Count;
			return list.ToArray();
		}

		// Token: 0x0600459E RID: 17822 RVA: 0x00100A40 File Offset: 0x000FEC40
		[SecurityCritical]
		internal static bool IsDefined(RuntimeMethodInfo method, RuntimeType caType)
		{
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			int num;
			return (flag || !(PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null)) && (((flag || caType == (RuntimeType)typeof(DllImportAttribute)) && DllImportAttribute.IsDefined(method)) || ((flag || caType == (RuntimeType)typeof(PreserveSigAttribute)) && PreserveSigAttribute.IsDefined(method)) || ((flag || PseudoCustomAttribute.IsSecurityAttribute(caType)) && PseudoCustomAttribute.GetCustomAttributes(method, caType, true, out num).Length != 0));
		}

		// Token: 0x0600459F RID: 17823 RVA: 0x00100AF8 File Offset: 0x000FECF8
		[SecurityCritical]
		internal static Attribute[] GetCustomAttributes(RuntimeParameterInfo parameter, RuntimeType caType, out int count)
		{
			count = 0;
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			if (!flag && PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null)
			{
				return null;
			}
			Attribute[] array = new Attribute[PseudoCustomAttribute.s_pcasCount];
			if (flag || caType == (RuntimeType)typeof(InAttribute))
			{
				Attribute customAttribute = InAttribute.GetCustomAttribute(parameter);
				if (customAttribute != null)
				{
					Attribute[] array2 = array;
					int num = count;
					count = num + 1;
					array2[num] = customAttribute;
				}
			}
			if (flag || caType == (RuntimeType)typeof(OutAttribute))
			{
				Attribute customAttribute = OutAttribute.GetCustomAttribute(parameter);
				if (customAttribute != null)
				{
					Attribute[] array3 = array;
					int num = count;
					count = num + 1;
					array3[num] = customAttribute;
				}
			}
			if (flag || caType == (RuntimeType)typeof(OptionalAttribute))
			{
				Attribute customAttribute = OptionalAttribute.GetCustomAttribute(parameter);
				if (customAttribute != null)
				{
					Attribute[] array4 = array;
					int num = count;
					count = num + 1;
					array4[num] = customAttribute;
				}
			}
			if (flag || caType == (RuntimeType)typeof(MarshalAsAttribute))
			{
				Attribute customAttribute = MarshalAsAttribute.GetCustomAttribute(parameter);
				if (customAttribute != null)
				{
					Attribute[] array5 = array;
					int num = count;
					count = num + 1;
					array5[num] = customAttribute;
				}
			}
			return array;
		}

		// Token: 0x060045A0 RID: 17824 RVA: 0x00100C20 File Offset: 0x000FEE20
		[SecurityCritical]
		internal static bool IsDefined(RuntimeParameterInfo parameter, RuntimeType caType)
		{
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			return (flag || !(PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null)) && (((flag || caType == (RuntimeType)typeof(InAttribute)) && InAttribute.IsDefined(parameter)) || ((flag || caType == (RuntimeType)typeof(OutAttribute)) && OutAttribute.IsDefined(parameter)) || ((flag || caType == (RuntimeType)typeof(OptionalAttribute)) && OptionalAttribute.IsDefined(parameter)) || ((flag || caType == (RuntimeType)typeof(MarshalAsAttribute)) && MarshalAsAttribute.IsDefined(parameter)));
		}

		// Token: 0x060045A1 RID: 17825 RVA: 0x00100D08 File Offset: 0x000FEF08
		[SecurityCritical]
		internal static Attribute[] GetCustomAttributes(RuntimeAssembly assembly, RuntimeType caType, bool includeSecCa, out int count)
		{
			count = 0;
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			if (!flag && PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null && !PseudoCustomAttribute.IsSecurityAttribute(caType))
			{
				return new Attribute[0];
			}
			List<Attribute> list = new List<Attribute>();
			if (includeSecCa && (flag || PseudoCustomAttribute.IsSecurityAttribute(caType)))
			{
				object[] array;
				PseudoCustomAttribute.GetSecurityAttributes(assembly.ManifestModule.ModuleHandle.GetRuntimeModule(), RuntimeAssembly.GetToken(assembly.GetNativeHandle()), true, out array);
				if (array != null)
				{
					foreach (object obj in array)
					{
						if (caType == obj.GetType() || obj.GetType().IsSubclassOf(caType))
						{
							list.Add((Attribute)obj);
						}
					}
				}
			}
			count = list.Count;
			return list.ToArray();
		}

		// Token: 0x060045A2 RID: 17826 RVA: 0x00100E00 File Offset: 0x000FF000
		[SecurityCritical]
		internal static bool IsDefined(RuntimeAssembly assembly, RuntimeType caType)
		{
			int num;
			return PseudoCustomAttribute.GetCustomAttributes(assembly, caType, true, out num).Length != 0;
		}

		// Token: 0x060045A3 RID: 17827 RVA: 0x00100E1B File Offset: 0x000FF01B
		internal static Attribute[] GetCustomAttributes(RuntimeModule module, RuntimeType caType, out int count)
		{
			count = 0;
			return null;
		}

		// Token: 0x060045A4 RID: 17828 RVA: 0x00100E21 File Offset: 0x000FF021
		internal static bool IsDefined(RuntimeModule module, RuntimeType caType)
		{
			return false;
		}

		// Token: 0x060045A5 RID: 17829 RVA: 0x00100E24 File Offset: 0x000FF024
		[SecurityCritical]
		internal static Attribute[] GetCustomAttributes(RuntimeFieldInfo field, RuntimeType caType, out int count)
		{
			count = 0;
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			if (!flag && PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null)
			{
				return null;
			}
			Attribute[] array = new Attribute[PseudoCustomAttribute.s_pcasCount];
			if (flag || caType == (RuntimeType)typeof(MarshalAsAttribute))
			{
				Attribute customAttribute = MarshalAsAttribute.GetCustomAttribute(field);
				if (customAttribute != null)
				{
					Attribute[] array2 = array;
					int num = count;
					count = num + 1;
					array2[num] = customAttribute;
				}
			}
			if (flag || caType == (RuntimeType)typeof(FieldOffsetAttribute))
			{
				Attribute customAttribute = FieldOffsetAttribute.GetCustomAttribute(field);
				if (customAttribute != null)
				{
					Attribute[] array3 = array;
					int num = count;
					count = num + 1;
					array3[num] = customAttribute;
				}
			}
			if (flag || caType == (RuntimeType)typeof(NonSerializedAttribute))
			{
				Attribute customAttribute = NonSerializedAttribute.GetCustomAttribute(field);
				if (customAttribute != null)
				{
					Attribute[] array4 = array;
					int num = count;
					count = num + 1;
					array4[num] = customAttribute;
				}
			}
			return array;
		}

		// Token: 0x060045A6 RID: 17830 RVA: 0x00100F1C File Offset: 0x000FF11C
		[SecurityCritical]
		internal static bool IsDefined(RuntimeFieldInfo field, RuntimeType caType)
		{
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			return (flag || !(PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null)) && (((flag || caType == (RuntimeType)typeof(MarshalAsAttribute)) && MarshalAsAttribute.IsDefined(field)) || ((flag || caType == (RuntimeType)typeof(FieldOffsetAttribute)) && FieldOffsetAttribute.IsDefined(field)) || ((flag || caType == (RuntimeType)typeof(NonSerializedAttribute)) && NonSerializedAttribute.IsDefined(field)));
		}

		// Token: 0x060045A7 RID: 17831 RVA: 0x00100FE0 File Offset: 0x000FF1E0
		[SecurityCritical]
		internal static Attribute[] GetCustomAttributes(RuntimeConstructorInfo ctor, RuntimeType caType, bool includeSecCa, out int count)
		{
			count = 0;
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			if (!flag && PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null && !PseudoCustomAttribute.IsSecurityAttribute(caType))
			{
				return new Attribute[0];
			}
			List<Attribute> list = new List<Attribute>();
			if (includeSecCa && (flag || PseudoCustomAttribute.IsSecurityAttribute(caType)))
			{
				object[] array;
				PseudoCustomAttribute.GetSecurityAttributes(ctor.Module.ModuleHandle.GetRuntimeModule(), ctor.MetadataToken, false, out array);
				if (array != null)
				{
					foreach (object obj in array)
					{
						if (caType == obj.GetType() || obj.GetType().IsSubclassOf(caType))
						{
							list.Add((Attribute)obj);
						}
					}
				}
			}
			count = list.Count;
			return list.ToArray();
		}

		// Token: 0x060045A8 RID: 17832 RVA: 0x001010D4 File Offset: 0x000FF2D4
		[SecurityCritical]
		internal static bool IsDefined(RuntimeConstructorInfo ctor, RuntimeType caType)
		{
			bool flag = caType == (RuntimeType)typeof(object) || caType == (RuntimeType)typeof(Attribute);
			int num;
			return (flag || !(PseudoCustomAttribute.s_pca.GetValueOrDefault(caType) == null)) && ((flag || PseudoCustomAttribute.IsSecurityAttribute(caType)) && PseudoCustomAttribute.GetCustomAttributes(ctor, caType, true, out num).Length != 0);
		}

		// Token: 0x060045A9 RID: 17833 RVA: 0x00101144 File Offset: 0x000FF344
		internal static Attribute[] GetCustomAttributes(RuntimePropertyInfo property, RuntimeType caType, out int count)
		{
			count = 0;
			return null;
		}

		// Token: 0x060045AA RID: 17834 RVA: 0x0010114A File Offset: 0x000FF34A
		internal static bool IsDefined(RuntimePropertyInfo property, RuntimeType caType)
		{
			return false;
		}

		// Token: 0x060045AB RID: 17835 RVA: 0x0010114D File Offset: 0x000FF34D
		internal static Attribute[] GetCustomAttributes(RuntimeEventInfo e, RuntimeType caType, out int count)
		{
			count = 0;
			return null;
		}

		// Token: 0x060045AC RID: 17836 RVA: 0x00101153 File Offset: 0x000FF353
		internal static bool IsDefined(RuntimeEventInfo e, RuntimeType caType)
		{
			return false;
		}

		// Token: 0x04001C8A RID: 7306
		private static Dictionary<RuntimeType, RuntimeType> s_pca;

		// Token: 0x04001C8B RID: 7307
		private static int s_pcasCount;
	}
}
