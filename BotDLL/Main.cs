// Developed by Riketta https://github.com/Riketta/Stronghold-Kingdoms-Bot


using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using Kingdoms;
using CommonTypes;
using Stronghold.AuthClient;

using System.Windows.Forms;
//using LuaInterface;

/*
 * TODO:
 * Сохранение (сериализация) мира - скачивание в xml
 * Автопокупка ресерч поинтов
 * Автолвлап
 * Пулл исследований
 * Пулл построек, шаблоны деревень
 * Автоскаутинг
 * Автонайм
 * Автопоиск лучших цен в округах
 * Перекупка
 */

namespace BotDLL
{
    public class Main
    {
        public void Inject()
        {
            AllocConsole();
            Console.Title = "SHKBot";

            Console.WriteLine("DLL загружена!");
            Thread Th = new Thread(SHK);
            Th.Start();

            BotForm FBot = new BotForm();
            FBot.Show();
        }

        public void SHK()
        {
            Console.WriteLine("Инжект выполнен!");

            while (!GameEngine.Instance.World.isDownloadComplete())
                Thread.Sleep(1500); // 1.5 sec

            Console.WriteLine();
            Console.WriteLine("Мир загружен! Начало выполнения операций ядра.");
            Console.WriteLine("\n======| DEBUG INFO |======");
            Console.WriteLine(RemoteServices.Instance.UserID);
            Console.WriteLine(RemoteServices.Instance.UserName);

            List<int> VillageIDs = GameEngine.Instance.World.getListOfUserVillages();
            foreach (int VillageID in VillageIDs)
            {
                WorldMap.VillageData Village = GameEngine.Instance.World.getVillageData(VillageID);
                Console.WriteLine("[Инициализация] " + Village.m_villageName + " - " + VillageID);

                InterfaceMgr.Instance.selectVillage(VillageID);
                GameEngine.Instance.GameDisplayMode = GameEngine.GameDisplays.DISPLAY_VILLAGE;
                GameEngine.Instance.downloadCurrentVillage();
            }
            Console.WriteLine("======| ========== |======\n");
            
            Thread OutThread = new Thread(OutTh);
            OutThread.Start();
            Console.WriteLine("Основной поток логики запущен!");

            while (true)
            {
                try
                {
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n======| EX INFO |======");
                    Console.WriteLine(ex);
                    Console.WriteLine("======| ======= |======\n");
                }
            }
        }

        public void OutTh()
        {
            try
            {
                //Console.WriteLine("Скрипт выполняется.");

                //Lua LuaSrc = new Lua();
                //LuaSrc.DoFile("SHK.lua");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n======| EX INFO |======");
                Console.WriteLine(ex);
                Console.WriteLine("======| ======= |======\n");
            }
            //catch (LuaException ex)
            //{
            //    Console.WriteLine("\n======| LUA EX INFO |======");
            //    Console.WriteLine(ex);
            //    Console.WriteLine("======| =========== |======\n");
            //}
        }

        private void Dev()
        {
            //RemoteServices.Instance.GetResearchData();
            //RemoteServices.Instance.BuyResearchPoint();
            //RemoteServices.Instance.DoResearch(0);
            //RemoteServices.Instance.SpyGetResearchInfo(0);

            //GameEngine.Instance.World.addResearchPoints(0);
            //GameEngine.Instance.World.doResearch(0);
            //var A = GameEngine.Instance.World.GetResearchDataForVillage(0);
            //GameEngine.Instance.World.GetResearchDataForCurrentVillage();
            //GameEngine.Instance.World.UserResearchData.research_pointCount;

            //XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath).getFreeCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", "")), null, null);
            //GameEngine.Instance.World.FreeCardInfo.timeUntilNextFreeCard().ToString();
            //TimeSpan FullTime = new TimeSpan(168 / GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(), 0, 0);
            //Console.WriteLine(FullTime.Subtract(GameEngine.Instance.World.FreeCardInfo.timeUntilNextFreeCard()).TotalMinutes); // Прошло после получения
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool FreeConsole();
    }
}
