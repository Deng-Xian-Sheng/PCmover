using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000918 RID: 2328
	[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	public sealed class TypeLibImportClassAttribute : Attribute
	{
		// Token: 0x06005FFB RID: 24571 RVA: 0x0014B5EC File Offset: 0x001497EC
		public TypeLibImportClassAttribute(Type importClass)
		{
			this._importClassName = importClass.ToString();
		}

		// Token: 0x170010D6 RID: 4310
		// (get) Token: 0x06005FFC RID: 24572 RVA: 0x0014B600 File Offset: 0x00149800
		public string Value
		{
			get
			{
				return this._importClassName;
			}
		}

		// Token: 0x04002A6B RID: 10859
		internal string _importClassName;
	}
}
