using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Util;
using System.Text;

namespace System.Security.Permissions
{
	// Token: 0x02000300 RID: 768
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class PermissionSetAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x060026F9 RID: 9977 RVA: 0x0008CFAA File Offset: 0x0008B1AA
		public PermissionSetAttribute(SecurityAction action) : base(action)
		{
			this.m_unicode = false;
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x060026FA RID: 9978 RVA: 0x0008CFBA File Offset: 0x0008B1BA
		// (set) Token: 0x060026FB RID: 9979 RVA: 0x0008CFC2 File Offset: 0x0008B1C2
		public string File
		{
			get
			{
				return this.m_file;
			}
			set
			{
				this.m_file = value;
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x060026FC RID: 9980 RVA: 0x0008CFCB File Offset: 0x0008B1CB
		// (set) Token: 0x060026FD RID: 9981 RVA: 0x0008CFD3 File Offset: 0x0008B1D3
		public bool UnicodeEncoded
		{
			get
			{
				return this.m_unicode;
			}
			set
			{
				this.m_unicode = value;
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x060026FE RID: 9982 RVA: 0x0008CFDC File Offset: 0x0008B1DC
		// (set) Token: 0x060026FF RID: 9983 RVA: 0x0008CFE4 File Offset: 0x0008B1E4
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06002700 RID: 9984 RVA: 0x0008CFED File Offset: 0x0008B1ED
		// (set) Token: 0x06002701 RID: 9985 RVA: 0x0008CFF5 File Offset: 0x0008B1F5
		public string XML
		{
			get
			{
				return this.m_xml;
			}
			set
			{
				this.m_xml = value;
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06002702 RID: 9986 RVA: 0x0008CFFE File Offset: 0x0008B1FE
		// (set) Token: 0x06002703 RID: 9987 RVA: 0x0008D006 File Offset: 0x0008B206
		public string Hex
		{
			get
			{
				return this.m_hex;
			}
			set
			{
				this.m_hex = value;
			}
		}

		// Token: 0x06002704 RID: 9988 RVA: 0x0008D00F File Offset: 0x0008B20F
		public override IPermission CreatePermission()
		{
			return null;
		}

		// Token: 0x06002705 RID: 9989 RVA: 0x0008D014 File Offset: 0x0008B214
		private PermissionSet BruteForceParseStream(Stream stream)
		{
			Encoding[] array = new Encoding[]
			{
				Encoding.UTF8,
				Encoding.ASCII,
				Encoding.Unicode
			};
			StreamReader streamReader = null;
			Exception ex = null;
			int num = 0;
			while (streamReader == null && num < array.Length)
			{
				try
				{
					stream.Position = 0L;
					streamReader = new StreamReader(stream, array[num]);
					return this.ParsePermissionSet(new Parser(streamReader));
				}
				catch (Exception ex2)
				{
					if (ex == null)
					{
						ex = ex2;
					}
				}
				num++;
			}
			throw ex;
		}

		// Token: 0x06002706 RID: 9990 RVA: 0x0008D098 File Offset: 0x0008B298
		private PermissionSet ParsePermissionSet(Parser parser)
		{
			SecurityElement topElement = parser.GetTopElement();
			PermissionSet permissionSet = new PermissionSet(PermissionState.None);
			permissionSet.FromXml(topElement);
			return permissionSet;
		}

		// Token: 0x06002707 RID: 9991 RVA: 0x0008D0BC File Offset: 0x0008B2BC
		[SecuritySafeCritical]
		public PermissionSet CreatePermissionSet()
		{
			if (this.m_unrestricted)
			{
				return new PermissionSet(PermissionState.Unrestricted);
			}
			if (this.m_name != null)
			{
				return PolicyLevel.GetBuiltInSet(this.m_name);
			}
			if (this.m_xml != null)
			{
				return this.ParsePermissionSet(new Parser(this.m_xml.ToCharArray()));
			}
			if (this.m_hex != null)
			{
				return this.BruteForceParseStream(new MemoryStream(System.Security.Util.Hex.DecodeHexString(this.m_hex)));
			}
			if (this.m_file != null)
			{
				return this.BruteForceParseStream(new FileStream(this.m_file, FileMode.Open, FileAccess.Read));
			}
			return new PermissionSet(PermissionState.None);
		}

		// Token: 0x04000F09 RID: 3849
		private string m_file;

		// Token: 0x04000F0A RID: 3850
		private string m_name;

		// Token: 0x04000F0B RID: 3851
		private bool m_unicode;

		// Token: 0x04000F0C RID: 3852
		private string m_xml;

		// Token: 0x04000F0D RID: 3853
		private string m_hex;
	}
}
