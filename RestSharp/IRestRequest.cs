using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using RestSharp.Serialization.Xml;
using RestSharp.Serializers;

namespace RestSharp
{
	// Token: 0x02000016 RID: 22
	[NullableContext(1)]
	public interface IRestRequest
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001C2 RID: 450
		// (set) Token: 0x060001C3 RID: 451
		bool AlwaysMultipartFormData { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001C4 RID: 452
		// (set) Token: 0x060001C5 RID: 453
		ISerializer JsonSerializer { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001C6 RID: 454
		// (set) Token: 0x060001C7 RID: 455
		IXmlSerializer XmlSerializer { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001C8 RID: 456
		// (set) Token: 0x060001C9 RID: 457
		Action<Stream, IHttpResponse> AdvancedResponseWriter { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001CA RID: 458
		// (set) Token: 0x060001CB RID: 459
		Action<Stream> ResponseWriter { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001CC RID: 460
		List<Parameter> Parameters { get; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001CD RID: 461
		List<FileParameter> Files { get; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001CE RID: 462
		// (set) Token: 0x060001CF RID: 463
		Method Method { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001D0 RID: 464
		// (set) Token: 0x060001D1 RID: 465
		string Resource { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060001D2 RID: 466
		// (set) Token: 0x060001D3 RID: 467
		[Obsolete("Use AddJsonBody or AddXmlBody to tell RestSharp how to serialize the request body")]
		DataFormat RequestFormat { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001D4 RID: 468
		// (set) Token: 0x060001D5 RID: 469
		string RootElement { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001D6 RID: 470
		// (set) Token: 0x060001D7 RID: 471
		string DateFormat { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001D8 RID: 472
		// (set) Token: 0x060001D9 RID: 473
		string XmlNamespace { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001DA RID: 474
		// (set) Token: 0x060001DB RID: 475
		[Nullable(2)]
		[Obsolete("Use one of authenticators provided")]
		ICredentials Credentials { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001DC RID: 476
		// (set) Token: 0x060001DD RID: 477
		int Timeout { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001DE RID: 478
		// (set) Token: 0x060001DF RID: 479
		int ReadWriteTimeout { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001E0 RID: 480
		int Attempts { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001E1 RID: 481
		// (set) Token: 0x060001E2 RID: 482
		bool UseDefaultCredentials { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001E3 RID: 483
		IList<DecompressionMethods> AllowedDecompressionMethods { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001E4 RID: 484
		// (set) Token: 0x060001E5 RID: 485
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<IRestResponse> OnBeforeDeserialization { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001E6 RID: 486
		// (set) Token: 0x060001E7 RID: 487
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<IHttp> OnBeforeRequest { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001E8 RID: 488
		// (set) Token: 0x060001E9 RID: 489
		[Nullable(2)]
		RequestBody Body { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x060001EA RID: 490
		IRestRequest AddFile(string name, string path, string contentType = null);

		// Token: 0x060001EB RID: 491
		IRestRequest AddFile(string name, byte[] bytes, string fileName, string contentType = null);

		// Token: 0x060001EC RID: 492
		IRestRequest AddFile(string name, Action<Stream> writer, string fileName, long contentLength, string contentType = null);

		// Token: 0x060001ED RID: 493
		IRestRequest AddFileBytes(string name, byte[] bytes, string filename, string contentType = "application/x-gzip");

		// Token: 0x060001EE RID: 494
		[Obsolete("Use AddJsonBody or AddXmlBody instead")]
		IRestRequest AddBody(object obj, string xmlNamespace);

		// Token: 0x060001EF RID: 495
		[Obsolete("Use AddJsonBody or AddXmlBody instead")]
		IRestRequest AddBody(object obj);

		// Token: 0x060001F0 RID: 496
		IRestRequest AddJsonBody(object obj);

		// Token: 0x060001F1 RID: 497
		IRestRequest AddJsonBody(object obj, string contentType);

		// Token: 0x060001F2 RID: 498
		IRestRequest AddXmlBody(object obj);

		// Token: 0x060001F3 RID: 499
		IRestRequest AddXmlBody(object obj, string xmlNamespace);

		// Token: 0x060001F4 RID: 500
		IRestRequest AddObject(object obj, params string[] includedProperties);

		// Token: 0x060001F5 RID: 501
		IRestRequest AddObject(object obj);

		// Token: 0x060001F6 RID: 502
		IRestRequest AddParameter(Parameter p);

		// Token: 0x060001F7 RID: 503
		IRestRequest AddParameter(string name, object value);

		// Token: 0x060001F8 RID: 504
		IRestRequest AddParameter(string name, object value, ParameterType type);

		// Token: 0x060001F9 RID: 505
		IRestRequest AddParameter(string name, object value, string contentType, ParameterType type);

		// Token: 0x060001FA RID: 506
		IRestRequest AddOrUpdateParameter(Parameter parameter);

		// Token: 0x060001FB RID: 507
		IRestRequest AddOrUpdateParameters(IEnumerable<Parameter> parameters);

		// Token: 0x060001FC RID: 508
		IRestRequest AddOrUpdateParameter(string name, object value);

		// Token: 0x060001FD RID: 509
		IRestRequest AddOrUpdateParameter(string name, object value, ParameterType type);

		// Token: 0x060001FE RID: 510
		IRestRequest AddOrUpdateParameter(string name, object value, string contentType, ParameterType type);

		// Token: 0x060001FF RID: 511
		IRestRequest AddHeader(string name, string value);

		// Token: 0x06000200 RID: 512
		IRestRequest AddHeaders([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] ICollection<KeyValuePair<string, string>> headers);

		// Token: 0x06000201 RID: 513
		IRestRequest AddCookie(string name, string value);

		// Token: 0x06000202 RID: 514
		IRestRequest AddUrlSegment(string name, string value);

		// Token: 0x06000203 RID: 515
		IRestRequest AddUrlSegment(string name, object value);

		// Token: 0x06000204 RID: 516
		IRestRequest AddQueryParameter(string name, string value);

		// Token: 0x06000205 RID: 517
		IRestRequest AddQueryParameter(string name, string value, bool encode);

		// Token: 0x06000206 RID: 518
		IRestRequest AddDecompressionMethod(DecompressionMethods decompressionMethod);

		// Token: 0x06000207 RID: 519
		void IncreaseNumAttempts();
	}
}
