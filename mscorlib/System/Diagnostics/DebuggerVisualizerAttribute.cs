using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003EF RID: 1007
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	[ComVisible(true)]
	public sealed class DebuggerVisualizerAttribute : Attribute
	{
		// Token: 0x0600331E RID: 13086 RVA: 0x000C4D16 File Offset: 0x000C2F16
		public DebuggerVisualizerAttribute(string visualizerTypeName)
		{
			this.visualizerName = visualizerTypeName;
		}

		// Token: 0x0600331F RID: 13087 RVA: 0x000C4D25 File Offset: 0x000C2F25
		public DebuggerVisualizerAttribute(string visualizerTypeName, string visualizerObjectSourceTypeName)
		{
			this.visualizerName = visualizerTypeName;
			this.visualizerObjectSourceName = visualizerObjectSourceTypeName;
		}

		// Token: 0x06003320 RID: 13088 RVA: 0x000C4D3B File Offset: 0x000C2F3B
		public DebuggerVisualizerAttribute(string visualizerTypeName, Type visualizerObjectSource)
		{
			if (visualizerObjectSource == null)
			{
				throw new ArgumentNullException("visualizerObjectSource");
			}
			this.visualizerName = visualizerTypeName;
			this.visualizerObjectSourceName = visualizerObjectSource.AssemblyQualifiedName;
		}

		// Token: 0x06003321 RID: 13089 RVA: 0x000C4D6A File Offset: 0x000C2F6A
		public DebuggerVisualizerAttribute(Type visualizer)
		{
			if (visualizer == null)
			{
				throw new ArgumentNullException("visualizer");
			}
			this.visualizerName = visualizer.AssemblyQualifiedName;
		}

		// Token: 0x06003322 RID: 13090 RVA: 0x000C4D94 File Offset: 0x000C2F94
		public DebuggerVisualizerAttribute(Type visualizer, Type visualizerObjectSource)
		{
			if (visualizer == null)
			{
				throw new ArgumentNullException("visualizer");
			}
			if (visualizerObjectSource == null)
			{
				throw new ArgumentNullException("visualizerObjectSource");
			}
			this.visualizerName = visualizer.AssemblyQualifiedName;
			this.visualizerObjectSourceName = visualizerObjectSource.AssemblyQualifiedName;
		}

		// Token: 0x06003323 RID: 13091 RVA: 0x000C4DE7 File Offset: 0x000C2FE7
		public DebuggerVisualizerAttribute(Type visualizer, string visualizerObjectSourceTypeName)
		{
			if (visualizer == null)
			{
				throw new ArgumentNullException("visualizer");
			}
			this.visualizerName = visualizer.AssemblyQualifiedName;
			this.visualizerObjectSourceName = visualizerObjectSourceTypeName;
		}

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x06003324 RID: 13092 RVA: 0x000C4E16 File Offset: 0x000C3016
		public string VisualizerObjectSourceTypeName
		{
			get
			{
				return this.visualizerObjectSourceName;
			}
		}

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x06003325 RID: 13093 RVA: 0x000C4E1E File Offset: 0x000C301E
		public string VisualizerTypeName
		{
			get
			{
				return this.visualizerName;
			}
		}

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x06003326 RID: 13094 RVA: 0x000C4E26 File Offset: 0x000C3026
		// (set) Token: 0x06003327 RID: 13095 RVA: 0x000C4E2E File Offset: 0x000C302E
		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06003329 RID: 13097 RVA: 0x000C4E60 File Offset: 0x000C3060
		// (set) Token: 0x06003328 RID: 13096 RVA: 0x000C4E37 File Offset: 0x000C3037
		public Type Target
		{
			get
			{
				return this.target;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.targetName = value.AssemblyQualifiedName;
				this.target = value;
			}
		}

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x0600332B RID: 13099 RVA: 0x000C4E71 File Offset: 0x000C3071
		// (set) Token: 0x0600332A RID: 13098 RVA: 0x000C4E68 File Offset: 0x000C3068
		public string TargetTypeName
		{
			get
			{
				return this.targetName;
			}
			set
			{
				this.targetName = value;
			}
		}

		// Token: 0x040016A9 RID: 5801
		private string visualizerObjectSourceName;

		// Token: 0x040016AA RID: 5802
		private string visualizerName;

		// Token: 0x040016AB RID: 5803
		private string description;

		// Token: 0x040016AC RID: 5804
		private string targetName;

		// Token: 0x040016AD RID: 5805
		private Type target;
	}
}
