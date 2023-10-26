using System.Collections.ObjectModel;
using System.Windows.Input;
using AgendaApp.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AgendaApp.Views;

public partial class AgendaPage : ContentPage
{
	public ObservableCollection<Agenda> MyAgendaField;

	public ObservableCollection<Agenda> MyAgenda { get => GetAgenda(); }
	public ICommand DetailCommand { get; private set; }
    public ICommand RegisterCommand { get; private set; }
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    public AgendaPage()
	{
		InitializeComponent();

		var temp = MyAgenda;

        RegisterCommand = new Command((obj) =>
        {
            Agenda agenObj = obj as Agenda;
            RegisterAgenda(agenObj);
        });
        DetailCommand = new Command((obj) =>
        {
            Agenda agenObj = obj as Agenda;
            ShowDetailAgenda(agenObj);
        });

        this.BindingContext = this;
        
    }

    private ObservableCollection<Agenda> GetAgenda()
	{ return new ObservableCollection<Agenda>
		{
			new Agenda { Topic = "All Things Xamarin", Duration = "07:30 UTC -11:30 UTC",
			Color = Microsoft.Maui.Graphics.Color.FromArgb("#B96CBD"), Date = new DateTime(2020, 8, 23),
			Speakers = new ObservableCollection<Speaker>{ new Speaker { Name = "Maddy Leger", Time = "07:30"},
			new Speaker { Name = "David Ortinau", Time = "08:30"}, new Speaker { Name = "Gerald Versluis", Time = "10:30"} } },

			new Agenda { Topic = "Visualize Your Data", Duration = "07:30 UTC -11:30 UTC",
			Color = Microsoft.Maui.Graphics.Color.FromArgb("#49A24D"), Date = new DateTime(2020, 9, 24),
			Speakers = new ObservableCollection<Speaker>{ new Speaker { Name = "Maddy Leger", Time = "07:30"},
			new Speaker { Name = "David Ortinau", Time = "08:30"}, new Speaker { Name = "Gerald Versluis", Time = "10:30"} } },

			new Agenda { Topic = "Testing Your Xamarin Apps", Duration = "07:30 UTC -11:30 UTC",
			Color = Microsoft.Maui.Graphics.Color.FromArgb("#FDA838"), Date = new DateTime(2020, 12, 25),
			Speakers = new ObservableCollection<Speaker>{ new Speaker { Name = "Maddy Leger", Time = "07:30"},
			new Speaker { Name = "David Ortinau", Time = "08:30"}, new Speaker { Name = "Gerald Versluis", Time = "10: 30"} } },

			new Agenda { Topic = "Xamarin Productivity to the Max", Duration = "07:30 UTC -11:30 UTC",
			Color = Microsoft.Maui.Graphics.Color.FromArgb("#F75355"), Date = new DateTime(2020, 12, 26),
			Speakers = new ObservableCollection<Speaker>{ new Speaker { Name = "Maddy Leger", Time = "07:30"},
			new Speaker { Name = "David Ortinau", Time = "08:30"}, new Speaker { Name = "Gerald Versluis", Time = "10:30"} } },

			new Agenda { Topic = "All Things Xamarin.FormsShell", Duration = "07:30 UTC -11:30 UTC",
			Color = Microsoft.Maui.Graphics.Color.FromArgb("#00C6AE"), Date = new DateTime(2021, 3, 27),
			Speakers =  new ObservableCollection<Speaker>{ new Speaker { Name = "Maddy Leger", Time = "07:30"},
			new Speaker { Name = "David Ortinau", Time = "08:30"}, new Speaker { Name = "Gerald Versluis", Time = "10:30"} } },

			new Agenda { Topic = "Building Beautiful Apps", Duration = "07:30 UTC -11:30 UTC",
			Color = Microsoft.Maui.Graphics.Color.FromArgb("#455399"), Date = new DateTime(2021, 5, 28),
			Speakers = new ObservableCollection<Speaker>{ new Speaker { Name = "Maddy Leger", Time = "07:30"},
			new Speaker { Name = "David Ortinau", Time = "08:30"}, new Speaker { Name = "Gerald Versluis", Time = "10:30"} } }
		};
	}

    private async void RegisterAgenda(Agenda obj)
    {
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;
        var toast = Toast.Make(obj.Topic, duration, fontSize);
        await toast.Show(cancellationTokenSource.Token);
    }

    private async void ShowDetailAgenda(Agenda obj)
    {
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;
        var toast = Toast.Make($"{obj.Topic} : {obj.Speakers[0].Name}",
        duration, fontSize);
        await toast.Show(cancellationTokenSource.Token);
    }

}
