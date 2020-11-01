using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardOrder.Preferences.ViewModels {
	class PreferencesViewModel {
		public IEnumerable<string> Labels {
			get {
				return new List<string>() { "raz", "Dwa" };
			}
		}
	}
}
