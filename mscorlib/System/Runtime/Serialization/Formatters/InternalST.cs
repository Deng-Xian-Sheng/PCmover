using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x02000762 RID: 1890
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class InternalST
	{
		// Token: 0x06005306 RID: 21254 RVA: 0x00123B17 File Offset: 0x00121D17
		private InternalST()
		{
		}

		// Token: 0x06005307 RID: 21255 RVA: 0x00123B1F File Offset: 0x00121D1F
		[Conditional("_LOGGING")]
		public static void InfoSoap(params object[] messages)
		{
		}

		// Token: 0x06005308 RID: 21256 RVA: 0x00123B21 File Offset: 0x00121D21
		public static bool SoapCheckEnabled()
		{
			return BCLDebug.CheckEnabled("Soap");
		}

		// Token: 0x06005309 RID: 21257 RVA: 0x00123B30 File Offset: 0x00121D30
		[Conditional("SER_LOGGING")]
		public static void Soap(params object[] messages)
		{
			if (!(messages[0] is string))
			{
				messages[0] = messages[0].GetType().Name + " ";
				return;
			}
			int num = 0;
			object obj = messages[0];
			messages[num] = ((obj != null) ? obj.ToString() : null) + " ";
		}

		// Token: 0x0600530A RID: 21258 RVA: 0x00123B7E File Offset: 0x00121D7E
		[Conditional("_DEBUG")]
		public static void SoapAssert(bool condition, string message)
		{
		}

		// Token: 0x0600530B RID: 21259 RVA: 0x00123B80 File Offset: 0x00121D80
		public static void SerializationSetValue(FieldInfo fi, object target, object value)
		{
			if (fi == null)
			{
				throw new ArgumentNullException("fi");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			FormatterServices.SerializationSetValue(fi, target, value);
		}

		// Token: 0x0600530C RID: 21260 RVA: 0x00123BBA File Offset: 0x00121DBA
		public static Assembly LoadAssemblyFromString(string assemblyString)
		{
			return FormatterServices.LoadAssemblyFromString(assemblyString);
		}
	}
}
