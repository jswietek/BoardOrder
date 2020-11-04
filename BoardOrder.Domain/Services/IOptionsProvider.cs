using System.Threading.Tasks;

namespace BoardOrder.Domain.Services {
	public interface IOptionsProvider {
		Task FetchOptions();
	}
}