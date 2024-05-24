using System;
using System.Security;

namespace System.Diagnostics
{
	// Token: 0x020003F5 RID: 1013
	[Serializable]
	internal class LogSwitch
	{
		// Token: 0x0600334D RID: 13133 RVA: 0x000C518B File Offset: 0x000C338B
		private LogSwitch()
		{
		}

		// Token: 0x0600334E RID: 13134 RVA: 0x000C5194 File Offset: 0x000C3394
		[SecuritySafeCritical]
		public LogSwitch(string name, string description, LogSwitch parent)
		{
			if (name != null && name.Length == 0)
			{
				throw new ArgumentOutOfRangeException("Name", Environment.GetResourceString("Argument_StringZeroLength"));
			}
			if (name != null && parent != null)
			{
				this.strName = name;
				this.strDescription = description;
				this.iLevel = LoggingLevels.ErrorLevel;
				this.iOldLevel = this.iLevel;
				this.ParentSwitch = parent;
				Log.m_Hashtable.Add(this.strName, this);
				Log.AddLogSwitch(this);
				return;
			}
			throw new ArgumentNullException((name == null) ? "name" : "parent");
		}

		// Token: 0x0600334F RID: 13135 RVA: 0x000C5228 File Offset: 0x000C3428
		[SecuritySafeCritical]
		internal LogSwitch(string name, string description)
		{
			this.strName = name;
			this.strDescription = description;
			this.iLevel = LoggingLevels.ErrorLevel;
			this.iOldLevel = this.iLevel;
			this.ParentSwitch = null;
			Log.m_Hashtable.Add(this.strName, this);
			Log.AddLogSwitch(this);
		}

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x06003350 RID: 13136 RVA: 0x000C5281 File Offset: 0x000C3481
		public virtual string Name
		{
			get
			{
				return this.strName;
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x06003351 RID: 13137 RVA: 0x000C5289 File Offset: 0x000C3489
		public virtual string Description
		{
			get
			{
				return this.strDescription;
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06003352 RID: 13138 RVA: 0x000C5291 File Offset: 0x000C3491
		public virtual LogSwitch Parent
		{
			get
			{
				return this.ParentSwitch;
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06003353 RID: 13139 RVA: 0x000C5299 File Offset: 0x000C3499
		// (set) Token: 0x06003354 RID: 13140 RVA: 0x000C52A4 File Offset: 0x000C34A4
		public virtual LoggingLevels MinimumLevel
		{
			get
			{
				return this.iLevel;
			}
			[SecuritySafeCritical]
			set
			{
				this.iLevel = value;
				this.iOldLevel = value;
				string strParentName = (this.ParentSwitch != null) ? this.ParentSwitch.Name : "";
				if (Debugger.IsAttached)
				{
					Log.ModifyLogSwitch((int)this.iLevel, this.strName, strParentName);
				}
				Log.InvokeLogSwitchLevelHandlers(this, this.iLevel);
			}
		}

		// Token: 0x06003355 RID: 13141 RVA: 0x000C5307 File Offset: 0x000C3507
		public virtual bool CheckLevel(LoggingLevels level)
		{
			return this.iLevel <= level || (this.ParentSwitch != null && this.ParentSwitch.CheckLevel(level));
		}

		// Token: 0x06003356 RID: 13142 RVA: 0x000C532C File Offset: 0x000C352C
		public static LogSwitch GetSwitch(string name)
		{
			return (LogSwitch)Log.m_Hashtable[name];
		}

		// Token: 0x040016C2 RID: 5826
		internal string strName;

		// Token: 0x040016C3 RID: 5827
		internal string strDescription;

		// Token: 0x040016C4 RID: 5828
		private LogSwitch ParentSwitch;

		// Token: 0x040016C5 RID: 5829
		internal volatile LoggingLevels iLevel;

		// Token: 0x040016C6 RID: 5830
		internal volatile LoggingLevels iOldLevel;
	}
}
