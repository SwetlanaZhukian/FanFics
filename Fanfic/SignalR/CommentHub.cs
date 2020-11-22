using Fanfic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.SignalR
{
    public class CommentHub:Hub
    {
        CompositionService compositionService;
        
        public CommentHub(CompositionService service)
        {
           
            compositionService = service;
        }
        [Authorize]
        public async Task Send(string message, string userName)
        {
           
            await this.Clients.All.SendAsync("Send", message,userName);
        }
        [Authorize]
        public async Task Save(int compositionId, string message)
        {
           
            var user = Context.User;
            var userName = user.Identity.Name;
            await compositionService.SaveComment(compositionId, message, userName);

            
        }
    }
}
