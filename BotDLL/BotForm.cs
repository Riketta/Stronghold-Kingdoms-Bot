// Developed by Riketta https://github.com/Riketta/Stronghold-Kingdoms-Bot


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Kingdoms;
using Stronghold.AuthClient;
using CommonTypes;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.IO;

namespace BotDLL
{
    public partial class BotForm : Form
    {
        string[] Researches;

        Thread TradeThread;
        bool IsTrading = false;

        Thread AutoLootThread;
        bool IsAutoLoot = true;

        Thread ResearchThread;

        string BotStartTime = "";

        Object Lock = new object();

        public void Log(string Text)
        {
            Text = "[" + DateTime.Now + "] " + Text;
            Console.WriteLine(Text);
            richTextBox_Log.Text = Text + "\r\n" + richTextBox_Log.Text;

            try
            {
                if (!Directory.Exists("logs"))
                    Directory.CreateDirectory("logs");

                lock (Lock)
                using (StreamWriter Writer = new StreamWriter(@".\logs\" + BotStartTime + ".log", true))
                    Writer.WriteLine(Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n======| EX INFO |======");
                Console.WriteLine(ex);
                Console.WriteLine("======| ======= |======\n");
            }
        }

        public BotForm()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            this.Show();
            BotStartTime = DateTime.Now.ToString().Replace(':', '-');
            Log("Форма бота отображена.");

            listBox_ResList.SelectedIndex = 0;
            //listBox_ResearchList.SelectedIndex = 0;

            TradeThread = new Thread(Trade);
            TradeThread.Start();

            AutoLootThread = new Thread(AutoLoot);
            AutoLootThread.Start();

            ResearchInit();
            ResearchThread = new Thread(Research);
            ResearchThread.Start();
        }

        private void button_Trade_Click(object sender, EventArgs e)
        {
            // Если мир уже загружен и поле цели заполнено
            if (GameEngine.Instance.World.isDownloadComplete() && textBox_TradeTargetID.Text.Length > 0)
            {
                try
                {
                    if (!IsTrading) // Если не торгуем
                    {
                        button_Trade.Text = "Стоп";
                        IsTrading = true; // То торгуем
                    }
                    else // И наоборот
                    {
                        button_Trade.Text = "Торговать";
                        IsTrading = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n======| EX INFO |======");
                    Log(ex.ToString());
                    Console.WriteLine("======| ======= |======\n");
                }
            }
        }

        public void Research()
        {
            while (true)
            {
                try
                {
                    if (GameEngine.Instance.World.isDownloadComplete() && listBox_Queue.Items.Count > 0)
                    {
                        if (GameEngine.Instance.World.userResearchData.research_points > 0)
                        {
                            TimeSpan Span = DateTime.Now.Subtract(GameEngine.Instance.World.userResearchData.research_completionTime);
                            Console.WriteLine(Span.TotalSeconds);

                            try
                            {
                                GameEngine.Instance.World.doResearch(GetItemID(listBox_Queue.SelectedItem.ToString()));
                                Log("Исследование " + listBox_Queue.SelectedItem.ToString() + " начато!");
                                // Удаляем из очереди т.к. уже исследуем
                                listBox_Queue.Items.RemoveAt(0);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\n======| EX INFO |======");
                                Log(ex.ToString());
                                Console.WriteLine("======| ======= |======\n");
                            }
                        }
                        else
                        {
                            Log("Не хватает очков исследований!");
                            listBox_Queue.Items.Clear(); // Чистим, дабы избежать спама в логи
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n======| EX INFO |======");
                    Log(ex.ToString());
                    Console.WriteLine("======| ======= |======\n");
                }
                Thread.Sleep(60 * 1000); // 60 sec
            }
        }
        
        public void AutoLoot()
        {
            Log("Поток автолута создан!");

            while (true)
            {
                try
                {
                    // Если лутаем и время пришло
                    if (GameEngine.Instance.World.isDownloadComplete() && IsAutoLoot && GameEngine.Instance.World.FreeCardInfo.timeUntilNextFreeCard().TotalSeconds <= 0)
                    {
                        // Грязный хак. Новая карта не будет показана пока игра не будет перезапущена - каллбека то нету
                        XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath).getFreeCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", "")), null, null);
                        // Wrong next time cause info about it not loaded. Cause callback is broken
                        // Не верное следующее время лута, т.к. новое не загружено - каллбека нет.
                        // Фактически одноразовый автолут, лол
                        Log("Карта полутана! Следующая через " + GameEngine.Instance.World.FreeCardInfo.timeUntilNextFreeCard());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n======| EX INFO |======");
                    Console.WriteLine(ex);
                    Console.WriteLine("======| ======= |======\n");
                }

                Thread.Sleep(60 * 1000); // 60 sec
            }
        }

        public void Trade()
        {
            Log("Торговый поток создан!");

            int Sleep = 0;
            while (true) 
            {
                try
                {
                    Sleep = 60 + new Random().Next(-5, 60);

                    if (IsTrading) // Если торгуем
                    {
                        Log("Заход с \"" + listBox_ResList.SelectedItem.ToString() + "\"");
                        // Получаем ID товара из списка
                        int ResID = GetItemID(listBox_ResList.SelectedItem.ToString());
                        int TargetID = int.Parse(textBox_TradeTargetID.Text); // Получаем ID деревни-цели
                        List<int> VillageIDs = GameEngine.Instance.World.getListOfUserVillages(); // Получаем список наших деревень

                        foreach (int VillageID in VillageIDs) // Перебираем их
                        {
                            // Если деревня прогружена (открывалась ее карта в текущей сессии хоть раз)
                            if (GameEngine.Instance.getVillage(VillageID) != null)
                            {
                                // Получаем базовую информацию о нашей деревни
                                WorldMap.VillageData Village = GameEngine.Instance.World.getVillageData(VillageID);
                                VillageMap Map = GameEngine.Instance.getVillage(VillageID); // Получаем полную информацию
                                int ResAmount = (int)Map.getResourceLevel(ResID); // Кол-во ресурса на складе
                                int MerchantsCount = Map.calcTotalTradersAtHome(); // Кол-во торговцев в ней
                                Log("В деревне " + VillageID + " есть " + MerchantsCount + " торговцев"); // Дебаг

                                int SendWithOne = int.Parse(textBox_ResCount.Text); // Кол-во ресурса на торговца
                                int MaxAmount = MerchantsCount * SendWithOne; // Кол-во ресурсов отправим
                                if (ResAmount < MaxAmount) // Если торговцы могут увезти больше чем есть
                                    MerchantsCount = (int)(ResAmount / SendWithOne); // Считаем сколько смогут увезти реально

                                if (MerchantsCount > 0) // Если трейдеры дома есть
                                {
                                    TargetID = (checkBox_Parish.Checked ? 
                                        GameEngine.Instance.World.getRegionCapitalVillage(Village.regionID) : 
                                        int.Parse(textBox_TradeTargetID.Text));
                                    //textBox_TradeTargetID.Text = TargetID.ToString();

                                    // Вызываем высокоуровневую функцию торговли с рядом каллбеков
                                    GameEngine.Instance.getVillage(VillageID).stockExchangeTrade(TargetID, ResID, MerchantsCount * SendWithOne, false);
                                    AllVillagesPanel.travellersChanged(); // Подтверждаем изменения (ушли трейдеры) в GUI-клиента
                                }
                            }
                        }

                        Log("Повтор цикла торговли через " + Sleep + " секунд(ы) в " + DateTime.Now.AddSeconds(Sleep).ToString("HH:mm:ss"));
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n======| EX INFO |======");
                    Console.WriteLine(ex);
                    Console.WriteLine("======| ======= |======\n");
                }

                Thread.Sleep(Sleep * 1000); // Спим, чтобы не спамить. Так меньше палева.
            }
        }

        public void ResearchInit()
        {
            Researches = new string[listBox_ResearchList.Items.Count];
            for (int i = 0; i < Researches.Length; i++)
                Researches[i] = listBox_ResearchList.Items[i].ToString();
        }

        private void listBox_ResList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ResID = GetItemID(listBox_ResList.SelectedItem.ToString());

            switch (ResID)
            {
                // Wood and Stone
                case 6:
                case 7: textBox_ResCount.Text = "1000";
                    break;

                // Iron and Pitch
                case 8:
                case 9: textBox_ResCount.Text = "200";
                    break;

                // Ale
                case 12: textBox_ResCount.Text = "124";
                    break;

                // Food
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18: textBox_ResCount.Text = "500";
                    break;

                // Metalware, Clothes, Furniture, Venison
                case 19:
                case 21:
                case 22:
                case 26: textBox_ResCount.Text = "50";
                    break;

                // Salt, Salt (Not Silk?), Species, Wine
                case 23:
                case 24:
                case 25:
                case 33: textBox_ResCount.Text = "20";
                    break;

                // Weapons
                case 28:
                case 29:
                case 30:
                case 31:
                case 32: textBox_ResCount.Text = "5"; // 32 may be not valid (Catapults)
                    break;
            }
        }

        private int GetItemID(string Item)
        {
            return int.Parse(Item.Replace(" ", "").Split('-')[0]);
        }

        private void BotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                TradeThread.Abort();
            } catch { }

            try
            {
                AutoLootThread.Abort();
            } catch { }

            try
            {
                ResearchThread.Abort();
            } catch { }
        }

        private void button_MapEditing_Click(object sender, EventArgs e) // Only visual
        {
            button_MapEditing.Text = (!GameEngine.Instance.World.MapEditing).ToString();
            GameEngine.Instance.World.MapEditing = !GameEngine.Instance.World.MapEditing;
        }

        private void button_Admin_Click(object sender, EventArgs e) // Only visual
        {
            button_Admin.Text = (!RemoteServices.Instance.Admin).ToString();
            RemoteServices.Instance.Admin = !RemoteServices.Instance.Admin;
        }

        private void button_Exec_Click(object sender, EventArgs e)
        {
            if (richTextBox_In.Text.Length == 0 || !GameEngine.Instance.World.isDownloadComplete())
                return;

            richTextBox_Out.Text = "";

            // *** Example form input has code in a text box
            string lcCode = richTextBox_In.Text;

            ICodeCompiler loCompiler = new CSharpCodeProvider().CreateCompiler();
            CompilerParameters loParameters = new CompilerParameters();

            // *** Start by adding any referenced assemblies
            loParameters.ReferencedAssemblies.Add("System.dll");
            loParameters.ReferencedAssemblies.Add("System.Data.dll");
            loParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            loParameters.ReferencedAssemblies.Add("CommonTypes.dll");
            loParameters.ReferencedAssemblies.Add("Stronghold.WebService.dll");
            loParameters.ReferencedAssemblies.Add("StrongholdKingdoms.exe");

            // *** Must create a fully functional assembly as a string
            lcCode = @"using System;
            using System.IO;
            using System.Windows.Forms;
            using System.Collections.Generic;
            using System.Text;

            using Kingdoms;
            using CommonTypes;
            using Stronghold.AuthClient;

            namespace NSpace {
            public class NClass {
            public object DynamicCode(params object[] Parameters) 
            {
                " + lcCode +
            @" return null;
            }
            }
            }";

            // *** Load the resulting assembly into memory
            loParameters.GenerateInMemory = false;
            // *** Now compile the whole thing
            CompilerResults loCompiled =
                    loCompiler.CompileAssemblyFromSource(loParameters, lcCode);
            if (loCompiled.Errors.HasErrors)
            {
                string lcErrorMsg = "";
                lcErrorMsg = loCompiled.Errors.Count.ToString() + " Errors:";
                for (int x = 0; x < loCompiled.Errors.Count; x++)
                    lcErrorMsg = lcErrorMsg + "\r\nLine: " +
                                 loCompiled.Errors[x].Line.ToString() + " - " +
                                 loCompiled.Errors[x].ErrorText;

                richTextBox_Out.Text = lcErrorMsg + "\r\n\r\n" + lcCode;
                return;
            }

            Assembly loAssembly = loCompiled.CompiledAssembly;
            // *** Retrieve an obj ref – generic type only
            object loObject = loAssembly.CreateInstance("NSpace.NClass");

            if (loObject == null)
            {
                richTextBox_Out.Text = "Couldn't load class.";
                return;
            }

            object[] loCodeParms = new object[1];
            loCodeParms[0] = "SHKBot";
            try
            {
                object loResult = loObject.GetType().InvokeMember(
                                 "DynamicCode", BindingFlags.InvokeMethod,
                                 null, loObject, loCodeParms);

                //DateTime ltNow = (DateTime)loResult;
                if (loResult != null)
                    richTextBox_Out.Text = "Method Call Result:\r\n\r\n" + loResult.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n======| EX INFO |======");
                Console.WriteLine(ex);
                Console.WriteLine("======| ======= |======\n");
            }
        }

        private void listBox_ResearchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Queue.Items.Add(listBox_ResearchList.SelectedItem);
        }

        private void button_FreeCardAutoLoot_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAutoLoot)
                {
                    IsAutoLoot = false;
                    button_FreeCardAutoLoot.Text = "AutoLoot Disabled";
                }
                else
                {
                    IsAutoLoot = true;
                    button_FreeCardAutoLoot.Text = "AutoLoot Enabled";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n======| EX INFO |======");
                Console.WriteLine(ex);
                Console.WriteLine("======| ======= |======\n");
            }
        }

        private void listBox_Queue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Here is exception. May be recursive remove items. Dont know how to fix. 
                listBox_Queue.Items.RemoveAt(listBox_Queue.SelectedIndex);
            } catch { }
        }
    }
}
