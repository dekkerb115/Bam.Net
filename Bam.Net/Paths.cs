﻿using Bam.Net.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net
{
    public static class Paths
    { 
        static Paths()
        {
            Root = "C:\\bam";
            Builds = @"\\core\share\builds";
        }
        static string _root;
        public static string Root
        {
            get { return _root; }
            set
            {
                _root = value;
                SetPaths();
            }
        }

        public static string Apps { get; private set; }
        public static string Local { get; private set; }
        public static string Content { get; private set; }
        public static string Conf { get; private set; }
        public static string Sys { get; private set; }
        public static string Tests { get; private set; }
        public static string Logs { get; private set; }
        public static string Data { get; private set; }
        public static string Tools { get; private set; }
        public static string NugetPackages { get; private set; }
        public static string Builds { get; set; }

        public static string AppData
        {
            get { return RuntimeSettings.AppDataFolder; }
            set { RuntimeSettings.AppDataFolder = value; }
        }

        private static void SetPaths()
        {
            Apps = Path.Combine(Root, "apps");
            Local = Path.Combine(Root, "local");
            Content = Path.Combine(Root, "content");
            Conf = Path.Combine(Root, "conf");
            Sys = Path.Combine(Root, "sys");
            Tests = Path.Combine(Root, "tests");
            Logs = Path.Combine(Root, "logs");
            Data = Path.Combine(Root, "data");
            Tools = Path.Combine(Root, "tools");
            NugetPackages = Path.Combine(Root, "nuget", "packages");
        }
    }
}
