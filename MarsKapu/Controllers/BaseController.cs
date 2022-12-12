using MarsKapu.Application.Contracts.Controllers;
using MarsKapu.DataContracts.Enums;
using MarsKapu.State;
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
        protected readonly AppState appState;

        abstract protected Color Color { get; set; }
        abstract protected string Title { get; set; }

        public BaseController(AppState appState)
        {
            this.appState = appState;
        }
        public virtual void AppHeader()
        {
            AnsiConsole.Clear();
            Rule rule;
            if (appState.CurrentUser != null)
            {
                rule = new Rule(appState.CurrentUser.Name);
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

        public MenuChoice LogOut()
        {
            appState.CurrentUser = null;
            return MenuChoice.APPLICATION;
        }

        public abstract MenuChoice ShowMenu();
    }
}
