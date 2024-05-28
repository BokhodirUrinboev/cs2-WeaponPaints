using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API;


namespace WeaponPaints
{
    internal static class SteamIdValidator
    {
        internal static bool HasReservationPermission(string steamIdStr)
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
