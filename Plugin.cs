using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace SkipTOS
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Awake()
        {
            var harmony = new Harmony(PluginInfo.GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
