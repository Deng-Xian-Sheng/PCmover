using System;
using System.Globalization;

namespace System.Reflection
{
	// Token: 0x020005FE RID: 1534
	internal class MetadataException : Exception
	{
		// Token: 0x060046CB RID: 18123 RVA: 0x00102EB6 File Offset: 0x001010B6
		internal MetadataException(int hr)
		{
			this.m_hr = hr;
		}

		// Token: 0x060046CC RID: 18124 RVA: 0x00102EC5 File Offset: 0x001010C5
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "MetadataException HResult = {0:x}.", this.m_hr);
		}

		// Token: 0x04001D4F RID: 7503
		private int m_hr;
	}
}
