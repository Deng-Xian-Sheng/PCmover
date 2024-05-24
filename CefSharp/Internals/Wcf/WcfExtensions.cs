using System;
using System.ServiceModel.Description;

namespace CefSharp.Internals.Wcf
{
	// Token: 0x020000F3 RID: 243
	internal static class WcfExtensions
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x0000BDB8 File Offset: 0x00009FB8
		public static void ApplyOperationBehavior<T>(this ServiceDescription description, Func<OperationDescription, T> behaviorFactory, Action<T> behaviorManipulation) where T : class, IOperationBehavior
		{
			foreach (ServiceEndpoint endpoint in description.Endpoints)
			{
				endpoint.ApplyOperationBehavior(behaviorFactory, behaviorManipulation);
			}
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0000BE08 File Offset: 0x0000A008
		public static void ApplyOperationBehavior<T>(this ServiceEndpoint endpoint, Func<OperationDescription, T> behaviorFactory, Action<T> behaviorManipulation) where T : class, IOperationBehavior
		{
			foreach (OperationDescription operationDescription in endpoint.Contract.Operations)
			{
				T t = operationDescription.Behaviors.Find<T>();
				if (t == null)
				{
					t = behaviorFactory(operationDescription);
					operationDescription.Behaviors.Add(t);
				}
				behaviorManipulation(t);
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0000BE88 File Offset: 0x0000A088
		public static void ApplyServiceBehavior<T>(this ServiceDescription description, Func<T> behaviorFactory, Action<T> behaviorManipulation) where T : class, IServiceBehavior
		{
			T t = description.Behaviors.Find<T>();
			if (t == null)
			{
				t = behaviorFactory();
				description.Behaviors.Add(t);
			}
			behaviorManipulation(t);
		}
	}
}
