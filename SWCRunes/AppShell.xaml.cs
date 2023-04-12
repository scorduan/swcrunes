namespace SWCRunes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        /*
        Routing.RegisterRoute("monsters/new", typeof(MonsterNewPage));
        Routing.RegisterRoute("monsters/edit", typeof(MonsterEditPage));

        Routing.RegisterRoute("runes/new", typeof(RuneNewPage));
        Routing.RegisterRoute("runes/edit", typeof(RuneEditPage));

        Routing.RegisterRoute("requests/new", typeof(RequestNewPage));
        Routing.RegisterRoute("requests/edit", typeof(RequestEditPage));

        Routing.RegisterRoute("recommendations/new", typeof(RequestNewPage));
        Routing.RegisterRoute("recommendations/edit", typeof(RequestEditPage));
        */

        Routing.RegisterRoute("teams/new", typeof(TeamNewPage));
        Routing.RegisterRoute("recommendations/detail", typeof(RecommendationDetail));
        Routing.RegisterRoute("monsters/detail", typeof(MonsterDetail));
        Routing.RegisterRoute("requests/detail", typeof(RequestDetail));
        Routing.RegisterRoute("requests/detail/threshold", typeof(ThresholdDetail));

    }
}

