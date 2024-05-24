using System;

namespace CefSharp
{
	// Token: 0x02000023 RID: 35
	public enum CefErrorCode
	{
		// Token: 0x0400004A RID: 74
		None,
		// Token: 0x0400004B RID: 75
		IoPending = -1,
		// Token: 0x0400004C RID: 76
		Failed = -2,
		// Token: 0x0400004D RID: 77
		Aborted = -3,
		// Token: 0x0400004E RID: 78
		InvalidArgument = -4,
		// Token: 0x0400004F RID: 79
		InvalidHandle = -5,
		// Token: 0x04000050 RID: 80
		FileNotFound = -6,
		// Token: 0x04000051 RID: 81
		TimedOut = -7,
		// Token: 0x04000052 RID: 82
		FileTooBig = -8,
		// Token: 0x04000053 RID: 83
		Unexpected = -9,
		// Token: 0x04000054 RID: 84
		AccessDenied = -10,
		// Token: 0x04000055 RID: 85
		NotImplemented = -11,
		// Token: 0x04000056 RID: 86
		InsufficientResources = -12,
		// Token: 0x04000057 RID: 87
		OutOfMemory = -13,
		// Token: 0x04000058 RID: 88
		UploadFileChanged = -14,
		// Token: 0x04000059 RID: 89
		SocketNotConnected = -15,
		// Token: 0x0400005A RID: 90
		FileExists = -16,
		// Token: 0x0400005B RID: 91
		FilePathTooLong = -17,
		// Token: 0x0400005C RID: 92
		FileNoSpace = -18,
		// Token: 0x0400005D RID: 93
		FileVirusInfected = -19,
		// Token: 0x0400005E RID: 94
		BlockedByClient = -20,
		// Token: 0x0400005F RID: 95
		NetworkChanged = -21,
		// Token: 0x04000060 RID: 96
		BlockedByAdministrator = -22,
		// Token: 0x04000061 RID: 97
		SocketIsConnected = -23,
		// Token: 0x04000062 RID: 98
		BlockedEnrollmentCheckPending = -24,
		// Token: 0x04000063 RID: 99
		UploadStreamRewindNotSupported = -25,
		// Token: 0x04000064 RID: 100
		ContextShutDown = -26,
		// Token: 0x04000065 RID: 101
		BlockedByResponse = -27,
		// Token: 0x04000066 RID: 102
		CleartextNotPermitted = -29,
		// Token: 0x04000067 RID: 103
		BlockedByCsp = -30,
		// Token: 0x04000068 RID: 104
		H2OrQuicRequired = -31,
		// Token: 0x04000069 RID: 105
		ConnectionClosed = -100,
		// Token: 0x0400006A RID: 106
		ConnectionReset = -101,
		// Token: 0x0400006B RID: 107
		ConnectionRefused = -102,
		// Token: 0x0400006C RID: 108
		ConnectionAborted = -103,
		// Token: 0x0400006D RID: 109
		ConnectionFailed = -104,
		// Token: 0x0400006E RID: 110
		NameNotResolved = -105,
		// Token: 0x0400006F RID: 111
		InternetDisconnected = -106,
		// Token: 0x04000070 RID: 112
		SslProtocolError = -107,
		// Token: 0x04000071 RID: 113
		AddressInvalid = -108,
		// Token: 0x04000072 RID: 114
		AddressUnreachable = -109,
		// Token: 0x04000073 RID: 115
		SslClientAuthCertNeeded = -110,
		// Token: 0x04000074 RID: 116
		TunnelConnectionFailed = -111,
		// Token: 0x04000075 RID: 117
		NoSslVersionsEnabled = -112,
		// Token: 0x04000076 RID: 118
		SslVersionOrCipherMismatch = -113,
		// Token: 0x04000077 RID: 119
		SslRenegotiationRequested = -114,
		// Token: 0x04000078 RID: 120
		ProxyAuthUnsupported = -115,
		// Token: 0x04000079 RID: 121
		BadSslClientAuthCert = -117,
		// Token: 0x0400007A RID: 122
		ConnectionTimedOut = -118,
		// Token: 0x0400007B RID: 123
		HostResolverQueueTooLarge = -119,
		// Token: 0x0400007C RID: 124
		SocksConnectionFailed = -120,
		// Token: 0x0400007D RID: 125
		SocksConnectionHostUnreachable = -121,
		// Token: 0x0400007E RID: 126
		AlpnNegotiationFailed = -122,
		// Token: 0x0400007F RID: 127
		SslNoRenegotiation = -123,
		// Token: 0x04000080 RID: 128
		WinsockUnexpectedWrittenBytes = -124,
		// Token: 0x04000081 RID: 129
		SslDecompressionFailureAlert = -125,
		// Token: 0x04000082 RID: 130
		SslBadRecordMacAlert = -126,
		// Token: 0x04000083 RID: 131
		ProxyAuthRequested = -127,
		// Token: 0x04000084 RID: 132
		ProxyConnectionFailed = -130,
		// Token: 0x04000085 RID: 133
		MandatoryProxyConfigurationFailed = -131,
		// Token: 0x04000086 RID: 134
		PreconnectMaxSocketLimit = -133,
		// Token: 0x04000087 RID: 135
		SslClientAuthPrivateKeyAccessDenied = -134,
		// Token: 0x04000088 RID: 136
		SslClientAuthCertNoPrivateKey = -135,
		// Token: 0x04000089 RID: 137
		ProxyCertificateInvalid = -136,
		// Token: 0x0400008A RID: 138
		NameResolutionFailed = -137,
		// Token: 0x0400008B RID: 139
		NetworkAccessDenied = -138,
		// Token: 0x0400008C RID: 140
		TemporarilyThrottled = -139,
		// Token: 0x0400008D RID: 141
		HttpsProxyTunnelResponseRedirect = -140,
		// Token: 0x0400008E RID: 142
		SslClientAuthSignatureFailed = -141,
		// Token: 0x0400008F RID: 143
		MsgTooBig = -142,
		// Token: 0x04000090 RID: 144
		WsProtocolError = -145,
		// Token: 0x04000091 RID: 145
		AddressInUse = -147,
		// Token: 0x04000092 RID: 146
		SslHandshakeNotCompleted = -148,
		// Token: 0x04000093 RID: 147
		SslBadPeerPublicKey = -149,
		// Token: 0x04000094 RID: 148
		SslPinnedKeyNotInCertChain = -150,
		// Token: 0x04000095 RID: 149
		ClientAuthCertTypeUnsupported = -151,
		// Token: 0x04000096 RID: 150
		SslDecryptErrorAlert = -153,
		// Token: 0x04000097 RID: 151
		WsThrottleQueueTooLarge = -154,
		// Token: 0x04000098 RID: 152
		SslServerCertChanged = -156,
		// Token: 0x04000099 RID: 153
		SslUnrecognizedNameAlert = -159,
		// Token: 0x0400009A RID: 154
		SocketSetReceiveBufferSizeError = -160,
		// Token: 0x0400009B RID: 155
		SocketSetSendBufferSizeError = -161,
		// Token: 0x0400009C RID: 156
		SocketReceiveBufferSizeUnchangeable = -162,
		// Token: 0x0400009D RID: 157
		SocketSendBufferSizeUnchangeable = -163,
		// Token: 0x0400009E RID: 158
		SslClientAuthCertBadFormat = -164,
		// Token: 0x0400009F RID: 159
		ICANNNameCollision = -166,
		// Token: 0x040000A0 RID: 160
		SslServerCertBadFormat = -167,
		// Token: 0x040000A1 RID: 161
		CtSthParsingFailed = -168,
		// Token: 0x040000A2 RID: 162
		CtSthIncomplete = -169,
		// Token: 0x040000A3 RID: 163
		UnableToReuseConnectionForProxyAuth = -170,
		// Token: 0x040000A4 RID: 164
		CtConsistencyProofParsingFailed = -171,
		// Token: 0x040000A5 RID: 165
		SslObsoleteCipher = -172,
		// Token: 0x040000A6 RID: 166
		WsUpgrade = -173,
		// Token: 0x040000A7 RID: 167
		ReadIfReadyNotImplemented = -174,
		// Token: 0x040000A8 RID: 168
		NoBufferSpace = -176,
		// Token: 0x040000A9 RID: 169
		SslClientAuthNoCommonAlgorithms = -177,
		// Token: 0x040000AA RID: 170
		EarlyDataRejected = -178,
		// Token: 0x040000AB RID: 171
		WrongVersionOnEarlyData = -179,
		// Token: 0x040000AC RID: 172
		Tls13DowngradeDetected = -180,
		// Token: 0x040000AD RID: 173
		SslKeyUsageIncompatible = -181,
		// Token: 0x040000AE RID: 174
		InvalidEchConfigList = -182,
		// Token: 0x040000AF RID: 175
		EchNotNegotiated = -183,
		// Token: 0x040000B0 RID: 176
		EchFallbackCertificateInvalid = -184,
		// Token: 0x040000B1 RID: 177
		CertCommonNameInvalid = -200,
		// Token: 0x040000B2 RID: 178
		CertDateInvalid = -201,
		// Token: 0x040000B3 RID: 179
		CertAuthorityInvalid = -202,
		// Token: 0x040000B4 RID: 180
		CertContainsErrors = -203,
		// Token: 0x040000B5 RID: 181
		CertNoRevocationMechanism = -204,
		// Token: 0x040000B6 RID: 182
		CertUnableToCheckRevocation = -205,
		// Token: 0x040000B7 RID: 183
		CertRevoked = -206,
		// Token: 0x040000B8 RID: 184
		CertInvalid = -207,
		// Token: 0x040000B9 RID: 185
		CertWeakSignatureAlgorithm = -208,
		// Token: 0x040000BA RID: 186
		CertNonUniqueName = -210,
		// Token: 0x040000BB RID: 187
		CertWeakKey = -211,
		// Token: 0x040000BC RID: 188
		CertNameConstraintViolation = -212,
		// Token: 0x040000BD RID: 189
		CertValidityTooLong = -213,
		// Token: 0x040000BE RID: 190
		CertificateTransparencyRequired = -214,
		// Token: 0x040000BF RID: 191
		CertSymantecLegacy = -215,
		// Token: 0x040000C0 RID: 192
		CertKnownInterceptionBlocked = -217,
		// Token: 0x040000C1 RID: 193
		CertEnd = -219,
		// Token: 0x040000C2 RID: 194
		InvalidUrl = -300,
		// Token: 0x040000C3 RID: 195
		DisallowedUrlScheme = -301,
		// Token: 0x040000C4 RID: 196
		UnknownUrlScheme = -302,
		// Token: 0x040000C5 RID: 197
		InvalidRedirect = -303,
		// Token: 0x040000C6 RID: 198
		TooManyRedirects = -310,
		// Token: 0x040000C7 RID: 199
		UnsafeRedirect = -311,
		// Token: 0x040000C8 RID: 200
		UnsafePort = -312,
		// Token: 0x040000C9 RID: 201
		InvalidResponse = -320,
		// Token: 0x040000CA RID: 202
		InvalidChunkedEncoding = -321,
		// Token: 0x040000CB RID: 203
		MethodNotSupported = -322,
		// Token: 0x040000CC RID: 204
		UnexpectedProxyAuth = -323,
		// Token: 0x040000CD RID: 205
		EmptyResponse = -324,
		// Token: 0x040000CE RID: 206
		ResponseHeadersTooBig = -325,
		// Token: 0x040000CF RID: 207
		PacScriptFailed = -327,
		// Token: 0x040000D0 RID: 208
		RequestRangeNotSatisfiable = -328,
		// Token: 0x040000D1 RID: 209
		MalformedIdentity = -329,
		// Token: 0x040000D2 RID: 210
		ContentDecodingFailed = -330,
		// Token: 0x040000D3 RID: 211
		NetworkIoSuspended = -331,
		// Token: 0x040000D4 RID: 212
		SynReplyNotReceived = -332,
		// Token: 0x040000D5 RID: 213
		EncodingConversionFailed = -333,
		// Token: 0x040000D6 RID: 214
		UnrecognizedFtpDirectoryListingFormat = -334,
		// Token: 0x040000D7 RID: 215
		NoSupportedProxies = -336,
		// Token: 0x040000D8 RID: 216
		Http2ProtocolError = -337,
		// Token: 0x040000D9 RID: 217
		InvalidAuthCredentials = -338,
		// Token: 0x040000DA RID: 218
		UnsupportedAuthScheme = -339,
		// Token: 0x040000DB RID: 219
		EncodingDetectionFailed = -340,
		// Token: 0x040000DC RID: 220
		MissingAuthCredentials = -341,
		// Token: 0x040000DD RID: 221
		UnexpectedSecurityLibraryStatus = -342,
		// Token: 0x040000DE RID: 222
		MisconfiguredAuthEnvironment = -343,
		// Token: 0x040000DF RID: 223
		UndocumentedSecurityLibraryStatus = -344,
		// Token: 0x040000E0 RID: 224
		ResponseBodyTooBigToDrain = -345,
		// Token: 0x040000E1 RID: 225
		ResponseHeadersMultipleContentLength = -346,
		// Token: 0x040000E2 RID: 226
		IncompleteHttp2Headers = -347,
		// Token: 0x040000E3 RID: 227
		PacNotInDhcp = -348,
		// Token: 0x040000E4 RID: 228
		ResponseHeadersMultipleContentDisposition = -349,
		// Token: 0x040000E5 RID: 229
		ResponseHeadersMultipleLocation = -350,
		// Token: 0x040000E6 RID: 230
		Http2ServerRefusedStream = -351,
		// Token: 0x040000E7 RID: 231
		Http2PingFailed = -352,
		// Token: 0x040000E8 RID: 232
		ContentLengthMismatch = -354,
		// Token: 0x040000E9 RID: 233
		IncompleteChunkedEncoding = -355,
		// Token: 0x040000EA RID: 234
		QuicProtocolError = -356,
		// Token: 0x040000EB RID: 235
		ResponseHeadersTruncated = -357,
		// Token: 0x040000EC RID: 236
		QuicHandshakeFailed = -358,
		// Token: 0x040000ED RID: 237
		Http2InadequateTransportSecurity = -360,
		// Token: 0x040000EE RID: 238
		Http2FlowControlError = -361,
		// Token: 0x040000EF RID: 239
		Http2FrameSizeError = -362,
		// Token: 0x040000F0 RID: 240
		Http2CompressionError = -363,
		// Token: 0x040000F1 RID: 241
		ProxyAuthRequestedWithNoConnection = -364,
		// Token: 0x040000F2 RID: 242
		Http11Required = -365,
		// Token: 0x040000F3 RID: 243
		ProxyHttp11Required = -366,
		// Token: 0x040000F4 RID: 244
		PacScriptTerminated = -367,
		// Token: 0x040000F5 RID: 245
		InvalidHttpResponse = -370,
		// Token: 0x040000F6 RID: 246
		ContentDecodingInitFailed = -371,
		// Token: 0x040000F7 RID: 247
		Http2RstStreamNoErrorReceived = -372,
		// Token: 0x040000F8 RID: 248
		Http2PushedStreamNotAvailable = -373,
		// Token: 0x040000F9 RID: 249
		Http2ClaimedPushedStreamResetByServer = -374,
		// Token: 0x040000FA RID: 250
		TooManyRetries = -375,
		// Token: 0x040000FB RID: 251
		Http2StreamClosed = -376,
		// Token: 0x040000FC RID: 252
		Http2ClientRefusedStream = -377,
		// Token: 0x040000FD RID: 253
		Http2PushedResponseDoesNotMatch = -378,
		// Token: 0x040000FE RID: 254
		HttpResponseCodeFailure = -379,
		// Token: 0x040000FF RID: 255
		QuicCertRootNotKnown = -380,
		// Token: 0x04000100 RID: 256
		QuicGoawayRequestCanBeRetried = -381,
		// Token: 0x04000101 RID: 257
		CacheMiss = -400,
		// Token: 0x04000102 RID: 258
		CacheReadFailure = -401,
		// Token: 0x04000103 RID: 259
		CacheWriteFailure = -402,
		// Token: 0x04000104 RID: 260
		CacheOperationNotSupported = -403,
		// Token: 0x04000105 RID: 261
		CacheOpenFailure = -404,
		// Token: 0x04000106 RID: 262
		CacheCreateFailure = -405,
		// Token: 0x04000107 RID: 263
		CacheRace = -406,
		// Token: 0x04000108 RID: 264
		CacheChecksumReadFailure = -407,
		// Token: 0x04000109 RID: 265
		CacheChecksumMismatch = -408,
		// Token: 0x0400010A RID: 266
		CacheLockTimeout = -409,
		// Token: 0x0400010B RID: 267
		CacheAuthFailureAfterRead = -410,
		// Token: 0x0400010C RID: 268
		CacheEntryNotSuitable = -411,
		// Token: 0x0400010D RID: 269
		CacheDoomFailure = -412,
		// Token: 0x0400010E RID: 270
		CacheOpenOrCreateFailure = -413,
		// Token: 0x0400010F RID: 271
		InsecureResponse = -501,
		// Token: 0x04000110 RID: 272
		NoPrivateKeyForCert = -502,
		// Token: 0x04000111 RID: 273
		AddUserCertFailed = -503,
		// Token: 0x04000112 RID: 274
		InvalidSignedExchange = -504,
		// Token: 0x04000113 RID: 275
		InvalidWebBundle = -505,
		// Token: 0x04000114 RID: 276
		TrustTokenOperationFailed = -506,
		// Token: 0x04000115 RID: 277
		TrustTokenOperationSuccessWithoutSendingRequest = -507,
		// Token: 0x04000116 RID: 278
		FtpFailed = -601,
		// Token: 0x04000117 RID: 279
		FtpServiceUnavailable = -602,
		// Token: 0x04000118 RID: 280
		FtpTransferAborted = -603,
		// Token: 0x04000119 RID: 281
		FtpFileBusy = -604,
		// Token: 0x0400011A RID: 282
		FtpSyntaxError = -605,
		// Token: 0x0400011B RID: 283
		FtpCommandNotSupported = -606,
		// Token: 0x0400011C RID: 284
		FtpBadCommandSequence = -607,
		// Token: 0x0400011D RID: 285
		Pkcs12ImportBadPassword = -701,
		// Token: 0x0400011E RID: 286
		Pkcs12ImportFailed = -702,
		// Token: 0x0400011F RID: 287
		ImportCaCertNotCa = -703,
		// Token: 0x04000120 RID: 288
		ImportCertAlreadyExists = -704,
		// Token: 0x04000121 RID: 289
		ImportCaCertFailed = -705,
		// Token: 0x04000122 RID: 290
		ImportServerCertFailed = -706,
		// Token: 0x04000123 RID: 291
		Pkcs12ImportInvalidMac = -707,
		// Token: 0x04000124 RID: 292
		Pkcs12ImportInvalidFile = -708,
		// Token: 0x04000125 RID: 293
		Pkcs12ImportUnsupported = -709,
		// Token: 0x04000126 RID: 294
		KeyGenerationFailed = -710,
		// Token: 0x04000127 RID: 295
		PrivateKeyExportFailed = -712,
		// Token: 0x04000128 RID: 296
		SelfSignedCertGenerationFailed = -713,
		// Token: 0x04000129 RID: 297
		CertDatabaseChanged = -714,
		// Token: 0x0400012A RID: 298
		DnsMalformedResponse = -800,
		// Token: 0x0400012B RID: 299
		DnsServerRequiresTcp = -801,
		// Token: 0x0400012C RID: 300
		DnsServerFailed = -802,
		// Token: 0x0400012D RID: 301
		DnsTimedOut = -803,
		// Token: 0x0400012E RID: 302
		DnsCacheMiss = -804,
		// Token: 0x0400012F RID: 303
		DnsSearchEmpty = -805,
		// Token: 0x04000130 RID: 304
		DnsSortError = -806,
		// Token: 0x04000131 RID: 305
		DnsSecureResolverHostnameResolutionFailed = -808,
		// Token: 0x04000132 RID: 306
		DnsNameHttpsOnly = -809,
		// Token: 0x04000133 RID: 307
		DnsRequestCancelled = -810
	}
}
