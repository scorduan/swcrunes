namespace SWCRunes;

public partial class App : Application
{
	public App(SimulationService simulationService)
	{
		SimService = simulationService;
		InitializeComponent();

		MainPage = new AppShell();
	}

	public SimulationService SimService {get; set; }
}

