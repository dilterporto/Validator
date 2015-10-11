using System;
using System.Text.RegularExpressions;

namespace Validator.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MatchAttribute : ValidateAttribute
    {
        public MatchAttribute(string message)
            : base(message)
        {
            
        }
        
        /// <summary>Regex Pattern</summary>
        public string Pattern { get; set;}
        
        public override bool IsValid(object value)
        {            
            var rgx = new Regex(this.Pattern, RegexOptions.IgnoreCase);
            var match = rgx.Match(value.ToString());
            
            return match.Success;
        }
    }
}