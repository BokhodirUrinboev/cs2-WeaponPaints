using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponPaints
{
    public static class SteamIdValidator
    {
        public static bool HasReservationPermission(string steamIdStr)
        {

            if (!ulong.TryParse(steamIdStr, out ulong steamIdLong))
            {
                return false;
            }

            var playerInfoList = Utilities.GetPlayers().Where(pl => pl.SteamID == steamIdLong).ToList();


            if (playerInfoList.Count == 0)
            {
                return false;
            }


            return AdminManager.PlayerHasPermissions(playerInfoList[0], new[] { "@css/reservation" });
        }
    }

}
