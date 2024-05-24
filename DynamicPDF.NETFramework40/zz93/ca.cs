using System;
using System.IO;
using System.Text;
using System.Xml;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000069 RID: 105
	internal class ca : Resource
	{
		// Token: 0x0600046E RID: 1134 RVA: 0x00049C86 File Offset: 0x00048C86
		public ca(ab6 A_0, Document A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00049CA0 File Offset: 0x00048CA0
		public override void Draw(DocumentWriter writer)
		{
			abg abg = this.a.b().m().b((long)this.a.c());
			abd abd = abg.i();
			bool flag = false;
			byte[] array = null;
			using (new MemoryStream())
			{
				byte[] array2 = ((afj)abd).j4();
				string text = Encoding.UTF8.GetString(array2);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.PreserveWhitespace = true;
				try
				{
					xmlDocument.LoadXml(text);
				}
				catch (XmlException ex)
				{
					int lineNumber = ex.LineNumber;
					int linePosition = ex.LinePosition;
					string message = ex.Message;
					bool flag2 = false;
					int i = 0;
					while (i < 10)
					{
						try
						{
							text = this.a(text, ex);
						}
						catch (Exception)
						{
							array = array2;
							flag = true;
							goto IL_138;
						}
						try
						{
							xmlDocument.LoadXml(text);
							flag2 = true;
						}
						catch (XmlException ex2)
						{
							int num = lineNumber;
							int num2 = linePosition;
							lineNumber = ex2.LineNumber;
							linePosition = ex2.LinePosition;
							if (lineNumber == num && linePosition == num2)
							{
								i++;
							}
							ex = ex2;
						}
						if (!flag2)
						{
							continue;
						}
						IL_138:
						goto IL_13C;
					}
					array = array2;
					flag = true;
				}
				IL_13C:
				if (!flag)
				{
					this.a(xmlDocument, writer);
					XmlElement documentElement = xmlDocument.DocumentElement;
					string outerXml = documentElement.ParentNode.OuterXml;
					array = Encoding.UTF8.GetBytes(outerXml);
				}
			}
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(ca.c);
			writer.WriteName(ca.d);
			writer.WriteName(ca.e);
			if (writer.Document.Security != null && !writer.Document.Security.c())
			{
				writer.WriteName(Resource.c);
				writer.WriteArrayOpen();
				writer.WriteName(ca.f);
				writer.WriteArrayClose();
			}
			if (writer.Document.Security == null || writer.Document.Security.c())
			{
				writer.WriteName(Resource.e);
				writer.ai(array.Length);
				writer.WriteDictionaryClose();
				writer.WriteStream(array, array.Length);
			}
			else
			{
				writer.WriteName(Resource.e);
				writer.WriteNumber(array.Length);
				writer.WriteDictionaryClose();
				writer.af(array, array.Length);
			}
			writer.WriteEndObject();
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00049FB4 File Offset: 0x00048FB4
		private new void a(XmlDocument A_0, DocumentWriter A_1)
		{
			string text = x6.a(A_1.CreationDate);
			string text2 = x6.a(A_1.CreationDate);
			XmlNodeList elementsByTagName = A_0.GetElementsByTagName("rdf:Description");
			foreach (object obj in elementsByTagName)
			{
				XmlNode xmlNode = (XmlNode)obj;
				XmlAttributeCollection attributes = xmlNode.Attributes;
				foreach (object obj2 in attributes)
				{
					XmlAttribute xmlAttribute = (XmlAttribute)obj2;
					string localName = xmlAttribute.LocalName;
					if (localName != null)
					{
						if (!(localName == "CreateDate"))
						{
							if (!(localName == "MetadataDate"))
							{
								if (!(localName == "ModifyDate"))
								{
									if (localName == "Producer")
									{
										if (this.b.Producer != null)
										{
											xmlAttribute.Value = this.b.Producer;
										}
									}
								}
								else
								{
									xmlAttribute.Value = text2;
								}
							}
							else
							{
								xmlAttribute.Value = text;
							}
						}
						else
						{
							xmlAttribute.Value = text;
						}
					}
				}
				if (xmlNode.HasChildNodes)
				{
					XmlNodeList childNodes = xmlNode.ChildNodes;
					foreach (object obj3 in childNodes)
					{
						XmlNode xmlNode2 = (XmlNode)obj3;
						string localName = xmlNode2.LocalName;
						if (localName != null)
						{
							if (!(localName == "CreateDate"))
							{
								if (!(localName == "MetadataDate"))
								{
									if (!(localName == "ModifyDate"))
									{
										if (localName == "Producer")
										{
											if (this.b.Producer != null)
											{
												xmlNode2.InnerText = this.b.Producer;
											}
										}
									}
									else
									{
										xmlNode2.InnerText = text2;
									}
								}
								else
								{
									xmlNode2.InnerText = text;
								}
							}
							else
							{
								xmlNode2.InnerText = text;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0004A26C File Offset: 0x0004926C
		private new string a(string A_0, XmlException A_1)
		{
			int lineNumber = A_1.LineNumber;
			int linePosition = A_1.LinePosition;
			string message = A_1.Message;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] == '\n')
				{
					num++;
					if (num == lineNumber - 1)
					{
						num2 = i;
					}
					if (num == lineNumber)
					{
						num3 = i;
						break;
					}
				}
			}
			if (num3 == 0)
			{
				num3 = A_0.Length - 1;
			}
			string text = A_0.Substring(num2 + 1, num3 - num2);
			if (message.Contains("An error occurred while parsing EntityName"))
			{
				string value = "";
				if (text[linePosition - 2] == '&' && text[linePosition - 1] != 'a')
				{
					value = "&#38;";
				}
				else if (text[linePosition - 2] == '<')
				{
					value = "&#60;";
				}
				else if (text[linePosition - 2] == '>')
				{
					value = "&#62;";
				}
				else if (text[linePosition - 2] == '\'')
				{
					value = "&#39;";
				}
				else if (text[linePosition - 2] == '"')
				{
					value = "&#34;";
				}
				StringBuilder stringBuilder = new StringBuilder(text);
				stringBuilder.Remove(linePosition - 2, 1);
				stringBuilder.Insert(linePosition - 2, value);
				text = stringBuilder.ToString();
			}
			else if (message.Contains("invalid character"))
			{
				text = text.Remove(linePosition - 1, 1);
			}
			else if (message.Contains("Name cannot begin with the '<' character"))
			{
				text = text.Insert(linePosition - 1, ">");
			}
			else if (message.Contains("Data at the root level is invalid"))
			{
				text = text.Substring(0, linePosition - 1);
			}
			else
			{
				if (!message.Contains("invalid attribute character"))
				{
					throw A_1;
				}
				for (int j = num2; j >= 0; j--)
				{
					if (A_0[j] == '>')
					{
						A_0 = A_0.Insert(j, "\"");
						num2++;
						break;
					}
				}
			}
			return A_0.Substring(0, num2) + text + A_0.Substring(num3 + 1, A_0.Length - num3 - 1);
		}

		// Token: 0x04000294 RID: 660
		private new ab6 a;

		// Token: 0x04000295 RID: 661
		private new Document b;

		// Token: 0x04000296 RID: 662
		private new static byte[] c = new byte[]
		{
			77,
			101,
			116,
			97,
			100,
			97,
			116,
			97
		};

		// Token: 0x04000297 RID: 663
		private new static byte[] d = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x04000298 RID: 664
		private new static byte[] e = new byte[]
		{
			88,
			77,
			76
		};

		// Token: 0x04000299 RID: 665
		private new static byte[] f = new byte[]
		{
			67,
			114,
			121,
			112,
			116
		};
	}
}
