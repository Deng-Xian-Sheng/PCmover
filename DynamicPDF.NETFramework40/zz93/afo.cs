using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004BB RID: 1211
	internal class afo : Resource
	{
		// Token: 0x060031CE RID: 12750 RVA: 0x001BD4E0 File Offset: 0x001BC4E0
		internal afo(ab6 A_0, FormFieldList A_1)
		{
			this.a = A_0;
			this.c = A_1;
		}

		// Token: 0x060031CF RID: 12751 RVA: 0x001BD504 File Offset: 0x001BC504
		public override void Draw(DocumentWriter writer)
		{
			if (this.a != null && this.c.Count > 0)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				abg abg = this.a.b().m().b((long)this.a.c());
				abd abd = abg.i();
				byte[] array = ((afj)abd).j4();
				string text = Encoding.ASCII.GetString(array);
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(array, 0, array.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				XmlTextReader reader = new XmlTextReader(memoryStream);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(reader);
				this.d = xmlDocument.DocumentElement.CreateNavigator();
				XmlDocument xmlDocument2 = new XmlDocument();
				if (this.d != null && this.d.Name == "xfa:datasets")
				{
					abg abg2 = this.b.b().m().b((long)this.b.c());
					abd abd2 = abg2.i();
					byte[] array2 = ((afj)abd2).j4();
					MemoryStream memoryStream2 = new MemoryStream();
					memoryStream2.Write(array2, 0, array2.Length);
					memoryStream2.Seek(0L, SeekOrigin.Begin);
					XmlTextReader reader2 = new XmlTextReader(memoryStream2);
					xmlDocument2.Load(reader2);
					this.e = xmlDocument2.DocumentElement.CreateNavigator();
				}
				else if (this.d != null && this.d.Name == "xdp:xdp")
				{
					string text2 = "http://www.xfa.org/schema/xfa-template/";
					float num = 0f;
					while (text.Contains(text2))
					{
						int num2 = text.IndexOf(text2);
						string s = text.Substring(num2 + text2.Length, 3);
						float num3 = float.Parse(s, CultureInfo.InvariantCulture);
						if (num < num3)
						{
							num = num3;
						}
						text = text.Substring(num2 + text2.Length);
					}
					text2 = text2 + num.ToString() + "/";
					XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(this.d.NameTable);
					xmlNamespaceManager.AddNamespace("xfa", text2);
					this.e = this.d.SelectSingleNode("xfa:template", xmlNamespaceManager);
					XmlNamespaceManager xmlNamespaceManager2 = new XmlNamespaceManager(this.d.NameTable);
					xmlNamespaceManager2.AddNamespace("xfa", "http://www.xfa.org/schema/xfa-data/1.0/");
					this.d = this.d.SelectSingleNode("//xfa:datasets", xmlNamespaceManager2);
				}
				this.a(this.c, xmlDocument2);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				xmlDocument.Save(memoryStream);
				byte[] array3 = memoryStream.ToArray();
				writer.WriteName(Resource.e);
				writer.ai(array3.Length);
				writer.WriteDictionaryClose();
				writer.WriteStream(array3, array3.Length);
				writer.WriteEndObject();
			}
		}

		// Token: 0x060031D0 RID: 12752 RVA: 0x001BD828 File Offset: 0x001BC828
		private new void a(FormFieldList A_0, XmlDocument A_1)
		{
			int i = 0;
			while (i < A_0.Count)
			{
				if (A_0[i].he())
				{
					this.f.a(A_0[i].hb().FullName);
					StringBuilder stringBuilder = new StringBuilder();
					XPathNavigator xpathNavigator = this.e;
					XPathNavigator xpathNavigator2 = this.d;
					string text = "";
					string[] array = null;
					bool flag = false;
					if (xpathNavigator != null)
					{
						XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xpathNavigator.NameTable);
						xmlNamespaceManager.AddNamespace("xfa", this.e.NamespaceURI);
						while (this.f.MoveNext())
						{
							string text2 = this.f.get_Current().ToString();
							int num = text2.IndexOf("[") + 1;
							int num2 = text2.IndexOf("]") - 1;
							int num3 = Convert.ToInt32(text2.Substring(num, num2 - num + 1));
							if (num > 0)
							{
								text2 = text2.Substring(0, num - 1);
							}
							if (xpathNavigator.SelectSingleNode(".//*[@name='" + text2 + "']") != null)
							{
								XPathNodeIterator xpathNodeIterator = xpathNavigator.Select(".//*[@name='" + text2 + "']", xmlNamespaceManager);
								if (xpathNodeIterator.Count > 1)
								{
									for (int j = 0; j < xpathNodeIterator.Count; j++)
									{
										xpathNodeIterator.MoveNext();
										if (xpathNodeIterator.Current.Name == "subform" || xpathNodeIterator.Current.Name == "field")
										{
											if (xpathNodeIterator.CurrentPosition == num3)
											{
												xpathNavigator = xpathNodeIterator.Current;
												break;
											}
										}
										else
										{
											num3++;
										}
									}
								}
								else
								{
									xpathNavigator = xpathNavigator.SelectSingleNode(".//*[@name='" + text2 + "']");
								}
							}
						}
						if (xpathNavigator != null)
						{
							if (xpathNavigator.SelectSingleNode("xfa:bind", xmlNamespaceManager) != null)
							{
								xpathNavigator = xpathNavigator.SelectSingleNode("xfa:bind", xmlNamespaceManager);
								if (xpathNavigator.GetAttribute("match", xpathNavigator.BaseURI) == "dataRef")
								{
									text = xpathNavigator.GetAttribute("ref", xpathNavigator.BaseURI);
								}
								else if (xpathNavigator.GetAttribute("match", xpathNavigator.BaseURI) == "None" || xpathNavigator.GetAttribute("match", xpathNavigator.BaseURI) == "none")
								{
									goto IL_B05;
								}
							}
						}
					}
					if (text != "")
					{
						array = text.Split(new char[]
						{
							'.'
						});
						for (int j = 1; j < array.Length; j++)
						{
							if (array[j].IndexOf("[") > 0)
							{
								int num = array[j].IndexOf("[") + 1;
								int num2 = array[j].IndexOf("]") - 1;
								int num3 = Convert.ToInt32(array[j].Substring(num, num2 - num + 1));
								num3++;
								array[j] = array[j].Substring(0, num) + num3.ToString() + "]";
							}
							stringBuilder.Append(array[j] + "/");
						}
						flag = true;
					}
					else
					{
						this.f.a(A_0[i].hb().FullName);
						XmlNamespaceManager xmlNamespaceManager2 = new XmlNamespaceManager(xpathNavigator2.NameTable);
						xmlNamespaceManager2.AddNamespace("", this.d.NamespaceURI);
						XPathNavigator xpathNavigator3 = this.e;
						XPathNavigator xpathNavigator4 = this.e;
						while (this.f.MoveNext())
						{
							string text2 = this.f.get_Current().ToString();
							int num = text2.IndexOf("[") + 1;
							int num2 = text2.IndexOf("]") - 1;
							int num3 = Convert.ToInt32(text2.Substring(num, num2 - num + 1));
							if (num > 0)
							{
								text2 = text2.Substring(0, num - 1);
							}
							if (xpathNavigator3.SelectSingleNode(".//*[@name='" + text2 + "']") != null)
							{
								XPathNodeIterator xpathNodeIterator2 = xpathNavigator3.Select(".//*[@name='" + text2 + "']");
								if (xpathNodeIterator2.Count > 1)
								{
									for (int j = 0; j < xpathNodeIterator2.Count; j++)
									{
										xpathNodeIterator2.MoveNext();
										if (xpathNodeIterator2.Current.Name == "subform" || xpathNodeIterator2.Current.Name == "field" || xpathNodeIterator2.Current.Name == "exclGroup")
										{
											if (xpathNodeIterator2.CurrentPosition == num3)
											{
												xpathNavigator3 = xpathNodeIterator2.Current;
												break;
											}
										}
										else
										{
											num3++;
										}
									}
								}
								else
								{
									xpathNavigator3 = xpathNavigator3.SelectSingleNode(".//*[@name='" + text2 + "']");
								}
							}
							if (xpathNavigator2.SelectSingleNode("//" + this.f.get_Current(), xmlNamespaceManager2) != null)
							{
								XPathNodeIterator xpathNodeIterator3 = xpathNavigator2.Select(".//" + text2, xmlNamespaceManager2);
								int num4 = 0;
								if (xpathNodeIterator3.Count > 1)
								{
									XPathNodeIterator xpathNodeIterator4 = xpathNavigator4.Select(".//*[@name='" + text2 + "']");
									for (int k = 0; k < xpathNodeIterator4.Count; k++)
									{
										xpathNodeIterator4.MoveNext();
										if (xpathNodeIterator4.Current.ComparePosition(xpathNavigator3).ToString() == "Same")
										{
											num4 = xpathNodeIterator4.CurrentPosition;
											xpathNavigator4 = xpathNodeIterator4.Current;
											break;
										}
									}
									if (num4 > 0)
									{
										text2 = text2 + "[" + num4.ToString() + "]";
										xpathNavigator2 = xpathNavigator2.SelectSingleNode("//" + text2, xmlNamespaceManager2);
										stringBuilder.Append(text2 + "/");
										if (xpathNavigator3.Name == "field" || xpathNavigator3.Name == "exclGroup")
										{
											flag = true;
										}
									}
								}
								else
								{
									xpathNavigator2 = xpathNavigator2.SelectSingleNode("//" + this.f.get_Current(), xmlNamespaceManager2);
									stringBuilder.Append(this.f.get_Current() + "/");
									if (xpathNavigator3.Name == "field" || xpathNavigator3.Name == "exclGroup")
									{
										flag = true;
									}
									if (xpathNavigator4.SelectSingleNode(".//*[@name='" + text2 + "']") != null)
									{
										XPathNodeIterator xpathNodeIterator2 = xpathNavigator4.Select(".//*[@name='" + text2 + "']");
										if (xpathNodeIterator2.Count > 1)
										{
											for (int j = 0; j < xpathNodeIterator2.Count; j++)
											{
												xpathNodeIterator2.MoveNext();
												if (xpathNodeIterator2.Current.Name == "subform" || xpathNodeIterator2.Current.Name == "field")
												{
													if (xpathNodeIterator2.CurrentPosition == num3)
													{
														xpathNavigator4 = xpathNodeIterator2.Current;
														break;
													}
												}
											}
										}
										else
										{
											xpathNavigator4 = xpathNavigator4.SelectSingleNode(".//*[@name='" + text2 + "']");
										}
									}
								}
							}
						}
					}
					if (stringBuilder.Length > 1 && flag)
					{
						XPathNavigator xpathNavigator5 = this.d.SelectSingleNode("//" + stringBuilder.ToString().Substring(0, stringBuilder.Length - 1));
						if (xpathNavigator5 == null && array != null)
						{
							xpathNavigator5 = this.d;
							for (int j = 1; j < array.Length - 1; j++)
							{
								if (xpathNavigator5 != null || j == 1)
								{
									xpathNavigator5 = xpathNavigator5.SelectSingleNode(".//" + array[j]);
								}
							}
							if (xpathNavigator5 != null)
							{
								xpathNavigator5.AppendChild(string.Concat(new string[]
								{
									"<",
									array[array.Length - 1],
									"> </",
									array[array.Length - 1],
									">"
								}));
								xpathNavigator5 = xpathNavigator5.SelectSingleNode(".//" + array[array.Length - 1]);
							}
						}
						if (xpathNavigator5 != null)
						{
							switch (A_0[i].cc())
							{
							case bj.c:
								if (A_0[i].Value != "")
								{
									xpathNavigator5.SetValue(A_0[i].Value);
								}
								else
								{
									xpathNavigator5.SetValue(((aak)A_0[i]).d);
								}
								goto IL_B05;
							case bj.e:
								if (A_0[i].Value != "")
								{
									if (A_0[i].Flags == FormFieldFlags.MultiSelect)
									{
										xpathNavigator5.InnerXml = "<value>" + A_0[i].Value + "</value>";
									}
									else
									{
										xpathNavigator5.SetValue(A_0[i].Value);
									}
								}
								goto IL_B05;
							}
							xpathNavigator5.SetValue(A_0[i].Value);
							goto IL_B05;
						}
					}
					goto IL_AD9;
				}
				goto IL_AD9;
				IL_B05:
				i++;
				continue;
				IL_AD9:
				if (A_0[i].HasChildFields)
				{
					this.a(A_0[i].ChildFields, A_1);
				}
				goto IL_B05;
			}
		}

		// Token: 0x060031D1 RID: 12753 RVA: 0x001BE350 File Offset: 0x001BD350
		internal new void a(ab6 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0400174A RID: 5962
		private new ab6 a;

		// Token: 0x0400174B RID: 5963
		private new ab6 b;

		// Token: 0x0400174C RID: 5964
		private new FormFieldList c;

		// Token: 0x0400174D RID: 5965
		private new XPathNavigator d;

		// Token: 0x0400174E RID: 5966
		private new XPathNavigator e;

		// Token: 0x0400174F RID: 5967
		private new afp f = new afp();
	}
}
