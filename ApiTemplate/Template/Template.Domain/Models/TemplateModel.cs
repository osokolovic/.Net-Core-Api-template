using ServiceCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class TemplateModel : IAggregateRoot
    {
        public Guid TemplateId { get; set; }
        public string TemplateName { get; set; }
    }
}
