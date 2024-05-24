using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009F1 RID: 2545
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	internal sealed class ManagedActivationFactory : IActivationFactory, IManagedActivationFactory
	{
		// Token: 0x060064B9 RID: 25785 RVA: 0x00157190 File Offset: 0x00155390
		[SecurityCritical]
		internal ManagedActivationFactory(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!(type is RuntimeType) || !type.IsExportedToWindowsRuntime)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeNotActivatableViaWindowsRuntime", new object[]
				{
					type
				}), "type");
			}
			this.m_type = type;
		}

		// Token: 0x060064BA RID: 25786 RVA: 0x001571F0 File Offset: 0x001553F0
		public object ActivateInstance()
		{
			object result;
			try
			{
				result = Activator.CreateInstance(this.m_type);
			}
			catch (MissingMethodException)
			{
				throw new NotImplementedException();
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
			return result;
		}

		// Token: 0x060064BB RID: 25787 RVA: 0x00157238 File Offset: 0x00155438
		void IManagedActivationFactory.RunClassConstructor()
		{
			RuntimeHelpers.RunClassConstructor(this.m_type.TypeHandle);
		}

		// Token: 0x04002CF5 RID: 11509
		private Type m_type;
	}
}
