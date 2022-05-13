﻿using GrassCutter_Proxy.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenshinImpact_Lanucher.Model.Launcher_Ini;

namespace GenshinImpact_Lanucher.Model
{
    public class StartAgument
    {
        /// <summary>
        /// 游戏高度
        /// </summary>
        public string GameHeight { get; set; }

        public bool IsPop { get; set; }

        /// <summary>
        /// 游戏宽度
        /// </summary>
        public string GameWidth { get; set; }

        public Server GameServer { get; set; }

        public string GamePath { get; set; }

        /// <summary>
        /// 是否全屏
        /// </summary>
        public bool full { get; set; }


        public static StartAgument GetDefultAgument()
        {
            var start = new StartAgument()
            {
                full = true,
                GameServer = Server.官服,
                GameHeight = "1080",
                GameWidth = "1980",
                IsPop = false
                , 
                GamePath = LanucherRegistryKey.GetGamePath()
            };
            return start;
        }


    }

    /// <summary>
    /// 启动核心
    /// </summary>
    public class StartGame
    {
        public async Task<string> GO(StartAgument args)
        {
            return await Task.Run(() =>
            {
                try
                {
                    
                    using (Process p = new Process())
                    {
                        string pop = "";
                        if(args.IsPop == true)
                        {
                            pop = "-popupwindow 1";
                        }
                        p.StartInfo = new ProcessStartInfo()
                        {
                            FileName = args.GamePath + "//YuanShen.exe",
                            Verb = "runas",
                            Arguments = $"-screen-fullscreen {System.Convert.ToInt32(args.full)} -screen-height {args.GameHeight}" +
                            $" -screen-width {args.GameWidth} {pop}",
                            WorkingDirectory = args.GamePath,
                            UseShellExecute = true,
                        };
                        p.Start();
                        return "1";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            });
        }
        public static ProxyController Controller;
        string docpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public async Task<string> ServerGo( bool flage, StartAgument args)
        {
            return await Task.Run(() =>
            {
                Launcher_Ini ini = new Launcher_Ini($@"{docpath}/GSIConfig/Config/LauncherConfig.ini");
                if (Controller == null)
                {
                    Controller = new ProxyController(ini.IniReadValue("Server", "Host"), ini.IniReadValue("Server", "IP"));

                }

                if (flage == true)
                {
                    Controller.Start();
                    Console.WriteLine("正在打开代理，并使用证书");
                }
                else
                {

                    Controller.Stop();
                    Console.WriteLine("正在关闭代理，并清除证书");
                    foreach (Process item in Process.GetProcesses())
                    {
                        if(item.ProcessName == "YuanShen.exe")
                        {
                            item.Kill();
                            Console.WriteLine("已经吧YuanShen进程杀灭，并清除证书");
                        }
                    }
                }
                return "1";
            });
        }
    }
}
