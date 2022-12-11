using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsKapu.Controllers
{
    public abstract class BaseController
    {

        abstract protected Color Color { get; set; }
        abstract protected string Title { get; set; }

        public virtual void AppHeader(string name = "")
        {
            AnsiConsole.Clear();
            Rule rule;
            if (name != "")
            {
                rule = new Rule(name);
            }
            else
            {
                rule = new Rule();
            }

            rule.Centered();
            rule.RuleStyle(StyleExtensions.Foreground(new Style(), Color));
            AnsiConsole.Write(rule);
            AnsiConsole.Write(
                new FigletText(Title)
                .Centered()
                .Color(Color));

            rule = new Rule();
            rule.RuleStyle(StyleExtensions.Foreground(new Style(), Color));
            AnsiConsole.Write(rule);
        }
    }
}
