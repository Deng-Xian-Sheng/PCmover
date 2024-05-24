using System;
using System.Reflection;
using System.Reflection.Emit;

namespace System.Runtime.InteropServices.TCEAdapterGen
{
	// Token: 0x020009C1 RID: 2497
	internal class EventSinkHelperWriter
	{
		// Token: 0x060063A5 RID: 25509 RVA: 0x00153EE4 File Offset: 0x001520E4
		public EventSinkHelperWriter(ModuleBuilder OutputModule, Type InputType, Type EventItfType)
		{
			this.m_InputType = InputType;
			this.m_OutputModule = OutputModule;
			this.m_EventItfType = EventItfType;
		}

		// Token: 0x060063A6 RID: 25510 RVA: 0x00153F04 File Offset: 0x00152104
		public Type Perform()
		{
			Type[] aInterfaceTypes = new Type[]
			{
				this.m_InputType
			};
			string text = null;
			string text2 = NameSpaceExtractor.ExtractNameSpace(this.m_EventItfType.FullName);
			if (text2 != "")
			{
				text = text2 + ".";
			}
			text = text + this.m_InputType.Name + EventSinkHelperWriter.GeneratedTypeNamePostfix;
			TypeBuilder typeBuilder = TCEAdapterGenerator.DefineUniqueType(text, TypeAttributes.Public | TypeAttributes.Sealed, null, aInterfaceTypes, this.m_OutputModule);
			TCEAdapterGenerator.SetHiddenAttribute(typeBuilder);
			TCEAdapterGenerator.SetClassInterfaceTypeToNone(typeBuilder);
			MethodInfo[] propertyMethods = TCEAdapterGenerator.GetPropertyMethods(this.m_InputType);
			foreach (MethodInfo method in propertyMethods)
			{
				this.DefineBlankMethod(typeBuilder, method);
			}
			MethodInfo[] nonPropertyMethods = TCEAdapterGenerator.GetNonPropertyMethods(this.m_InputType);
			FieldBuilder[] array2 = new FieldBuilder[nonPropertyMethods.Length];
			for (int j = 0; j < nonPropertyMethods.Length; j++)
			{
				if (this.m_InputType == nonPropertyMethods[j].DeclaringType)
				{
					MethodInfo method2 = this.m_EventItfType.GetMethod("add_" + nonPropertyMethods[j].Name);
					ParameterInfo[] parameters = method2.GetParameters();
					Type parameterType = parameters[0].ParameterType;
					array2[j] = typeBuilder.DefineField("m_" + nonPropertyMethods[j].Name + "Delegate", parameterType, FieldAttributes.Public);
					this.DefineEventMethod(typeBuilder, nonPropertyMethods[j], parameterType, array2[j]);
				}
			}
			FieldBuilder fbCookie = typeBuilder.DefineField("m_dwCookie", typeof(int), FieldAttributes.Public);
			this.DefineConstructor(typeBuilder, fbCookie, array2);
			return typeBuilder.CreateType();
		}

		// Token: 0x060063A7 RID: 25511 RVA: 0x00154098 File Offset: 0x00152298
		private void DefineBlankMethod(TypeBuilder OutputTypeBuilder, MethodInfo Method)
		{
			ParameterInfo[] parameters = Method.GetParameters();
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = parameters[i].ParameterType;
			}
			MethodBuilder methodBuilder = OutputTypeBuilder.DefineMethod(Method.Name, Method.Attributes & ~MethodAttributes.Abstract, Method.CallingConvention, Method.ReturnType, array);
			ILGenerator ilgenerator = methodBuilder.GetILGenerator();
			this.AddReturn(Method.ReturnType, ilgenerator, methodBuilder);
			ilgenerator.Emit(OpCodes.Ret);
		}

		// Token: 0x060063A8 RID: 25512 RVA: 0x0015411C File Offset: 0x0015231C
		private void DefineEventMethod(TypeBuilder OutputTypeBuilder, MethodInfo Method, Type DelegateCls, FieldBuilder fbDelegate)
		{
			MethodInfo method = DelegateCls.GetMethod("Invoke");
			Type returnType = Method.ReturnType;
			ParameterInfo[] parameters = Method.GetParameters();
			Type[] array;
			if (parameters != null)
			{
				array = new Type[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
				{
					array[i] = parameters[i].ParameterType;
				}
			}
			else
			{
				array = null;
			}
			MethodAttributes attributes = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Virtual;
			MethodBuilder methodBuilder = OutputTypeBuilder.DefineMethod(Method.Name, attributes, CallingConventions.Standard, returnType, array);
			ILGenerator ilgenerator = methodBuilder.GetILGenerator();
			Label label = ilgenerator.DefineLabel();
			ilgenerator.Emit(OpCodes.Ldarg, 0);
			ilgenerator.Emit(OpCodes.Ldfld, fbDelegate);
			ilgenerator.Emit(OpCodes.Brfalse, label);
			ilgenerator.Emit(OpCodes.Ldarg, 0);
			ilgenerator.Emit(OpCodes.Ldfld, fbDelegate);
			ParameterInfo[] parameters2 = Method.GetParameters();
			for (int j = 0; j < parameters2.Length; j++)
			{
				ilgenerator.Emit(OpCodes.Ldarg, (short)(j + 1));
			}
			ilgenerator.Emit(OpCodes.Callvirt, method);
			ilgenerator.Emit(OpCodes.Ret);
			ilgenerator.MarkLabel(label);
			this.AddReturn(returnType, ilgenerator, methodBuilder);
			ilgenerator.Emit(OpCodes.Ret);
		}

		// Token: 0x060063A9 RID: 25513 RVA: 0x00154244 File Offset: 0x00152444
		private void AddReturn(Type ReturnType, ILGenerator il, MethodBuilder Meth)
		{
			if (!(ReturnType == typeof(void)))
			{
				if (ReturnType.IsPrimitive)
				{
					switch (Type.GetTypeCode(ReturnType))
					{
					case TypeCode.Boolean:
					case TypeCode.Char:
					case TypeCode.SByte:
					case TypeCode.Byte:
					case TypeCode.Int16:
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
						il.Emit(OpCodes.Ldc_I4_0);
						return;
					case TypeCode.Int64:
					case TypeCode.UInt64:
						il.Emit(OpCodes.Ldc_I4_0);
						il.Emit(OpCodes.Conv_I8);
						return;
					case TypeCode.Single:
						il.Emit(OpCodes.Ldc_R4, 0);
						return;
					case TypeCode.Double:
						il.Emit(OpCodes.Ldc_R4, 0);
						il.Emit(OpCodes.Conv_R8);
						return;
					default:
						if (ReturnType == typeof(IntPtr))
						{
							il.Emit(OpCodes.Ldc_I4_0);
							return;
						}
						break;
					}
				}
				else
				{
					if (ReturnType.IsValueType)
					{
						Meth.InitLocals = true;
						LocalBuilder local = il.DeclareLocal(ReturnType);
						il.Emit(OpCodes.Ldloc_S, local);
						return;
					}
					il.Emit(OpCodes.Ldnull);
				}
			}
		}

		// Token: 0x060063AA RID: 25514 RVA: 0x00154348 File Offset: 0x00152548
		private void DefineConstructor(TypeBuilder OutputTypeBuilder, FieldBuilder fbCookie, FieldBuilder[] afbDelegates)
		{
			ConstructorInfo constructor = typeof(object).GetConstructor(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, new Type[0], null);
			MethodBuilder methodBuilder = OutputTypeBuilder.DefineMethod(".ctor", MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.SpecialName, CallingConventions.Standard, null, null);
			ILGenerator ilgenerator = methodBuilder.GetILGenerator();
			ilgenerator.Emit(OpCodes.Ldarg, 0);
			ilgenerator.Emit(OpCodes.Call, constructor);
			ilgenerator.Emit(OpCodes.Ldarg, 0);
			ilgenerator.Emit(OpCodes.Ldc_I4, 0);
			ilgenerator.Emit(OpCodes.Stfld, fbCookie);
			for (int i = 0; i < afbDelegates.Length; i++)
			{
				if (afbDelegates[i] != null)
				{
					ilgenerator.Emit(OpCodes.Ldarg, 0);
					ilgenerator.Emit(OpCodes.Ldnull);
					ilgenerator.Emit(OpCodes.Stfld, afbDelegates[i]);
				}
			}
			ilgenerator.Emit(OpCodes.Ret);
		}

		// Token: 0x04002CC5 RID: 11461
		public static readonly string GeneratedTypeNamePostfix = "_SinkHelper";

		// Token: 0x04002CC6 RID: 11462
		private Type m_InputType;

		// Token: 0x04002CC7 RID: 11463
		private Type m_EventItfType;

		// Token: 0x04002CC8 RID: 11464
		private ModuleBuilder m_OutputModule;
	}
}
