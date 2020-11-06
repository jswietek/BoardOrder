using System;
using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public interface IOptionsProvider {
		event Action<string> Fetching;
		Task FetchOptions();
	}
}