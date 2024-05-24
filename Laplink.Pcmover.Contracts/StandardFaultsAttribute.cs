using System;
using System.ComponentModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000066 RID: 102
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
	public class StandardFaultsAttribute : Attribute, IContractBehavior
	{
		// Token: 0x060002C9 RID: 713 RVA: 0x00003AF2 File Offset: 0x00001CF2
		public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00003AF2 File Offset: 0x00001CF2
		public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00003AF2 File Offset: 0x00001CF2
		public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
		{
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00003AF4 File Offset: 0x00001CF4
		public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
		{
			foreach (OperationDescription operationDescription in contractDescription.Operations)
			{
				foreach (Type detailType in StandardFaultsAttribute.Faults)
				{
					operationDescription.Faults.Add(this.MakeFault(detailType));
				}
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00003B68 File Offset: 0x00001D68
		private FaultDescription MakeFault(Type detailType)
		{
			string action = detailType.Name;
			DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(detailType, typeof(DescriptionAttribute));
			if (descriptionAttribute != null)
			{
				action = descriptionAttribute.Description;
			}
			return new FaultDescription(action)
			{
				DetailType = detailType,
				Name = detailType.Name
			};
		}

		// Token: 0x04000267 RID: 615
		private static Type[] Faults = new Type[]
		{
			typeof(UnauthorizedAccessException)
		};
	}
}
