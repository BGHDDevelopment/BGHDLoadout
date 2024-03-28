using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace FiveMLoadout
{
    public class Loadout : BaseScript
    {
        public Loadout()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            Tick += OnTick;
            EventHandlers["playerSpawned"] += new Action<Vector3>(playerSpawned);
        }

        private async Task OnTick()
        {
            await Delay(100);
        }

        private void OnClientResourceStart(string resourceName)
        {
            RegisterCommand("loadout", new Action<int, List<object>, string>((source, args, raw) =>
            {
                Game.PlayerPed.Weapons.RemoveAll();
                Game.PlayerPed.Weapons.Give(WeaponHash.Flare, 10, false, true);
                var pistol = Game.PlayerPed.Weapons.Give(WeaponHash.Pistol, 500, false, true);
                GiveWeaponComponentToWeaponObject(pistol.GetHashCode(), (uint)WeaponComponentHash.FlashlightLight);
                Game.PlayerPed.Weapons.Give(WeaponHash.FireExtinguisher, 5100, false, true);
                Game.PlayerPed.Weapons.Give(WeaponHash.StunGun, 5100, false, true);
                Game.PlayerPed.Weapons.Give(WeaponHash.Nightstick, 5100, false, true);
                Game.PlayerPed.Weapons.Give(WeaponHash.PumpShotgun, 5100, false, true);
                Game.PlayerPed.Weapons.Give(WeaponHash.Flare, 10, false, true);
                Game.PlayerPed.Weapons.Give(WeaponHash.PetrolCan, 1, false, true);
                var carbineRifle = Game.PlayerPed.Weapons.Give(WeaponHash.CarbineRifle, 500, false, true);
                GiveWeaponComponentToWeaponObject(carbineRifle.GetHashCode(), (uint)WeaponComponentHash.AtArFlsh);

                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[LOADOUT]", "^3You have received the default loadout!" }
                });
            }), false);


            RegisterCommand("clearloadout", new Action<int, List<object>, string>((source, args, raw) =>
            {
                Game.PlayerPed.Weapons.RemoveAll();
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[LOADOUT]", "^3You cleared your weapons!" }
                });
            }), false);
        }

        private void playerSpawned([FromSource] Vector3 spawn)
        {
            Game.PlayerPed.Weapons.RemoveAll();
            Game.PlayerPed.Weapons.Give(WeaponHash.Flare, 10, false, true);
            var pistol = Game.PlayerPed.Weapons.Give(WeaponHash.CombatPistol, 500, false, true);
            GiveWeaponComponentToWeaponObject(pistol.GetHashCode(), (uint)WeaponComponentHash.FlashlightLight);
            Game.PlayerPed.Weapons.Give(WeaponHash.FireExtinguisher, 5100, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.StunGun, 5100, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.Nightstick, 5100, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.PumpShotgun, 5100, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.Flare, 10, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.PetrolCan, 1, false, true);
            var carbineRifle = Game.PlayerPed.Weapons.Give(WeaponHash.CarbineRifle, 500, false, true);
            GiveWeaponComponentToWeaponObject(carbineRifle.GetHashCode(), (uint)WeaponComponentHash.AtArFlsh);
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 0, 0 },
                multiline = true,
                args = new[] { "[LOADOUT]", "^3You have received the default loadout!" }
            });
        }
    }
}