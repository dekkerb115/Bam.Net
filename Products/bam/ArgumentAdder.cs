﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.CommandLine;

namespace Bam.Net.Application
{
    internal class ArgumentAdder: CommandLineInterface
    {
        internal static void AddArguments()
        {
            AddManagementArguments();
            AddHeartArguments();
            AddUtilityArguments();
        }

        private static void AddHeartArguments()
        {
            AddValidArgument("org", false, description: "heart: The name of your organization");
            AddValidArgument("email", false, description: "heart: Your email address");
            AddValidArgument("password", false, description: "heart: Your password to automate operations that require authentication");
            AddValidArgument("app", false, description: "heart: The name of the application you are acting on");
        }

        private static void AddManagementArguments()
        {
            AddValidArgument("root", false, description: "The root directory to pack files from");
            AddValidArgument("saveTo", false, description: "The zip file to create when packing the toolkit");
            AddValidArgument("appName", false, description: "The name of the app to create when calling /cca (create client app) or /cm (create manifest)");
            AddValidArgument("appDirectory", false, description: "The directory path to create an app manifest for");
        }

        private static void AddUtilityArguments()
        {
            AddValidArgument("configPath", false, description: "The path to the config file to set appSettings for");
        }
    }
}
