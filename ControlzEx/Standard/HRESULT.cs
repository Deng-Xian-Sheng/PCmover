using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ControlzEx.Standard
{
	// Token: 0x0200001D RID: 29
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[StructLayout(LayoutKind.Explicit)]
	public struct HRESULT
	{
		// Token: 0x06000151 RID: 337 RVA: 0x000079AD File Offset: 0x00005BAD
		public HRESULT(uint i)
		{
			this._value = i;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000079AD File Offset: 0x00005BAD
		public HRESULT(int i)
		{
			this._value = (uint)i;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000079B6 File Offset: 0x00005BB6
		public static explicit operator int(HRESULT hr)
		{
			return (int)hr._value;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000079BE File Offset: 0x00005BBE
		public static HRESULT Make(bool severe, Facility facility, int code)
		{
			return new HRESULT((uint)((severe ? ((Facility)(-2147483648)) : Facility.Null) | (int)facility << 16 | (Facility)code));
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000079D7 File Offset: 0x00005BD7
		public Facility Facility
		{
			get
			{
				return HRESULT.GetFacility((int)this._value);
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000079E4 File Offset: 0x00005BE4
		public static Facility GetFacility(int errorCode)
		{
			return (Facility)(errorCode >> 16 & 8191);
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000079F0 File Offset: 0x00005BF0
		public int Code
		{
			get
			{
				return HRESULT.GetCode((int)this._value);
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000079FD File Offset: 0x00005BFD
		public static int GetCode(int error)
		{
			return error & 65535;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00007A08 File Offset: 0x00005C08
		public override string ToString()
		{
			foreach (FieldInfo fieldInfo in typeof(HRESULT).GetFields(BindingFlags.Static | BindingFlags.Public))
			{
				if (fieldInfo.FieldType == typeof(HRESULT) && (HRESULT)fieldInfo.GetValue(null) == this)
				{
					return fieldInfo.Name;
				}
			}
			if (this.Facility == Facility.Win32)
			{
				foreach (FieldInfo fieldInfo2 in typeof(Win32Error).GetFields(BindingFlags.Static | BindingFlags.Public))
				{
					if (fieldInfo2.FieldType == typeof(Win32Error) && (HRESULT)((Win32Error)fieldInfo2.GetValue(null)) == this)
					{
						return "HRESULT_FROM_WIN32(" + fieldInfo2.Name + ")";
					}
				}
			}
			return string.Format(CultureInfo.InvariantCulture, "0x{0:X8}", this._value);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00007B04 File Offset: 0x00005D04
		public override bool Equals(object obj)
		{
			bool result;
			try
			{
				result = (((HRESULT)obj)._value == this._value);
			}
			catch (InvalidCastException)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00007B40 File Offset: 0x00005D40
		public override int GetHashCode()
		{
			return this._value.GetHashCode();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00007B5B File Offset: 0x00005D5B
		public static bool operator ==(HRESULT hrLeft, HRESULT hrRight)
		{
			return hrLeft._value == hrRight._value;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00007B6B File Offset: 0x00005D6B
		public static bool operator !=(HRESULT hrLeft, HRESULT hrRight)
		{
			return !(hrLeft == hrRight);
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00007B77 File Offset: 0x00005D77
		public bool Succeeded
		{
			get
			{
				return this._value >= 0U;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00007B85 File Offset: 0x00005D85
		public bool Failed
		{
			get
			{
				return this._value < 0U;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00007B90 File Offset: 0x00005D90
		public void ThrowIfFailed()
		{
			this.ThrowIfFailed(null);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00007B9C File Offset: 0x00005D9C
		public void ThrowIfFailed(string message)
		{
			if (this.Failed)
			{
				if (string.IsNullOrEmpty(message))
				{
					message = this.ToString();
				}
				Exception ex = Marshal.GetExceptionForHR((int)this._value, new IntPtr(-1));
				if (ex.GetType() == typeof(COMException))
				{
					Facility facility = this.Facility;
					if (facility == Facility.Win32)
					{
						ex = new Win32Exception(this.Code, message);
					}
					else
					{
						ex = new COMException(message, (int)this._value);
					}
				}
				else
				{
					ConstructorInfo constructor = ex.GetType().GetConstructor(new Type[]
					{
						typeof(string)
					});
					if (null != constructor)
					{
						ex = (constructor.Invoke(new object[]
						{
							message
						}) as Exception);
					}
				}
				throw ex;
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00007C5C File Offset: 0x00005E5C
		public static void ThrowLastError()
		{
			((HRESULT)Win32Error.GetLastError()).ThrowIfFailed();
		}

		// Token: 0x040000EC RID: 236
		[FieldOffset(0)]
		private readonly uint _value;

		// Token: 0x040000ED RID: 237
		public static readonly HRESULT S_OK = new HRESULT(0);

		// Token: 0x040000EE RID: 238
		public static readonly HRESULT S_FALSE = new HRESULT(1);

		// Token: 0x040000EF RID: 239
		public static readonly HRESULT E_PENDING = new HRESULT(2147483658U);

		// Token: 0x040000F0 RID: 240
		public static readonly HRESULT E_NOTIMPL = new HRESULT(2147500033U);

		// Token: 0x040000F1 RID: 241
		public static readonly HRESULT E_NOINTERFACE = new HRESULT(2147500034U);

		// Token: 0x040000F2 RID: 242
		public static readonly HRESULT E_POINTER = new HRESULT(2147500035U);

		// Token: 0x040000F3 RID: 243
		public static readonly HRESULT E_ABORT = new HRESULT(2147500036U);

		// Token: 0x040000F4 RID: 244
		public static readonly HRESULT E_FAIL = new HRESULT(2147500037U);

		// Token: 0x040000F5 RID: 245
		public static readonly HRESULT E_UNEXPECTED = new HRESULT(2147549183U);

		// Token: 0x040000F6 RID: 246
		public static readonly HRESULT STG_E_INVALIDFUNCTION = new HRESULT(2147680257U);

		// Token: 0x040000F7 RID: 247
		public static readonly HRESULT OLE_E_ADVISENOTSUPPORTED = new HRESULT(2147745795U);

		// Token: 0x040000F8 RID: 248
		public static readonly HRESULT DV_E_FORMATETC = new HRESULT(2147745892U);

		// Token: 0x040000F9 RID: 249
		public static readonly HRESULT DV_E_TYMED = new HRESULT(2147745897U);

		// Token: 0x040000FA RID: 250
		public static readonly HRESULT DV_E_CLIPFORMAT = new HRESULT(2147745898U);

		// Token: 0x040000FB RID: 251
		public static readonly HRESULT DV_E_DVASPECT = new HRESULT(2147745899U);

		// Token: 0x040000FC RID: 252
		public static readonly HRESULT REGDB_E_CLASSNOTREG = new HRESULT(2147746132U);

		// Token: 0x040000FD RID: 253
		public static readonly HRESULT DESTS_E_NO_MATCHING_ASSOC_HANDLER = new HRESULT(2147749635U);

		// Token: 0x040000FE RID: 254
		public static readonly HRESULT DESTS_E_NORECDOCS = new HRESULT(2147749636U);

		// Token: 0x040000FF RID: 255
		public static readonly HRESULT DESTS_E_NOTALLCLEARED = new HRESULT(2147749637U);

		// Token: 0x04000100 RID: 256
		public static readonly HRESULT E_ACCESSDENIED = new HRESULT(2147942405U);

		// Token: 0x04000101 RID: 257
		public static readonly HRESULT E_OUTOFMEMORY = new HRESULT(2147942414U);

		// Token: 0x04000102 RID: 258
		public static readonly HRESULT E_INVALIDARG = new HRESULT(2147942487U);

		// Token: 0x04000103 RID: 259
		public static readonly HRESULT INTSAFE_E_ARITHMETIC_OVERFLOW = new HRESULT(2147942934U);

		// Token: 0x04000104 RID: 260
		public static readonly HRESULT COR_E_OBJECTDISPOSED = new HRESULT(2148734498U);

		// Token: 0x04000105 RID: 261
		public static readonly HRESULT WC_E_GREATERTHAN = new HRESULT(3222072867U);

		// Token: 0x04000106 RID: 262
		public static readonly HRESULT WC_E_SYNTAX = new HRESULT(3222072877U);

		// Token: 0x04000107 RID: 263
		public static readonly HRESULT WINCODEC_ERR_GENERIC_ERROR = HRESULT.E_FAIL;

		// Token: 0x04000108 RID: 264
		public static readonly HRESULT WINCODEC_ERR_INVALIDPARAMETER = HRESULT.E_INVALIDARG;

		// Token: 0x04000109 RID: 265
		public static readonly HRESULT WINCODEC_ERR_OUTOFMEMORY = HRESULT.E_OUTOFMEMORY;

		// Token: 0x0400010A RID: 266
		public static readonly HRESULT WINCODEC_ERR_NOTIMPLEMENTED = HRESULT.E_NOTIMPL;

		// Token: 0x0400010B RID: 267
		public static readonly HRESULT WINCODEC_ERR_ABORTED = HRESULT.E_ABORT;

		// Token: 0x0400010C RID: 268
		public static readonly HRESULT WINCODEC_ERR_ACCESSDENIED = HRESULT.E_ACCESSDENIED;

		// Token: 0x0400010D RID: 269
		public static readonly HRESULT WINCODEC_ERR_VALUEOVERFLOW = HRESULT.INTSAFE_E_ARITHMETIC_OVERFLOW;

		// Token: 0x0400010E RID: 270
		public static readonly HRESULT WINCODEC_ERR_WRONGSTATE = HRESULT.Make(true, Facility.WinCodec, 12036);

		// Token: 0x0400010F RID: 271
		public static readonly HRESULT WINCODEC_ERR_VALUEOUTOFRANGE = HRESULT.Make(true, Facility.WinCodec, 12037);

		// Token: 0x04000110 RID: 272
		public static readonly HRESULT WINCODEC_ERR_UNKNOWNIMAGEFORMAT = HRESULT.Make(true, Facility.WinCodec, 12039);

		// Token: 0x04000111 RID: 273
		public static readonly HRESULT WINCODEC_ERR_UNSUPPORTEDVERSION = HRESULT.Make(true, Facility.WinCodec, 12043);

		// Token: 0x04000112 RID: 274
		public static readonly HRESULT WINCODEC_ERR_NOTINITIALIZED = HRESULT.Make(true, Facility.WinCodec, 12044);

		// Token: 0x04000113 RID: 275
		public static readonly HRESULT WINCODEC_ERR_ALREADYLOCKED = HRESULT.Make(true, Facility.WinCodec, 12045);

		// Token: 0x04000114 RID: 276
		public static readonly HRESULT WINCODEC_ERR_PROPERTYNOTFOUND = HRESULT.Make(true, Facility.WinCodec, 12096);

		// Token: 0x04000115 RID: 277
		public static readonly HRESULT WINCODEC_ERR_PROPERTYNOTSUPPORTED = HRESULT.Make(true, Facility.WinCodec, 12097);

		// Token: 0x04000116 RID: 278
		public static readonly HRESULT WINCODEC_ERR_PROPERTYSIZE = HRESULT.Make(true, Facility.WinCodec, 12098);

		// Token: 0x04000117 RID: 279
		public static readonly HRESULT WINCODEC_ERR_CODECPRESENT = HRESULT.Make(true, Facility.WinCodec, 12099);

		// Token: 0x04000118 RID: 280
		public static readonly HRESULT WINCODEC_ERR_CODECNOTHUMBNAIL = HRESULT.Make(true, Facility.WinCodec, 12100);

		// Token: 0x04000119 RID: 281
		public static readonly HRESULT WINCODEC_ERR_PALETTEUNAVAILABLE = HRESULT.Make(true, Facility.WinCodec, 12101);

		// Token: 0x0400011A RID: 282
		public static readonly HRESULT WINCODEC_ERR_CODECTOOMANYSCANLINES = HRESULT.Make(true, Facility.WinCodec, 12102);

		// Token: 0x0400011B RID: 283
		public static readonly HRESULT WINCODEC_ERR_INTERNALERROR = HRESULT.Make(true, Facility.WinCodec, 12104);

		// Token: 0x0400011C RID: 284
		public static readonly HRESULT WINCODEC_ERR_SOURCERECTDOESNOTMATCHDIMENSIONS = HRESULT.Make(true, Facility.WinCodec, 12105);

		// Token: 0x0400011D RID: 285
		public static readonly HRESULT WINCODEC_ERR_COMPONENTNOTFOUND = HRESULT.Make(true, Facility.WinCodec, 12112);

		// Token: 0x0400011E RID: 286
		public static readonly HRESULT WINCODEC_ERR_IMAGESIZEOUTOFRANGE = HRESULT.Make(true, Facility.WinCodec, 12113);

		// Token: 0x0400011F RID: 287
		public static readonly HRESULT WINCODEC_ERR_TOOMUCHMETADATA = HRESULT.Make(true, Facility.WinCodec, 12114);

		// Token: 0x04000120 RID: 288
		public static readonly HRESULT WINCODEC_ERR_BADIMAGE = HRESULT.Make(true, Facility.WinCodec, 12128);

		// Token: 0x04000121 RID: 289
		public static readonly HRESULT WINCODEC_ERR_BADHEADER = HRESULT.Make(true, Facility.WinCodec, 12129);

		// Token: 0x04000122 RID: 290
		public static readonly HRESULT WINCODEC_ERR_FRAMEMISSING = HRESULT.Make(true, Facility.WinCodec, 12130);

		// Token: 0x04000123 RID: 291
		public static readonly HRESULT WINCODEC_ERR_BADMETADATAHEADER = HRESULT.Make(true, Facility.WinCodec, 12131);

		// Token: 0x04000124 RID: 292
		public static readonly HRESULT WINCODEC_ERR_BADSTREAMDATA = HRESULT.Make(true, Facility.WinCodec, 12144);

		// Token: 0x04000125 RID: 293
		public static readonly HRESULT WINCODEC_ERR_STREAMWRITE = HRESULT.Make(true, Facility.WinCodec, 12145);

		// Token: 0x04000126 RID: 294
		public static readonly HRESULT WINCODEC_ERR_STREAMREAD = HRESULT.Make(true, Facility.WinCodec, 12146);

		// Token: 0x04000127 RID: 295
		public static readonly HRESULT WINCODEC_ERR_STREAMNOTAVAILABLE = HRESULT.Make(true, Facility.WinCodec, 12147);

		// Token: 0x04000128 RID: 296
		public static readonly HRESULT WINCODEC_ERR_UNSUPPORTEDPIXELFORMAT = HRESULT.Make(true, Facility.WinCodec, 12160);

		// Token: 0x04000129 RID: 297
		public static readonly HRESULT WINCODEC_ERR_UNSUPPORTEDOPERATION = HRESULT.Make(true, Facility.WinCodec, 12161);

		// Token: 0x0400012A RID: 298
		public static readonly HRESULT WINCODEC_ERR_INVALIDREGISTRATION = HRESULT.Make(true, Facility.WinCodec, 12170);

		// Token: 0x0400012B RID: 299
		public static readonly HRESULT WINCODEC_ERR_COMPONENTINITIALIZEFAILURE = HRESULT.Make(true, Facility.WinCodec, 12171);

		// Token: 0x0400012C RID: 300
		public static readonly HRESULT WINCODEC_ERR_INSUFFICIENTBUFFER = HRESULT.Make(true, Facility.WinCodec, 12172);

		// Token: 0x0400012D RID: 301
		public static readonly HRESULT WINCODEC_ERR_DUPLICATEMETADATAPRESENT = HRESULT.Make(true, Facility.WinCodec, 12173);

		// Token: 0x0400012E RID: 302
		public static readonly HRESULT WINCODEC_ERR_PROPERTYUNEXPECTEDTYPE = HRESULT.Make(true, Facility.WinCodec, 12174);

		// Token: 0x0400012F RID: 303
		public static readonly HRESULT WINCODEC_ERR_UNEXPECTEDSIZE = HRESULT.Make(true, Facility.WinCodec, 12175);

		// Token: 0x04000130 RID: 304
		public static readonly HRESULT WINCODEC_ERR_INVALIDQUERYREQUEST = HRESULT.Make(true, Facility.WinCodec, 12176);

		// Token: 0x04000131 RID: 305
		public static readonly HRESULT WINCODEC_ERR_UNEXPECTEDMETADATATYPE = HRESULT.Make(true, Facility.WinCodec, 12177);

		// Token: 0x04000132 RID: 306
		public static readonly HRESULT WINCODEC_ERR_REQUESTONLYVALIDATMETADATAROOT = HRESULT.Make(true, Facility.WinCodec, 12178);

		// Token: 0x04000133 RID: 307
		public static readonly HRESULT WINCODEC_ERR_INVALIDQUERYCHARACTER = HRESULT.Make(true, Facility.WinCodec, 12179);
	}
}
