using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using Kingdoms;
using System.Windows.Forms;
//using LuaInterface;

/*
 * TODO:
 * Менять селект деревни и качать ее
 * NLua
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
            {
                Console.WriteLine("Мир еще не загружен!");
                Thread.Sleep(5000); // 5 sec
                Console.Clear();
            }

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
                GameEngine.Instance.downloadCurrentVillage();
            }
            Console.WriteLine("======| ========== |======\n");
            
            Thread OutThread = new Thread(OutTh);
            OutThread.Start();
            Console.WriteLine("Основной поток формы запущен!");

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
            try
            {
                Console.WriteLine(RemoteServices.Instance.UserID);
                Console.WriteLine(RemoteServices.Instance.UserName);

                List<int> VillageIDs = GameEngine.Instance.World.getListOfUserVillages();
                foreach (int VillageID in VillageIDs)
                    Console.WriteLine(GameEngine.Instance.getVillage(VillageID).calcTotalTradersAtHome());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool FreeConsole();
    }
}
