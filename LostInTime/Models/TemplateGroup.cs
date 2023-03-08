using System.Collections.Generic;

namespace LostInTime.Models
{
    public class TemplateGroup
    {
        public int TemplateGroupId { get; set; }
        public string? Name { get; set; }
        public List<TemplateGroupItem> Items { get; set; } = new();
    }
}
