﻿using System.Threading;
using Shuttle.EMailSender.Messages;
using Shuttle.ESB.Core;

namespace Shuttle.EMailSender.Server
{
    public class SendEMailHandler : IMessageHandler<SendEMailCommand>
    {
        public void ProcessMessage(HandlerContext<SendEMailCommand> context)
        {
            // simulate sending an e-mail

            Thread.Sleep(2000);

            context.Publish(new EMailSentEvent
            {
                EMailId = context.Message.EMailId
            });
        }

        public bool IsReusable {
            get { return true; }
        }
    }
}