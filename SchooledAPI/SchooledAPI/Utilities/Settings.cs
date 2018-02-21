﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SchooledAPI.Utilities
{
    public static class Settings
    {
        //TODO: SMTP Credentials and Cloud Storage Credentials

        public static string StorageAccountConnection = ConfigurationManager.AppSettings["CloudStorage"];

        public static string MainHost = "Schooled";

        public static string EmailFromAddress = "";
        public static string EmailServer = "";
        public static string EmailUsername = "";
        public static string EmailPassword = "";
        public static int EmailPort = 0;
        public static bool EmailSsl = false;
    }
}