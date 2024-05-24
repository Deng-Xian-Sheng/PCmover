using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Prism.Properties
{
	// Token: 0x02000003 RID: 3
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002050 File Offset: 0x00000250
		internal Resources()
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002058 File Offset: 0x00000258
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Prism.Properties.Resources", typeof(Resources).GetTypeInfo().Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002089 File Offset: 0x00000289
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002090 File Offset: 0x00000290
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002098 File Offset: 0x00000298
		internal static string CannotRegisterCompositeCommandInItself
		{
			get
			{
				return Resources.ResourceManager.GetString("CannotRegisterCompositeCommandInItself", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020AE File Offset: 0x000002AE
		internal static string CannotRegisterSameCommandTwice
		{
			get
			{
				return Resources.ResourceManager.GetString("CannotRegisterSameCommandTwice", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020C4 File Offset: 0x000002C4
		internal static string DefaultDebugLoggerPattern
		{
			get
			{
				return Resources.ResourceManager.GetString("DefaultDebugLoggerPattern", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020DA File Offset: 0x000002DA
		internal static string DelegateCommandDelegatesCannotBeNull
		{
			get
			{
				return Resources.ResourceManager.GetString("DelegateCommandDelegatesCannotBeNull", Resources.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020F0 File Offset: 0x000002F0
		internal static string DelegateCommandInvalidGenericPayloadType
		{
			get
			{
				return Resources.ResourceManager.GetString("DelegateCommandInvalidGenericPayloadType", Resources.resourceCulture);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002106 File Offset: 0x00000306
		internal static string EventAggregatorNotConstructedOnUIThread
		{
			get
			{
				return Resources.ResourceManager.GetString("EventAggregatorNotConstructedOnUIThread", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000211C File Offset: 0x0000031C
		internal static string InvalidDelegateRerefenceTypeException
		{
			get
			{
				return Resources.ResourceManager.GetString("InvalidDelegateRerefenceTypeException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002132 File Offset: 0x00000332
		internal static string InvalidPropertyNameException
		{
			get
			{
				return Resources.ResourceManager.GetString("InvalidPropertyNameException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002148 File Offset: 0x00000348
		internal static string PropertySupport_ExpressionNotProperty_Exception
		{
			get
			{
				return Resources.ResourceManager.GetString("PropertySupport_ExpressionNotProperty_Exception", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000012 RID: 18 RVA: 0x0000215E File Offset: 0x0000035E
		internal static string PropertySupport_NotMemberAccessExpression_Exception
		{
			get
			{
				return Resources.ResourceManager.GetString("PropertySupport_NotMemberAccessExpression_Exception", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002174 File Offset: 0x00000374
		internal static string PropertySupport_StaticExpression_Exception
		{
			get
			{
				return Resources.ResourceManager.GetString("PropertySupport_StaticExpression_Exception", Resources.resourceCulture);
			}
		}

		// Token: 0x04000001 RID: 1
		private static ResourceManager resourceMan;

		// Token: 0x04000002 RID: 2
		private static CultureInfo resourceCulture;
	}
}
