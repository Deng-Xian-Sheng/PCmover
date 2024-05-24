using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000785 RID: 1925
	internal sealed class BinaryMethodCall
	{
		// Token: 0x060053D8 RID: 21464 RVA: 0x0012704C File Offset: 0x0012524C
		internal object[] WriteArray(string uri, string methodName, string typeName, Type[] instArgs, object[] args, object methodSignature, object callContext, object[] properties)
		{
			this.uri = uri;
			this.methodName = methodName;
			this.typeName = typeName;
			this.instArgs = instArgs;
			this.args = args;
			this.methodSignature = methodSignature;
			this.callContext = callContext;
			this.properties = properties;
			int num = 0;
			if (args == null || args.Length == 0)
			{
				this.messageEnum = MessageEnum.NoArgs;
			}
			else
			{
				this.argTypes = new Type[args.Length];
				this.bArgsPrimitive = true;
				for (int i = 0; i < args.Length; i++)
				{
					if (args[i] != null)
					{
						this.argTypes[i] = args[i].GetType();
						if ((Converter.ToCode(this.argTypes[i]) <= InternalPrimitiveTypeE.Invalid && this.argTypes[i] != Converter.typeofString) || args[i] is ISerializable)
						{
							this.bArgsPrimitive = false;
							break;
						}
					}
				}
				if (this.bArgsPrimitive)
				{
					this.messageEnum = MessageEnum.ArgsInline;
				}
				else
				{
					num++;
					this.messageEnum = MessageEnum.ArgsInArray;
				}
			}
			if (instArgs != null)
			{
				num++;
				this.messageEnum |= MessageEnum.GenericMethod;
			}
			if (methodSignature != null)
			{
				num++;
				this.messageEnum |= MessageEnum.MethodSignatureInArray;
			}
			if (callContext == null)
			{
				this.messageEnum |= MessageEnum.NoContext;
			}
			else if (callContext is string)
			{
				this.messageEnum |= MessageEnum.ContextInline;
			}
			else
			{
				num++;
				this.messageEnum |= MessageEnum.ContextInArray;
			}
			if (properties != null)
			{
				num++;
				this.messageEnum |= MessageEnum.PropertyInArray;
			}
			if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ArgsInArray) && num == 1)
			{
				this.messageEnum ^= MessageEnum.ArgsInArray;
				this.messageEnum |= MessageEnum.ArgsIsArray;
				return args;
			}
			if (num > 0)
			{
				int num2 = 0;
				this.callA = new object[num];
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ArgsInArray))
				{
					this.callA[num2++] = args;
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.GenericMethod))
				{
					this.callA[num2++] = instArgs;
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.MethodSignatureInArray))
				{
					this.callA[num2++] = methodSignature;
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ContextInArray))
				{
					this.callA[num2++] = callContext;
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.PropertyInArray))
				{
					this.callA[num2] = properties;
				}
				return this.callA;
			}
			return null;
		}

		// Token: 0x060053D9 RID: 21465 RVA: 0x001272B0 File Offset: 0x001254B0
		internal void Write(__BinaryWriter sout)
		{
			sout.WriteByte(21);
			sout.WriteInt32((int)this.messageEnum);
			IOUtil.WriteStringWithCode(this.methodName, sout);
			IOUtil.WriteStringWithCode(this.typeName, sout);
			if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ContextInline))
			{
				IOUtil.WriteStringWithCode((string)this.callContext, sout);
			}
			if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ArgsInline))
			{
				sout.WriteInt32(this.args.Length);
				for (int i = 0; i < this.args.Length; i++)
				{
					IOUtil.WriteWithCode(this.argTypes[i], this.args[i], sout);
				}
			}
		}

		// Token: 0x060053DA RID: 21466 RVA: 0x00127350 File Offset: 0x00125550
		[SecurityCritical]
		internal void Read(__BinaryParser input)
		{
			this.messageEnum = (MessageEnum)input.ReadInt32();
			this.methodName = (string)IOUtil.ReadWithCode(input);
			this.typeName = (string)IOUtil.ReadWithCode(input);
			if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ContextInline))
			{
				this.scallContext = (string)IOUtil.ReadWithCode(input);
				this.callContext = new LogicalCallContext
				{
					RemotingData = 
					{
						LogicalCallID = this.scallContext
					}
				};
			}
			if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ArgsInline))
			{
				this.args = IOUtil.ReadArgs(input);
			}
		}

		// Token: 0x060053DB RID: 21467 RVA: 0x001273E4 File Offset: 0x001255E4
		[SecurityCritical]
		internal IMethodCallMessage ReadArray(object[] callA, object handlerObject)
		{
			if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ArgsIsArray))
			{
				this.args = callA;
			}
			else
			{
				int num = 0;
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ArgsInArray))
				{
					if (callA.Length < num)
					{
						throw new SerializationException(Environment.GetResourceString("Serialization_Method"));
					}
					this.args = (object[])callA[num++];
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.GenericMethod))
				{
					if (callA.Length < num)
					{
						throw new SerializationException(Environment.GetResourceString("Serialization_Method"));
					}
					this.instArgs = (Type[])callA[num++];
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.MethodSignatureInArray))
				{
					if (callA.Length < num)
					{
						throw new SerializationException(Environment.GetResourceString("Serialization_Method"));
					}
					this.methodSignature = callA[num++];
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ContextInArray))
				{
					if (callA.Length < num)
					{
						throw new SerializationException(Environment.GetResourceString("Serialization_Method"));
					}
					this.callContext = callA[num++];
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.PropertyInArray))
				{
					if (callA.Length < num)
					{
						throw new SerializationException(Environment.GetResourceString("Serialization_Method"));
					}
					this.properties = callA[num++];
				}
			}
			return new MethodCall(handlerObject, new BinaryMethodCallMessage(this.uri, this.methodName, this.typeName, this.instArgs, this.args, this.methodSignature, (LogicalCallContext)this.callContext, (object[])this.properties));
		}

		// Token: 0x060053DC RID: 21468 RVA: 0x0012755E File Offset: 0x0012575E
		internal void Dump()
		{
		}

		// Token: 0x060053DD RID: 21469 RVA: 0x00127560 File Offset: 0x00125760
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			if (BCLDebug.CheckEnabled("BINARY"))
			{
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ContextInline))
				{
					string text = this.callContext as string;
				}
				if (IOUtil.FlagTest(this.messageEnum, MessageEnum.ArgsInline))
				{
					for (int i = 0; i < this.args.Length; i++)
					{
					}
				}
			}
		}

		// Token: 0x040025C0 RID: 9664
		private string uri;

		// Token: 0x040025C1 RID: 9665
		private string methodName;

		// Token: 0x040025C2 RID: 9666
		private string typeName;

		// Token: 0x040025C3 RID: 9667
		private Type[] instArgs;

		// Token: 0x040025C4 RID: 9668
		private object[] args;

		// Token: 0x040025C5 RID: 9669
		private object methodSignature;

		// Token: 0x040025C6 RID: 9670
		private object callContext;

		// Token: 0x040025C7 RID: 9671
		private string scallContext;

		// Token: 0x040025C8 RID: 9672
		private object properties;

		// Token: 0x040025C9 RID: 9673
		private Type[] argTypes;

		// Token: 0x040025CA RID: 9674
		private bool bArgsPrimitive = true;

		// Token: 0x040025CB RID: 9675
		private MessageEnum messageEnum;

		// Token: 0x040025CC RID: 9676
		private object[] callA;
	}
}
