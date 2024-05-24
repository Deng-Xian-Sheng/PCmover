using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000778 RID: 1912
	[ComVisible(true)]
	public sealed class BinaryFormatter : IRemotingFormatter, IFormatter
	{
		// Token: 0x17000DCE RID: 3534
		// (get) Token: 0x06005331 RID: 21297 RVA: 0x00123EA8 File Offset: 0x001220A8
		// (set) Token: 0x06005332 RID: 21298 RVA: 0x00123EB0 File Offset: 0x001220B0
		public FormatterTypeStyle TypeFormat
		{
			get
			{
				return this.m_typeFormat;
			}
			set
			{
				this.m_typeFormat = value;
			}
		}

		// Token: 0x17000DCF RID: 3535
		// (get) Token: 0x06005333 RID: 21299 RVA: 0x00123EB9 File Offset: 0x001220B9
		// (set) Token: 0x06005334 RID: 21300 RVA: 0x00123EC1 File Offset: 0x001220C1
		public FormatterAssemblyStyle AssemblyFormat
		{
			get
			{
				return this.m_assemblyFormat;
			}
			set
			{
				this.m_assemblyFormat = value;
			}
		}

		// Token: 0x17000DD0 RID: 3536
		// (get) Token: 0x06005335 RID: 21301 RVA: 0x00123ECA File Offset: 0x001220CA
		// (set) Token: 0x06005336 RID: 21302 RVA: 0x00123ED2 File Offset: 0x001220D2
		public TypeFilterLevel FilterLevel
		{
			get
			{
				return this.m_securityLevel;
			}
			set
			{
				this.m_securityLevel = value;
			}
		}

		// Token: 0x17000DD1 RID: 3537
		// (get) Token: 0x06005337 RID: 21303 RVA: 0x00123EDB File Offset: 0x001220DB
		// (set) Token: 0x06005338 RID: 21304 RVA: 0x00123EE3 File Offset: 0x001220E3
		public ISurrogateSelector SurrogateSelector
		{
			get
			{
				return this.m_surrogates;
			}
			set
			{
				this.m_surrogates = value;
			}
		}

		// Token: 0x17000DD2 RID: 3538
		// (get) Token: 0x06005339 RID: 21305 RVA: 0x00123EEC File Offset: 0x001220EC
		// (set) Token: 0x0600533A RID: 21306 RVA: 0x00123EF4 File Offset: 0x001220F4
		public SerializationBinder Binder
		{
			get
			{
				return this.m_binder;
			}
			set
			{
				this.m_binder = value;
			}
		}

		// Token: 0x17000DD3 RID: 3539
		// (get) Token: 0x0600533B RID: 21307 RVA: 0x00123EFD File Offset: 0x001220FD
		// (set) Token: 0x0600533C RID: 21308 RVA: 0x00123F05 File Offset: 0x00122105
		public StreamingContext Context
		{
			get
			{
				return this.m_context;
			}
			set
			{
				this.m_context = value;
			}
		}

		// Token: 0x0600533D RID: 21309 RVA: 0x00123F0E File Offset: 0x0012210E
		public BinaryFormatter()
		{
			this.m_surrogates = null;
			this.m_context = new StreamingContext(StreamingContextStates.All);
		}

		// Token: 0x0600533E RID: 21310 RVA: 0x00123F3B File Offset: 0x0012213B
		public BinaryFormatter(ISurrogateSelector selector, StreamingContext context)
		{
			this.m_surrogates = selector;
			this.m_context = context;
		}

		// Token: 0x0600533F RID: 21311 RVA: 0x00123F5F File Offset: 0x0012215F
		public object Deserialize(Stream serializationStream)
		{
			return this.Deserialize(serializationStream, null);
		}

		// Token: 0x06005340 RID: 21312 RVA: 0x00123F69 File Offset: 0x00122169
		[SecurityCritical]
		internal object Deserialize(Stream serializationStream, HeaderHandler handler, bool fCheck)
		{
			return this.Deserialize(serializationStream, handler, fCheck, null);
		}

		// Token: 0x06005341 RID: 21313 RVA: 0x00123F75 File Offset: 0x00122175
		[SecuritySafeCritical]
		public object Deserialize(Stream serializationStream, HeaderHandler handler)
		{
			return this.Deserialize(serializationStream, handler, true);
		}

		// Token: 0x06005342 RID: 21314 RVA: 0x00123F80 File Offset: 0x00122180
		[SecuritySafeCritical]
		public object DeserializeMethodResponse(Stream serializationStream, HeaderHandler handler, IMethodCallMessage methodCallMessage)
		{
			return this.Deserialize(serializationStream, handler, true, methodCallMessage);
		}

		// Token: 0x06005343 RID: 21315 RVA: 0x00123F8C File Offset: 0x0012218C
		[SecurityCritical]
		[ComVisible(false)]
		public object UnsafeDeserialize(Stream serializationStream, HeaderHandler handler)
		{
			return this.Deserialize(serializationStream, handler, false);
		}

		// Token: 0x06005344 RID: 21316 RVA: 0x00123F97 File Offset: 0x00122197
		[SecurityCritical]
		[ComVisible(false)]
		public object UnsafeDeserializeMethodResponse(Stream serializationStream, HeaderHandler handler, IMethodCallMessage methodCallMessage)
		{
			return this.Deserialize(serializationStream, handler, false, methodCallMessage);
		}

		// Token: 0x06005345 RID: 21317 RVA: 0x00123FA3 File Offset: 0x001221A3
		[SecurityCritical]
		internal object Deserialize(Stream serializationStream, HeaderHandler handler, bool fCheck, IMethodCallMessage methodCallMessage)
		{
			return this.Deserialize(serializationStream, handler, fCheck, false, methodCallMessage);
		}

		// Token: 0x06005346 RID: 21318 RVA: 0x00123FB4 File Offset: 0x001221B4
		[SecurityCritical]
		internal object Deserialize(Stream serializationStream, HeaderHandler handler, bool fCheck, bool isCrossAppDomain, IMethodCallMessage methodCallMessage)
		{
			if (serializationStream == null)
			{
				throw new ArgumentNullException("serializationStream", Environment.GetResourceString("ArgumentNull_WithParamName", new object[]
				{
					serializationStream
				}));
			}
			if (serializationStream.CanSeek && serializationStream.Length == 0L)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_Stream"));
			}
			InternalFE internalFE = new InternalFE();
			internalFE.FEtypeFormat = this.m_typeFormat;
			internalFE.FEserializerTypeEnum = InternalSerializerTypeE.Binary;
			internalFE.FEassemblyFormat = this.m_assemblyFormat;
			internalFE.FEsecurityLevel = this.m_securityLevel;
			ObjectReader objectReader = new ObjectReader(serializationStream, this.m_surrogates, this.m_context, internalFE, this.m_binder);
			objectReader.crossAppDomainArray = this.m_crossAppDomainArray;
			return objectReader.Deserialize(handler, new __BinaryParser(serializationStream, objectReader), fCheck, isCrossAppDomain, methodCallMessage);
		}

		// Token: 0x06005347 RID: 21319 RVA: 0x0012406D File Offset: 0x0012226D
		public void Serialize(Stream serializationStream, object graph)
		{
			this.Serialize(serializationStream, graph, null);
		}

		// Token: 0x06005348 RID: 21320 RVA: 0x00124078 File Offset: 0x00122278
		[SecuritySafeCritical]
		public void Serialize(Stream serializationStream, object graph, Header[] headers)
		{
			this.Serialize(serializationStream, graph, headers, true);
		}

		// Token: 0x06005349 RID: 21321 RVA: 0x00124084 File Offset: 0x00122284
		[SecurityCritical]
		internal void Serialize(Stream serializationStream, object graph, Header[] headers, bool fCheck)
		{
			if (serializationStream == null)
			{
				throw new ArgumentNullException("serializationStream", Environment.GetResourceString("ArgumentNull_WithParamName", new object[]
				{
					serializationStream
				}));
			}
			InternalFE internalFE = new InternalFE();
			internalFE.FEtypeFormat = this.m_typeFormat;
			internalFE.FEserializerTypeEnum = InternalSerializerTypeE.Binary;
			internalFE.FEassemblyFormat = this.m_assemblyFormat;
			ObjectWriter objectWriter = new ObjectWriter(this.m_surrogates, this.m_context, internalFE, this.m_binder);
			__BinaryWriter serWriter = new __BinaryWriter(serializationStream, objectWriter, this.m_typeFormat);
			objectWriter.Serialize(graph, headers, serWriter, fCheck);
			this.m_crossAppDomainArray = objectWriter.crossAppDomainArray;
		}

		// Token: 0x0600534A RID: 21322 RVA: 0x00124118 File Offset: 0x00122318
		internal static TypeInformation GetTypeInformation(Type type)
		{
			if (AppContextSwitches.UseConcurrentFormatterTypeCache)
			{
				return BinaryFormatter.concurrentTypeNameCache.Value.GetOrAdd(type, delegate(Type t)
				{
					bool hasTypeForwardedFrom2;
					string clrAssemblyName2 = FormatterServices.GetClrAssemblyName(t, out hasTypeForwardedFrom2);
					return new TypeInformation(FormatterServices.GetClrTypeFullName(t), clrAssemblyName2, hasTypeForwardedFrom2);
				});
			}
			Dictionary<Type, TypeInformation> obj = BinaryFormatter.typeNameCache;
			TypeInformation result;
			lock (obj)
			{
				TypeInformation typeInformation = null;
				if (!BinaryFormatter.typeNameCache.TryGetValue(type, out typeInformation))
				{
					bool hasTypeForwardedFrom;
					string clrAssemblyName = FormatterServices.GetClrAssemblyName(type, out hasTypeForwardedFrom);
					typeInformation = new TypeInformation(FormatterServices.GetClrTypeFullName(type), clrAssemblyName, hasTypeForwardedFrom);
					BinaryFormatter.typeNameCache.Add(type, typeInformation);
				}
				result = typeInformation;
			}
			return result;
		}

		// Token: 0x04002573 RID: 9587
		internal ISurrogateSelector m_surrogates;

		// Token: 0x04002574 RID: 9588
		internal StreamingContext m_context;

		// Token: 0x04002575 RID: 9589
		internal SerializationBinder m_binder;

		// Token: 0x04002576 RID: 9590
		internal FormatterTypeStyle m_typeFormat = FormatterTypeStyle.TypesAlways;

		// Token: 0x04002577 RID: 9591
		internal FormatterAssemblyStyle m_assemblyFormat;

		// Token: 0x04002578 RID: 9592
		internal TypeFilterLevel m_securityLevel = TypeFilterLevel.Full;

		// Token: 0x04002579 RID: 9593
		internal object[] m_crossAppDomainArray;

		// Token: 0x0400257A RID: 9594
		private static Dictionary<Type, TypeInformation> typeNameCache = new Dictionary<Type, TypeInformation>();

		// Token: 0x0400257B RID: 9595
		private static Lazy<ConcurrentDictionary<Type, TypeInformation>> concurrentTypeNameCache = new Lazy<ConcurrentDictionary<Type, TypeInformation>>(() => new ConcurrentDictionary<Type, TypeInformation>());
	}
}
