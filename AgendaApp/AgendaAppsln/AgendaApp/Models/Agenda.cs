using System;
using System.Collections.ObjectModel;

namespace AgendaApp.Models
{
    public class Agenda
    {
        public string Topic { get; set; }
        public string Duration { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<Speaker> Speakers { get; set; }
        public Microsoft.Maui.Graphics.Color Color { get; set; }
    }


  }


