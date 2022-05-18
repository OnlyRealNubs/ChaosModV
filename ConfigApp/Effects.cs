using System.Collections.Generic;

namespace ConfigApp
{
    public static class Effects
    {
        public struct EffectInfo
        {
            public EffectInfo(string name, EffectCategory effectCategory, bool isTimed = false, bool isShort = false)
            {
                Name = name;
                EffectCategory = effectCategory;
                IsTimed = isTimed;
                IsShort = isShort;
            }

            public readonly string Name;
            public readonly EffectCategory EffectCategory;
            public readonly bool IsTimed;
            public readonly bool IsShort;
        }

        public enum EffectCategory
        {
            PLAYER,
            VEHICLE,
            PEDS,
            TIME,
            WEATHER,
            MISC,
            META
        }

        public enum EffectTimedType
        {
            TIMED_NORMAL,
            TIMED_SHORT
        }

        public static readonly Dictionary<string, EffectInfo> EffectsMap = new Dictionary<string, EffectInfo>()
        {
            { "player_suicide", new EffectInfo("Suicide", EffectCategory.PLAYER) },
            { "player_plus2stars", new EffectInfo("+2 Wanted Stars", EffectCategory.PLAYER) },
            { "player_5stars", new EffectInfo("5 Wanted Stars", EffectCategory.PLAYER) },
            { "player_neverwanted", new EffectInfo("Never Wanted", EffectCategory.PLAYER, true) },
            { "peds_remweps", new EffectInfo("Remove Weapons From Everyone", EffectCategory.PEDS) },
            { "player_heal", new EffectInfo("HESOYAM", EffectCategory.PLAYER) },
            { "player_ignite", new EffectInfo("Ignite Player", EffectCategory.PLAYER) },
            { "spawn_grieferjesus", new EffectInfo("Spawn Griefer Jesus", EffectCategory.PEDS) },
            { "peds_spawnimrage", new EffectInfo("Spawn Impotent Rage", EffectCategory.PEDS) },
            { "spawn_grieferjesus2", new EffectInfo("Spawn Extreme Griefer Jesus", EffectCategory.PEDS) },
            { "peds_ignite", new EffectInfo("Ignite All Nearby Peds", EffectCategory.PEDS) },
            { "vehs_explode", new EffectInfo("Explode All Nearby Vehicles", EffectCategory.VEHICLE) },
            { "player_upupaway", new EffectInfo("Launch Player Up", EffectCategory.PLAYER) },
            { "vehs_upupaway", new EffectInfo("Launch All Vehicles Up", EffectCategory.VEHICLE) },
            { "playerveh_lock", new EffectInfo("Lock Player Inside Vehicle", EffectCategory.VEHICLE, true) },
            { "nothing", new EffectInfo("Nothing", EffectCategory.MISC) },
            { "playerveh_killengine", new EffectInfo("Kill Engine Of Every Vehicle", EffectCategory.VEHICLE) },
            { "time_morning", new EffectInfo("Set Time To Morning", EffectCategory.TIME) },
            { "time_day", new EffectInfo("Set Time To Daytime", EffectCategory.TIME) },
            { "time_evening", new EffectInfo("Set Time To Evening", EffectCategory.TIME) },
            { "time_night", new EffectInfo("Set Time To Night", EffectCategory.TIME) },
            { "weather_extrasunny", new EffectInfo("Extra Sunny Weather", EffectCategory.WEATHER) },
            { "weather_stormy", new EffectInfo("Stormy Weather", EffectCategory.WEATHER) },
            { "weather_foggy", new EffectInfo("Foggy Weather", EffectCategory.WEATHER) },
            { "weather_neutral", new EffectInfo("Neutral Weather", EffectCategory.WEATHER) },
            { "weather_snowy", new EffectInfo("Snowy Weather", EffectCategory.WEATHER) },
            { "tp_lsairport", new EffectInfo("Teleport To LS Airport", EffectCategory.PLAYER) },
            { "tp_mazebanktower", new EffectInfo("Teleport To Top Of Maze Bank Tower", EffectCategory.PLAYER) },
            { "tp_fortzancudo", new EffectInfo("Teleport To Fort Zancudo", EffectCategory.PLAYER) },
            { "tp_skyfall", new EffectInfo("Teleport To Heaven", EffectCategory.PLAYER) },
            { "tp_mountchilliad", new EffectInfo("Teleport To Mount Chiliad", EffectCategory.PLAYER) },
            { "tp_random", new EffectInfo("Teleport To Random Location", EffectCategory.PLAYER) },
            { "tp_mission", new EffectInfo("Teleport To Random Mission", EffectCategory.PLAYER) },
            { "tp_fake", new EffectInfo("Fake Teleport", EffectCategory.PLAYER) },
            { "player_tp_store", new EffectInfo("Teleport to Random Store", EffectCategory.PLAYER) },
            { "player_nophone", new EffectInfo("No Phone", EffectCategory.MISC, true) },
            { "player_tpclosestveh", new EffectInfo("Set Player Into Closest Vehicle", EffectCategory.PLAYER) },
            { "playerveh_exit", new EffectInfo("Everyone Exits Their Vehicles", EffectCategory.PEDS) },
            { "time_x02", new EffectInfo("x0.2 Gamespeed", EffectCategory.TIME, true, true) },
            { "time_x05", new EffectInfo("x0.5 Gamespeed", EffectCategory.TIME, true, true) },
            { "time_lag", new EffectInfo("Lag", EffectCategory.MISC, true, true) },
            { "peds_riot", new EffectInfo("Peds Riot", EffectCategory.PEDS, true) },
            { "vehs_red", new EffectInfo("Red Traffic", EffectCategory.VEHICLE, true) },
            { "vehs_blue", new EffectInfo("Blue Traffic", EffectCategory.VEHICLE, true) },
            { "vehs_green", new EffectInfo("Green Traffic", EffectCategory.VEHICLE, true) },
            { "vehs_chrome", new EffectInfo("Chrome Traffic", EffectCategory.VEHICLE, true) },
            { "vehs_pink", new EffectInfo("Hot Traffic", EffectCategory.VEHICLE, true) },
            { "vehs_rainbow", new EffectInfo("Rainbow Traffic", EffectCategory.VEHICLE, true) },
            { "player_firstperson", new EffectInfo("First Person", EffectCategory.MISC, true) },
            { "vehs_slippery", new EffectInfo("Slippery Vehicles", EffectCategory.VEHICLE, true) },
            { "vehs_nogravity", new EffectInfo("Vehicles Have No Gravity", EffectCategory.VEHICLE, true, true) },
            { "player_invincible", new EffectInfo("Invincibility", EffectCategory.PLAYER, true) },
            { "vehs_x2engine", new EffectInfo("2x Vehicle Engine Speed", EffectCategory.VEHICLE, true) },
            { "vehs_x10engine", new EffectInfo("10x Vehicle Engine Speed", EffectCategory.VEHICLE, true) },
            { "vehs_x05engine", new EffectInfo("0.5x Vehicle Engine Speed", EffectCategory.VEHICLE, true) },
            { "spawn_rhino", new EffectInfo("Spawn Rhino", EffectCategory.VEHICLE) },
            { "spawn_adder", new EffectInfo("Spawn Adder", EffectCategory.VEHICLE) },
            { "spawn_dump", new EffectInfo("Spawn Dump", EffectCategory.VEHICLE) },
            { "spawn_monster", new EffectInfo("Spawn Monster", EffectCategory.VEHICLE) },
            { "spawn_bmx", new EffectInfo("Spawn BMX", EffectCategory.VEHICLE) },
            { "spawn_tug", new EffectInfo("Spawn Tug", EffectCategory.VEHICLE) },
            { "spawn_cargo", new EffectInfo("Spawn Cargo Plane", EffectCategory.VEHICLE) },
            { "spawn_bus", new EffectInfo("Spawn Bus", EffectCategory.VEHICLE) },
            { "spawn_blimp", new EffectInfo("Spawn Blimp", EffectCategory.VEHICLE) },
            { "spawn_buzzard", new EffectInfo("Spawn Buzzard", EffectCategory.VEHICLE) },
            { "spawn_faggio", new EffectInfo("Spawn Faggio", EffectCategory.VEHICLE) },
            { "spawn_ruiner3", new EffectInfo("Spawn Ruined Ruiner", EffectCategory.VEHICLE) },
            { "spawn_baletrailer", new EffectInfo("Spawn Bale Trailer", EffectCategory.VEHICLE) },
            { "spawn_romero", new EffectInfo("Where's The Funeral?", EffectCategory.VEHICLE) },
            { "spawn_random", new EffectInfo("Spawn Random Vehicle", EffectCategory.VEHICLE) },
            { "notraffic", new EffectInfo("No Traffic", EffectCategory.VEHICLE, true) },
            { "playerveh_explode", new EffectInfo("Detonate Current Vehicle", EffectCategory.VEHICLE) },
            { "peds_ghost", new EffectInfo("Everyone Is A Ghost", EffectCategory.PEDS, true) },
            { "vehs_ghost", new EffectInfo("Invisible Vehicles", EffectCategory.VEHICLE, true) },
            { "no_radar", new EffectInfo("No Radar", EffectCategory.MISC, true) },
            { "no_hud", new EffectInfo("No HUD", EffectCategory.MISC, true) },
            { "player_superrun", new EffectInfo("Super Run & Super Jump", EffectCategory.PLAYER, true) },
            { "player_ragdoll", new EffectInfo("Ragdoll", EffectCategory.PLAYER) },
            { "peds_ragdoll", new EffectInfo("Ragdoll Everyone", EffectCategory.PEDS) },
            { "peds_sensitivetouch", new EffectInfo("Sensitive Touch", EffectCategory.PEDS, true, true) },
            { "poorboi", new EffectInfo("Poor Boy", EffectCategory.PLAYER) },
            { "player_famous", new EffectInfo("You Are Famous", EffectCategory.PEDS, true) },
            { "player_drunk", new EffectInfo("Drunk", EffectCategory.PLAYER, true) },
            { "player_ohko", new EffectInfo("One Hit KO", EffectCategory.PEDS, true) },
            { "screen_lsd", new EffectInfo("LSD", EffectCategory.PLAYER, true) },
            { "screen_lowrenderdist", new EffectInfo("Where Did Everything Go?", EffectCategory.MISC, true, true) },
            { "screen_fog", new EffectInfo("Extreme Fog", EffectCategory.MISC, true, true) },
            { "screen_lsnoire", new EffectInfo("LS Noire", EffectCategory.MISC, true) },
            { "screen_bright", new EffectInfo("Deep Fried", EffectCategory.MISC, true, true) },
            { "screen_mexico", new EffectInfo("Is This What Mexico Looks Like?", EffectCategory.MISC, true) },
            { "screen_fullbright", new EffectInfo("Fullbright", EffectCategory.MISC, true) },
            { "screen_bubblevision", new EffectInfo("Bubble Vision", EffectCategory.MISC, true, true) },
            { "peds_blind", new EffectInfo("Blind Peds", EffectCategory.PEDS, true) },
            { "vehs_honkboost", new EffectInfo("Honk Boosting", EffectCategory.VEHICLE, true) },
            { "peds_mindmg", new EffectInfo("Minimal Damage", EffectCategory.PEDS, true) },
            { "peds_frozen", new EffectInfo("Peds Are Brainless", EffectCategory.PEDS, true) },
            { "lowgravity", new EffectInfo("Low Gravity", EffectCategory.MISC, true, true) },
            { "verylowgravity", new EffectInfo("Very Low Gravity", EffectCategory.MISC, true, true) },
            { "insanegravity", new EffectInfo("Insane Gravity", EffectCategory.MISC, true, true) },
            { "invertgravity", new EffectInfo("Invert Gravity", EffectCategory.MISC, true, true) },
            { "playerveh_repair", new EffectInfo("Repair All Vehicles", EffectCategory.VEHICLE) },
            { "playerveh_poptires", new EffectInfo("Pop Tires Of Every Vehicle", EffectCategory.VEHICLE) },
            { "vehs_poptiresconstant", new EffectInfo("Now This Is Some Tire Poppin'", EffectCategory.VEHICLE, true, true) },
            { "player_nospecial", new EffectInfo("No Special Ability", EffectCategory.PLAYER, true) },
            { "peds_dance", new EffectInfo("In The Hood", EffectCategory.PEDS, true) },
            { "player_forcedcinematiccam", new EffectInfo("Cinematic Vehicle Cam", EffectCategory.VEHICLE, true) },
            { "peds_flee", new EffectInfo("All Nearby Peds Are Fleeing", EffectCategory.PEDS) },
            { "playerveh_breakdoors", new EffectInfo("Break Doors Of Every Vehicle", EffectCategory.VEHICLE) },
            { "zombies", new EffectInfo("Explosive Zombies", EffectCategory.PEDS, true) },
            { "meteorrain", new EffectInfo("Meteor Shower", EffectCategory.MISC, true) },
            { "world_blackout", new EffectInfo("Blackout", EffectCategory.MISC, true) },
            { "time_quickday", new EffectInfo("Timelapse", EffectCategory.TIME, true) },
            { "player_break", new EffectInfo("Autopilot", EffectCategory.PLAYER, true, true) },
            { "peds_giverpg", new EffectInfo("Give Everyone An RPG", EffectCategory.PEDS) },
            { "peds_stungun", new EffectInfo("Give Everyone A Stun Gun", EffectCategory.PEDS) },
            { "peds_minigun", new EffectInfo("Give Everyone A Minigun", EffectCategory.PEDS) },
            { "peds_upnatomizer", new EffectInfo("Give Everyone An Up-N-Atomizer", EffectCategory.PEDS) },
            { "peds_randomwep", new EffectInfo("Give Everyone A Random Weapon", EffectCategory.PEDS) },
            { "peds_railgun", new EffectInfo("Give Everyone A Railgun", EffectCategory.PEDS) },
            { "peds_battleaxe", new EffectInfo("Give Everyone A Battle Axe", EffectCategory.PEDS) },
            { "player_nosprint", new EffectInfo("No Sprint & No Jump", EffectCategory.PLAYER, true) },
            { "peds_invincible", new EffectInfo("Everyone Is Invincible", EffectCategory.PEDS, true) },
            { "vehs_invincible", new EffectInfo("All Vehicles Are Invulnerable", EffectCategory.VEHICLE, true) },
            { "player_ragdollondmg", new EffectInfo("Player Ragdolls When Shot", EffectCategory.PLAYER, true) },
            { "vehs_jumpy", new EffectInfo("Jumpy Vehicles", EffectCategory.VEHICLE, true, true) },
            { "vehs_lockdoors", new EffectInfo("Lock All Vehicles", EffectCategory.VEHICLE) },
            { "chaosmode", new EffectInfo("Doomsday", EffectCategory.MISC, true, true) },
            { "player_noragdoll", new EffectInfo("No Ragdoll", EffectCategory.PEDS, true) },
            { "vehs_honkconstant", new EffectInfo("All Vehicles Honk", EffectCategory.VEHICLE, true) },
            { "player_tptowaypoint", new EffectInfo("Teleport To Waypoint", EffectCategory.PLAYER) },
            { "peds_sayhi", new EffectInfo("Friendly Neighborhood", EffectCategory.PEDS, true) },
            { "peds_insult", new EffectInfo("Unfriendly Neighborhood", EffectCategory.PEDS, true) },
            { "player_explosivecombat", new EffectInfo("Explosive Combat", EffectCategory.PEDS, true) },
            { "player_allweps", new EffectInfo("Give All Weapons", EffectCategory.PLAYER) },
            { "peds_aimbot", new EffectInfo("Aimbot Peds", EffectCategory.PEDS, true) },
            { "spawn_chop", new EffectInfo("Spawn Companion Doggo", EffectCategory.PEDS) },
            { "spawn_chimp", new EffectInfo("Spawn Companion Chimp", EffectCategory.PEDS) },
            { "spawn_compbrad", new EffectInfo("Spawn Companion Brad", EffectCategory.PEDS) },
            { "spawn_comprnd", new EffectInfo("Spawn Random Companion", EffectCategory.PEDS) },
            { "player_nightvision", new EffectInfo("Night Vision", EffectCategory.MISC, true) },
            { "player_heatvision", new EffectInfo("Heat Vision", EffectCategory.MISC, true, true) },
            { "player_moneydrops", new EffectInfo("Money Rain", EffectCategory.MISC, true) },
            { "playerveh_tprandompeds", new EffectInfo("Teleport Random Peds Into Current Vehicle", EffectCategory.PEDS) },
            { "peds_revive", new EffectInfo("Revive Dead Peds", EffectCategory.PEDS) },
            { "world_snow", new EffectInfo("Snow", EffectCategory.WEATHER, true) },
            { "world_whalerain", new EffectInfo("Whale Rain", EffectCategory.MISC, true) },
            { "playerveh_maxupgrades", new EffectInfo("Add Max Upgrades To Every Vehicle", EffectCategory.VEHICLE) },
            { "playerveh_randupgrades", new EffectInfo("Add Random Upgrades To Every Vehicle", EffectCategory.VEHICLE) },
            { "player_arenawarstheme", new EffectInfo("Play Arena Wars Theme", EffectCategory.MISC, true) },
            { "peds_driveby", new EffectInfo("Peds Drive-By Player", EffectCategory.PEDS, true, true) },
            { "player_randclothes", new EffectInfo("Randomize Player Clothes", EffectCategory.PLAYER) },
            { "peds_rainbowweps", new EffectInfo("Rainbow Weapons", EffectCategory.MISC, true) },
            { "traffic_gtao", new EffectInfo("Traffic Magnet", EffectCategory.VEHICLE, true) },
            { "spawn_bluesultan", new EffectInfo("Spawn Blue Sultan", EffectCategory.PEDS) },
            { "player_setintorandveh", new EffectInfo("Set Player Into Random Vehicle", EffectCategory.PLAYER) },
            { "traffic_fullaccel", new EffectInfo("Full Acceleration", EffectCategory.VEHICLE, true, true) },
            { "misc_spawnufo", new EffectInfo("Spawn UFO", EffectCategory.MISC) },
            { "misc_spawnferriswheel", new EffectInfo("Spawn Ferris Wheel", EffectCategory.MISC) },
            { "peds_explosive", new EffectInfo("Explosive Peds", EffectCategory.PEDS, true) },
            { "invertvelocity", new EffectInfo("Invert Current Velocity", EffectCategory.MISC) },
            { "player_tpeverything", new EffectInfo("Teleport Everything To Player", EffectCategory.PLAYER) },
            { "weather_randomizer", new EffectInfo("Disco Weather", EffectCategory.WEATHER, true) },
            { "world_lowpoly", new EffectInfo("Low Render Distance", EffectCategory.MISC, true) },
            { "peds_obliterate", new EffectInfo("Obliterate All Nearby Peds", EffectCategory.PEDS) },
            { "vehs_alarmloop", new EffectInfo("Alarmy Vehicles", EffectCategory.VEHICLE, true) },
            { "veh_randomseat", new EffectInfo("Set Player Into Random Vehicle Seat", EffectCategory.PLAYER) },
            { "veh_30mphlimit", new EffectInfo("30MPH Speed Limit", EffectCategory.VEHICLE, true, true) },
            { "veh_jesustakethewheel", new EffectInfo("Jesus Take The Wheel", EffectCategory.VEHICLE) },
            { "veh_poptire", new EffectInfo("Random Tire Popping", EffectCategory.VEHICLE, true, true) },
            { "peds_angryalien", new EffectInfo("Spawn Angry Alien", EffectCategory.PEDS) },
            { "peds_angryjimmy", new EffectInfo("Spawn Jealous Jimmy", EffectCategory.PEDS) },
            { "vehs_ohko", new EffectInfo("Vehicles Explode On Impact", EffectCategory.VEHICLE, true) },
            { "vehs_spamdoors", new EffectInfo("Spammy Vehicle Doors", EffectCategory.VEHICLE, true) },
            { "veh_speed_goal", new EffectInfo("Need For Speed", EffectCategory.VEHICLE, true, true) },
            { "vehs_flyingcars", new EffectInfo("Flying Cars", EffectCategory.VEHICLE, true) },
            { "misc_credits", new EffectInfo("Roll Credits", EffectCategory.MISC, true, true) },
            { "misc_earthquake", new EffectInfo("Earthquake", EffectCategory.MISC, true, true) },
            { "player_tpfront", new EffectInfo("Teleport Player A Few Meters", EffectCategory.PLAYER) },
            { "peds_spawnfancats", new EffectInfo("Spawn Fan Cats", EffectCategory.PEDS) },
            { "peds_cops", new EffectInfo("All Peds Are Cops", EffectCategory.PEDS, true) },
            { "vehs_rotall", new EffectInfo("Flip All Vehicles", EffectCategory.VEHICLE) },
            { "peds_launchnearby", new EffectInfo("Launch All Nearby Peds Up", EffectCategory.PEDS) },
            { "peds_attackplayer", new EffectInfo("All Peds Attack Player", EffectCategory.PEDS, true) },
            { "player_clone", new EffectInfo("Clone Player", EffectCategory.PLAYER) },
            { "peds_slidy", new EffectInfo("Slidy Peds", EffectCategory.PEDS, true) },
            { "peds_spawndancingapes", new EffectInfo("Spawn Dance Troupe", EffectCategory.PEDS) },
            { "misc_onebullet", new EffectInfo("One Bullet Mags", EffectCategory.PEDS, true) },
            { "peds_phones", new EffectInfo("Whose Phone Is Ringing?", EffectCategory.PEDS, true) },
            { "misc_midas", new EffectInfo("Midas Touch", EffectCategory.PLAYER, true) },
            { "peds_spawnrandomhostile", new EffectInfo("Spawn Random Enemy", EffectCategory.PEDS) },
            { "peds_portal_gun", new EffectInfo("Portal Guns", EffectCategory.PEDS, true) },
            { "misc_fireworks", new EffectInfo("Fireworks!", EffectCategory.MISC, true) },
            { "peds_spawnballasquad", new EffectInfo("Spawn Balla Squad", EffectCategory.PEDS) },
            { "playerveh_despawn", new EffectInfo("Remove Current Vehicle", EffectCategory.VEHICLE) },
            { "peds_scooterbrothers", new EffectInfo("Scooter Brothers", EffectCategory.PEDS) },
            { "peds_intorandomvehs", new EffectInfo("Set Everyone Into Random Vehicles", EffectCategory.PEDS) },
            { "player_heavyrecoil", new EffectInfo("Heavy Recoil", EffectCategory.PLAYER, true) },
            { "peds_catguns", new EffectInfo("Catto Guns", EffectCategory.PEDS, true) },
            { "player_forcefield", new EffectInfo("Forcefield", EffectCategory.PLAYER, true, true) },
            { "misc_oilleaks", new EffectInfo("Oil Trails", EffectCategory.MISC, true) },
            { "peds_gunsmoke", new EffectInfo("Gunsmoke", EffectCategory.PEDS, true) },
            { "player_keeprunning", new EffectInfo("Help My W Key Is Stuck", EffectCategory.PLAYER, true, true) },
            { "veh_weapons", new EffectInfo("Vehicles Shoot Rockets", EffectCategory.VEHICLE, true) },
            { "misc_airstrike", new EffectInfo("Airstrike Inbound", EffectCategory.MISC, true) },
            { "peds_mercenaries", new EffectInfo("Mercenaries", EffectCategory.PEDS, true) },
            { "peds_loosetrigger", new EffectInfo("Loose Triggers", EffectCategory.PEDS, true) },
            { "peds_minions", new EffectInfo("Minions", EffectCategory.PEDS, true) },
            { "misc_flamethrower", new EffectInfo("Flamethrowers", EffectCategory.MISC, true) },
            { "misc_dvdscreensaver", new EffectInfo("DVD Screensaver", EffectCategory.MISC, true, true) },
            { "player_fakedeath", new EffectInfo("Fake Death", EffectCategory.PLAYER) },
            { "time_superhot", new EffectInfo("Superhot", EffectCategory.TIME, true) },
            { "vehs_beyblade", new EffectInfo("Beyblades", EffectCategory.VEHICLE, true, true) },
            { "peds_killerclowns", new EffectInfo("Killer Clowns", EffectCategory.PEDS, true, true) },
            { "peds_jamesbond", new EffectInfo("Spawn Deadly Agent", EffectCategory.PEDS) },
            { "player_poof", new EffectInfo("Deadly Aim", EffectCategory.PLAYER, true) },
            { "player_simeonsays", new EffectInfo("Simeon Says", EffectCategory.PLAYER, true, true) },
            { "player_lockcamera", new EffectInfo("Lock Camera", EffectCategory.PLAYER, true) },
            { "misc_replacevehicle", new EffectInfo("Replace Current Vehicle", EffectCategory.VEHICLE) },
            { "player_tired", new EffectInfo("I'm So Tired", EffectCategory.PLAYER, true) },
            { "player_kickflip", new EffectInfo("Kickflip", EffectCategory.PLAYER) },
            { "misc_superstunt", new EffectInfo("Super Stunt", EffectCategory.MISC) },
            { "player_walkonwater", new EffectInfo("Walk On Water", EffectCategory.PLAYER, true) },
            { "screen_needglasses", new EffectInfo("I Need Glasses", EffectCategory.MISC, true, true) },
            { "player_flip_camera", new EffectInfo("Turn Turtle", EffectCategory.PLAYER, true, true) },
            { "player_quake_fov", new EffectInfo("Quake FOV", EffectCategory.PLAYER, true) },
            { "player_rapid_fire", new EffectInfo("Rapid Fire", EffectCategory.PLAYER, true) },
            { "player_on_demand_cartoon", new EffectInfo("On-Demand TV", EffectCategory.MISC, true) },
            { "peds_drive_backwards", new EffectInfo("Peds Drive Backwards", EffectCategory.PEDS, true) },
            { "veh_randtraffic", new EffectInfo("Random Traffic", EffectCategory.VEHICLE, true) },
            { "misc_rampjam", new EffectInfo("Ramp Jam", EffectCategory.MISC, true) },
            { "misc_vehicle_rain", new EffectInfo("Vehicle Rain", EffectCategory.MISC, true, true) },
            { "misc_fakecrash", new EffectInfo("Fake Crash", EffectCategory.MISC) },
            { "player_gravity", new EffectInfo("Gravity Field", EffectCategory.PLAYER, true, true) },
            { "veh_bouncy", new EffectInfo("Bouncy Vehicles", EffectCategory.VEHICLE, true, false) },
            { "peds_stop_stare", new EffectInfo("Stop And Stare", EffectCategory.PEDS) },
            { "peds_flip", new EffectInfo("Spinning Peds", EffectCategory.PEDS, true, true) },
            { "player_pacifist", new EffectInfo("Pacifist", EffectCategory.PLAYER, true, false) },
            { "peds_busbois", new EffectInfo("Bus Bois", EffectCategory.PEDS) },
            { "player_dead_eye", new EffectInfo("Dead Eye", EffectCategory.PLAYER, true) },
            { "player_hacking", new EffectInfo("Realistic Hacking", EffectCategory.PLAYER) },
            { "peds_nailguns", new EffectInfo("Nailguns", EffectCategory.PEDS, true, true) },
            { "veh_brakeboost", new EffectInfo("Brake Boosting", EffectCategory.VEHICLE, true) },
            { "player_bees", new EffectInfo("Bees", EffectCategory.PLAYER, true) },
            { "player_vr", new EffectInfo("Virtual Reality", EffectCategory.PLAYER, true, true) },
            { "misc_portrait", new EffectInfo("Portrait Mode", EffectCategory.MISC, true) },
            { "misc_highpitch", new EffectInfo("High Pitch", EffectCategory.MISC, true) },
            { "misc_nosky", new EffectInfo("No Sky", EffectCategory.MISC, true) },
            { "player_gta_2", new EffectInfo("GTA 2", EffectCategory.PLAYER, true, true) },
            { "peds_kifflom", new EffectInfo("Kifflom!", EffectCategory.PEDS, true) },
            { "meta_timerspeed_0_5x", new EffectInfo("0.5x Timer Speed", EffectCategory.META, true) },
            { "meta_timerspeed_2x", new EffectInfo("2x Timer Speed", EffectCategory.META, true) },
            { "meta_timerspeed_5x", new EffectInfo("5x Timer Speed", EffectCategory.META, true, true) },
            { "meta_effect_duration_2x", new EffectInfo("2x Effect Duration", EffectCategory.META, true) },
            { "meta_effect_duration_0_5x", new EffectInfo("0.5x Effect Duration", EffectCategory.META, true) },
            { "meta_hide_chaos_ui", new EffectInfo("What's Happening??", EffectCategory.META, true) },
            { "meta_spawn_multiple_effects", new EffectInfo("Combo Time", EffectCategory.META, true) },
            { "misc_flip_ui", new EffectInfo("Flipped HUD", EffectCategory.MISC, true) },
            { "vehs_crumble", new EffectInfo("Crumbling Vehicles", EffectCategory.VEHICLE, true, true) },
            { "misc_fps_limit", new EffectInfo("Console Experience", EffectCategory.MISC, true, true) },
            { "meta_nochaos", new EffectInfo("No Chaos", EffectCategory.META, true) },
            { "player_spin_camera", new EffectInfo("Spinning Camera", EffectCategory.PLAYER, true, true) },
            { "misc_lowpitch", new EffectInfo("Low Pitch", EffectCategory.MISC, true) },
            { "peds_roasting", new EffectInfo("Get Roasted", EffectCategory.PEDS, true, true) },
            { "player_binoculars", new EffectInfo("Binoculars", EffectCategory.PLAYER, true) },
            { "peds_slippery_peds", new EffectInfo("Can't Tie My Shoes", EffectCategory.PEDS, true, true) },
            { "vehs_cruise_control", new EffectInfo("Cruise Control", EffectCategory.VEHICLE, true, true) },
            { "peds_hands_up", new EffectInfo("Hands Up!", EffectCategory.PEDS) },
            { "player_aimbot", new EffectInfo("Aimbot", EffectCategory.PLAYER, true) },
            { "player_jump_jump", new EffectInfo("Jump! Jump!", EffectCategory.PLAYER, true, true) },
            { "peds_spawn_biker", new EffectInfo("Spawn Biker", EffectCategory.PEDS) },
            { "peds_spawn_juggernaut", new EffectInfo("Spawn Juggernaut", EffectCategory.PEDS) },
            { "misc_witness_protection", new EffectInfo("Witness Protection", EffectCategory.MISC, true) },
            { "misc_quick_sprunk_stop", new EffectInfo("Quick Sprunk Stop", EffectCategory.MISC) },
            { "player_blimp_strats", new EffectInfo("Blimp Strats", EffectCategory.PLAYER) },
            { "peds_spawn_space_ranger", new EffectInfo("Spawn Space Ranger", EffectCategory.PEDS) },
            { "peds_mowermates", new EffectInfo("Mower Mates", EffectCategory.PEDS) },
            { "peds_tank_bois", new EffectInfo("Tanks A Lot", EffectCategory.PEDS) },
            { "veh_repossession", new EffectInfo("Repossession", EffectCategory.VEHICLE) },
            { "misc_pause", new EffectInfo("Pause", EffectCategory.MISC) },
            { "vehs_spawn_wizard_broom", new EffectInfo("You're A Wizard, Franklin", EffectCategory.VEHICLE) },
            { "player_illegalinnocence", new EffectInfo("Innocence Is Illegal", EffectCategory.PLAYER, true) },
            { "player_zoomzoom_cam", new EffectInfo("Zoom Zoom Cam", EffectCategory.PLAYER, true, true) },
            { "misc_spawn_orange_ball", new EffectInfo("Spawn Orange Ball", EffectCategory.MISC) },
            { "player_no_random_movement", new EffectInfo("Disable Random Direction", EffectCategory.PLAYER, true) },
            { "player_rocket", new EffectInfo("Rocket Man", EffectCategory.PLAYER) },
            { "misc_news_team", new EffectInfo("News Team", EffectCategory.MISC, true, true) },
            { "player_fling_player", new EffectInfo("Fling Player", EffectCategory.PLAYER) },
            { "misc_stuffguns", new EffectInfo("Improvised Weaponry", EffectCategory.MISC, true, true) },
            { "misc_random_waypoint", new EffectInfo("Random Waypoint", EffectCategory.MISC) },
            { "peds_eternal_screams", new EffectInfo("Eternal Screams", EffectCategory.PEDS, true, true) },
            { "player_blade_hunger", new EffectInfo("The Blade Hungers", EffectCategory.PLAYER, true) },
            { "spawn_angry_chimp", new EffectInfo("Spawn Angry Chimp", EffectCategory.PEDS, true) },
            { "misc_uturn", new EffectInfo("U-Turn", EffectCategory.MISC) },
            { "peds_spawn_quarreling_couple", new EffectInfo("Spawn Quarreling Couple", EffectCategory.PEDS) },
            { "misc_get_towed", new EffectInfo("Get Towed", EffectCategory.MISC) },
            { "peds_bloody", new EffectInfo("Everyone Is Bloody", EffectCategory.PEDS) },
            { "misc_weirdpitch", new EffectInfo("Weird Pitch", EffectCategory.MISC, true) },
            { "player_tp_stunt", new EffectInfo("Make Random Stunt Jump", EffectCategory.PLAYER) },
            { "misc_spinning_props", new EffectInfo("Spinning Props", EffectCategory.MISC, true) },
            { "player_grav_sphere", new EffectInfo("Gravity Sphere", EffectCategory.PLAYER, true, true) },
            { "player_sick_cam", new EffectInfo("I Feel Sick", EffectCategory.PLAYER, true, true) },
            { "misc_ghost_world", new EffectInfo("Ghost Town", EffectCategory.MISC, true) },
            { "peds_headless", new EffectInfo("Mannequins", EffectCategory.PEDS, true) },
            { "peds_2x_animation_speed", new EffectInfo("2x Animation Speed", EffectCategory.PEDS, true) },
            { "player_tp_to_everything", new EffectInfo("Teleporter Malfunction", EffectCategory.PLAYER, true, true) },
            { "player_laggy_camera", new EffectInfo("Delayed Camera", EffectCategory.PLAYER, true) },
            { "misc_clone_on_death", new EffectInfo("Resurrection Day", EffectCategory.MISC, true, true) },
            { "misc_sideways_gravity", new EffectInfo("Sideways Gravity", EffectCategory.MISC, true, true) },
            { "misc_jumpy_props", new EffectInfo("Jumpy Props", EffectCategory.MISC, true) },
            { "misc_boost_velocity", new EffectInfo("Speed Boost", EffectCategory.MISC) },
            { "peds_prop_hunt", new EffectInfo("Prop Hunt", EffectCategory.PEDS, true) },
            { "misc_remove_water", new EffectInfo("Drought", EffectCategory.MISC, true) },
            { "vehs_prop_models", new EffectInfo("Prop Cars", EffectCategory.VEHICLE, true) },
            { "vehs_tiny", new EffectInfo("Tiny Vehicles", EffectCategory.VEHICLE, true) },
            { "meta_re_invoke", new EffectInfo("Re-Invoke Previous Effects", EffectCategory.META) },
            { "misc_tnpanel", new EffectInfo("TN Panel", EffectCategory.MISC, true) },
            { "misc_fckautorotate", new EffectInfo("Goddamn Auto-Rotate", EffectCategory.MISC, true, true) },
            { "misc_warpedcam", new EffectInfo("Warped Camera", EffectCategory.MISC, true, true) },
            { "misc_dimwarp", new EffectInfo("Dimension Warp", EffectCategory.MISC, true, true) },
            { "misc_shatteredscreen", new EffectInfo("Shattered Screen", EffectCategory.MISC, true) },
            { "misc_localcoop", new EffectInfo("Split Screen Co-op", EffectCategory.MISC, true, true) },
            { "misc_invertedcolors", new EffectInfo("Inverted Colors", EffectCategory.MISC, true) },
            { "misc_fourthdimension", new EffectInfo("Fourth Dimension", EffectCategory.MISC, true, true) },
            { "misc_rgbland", new EffectInfo("RGB Land", EffectCategory.MISC, true) },
            { "player_esp", new EffectInfo("ESP", EffectCategory.PLAYER, true) },
        };
    }
}
