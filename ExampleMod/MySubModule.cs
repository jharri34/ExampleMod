using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.InputSystem;

namespace ExampleMod
{
    public class MySubModule : MBSubModuleBase
    {
        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);
            if (Campaign.Current != null){
                if (Campaign.Current.GameStarted){
                    if (InputKey.F1.IsPressed()){
                        List<InquiryElement> inquiryElements = new List<InquiryElement>{
                                new InquiryElement("showPotentialWife", "Show Potential Wife", null, true, "Shows all women name, age, and last place seen thats not dead or a child."),
                        };
                        InformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData("Wife Info","", inquiryElements, true, true, "Show", "Close", new Action<List<InquiryElement>>(this.OptionSelected), null, ""), true);
                    }
                }
            }
        }

        private void OptionSelected(List<InquiryElement> obj)
        {
            InquiryElement selection = obj.FirstOrDefault<InquiryElement>();
            if (selection != null)
            {
                string a = selection.Identifier as string;
                if (a == "showPotentialWife")
                {
                    showPotentialWife();
                }
            };
        }


        private void showPotentialWife(){
            string output = "";
            foreach (Hero hero in Hero.All) {
                if (hero != null && hero.IsFemale && hero.IsAlive && !hero.IsChild && hero.IsFertile) {
                    
                    output += "NAME : " + hero.Name.ToString() + " , ";
                    output += "ENCYCLOPEDIA : " + hero.EncyclopediaLink + " , ";
                    output += "LOCATION: " + hero.CurrentSettlement + " , ";
                    output += "AGE : " + hero.Age.ToString() + " \n ";
                    
 
                }
            }
            InformationManager.ShowInquiry(new InquiryData("Potential Wife Info", output, true, false, "Close", "Cancel", null, null, ""), false);
        }
    }
}
