using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007EE RID: 2030
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapQName : ISoapXsd
	{
		// Token: 0x17000E83 RID: 3715
		// (get) Token: 0x060057AD RID: 22445 RVA: 0x001363C7 File Offset: 0x001345C7
		public static string XsdType
		{
			get
			{
				return "QName";
			}
		}

		// Token: 0x060057AE RID: 22446 RVA: 0x001363CE File Offset: 0x001345CE
		public string GetXsdType()
		{
			return SoapQName.XsdType;
		}

		// Token: 0x060057AF RID: 22447 RVA: 0x001363D5 File Offset: 0x001345D5
		public SoapQName()
		{
		}

		// Token: 0x060057B0 RID: 22448 RVA: 0x001363DD File Offset: 0x001345DD
		public SoapQName(string value)
		{
			this._name = value;
		}

		// Token: 0x060057B1 RID: 22449 RVA: 0x001363EC File Offset: 0x001345EC
		public SoapQName(string key, string name)
		{
			this._name = name;
			this._key = key;
		}

		// Token: 0x060057B2 RID: 22450 RVA: 0x00136402 File Offset: 0x00134602
		public SoapQName(string key, string name, string namespaceValue)
		{
			this._name = name;
			this._namespace = namespaceValue;
			this._key = key;
		}

		// Token: 0x17000E84 RID: 3716
		// (get) Token: 0x060057B3 RID: 22451 RVA: 0x0013641F File Offset: 0x0013461F
		// (set) Token: 0x060057B4 RID: 22452 RVA: 0x00136427 File Offset: 0x00134627
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000E85 RID: 3717
		// (get) Token: 0x060057B5 RID: 22453 RVA: 0x00136430 File Offset: 0x00134630
		// (set) Token: 0x060057B6 RID: 22454 RVA: 0x00136438 File Offset: 0x00134638
		public string Namespace
		{
			get
			{
				return this._namespace;
			}
			set
			{
				this._namespace = value;
			}
		}

		// Token: 0x17000E86 RID: 3718
		// (get) Token: 0x060057B7 RID: 22455 RVA: 0x00136441 File Offset: 0x00134641
		// (set) Token: 0x060057B8 RID: 22456 RVA: 0x00136449 File Offset: 0x00134649
		public string Key
		{
			get
			{
				return this._key;
			}
			set
			{
				this._key = value;
			}
		}

		// Token: 0x060057B9 RID: 22457 RVA: 0x00136452 File Offset: 0x00134652
		public override string ToString()
		{
			if (this._key == null || this._key.Length == 0)
			{
				return this._name;
			}
			return this._key + ":" + this._name;
		}

		// Token: 0x060057BA RID: 22458 RVA: 0x00136488 File Offset: 0x00134688
		public static SoapQName Parse(string value)
		{
			if (value == null)
			{
				return new SoapQName();
			}
			string key = "";
			string name = value;
			int num = value.IndexOf(':');
			if (num > 0)
			{
				key = value.Substring(0, num);
				name = value.Substring(num + 1);
			}
			return new SoapQName(key, name);
		}

		// Token: 0x04002819 RID: 10265
		private string _name;

		// Token: 0x0400281A RID: 10266
		private string _namespace;

		// Token: 0x0400281B RID: 10267
		private string _key;
	}
}
