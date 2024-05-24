using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using RestSharp.Extensions;
using RestSharp.Serialization.Xml;
using RestSharp.Serializers;

namespace RestSharp
{
	// Token: 0x02000022 RID: 34
	[NullableContext(1)]
	[Nullable(0)]
	public class RestRequest : IRestRequest
	{
		// Token: 0x06000316 RID: 790 RVA: 0x000061C8 File Offset: 0x000043C8
		public RestRequest()
		{
			this.RequestFormat = DataFormat.Xml;
			this.Method = Method.GET;
			this.Parameters = new List<Parameter>();
			this.Files = new List<FileParameter>();
			this._allowedDecompressionMethods = new List<DecompressionMethods>();
			this.OnBeforeDeserialization = delegate(IRestResponse r)
			{
			};
			this.OnBeforeRequest = delegate(IHttp h)
			{
			};
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00006254 File Offset: 0x00004454
		public RestRequest(Method method) : this()
		{
			this.Method = method;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00006263 File Offset: 0x00004463
		public RestRequest(string resource, Method method) : this(resource, method, DataFormat.Xml)
		{
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000626E File Offset: 0x0000446E
		public RestRequest(string resource, DataFormat dataFormat) : this(resource, Method.GET, dataFormat)
		{
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00006279 File Offset: 0x00004479
		public RestRequest(string resource) : this(resource, Method.GET, DataFormat.Xml)
		{
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00006284 File Offset: 0x00004484
		public RestRequest(string resource, Method method, DataFormat dataFormat) : this()
		{
			this.Resource = (resource ?? "");
			this.Method = method;
			this.RequestFormat = dataFormat;
			int num = this.Resource.IndexOf('?');
			if (num >= 0 && this.Resource.IndexOf('=') > num)
			{
				IEnumerable<NameValuePair> enumerable = RestRequest.<.ctor>g__ParseQuery|9_0(this.Resource.Substring(num + 1));
				this.Resource = this.Resource.Substring(0, num);
				foreach (NameValuePair nameValuePair in enumerable)
				{
					this.AddQueryParameter(nameValuePair.Name, nameValuePair.Value, false);
				}
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00006344 File Offset: 0x00004544
		public RestRequest(Uri resource, Method method, DataFormat dataFormat) : this(resource.IsAbsoluteUri ? resource.AbsoluteUri : resource.OriginalString, method, dataFormat)
		{
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00006364 File Offset: 0x00004564
		public RestRequest(Uri resource, Method method) : this(resource, method, DataFormat.Xml)
		{
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000636F File Offset: 0x0000456F
		public RestRequest(Uri resource) : this(resource, Method.GET, DataFormat.Xml)
		{
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600031F RID: 799 RVA: 0x0000637C File Offset: 0x0000457C
		public IList<DecompressionMethods> AllowedDecompressionMethods
		{
			get
			{
				if (!this._allowedDecompressionMethods.Any<DecompressionMethods>())
				{
					return new DecompressionMethods[]
					{
						DecompressionMethods.None,
						DecompressionMethods.Deflate,
						DecompressionMethods.GZip
					};
				}
				return this._allowedDecompressionMethods;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000320 RID: 800 RVA: 0x000063AD File Offset: 0x000045AD
		// (set) Token: 0x06000321 RID: 801 RVA: 0x000063B5 File Offset: 0x000045B5
		public bool AlwaysMultipartFormData { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000322 RID: 802 RVA: 0x000063BE File Offset: 0x000045BE
		// (set) Token: 0x06000323 RID: 803 RVA: 0x000063C6 File Offset: 0x000045C6
		public ISerializer JsonSerializer { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000324 RID: 804 RVA: 0x000063CF File Offset: 0x000045CF
		// (set) Token: 0x06000325 RID: 805 RVA: 0x000063D7 File Offset: 0x000045D7
		public IXmlSerializer XmlSerializer { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000326 RID: 806 RVA: 0x000063E0 File Offset: 0x000045E0
		// (set) Token: 0x06000327 RID: 807 RVA: 0x000063E8 File Offset: 0x000045E8
		public RequestBody Body { get; set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000328 RID: 808 RVA: 0x000063F1 File Offset: 0x000045F1
		// (set) Token: 0x06000329 RID: 809 RVA: 0x000063F9 File Offset: 0x000045F9
		public Action<Stream> ResponseWriter
		{
			get
			{
				return this._responseWriter;
			}
			set
			{
				if (this.AdvancedResponseWriter != null)
				{
					throw new ArgumentException("AdvancedResponseWriter is not null. Only one response writer can be used.");
				}
				this._responseWriter = value;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00006415 File Offset: 0x00004615
		// (set) Token: 0x0600032B RID: 811 RVA: 0x0000641D File Offset: 0x0000461D
		public Action<Stream, IHttpResponse> AdvancedResponseWriter
		{
			get
			{
				return this._advancedResponseWriter;
			}
			set
			{
				if (this.ResponseWriter != null)
				{
					throw new ArgumentException("ResponseWriter is not null. Only one response writer can be used.");
				}
				this._advancedResponseWriter = value;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00006439 File Offset: 0x00004639
		// (set) Token: 0x0600032D RID: 813 RVA: 0x00006441 File Offset: 0x00004641
		public bool UseDefaultCredentials { get; set; }

		// Token: 0x0600032E RID: 814 RVA: 0x0000644C File Offset: 0x0000464C
		public IRestRequest AddFile(string name, string path, string contentType = null)
		{
			long length = new FileInfo(path).Length;
			return this.AddFile(new FileParameter
			{
				Name = name,
				FileName = Path.GetFileName(path),
				ContentLength = length,
				Writer = delegate(Stream s)
				{
					using (StreamReader streamReader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
					{
						streamReader.BaseStream.CopyTo(s);
					}
				},
				ContentType = contentType
			});
		}

		// Token: 0x0600032F RID: 815 RVA: 0x000064BA File Offset: 0x000046BA
		public IRestRequest AddFile(string name, byte[] bytes, string fileName, string contentType = null)
		{
			return this.AddFile(FileParameter.Create(name, bytes, fileName, contentType));
		}

		// Token: 0x06000330 RID: 816 RVA: 0x000064CC File Offset: 0x000046CC
		public IRestRequest AddFile(string name, Action<Stream> writer, string fileName, long contentLength, string contentType = null)
		{
			return this.AddFile(new FileParameter
			{
				Name = name,
				Writer = writer,
				FileName = fileName,
				ContentLength = contentLength,
				ContentType = contentType
			});
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00006500 File Offset: 0x00004700
		public IRestRequest AddFileBytes(string name, byte[] bytes, string filename, string contentType = "application/x-gzip")
		{
			long contentLength = (long)bytes.Length;
			return this.AddFile(new FileParameter
			{
				Name = name,
				FileName = filename,
				ContentLength = contentLength,
				ContentType = contentType,
				Writer = delegate(Stream s)
				{
					using (StreamReader streamReader = new StreamReader(new MemoryStream(bytes)))
					{
						streamReader.BaseStream.CopyTo(s);
					}
				}
			});
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00006560 File Offset: 0x00004760
		[Obsolete("Use AddXmlBody")]
		public IRestRequest AddBody(object obj, string xmlNamespace)
		{
			DataFormat requestFormat = this.RequestFormat;
			IRestRequest result;
			if (requestFormat != DataFormat.Json)
			{
				if (requestFormat != DataFormat.Xml)
				{
					result = this;
				}
				else
				{
					result = this.AddXmlBody(obj, xmlNamespace);
				}
			}
			else
			{
				result = this.AddJsonBody(obj);
			}
			return result;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00006598 File Offset: 0x00004798
		[Obsolete("Use AddXmlBody or AddJsonBody")]
		public IRestRequest AddBody(object obj)
		{
			DataFormat requestFormat = this.RequestFormat;
			IRestRequest result;
			if (requestFormat != DataFormat.Json)
			{
				if (requestFormat != DataFormat.Xml)
				{
					result = this;
				}
				else
				{
					result = this.AddXmlBody(obj);
				}
			}
			else
			{
				result = this.AddJsonBody(obj);
			}
			return result;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000065CC File Offset: 0x000047CC
		public IRestRequest AddJsonBody(object obj)
		{
			this.RequestFormat = DataFormat.Json;
			return this.AddParameter(new JsonParameter("", obj));
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000065E6 File Offset: 0x000047E6
		public IRestRequest AddJsonBody(object obj, string contentType)
		{
			this.RequestFormat = DataFormat.Json;
			return this.AddParameter(new JsonParameter(contentType, obj, contentType));
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000065FD File Offset: 0x000047FD
		public IRestRequest AddXmlBody(object obj)
		{
			return this.AddXmlBody(obj, "");
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000660C File Offset: 0x0000480C
		public IRestRequest AddXmlBody(object obj, string xmlNamespace)
		{
			this.RequestFormat = DataFormat.Xml;
			if (!string.IsNullOrWhiteSpace(this.XmlNamespace))
			{
				xmlNamespace = this.XmlNamespace;
			}
			else
			{
				IXmlSerializer xmlSerializer = this.XmlSerializer;
				if (!string.IsNullOrWhiteSpace((xmlSerializer != null) ? xmlSerializer.Namespace : null))
				{
					xmlNamespace = this.XmlSerializer.Namespace;
				}
			}
			this.AddParameter(new XmlParameter("", obj, xmlNamespace));
			return this;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00006674 File Offset: 0x00004874
		public IRestRequest AddObject(object obj, params string[] includedProperties)
		{
			RestRequest.<>c__DisplayClass51_0 CS$<>8__locals1;
			CS$<>8__locals1.includedProperties = includedProperties;
			foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
			{
				if (RestRequest.<AddObject>g__IsAllowedProperty|51_0(propertyInfo.Name, ref CS$<>8__locals1))
				{
					object obj2 = propertyInfo.GetValue(obj, null);
					if (obj2 != null)
					{
						Type propertyType = propertyInfo.PropertyType;
						if (propertyType.IsArray)
						{
							Type elementType = propertyType.GetElementType();
							Array array = (Array)obj2;
							if (array.Length > 0 && elementType != null)
							{
								IEnumerable<string> values = from object item in array
								select item.ToString();
								obj2 = string.Join(",", values);
							}
						}
						this.AddParameter(propertyInfo.Name, obj2);
					}
				}
			}
			return this;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00006754 File Offset: 0x00004954
		public IRestRequest AddObject(object obj)
		{
			return this.With(delegate(RestRequest x)
			{
				x.AddObject(obj, new string[0]);
			});
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00006780 File Offset: 0x00004980
		public IRestRequest AddParameter(Parameter p)
		{
			return this.With(delegate(RestRequest x)
			{
				x.Parameters.Add(p);
			});
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000067AC File Offset: 0x000049AC
		public IRestRequest AddParameter(string name, object value)
		{
			return this.AddParameter(new Parameter(name, value, ParameterType.GetOrPost));
		}

		// Token: 0x0600033C RID: 828 RVA: 0x000067BC File Offset: 0x000049BC
		public IRestRequest AddParameter(string name, object value, ParameterType type)
		{
			return this.AddParameter(new Parameter(name, value, type));
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000067CC File Offset: 0x000049CC
		public IRestRequest AddParameter(string name, object value, string contentType, ParameterType type)
		{
			return this.AddParameter(new Parameter(name, value, contentType, type));
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000067E0 File Offset: 0x000049E0
		public IRestRequest AddOrUpdateParameter(Parameter parameter)
		{
			Parameter parameter2 = this.Parameters.FirstOrDefault((Parameter x) => x.Name == parameter.Name && x.Type == parameter.Type);
			if (parameter2 != null)
			{
				this.Parameters.Remove(parameter2);
			}
			this.Parameters.Add(parameter);
			return this;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00006834 File Offset: 0x00004A34
		public IRestRequest AddOrUpdateParameters(IEnumerable<Parameter> parameters)
		{
			foreach (Parameter parameter in parameters)
			{
				this.AddOrUpdateParameter(parameter);
			}
			return this;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00006880 File Offset: 0x00004A80
		public IRestRequest AddOrUpdateParameter(string name, object value)
		{
			return this.AddOrUpdateParameter(new Parameter(name, value, ParameterType.GetOrPost));
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00006890 File Offset: 0x00004A90
		public IRestRequest AddOrUpdateParameter(string name, object value, ParameterType type)
		{
			return this.AddOrUpdateParameter(new Parameter(name, value, type));
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000068A0 File Offset: 0x00004AA0
		public IRestRequest AddOrUpdateParameter(string name, object value, string contentType, ParameterType type)
		{
			return this.AddOrUpdateParameter(new Parameter(name, value, contentType, type));
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000068B2 File Offset: 0x00004AB2
		public IRestRequest AddHeader(string name, string value)
		{
			if (name == "Host" && RestRequest.<AddHeader>g__InvalidHost|62_0(value))
			{
				throw new ArgumentException("The specified value is not a valid Host header string.", "value");
			}
			return this.AddParameter(name, value, ParameterType.HttpHeader);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000068E4 File Offset: 0x00004AE4
		public IRestRequest AddHeaders([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] ICollection<KeyValuePair<string, string>> headers)
		{
			List<string> list = (from pair in headers
			group pair by pair.Key.ToUpperInvariant() into @group
			where @group.Count<KeyValuePair<string, string>>() > 1
			select @group.Key).ToList<string>();
			if (list.Any<string>())
			{
				throw new ArgumentException("Duplicate header names exist: " + string.Join(", ", list));
			}
			foreach (KeyValuePair<string, string> keyValuePair in headers)
			{
				this.AddHeader(keyValuePair.Key, keyValuePair.Value);
			}
			return this;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x000069D4 File Offset: 0x00004BD4
		public IRestRequest AddCookie(string name, string value)
		{
			return this.AddParameter(name, value, ParameterType.Cookie);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x000069DF File Offset: 0x00004BDF
		public IRestRequest AddUrlSegment(string name, string value)
		{
			return this.AddParameter(name, value, ParameterType.UrlSegment);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x000069EA File Offset: 0x00004BEA
		public IRestRequest AddQueryParameter(string name, string value)
		{
			return this.AddParameter(name, value, ParameterType.QueryString);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x000069F5 File Offset: 0x00004BF5
		public IRestRequest AddQueryParameter(string name, string value, bool encode)
		{
			return this.AddParameter(name, value, encode ? ParameterType.QueryString : ParameterType.QueryStringWithoutEncode);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00006A06 File Offset: 0x00004C06
		public IRestRequest AddDecompressionMethod(DecompressionMethods decompressionMethod)
		{
			if (!this._allowedDecompressionMethods.Contains(decompressionMethod))
			{
				this._allowedDecompressionMethods.Add(decompressionMethod);
			}
			return this;
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00006A23 File Offset: 0x00004C23
		public List<Parameter> Parameters { get; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00006A2B File Offset: 0x00004C2B
		public List<FileParameter> Files { get; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00006A33 File Offset: 0x00004C33
		// (set) Token: 0x0600034D RID: 845 RVA: 0x00006A3B File Offset: 0x00004C3B
		public Method Method { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00006A44 File Offset: 0x00004C44
		// (set) Token: 0x0600034F RID: 847 RVA: 0x00006A4C File Offset: 0x00004C4C
		public string Resource { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00006A55 File Offset: 0x00004C55
		// (set) Token: 0x06000351 RID: 849 RVA: 0x00006A5D File Offset: 0x00004C5D
		public DataFormat RequestFormat { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00006A66 File Offset: 0x00004C66
		// (set) Token: 0x06000353 RID: 851 RVA: 0x00006A6E File Offset: 0x00004C6E
		[Obsolete("Add custom content handler instead. This property will be removed.")]
		public string RootElement { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00006A77 File Offset: 0x00004C77
		// (set) Token: 0x06000355 RID: 853 RVA: 0x00006A7F File Offset: 0x00004C7F
		public Action<IRestResponse> OnBeforeDeserialization { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000356 RID: 854 RVA: 0x00006A88 File Offset: 0x00004C88
		// (set) Token: 0x06000357 RID: 855 RVA: 0x00006A90 File Offset: 0x00004C90
		public Action<IHttp> OnBeforeRequest { get; set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00006A99 File Offset: 0x00004C99
		// (set) Token: 0x06000359 RID: 857 RVA: 0x00006AA1 File Offset: 0x00004CA1
		[Obsolete("Add custom content handler instead. This property will be removed.")]
		public string DateFormat { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00006AAA File Offset: 0x00004CAA
		// (set) Token: 0x0600035B RID: 859 RVA: 0x00006AB2 File Offset: 0x00004CB2
		[Obsolete("Add custom content handler instead. This property will be removed.")]
		public string XmlNamespace { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00006ABB File Offset: 0x00004CBB
		// (set) Token: 0x0600035D RID: 861 RVA: 0x00006AC3 File Offset: 0x00004CC3
		public ICredentials Credentials { get; set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00006ACC File Offset: 0x00004CCC
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00006AD4 File Offset: 0x00004CD4
		public int Timeout { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00006ADD File Offset: 0x00004CDD
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00006AE5 File Offset: 0x00004CE5
		public int ReadWriteTimeout { get; set; }

		// Token: 0x06000362 RID: 866 RVA: 0x00006AF0 File Offset: 0x00004CF0
		public void IncreaseNumAttempts()
		{
			int attempts = this.Attempts;
			this.Attempts = attempts + 1;
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000363 RID: 867 RVA: 0x00006B0D File Offset: 0x00004D0D
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00006B15 File Offset: 0x00004D15
		public int Attempts { get; private set; }

		// Token: 0x06000365 RID: 869 RVA: 0x00006B1E File Offset: 0x00004D1E
		public IRestRequest AddUrlSegment(string name, object value)
		{
			return this.AddParameter(name, value, ParameterType.UrlSegment);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00006B2C File Offset: 0x00004D2C
		private IRestRequest AddFile(FileParameter file)
		{
			return this.With(delegate(RestRequest x)
			{
				x.Files.Add(file);
			});
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00006B69 File Offset: 0x00004D69
		[CompilerGenerated]
		internal static IEnumerable<NameValuePair> <.ctor>g__ParseQuery|9_0(string query)
		{
			return query.Split(new char[]
			{
				'&'
			}, StringSplitOptions.RemoveEmptyEntries).Select(delegate(string x)
			{
				int num = x.IndexOf('=');
				if (num <= 0)
				{
					return new NameValuePair(x, string.Empty);
				}
				return new NameValuePair(x.Substring(0, num), x.Substring(num + 1));
			});
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00006BA1 File Offset: 0x00004DA1
		[CompilerGenerated]
		internal static bool <AddObject>g__IsAllowedProperty|51_0(string propertyName, ref RestRequest.<>c__DisplayClass51_0 A_1)
		{
			return A_1.includedProperties.Length == 0 || (A_1.includedProperties.Length != 0 && A_1.includedProperties.Contains(propertyName));
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00006BC5 File Offset: 0x00004DC5
		[CompilerGenerated]
		internal static bool <AddHeader>g__InvalidHost|62_0(string host)
		{
			return Uri.CheckHostName(RestRequest.PortSplitRegex.Split(host)[0]) == UriHostNameType.Unknown;
		}

		// Token: 0x040000A8 RID: 168
		private static readonly Regex PortSplitRegex = new Regex(":\\d+");

		// Token: 0x040000A9 RID: 169
		private readonly IList<DecompressionMethods> _allowedDecompressionMethods;

		// Token: 0x040000AA RID: 170
		private Action<Stream, IHttpResponse> _advancedResponseWriter;

		// Token: 0x040000AB RID: 171
		private Action<Stream> _responseWriter;
	}
}
