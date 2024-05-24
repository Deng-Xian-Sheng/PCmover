using System;
using System.Collections.Generic;
using System.Reflection;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200056E RID: 1390
	internal class akl
	{
		// Token: 0x06003752 RID: 14162 RVA: 0x001DEBF8 File Offset: 0x001DDBF8
		internal akl(Type A_0)
		{
			this.a = A_0;
			this.b = A_0.GetProperties();
			this.e = A_0.GetFields();
		}

		// Token: 0x06003753 RID: 14163 RVA: 0x001DEC68 File Offset: 0x001DDC68
		internal void a()
		{
			this.j = this.a.GetMethod("ContainsKey", new Type[]
			{
				typeof(string)
			});
			if (this.j == null)
			{
				this.j = this.a.GetMethod("ContainsKey", new Type[]
				{
					typeof(object)
				});
			}
			if (this.j == null)
			{
				this.j = this.a.GetMethod("Contains", new Type[]
				{
					typeof(object)
				});
			}
			if (this.j != null)
			{
				this.i = this.a.GetProperty("Item", new Type[]
				{
					typeof(string)
				});
				if (this.i == null)
				{
					this.i = this.a.GetProperty("Item", new Type[]
					{
						typeof(object)
					});
				}
			}
			if (this.i == null)
			{
				this.j = null;
			}
			this.h = true;
		}

		// Token: 0x06003754 RID: 14164 RVA: 0x001DEDBC File Offset: 0x001DDDBC
		internal object a(string A_0, object A_1)
		{
			if (!this.h)
			{
				this.a();
			}
			object value;
			if (this.i != null)
			{
				value = this.i.GetValue(A_1, new object[]
				{
					A_0
				});
			}
			else
			{
				PropertyInfo propertyInfo = this.b(A_0);
				if (propertyInfo != null)
				{
					value = propertyInfo.GetValue(A_1, null);
				}
				else
				{
					FieldInfo fieldInfo = this.a(A_0);
					if (!(fieldInfo != null))
					{
						throw new LayoutEngineException("Object does not contain a " + A_0 + " dictionary key, property or field.");
					}
					value = fieldInfo.GetValue(A_1);
				}
			}
			return value;
		}

		// Token: 0x06003755 RID: 14165 RVA: 0x001DEE68 File Offset: 0x001DDE68
		internal bool b(string A_0, object A_1)
		{
			if (!this.h)
			{
				this.a();
			}
			bool result;
			if (this.j != null)
			{
				object obj = this.j.Invoke(A_1, new object[]
				{
					A_0
				});
				result = (bool)obj;
			}
			else
			{
				PropertyInfo left = this.b(A_0);
				if (left != null)
				{
					result = true;
				}
				else
				{
					FieldInfo left2 = this.a(A_0);
					result = (left2 != null);
				}
			}
			return result;
		}

		// Token: 0x06003756 RID: 14166 RVA: 0x001DEF04 File Offset: 0x001DDF04
		internal object a(int A_0, object A_1)
		{
			if (this.b == null)
			{
				this.b = this.a.GetProperties();
			}
			object result;
			if (A_0 >= this.b.Length || A_0 < 0)
			{
				result = null;
			}
			else
			{
				result = this.b[A_0].GetValue(A_1, null);
			}
			return result;
		}

		// Token: 0x06003757 RID: 14167 RVA: 0x001DEF64 File Offset: 0x001DDF64
		internal Type b()
		{
			return this.a;
		}

		// Token: 0x06003758 RID: 14168 RVA: 0x001DEF7C File Offset: 0x001DDF7C
		private PropertyInfo b(string A_0)
		{
			PropertyInfo propertyInfo = null;
			if (!this.c.TryGetValue(A_0, out propertyInfo))
			{
				propertyInfo = this.a.GetProperty(A_0);
				if (propertyInfo == null)
				{
					if (this.d == null)
					{
						this.d = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
						for (int i = 0; i < this.b.Length; i++)
						{
							if (!this.d.ContainsKey(this.b[i].Name))
							{
								this.d.Add(this.b[i].Name, this.b[i]);
							}
						}
					}
					this.d.TryGetValue(A_0, out propertyInfo);
				}
				else
				{
					this.c.Add(A_0, propertyInfo);
				}
			}
			return propertyInfo;
		}

		// Token: 0x06003759 RID: 14169 RVA: 0x001DF064 File Offset: 0x001DE064
		private FieldInfo a(string A_0)
		{
			FieldInfo fieldInfo = null;
			if (!this.f.TryGetValue(A_0, out fieldInfo))
			{
				fieldInfo = this.a.GetField(A_0);
				if (fieldInfo == null)
				{
					if (this.g == null)
					{
						this.g = new Dictionary<string, FieldInfo>(StringComparer.OrdinalIgnoreCase);
						for (int i = 0; i < this.e.Length; i++)
						{
							if (!this.d.ContainsKey(this.e[i].Name))
							{
								this.d.Add(this.e[i].Name, this.b[i]);
							}
						}
					}
					this.g.TryGetValue(A_0, out fieldInfo);
				}
				else
				{
					this.f.Add(A_0, fieldInfo);
				}
			}
			return fieldInfo;
		}

		// Token: 0x04001A24 RID: 6692
		private Type a;

		// Token: 0x04001A25 RID: 6693
		private PropertyInfo[] b;

		// Token: 0x04001A26 RID: 6694
		private Dictionary<string, PropertyInfo> c = new Dictionary<string, PropertyInfo>();

		// Token: 0x04001A27 RID: 6695
		private Dictionary<string, PropertyInfo> d = null;

		// Token: 0x04001A28 RID: 6696
		private FieldInfo[] e;

		// Token: 0x04001A29 RID: 6697
		private Dictionary<string, FieldInfo> f = new Dictionary<string, FieldInfo>();

		// Token: 0x04001A2A RID: 6698
		private Dictionary<string, FieldInfo> g = null;

		// Token: 0x04001A2B RID: 6699
		private bool h = false;

		// Token: 0x04001A2C RID: 6700
		private PropertyInfo i = null;

		// Token: 0x04001A2D RID: 6701
		private MethodInfo j = null;
	}
}
