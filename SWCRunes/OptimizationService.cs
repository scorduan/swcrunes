using System;
using SWCRunesLib;

namespace SWCRunes
{
	public class OptimizationService
	{
		public OptimizationService(StorageService store)
		{
			_store = store;

			_optim = new Optimizer(store.RuneStore,store.MonStore, store.ReqStore);


		}

		private StorageService _store;

		private Optimizer _optim;

		public List<Recommendation> Process()
		{
			return _optim.Process();
		}
	}
}