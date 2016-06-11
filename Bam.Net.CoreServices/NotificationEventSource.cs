﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bam.Net.Data.Repositories;
using Bam.Net.Logging;
using Bam.Net.Messaging;
using Bam.Net.Server;
using Bam.Net.ServiceProxy;

namespace Bam.Net.CoreServices
{
    [Proxy("notificationEvents")]
    public class NotificationEventSource : EventSource
    {
        public NotificationEventSource(DaoRepository daoRepository, AppConf appConf, ILogger logger, ISmtpSettingsProvider smtpSettingsProvider) : base(daoRepository, appConf, logger)
        {
            SupportedEvents.Add("Error");
            SupportedEvents.Add("Fatal");

            SmtpSettingsProvider = smtpSettingsProvider;
        }
      
        public override object Clone()
        {
            return new NotificationEventSource(DaoRepository, AppConf, Logger, SmtpSettingsProvider);
        }

        public override Task FireEvent(string eventName, string json)
        {
            EnsureSupportedEventOrThrow(eventName);
            return base.FireEvent(eventName, json);
        }

        public override void Subscribe(string eventName, Action<EventMessage, IHttpContext> listener)
        {
            EnsureSupportedEventOrThrow(eventName);
            base.Subscribe(eventName, listener);
        }
        protected ISmtpSettingsProvider SmtpSettingsProvider { get; private set; }
        private bool EventSupported(string eventName)
        {
            return SupportedEvents.Contains(eventName);
        }

        private void EnsureSupportedEventOrThrow(string eventName)
        {
            if (!EventSupported(eventName))
            {
                throw new InvalidOperationException();
            }
        }
    }
}
