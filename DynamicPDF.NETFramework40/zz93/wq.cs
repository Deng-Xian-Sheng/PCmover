using System;
using System.IO;
using System.Reflection;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000361 RID: 865
	internal class wq
	{
		// Token: 0x06002521 RID: 9505 RVA: 0x0015C7C8 File Offset: 0x0015B7C8
		internal wq(string A_0, Type A_1)
		{
			this.f = new DplxFile(A_0);
			this.g = File.GetLastWriteTime(A_0);
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002522 RID: 9506 RVA: 0x0015C82C File Offset: 0x0015B82C
		internal DocumentLayout a(DplxWebForm A_0)
		{
			if (this.g != File.GetLastWriteTime(this.a))
			{
				this.g = File.GetLastWriteTime(this.a);
				this.f = new DplxFile(this.a);
			}
			DocumentLayout documentLayout = new DocumentLayout(this.f);
			if (!this.e)
			{
				this.a(documentLayout);
				this.e = true;
			}
			for (wq.a a = this.c; a != null; a = a.a())
			{
				a.a(A_0, documentLayout);
			}
			return documentLayout;
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x0015C8D0 File Offset: 0x0015B8D0
		private void a(DocumentLayout A_0)
		{
			MethodInfo[] methods = this.b.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
			for (int i = 0; i < methods.Length; i++)
			{
				int num = methods[i].Name.IndexOf("_");
				if (num > 0)
				{
					string text = methods[i].Name.Substring(0, num);
					string name = methods[i].Name.Substring(num + 1, methods[i].Name.Length - num - 1);
					object obj = A_0.GetElementById(text);
					if (obj == null && A_0.Id == text)
					{
						obj = A_0;
					}
					if (obj != null)
					{
						EventInfo @event = obj.GetType().GetEvent(name);
						if (@event != null)
						{
							this.a(methods[i], @event, text);
						}
					}
				}
			}
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x0015C9C8 File Offset: 0x0015B9C8
		private void a(MethodInfo A_0, EventInfo A_1, string A_2)
		{
			wq.a a = new wq.a(A_0, A_1, A_2);
			if (this.c == null)
			{
				this.c = (this.d = a);
			}
			else
			{
				wq.a a2;
				this.d.a(a2 = a);
				this.d = a2;
			}
		}

		// Token: 0x0400103D RID: 4157
		private string a;

		// Token: 0x0400103E RID: 4158
		private Type b;

		// Token: 0x0400103F RID: 4159
		private wq.a c = null;

		// Token: 0x04001040 RID: 4160
		private wq.a d = null;

		// Token: 0x04001041 RID: 4161
		private bool e = false;

		// Token: 0x04001042 RID: 4162
		private DplxFile f = null;

		// Token: 0x04001043 RID: 4163
		private DateTime g = DateTime.MinValue;

		// Token: 0x02000362 RID: 866
		private class a
		{
			// Token: 0x06002525 RID: 9509 RVA: 0x0015CA1B File Offset: 0x0015BA1B
			internal a(MethodInfo A_0, EventInfo A_1, string A_2)
			{
				this.a = A_0;
				this.b = A_1;
				this.c = A_2;
			}

			// Token: 0x06002526 RID: 9510 RVA: 0x0015CA44 File Offset: 0x0015BA44
			internal wq.a a()
			{
				return this.d;
			}

			// Token: 0x06002527 RID: 9511 RVA: 0x0015CA5C File Offset: 0x0015BA5C
			internal void a(wq.a A_0)
			{
				this.d = A_0;
			}

			// Token: 0x06002528 RID: 9512 RVA: 0x0015CA68 File Offset: 0x0015BA68
			internal void a(DplxWebForm A_0, DocumentLayout A_1)
			{
				object obj = A_1.GetElementById(this.c);
				if (obj == null && A_1.Id == this.c)
				{
					obj = A_1;
				}
				Delegate handler = Delegate.CreateDelegate(this.b.EventHandlerType, A_0, this.a.Name);
				this.b.AddEventHandler(obj, handler);
			}

			// Token: 0x04001044 RID: 4164
			private MethodInfo a;

			// Token: 0x04001045 RID: 4165
			private EventInfo b;

			// Token: 0x04001046 RID: 4166
			private string c;

			// Token: 0x04001047 RID: 4167
			private wq.a d = null;
		}
	}
}
