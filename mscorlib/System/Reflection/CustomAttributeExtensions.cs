using System;
using System.Collections.Generic;

namespace System.Reflection
{
	// Token: 0x020005CC RID: 1484
	[__DynamicallyInvokable]
	public static class CustomAttributeExtensions
	{
		// Token: 0x060044B2 RID: 17586 RVA: 0x000FCFE6 File Offset: 0x000FB1E6
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(this Assembly element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType);
		}

		// Token: 0x060044B3 RID: 17587 RVA: 0x000FCFEF File Offset: 0x000FB1EF
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(this Module element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType);
		}

		// Token: 0x060044B4 RID: 17588 RVA: 0x000FCFF8 File Offset: 0x000FB1F8
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType);
		}

		// Token: 0x060044B5 RID: 17589 RVA: 0x000FD001 File Offset: 0x000FB201
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType)
		{
			return Attribute.GetCustomAttribute(element, attributeType);
		}

		// Token: 0x060044B6 RID: 17590 RVA: 0x000FD00A File Offset: 0x000FB20A
		[__DynamicallyInvokable]
		public static T GetCustomAttribute<T>(this Assembly element) where T : Attribute
		{
			return (T)((object)element.GetCustomAttribute(typeof(T)));
		}

		// Token: 0x060044B7 RID: 17591 RVA: 0x000FD021 File Offset: 0x000FB221
		[__DynamicallyInvokable]
		public static T GetCustomAttribute<T>(this Module element) where T : Attribute
		{
			return (T)((object)element.GetCustomAttribute(typeof(T)));
		}

		// Token: 0x060044B8 RID: 17592 RVA: 0x000FD038 File Offset: 0x000FB238
		[__DynamicallyInvokable]
		public static T GetCustomAttribute<T>(this MemberInfo element) where T : Attribute
		{
			return (T)((object)element.GetCustomAttribute(typeof(T)));
		}

		// Token: 0x060044B9 RID: 17593 RVA: 0x000FD04F File Offset: 0x000FB24F
		[__DynamicallyInvokable]
		public static T GetCustomAttribute<T>(this ParameterInfo element) where T : Attribute
		{
			return (T)((object)element.GetCustomAttribute(typeof(T)));
		}

		// Token: 0x060044BA RID: 17594 RVA: 0x000FD066 File Offset: 0x000FB266
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType, bool inherit)
		{
			return Attribute.GetCustomAttribute(element, attributeType, inherit);
		}

		// Token: 0x060044BB RID: 17595 RVA: 0x000FD070 File Offset: 0x000FB270
		[__DynamicallyInvokable]
		public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType, bool inherit)
		{
			return Attribute.GetCustomAttribute(element, attributeType, inherit);
		}

		// Token: 0x060044BC RID: 17596 RVA: 0x000FD07A File Offset: 0x000FB27A
		[__DynamicallyInvokable]
		public static T GetCustomAttribute<T>(this MemberInfo element, bool inherit) where T : Attribute
		{
			return (T)((object)element.GetCustomAttribute(typeof(T), inherit));
		}

		// Token: 0x060044BD RID: 17597 RVA: 0x000FD092 File Offset: 0x000FB292
		[__DynamicallyInvokable]
		public static T GetCustomAttribute<T>(this ParameterInfo element, bool inherit) where T : Attribute
		{
			return (T)((object)element.GetCustomAttribute(typeof(T), inherit));
		}

		// Token: 0x060044BE RID: 17598 RVA: 0x000FD0AA File Offset: 0x000FB2AA
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element)
		{
			return Attribute.GetCustomAttributes(element);
		}

		// Token: 0x060044BF RID: 17599 RVA: 0x000FD0B2 File Offset: 0x000FB2B2
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this Module element)
		{
			return Attribute.GetCustomAttributes(element);
		}

		// Token: 0x060044C0 RID: 17600 RVA: 0x000FD0BA File Offset: 0x000FB2BA
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element)
		{
			return Attribute.GetCustomAttributes(element);
		}

		// Token: 0x060044C1 RID: 17601 RVA: 0x000FD0C2 File Offset: 0x000FB2C2
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element)
		{
			return Attribute.GetCustomAttributes(element);
		}

		// Token: 0x060044C2 RID: 17602 RVA: 0x000FD0CA File Offset: 0x000FB2CA
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, bool inherit)
		{
			return Attribute.GetCustomAttributes(element, inherit);
		}

		// Token: 0x060044C3 RID: 17603 RVA: 0x000FD0D3 File Offset: 0x000FB2D3
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, bool inherit)
		{
			return Attribute.GetCustomAttributes(element, inherit);
		}

		// Token: 0x060044C4 RID: 17604 RVA: 0x000FD0DC File Offset: 0x000FB2DC
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element, Type attributeType)
		{
			return Attribute.GetCustomAttributes(element, attributeType);
		}

		// Token: 0x060044C5 RID: 17605 RVA: 0x000FD0E5 File Offset: 0x000FB2E5
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this Module element, Type attributeType)
		{
			return Attribute.GetCustomAttributes(element, attributeType);
		}

		// Token: 0x060044C6 RID: 17606 RVA: 0x000FD0EE File Offset: 0x000FB2EE
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType)
		{
			return Attribute.GetCustomAttributes(element, attributeType);
		}

		// Token: 0x060044C7 RID: 17607 RVA: 0x000FD0F7 File Offset: 0x000FB2F7
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType)
		{
			return Attribute.GetCustomAttributes(element, attributeType);
		}

		// Token: 0x060044C8 RID: 17608 RVA: 0x000FD100 File Offset: 0x000FB300
		[__DynamicallyInvokable]
		public static IEnumerable<T> GetCustomAttributes<T>(this Assembly element) where T : Attribute
		{
			return (IEnumerable<T>)element.GetCustomAttributes(typeof(T));
		}

		// Token: 0x060044C9 RID: 17609 RVA: 0x000FD117 File Offset: 0x000FB317
		[__DynamicallyInvokable]
		public static IEnumerable<T> GetCustomAttributes<T>(this Module element) where T : Attribute
		{
			return (IEnumerable<T>)element.GetCustomAttributes(typeof(T));
		}

		// Token: 0x060044CA RID: 17610 RVA: 0x000FD12E File Offset: 0x000FB32E
		[__DynamicallyInvokable]
		public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element) where T : Attribute
		{
			return (IEnumerable<T>)element.GetCustomAttributes(typeof(T));
		}

		// Token: 0x060044CB RID: 17611 RVA: 0x000FD145 File Offset: 0x000FB345
		[__DynamicallyInvokable]
		public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element) where T : Attribute
		{
			return (IEnumerable<T>)element.GetCustomAttributes(typeof(T));
		}

		// Token: 0x060044CC RID: 17612 RVA: 0x000FD15C File Offset: 0x000FB35C
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType, bool inherit)
		{
			return Attribute.GetCustomAttributes(element, attributeType, inherit);
		}

		// Token: 0x060044CD RID: 17613 RVA: 0x000FD166 File Offset: 0x000FB366
		[__DynamicallyInvokable]
		public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType, bool inherit)
		{
			return Attribute.GetCustomAttributes(element, attributeType, inherit);
		}

		// Token: 0x060044CE RID: 17614 RVA: 0x000FD170 File Offset: 0x000FB370
		[__DynamicallyInvokable]
		public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element, bool inherit) where T : Attribute
		{
			return (IEnumerable<T>)element.GetCustomAttributes(typeof(T), inherit);
		}

		// Token: 0x060044CF RID: 17615 RVA: 0x000FD188 File Offset: 0x000FB388
		[__DynamicallyInvokable]
		public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element, bool inherit) where T : Attribute
		{
			return (IEnumerable<T>)element.GetCustomAttributes(typeof(T), inherit);
		}

		// Token: 0x060044D0 RID: 17616 RVA: 0x000FD1A0 File Offset: 0x000FB3A0
		[__DynamicallyInvokable]
		public static bool IsDefined(this Assembly element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType);
		}

		// Token: 0x060044D1 RID: 17617 RVA: 0x000FD1A9 File Offset: 0x000FB3A9
		[__DynamicallyInvokable]
		public static bool IsDefined(this Module element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType);
		}

		// Token: 0x060044D2 RID: 17618 RVA: 0x000FD1B2 File Offset: 0x000FB3B2
		[__DynamicallyInvokable]
		public static bool IsDefined(this MemberInfo element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType);
		}

		// Token: 0x060044D3 RID: 17619 RVA: 0x000FD1BB File Offset: 0x000FB3BB
		[__DynamicallyInvokable]
		public static bool IsDefined(this ParameterInfo element, Type attributeType)
		{
			return Attribute.IsDefined(element, attributeType);
		}

		// Token: 0x060044D4 RID: 17620 RVA: 0x000FD1C4 File Offset: 0x000FB3C4
		[__DynamicallyInvokable]
		public static bool IsDefined(this MemberInfo element, Type attributeType, bool inherit)
		{
			return Attribute.IsDefined(element, attributeType, inherit);
		}

		// Token: 0x060044D5 RID: 17621 RVA: 0x000FD1CE File Offset: 0x000FB3CE
		[__DynamicallyInvokable]
		public static bool IsDefined(this ParameterInfo element, Type attributeType, bool inherit)
		{
			return Attribute.IsDefined(element, attributeType, inherit);
		}
	}
}
