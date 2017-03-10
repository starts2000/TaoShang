using System;

namespace Starts2000.TaobaoPlatform.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
    }
}