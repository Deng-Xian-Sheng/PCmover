using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x020000E5 RID: 229
	public class ShellLink : ShellObject
	{
		// Token: 0x060008B9 RID: 2233 RVA: 0x000253C1 File Offset: 0x000235C1
		internal ShellLink(IShellItem2 shellItem)
		{
			this.nativeShellItem = shellItem;
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x000253D4 File Offset: 0x000235D4
		// (set) Token: 0x060008BB RID: 2235 RVA: 0x00025413 File Offset: 0x00023613
		public virtual string Path
		{
			get
			{
				if (this._internalPath == null && this.NativeShellItem != null)
				{
					this._internalPath = base.ParsingName;
				}
				return this._internalPath;
			}
			protected set
			{
				this._internalPath = value;
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x00025420 File Offset: 0x00023620
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x00025478 File Offset: 0x00023678
		public string TargetLocation
		{
			get
			{
				if (string.IsNullOrEmpty(this.internalTargetLocation) && this.NativeShellItem2 != null)
				{
					this.internalTargetLocation = base.Properties.System.Link.TargetParsingPath.Value;
				}
				return this.internalTargetLocation;
			}
			set
			{
				if (value != null)
				{
					this.internalTargetLocation = value;
					if (this.NativeShellItem2 != null)
					{
						base.Properties.System.Link.TargetParsingPath.Value = this.internalTargetLocation;
					}
				}
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x000254CC File Offset: 0x000236CC
		public ShellObject TargetShellObject
		{
			get
			{
				return ShellObjectFactory.Create(this.TargetLocation);
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x000254EC File Offset: 0x000236EC
		// (set) Token: 0x060008C0 RID: 2240 RVA: 0x00025528 File Offset: 0x00023728
		public string Title
		{
			get
			{
				string result;
				if (this.NativeShellItem2 != null)
				{
					result = base.Properties.System.Title.Value;
				}
				else
				{
					result = null;
				}
				return result;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.NativeShellItem2 != null)
				{
					base.Properties.System.Title.Value = value;
				}
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x00025574 File Offset: 0x00023774
		public string Arguments
		{
			get
			{
				if (string.IsNullOrEmpty(this.internalArguments) && this.NativeShellItem2 != null)
				{
					this.internalArguments = base.Properties.System.Link.Arguments.Value;
				}
				return this.internalArguments;
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x000255CC File Offset: 0x000237CC
		public string Comments
		{
			get
			{
				if (string.IsNullOrEmpty(this.internalComments) && this.NativeShellItem2 != null)
				{
					this.internalComments = base.Properties.System.Comment.Value;
				}
				return this.internalComments;
			}
		}

		// Token: 0x04000435 RID: 1077
		private string _internalPath;

		// Token: 0x04000436 RID: 1078
		private string internalTargetLocation;

		// Token: 0x04000437 RID: 1079
		private string internalArguments;

		// Token: 0x04000438 RID: 1080
		private string internalComments;
	}
}
