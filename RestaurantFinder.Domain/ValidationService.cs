using RestaurantFinder.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestaurantFinder.Domain
{
    public interface IValidationService
    {
        public Task<bool> ValidatePostCode(string code);
    }
    public class ValidationService : IValidationService
    {
        public async Task<bool> ValidatePostCode(string code)
        {
            return Regex.IsMatch(code, AppConstants.ValidationConstant.POST_CODE_REGEX);
        }
    }
}
