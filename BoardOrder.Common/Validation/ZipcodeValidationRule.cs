using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace BoardOrder.Common.Validation {
	public class ZipcodeValidationRule : ValidationRule {
		const string ZipCodeRegex = @"^[0-9]{5}(?:-[0-9]{4})?$";

		public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
			var isValidZipCode = false;
			if (value is string zipCodeCandidate && !string.IsNullOrEmpty(zipCodeCandidate)) {
				isValidZipCode = Regex.IsMatch(zipCodeCandidate, ZipCodeRegex);
			}

			return isValidZipCode ? ValidationResult.ValidResult : new ValidationResult(isValidZipCode, "Invalid zip code. Please use 5- or 5+4- digit zipcode format");
		}
	}
}
