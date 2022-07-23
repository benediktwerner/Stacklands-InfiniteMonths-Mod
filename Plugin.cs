using BepInEx;
using HarmonyLib;

namespace InfiniteMonths
{
    [BepInPlugin("de.benediktwerner.stacklands.infinitemonths", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Plugin));
        }

        [HarmonyPatch(typeof(WorldManager), "MonthTime", MethodType.Getter)]
        [HarmonyPrefix]
        private static void WorldManager__MonthTime__get__Prefix(ref bool __runOriginal, out float __result)
        {
            __runOriginal = false;
            __result = float.PositiveInfinity;
        }
    }
}
