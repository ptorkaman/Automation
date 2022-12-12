using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.UserArea.Hubs
{
    public class LetterHub : Hub
    {
        private readonly ILettersRepository _iletter;

        public LetterHub(ILettersRepository iletter)
        {
            _iletter = iletter;
        }
        public async Task SentLetters(string userIdList)
        {
            List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(userIdList);
            for (int i = 0; i < items.Count; i++)
            {
                await Clients.Users(_iletter.GetUserIdFromJobID(Convert.ToInt32(items[i].id))).SendAsync("RecievedLetter");
            }
        }
    }
}