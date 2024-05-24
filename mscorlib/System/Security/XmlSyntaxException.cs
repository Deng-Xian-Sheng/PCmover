using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security
{
	// Token: 0x020001C0 RID: 448
	[ComVisible(true)]
	[Serializable]
	public sealed class XmlSyntaxException : SystemException
	{
		// Token: 0x06001C12 RID: 7186 RVA: 0x00060D4E File Offset: 0x0005EF4E
		public XmlSyntaxException() : base(Environment.GetResourceString("XMLSyntax_InvalidSyntax"))
		{
			base.SetErrorCode(-2146233320);
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x00060D6B File Offset: 0x0005EF6B
		public XmlSyntaxException(string message) : base(message)
		{
			base.SetErrorCode(-2146233320);
		}

		// Token: 0x06001C14 RID: 7188 RVA: 0x00060D7F File Offset: 0x0005EF7F
		public XmlSyntaxException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233320);
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x00060D94 File Offset: 0x0005EF94
		public XmlSyntaxException(int lineNumber) : base(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("XMLSyntax_SyntaxError"), lineNumber))
		{
			base.SetErrorCode(-2146233320);
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x00060DC1 File Offset: 0x0005EFC1
		public XmlSyntaxException(int lineNumber, string message) : base(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("XMLSyntax_SyntaxErrorEx"), lineNumber, message))
		{
			base.SetErrorCode(-2146233320);
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x00060DEF File Offset: 0x0005EFEF
		internal XmlSyntaxException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
