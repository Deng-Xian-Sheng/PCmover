using System;
using System.Runtime.CompilerServices;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace RestSharp.Serialization.Xml
{
	// Token: 0x02000042 RID: 66
	[NullableContext(1)]
	[Nullable(0)]
	public class XmlRestSerializer : IRestSerializer, ISerializer, IDeserializer, IXmlSerializer, IWithRootElement, IXmlDeserializer
	{
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000AED9 File Offset: 0x000090D9
		public string[] SupportedContentTypes { get; } = RestSharp.Serialization.ContentType.XmlAccept;

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000AEE1 File Offset: 0x000090E1
		public DataFormat DataFormat { get; } = 1;

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0000AEE9 File Offset: 0x000090E9
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x0000AEF1 File Offset: 0x000090F1
		public string ContentType { get; set; } = "application/xml";

		// Token: 0x0600049D RID: 1181 RVA: 0x0000AEFA File Offset: 0x000090FA
		public string Serialize(object obj)
		{
			return this._xmlSerializer.Serialize(obj);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000AF08 File Offset: 0x00009108
		public T Deserialize<[Nullable(2)] T>(IRestResponse response)
		{
			return this._xmlDeserializer.Deserialize<T>(response);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000AF18 File Offset: 0x00009118
		public string Serialize(Parameter parameter)
		{
			XmlParameter xmlParameter = parameter as XmlParameter;
			if (xmlParameter == null)
			{
				throw new InvalidOperationException("Supplied parameter is not an XML parameter");
			}
			string @namespace = this._xmlSerializer.Namespace;
			this._xmlSerializer.Namespace = (xmlParameter.XmlNamespace ?? @namespace);
			string result = this._xmlSerializer.Serialize(parameter.Value);
			this._xmlSerializer.Namespace = @namespace;
			return result;
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0000AF79 File Offset: 0x00009179
		// (set) Token: 0x060004A1 RID: 1185 RVA: 0x0000AF86 File Offset: 0x00009186
		public string RootElement
		{
			get
			{
				return this._options.RootElement;
			}
			set
			{
				this._options.RootElement = value;
				this._xmlSerializer.RootElement = value;
				this._xmlDeserializer.RootElement = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000AFAC File Offset: 0x000091AC
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x0000AFB9 File Offset: 0x000091B9
		public string Namespace
		{
			get
			{
				return this._options.Namespace;
			}
			set
			{
				this._options.Namespace = value;
				this._xmlSerializer.Namespace = value;
				this._xmlDeserializer.Namespace = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0000AFDF File Offset: 0x000091DF
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0000AFEC File Offset: 0x000091EC
		public string DateFormat
		{
			get
			{
				return this._options.DateFormat;
			}
			set
			{
				this._options.DateFormat = value;
				this._xmlSerializer.DateFormat = value;
				this._xmlDeserializer.DateFormat = value;
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0000B012 File Offset: 0x00009212
		public XmlRestSerializer WithOptions(XmlSerilizationOptions options)
		{
			this._options = options;
			return this;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000B01C File Offset: 0x0000921C
		public XmlRestSerializer WithXmlSerializer<[Nullable(0)] T>(XmlSerilizationOptions options = null) where T : IXmlSerializer, new()
		{
			if (options != null)
			{
				this._options = options;
			}
			T t = Activator.CreateInstance<T>();
			t.Namespace = this._options.Namespace;
			t.DateFormat = this._options.DateFormat;
			t.RootElement = this._options.RootElement;
			return this.WithXmlSerializer(t);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000B08D File Offset: 0x0000928D
		public XmlRestSerializer WithXmlSerializer(IXmlSerializer xmlSerializer)
		{
			this._xmlSerializer = xmlSerializer;
			return this;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0000B098 File Offset: 0x00009298
		public XmlRestSerializer WithXmlDeserialzier<[Nullable(0)] T>(XmlSerilizationOptions options = null) where T : IXmlDeserializer, new()
		{
			if (options != null)
			{
				this._options = options;
			}
			T t = Activator.CreateInstance<T>();
			t.Namespace = this._options.Namespace;
			t.DateFormat = this._options.DateFormat;
			t.RootElement = this._options.RootElement;
			return this.WithXmlDeserializer(t);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000B109 File Offset: 0x00009309
		public XmlRestSerializer WithXmlDeserializer(IXmlDeserializer xmlDeserializer)
		{
			this._xmlDeserializer = xmlDeserializer;
			return this;
		}

		// Token: 0x0400011B RID: 283
		private XmlSerilizationOptions _options = XmlSerilizationOptions.Default;

		// Token: 0x0400011C RID: 284
		private IXmlDeserializer _xmlDeserializer = new XmlDeserializer();

		// Token: 0x0400011D RID: 285
		private IXmlSerializer _xmlSerializer = new XmlSerializer();
	}
}
