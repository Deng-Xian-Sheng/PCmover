using System;
using System.Reflection;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Security;
using System.Text;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200087D RID: 2173
	internal class SoapMessageSurrogate : ISerializationSurrogate
	{
		// Token: 0x06005C58 RID: 23640 RVA: 0x001438CA File Offset: 0x00141ACA
		[SecurityCritical]
		internal SoapMessageSurrogate(RemotingSurrogateSelector ss)
		{
			this._ss = ss;
		}

		// Token: 0x06005C59 RID: 23641 RVA: 0x001438E4 File Offset: 0x00141AE4
		internal void SetRootObject(object obj)
		{
			this._rootObj = obj;
		}

		// Token: 0x06005C5A RID: 23642 RVA: 0x001438F0 File Offset: 0x00141AF0
		[SecurityCritical]
		internal virtual string[] GetInArgNames(IMethodCallMessage m, int c)
		{
			string[] array = new string[c];
			for (int i = 0; i < c; i++)
			{
				string text = m.GetInArgName(i);
				if (text == null)
				{
					text = "__param" + i.ToString();
				}
				array[i] = text;
			}
			return array;
		}

		// Token: 0x06005C5B RID: 23643 RVA: 0x00143934 File Offset: 0x00141B34
		[SecurityCritical]
		internal virtual string[] GetNames(IMethodCallMessage m, int c)
		{
			string[] array = new string[c];
			for (int i = 0; i < c; i++)
			{
				string text = m.GetArgName(i);
				if (text == null)
				{
					text = "__param" + i.ToString();
				}
				array[i] = text;
			}
			return array;
		}

		// Token: 0x06005C5C RID: 23644 RVA: 0x00143978 File Offset: 0x00141B78
		[SecurityCritical]
		public virtual void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			if (obj != null && obj != this._rootObj)
			{
				new MessageSurrogate(this._ss).GetObjectData(obj, info, context);
				return;
			}
			IMethodReturnMessage methodReturnMessage = obj as IMethodReturnMessage;
			if (methodReturnMessage != null)
			{
				if (methodReturnMessage.Exception != null)
				{
					object data = CallContext.GetData("__ClientIsClr");
					bool flag = data == null || (bool)data;
					info.FullTypeName = "FormatterWrapper";
					info.AssemblyName = this.DefaultFakeRecordAssemblyName;
					Exception ex = methodReturnMessage.Exception;
					StringBuilder stringBuilder = new StringBuilder();
					bool flag2 = false;
					while (ex != null)
					{
						if (ex.Message.StartsWith("MustUnderstand", StringComparison.Ordinal))
						{
							flag2 = true;
						}
						stringBuilder.Append(" **** ");
						stringBuilder.Append(ex.GetType().FullName);
						stringBuilder.Append(" - ");
						stringBuilder.Append(ex.Message);
						ex = ex.InnerException;
					}
					ServerFault serverFault;
					if (flag)
					{
						serverFault = new ServerFault(methodReturnMessage.Exception);
					}
					else
					{
						serverFault = new ServerFault(methodReturnMessage.Exception.GetType().AssemblyQualifiedName, stringBuilder.ToString(), methodReturnMessage.Exception.StackTrace);
					}
					string faultCode = "Server";
					if (flag2)
					{
						faultCode = "MustUnderstand";
					}
					SoapFault value = new SoapFault(faultCode, stringBuilder.ToString(), null, serverFault);
					info.AddValue("__WrappedObject", value, SoapMessageSurrogate._soapFaultType);
					return;
				}
				MethodBase methodBase = methodReturnMessage.MethodBase;
				SoapMethodAttribute soapMethodAttribute = (SoapMethodAttribute)InternalRemotingServices.GetCachedSoapAttribute(methodBase);
				string responseXmlElementName = soapMethodAttribute.ResponseXmlElementName;
				string responseXmlNamespace = soapMethodAttribute.ResponseXmlNamespace;
				string returnXmlElementName = soapMethodAttribute.ReturnXmlElementName;
				ArgMapper argMapper = new ArgMapper(methodReturnMessage, true);
				object[] args = argMapper.Args;
				info.FullTypeName = responseXmlElementName;
				info.AssemblyName = responseXmlNamespace;
				Type returnType = ((MethodInfo)methodBase).ReturnType;
				if (!(returnType == null) && !(returnType == SoapMessageSurrogate._voidType))
				{
					info.AddValue(returnXmlElementName, methodReturnMessage.ReturnValue, returnType);
				}
				if (args != null)
				{
					Type[] argTypes = argMapper.ArgTypes;
					for (int i = 0; i < args.Length; i++)
					{
						string text = argMapper.GetArgName(i);
						if (text == null || text.Length == 0)
						{
							text = "__param" + i.ToString();
						}
						info.AddValue(text, args[i], argTypes[i].IsByRef ? argTypes[i].GetElementType() : argTypes[i]);
					}
					return;
				}
			}
			else
			{
				IMethodCallMessage methodCallMessage = (IMethodCallMessage)obj;
				MethodBase methodBase2 = methodCallMessage.MethodBase;
				string xmlNamespaceForMethodCall = SoapServices.GetXmlNamespaceForMethodCall(methodBase2);
				object[] inArgs = methodCallMessage.InArgs;
				string[] inArgNames = this.GetInArgNames(methodCallMessage, inArgs.Length);
				Type[] array = (Type[])methodCallMessage.MethodSignature;
				info.FullTypeName = methodCallMessage.MethodName;
				info.AssemblyName = xmlNamespaceForMethodCall;
				RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(methodBase2);
				int[] marshalRequestArgMap = reflectionCachedData.MarshalRequestArgMap;
				for (int j = 0; j < inArgs.Length; j++)
				{
					string name;
					if (inArgNames[j] == null || inArgNames[j].Length == 0)
					{
						name = "__param" + j.ToString();
					}
					else
					{
						name = inArgNames[j];
					}
					int num = marshalRequestArgMap[j];
					Type type;
					if (array[num].IsByRef)
					{
						type = array[num].GetElementType();
					}
					else
					{
						type = array[num];
					}
					info.AddValue(name, inArgs[j], type);
				}
			}
		}

		// Token: 0x06005C5D RID: 23645 RVA: 0x00143CCB File Offset: 0x00141ECB
		[SecurityCritical]
		public virtual object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_PopulateData"));
		}

		// Token: 0x040029B0 RID: 10672
		private static Type _voidType = typeof(void);

		// Token: 0x040029B1 RID: 10673
		private static Type _soapFaultType = typeof(SoapFault);

		// Token: 0x040029B2 RID: 10674
		private string DefaultFakeRecordAssemblyName = "http://schemas.microsoft.com/urt/SystemRemotingSoapTopRecord";

		// Token: 0x040029B3 RID: 10675
		private object _rootObj;

		// Token: 0x040029B4 RID: 10676
		[SecurityCritical]
		private RemotingSurrogateSelector _ss;
	}
}
