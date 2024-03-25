using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace forceKnifeSpawn;

public class forceKnifeSpawn : BasePlugin {
    public override string ModuleName => "Force Knife Spawn";
    public override string ModuleAuthor => "Chase88";
    public override string ModuleDescription => "This is a simple plugin that will force all players to recieve a knife on spawn.";
    public override string ModuleVersion => "1.0.0";

    public override void Load(bool hotReload) {
        //Hook into the player spawn event
        RegisterEventHandler<EventPlayerSpawn>((@event, info) => {
            //Check to make sure our player is valid
            if(@event == null || !@event.Userid.IsValid) {
                return HookResult.Continue;
            }

            //Give the player a knife
            @event.Userid.GiveNamedItem("weapon_knife");

            return HookResult.Continue;
        });
    }
}