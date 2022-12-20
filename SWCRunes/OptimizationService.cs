using System;
using SWCRunesLib;
using System.Collections.ObjectModel;

namespace SWCRunes
{
	public class OptimizationService
	{
		public OptimizationService(StorageService store)
		{
			_store = store;

			_optim = new Optimizer(store.RuneStore, store.MonStore, store.ReqStore);


		}

		private StorageService _store;

		private Optimizer _optim;

		public List<Recommendation> Process()
		{
			return _optim.Process();
		}


		public Recommendation Recommended { get; set; }

		public Recommendation ProcessRequest(Request req)
		{
			Recommended = _optim.ProcessReq(req);
			OptimizationCompletedEvent?.Invoke(this,Recommended);
			return Recommended;
		}

        // Declare the delegate (if using non-generic pattern).
        public delegate void OptimizationCompletedHandler(object sender, Recommendation recommendation);

		// Declare the event.
		public event OptimizationCompletedHandler OptimizationCompletedEvent;

    }
}