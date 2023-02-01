using System.ComponentModel.DataAnnotations;

namespace _007
{
    public class Persion
    {
        public string Name { get; set; }
        //[RangeAttribute(minimum: 19, maximum: int.MaxValue, ErrorMessage = "填写信息有误，年龄必须大于19岁。")]
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public Company Company { get; set; }

    }
}
