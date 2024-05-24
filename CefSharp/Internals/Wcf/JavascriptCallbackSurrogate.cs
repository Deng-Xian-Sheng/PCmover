using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace CefSharp.Internals.Wcf
{
	// Token: 0x020000F2 RID: 242
	internal sealed class JavascriptCallbackSurrogate : IDataContractSurrogate
	{
		// Token: 0x0600071F RID: 1823 RVA: 0x0000BD3A File Offset: 0x00009F3A
		public JavascriptCallbackSurrogate(IJavascriptCallbackFactory callbackFactory)
		{
			this.callbackFactory = callbackFactory;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0000BD49 File Offset: 0x00009F49
		public Type GetDataContractType(Type type)
		{
			if (type == typeof(JavascriptCallback))
			{
				return typeof(IJavascriptCallback);
			}
			return type;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0000BD69 File Offset: 0x00009F69
		public object GetObjectToSerialize(object obj, Type targetType)
		{
			return obj;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0000BD6C File Offset: 0x00009F6C
		public object GetDeserializedObject(object obj, Type targetType)
		{
			object result = obj;
			JavascriptCallback javascriptCallback = obj as JavascriptCallback;
			if (javascriptCallback != null)
			{
				result = this.callbackFactory.Create(javascriptCallback);
			}
			return result;
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0000BD93 File Offset: 0x00009F93
		public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0000BD9A File Offset: 0x00009F9A
		public object GetCustomDataToExport(Type clrType, Type dataContractType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0000BDA1 File Offset: 0x00009FA1
		public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0000BDA8 File Offset: 0x00009FA8
		public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0000BDAF File Offset: 0x00009FAF
		public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0400039A RID: 922
		private readonly IJavascriptCallbackFactory callbackFactory;
	}
}
