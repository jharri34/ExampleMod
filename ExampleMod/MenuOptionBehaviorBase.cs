using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;

namespace ExampleMod
{
    public abstract  class MenuOptionBehaviorBase : CampaignBehaviorBase
    {
        private readonly string _menuId;
        private readonly string _menuOptionId;
        private readonly string _menuOptionText;
        private readonly GameMenuOption.LeaveType _menuLeaveType;
        private readonly bool _isLeave;
        private readonly int _index;

        protected MenuOptionBehaviorBase(){}
        public override void RegisterEvents()
        {
            CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnNewGameCreated);
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        }

        public override void SyncData(IDataStore dataStore)
        {
            throw new NotImplementedException();
        }
        private void OnNewGameCreated(CampaignGameStarter campaignGameStarter)
        {
            InitializeBehavior(campaignGameStarter);
        }

        private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
        {
            InitializeBehavior(campaignGameStarter);
        }

        private void InitializeBehavior(CampaignGameStarter campaignGameStarter)
        {
            campaignGameStarter?.AddGameMenuOption(_menuId, _menuOptionId, _menuOptionText, MenuCondition,
                MenuConsequence, _isLeave, _index);
        }
        private bool MenuCondition(MenuCallbackArgs args)
        {
            args.optionLeaveType = _menuLeaveType;
            return true;
        }
        private void MenuConsequence(MenuCallbackArgs args)
        {
            OnMenuOptionClicked(args);
        }
        protected abstract void OnMenuOptionClicked(MenuCallbackArgs args);

    }
}
