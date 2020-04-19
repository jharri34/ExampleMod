using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Engine.Screens;
using TaleWorlds.MountAndBlade.View.Missions;

namespace ExampleMod
{
    class MenuOpenEncyclopediaBehavior : MenuOptionBehaviorBase
    {
        protected override void OnMenuOptionClicked(MenuCallbackArgs args)
        {
            ScreenManager.PushScreen(ViewCreatorManager.CreateScreenView<ConfigMenuScreenBase>());
        }
    }
}
