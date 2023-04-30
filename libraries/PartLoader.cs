using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CO_Driver
{
    public class PartLoader
    {
        public class Structure
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Faction { get; set; }
            public int Level { get; set; }
            public int HullDurability { get; set; }
            public int PartDurability { get; set; }
            public int Mass { get; set; }
            public int PowerScore { get; set; }
            public double PassThrough { get; set; }
            public double BulletResistance { get; set; }
            public double MeleeResistance { get; set; }
        }

        public class Weapon
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Rarity { get; set; }
            public string WeaponClass { get; set; }
        }

        public class Cabin
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Module
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string ModuleClass { get; set; }
        }

        public class Engine
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Explosive
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Movement
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
        }

        public class Reward
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string ShortDescription { get; set; }
        }

        public class EventTime
        {
            public int EventType { get; set; }
            public DayOfWeek Day { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
        }

        private class CK
        {
            public string CKName { get; set; }
            public string Name { get; set; }

        }


        public static Reward NewReward(string name, string desc, string shortDesc)
        {
            return new Reward
            {
                Name = name,
                Description = desc,
                ShortDescription = shortDesc
            };
        }



        public static Structure NewPart(string desc, int faction, int level, int hull, int partDura, int mass, int powerScore, double passThrough, double bulletResist, double meleeResist)
        {
            return new Structure
            {
                Description = desc,
                Faction = faction,
                Level = level,
                HullDurability = hull,
                PartDurability = partDura,
                Mass = mass,
                PowerScore = powerScore,
                PassThrough = passThrough,
                BulletResistance = bulletResist,
                MeleeResistance = meleeResist
            };
        }

        public static Cabin NewCabin()
        {
            return new Cabin
            {
                Name = "",
                Description = ""
            };
        }

        public static Engine NewEngine()
        {
            return new Engine
            {
                Name = "",
                Description = ""
            };
        }

        public static Explosive NewExpolosive(string name, string desc)
        {
            return new Explosive
            {
                Name = name,
                Description = desc
            };
        }

        public static Movement NewMovement()
        {
            return new Movement
            {
                Name = "",
                Description = "",
                Type = ""
            };
        }

        public static EventTime NewEvent(int type, DayOfWeek day, TimeSpan start, TimeSpan end)
        {
            return new EventTime
            {
                EventType = type,
                Day = day,
                StartTime = start,
                EndTime = end
            };
        }

        public static void LoadParts(FileTraceManagment.SessionStats currentSession)
        {
            PartLoader.PopulateGlobalPartsList(currentSession);
            PartLoader.PopulateWeaponList(currentSession);
            PartLoader.PopulateModuleList(currentSession);
            PartLoader.PopulateCabinList(currentSession);
            PartLoader.PopulateEngineList(currentSession);
            PartLoader.PopulateExplosiveList(currentSession);
            PartLoader.PopulateMovementList(currentSession);
            PartLoader.LoadEventSchedule(currentSession);
            PartLoader.LoadMapDictionary(currentSession);
            PartLoader.LoadResourceDictionary(currentSession);
            PartLoader.LoadCKDictionary(currentSession);
        }

        public static void LoadMapDictionary(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.MapDict.Add("bridge", "Bridge");
            currentSession.StaticRecords.MapDict.Add("sand_valley", "Desert valley");
            currentSession.StaticRecords.MapDict.Add("downtown", "East quarter");
            currentSession.StaticRecords.MapDict.Add("factory", "Factory");
            currentSession.StaticRecords.MapDict.Add("rockcity_2bases", "Founders Canyon");
            currentSession.StaticRecords.MapDict.Add("tower", "Nameless tower");
            currentSession.StaticRecords.MapDict.Add("geopp", "Naukograd");
            currentSession.StaticRecords.MapDict.Add("powerplant", "Powerplant");
            currentSession.StaticRecords.MapDict.Add("abandoned_ship", "Sandy gulf");
            currentSession.StaticRecords.MapDict.Add("iron_way_center", @"""Control-17""station");
            currentSession.StaticRecords.MapDict.Add("chemical_plant", "Chemical plant");
            currentSession.StaticRecords.MapDict.Add("holes", "Ravagers foothold");
            currentSession.StaticRecords.MapDict.Add("rockcity", "Rock City");
            currentSession.StaticRecords.MapDict.Add("conflagration", "Ashen ring");
            currentSession.StaticRecords.MapDict.Add("arizona_silo", "Broken arrow");
            currentSession.StaticRecords.MapDict.Add("island", "Clean island");
            currentSession.StaticRecords.MapDict.Add("sand_crater", "Crater");
            currentSession.StaticRecords.MapDict.Add("building_yard", "Sector EX");
            currentSession.StaticRecords.MapDict.Add("building_yard2", "Sector EX night");
            currentSession.StaticRecords.MapDict.Add("building_yard3", "Sector EX");
            currentSession.StaticRecords.MapDict.Add("building_yard_newyear", "Winter Sector EX");
            currentSession.StaticRecords.MapDict.Add("building_yard_halloween", "Sector EX");
            currentSession.StaticRecords.MapDict.Add("red_rocks_battle_royale", "Blood Rocks");
            currentSession.StaticRecords.MapDict.Add("red_rocks_territory", "Blood Rocks");
            currentSession.StaticRecords.MapDict.Add("arizona_castle", "Wrath of Khan");
            currentSession.StaticRecords.MapDict.Add("big_plato_race", "Rocky track");
            currentSession.StaticRecords.MapDict.Add("smallmap_race", "Industrial track");
            currentSession.StaticRecords.MapDict.Add("miners_way", "Cursed mines");
            currentSession.StaticRecords.MapDict.Add("cemetery_highway", "Dead Highway");
            currentSession.StaticRecords.MapDict.Add("iron_way", "Eastern Array");
            currentSession.StaticRecords.MapDict.Add("lost_coast", "Lost coast");
            currentSession.StaticRecords.MapDict.Add("port", "Terminal-45");
            currentSession.StaticRecords.MapDict.Add("port_newyear", "Terminal-45");
            currentSession.StaticRecords.MapDict.Add("shipyard_battle", "River lighthouse");
            currentSession.StaticRecords.MapDict.Add("fieldbattle", "Tank range");
            currentSession.StaticRecords.MapDict.Add("sinto", "Sinto City");
            currentSession.StaticRecords.MapDict.Add("mountain_serpantin", "Serpentine");
            currentSession.StaticRecords.MapDict.Add("castle", "Fortress");
            currentSession.StaticRecords.MapDict.Add("cemetery_highway_newyear", "Winter Highway");
            currentSession.StaticRecords.MapDict.Add("experimental_map", "Test map");
            currentSession.StaticRecords.MapDict.Add("frenzied_track", "Two Turrets");
            currentSession.StaticRecords.MapDict.Add("pve_canyons", "Death canyon");
            currentSession.StaticRecords.MapDict.Add("refinery", "Refinery");
            currentSession.StaticRecords.MapDict.Add("refinery_newyear", "Refinery");
            currentSession.StaticRecords.MapDict.Add("riverport", "Ship graveyard");
            currentSession.StaticRecords.MapDict.Add("newyear_foray", "Mountain village");
            currentSession.StaticRecords.MapDict.Add("vulkan", "Volcano");
            currentSession.StaticRecords.MapDict.Add("quarry", "Marble Quarry");
            currentSession.StaticRecords.MapDict.Add("customgame_race", "Toxic Track");
            currentSession.StaticRecords.MapDict.Add("customgame_craterarena", "Oasis");
            currentSession.StaticRecords.MapDict.Add("customgame_fiery_river", "Deadly Crossing");
            currentSession.StaticRecords.MapDict.Add("customgame_mountain_lake", "Mountain Lake");
            currentSession.StaticRecords.MapDict.Add("sulfur", "Peaceful Atom");
            currentSession.StaticRecords.MapDict.Add("drcross", "Abandoned Town");
        }

        public static void LoadResourceDictionary(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.ResourceDict.Add("expFactionTotal", "Faction XP");
            currentSession.StaticRecords.ResourceDict.Add("expBaseFactionTotal", "Engineer XP");
            currentSession.StaticRecords.ResourceDict.Add("Scrap_Common", "Scrap");
            currentSession.StaticRecords.ResourceDict.Add("ClanMoney", "Uranium");
            currentSession.StaticRecords.ResourceDict.Add("Platinum", "Copper");
            currentSession.StaticRecords.ResourceDict.Add("Supply", "Coupons");
            currentSession.StaticRecords.ResourceDict.Add("Scrap_Rare", "Wires");
            currentSession.StaticRecords.ResourceDict.Add("Accumulators", "Batteries");
            currentSession.StaticRecords.ResourceDict.Add("NewYearMoney", "Crackers");
            currentSession.StaticRecords.ResourceDict.Add("Scrap_Epic", "Electronics");
            currentSession.StaticRecords.ResourceDict.Add("Plastic", "Plastic");
            currentSession.StaticRecords.ResourceDict.Add("GermanMoney", "Taler");
            currentSession.StaticRecords.ResourceDict.Add("Glory", "Intelligence");
        }


        public static void LoadEventSchedule(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.STANDARD_CW, DayOfWeek.Monday, new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.STANDARD_CW, DayOfWeek.Tuesday, new TimeSpan(17, 0, 0), new TimeSpan(21, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.LEVIATHIAN_CW, DayOfWeek.Wednesday, new TimeSpan(0, 0, 0), new TimeSpan(4, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.LEVIATHIAN_CW, DayOfWeek.Thursday, new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.LEVIATHIAN_CW, DayOfWeek.Thursday, new TimeSpan(17, 0, 0), new TimeSpan(21, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.STANDARD_CW, DayOfWeek.Friday, new TimeSpan(0, 0, 0), new TimeSpan(4, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.STANDARD_CW, DayOfWeek.Saturday, new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.STANDARD_CW, DayOfWeek.Saturday, new TimeSpan(17, 0, 0), new TimeSpan(21, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.STANDARD_CW, DayOfWeek.Sunday, new TimeSpan(0, 0, 0), new TimeSpan(4, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.STANDARD_CW, DayOfWeek.Sunday, new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0)));

            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.BIG_BLACK_SCORPION, DayOfWeek.Monday, new TimeSpan(0, 0, 0), new TimeSpan(8, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.CANNON_FODDER, DayOfWeek.Monday, new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.BIG_BLACK_SCORPION, DayOfWeek.Monday, new TimeSpan(16, 0, 0), new TimeSpan(24, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.HEAD_ON, DayOfWeek.Tuesday, new TimeSpan(0, 0, 0), new TimeSpan(8, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.HOVER_RACE, DayOfWeek.Tuesday, new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.CANNON_FODDER, DayOfWeek.Tuesday, new TimeSpan(16, 0, 0), new TimeSpan(24, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.WHEEL_RACE, DayOfWeek.Wednesday, new TimeSpan(0, 0, 0), new TimeSpan(8, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.HEAD_ON, DayOfWeek.Wednesday, new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.HOVER_RACE, DayOfWeek.Wednesday, new TimeSpan(16, 0, 0), new TimeSpan(24, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.CANNON_FODDER, DayOfWeek.Thursday, new TimeSpan(0, 0, 0), new TimeSpan(8, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.WHEEL_RACE, DayOfWeek.Thursday, new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.HEAD_ON, DayOfWeek.Thursday, new TimeSpan(16, 0, 0), new TimeSpan(24, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.HOVER_RACE, DayOfWeek.Friday, new TimeSpan(0, 0, 0), new TimeSpan(8, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.BIG_BLACK_SCORPION, DayOfWeek.Friday, new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.WHEEL_RACE, DayOfWeek.Friday, new TimeSpan(16, 0, 0), new TimeSpan(24, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.BATTLE_ROYALE, DayOfWeek.Saturday, new TimeSpan(0, 0, 0), new TimeSpan(24, 0, 0)));
            currentSession.StaticRecords.GlobalEventTimes.Add(NewEvent(GlobalData.BATTLE_ROYALE, DayOfWeek.Sunday, new TimeSpan(0, 0, 0), new TimeSpan(24, 0, 0)));
        }

        public static void LoadCKDictionary(FileTraceManagment.SessionStats currentSession)
        {
            List<CK> cks = JsonConvert.DeserializeObject<List<CK>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.cks));

            foreach (CK ck in cks)
            {
                currentSession.StaticRecords.CKDict.Add(ck.CKName, ck.Name);
            }
        }

        public static void PopulateMovementList(FileTraceManagment.SessionStats currentSession)
        {
            List<Movement> movements = JsonConvert.DeserializeObject<List<Movement>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.movements));

            foreach (Movement movement in movements)
            {
                currentSession.StaticRecords.GlobalMovementDict.Add(movement.Name, new Movement { Name = movement.Name, Description = movement.Description, Type = movement.Type });
            }
        }

        public static void PopulateExplosiveList(FileTraceManagment.SessionStats currentSession)
        {
            List<Explosive> explosives = JsonConvert.DeserializeObject<List<Explosive>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.explosives));

            foreach (Explosive explosive in explosives)
            {
                currentSession.StaticRecords.GlobalExplosivesDict.Add(explosive.Name, new Explosive { Name = explosive.Name, Description = explosive.Description});
            }
        }

        public static void PopulateEngineList(FileTraceManagment.SessionStats currentSession)
        {
            List<Engine> engines = JsonConvert.DeserializeObject<List<Engine>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.engines));

            foreach (Engine engine in engines)
            {
                currentSession.StaticRecords.GlobalEngineDict.Add(engine.Name, new Engine { Name = engine.Name, Description = engine.Description });
            }
        }

        public static void PopulateModuleList(FileTraceManagment.SessionStats currentSession)
        {
            List<Module> modules = JsonConvert.DeserializeObject<List<Module>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.modules));

            foreach (Module module in modules)
            {
                currentSession.StaticRecords.GlobalModuleDict.Add(module.Name, new Module { Name = module.Name, Description = module.Description, ModuleClass = module.ModuleClass });
            }
        }

        public static void PopulateCabinList(FileTraceManagment.SessionStats currentSession)
        {
            List<Cabin> cabins = JsonConvert.DeserializeObject<List<Cabin>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.cabins));

            foreach (Cabin cabin in cabins)
            {
                currentSession.StaticRecords.GlobalCabinDict.Add(cabin.Name, new Cabin { Name = cabin.Name, Description = cabin.Description });
            }
        }

        public static void PopulateWeaponList(FileTraceManagment.SessionStats currentSession)
        {
            List<Weapon> weapons = JsonConvert.DeserializeObject<List<Weapon>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.weapons));

            foreach (Weapon weapon in weapons)
            {
                currentSession.StaticRecords.GlobalWeaponDict.Add(weapon.Name, new Weapon { Name = weapon.Name, Description = weapon.Description, Rarity = weapon.Rarity, WeaponClass = weapon.WeaponClass });
            }
        }

        public static void PopulateGlobalPartsList(FileTraceManagment.SessionStats currentSession)
        {
            List<Structure> structures = JsonConvert.DeserializeObject<List<Structure>>(System.Text.Encoding.Default.GetString(CO_Driver.Properties.Resources.structures));

            foreach (Structure structure in structures)
            {
                currentSession.StaticRecords.GlobalPartsList.Add(new Structure { 
                    Name = structure.Name,
                    Description = structure.Description,
                    Faction = structure.Faction,
                    Level = structure.Level,
                    HullDurability = structure.HullDurability,
                    PartDurability = structure.PartDurability,
                    Mass = structure.Mass,
                    PowerScore = structure.PowerScore,
                    PassThrough = structure.PassThrough,
                    BulletResistance = structure.BulletResistance,
                    MeleeResistance = structure.MeleeResistance
                });
            }
        }


    }
}

