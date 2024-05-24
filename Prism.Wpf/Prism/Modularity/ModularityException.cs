using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Prism.Modularity
{
	// Token: 0x02000058 RID: 88
	[Serializable]
	public class ModularityException : Exception
	{
		// Token: 0x0600026A RID: 618 RVA: 0x00006E0D File Offset: 0x0000500D
		public ModularityException() : this(null)
		{
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00006E16 File Offset: 0x00005016
		public ModularityException(string message) : this(null, message)
		{
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00006E20 File Offset: 0x00005020
		public ModularityException(string message, Exception innerException) : this(null, message, innerException)
		{
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00006E2B File Offset: 0x0000502B
		public ModularityException(string moduleName, string message) : this(moduleName, message, null)
		{
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00006E36 File Offset: 0x00005036
		public ModularityException(string moduleName, string message, Exception innerException) : base(message, innerException)
		{
			this.ModuleName = moduleName;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00006E47 File Offset: 0x00005047
		// (set) Token: 0x06000270 RID: 624 RVA: 0x00006E4F File Offset: 0x0000504F
		public string ModuleName { get; set; }

		// Token: 0x06000271 RID: 625 RVA: 0x00006E58 File Offset: 0x00005058
		protected ModularityException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.ModuleName = (info.GetValue("ModuleName", typeof(string)) as string);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00006E82 File Offset: 0x00005082
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("ModuleName", this.ModuleName);
		}
	}
}
