﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManagement.ViewModels.AdminNotificationViewModel;

namespace StudentManagement.ViewModels
{
    public class ShowDetailNotificationViewModel
    {
        public CardNotification CurrentCard { get => _currentCard; set => _currentCard = value; }
        private CardNotification _currentCard;
        public ShowDetailNotificationViewModel(CardNotification card)
        {
            this.CurrentCard = card;
        }
    }
}
