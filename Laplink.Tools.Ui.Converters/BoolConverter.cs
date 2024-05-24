using System;
using Laplink.Tools.Ui.Converters.Properties;

namespace Laplink.Tools.Ui.Converters
{
	// Token: 0x02000002 RID: 2
	public class BoolConverter
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public string FalseValue { get; set; } = Resources.NO;

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public string TrueValue { get; set; } = Resources.YES;

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		public string NullValue { get; set; } = string.Empty;

		// Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
		public string Convert(bool? value)
		{
			if (value == null)
			{
				return this.NullValue;
			}
			if (!value.Value)
			{
				return this.FalseValue;
			}
			return this.TrueValue;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020AC File Offset: 0x000002AC
		public bool? ConvertBack(string sValue)
		{
			if (sValue == null)
			{
				return null;
			}
			if (string.Compare(sValue, this.NullValue, true) == 0)
			{
				return null;
			}
			return new bool?(string.Compare(sValue, this.TrueValue, true) == 0);
		}
	}
}
