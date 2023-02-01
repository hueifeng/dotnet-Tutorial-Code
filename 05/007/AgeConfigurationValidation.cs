using Microsoft.Extensions.Options;

namespace _007
{
    public class AgeConfigurationValidation : IValidateOptions<Persion>
    {
        public ValidateOptionsResult Validate(string? name, Persion options)
        {
            if (options.Age < 19)
            {
                return ValidateOptionsResult.Fail("填写信息有误，年龄必须大于19岁。");
            }
            return ValidateOptionsResult.Success;
        }
    }

}
