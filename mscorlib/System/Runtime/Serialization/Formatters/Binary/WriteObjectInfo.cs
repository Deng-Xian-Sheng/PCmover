using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x020007A0 RID: 1952
	internal sealed class WriteObjectInfo
	{
		// Token: 0x060054BA RID: 21690 RVA: 0x0012CEFB File Offset: 0x0012B0FB
		internal WriteObjectInfo()
		{
		}

		// Token: 0x060054BB RID: 21691 RVA: 0x0012CF03 File Offset: 0x0012B103
		internal void ObjectEnd()
		{
			WriteObjectInfo.PutObjectInfo(this.serObjectInfoInit, this);
		}

		// Token: 0x060054BC RID: 21692 RVA: 0x0012CF14 File Offset: 0x0012B114
		private void InternalInit()
		{
			this.obj = null;
			this.objectType = null;
			this.isSi = false;
			this.isNamed = false;
			this.isTyped = false;
			this.isArray = false;
			this.si = null;
			this.cache = null;
			this.memberData = null;
			this.objectId = 0L;
			this.assemId = 0L;
			this.binderTypeName = null;
			this.binderAssemblyString = null;
		}

		// Token: 0x060054BD RID: 21693 RVA: 0x0012CF80 File Offset: 0x0012B180
		[SecurityCritical]
		internal static WriteObjectInfo Serialize(object obj, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, ObjectWriter objectWriter, SerializationBinder binder)
		{
			WriteObjectInfo objectInfo = WriteObjectInfo.GetObjectInfo(serObjectInfoInit);
			objectInfo.InitSerialize(obj, surrogateSelector, context, serObjectInfoInit, converter, objectWriter, binder);
			return objectInfo;
		}

		// Token: 0x060054BE RID: 21694 RVA: 0x0012CFA8 File Offset: 0x0012B1A8
		[SecurityCritical]
		internal void InitSerialize(object obj, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, ObjectWriter objectWriter, SerializationBinder binder)
		{
			this.context = context;
			this.obj = obj;
			this.serObjectInfoInit = serObjectInfoInit;
			if (RemotingServices.IsTransparentProxy(obj))
			{
				this.objectType = Converter.typeofMarshalByRefObject;
			}
			else
			{
				this.objectType = obj.GetType();
			}
			if (this.objectType.IsArray)
			{
				this.isArray = true;
				this.InitNoMembers();
				return;
			}
			this.InvokeSerializationBinder(binder);
			objectWriter.ObjectManager.RegisterObject(obj);
			ISurrogateSelector surrogateSelector2;
			if (surrogateSelector != null && (this.serializationSurrogate = surrogateSelector.GetSurrogate(this.objectType, context, out surrogateSelector2)) != null)
			{
				this.si = new SerializationInfo(this.objectType, converter);
				if (!this.objectType.IsPrimitive)
				{
					this.serializationSurrogate.GetObjectData(obj, this.si, context);
				}
				this.InitSiWrite();
				return;
			}
			if (!(obj is ISerializable))
			{
				this.InitMemberInfo();
				WriteObjectInfo.CheckTypeForwardedFrom(this.cache, this.objectType, this.binderAssemblyString);
				return;
			}
			if (!this.objectType.IsSerializable)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_NonSerType", new object[]
				{
					this.objectType.FullName,
					this.objectType.Assembly.FullName
				}));
			}
			this.si = new SerializationInfo(this.objectType, converter, !FormatterServices.UnsafeTypeForwardersIsEnabled());
			((ISerializable)obj).GetObjectData(this.si, context);
			this.InitSiWrite();
			WriteObjectInfo.CheckTypeForwardedFrom(this.cache, this.objectType, this.binderAssemblyString);
		}

		// Token: 0x060054BF RID: 21695 RVA: 0x0012D12C File Offset: 0x0012B32C
		[Conditional("SER_LOGGING")]
		private void DumpMemberInfo()
		{
			for (int i = 0; i < this.cache.memberInfos.Length; i++)
			{
			}
		}

		// Token: 0x060054C0 RID: 21696 RVA: 0x0012D154 File Offset: 0x0012B354
		[SecurityCritical]
		internal static WriteObjectInfo Serialize(Type objectType, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, SerializationBinder binder)
		{
			WriteObjectInfo objectInfo = WriteObjectInfo.GetObjectInfo(serObjectInfoInit);
			objectInfo.InitSerialize(objectType, surrogateSelector, context, serObjectInfoInit, converter, binder);
			return objectInfo;
		}

		// Token: 0x060054C1 RID: 21697 RVA: 0x0012D178 File Offset: 0x0012B378
		[SecurityCritical]
		internal void InitSerialize(Type objectType, ISurrogateSelector surrogateSelector, StreamingContext context, SerObjectInfoInit serObjectInfoInit, IFormatterConverter converter, SerializationBinder binder)
		{
			this.objectType = objectType;
			this.context = context;
			this.serObjectInfoInit = serObjectInfoInit;
			if (objectType.IsArray)
			{
				this.InitNoMembers();
				return;
			}
			this.InvokeSerializationBinder(binder);
			ISurrogateSelector surrogateSelector2 = null;
			if (surrogateSelector != null)
			{
				this.serializationSurrogate = surrogateSelector.GetSurrogate(objectType, context, out surrogateSelector2);
			}
			if (this.serializationSurrogate != null)
			{
				this.si = new SerializationInfo(objectType, converter);
				this.cache = new SerObjectInfoCache(objectType);
				this.isSi = true;
			}
			else if (objectType != Converter.typeofObject && Converter.typeofISerializable.IsAssignableFrom(objectType))
			{
				this.si = new SerializationInfo(objectType, converter, !FormatterServices.UnsafeTypeForwardersIsEnabled());
				this.cache = new SerObjectInfoCache(objectType);
				WriteObjectInfo.CheckTypeForwardedFrom(this.cache, objectType, this.binderAssemblyString);
				this.isSi = true;
			}
			if (!this.isSi)
			{
				this.InitMemberInfo();
				WriteObjectInfo.CheckTypeForwardedFrom(this.cache, objectType, this.binderAssemblyString);
			}
		}

		// Token: 0x060054C2 RID: 21698 RVA: 0x0012D264 File Offset: 0x0012B464
		private void InitSiWrite()
		{
			this.isSi = true;
			SerializationInfoEnumerator enumerator = this.si.GetEnumerator();
			int memberCount = this.si.MemberCount;
			int num = memberCount;
			TypeInformation typeInformation = null;
			string fullTypeName = this.si.FullTypeName;
			string assemblyName = this.si.AssemblyName;
			bool hasTypeForwardedFrom = false;
			if (!this.si.IsFullTypeNameSetExplicit)
			{
				typeInformation = BinaryFormatter.GetTypeInformation(this.si.ObjectType);
				fullTypeName = typeInformation.FullTypeName;
				hasTypeForwardedFrom = typeInformation.HasTypeForwardedFrom;
			}
			if (!this.si.IsAssemblyNameSetExplicit)
			{
				if (typeInformation == null)
				{
					typeInformation = BinaryFormatter.GetTypeInformation(this.si.ObjectType);
				}
				assemblyName = typeInformation.AssemblyString;
				hasTypeForwardedFrom = typeInformation.HasTypeForwardedFrom;
			}
			this.cache = new SerObjectInfoCache(fullTypeName, assemblyName, hasTypeForwardedFrom);
			this.cache.memberNames = new string[num];
			this.cache.memberTypes = new Type[num];
			this.memberData = new object[num];
			enumerator = this.si.GetEnumerator();
			int num2 = 0;
			while (enumerator.MoveNext())
			{
				this.cache.memberNames[num2] = enumerator.Name;
				this.cache.memberTypes[num2] = enumerator.ObjectType;
				this.memberData[num2] = enumerator.Value;
				num2++;
			}
			this.isNamed = true;
			this.isTyped = false;
		}

		// Token: 0x060054C3 RID: 21699 RVA: 0x0012D3B8 File Offset: 0x0012B5B8
		private static void CheckTypeForwardedFrom(SerObjectInfoCache cache, Type objectType, string binderAssemblyString)
		{
			if (cache.hasTypeForwardedFrom && binderAssemblyString == null && !FormatterServices.UnsafeTypeForwardersIsEnabled())
			{
				Assembly assembly = objectType.Assembly;
				if (!SerializationInfo.IsAssemblyNameAssignmentSafe(assembly.FullName, cache.assemblyString) && !assembly.IsFullyTrusted)
				{
					throw new SecurityException(Environment.GetResourceString("Serialization_RequireFullTrust", new object[]
					{
						objectType
					}));
				}
			}
		}

		// Token: 0x060054C4 RID: 21700 RVA: 0x0012D414 File Offset: 0x0012B614
		private void InitNoMembers()
		{
			this.cache = (SerObjectInfoCache)this.serObjectInfoInit.seenBeforeTable[this.objectType];
			if (this.cache == null)
			{
				this.cache = new SerObjectInfoCache(this.objectType);
				this.serObjectInfoInit.seenBeforeTable.Add(this.objectType, this.cache);
			}
		}

		// Token: 0x060054C5 RID: 21701 RVA: 0x0012D478 File Offset: 0x0012B678
		[SecurityCritical]
		private void InitMemberInfo()
		{
			this.cache = (SerObjectInfoCache)this.serObjectInfoInit.seenBeforeTable[this.objectType];
			if (this.cache == null)
			{
				this.cache = new SerObjectInfoCache(this.objectType);
				this.cache.memberInfos = FormatterServices.GetSerializableMembers(this.objectType, this.context);
				int num = this.cache.memberInfos.Length;
				this.cache.memberNames = new string[num];
				this.cache.memberTypes = new Type[num];
				for (int i = 0; i < num; i++)
				{
					this.cache.memberNames[i] = this.cache.memberInfos[i].Name;
					this.cache.memberTypes[i] = this.GetMemberType(this.cache.memberInfos[i]);
				}
				this.serObjectInfoInit.seenBeforeTable.Add(this.objectType, this.cache);
			}
			if (this.obj != null)
			{
				this.memberData = FormatterServices.GetObjectData(this.obj, this.cache.memberInfos);
			}
			this.isTyped = true;
			this.isNamed = true;
		}

		// Token: 0x060054C6 RID: 21702 RVA: 0x0012D5A7 File Offset: 0x0012B7A7
		internal string GetTypeFullName()
		{
			return this.binderTypeName ?? this.cache.fullTypeName;
		}

		// Token: 0x060054C7 RID: 21703 RVA: 0x0012D5BE File Offset: 0x0012B7BE
		internal string GetAssemblyString()
		{
			return this.binderAssemblyString ?? this.cache.assemblyString;
		}

		// Token: 0x060054C8 RID: 21704 RVA: 0x0012D5D5 File Offset: 0x0012B7D5
		private void InvokeSerializationBinder(SerializationBinder binder)
		{
			if (binder != null)
			{
				binder.BindToName(this.objectType, out this.binderAssemblyString, out this.binderTypeName);
			}
		}

		// Token: 0x060054C9 RID: 21705 RVA: 0x0012D5F4 File Offset: 0x0012B7F4
		internal Type GetMemberType(MemberInfo objMember)
		{
			Type result;
			if (objMember is FieldInfo)
			{
				result = ((FieldInfo)objMember).FieldType;
			}
			else
			{
				if (!(objMember is PropertyInfo))
				{
					throw new SerializationException(Environment.GetResourceString("Serialization_SerMemberInfo", new object[]
					{
						objMember.GetType()
					}));
				}
				result = ((PropertyInfo)objMember).PropertyType;
			}
			return result;
		}

		// Token: 0x060054CA RID: 21706 RVA: 0x0012D650 File Offset: 0x0012B850
		internal void GetMemberInfo(out string[] outMemberNames, out Type[] outMemberTypes, out object[] outMemberData)
		{
			outMemberNames = this.cache.memberNames;
			outMemberTypes = this.cache.memberTypes;
			outMemberData = this.memberData;
			if (this.isSi && !this.isNamed)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_ISerializableMemberInfo"));
			}
		}

		// Token: 0x060054CB RID: 21707 RVA: 0x0012D6A0 File Offset: 0x0012B8A0
		private static WriteObjectInfo GetObjectInfo(SerObjectInfoInit serObjectInfoInit)
		{
			WriteObjectInfo writeObjectInfo;
			if (!serObjectInfoInit.oiPool.IsEmpty())
			{
				writeObjectInfo = (WriteObjectInfo)serObjectInfoInit.oiPool.Pop();
				writeObjectInfo.InternalInit();
			}
			else
			{
				writeObjectInfo = new WriteObjectInfo();
				WriteObjectInfo writeObjectInfo2 = writeObjectInfo;
				int objectInfoIdCount = serObjectInfoInit.objectInfoIdCount;
				serObjectInfoInit.objectInfoIdCount = objectInfoIdCount + 1;
				writeObjectInfo2.objectInfoId = objectInfoIdCount;
			}
			return writeObjectInfo;
		}

		// Token: 0x060054CC RID: 21708 RVA: 0x0012D6F3 File Offset: 0x0012B8F3
		private static void PutObjectInfo(SerObjectInfoInit serObjectInfoInit, WriteObjectInfo objectInfo)
		{
			serObjectInfoInit.oiPool.Push(objectInfo);
		}

		// Token: 0x040026DA RID: 9946
		internal int objectInfoId;

		// Token: 0x040026DB RID: 9947
		internal object obj;

		// Token: 0x040026DC RID: 9948
		internal Type objectType;

		// Token: 0x040026DD RID: 9949
		internal bool isSi;

		// Token: 0x040026DE RID: 9950
		internal bool isNamed;

		// Token: 0x040026DF RID: 9951
		internal bool isTyped;

		// Token: 0x040026E0 RID: 9952
		internal bool isArray;

		// Token: 0x040026E1 RID: 9953
		internal SerializationInfo si;

		// Token: 0x040026E2 RID: 9954
		internal SerObjectInfoCache cache;

		// Token: 0x040026E3 RID: 9955
		internal object[] memberData;

		// Token: 0x040026E4 RID: 9956
		internal ISerializationSurrogate serializationSurrogate;

		// Token: 0x040026E5 RID: 9957
		internal StreamingContext context;

		// Token: 0x040026E6 RID: 9958
		internal SerObjectInfoInit serObjectInfoInit;

		// Token: 0x040026E7 RID: 9959
		internal long objectId;

		// Token: 0x040026E8 RID: 9960
		internal long assemId;

		// Token: 0x040026E9 RID: 9961
		private string binderTypeName;

		// Token: 0x040026EA RID: 9962
		private string binderAssemblyString;
	}
}
