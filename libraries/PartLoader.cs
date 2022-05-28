using System;

namespace CO_Driver
{
    public class PartLoader
    {
        public class Part
        {
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
            public int Energy { get; set; }
            public double BaseDamage { get; set; }
            public int Mass { get; set; }
            public int Durability { get; set; }
            public int PowerScore { get; set; }
            public string WeaponClass { get; set; }
        }

        public class Cabin
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Rarity { get; set; }
            public int Energy { get; set; }
            public int BaseSpeed { get; set; }
            public int MassLimit { get; set; }
            public int Tonnage { get; set; }
            public int Mass { get; set; }
            public int Durability { get; set; }
            public int PowerScore { get; set; }
            public string CabinClass { get; set; }
        }

        public class Module
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Rarity { get; set; }
            public int Energy { get; set; }
            public int Mass { get; set; }
            public int Durability { get; set; }
            public int PowerScore { get; set; }
            public string ModuleClass { get; set; }
        }

        public class Engine
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Rarity { get; set; }
            public int Energy { get; set; }
            public int Durability { get; set; }
            public int Mass { get; set; }
            public int PowerScore { get; set; }
            public int Tonnage { get; set; }
            public int MassLimit { get; set; }
            public double SpeedBonus { get; set; }
            public double PowerBonus { get; set; }
        }

        public class Explosive
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Rarity { get; set; }
            public int Energy { get; set; }
            public int Durability { get; set; }
            public int Mass { get; set; }
            public int PowerScore { get; set; }
            public double BlastDamage { get; set; }
            public string ExplosiveClass { get; set; }
        }

        public class Movement
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Rarity { get; set; }
            public int Energy { get; set; }
            public int Durability { get; set; }
            public int Mass { get; set; }
            public int PowerScore { get; set; }
            public int MaxSpeed { get; set; }
            public int Tonnage { get; set; }
            public double PowerLoss { get; set; }
            public double MeleeResistance { get; set; }
            public double BulletResistance { get; set; }
            public double FireResistance { get; set; }
            public double ExplosiveResistance { get; set; }
            public double PassThrough { get; set; }
            public string Category { get; set; }
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


        public static Reward NewReward(string name, string desc, string shortDesc)
        {
            return new Reward
            {
                Name = name,
                Description = desc,
                ShortDescription = shortDesc
            };
        }



        public static Part NewPart(string desc, int faction, int level, int hull, int partDura, int mass, int powerScore, double passThrough, double bulletResist, double meleeResist)
        {
            return new Part
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
        public static Part NewPart()
        {
            return new Part
            {
                Description = "",
                Faction = 0,
                Level = 0,
                HullDurability = 0,
                PartDurability = 0,
                Mass = 0,
                PowerScore = 0,
                PassThrough = 0.0,
                BulletResistance = 0.0,
                MeleeResistance = 0.0
            };
        }

        public static Weapon NewWeapon(string name, string desc, int rarity, int energy, double baseDamage, int mass, int dura, int ps, string weaponClass)
        {
            return new Weapon
            {
                Name = name,
                Description = desc,
                Rarity = rarity,
                Energy = energy,
                BaseDamage = baseDamage,
                Mass = mass,
                Durability = dura,
                PowerScore = ps,
                WeaponClass = weaponClass
            };
        }

        public static Weapon NewWeapon()
        {
            return new Weapon
            {
                Name = "",
                Description = "",
                Rarity = 0,
                Energy = 0,
                BaseDamage = 0,
                Mass = 0,
                Durability = 0,
                PowerScore = 0,
                WeaponClass = ""
            };
        }

        public static Cabin NewCabin(string name, string desc, int rarity, int energy, int speed, int mass_lim, int tonnage, int mass, int dura, int ps, string cabinClass)
        {
            return new Cabin
            {
                Name = name,
                Description = desc,
                Rarity = rarity,
                Energy = energy,
                BaseSpeed = speed,
                MassLimit = mass_lim,
                Tonnage = tonnage,
                Mass = mass,
                Durability = dura,
                PowerScore = ps,
                CabinClass = cabinClass
            };
        }

        public static Cabin NewCabin()
        {
            return new Cabin
            {
                Name = "",
                Description = "",
                Rarity = 0,
                Energy = 0,
                BaseSpeed = 0,
                MassLimit = 0,
                Tonnage = 0,
                Mass = 0,
                Durability = 0,
                PowerScore = 0,
                CabinClass = ""
            };
        }

        public static Module NewModule(string name, string desc, int rarity, int energy, int dura, int mass, int ps, string moduleClass)
        {
            return new Module
            {
                Name = name,
                Description = desc,
                Rarity = rarity,
                Energy = energy,
                Durability = dura,
                Mass = mass,
                PowerScore = ps,
                ModuleClass = moduleClass
            };
        }

        public static Module NewModule()
        {
            return new Module
            {
                Name = "",
                Description = "",
                Rarity = 0,
                Energy = 0,
                Durability = 0,
                Mass = 0,
                PowerScore = 0,
                ModuleClass = ""
            };
        }
        public static Engine NewEngine(string name, string desc, int rarity, int energy, int dura, int mass, int ps, int tonnage, int massLimit, double speed, double power)
        {
            return new Engine
            {
                Name = name,
                Description = desc,
                Rarity = rarity,
                Energy = energy,
                Durability = dura,
                Mass = mass,
                PowerScore = ps,
                Tonnage = tonnage,
                MassLimit = massLimit,
                SpeedBonus = speed,
                PowerBonus = power
            };
        }

        public static Engine NewEngine()
        {
            return new Engine
            {
                Name = "",
                Description = "",
                Rarity = 0,
                Energy = 0,
                Durability = 0,
                Mass = 0,
                PowerScore = 0,
                Tonnage = 0,
                MassLimit = 0,
                SpeedBonus = 0.0,
                PowerBonus = 0.0
            };
        }

        public static Explosive NewExpolosive(string name, string desc, int rarity, int energy, int dura, int mass, int ps, double blast, string explosiveClass)
        {
            return new Explosive
            {
                Name = name,
                Description = desc,
                Rarity = rarity,
                Energy = energy,
                Durability = dura,
                Mass = mass,
                PowerScore = ps,
                BlastDamage = blast,
                ExplosiveClass = explosiveClass
            };
        }

        public static Explosive NewExplosive()
        {
            return new Explosive
            {
                Name = "",
                Description = "",
                Rarity = 0,
                Energy = 0,
                Durability = 0,
                Mass = 0,
                PowerScore = 0,
                BlastDamage = 0,
                ExplosiveClass = ""
            };
        }

        public static Movement NewMovement(string name, string desc, int rarity, int ps, int maxSpeed, int tonnage, double powerLoss, int dura, int mass,
                                            double meleeResist, double bulletResist, double fireResist, double explosiveResist, double passThrough, string category)
        {
            return new Movement
            {
                Name = name,
                Description = desc,
                Rarity = rarity,
                Durability = dura,
                Mass = mass,
                PowerScore = ps,
                MaxSpeed = maxSpeed,
                Tonnage = tonnage,
                PowerLoss = powerLoss,
                MeleeResistance = meleeResist,
                BulletResistance = bulletResist,
                FireResistance = fireResist,
                ExplosiveResistance = explosiveResist,
                PassThrough = passThrough,
                Category = category
            };
        }

        public static Movement NewMovement()
        {
            return new Movement
            {
                Name = "",
                Description = "",
                Rarity = 0,
                Durability = 0,
                Mass = 0,
                PowerScore = 0,
                MaxSpeed = 0,
                Tonnage = 0,
                PowerLoss = 0,
                MeleeResistance = 0,
                BulletResistance = 0,
                FireResistance = 0,
                ExplosiveResistance = 0,
                PassThrough = 0,
                Category = ""
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

        public static void LoadCKDictionary(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_C1_Raider", "CarPart_Gun_Machinegun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_C1_China", "CarPart_Gun_Machinegun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_Frontal_C1_China", "CarPart_Gun_Machinegun_Frontal");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_Frontal_C1_Raider", "CarPart_Gun_Machinegun_Frontal");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_rare_C1_China", "CarPart_Gun_Machinegun_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_SmartMachinegun_C2_China", "CarPart_Gun_SmartMachinegun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_epic_C2_China", "CarPart_Gun_Machinegun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_epic_C1_Raider", "CarPart_Gun_Machinegun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_epic_C1_China", "CarPart_Gun_Machinegun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Minigun_C1_China", "CarPart_Gun_Minigun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Minigun_C1_Raider", "CarPart_Gun_Minigun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_CannonMinigun_legend_C1_China", "CarPart_Gun_CannonMinigun_legend");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Shotgun_rare_C1_China", "CarPart_Gun_Shotgun_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Shotgun_epic_C1_Raider", "CarPart_Gun_Shotgun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Shotgun_legend_C2_China", "CarPart_Gun_Shotgun_legend");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Cannon_rare_C1_China", "CarPart_Gun_Cannon_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Cannon_epic_C1_China", "CarPart_Gun_Cannon_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_EX_C1_China", "CarPart_Gun_BigCannon_EX");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_EX_rare_C1_Raider", "CarPart_Gun_BigCannon_EX_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_EX_rare_C1_China", "CarPart_Gun_BigCannon_EX_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_Free_rare_C1_China", "CarPart_Gun_BigCannon_Free_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_Free_rare_C1_Raider", "CarPart_Gun_BigCannon_Free_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_EX_epic_C2_China", "CarPart_Gun_BigCannon_EX_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_EX_epic_C1_China", "CarPart_Gun_BigCannon_EX_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_Free_epic_C1_China", "CarPart_Gun_BigCannon_Free_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_Free_legend_C1_China", "CarPart_Gun_BigCannon_Free_legend");
            currentSession.StaticRecords.CKDict.Add("CarPart_AutoGuidedCourseGun_rare_C1_Raider", "CarPart_AutoGuidedCourseGun_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_AutoGuidedCourseGun_rare_C1_China", "CarPart_AutoGuidedCourseGun_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_AutoGuidedCourseGun_rare_C2_China", "CarPart_AutoGuidedCourseGun_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_GuidedMissile_Sniper_C2_China", "CarPart_Gun_GuidedMissile_Sniper");
            currentSession.StaticRecords.CKDict.Add("CarPart_AutoGuidedCourseGun_epic_C1_China", "CarPart_AutoGuidedCourseGun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_AutoGuidedCourseGun_epic_C1_Raider", "CarPart_AutoGuidedCourseGun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_AutoGuidedCourseGun_epic_C2_China", "CarPart_AutoGuidedCourseGun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_HomingMissileLauncher_epic_C1_Raider", "CarPart_HomingMissileLauncher_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_HomingMissileLauncherBurstR_legend_C2_China", "CarPart_HomingMissileLauncherBurstR_legend");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_GrenadeLauncher_Auto_C1_China", "CarPart_Gun_GrenadeLauncher_Auto");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_GrenadeLauncher_Shotgun_C2_China", "CarPart_Gun_GrenadeLauncher_Shotgun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_SniperCrossbow_C2_China", "CarPart_Gun_SniperCrossbow");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_SniperCrossbow_C2_SNG", "CarPart_Gun_SniperCrossbow");
            currentSession.StaticRecords.CKDict.Add("CarPart_Drill_epic_C1_China", "CarPart_Drill_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Drill_epic_C1_Raider", "CarPart_Drill_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Drill_epic_C2_China", "CarPart_Drill_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_SpearExplosive_C1_China", "CarPart_SpearExplosive");
            currentSession.StaticRecords.CKDict.Add("CarPart_Roundsaw_rare_C1_China", "CarPart_Roundsaw_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_LanceExplosive_C1_China", "CarPart_LanceExplosive");
            currentSession.StaticRecords.CKDict.Add("CarPart_LanceExplosive_C2_China", "CarPart_LanceExplosive");
            currentSession.StaticRecords.CKDict.Add("CarPart_ChainSaw_epic_C1_China", "CarPart_ChainSaw_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_ChainSaw_epic_C1_Raider", "CarPart_ChainSaw_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Harvester_legend_C1_China", "CarPart_Harvester_legend");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Flamethrower_frontal_C1_Raider", "CarPart_Gun_Flamethrower_frontal");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Flamethrower_light_C1_China", "CarPart_Gun_Flamethrower_light");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Mortar_Revert_C2_China", "CarPart_Gun_Mortar_Revert");
            currentSession.StaticRecords.CKDict.Add("CarPart_Booster_rare_C1_Raider", "CarPart_Booster_rare");
            currentSession.StaticRecords.CKDict.Add("Chassis_Basic_C1_Raider", "Chassis_Basic");
            currentSession.StaticRecords.CKDict.Add("Cabin_Tribal_C1_Raider", "Cabin_Tribal");
            currentSession.StaticRecords.CKDict.Add("Chassis_Wyvern_C1_Raider", "Chassis_Wyvern");
            currentSession.StaticRecords.CKDict.Add("Cabin_Moonwalker_C1_Raider", "Cabin_Moonwalker");
            currentSession.StaticRecords.CKDict.Add("Chassis_Gazelle_C2_Raider", "Chassis_Gazelle");
            currentSession.StaticRecords.CKDict.Add("Chassis_Kamaz_C1_Raider", "Chassis_Kamaz");
            currentSession.StaticRecords.CKDict.Add("Chassis_Military_C1_Raider", "Chassis_Military");
            currentSession.StaticRecords.CKDict.Add("Chassis_Maz_C1_Bundle", "Chassis_Maz");
            currentSession.StaticRecords.CKDict.Add("Chassis_Maz_bp8", "Chassis_Maz");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelSmallChains_C1_Raider", "CarPart_WheelSmallChains");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelSmallChains_S_C1_Raider", "CarPart_WheelSmallChains_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelSmallSpiked_C1_Raider", "CarPart_WheelSmallSpiked");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelSmallSpiked_S_C1_Raider", "CarPart_WheelSmallSpiked_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_Moonwalker_German", "CarPart_Wheel_Moonwalker");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_Moonwalker_S_German", "CarPart_Wheel_Moonwalker_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelMed_R_rare_C2_Raider", "CarPart_WheelMed_R_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelMed_RS_rare_C2_Raider", "CarPart_WheelMed_RS_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_AviaSmall_C1_Raider", "CarPart_Wheel_AviaSmall");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_AviaSmall_S_C1_Raider", "CarPart_Wheel_AviaSmall_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_Drag_C1_Raider", "CarPart_Wheel_Drag");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_Drag_S_C1_Raider", "CarPart_Wheel_Drag_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_Drag_C2_Raider", "CarPart_Wheel_Drag");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_Drag_S_C2_Raider", "CarPart_Wheel_Drag_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_SawWheel_C1_Raider", "CarPart_Wheel_SawWheel");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_SawWheel_S_C1_Raider", "CarPart_Wheel_SawWheel_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelMilitary_C1_Raider", "CarPart_WheelMilitary");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelMilitary_S_C1_Raider", "CarPart_WheelMilitary_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelMilitary_C2_Raider", "CarPart_WheelMilitary");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelMilitary_S_C2_Raider", "CarPart_WheelMilitary_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelDouble_R_epic_C1_Raider", "CarPart_WheelDouble_R_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_WheelDouble_RS_epic_C1_Raider", "CarPart_WheelDouble_RS_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_MonsterTruck_C1_Raider", "CarPart_Wheel_MonsterTruck");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_MonsterTruck_S_C1_Raider", "CarPart_Wheel_MonsterTruck_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_MonsterTruck_C2_Raider", "CarPart_Wheel_MonsterTruck");
            currentSession.StaticRecords.CKDict.Add("CarPart_Wheel_MonsterTruck_S_C2_Raider", "CarPart_Wheel_MonsterTruck_S");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_Free_T34_epic_Misc", "CarPart_Gun_BigCannon_Free_T34_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_SMG_bp8", "CarPart_Gun_SMG");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_SmartMachinegun_bp7", "CarPart_Gun_SmartMachinegun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Syfy_FusionRifle_legend_bp7", "CarPart_Gun_Syfy_FusionRifle_legend");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Shotgun_Preepic_bp6", "CarPart_Gun_Shotgun_Preepic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Minigun_Legend_bp6", "CarPart_Gun_Minigun_Legend");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_BigCannon_Free_rare_C2_China", "CarPart_Gun_BigCannon_Free_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Cannon_epic_C2_China", "CarPart_Gun_Cannon_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Cannon_rare_C1_Raider", "CarPart_Gun_Cannon_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_GrenadeLauncher_Auto_C2_China", "CarPart_Gun_GrenadeLauncher_Auto");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_Frontal_C2_China", "CarPart_Gun_Machinegun_Frontal");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Machinegun_rare_C2_China", "CarPart_Gun_Machinegun_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Minigun_C2_China", "CarPart_Gun_Minigun");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Shotgun_epic_C2_China", "CarPart_Gun_Shotgun_epic");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Shotgun_Frontal_C2_China", "CarPart_Gun_Shotgun_Frontal");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_Shotgun_rare_C2_China", "CarPart_Gun_Shotgun_rare");
            currentSession.StaticRecords.CKDict.Add("CarPart_Gun_SniperCrossbow_C2_China_Douyu", "CarPart_Gun_SniperCrossbow");
            currentSession.StaticRecords.CKDict.Add("CarPart_HomingMissileLauncher_epic_C2_China", "CarPart_HomingMissileLauncher");
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
        }

        public static void LoadResourceDictionary(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.ResourceDict.Add("expFactionTotal", "Fation XP");
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

        public static void PopulateRewardList(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalRewardDict.Add("expFactionTotal", NewReward("expFactionTotal", "Total Exp", "Tot Exp"));
            currentSession.StaticRecords.GlobalRewardDict.Add("expBaseFactionTotal", NewReward("expBaseFactionTotal", "Faction Exp", "Fac Exp"));
            currentSession.StaticRecords.GlobalRewardDict.Add("ClanMoney", NewReward("ClanMoney", "Uranium", "U"));
            currentSession.StaticRecords.GlobalRewardDict.Add("Scrap_Common", NewReward("Scrap_Common", "Scrap", "S"));
            currentSession.StaticRecords.GlobalRewardDict.Add("Scrap_Rare", NewReward("Scrap_Rare", "Wires", "W"));
            currentSession.StaticRecords.GlobalRewardDict.Add("Scrap_Epic", NewReward("Scrap_Epic", "Electronics", "B"));
            currentSession.StaticRecords.GlobalRewardDict.Add("Plastic", NewReward("Plastic", "Plastic", "P"));
            currentSession.StaticRecords.GlobalRewardDict.Add("Accumulators", NewReward("Accumulators", "unknown", "unknown"));
            currentSession.StaticRecords.GlobalRewardDict.Add("HalloweenMoney", NewReward("HalloweenMoney", "Tricky Treats", "TT"));
            currentSession.StaticRecords.GlobalRewardDict.Add("Supply", NewReward("Supply", "unknown", "unknown"));
            currentSession.StaticRecords.GlobalRewardDict.Add("Platinum", NewReward("Platinum", "unknown", "unknown"));
            currentSession.StaticRecords.GlobalRewardDict.Add("NewYearMoney", NewReward("NewYearMoney", "Crackers", "Cr"));
            currentSession.StaticRecords.GlobalRewardDict.Add("GermanMoney", NewReward("GermanMoney", "Taler", "T"));
        }

        public static void PopulateMovementList(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmall_Starter", NewMovement("CarPart_WheelSmall_Starter", "Starter wheel", 40, GlobalData.BASE_RARITY, 0, 570, 0.09, 50, 70, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmall_S_Starter", NewMovement("CarPart_WheelSmall_S_Starter", "Starter wheel ST", 40, GlobalData.BASE_RARITY, 0, 320, 0.17, 50, 70, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmall_R", NewMovement("CarPart_WheelSmall_R", "Small wheel", 40, GlobalData.COMMON_RARITY, 0, 380, 0.06, 65, 40, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmall_RS", NewMovement("CarPart_WheelSmall_RS", "Small wheel ST", 40, GlobalData.COMMON_RARITY, 0, 210, 0.12, 65, 40, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmallChains", NewMovement("CarPart_WheelSmallChains", "Chained wheel", 90, GlobalData.RARE_RARITY, 0, 540, 0.06, 115, 50, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmallChains_S", NewMovement("CarPart_WheelSmallChains_S", "Chained wheel ST", 90, GlobalData.RARE_RARITY, 0, 300, 0.12, 115, 50, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmallSpiked", NewMovement("CarPart_WheelSmallSpiked", "Studded wheel", 60, GlobalData.RARE_RARITY, 0, 390, 0.05, 100, 40, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelSmallSpiked_S", NewMovement("CarPart_WheelSmallSpiked_S", "Studded wheel ST", 60, GlobalData.RARE_RARITY, 0, 215, 0.1, 100, 40, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Moonwalker", NewMovement("CarPart_Wheel_Moonwalker", "Lunar IV", 100, GlobalData.SPECIAL_RARITY, 0, 540, 0.05, 125, 50, 0, 0, 0, 0, 0.5, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Moonwalker_S", NewMovement("CarPart_Wheel_Moonwalker_S", "Lunar IV ST", 100, GlobalData.SPECIAL_RARITY, 0, 300, 0.1, 125, 50, 0, 0, 0, 0, 0.5, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelMed_R_rare", NewMovement("CarPart_WheelMed_R_rare", "Medium wheel", 40, GlobalData.COMMON_RARITY, 0, 750, 0.08, 110, 140, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelMed_RS_rare", NewMovement("CarPart_WheelMed_RS_rare", "Medium wheel ST", 40, GlobalData.COMMON_RARITY, 0, 415, 0.15, 110, 140, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Baloon", NewMovement("CarPart_Wheel_Baloon", "Balloon tyre", 60, GlobalData.RARE_RARITY, 0, 900, 0.06, 140, 100, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Baloon_S", NewMovement("CarPart_Wheel_Baloon_S", "Balloon tyre ST", 60, GlobalData.RARE_RARITY, 0, 500, 0.12, 140, 100, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Medieval", NewMovement("CarPart_Wheel_Medieval", "Gun-mount wheel", 90, GlobalData.RARE_RARITY, 0, 750, 0.08, 132, 85, 0, 0, 0, 0, 0.5, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Medieval_S", NewMovement("CarPart_Wheel_Medieval_S", "Gun-mount wheel ST", 90, GlobalData.RARE_RARITY, 0, 415, 0.15, 132, 85, 0, 0, 0, 0, 0.5, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_AviaSmall", NewMovement("CarPart_Wheel_AviaSmall", "Landing gear", 60, GlobalData.RARE_RARITY, 0, 640, 0.05, 110, 70, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_AviaSmall_S", NewMovement("CarPart_Wheel_AviaSmall_S", "Landing gear ST", 60, GlobalData.RARE_RARITY, 0, 355, 0.1, 110, 70, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Drag", NewMovement("CarPart_Wheel_Drag", "Racing wheel", 75, GlobalData.RARE_RARITY, 0, 1050, 0.08, 160, 145, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Drag_S", NewMovement("CarPart_Wheel_Drag_S", "Racing wheel ST", 75, GlobalData.RARE_RARITY, 0, 585, 0.15, 160, 145, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Hopping", NewMovement("CarPart_Wheel_Hopping", "Stallion", 80, GlobalData.RARE_RARITY, 0, 820, 0.08, 140, 90, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Hopping_S", NewMovement("CarPart_Wheel_Hopping_S", "Stallion ST", 80, GlobalData.RARE_RARITY, 0, 455, 0.15, 140, 90, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Work", NewMovement("CarPart_Wheel_Work", "Array", 90, GlobalData.SPECIAL_RARITY, 0, 1260, 0.08, 200, 175, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Work_S", NewMovement("CarPart_Wheel_Work_S", "Array ST", 90, GlobalData.SPECIAL_RARITY, 0, 700, 0.15, 200, 175, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Stance", NewMovement("CarPart_Wheel_Stance", "Camber", 90, GlobalData.SPECIAL_RARITY, 0, 1260, 0.08, 200, 175, 0, 0, 0, 0, 0, "heavy wheel")); /* incomplete */
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Stance_S", NewMovement("CarPart_Wheel_Stance_S", "Camber ST", 90, GlobalData.SPECIAL_RARITY, 0, 1260, 0.08, 200, 175, 0, 0, 0, 0, 0, "heavy wheel")); /* incomplete */
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_SawWheel", NewMovement("CarPart_Wheel_SawWheel", "Shiv", 113, GlobalData.SPECIAL_RARITY, 0, 1125, 0.06, 180, 125, 0.5, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_SawWheel_S", NewMovement("CarPart_Wheel_SawWheel_S", "Shiv ST", 113, GlobalData.SPECIAL_RARITY, 0, 625, 0.12, 180, 125, 0.5, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelMedium_epic", NewMovement("CarPart_WheelMedium_epic", "Hermit", 190, GlobalData.EPIC_RARITY, 0, 1700, 0.06, 310, 110, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelMedium_epic_S", NewMovement("CarPart_WheelMedium_epic_S", "Hermit (ST)", 190, GlobalData.EPIC_RARITY, 0, 850, 0.12, 310, 110, 0, 0, 0, 0, 0, "light wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelBig_R_epic", NewMovement("CarPart_WheelBig_R_epic", "Large wheel", 90, GlobalData.RARE_RARITY, 0, 1650, 0.1, 220, 300, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelBig_RS_epic", NewMovement("CarPart_WheelBig_RS_epic", "Large wheel ST", 90, GlobalData.RARE_RARITY, 0, 900, 0.2, 220, 300, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelMilitary", NewMovement("CarPart_WheelMilitary", "APC wheel", 75, GlobalData.SPECIAL_RARITY, 0, 1350, 0.08, 215, 250, 0, 0, 0, 0.25, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelMilitary_S", NewMovement("CarPart_WheelMilitary_S", "APC wheel ST", 75, GlobalData.SPECIAL_RARITY, 0, 750, 0.15, 215, 250, 0, 0, 0, 0.25, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelDouble_R_epic", NewMovement("CarPart_WheelDouble_R_epic", "Twin wheel", 90, GlobalData.SPECIAL_RARITY, 0, 1620, 0.1, 235, 300, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_WheelDouble_RS_epic", NewMovement("CarPart_WheelDouble_RS_epic", "Twin wheel ST", 90, GlobalData.SPECIAL_RARITY, 0, 900, 0.2, 235, 300, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_MonsterTruck", NewMovement("CarPart_Wheel_MonsterTruck", "Bigfoot", 225, GlobalData.EPIC_RARITY, 0, 2250, 0.1, 445, 280, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_MonsterTruck_S", NewMovement("CarPart_Wheel_MonsterTruck_S", "Bigfoot ST", 225, GlobalData.EPIC_RARITY, 0, 1250, 0.2, 445, 280, 0, 0, 0, 0, 0, "heavy wheel"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Ilon", NewMovement("CarPart_Wheel_Ilon", "Omni wheel", 225, GlobalData.EPIC_RARITY, 0, 1250, 0.2, 445, 280, 0, 0, 0, 0, 0, "heavy wheel")); /* incomplete */
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_TankTrackBig_legend", NewMovement("CarPart_TankTrackBig_legend", "Armored track", 625, GlobalData.EPIC_RARITY, 60, 4000, 0.4, 1300, 1440, 0.5, 0.25, 0.25, 0.25, 0, "heavy track"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_TankTrackRomb", NewMovement("CarPart_TankTrackRomb", "Goliath", 1000, GlobalData.EPIC_RARITY, 45, 6000, 0.45, 1600, 1800, 0.5, 0.25, 0.25, 0, 0, "heavy track"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_TankTrack_rare", NewMovement("CarPart_TankTrack_rare", "Hardened track", 300, GlobalData.EPIC_RARITY, 75, 1850, 0.22, 600, 400, 0.5, 0.25, 0.25, 0, 0, "medium track"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_TankTrackBig_epic", NewMovement("CarPart_TankTrackBig_epic", "Small track", 230, GlobalData.EPIC_RARITY, 90, 935, 0.12, 300, 285, 0.5, 0.25, 0.25, 0, 0, "light track"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Hover_rare_bundle", NewMovement("CarPart_Hover_rare_bundle", "Icarus IV", 420, GlobalData.EPIC_RARITY, 75, 750, 0.08, 160, 325, 0, 0, 0, 0, 0, "hover"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Hover_rare", NewMovement("CarPart_Hover_rare", "Icarus VII", 420, GlobalData.EPIC_RARITY, 75, 750, 0.05, 135, 325, 0, 0, 0, 0, 0, "hover"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_MechaWheelLeg", NewMovement("CarPart_MechaWheelLeg", "Bigram", 275, GlobalData.EPIC_RARITY, 45, 2000, 0.2, 600, 700, 0.5, 0, 0, 0, 0, "leg"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_MechaLeg", NewMovement("CarPart_MechaLeg", "ML 200", 400, GlobalData.EPIC_RARITY, 40, 2400, 0.2, 810, 900, 0.5, 0, 0, 0, 0, "leg"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Shnekohod", NewMovement("CarPart_Shnekohod", "Meat Grinder", 360, GlobalData.EPIC_RARITY, 60, 2800, 0.35, 820, 800, 0.5, 0, 0, 0, 0, "auger"));
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Raider_01_epic_S", NewMovement("CarPart_Wheel_Raider_01_epic_S", "Buggy wheel ST", 360, GlobalData.EPIC_RARITY, 60, 2800, 0.35, 820, 800, 0.5, 0, 0, 0, 0, "auger")); /*incomplete*/
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_Wheel_Raider_01_epic", NewMovement("CarPart_Wheel_Raider_01_epic", "Buggy wheel", 360, GlobalData.EPIC_RARITY, 60, 2800, 0.35, 820, 800, 0.5, 0, 0, 0, 0, "auger")); /*incomplete*/
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_MotoWheel_S", NewMovement("CarPart_MotoWheel_S", "Claw", 360, GlobalData.EPIC_RARITY, 60, 2800, 0.35, 820, 800, 0.5, 0, 0, 0, 0, "frontal wheel")); /*incomplete*/
            currentSession.StaticRecords.GlobalMovementDict.Add("CarPart_TankTrackBig_dow", NewMovement("CarPart_TankTrackBig_dow", "Tank track", 1000, GlobalData.EPIC_RARITY, 45, 6000, 0.45, 1600, 1800, 0.5, 0.25, 0.25, 0, 0, "heavy track"));
        }

        public static void PopulateExplosiveList(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_ModuleAmmoBig_epic", NewExpolosive("CarPart_ModuleAmmoBig_epic", "Ammo pack", GlobalData.RARE_RARITY, 0, 115, 95, 96, 250.13, "ammo"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_Syfy_DeployAmmo", NewExpolosive("CarPart_Syfy_DeployAmmo", "Genesis", GlobalData.SPECIAL_RARITY, 0, 86, 80, 157, 193, "ammo"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_ModuleAmmo_rare", NewExpolosive("CarPart_ModuleAmmo_rare", "Expanded ammo pack", GlobalData.EPIC_RARITY, 0, 264, 288, 216, 434.2, "ammo"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_PowerGiver_rare", NewExpolosive("CarPart_PowerGiver_rare", "Big G", GlobalData.RARE_RARITY, -1, 101, 36, 150, 72.4, "generator"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_PowerGiverExplosive_epic", NewExpolosive("CarPart_PowerGiverExplosive_epic", "Ampere", GlobalData.SPECIAL_RARITY, -2, 30, 108, 410, 345.89, "generator"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_PowerGiver_epic", NewExpolosive("CarPart_PowerGiver_epic", "PU-1 Charge", GlobalData.SPECIAL_RARITY, -2, 164, 576, 410, 171.23, "generator"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_PowerGiverExplosive_legend", NewExpolosive("CarPart_PowerGiverExplosive_legend", "Gasgen", GlobalData.EPIC_RARITY, -3, 36, 144, 870, 446.21, "generator"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_PowerGiver_legend", NewExpolosive("CarPart_PowerGiver_legend", "Apollo IV", GlobalData.LEGENDARY_RARITY, -4, 363, 1152, 1600, 350.01, "generator"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_Barrel", NewExpolosive("CarPart_Barrel", "Fuel barrel", GlobalData.COMMON_RARITY, 0, 56, 80, 65, 195.51, "fuel tank"));
            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_ModuleTank_rare", NewExpolosive("CarPart_ModuleTank_rare", "Fuel tank", GlobalData.RARE_RARITY, 0, 140, 200, 115, 392.24, "fuel tank"));

            currentSession.StaticRecords.GlobalExplosivesDict.Add("CarPart_PowerGiver_epic2", NewExpolosive("CarPart_PowerGiver_epic2", "Bootstrap", GlobalData.EPIC_RARITY, -3, 36, 144, 870, 446.21, "generator"));
        }

        public static void PopulateEngineList(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_Engine", NewEngine("CarPart_Engine", "Dun horse", GlobalData.SPECIAL_RARITY, 1, 127, 80, 190, 2500, 500, 0.14, 0.15));
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_EngineMini_rare", NewEngine("CarPart_EngineMini_rare", "Hardcore", GlobalData.SPECIAL_RARITY, 0, 93, 50, 157, 0, 500, 0.09, 0.1));
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_Engine_rare", NewEngine("CarPart_Engine_rare", "Razorback", GlobalData.SPECIAL_RARITY, 1, 370, 400, 190, 0, 2000, 0.04, 0.3));
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_Engine_epic", NewEngine("CarPart_Engine_epic", "Cheetah", GlobalData.EPIC_RARITY, 1, 223, 150, 275, 3000, 1000, 0.2, 0.25));
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_EngineMini_epic", NewEngine("CarPart_EngineMini_epic", "Colossus", GlobalData.EPIC_RARITY, 1, 333, 450, 275, 0, 2500, 0.07, 0.5));
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_Engine_avia_front", NewEngine("CarPart_Engine_avia_front", "Golden Eagle", GlobalData.EPIC_RARITY, 1, 425, 500, 275, 0, 2500, 0.08, 0.4));
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_Engine_v8", NewEngine("CarPart_Engine_v8", "Hot red", GlobalData.EPIC_RARITY, 0, 145, 90, 216, 0, 1000, 0.13, 0.2));
            currentSession.StaticRecords.GlobalEngineDict.Add("CarPart_Engine_Powerful", NewEngine("CarPart_Engine_Powerful", "Oppressor ", GlobalData.EPIC_RARITY, 1, 425, 500, 275, 3000, 1000, 0.17, 0.3));
        }

        public static void PopulateModuleList(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Lifter", NewModule("CarPart_Lifter", "Car jack", GlobalData.COMMON_RARITY, 1, 112, 160, 85, "self righter"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Coupler", NewModule("CarPart_Coupler", "Contact 2M", GlobalData.RARE_RARITY, 0, 90, 100, 115, "connector"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Squib", NewModule("CarPart_Squib", "Rift 2M", GlobalData.RARE_RARITY, 0, 15, 35, 115, "connector"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Quadrocopter_SelfDefence", NewModule("CarPart_Quadrocopter_SelfDefence", "Argus", GlobalData.EPIC_RARITY, 1, 144, 128, 275, "defence"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_FusionSpec", NewModule("CarPart_FusionSpec", "Power unit", GlobalData.EPIC_RARITY, 2, 145, 383, 550, "support"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Selfcalc", NewModule("CarPart_Selfcalc", "Tormentor", GlobalData.EPIC_RARITY, 2, 153, 128, 550, "support"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Shield_mortal", NewModule("CarPart_Shield_mortal", "Aegis-Prime", GlobalData.LEGENDARY_RARITY, 3, 112, 80, 1200, "defence"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Stealth_epic", NewModule("CarPart_Stealth_epic", "Chameleon ", GlobalData.SPECIAL_RARITY, 1, 68, 48, 190, "stealth"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Stealth_legend", NewModule("CarPart_Stealth_legend", "Chameleon Mk2", GlobalData.EPIC_RARITY, 1, 84, 60, 275, "stealth"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_ModuleRadio", NewModule("CarPart_ModuleRadio", "Radio", GlobalData.COMMON_RARITY, 0, 13, 36, 65, "radar"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_RadarSmall", NewModule("CarPart_RadarSmall", "RS-1 Ruby", GlobalData.COMMON_RARITY, 0, 26, 72, 65, "radar"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_RadarSmall_rare", NewModule("CarPart_RadarSmall_rare", "RD-1 Listener", GlobalData.RARE_RARITY, 0, 71, 72, 115, "radar"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_RadarBig_rare", NewModule("CarPart_RadarBig_rare", "Maxwell", GlobalData.SPECIAL_RARITY, 1, 327, 288, 190, "radar"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Stealth_Seeker_rare", NewModule("CarPart_Stealth_Seeker_rare", "Oculus VI", GlobalData.SPECIAL_RARITY, 1, 174, 110, 190, "radar"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_RadarBig_epic", NewModule("CarPart_RadarBig_epic", "Doppler", GlobalData.EPIC_RARITY, 1, 431, 384, 275, "radar"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_RadarSmall_epic", NewModule("CarPart_RadarSmall_epic", "RD-2 Keen", GlobalData.EPIC_RARITY, 0, 202, 180, 216, "radar"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Stealth_Seeker_epic", NewModule("CarPart_Stealth_Seeker_epic", "Verifier", GlobalData.EPIC_RARITY, 1, 220, 190, 275, "defence"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Sniper_rare", NewModule("CarPart_Sniper_rare", "TS-1 Horizon", GlobalData.RARE_RARITY, 1, 36, 36, 130, "optic"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Syfy_SniperVisor", NewModule("CarPart_Syfy_SniperVisor", "Neutrino", GlobalData.EPIC_RARITY, 1, 72, 40, 275, "optic"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Booster", NewModule("CarPart_Booster", "B-1 Aviator", GlobalData.COMMON_RARITY, 1, 23, 32, 85, "booster"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Booster_rare", NewModule("CarPart_Booster_rare", "Blastoff", GlobalData.RARE_RARITY, 1, 48, 48, 130, "booster"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Booster_epic", NewModule("CarPart_Booster_epic", "Hermes", GlobalData.EPIC_RARITY, 1, 129, 108, 275, "booster"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Radiator", NewModule("CarPart_Radiator", "R-1 Breeze", GlobalData.COMMON_RARITY, 1, 45, 64, 85, "support"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Cooler_rare", NewModule("CarPart_Cooler_rare", "CS Taymyr", GlobalData.RARE_RARITY, 1, 63, 64, 130, "support"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Radiator_rare", NewModule("CarPart_Radiator_rare", "R-2 Chill", GlobalData.RARE_RARITY, 1, 126, 128, 130, "support"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Radiator_epic", NewModule("CarPart_Radiator_epic", "RN Seal", GlobalData.EPIC_RARITY, 1, 77, 64, 275, "support"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Cooler_epic", NewModule("CarPart_Cooler_epic", "Shiver", GlobalData.EPIC_RARITY, 1, 115, 96, 275, "support"));
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Cooldown_Accelerator_preepic", NewModule("CarPart_Cooldown_Accelerator_preepic", "KA-1 Discharger", GlobalData.EPIC_RARITY, 1, 115, 96, 275, "support")); /* incomplete */
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Cooldown_Accelerator_epic", NewModule("CarPart_Cooldown_Accelerator_epic", "KA-2 Flywheel", GlobalData.EPIC_RARITY, 1, 115, 96, 275, "support")); /* incomplete */
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Resist_Fslot_epic", NewModule("CarPart_Resist_Fslot_epic", "Averter", GlobalData.EPIC_RARITY, 3, 112, 80, 1200, "defence"));/* incomplete */
            currentSession.StaticRecords.GlobalModuleDict.Add("CarPart_Interceptor", NewModule("CarPart_Interceptor", "Interceptor", GlobalData.EPIC_RARITY, 3, 112, 80, 1200, "defence"));/* incomplete */
        }

        public static void PopulateCabinList(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Buggy_Small", NewCabin("Cabin_Buggy_Small", "Duster", GlobalData.COMMON_RARITY, 9, 95, 4000, 2000, 300, 170, 250, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Basic", NewCabin("Chassis_Basic", "Growl", GlobalData.RARE_RARITY, 11, 100, 6000, 3000, 450, 230, 750, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Tribal", NewCabin("Cabin_Tribal", "Bat", GlobalData.SPECIAL_RARITY, 11, 100, 6500, 3900, 600, 265, 1300, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Pestilence", NewCabin("Cabin_Pestilence", "Blight", GlobalData.EPIC_RARITY, 12, 100, 8300, 4100, 700, 300, 1800, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_InnateMelee", NewCabin("Cabin_InnateMelee", "Cerberus", GlobalData.EPIC_RARITY, 12, 100, 8500, 4000, 850, 285, 1800, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Moby_935", NewCabin("Cabin_Moby_935", "Cockpit", GlobalData.EPIC_RARITY, 12, 105, 7700, 3700, 450, 245, 1800, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Halloween2020_Cab", NewCabin("Cabin_Halloween2020_Cab", "Dusk", GlobalData.EPIC_RARITY, 12, 100, 8600, 4200, 850, 280, 1800, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Volcano", NewCabin("Cabin_Volcano", "Harpy", GlobalData.EPIC_RARITY, 12, 100, 8500, 4500, 1000, 295, 1800, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_DronSpawn", NewCabin("Cabin_DronSpawn", "Werewolf", GlobalData.EPIC_RARITY, 12, 100, 8000, 4000, 600, 250, 1800, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Tribal_Hog", NewCabin("Cabin_Tribal_Hog", "Tusk", GlobalData.EPIC_RARITY, 12, 100, 8000, 4000, 600, 250, 1800, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Tribal_cab2", NewCabin("Cabin_Tribal_cab2", "Griffon", GlobalData.LEGENDARY_RARITY, 12, 100, 9000, 4800, 700, 314, 2400, "light cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Small", NewCabin("Chassis_Small", "Guerilla", GlobalData.BASE_RARITY, 7, 65, 6000, 3000, 360, 250, 160, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_FordPickup", NewCabin("Chassis_FordPickup", "Huntsman", GlobalData.COMMON_RARITY, 8, 75, 7000, 3000, 700, 275, 250, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Light", NewCabin("Cabin_Light", "Sprinter", GlobalData.COMMON_RARITY, 8, 90, 6000, 2800, 350, 220, 250, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_FordPickup_Alpha", NewCabin("Chassis_FordPickup_Alpha", "Thug", GlobalData.COMMON_RARITY, 8, 75, 7000, 3500, 800, 280, 250, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_VWT1", NewCabin("Chassis_VWT1", "WWT1", GlobalData.COMMON_RARITY, 8, 70, 9000, 3000, 1200, 310, 250, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_ArmoredPickup", NewCabin("Cabin_ArmoredPickup", "Bear", GlobalData.RARE_RARITY, 10, 75, 9500, 4000, 1150, 340, 750, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Rage", NewCabin("Chassis_Rage", "Fury", GlobalData.RARE_RARITY, 10, 80, 9000, 4500, 950, 310, 750, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Riviera", NewCabin("Cabin_Riviera", "Hot Rod", GlobalData.RARE_RARITY, 10, 85, 9000, 4000, 900, 305, 750, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_ChevyPickup", NewCabin("Chassis_ChevyPickup", "Jockey", GlobalData.RARE_RARITY, 10, 75, 10000, 4000, 1400, 380, 750, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Wyvern", NewCabin("Chassis_Wyvern", "Wyvern", GlobalData.RARE_RARITY, 10, 80, 9000, 4000, 800, 290, 750, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Moonwalker", NewCabin("Cabin_Moonwalker", "Pilgrim", GlobalData.SPECIAL_RARITY, 11, 70, 12000, 4300, 1700, 310, 1100, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Zubilo", NewCabin("Cabin_Zubilo", "Favorite", GlobalData.EPIC_RARITY, 12, 90, 10500, 5250, 700, 280, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Mi24", NewCabin("Cabin_Mi24", "Ghost", GlobalData.EPIC_RARITY, 12, 80, 12000, 6000, 1050, 330, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Famine", NewCabin("Cabin_Famine", "Howl", GlobalData.EPIC_RARITY, 12, 90, 10500, 4500, 400, 250, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Workers_epic", NewCabin("Cabin_Workers_epic", "Omnibox", GlobalData.EPIC_RARITY, 12, 70, 12500, 6500, 2100, 369, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Lunar_Rover", NewCabin("Cabin_Lunar_Rover", "Photon", GlobalData.EPIC_RARITY, 12, 80, 13000, 5000, 2000, 335, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Satellite", NewCabin("Cabin_Satellite", "Quantum", GlobalData.EPIC_RARITY, 12, 90, 10000, 5000, 600, 260, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Spider", NewCabin("Chassis_Spider", "Steppe spider", GlobalData.EPIC_RARITY, 12, 60, 16000, 7000, 3250, 445, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Death", NewCabin("Cabin_Death", "The Call", GlobalData.EPIC_RARITY, 12, 85, 10500, 6000, 950, 300, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Lambo", NewCabin("Cabin_Lambo", "Torero", GlobalData.EPIC_RARITY, 12, 100, 10000, 5500, 750, 310, 1500, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_CyberEast_Cab1", NewCabin("Cabin_CyberEast_Cab1", "Jannabi", GlobalData.EPIC_RARITY, 12, 100, 10000, 5500, 750, 310, 1500, "medium cabin")); /* incomplete */
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Bell_Uh1_Oracle", NewCabin("Cabin_Bell_Uh1_Oracle", "Beholder", GlobalData.LEGENDARY_RARITY, 12, 90, 12500, 5400, 800, 305, 2100, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Scientists_Cab4", NewCabin("Cabin_Scientists_Cab4", "Nova", GlobalData.LEGENDARY_RARITY, 12, 80, 15400, 5500, 2300, 419, 2100, "medium cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Gazelle", NewCabin("Chassis_Gazelle", "Docker", GlobalData.COMMON_RARITY, 7, 60, 12000, 4000, 2400, 390, 250, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Panzer", NewCabin("Chassis_Panzer", "Carapace", GlobalData.RARE_RARITY, 10, 50, 16000, 6000, 3600, 440, 750, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Kamaz", NewCabin("Chassis_Kamaz", "Trucker", GlobalData.RARE_RARITY, 9, 60, 16000, 6000, 3200, 410, 750, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Military", NewCabin("Chassis_Military", "Jawbreaker", GlobalData.SPECIAL_RARITY, 10, 60, 17500, 6500, 3000, 410, 1100, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Bulldozer", NewCabin("Cabin_Bulldozer", "Bastion", GlobalData.EPIC_RARITY, 11, 60, 20000, 9000, 4500, 495, 1500, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_War", NewCabin("Cabin_War", "Echo", GlobalData.EPIC_RARITY, 11, 70, 18000, 10000, 3500, 440, 1500, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Chassis_Maz", NewCabin("Chassis_Maz", "Humpback", GlobalData.EPIC_RARITY, 11, 60, 20000, 8000, 4000, 470, 1500, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Explorer", NewCabin("Cabin_Explorer", "Ermak", GlobalData.EPIC_RARITY, 11, 60, 20000, 8000, 4000, 470, 1500, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Big", NewCabin("Cabin_Big", "Icebox", GlobalData.EPIC_RARITY, 11, 65, 19000, 9000, 3800, 455, 1500, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Military_cab4", NewCabin("Cabin_Military_cab4", "Cohort", GlobalData.LEGENDARY_RARITY, 11, 60, 24000, 9200, 5200, 609, 2100, "heavy cabin"));
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_CyberEast_Cab2", NewCabin("Cabin_CyberEast_Cab2", "Yokozuna", GlobalData.LEGENDARY_RARITY, 11, 60, 24000, 9200, 5200, 609, 2100, "heavy cabin")); /* incomplete */
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Raider_Cab1", NewCabin("Cabin_Raider_Cab1", "Aggressor", GlobalData.LEGENDARY_RARITY, 11, 60, 24000, 9200, 5200, 609, 2100, "light cabin")); /* incomplete */
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Junk_Cab1", NewCabin("Cabin_Junk_Cab1", "Machinist", GlobalData.LEGENDARY_RARITY, 11, 60, 24000, 9200, 5200, 609, 2100, "heavy cabin")); /* incomplete */
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_CyberEast_Cab3", NewCabin("Cabin_CyberEast_Cab3", "Deadman", GlobalData.LEGENDARY_RARITY, 11, 60, 24000, 9200, 5200, 609, 2100, "light cabin")); /* incomplete */
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_Engineers_Cab1_Fslot", NewCabin("Cabin_Engineers_Cab1_Fslot", "Master", GlobalData.LEGENDARY_RARITY, 11, 60, 24000, 9200, 5200, 609, 2100, "light cabin")); /* incomplete */
            currentSession.StaticRecords.GlobalCabinDict.Add("Cabin_CDAveraging", NewCabin("Cabin_CDAveraging", "Hadron", GlobalData.LEGENDARY_RARITY, 11, 60, 24000, 9200, 5200, 609, 2100, "light cabin")); /* incomplete */
        }

        public static void PopulateWeaponList(FileTraceManagment.SessionStats currentSession)
        {
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Starter", NewWeapon("CarPart_Gun_Machinegun_Starter", "SM Hornet", GlobalData.BASE_RARITY, 2, 2.71, 144, 52, 100, "machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun", NewWeapon("CarPart_Gun_Machinegun", "LM-54 Chord", GlobalData.COMMON_RARITY, 2, 3.11, 144, 60, 170, "machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Frontal", NewWeapon("CarPart_Gun_Machinegun_Frontal", "ST-M23 Defender", GlobalData.RARE_RARITY, 3, 7.2, 144, 140, 390, "frontal machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_rare", NewWeapon("CarPart_Gun_Machinegun_rare", "Vector", GlobalData.RARE_RARITY, 3, 7.07, 171, 74, 390, "machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_SMG", NewWeapon("CarPart_Gun_SMG", "M-37 Piercer", GlobalData.SPECIAL_RARITY, 3, 7.7, 195, 133, 570, "rapid-fire machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Preepic", NewWeapon("CarPart_Gun_Machinegun_Preepic", "Sinus-0", GlobalData.SPECIAL_RARITY, 3, 7.56, 185, 90, 570, "machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_ParticleBeam", NewWeapon("CarPart_Gun_Syfy_ParticleBeam", "Aurora", GlobalData.EPIC_RARITY, 4, 1.08, 315, 275, 1100, "laser minigun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_SmartMachinegun", NewWeapon("CarPart_Gun_SmartMachinegun", "Caucasus", GlobalData.EPIC_RARITY, 4, 11.3, 824, 314, 1100, "automatic machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_epic", NewWeapon("CarPart_Gun_Machinegun_epic", "Spectre-2", GlobalData.EPIC_RARITY, 4, 9.31, 186, 216, 1100, "machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Frontal_Epic", NewWeapon("CarPart_Gun_Machinegun_Frontal_Epic", "M-29 Protector", GlobalData.EPIC_RARITY, 3, 8.9, 170, 213, 825, "frontal machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_SMG_Epic", NewWeapon("CarPart_Gun_SMG_Epic", "M-38 Fidget", GlobalData.EPIC_RARITY, 3, 7.4, 220, 145, 825, "rapid-fire machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Minigun", NewWeapon("CarPart_Gun_Minigun", "MG13 Equalizer", GlobalData.EPIC_RARITY, 3, 3.8, 216, 163, 825, "minigun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Carabine", NewWeapon("CarPart_Gun_Carabine", "R-37-39 Adapter", GlobalData.EPIC_RARITY, 4, 12.28, 240, 154, 1100, "reloading machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Corner", NewWeapon("CarPart_Gun_Machinegun_Corner", "ST-M26 Tackler", GlobalData.EPIC_RARITY, 3, 16.1, 180, 228, 825, "frontal machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Legendary", NewWeapon("CarPart_Gun_Machinegun_Legendary", "Aspect", GlobalData.LEGENDARY_RARITY, 4, 9.6, 342, 220, 1600, "machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_SMG_Legend", NewWeapon("CarPart_Gun_SMG_Legend", "M-39 Imp", GlobalData.LEGENDARY_RARITY, 3, 8.24, 280, 209, 1200, "rapid-fire machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Minigun_Legend", NewWeapon("CarPart_Gun_Minigun_Legend", "MG14 Arbiter", GlobalData.LEGENDARY_RARITY, 3, 4, 279, 186, 1200, "minigun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_CannonMinigun_legend", NewWeapon("CarPart_Gun_CannonMinigun_legend", "Reaper", GlobalData.LEGENDARY_RARITY, 6, 12.5, 603, 520, 2400, "minigun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Relic", NewWeapon("CarPart_Gun_Machinegun_Relic", "Punisher", GlobalData.RELIC_RARITY, 4, 11, 430, 368, 2400, "machine gun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun", NewWeapon("CarPart_Gun_Shotgun", "Lupara", GlobalData.COMMON_RARITY, 3, 24, 68, 63, 255, "shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_rare", NewWeapon("CarPart_Gun_Shotgun_rare", "Sledgehammer", GlobalData.RARE_RARITY, 3, 24.42, 54, 115, 390, "shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_Frontal", NewWeapon("CarPart_Gun_Shotgun_Frontal", "Spitfire", GlobalData.RARE_RARITY, 3, 25.8, 126, 183, 390, "frontal shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_Fixed_Rare", NewWeapon("CarPart_Gun_Shotgun_Fixed_Rare", "Goblin", GlobalData.SPECIAL_RARITY, 2, 24.54, 90, 128, 380, "frontal shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_ShotGun_Garbage", NewWeapon("CarPart_Gun_ShotGun_Garbage", "Junkbow", GlobalData.SPECIAL_RARITY, 4, 144, 189, 247, 760, "reloading shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_Frontal_Preepic", NewWeapon("CarPart_Gun_Shotgun_Frontal_Preepic", "Leech", GlobalData.SPECIAL_RARITY, 3, 28.2, 135, 190, 570, "frontal shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_Preepic", NewWeapon("CarPart_Gun_Shotgun_Preepic", "Mace", GlobalData.SPECIAL_RARITY, 3, 25.98, 65, 120, 570, "shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_NailGun_rare", NewWeapon("CarPart_Gun_NailGun_rare", "Summator", GlobalData.SPECIAL_RARITY, 4, 138, 180, 157, 760, "charging shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_NailGun_epic", NewWeapon("CarPart_Gun_NailGun_epic", "Argument", GlobalData.EPIC_RARITY, 4, 138, 180, 157, 760, "charging shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_MiddleRangeShotgun", NewWeapon("CarPart_Gun_MiddleRangeShotgun", "Arothron", GlobalData.EPIC_RARITY, 4, 211.2, 378, 280, 1100, "reloading shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_ShotGun_Garbage_epic", NewWeapon("CarPart_Gun_ShotGun_Garbage_epic", "Fafnir", GlobalData.EPIC_RARITY, 4, 152, 255, 315, 1100, "reloading shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_ShotGun", NewWeapon("CarPart_Gun_Syfy_ShotGun", "Gravastar", GlobalData.EPIC_RARITY, 4, 42, 306, 196, 1100, "laser shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_Corner", NewWeapon("CarPart_Gun_Shotgun_Corner", "Rupture", GlobalData.EPIC_RARITY, 3, 29.4, 160, 229, 825, "frontal shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_epic", NewWeapon("CarPart_Gun_Shotgun_epic", "Thunderbolt", GlobalData.EPIC_RARITY, 4, 39.6, 90, 173, 1100, "shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_legend", NewWeapon("CarPart_Gun_Shotgun_legend", "Hammerfall", GlobalData.LEGENDARY_RARITY, 5, 42, 122, 221, 2000, "shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_ShotGun_Garbage_legend", NewWeapon("CarPart_Gun_ShotGun_Garbage_legend", "Nidhogg", GlobalData.LEGENDARY_RARITY, 4, 184, 290, 340, 1600, "reloading shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_Relic", NewWeapon("CarPart_Gun_Shotgun_Relic", "Breaker", GlobalData.RELIC_RARITY, 5, 47.4, 180, 387, 3000, "shotgun"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Cannon_rare", NewWeapon("CarPart_Gun_Cannon_rare", "AC43 Rapier", GlobalData.RARE_RARITY, 4, 14.3, 180, 113, 520, "autocannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Cannon_Preepic", NewWeapon("CarPart_Gun_Cannon_Preepic", "AC50 Storm", GlobalData.SPECIAL_RARITY, 4, 14.3, 210, 168, 760, "autocannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Cannon_Oneshot_preepic", NewWeapon("CarPart_Gun_Cannon_Oneshot_preepic", "Median", GlobalData.SPECIAL_RARITY, 5, 150, 342, 189, 950, "reloading autocannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Lcannon_epic", NewWeapon("CarPart_Gun_Lcannon_epic", "AC64 Joule", GlobalData.EPIC_RARITY, 4, 13.6, 240, 216, 1100, "rapid-fire autocannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Cannon_epic", NewWeapon("CarPart_Gun_Cannon_epic", "AC72 Whirlwind", GlobalData.EPIC_RARITY, 5, 16.2, 486, 391, 1375, "autocannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_CloseCombatCannon", NewWeapon("CarPart_Gun_CloseCombatCannon", "Whirl", GlobalData.EPIC_RARITY, 4, 32.76, 729, 457, 1100, "autocannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Cannon_Legend", NewWeapon("CarPart_Gun_Cannon_Legend", "Cyclone", GlobalData.LEGENDARY_RARITY, 5, 21, 570, 535, 2000, "rapid-fire autocannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_EX", NewWeapon("CarPart_Gun_BigCannon_EX", "Avenger 57mm", GlobalData.COMMON_RARITY, 5, 89, 468, 217, 425, "cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_EX_rare", NewWeapon("CarPart_Gun_BigCannon_EX_rare", "Judge 76mm", GlobalData.RARE_RARITY, 5, 105.8, 585, 320, 650, "cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_Free_rare", NewWeapon("CarPart_Gun_BigCannon_Free_rare", "Little Boy 6LB", GlobalData.RARE_RARITY, 6, 110, 837, 454, 780, "turret cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_Free_Preepic", NewWeapon("CarPart_Gun_BigCannon_Free_Preepic", "ZS-33 Hulk", GlobalData.SPECIAL_RARITY, 6, 121, 850, 583, 1140, "turret cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_EX_Preepic", NewWeapon("CarPart_Gun_BigCannon_EX_Preepic", "Prosecutor 76mm", GlobalData.SPECIAL_RARITY, 5, 118, 670, 400, 950, "cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_Free_T34_epic", NewWeapon("CarPart_Gun_BigCannon_Free_T34_epic", "Elephant", GlobalData.EPIC_RARITY, 6, 126.1, 1300, 847, 1650, "turret cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_EX_epic", NewWeapon("CarPart_Gun_BigCannon_EX_epic", "Executioner 88mm", GlobalData.EPIC_RARITY, 5, 143.41, 864, 495, 1375, "cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_Free_epic", NewWeapon("CarPart_Gun_BigCannon_Free_epic", "ZS-34 Fat Man", GlobalData.EPIC_RARITY, 6, 136, 1215, 830, 1650, "turret cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_EX_Legend", NewWeapon("CarPart_Gun_BigCannon_EX_Legend", "BC-17 Tsunami", GlobalData.LEGENDARY_RARITY, 6, 213, 1850, 746, 2400, "cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_Free_legend", NewWeapon("CarPart_Gun_BigCannon_Free_legend", "ZS-46 Mammoth", GlobalData.LEGENDARY_RARITY, 6, 170, 2633, 1284, 2400, "turret cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_EX_Relic", NewWeapon("CarPart_Gun_BigCannon_EX_Relic", "CC-18 Typhoon", GlobalData.RELIC_RARITY, 6, 255, 2200, 950, 3600, "cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_BigCannon_Free_Relic", NewWeapon("CarPart_Gun_BigCannon_Free_Relic", "ZS-52 Mastodon", GlobalData.RELIC_RARITY, 6, 75, 2855, 1505, 3600, "turret cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_AutoGuidedCourseGun_rare", NewWeapon("CarPart_AutoGuidedCourseGun_rare", "Wasp", GlobalData.RARE_RARITY, 4, 77.1, 90, 55, 520, "unguided rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_AutoGuidedCourseGun_Nurs_Preepic", NewWeapon("CarPart_AutoGuidedCourseGun_Nurs_Preepic", "Pyralid", GlobalData.SPECIAL_RARITY, 4, 89, 98, 69, 760, "unguided rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Improv_HomingMissileLauncher_epic", NewWeapon("CarPart_Improv_HomingMissileLauncher_epic", "ATGM Flute", GlobalData.EPIC_RARITY, 2, 73.07, 81, 47, 550, "guided rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_GuidedMissile_Sniper", NewWeapon("CarPart_Gun_GuidedMissile_Sniper", "Clarinet TOW", GlobalData.EPIC_RARITY, 5, 198.5, 270, 172, 1375, "guided rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_AutoGuidedCourseGun_epic", NewWeapon("CarPart_AutoGuidedCourseGun_epic", "Cricket", GlobalData.EPIC_RARITY, 5, 51.14, 288, 150, 1375, "unguided rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Missile_3x_Front_epic", NewWeapon("CarPart_Gun_Missile_3x_Front_epic", "Snowfall", GlobalData.EPIC_RARITY, 5, 90.00, 436, 567, 1375, "unguided rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_AutoGuidedCourseGun_Epic2", NewWeapon("CarPart_AutoGuidedCourseGun_Epic2", "Locust", GlobalData.EPIC_RARITY, 4, 94, 110, 100, 1100, "unguided rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_HomingMissileLauncherLockOn_epic", NewWeapon("CarPart_HomingMissileLauncherLockOn_epic", "Nest", GlobalData.EPIC_RARITY, 5, 37, 288, 164, 1375, "homing rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_HomingMissileLauncher_epic", NewWeapon("CarPart_HomingMissileLauncher_epic", "Pyre", GlobalData.EPIC_RARITY, 2, 116, 81, 52, 550, "homing rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_SpyModule_epic", NewWeapon("CarPart_Gun_SpyModule_epic", "Enlightenment", GlobalData.EPIC_RARITY, 2, 116, 81, 52, 550, "tracking rocket")); /* incomplete */
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_HomingMissileLauncherBurstR_legend", NewWeapon("CarPart_HomingMissileLauncherBurstR_legend", "Hurricane", GlobalData.LEGENDARY_RARITY, 6, 89, 288, 175, 2400, "homing rocket"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_GrenadeLauncher_Auto", NewWeapon("CarPart_Gun_GrenadeLauncher_Auto", "GL-55 Impulse", GlobalData.EPIC_RARITY, 5, 50, 198, 126, 1375, "grenade launcher"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_GrenadeLauncher_Shotgun", NewWeapon("CarPart_Gun_GrenadeLauncher_Shotgun", "Retcher", GlobalData.LEGENDARY_RARITY, 6, 100.2, 234, 213, 2400, "grenade launcher"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_FusionRifle", NewWeapon("CarPart_Gun_Syfy_FusionRifle", "Synthesis", GlobalData.SPECIAL_RARITY, 4, 14.18, 158, 175, 760, "plasma emitter"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Plasma_Cutter", NewWeapon("CarPart_Gun_Plasma_Cutter", "Blockchain", GlobalData.EPIC_RARITY, 4, 112, 340, 260, 1100, "electric sniper"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_FusionRifle_epic", NewWeapon("CarPart_Gun_Syfy_FusionRifle_epic", "Prometheus", GlobalData.EPIC_RARITY, 4, 14.4, 200, 185, 1100, "plasma emitter"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_Plazma", NewWeapon("CarPart_Gun_Syfy_Plazma", "Quasar", GlobalData.EPIC_RARITY, 6, 135, 792, 535, 1650, "plasma cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Plasma_Drill", NewWeapon("CarPart_Gun_Plasma_Drill", "Trigger", GlobalData.EPIC_RARITY, 4, 7, 410, 246, 1100, "reloading laser"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_LightningGun", NewWeapon("CarPart_Gun_LightningGun", "Assembler", GlobalData.LEGENDARY_RARITY, 6, 233.1, 293, 312, 2400, "electric sniper"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_FusionRifle_legend", NewWeapon("CarPart_Gun_Syfy_FusionRifle_legend", "Helios", GlobalData.LEGENDARY_RARITY, 4, 15.3, 250, 225, 1600, "plasma emitter"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_Plazma_Legend", NewWeapon("CarPart_Gun_Syfy_Plazma_Legend", "Pulsar", GlobalData.LEGENDARY_RARITY, 6, 142, 950, 693, 2400, "plasma cannon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_Tesla", NewWeapon("CarPart_Gun_Syfy_Tesla", "Spark III", GlobalData.LEGENDARY_RARITY, 4, 16, 360, 435, 1600, "tesla emitter"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Syfy_Tesla_relic", NewWeapon("CarPart_Gun_Syfy_Tesla_relic", "Flash I", GlobalData.RELIC_RARITY, 4, 20, 450, 544, 2400, "tesla emitter"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_SniperCrossbow", NewWeapon("CarPart_Gun_SniperCrossbow", "Scorpion", GlobalData.RELIC_RARITY, 6, 280, 900, 552, 3600, "electric sniper"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Coilgun_Legend", NewWeapon("CarPart_Gun_Coilgun_Legend", "Kaiju", GlobalData.RELIC_RARITY, 6, 280, 900, 552, 3600, "electric sniper"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Blast_ClassicCrossbow", NewWeapon("CarPart_Gun_Blast_ClassicCrossbow", "Phoenix", GlobalData.EPIC_RARITY, 5, 178, 1012, 418, 1375, "crossbow"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_ClassicCrossbow", NewWeapon("CarPart_Gun_ClassicCrossbow", "Spike-1", GlobalData.EPIC_RARITY, 4, 180, 810, 305, 1100, "crossbow"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_DoubleCrossbow", NewWeapon("CarPart_Gun_DoubleCrossbow", "Toadfish", GlobalData.LEGENDARY_RARITY, 4, 140, 900, 384, 1600, "crossbow"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Drill_epic", NewWeapon("CarPart_Drill_epic", "Borer", GlobalData.RARE_RARITY, 2, 20, 250, 330, 260, "grinding melee"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_SpearExplosive", NewWeapon("CarPart_SpearExplosive", "Boom", GlobalData.SPECIAL_RARITY, 1, 199.76, 45, 31, 190, "explosive melee"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Roundsaw_rare", NewWeapon("CarPart_Roundsaw_rare", "Buzzsaw", GlobalData.SPECIAL_RARITY, 2, 33, 125, 279, 380, "grinding melee"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_PlasmaSaw_preepic", NewWeapon("CarPart_PlasmaSaw_preepic", "Tempura", GlobalData.SPECIAL_RARITY, 2, 33, 125, 279, 380, "grinding melee")); /* incomplete */
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Chainsaw_dble_epic", NewWeapon("CarPart_Chainsaw_dble_epic", "Lacerator", GlobalData.EPIC_RARITY, 3, 50, 188, 401, 825, "grinding melee"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_LanceExplosive", NewWeapon("CarPart_LanceExplosive", "Lancelot", GlobalData.EPIC_RARITY, 1, 158.32, 144, 57, 275, "explosive melee"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_ChainSaw_epic", NewWeapon("CarPart_ChainSaw_epic", "Mauler", GlobalData.EPIC_RARITY, 3, 49.5, 94, 327, 825, "grinding melee"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Harvester_legend", NewWeapon("CarPart_Harvester_legend", "Harvester", GlobalData.LEGENDARY_RARITY, 4, 30, 940, 765, 1600, "grinding melee"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Flamethrower_frontal", NewWeapon("CarPart_Gun_Flamethrower_frontal", "Remedy", GlobalData.EPIC_RARITY, 4, 15, 300, 420, 1100, "frontal flamethrower"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Flamethrower_fixed", NewWeapon("CarPart_Gun_Flamethrower_fixed", "Draco", GlobalData.LEGENDARY_RARITY, 4, 23, 270, 360, 1600, "frontal flamethrower"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Flamethrower_light", NewWeapon("CarPart_Gun_Flamethrower_light", "Firebug", GlobalData.RELIC_RARITY, 4, 25, 315, 540, 2400, "flamethrower"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_MineTrap", NewWeapon("CarPart_Gun_MineTrap", "Kapkan", GlobalData.EPIC_RARITY, 2, 0, 360, 267, 550, "harpoon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Harpoon", NewWeapon("CarPart_Gun_Harpoon", "Skinner", GlobalData.EPIC_RARITY, 2, 0.1, 378, 308, 550, "harpoon"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_MineLauncher_Legend", NewWeapon("CarPart_Gun_MineLauncher_Legend", "King", GlobalData.EPIC_RARITY, 3, 119.26, 540, 240, 825, "minelayer"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_TurretHarpoonLauncher_legendary", NewWeapon("CarPart_Gun_TurretHarpoonLauncher_legendary", "Jubokko", GlobalData.LEGENDARY_RARITY, 5, 85, 360, 288, 2000, "minelayer")); /* incomplete */
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_WheelRocket", NewWeapon("CarPart_Gun_WheelRocket", "Fortune", GlobalData.LEGENDARY_RARITY, 5, 85, 360, 288, 2000, "minelayer"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_MineLauncher", NewWeapon("CarPart_Gun_MineLauncher", "Porcupine", GlobalData.RELIC_RARITY, 3, 174.21, 720, 384, 1800, "minelayer"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Catapult", NewWeapon("CarPart_Gun_Catapult", "Incinerator", GlobalData.EPIC_RARITY, 6, 2.5, 540, 472, 1650, "artillery"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Mortar_Revert", NewWeapon("CarPart_Gun_Mortar_Revert", "Mandrake", GlobalData.LEGENDARY_RARITY, 8, 110, 2430, 689, 3200, "artillery"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Quadrocopter_rare", NewWeapon("CarPart_Quadrocopter_rare", "AD-12 Falcon", GlobalData.RARE_RARITY, 3, 10, 128, 126, 390, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_TurretDeployer_rare", NewWeapon("CarPart_TurretDeployer_rare", "DT Cobra", GlobalData.RARE_RARITY, 3, 10, 128, 126, 390, "turret"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Quadrocopter_preepic", NewWeapon("CarPart_Quadrocopter_preepic", "AD-13 Hawk", GlobalData.SPECIAL_RARITY, 3, 12.32, 128, 141, 570, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_WheelDroneDeployer", NewWeapon("CarPart_WheelDroneDeployer", "Sidekick", GlobalData.SPECIAL_RARITY, 4, 15.3, 256, 141, 760, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_TurretDeployer_Preepic", NewWeapon("CarPart_TurretDeployer_Preepic", "T4 Python", GlobalData.SPECIAL_RARITY, 3, 11.2, 128, 141, 570, "turret"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_TurretDeployer_Shield", NewWeapon("CarPart_TurretDeployer_Shield", "Barrier IX", GlobalData.EPIC_RARITY, 3, 0, 128, 161, 825, "turret"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_kamikazeDroneDeployer", NewWeapon("CarPart_kamikazeDroneDeployer", "Fuze", GlobalData.EPIC_RARITY, 4, 134.1, 128, 161, 1100, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("Cabin_DronSpawn", NewWeapon("Cabin_DronSpawn", "Werewolf Drone", GlobalData.EPIC_RARITY, 0, 134.1, 128, 161, 0, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_WheelDroneDeployer_epic", NewWeapon("CarPart_WheelDroneDeployer_epic", "Grenadier", GlobalData.EPIC_RARITY, 4, 33.6, 180, 141, 1100, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Quadrocopter_epic", NewWeapon("CarPart_Quadrocopter_epic", "MD-3 Owl", GlobalData.EPIC_RARITY, 4, 100.8, 128, 161, 1100, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_DroneLauncher_epic", NewWeapon("CarPart_Gun_DroneLauncher_epic", "Yaoguai", GlobalData.EPIC_RARITY, 4, 100.8, 128, 161, 1100, "drone")); /*incomplete */
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_TurretDeployerMissile_epic", NewWeapon("CarPart_TurretDeployerMissile_epic", "RT Anaconda", GlobalData.EPIC_RARITY, 4, 101, 256, 321, 1100, "turret"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Quadrocopter_Syfy", NewWeapon("CarPart_Quadrocopter_Syfy", "Annihilator", GlobalData.LEGENDARY_RARITY, 4, 12, 200, 190, 1600, "drone"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_MGL_rare", NewWeapon("CarPart_Gun_MGL_rare", "Emily", GlobalData.SPECIAL_RARITY, 4, 38.5, 160, 100, 760, "revolver"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Revolver_epic", NewWeapon("CarPart_Gun_Revolver_epic", "Corvo", GlobalData.EPIC_RARITY, 4, 20, 200, 160, 1100, "revolver"));
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Shotgun_Fixed_epic", NewWeapon("CarPart_Gun_Shotgun_Fixed_epic", "Gremlin", GlobalData.EPIC_RARITY, 4, 20, 200, 160, 1100, "revolver")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Grenade_Launcher_epic", NewWeapon("CarPart_Gun_Grenade_Launcher_epic", "Thresher", GlobalData.EPIC_RARITY, 4, 20, 200, 160, 1100, "revolver")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Frontal_legend", NewWeapon("CarPart_Gun_Machinegun_Frontal_legend", "Vindicator", GlobalData.EPIC_RARITY, 4, 20, 200, 160, 1100, "revolver")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_CannonLong_legend", NewWeapon("CarPart_Gun_CannonLong_legend", "Stillwind", GlobalData.EPIC_RARITY, 4, 20, 200, 160, 1100, "revolver")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_GrenadeLauncher_Burst", NewWeapon("CarPart_Gun_GrenadeLauncher_Burst", "Yongwang", GlobalData.EPIC_RARITY, 4, 20, 200, 160, 1100, "revolver")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Plasma_Drill_legendary", NewWeapon("CarPart_Gun_Plasma_Drill_legendary", "Destructor", GlobalData.LEGENDARY_RARITY, 4, 20, 200, 160, 1100, "reloading laser")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_MiddleRangeShotgun_legend", NewWeapon("CarPart_Gun_MiddleRangeShotgun_legend", "Parser", GlobalData.LEGENDARY_RARITY, 4, 20, 200, 160, 1100, "reloading shotgun")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Machinegun_Frontal_Preepic", NewWeapon("CarPart_Gun_Machinegun_Frontal_Preepic", "M-25 Guardian", GlobalData.SPECIAL_RARITY, 4, 20, 200, 160, 1100, "frontal machine gun")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Missile_3xSpiral_Legend", NewWeapon("CarPart_Gun_Missile_3xSpiral_Legend", "Waltz", GlobalData.LEGENDARY_RARITY, 4, 20, 200, 160, 1100, "unguided rocket")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_ShotGun_Garbage_relic", NewWeapon("CarPart_Gun_ShotGun_Garbage_relic", "Jormungandr", GlobalData.RELIC_RARITY, 4, 20, 200, 160, 1100, "reloading shotgun")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_MissileLauncherPlasma_epic", NewWeapon("CarPart_Gun_MissileLauncherPlasma_epic", "Yokai", GlobalData.RELIC_RARITY, 4, 20, 200, 160, 1100, "unguided rocket")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_HomingMissileLauncherSupport_epic", NewWeapon("CarPart_HomingMissileLauncherSupport_epic", "Trombone", GlobalData.RELIC_RARITY, 4, 20, 200, 160, 1100, "unguided rocket")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_SawLauncher", NewWeapon("CarPart_Gun_SawLauncher", "Ripper", GlobalData.RELIC_RARITY, 4, 20, 200, 160, 1100, "unguided rocket")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_Lcannon_Preepic", NewWeapon("CarPart_Gun_Lcannon_Preepic", "AC62 Therm", GlobalData.RELIC_RARITY, 4, 20, 200, 160, 1100, "unguided rocket")); /*incomplete*/
            currentSession.StaticRecords.GlobalWeaponDict.Add("CarPart_Gun_DroneLauncher_Legend", NewWeapon("CarPart_Gun_DroneLauncher_Legend", "SD-15 Vulture", GlobalData.RELIC_RARITY, 4, 20, 200, 160, 1100, "unguided rocket")); /*incomplete*/
        }

        public static void PopulateGlobalPartsList(FileTraceManagment.SessionStats currentSession)
        {
            //ENGINEER 1
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 1, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 1, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 1, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 2
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.ENGINEER_FACTION, 2, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bumper Catch", GlobalData.ENGINEER_FACTION, 2, 0, 53, 72, 21, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.ENGINEER_FACTION, 2, 41, 41, 80, 52, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.ENGINEER_FACTION, 2, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 2, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 2, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 2, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 2, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 2, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 2, 13, 13, 28, 11, 0.0, 0, 0));
            //ENGINEER 3
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.ENGINEER_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Radiator Grille", GlobalData.ENGINEER_FACTION, 3, 0, 7, 7, 21, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 3, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 3, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.ENGINEER_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Running Board", GlobalData.ENGINEER_FACTION, 3, 15, 15, 34, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Running Board", GlobalData.ENGINEER_FACTION, 3, 15, 15, 34, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 3, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 3, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 3, 23, 23, 51, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 3, 23, 23, 51, 20, 0.0, 0, 0));
            //ENGINEER 4
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Gun Mount", GlobalData.ENGINEER_FACTION, 4, 0, 38, 43, 133, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hatchet", GlobalData.ENGINEER_FACTION, 4, 0, 31, 42, 12, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hatchet", GlobalData.ENGINEER_FACTION, 4, 0, 31, 42, 12, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 4, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 4, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 5
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Buggy Floor", GlobalData.ENGINEER_FACTION, 5, 0, 8, 9, 28, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Buggy Floor", GlobalData.ENGINEER_FACTION, 5, 0, 8, 9, 28, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Canvas Roof", GlobalData.ENGINEER_FACTION, 5, 60, 60, 135, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 6
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Radiator Grille", GlobalData.ENGINEER_FACTION, 6, 0, 7, 7, 21, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 6, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 6, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 6, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 6, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Offroad Bumper", GlobalData.ENGINEER_FACTION, 6, 0, 139, 192, 56, 0.0, 0, 0.9));
            //ENGINEER 7
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rear Door", GlobalData.ENGINEER_FACTION, 7, 86, 86, 196, 77, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 7, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 7, 6, 6, 12, 4, 0.0, 0, 0));
            //ENGINEER 8
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Gun Mount", GlobalData.ENGINEER_FACTION, 8, 0, 38, 43, 133, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 8, 23, 23, 51, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 8, 23, 23, 51, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 8, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 8, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 9
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 9, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bumper Catch", GlobalData.ENGINEER_FACTION, 9, 0, 53, 72, 21, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 9, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 9, 13, 13, 28, 11, 0.0, 0, 0));
            //ENGINEER 10
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Running Board", GlobalData.ENGINEER_FACTION, 10, 15, 15, 34, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Running Board", GlobalData.ENGINEER_FACTION, 10, 15, 15, 34, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Canvas Roof", GlobalData.ENGINEER_FACTION, 10, 60, 60, 135, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Canvas Roof", GlobalData.ENGINEER_FACTION, 10, 60, 60, 135, 53, 0.0, 0, 0));
            //ENGINEER 11
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 11, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 11, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Offroad Bumper", GlobalData.ENGINEER_FACTION, 11, 0, 139, 192, 56, 0.0, 0, 0.9));
            //ENGINEER 12 
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Radiator Grille", GlobalData.ENGINEER_FACTION, 12, 0, 7, 7, 21, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Radiator Grille", GlobalData.ENGINEER_FACTION, 12, 0, 7, 7, 21, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 12, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 12, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Canvas Roof", GlobalData.ENGINEER_FACTION, 12, 60, 60, 135, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Canvas Roof", GlobalData.ENGINEER_FACTION, 12, 60, 60, 135, 53, 0.0, 0, 0));
            //ENGINEER 13
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Floor", GlobalData.ENGINEER_FACTION, 13, 0, 16, 18, 56, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Floor", GlobalData.ENGINEER_FACTION, 13, 0, 16, 18, 56, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rear Door", GlobalData.ENGINEER_FACTION, 13, 86, 86, 196, 77, 0.0, 0, 0));
            //ENGINEER 14
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Engine Cover", GlobalData.ENGINEER_FACTION, 14, 0, 5, 5, 14, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Engine Cover", GlobalData.ENGINEER_FACTION, 14, 0, 5, 5, 14, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 14, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Sideboard", GlobalData.ENGINEER_FACTION, 14, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 15
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 15, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 15, 6, 6, 12, 4, 0.0, 0, 0));
            //ENGINEER 16
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Engine Cover", GlobalData.ENGINEER_FACTION, 16, 0, 5, 5, 14, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Engine Cover", GlobalData.ENGINEER_FACTION, 16, 0, 5, 5, 14, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hatchet", GlobalData.ENGINEER_FACTION, 16, 0, 31, 42, 12, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hatchet", GlobalData.ENGINEER_FACTION, 16, 0, 31, 42, 12, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Gun Mount", GlobalData.ENGINEER_FACTION, 16, 0, 38, 43, 133, 0.9, 0.9, 0));
            //ENGINEER 17
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 17, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 17, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Buggy Floor", GlobalData.ENGINEER_FACTION, 17, 0, 8, 9, 28, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Buggy Floor", GlobalData.ENGINEER_FACTION, 17, 0, 8, 9, 28, 0.9, 0.9, 0));
            //ENGINEER 18
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 18, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 18, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Trunk", GlobalData.ENGINEER_FACTION, 18, 0, 8, 9, 28, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Trunk", GlobalData.ENGINEER_FACTION, 18, 0, 8, 9, 28, 0.9, 0.9, 0));
            //ENGINEER 19
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 19, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 19, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Running Board", GlobalData.ENGINEER_FACTION, 19, 15, 15, 34, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Running Board", GlobalData.ENGINEER_FACTION, 19, 15, 15, 34, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 19, 23, 23, 51, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 19, 23, 23, 51, 20, 0.0, 0, 0));
            //ENGINEER 20
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Rear", GlobalData.ENGINEER_FACTION, 20, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Nosecut", GlobalData.ENGINEER_FACTION, 20, 40, 40, 90, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 20, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fender", GlobalData.ENGINEER_FACTION, 20, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 21
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Radiator Grille", GlobalData.ENGINEER_FACTION, 21, 0, 7, 7, 21, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Radiator Grille", GlobalData.ENGINEER_FACTION, 21, 0, 7, 7, 21, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 21, 23, 23, 51, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Window", GlobalData.ENGINEER_FACTION, 21, 23, 23, 51, 20, 0.0, 0, 0));
            //ENGINEER 22
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Trunk", GlobalData.ENGINEER_FACTION, 22, 0, 8, 9, 28, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Trunk", GlobalData.ENGINEER_FACTION, 22, 0, 8, 9, 28, 0.9, 0.9, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Fender", GlobalData.ENGINEER_FACTION, 22, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Fender", GlobalData.ENGINEER_FACTION, 22, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 23
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 23, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 23, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rear Door", GlobalData.ENGINEER_FACTION, 23, 86, 86, 196, 77, 0.0, 0, 0));
            //ENGINEER 24
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Fender", GlobalData.ENGINEER_FACTION, 24, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Fender", GlobalData.ENGINEER_FACTION, 24, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Canvas Roof", GlobalData.ENGINEER_FACTION, 24, 60, 60, 135, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Canvas Roof", GlobalData.ENGINEER_FACTION, 24, 60, 60, 135, 53, 0.0, 0, 0));
            //ENGINEER 25
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 25, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 25, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Bonnet", GlobalData.ENGINEER_FACTION, 25, 94, 94, 213, 84, 0.0, 0, 0));
            //ENGINEER 26
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 26, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 26, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Nosecut", GlobalData.ENGINEER_FACTION, 26, 40, 40, 90, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 26, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Side", GlobalData.ENGINEER_FACTION, 26, 20, 20, 45, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Rear", GlobalData.ENGINEER_FACTION, 26, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 27
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Strut", GlobalData.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Fender", GlobalData.ENGINEER_FACTION, 27, 25, 25, 56, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Fender", GlobalData.ENGINEER_FACTION, 27, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 28
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 28, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Strut", GlobalData.ENGINEER_FACTION, 28, 13, 13, 28, 11, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Torino Bonnet", GlobalData.ENGINEER_FACTION, 28, 94, 94, 213, 84, 0.0, 0, 0));
            //ENGINEER 29
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 29, 6, 6, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Van Ramp", GlobalData.ENGINEER_FACTION, 29, 6, 6, 12, 4, 0.0, 0, 0));
            //ENGINEER 30
            //ENGINEER PRESTIGE
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hot Rod Grille", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.ENGINEER_FACTION, 23, 23, 54, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hot Rod Hood", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.ENGINEER_FACTION, 50, 50, 121, 40, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hot Rod Left Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.ENGINEER_FACTION, 22, 22, 51, 17, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hot Rod Left Rear Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.ENGINEER_FACTION, 34, 34, 81, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hot Rod Right Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.ENGINEER_FACTION, 22, 22, 51, 17, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hot Rod Right Rear Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.ENGINEER_FACTION, 34, 34, 81, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hot Rod Trunk", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.ENGINEER_FACTION, 36, 36, 85, 28, 0.0, 0, 0));
            //LUNATICS 1
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fryer", GlobalData.LUNATICS_FACTION, 1, 28, 28, 54, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fryer", GlobalData.LUNATICS_FACTION, 1, 28, 28, 54, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 1, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 1, 4, 4, 7, 4, 0.0, 0, 0));
            //LUNATICS 2
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bullbar", GlobalData.LUNATICS_FACTION, 2, 0, 95, 101, 49, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 2, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 2, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Brazier", GlobalData.LUNATICS_FACTION, 2, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Brazier", GlobalData.LUNATICS_FACTION, 2, 14, 14, 27, 18, 0.0, 0, 0));
            //LUNATICS 3
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 3, 41, 41, 80, 52, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 3, 41, 41, 80, 52, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dryer", GlobalData.LUNATICS_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dryer", GlobalData.LUNATICS_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bumper Spike", GlobalData.LUNATICS_FACTION, 3, 0, 55, 58, 28, 0.0, 0, 0.9));
            //LUNATICS 4
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Rear", GlobalData.LUNATICS_FACTION, 4, 44, 44, 86, 56, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Rear", GlobalData.LUNATICS_FACTION, 4, 44, 44, 86, 56, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 4, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 4, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Brazier", GlobalData.LUNATICS_FACTION, 4, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Brazier", GlobalData.LUNATICS_FACTION, 4, 14, 14, 27, 18, 0.0, 0, 0));
            //LUNATICS 5
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fryer", GlobalData.LUNATICS_FACTION, 5, 28, 28, 54, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fryer", GlobalData.LUNATICS_FACTION, 5, 28, 28, 54, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 5, 41, 41, 80, 52, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 5, 41, 41, 80, 52, 0.0, 0, 0));
            //LUNATICS 6
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Rear", GlobalData.LUNATICS_FACTION, 6, 44, 44, 86, 56, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Rear", GlobalData.LUNATICS_FACTION, 6, 44, 44, 86, 56, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Fender Left", GlobalData.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Fender Left", GlobalData.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 6, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 6, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Fender Right", GlobalData.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Fender Right", GlobalData.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dryer", GlobalData.LUNATICS_FACTION, 6, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dryer", GlobalData.LUNATICS_FACTION, 6, 10, 10, 19, 12, 0.0, 0, 0));
            //LUNATICS 7
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dipper", GlobalData.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dipper", GlobalData.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Brazier", GlobalData.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Brazier", GlobalData.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Frontal Protection System", GlobalData.LUNATICS_FACTION, 7, 0, 68, 72, 35, 0.0, 0, 0.9));
            //LUNATICS 8
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bullbar", GlobalData.LUNATICS_FACTION, 8, 0, 95, 101, 49, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fryer", GlobalData.LUNATICS_FACTION, 8, 28, 28, 54, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Fryer", GlobalData.LUNATICS_FACTION, 8, 28, 28, 54, 35, 0.0, 0, 0));
            //LUNATICS 9
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dryer", GlobalData.LUNATICS_FACTION, 9, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dryer", GlobalData.LUNATICS_FACTION, 9, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 9, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 9, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bumper Spike", GlobalData.LUNATICS_FACTION, 9, 0, 55, 58, 28, 0.0, 0, 0.9));
            //LUNATICS 10
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Crutch", GlobalData.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Crutch", GlobalData.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 10, 41, 41, 80, 52, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 10, 41, 41, 80, 52, 0.0, 0, 0));
            //LUNATICS 11
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Fender Left", GlobalData.LUNATICS_FACTION, 11, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Fender Right", GlobalData.LUNATICS_FACTION, 11, 6, 6, 11, 7, 0.0, 0, 0));
            //LUNATICS 12
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Bumper", GlobalData.LUNATICS_FACTION, 12, 0, 81, 86, 42, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dipper", GlobalData.LUNATICS_FACTION, 12, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Dipper", GlobalData.LUNATICS_FACTION, 12, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Comb", GlobalData.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            //LUNATICS 13
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Rear", GlobalData.LUNATICS_FACTION, 13, 44, 44, 86, 56, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Rear", GlobalData.LUNATICS_FACTION, 13, 44, 44, 86, 56, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Grater", GlobalData.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bumper Spike", GlobalData.LUNATICS_FACTION, 13, 0, 55, 58, 28, 0.0, 0, 0.9));
            //LUNATICS 14
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 14, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Step Plate", GlobalData.LUNATICS_FACTION, 14, 8, 8, 14, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 14, 41, 41, 80, 52, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Whaleback", GlobalData.LUNATICS_FACTION, 14, 41, 41, 80, 52, 0.0, 0, 0));
            //LUNATICS 15
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Buggy Bumper", GlobalData.LUNATICS_FACTION, 15, 0, 81, 86, 42, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Frontal Protection System", GlobalData.LUNATICS_FACTION, 15, 0, 68, 72, 35, 0.0, 0, 0.9));
            //LUNATICS PRESTIGE
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Powerslide", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 68, 68, 138, 88, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Shielded Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 7, 7, 12, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Shielded Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 7, 7, 12, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Side Guard Right", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 11, 11, 21, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Side Guard Left", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 11, 11, 21, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bully Nosecut", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bully Bumper", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 0, 68, 72, 35, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pole Position", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 0, 89, 94, 46, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Backmarker", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 18, 18, 34, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Backmaker", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 18, 18, 34, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Bend", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 14, 14, 27, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Bend", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.LUNATICS_FACTION, 14, 14, 27, 18, 0.0, 0, 0));
            //NOMADS 1
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 1, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 1, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Large", GlobalData.NOMADS_FACTION, 1, 45, 45, 108, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Large", GlobalData.NOMADS_FACTION, 1, 45, 45, 108, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 1, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 1, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMADS 2
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Plow", GlobalData.NOMADS_FACTION, 2, 0, 216, 492, 155, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 2, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 2, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Wide Slope", GlobalData.NOMADS_FACTION, 2, 20, 20, 48, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel", GlobalData.NOMADS_FACTION, 2, 23, 23, 54, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel", GlobalData.NOMADS_FACTION, 2, 23, 23, 54, 18, 0.0, 0, 0));
            //NOMADS 3
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Blade Wing", GlobalData.NOMADS_FACTION, 3, 0, 28, 43, 17, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Blade Wing", GlobalData.NOMADS_FACTION, 3, 0, 28, 43, 17, 0.28, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 3, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 3, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Double Slope", GlobalData.NOMADS_FACTION, 3, 54, 54, 130, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Double Slope", GlobalData.NOMADS_FACTION, 3, 54, 54, 130, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Strut", GlobalData.NOMADS_FACTION, 3, 8, 8, 19, 6, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Strut", GlobalData.NOMADS_FACTION, 3, 8, 8, 19, 6, 0.0, 0, 0));
            //NOMADS 4
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 4, 5, 5, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 4, 5, 5, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Wide Slope", GlobalData.NOMADS_FACTION, 4, 20, 20, 48, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Narrow Wing", GlobalData.NOMADS_FACTION, 4, 50, 50, 121, 40, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Narrow Wing", GlobalData.NOMADS_FACTION, 4, 50, 50, 121, 40, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 4, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 4, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel", GlobalData.NOMADS_FACTION, 4, 23, 23, 54, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel", GlobalData.NOMADS_FACTION, 4, 23, 23, 54, 18, 0.0, 0, 0));
            //NOMADS 5
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 5, 5, 5, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 5, 5, 5, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Large", GlobalData.NOMADS_FACTION, 5, 45, 45, 108, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Large", GlobalData.NOMADS_FACTION, 5, 45, 45, 108, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 5, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 5, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Narrow Wing", GlobalData.NOMADS_FACTION, 5, 50, 50, 121, 40, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Narrow Wing", GlobalData.NOMADS_FACTION, 5, 50, 50, 121, 40, 0.0, 0, 0));
            //NOMAD 6
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Avia Fender", GlobalData.NOMADS_FACTION, 6, 53, 53, 128, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Avia Fender", GlobalData.NOMADS_FACTION, 6, 53, 53, 128, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 6, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 6, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Air Intake", GlobalData.NOMADS_FACTION, 6, 31, 31, 74, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Air Intake", GlobalData.NOMADS_FACTION, 6, 31, 31, 74, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMAD 7
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Wide", GlobalData.NOMADS_FACTION, 7, 37, 37, 88, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Wide", GlobalData.NOMADS_FACTION, 7, 37, 37, 88, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Small", GlobalData.NOMADS_FACTION, 7, 12, 12, 27, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Small", GlobalData.NOMADS_FACTION, 7, 12, 12, 27, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Blade Wing", GlobalData.NOMADS_FACTION, 7, 0, 28, 43, 17, 0.0, 0.25, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel", GlobalData.NOMADS_FACTION, 7, 23, 23, 54, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel", GlobalData.NOMADS_FACTION, 7, 23, 23, 54, 18, 0.0, 0, 0));
            //NOMAD 8
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Strut", GlobalData.NOMADS_FACTION, 8, 8, 8, 19, 6, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Strut", GlobalData.NOMADS_FACTION, 8, 8, 8, 19, 6, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Narrow", GlobalData.NOMADS_FACTION, 8, 10, 10, 22, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Narrow", GlobalData.NOMADS_FACTION, 8, 10, 10, 22, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Large", GlobalData.NOMADS_FACTION, 8, 45, 45, 108, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Large", GlobalData.NOMADS_FACTION, 8, 45, 45, 108, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Plow", GlobalData.NOMADS_FACTION, 8, 0, 216, 492, 155, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 8, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 8, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMAD 9
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 9, 5, 5, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 9, 5, 5, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Twin BladeWing", GlobalData.NOMADS_FACTION, 9, 0, 56, 86, 34, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Twin BladeWing", GlobalData.NOMADS_FACTION, 9, 0, 56, 86, 34, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Double Slope", GlobalData.NOMADS_FACTION, 9, 54, 54, 130, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Double Slope", GlobalData.NOMADS_FACTION, 9, 54, 54, 130, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Wide Slope", GlobalData.NOMADS_FACTION, 9, 20, 20, 48, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Wide Slope", GlobalData.NOMADS_FACTION, 9, 20, 20, 48, 15, 0.0, 0, 0));
            //NOMAD 10
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Avia Fender", GlobalData.NOMADS_FACTION, 10, 53, 53, 128, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 10, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 10, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Avia Fender", GlobalData.NOMADS_FACTION, 10, 53, 53, 128, 42, 0.0, 0, 0));
            //NOMAD 11
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Blade Wing", GlobalData.NOMADS_FACTION, 11, 0, 28, 43, 17, 0.0, 0.25, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 11, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 11, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Wide Slope", GlobalData.NOMADS_FACTION, 11, 20, 20, 48, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Wide Slope", GlobalData.NOMADS_FACTION, 11, 20, 20, 48, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 11, 5, 5, 12, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Narrow Slope", GlobalData.NOMADS_FACTION, 11, 5, 5, 12, 4, 0.0, 0, 0));
            //NOMAD 12
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Wide", GlobalData.NOMADS_FACTION, 12, 37, 37, 88, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Wide", GlobalData.NOMADS_FACTION, 12, 37, 37, 88, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Small", GlobalData.NOMADS_FACTION, 12, 12, 12, 27, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Panel Small", GlobalData.NOMADS_FACTION, 12, 12, 12, 27, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 12, 10, 10, 24, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Slope", GlobalData.NOMADS_FACTION, 12, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMAD 13
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 13, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Strut", GlobalData.NOMADS_FACTION, 13, 16, 16, 37, 12, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 13, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Nose", GlobalData.NOMADS_FACTION, 13, 13, 13, 31, 10, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Air Intake", GlobalData.NOMADS_FACTION, 13, 31, 31, 74, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Plane Air Intake", GlobalData.NOMADS_FACTION, 13, 31, 31, 74, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Narrow", GlobalData.NOMADS_FACTION, 13, 10, 10, 22, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope Narrow", GlobalData.NOMADS_FACTION, 13, 10, 10, 22, 7, 0.0, 0, 0));
            //NOMAD 14
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Avia Fender", GlobalData.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Avia Fender", GlobalData.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Oblique Slope", GlobalData.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Avia Fender", GlobalData.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Avia Fender", GlobalData.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            //NOMAD 15
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Strut", GlobalData.NOMADS_FACTION, 15, 8, 8, 19, 6, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Avia Strut", GlobalData.NOMADS_FACTION, 15, 8, 8, 19, 6, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Plow", GlobalData.NOMADS_FACTION, 15, 0, 216, 492, 155, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Plow", GlobalData.NOMADS_FACTION, 15, 0, 216, 492, 155, 0.0, 0, 0.9));
            //NOMAD PRESTIGE
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Mariposa", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 0, 75, 115, 28, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Shoulder", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 7, 7, 16, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Shoulder", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 7, 7, 16, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Corrida Right Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 56, 56, 142, 40, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Corrida Nosecut", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 68, 68, 173, 48, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Corrida Left Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 56, 56, 142, 40, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Splitter", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 0, 72, 110, 28, 0.0, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Side Air Intake", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 20, 20, 48, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Side Air", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.NOMADS_FACTION, 20, 20, 48, 15, 0.0, 0, 0));
            //SCAVENGERS 1
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Half-Wall", GlobalData.SCAVENGERS_FACTION, 1, 57, 57, 162, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Half-Wall", GlobalData.SCAVENGERS_FACTION, 1, 57, 57, 162, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 1, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 1, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 2
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 2, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 2, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 2, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 2, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Terribull Bar", GlobalData.SCAVENGERS_FACTION, 2, 0, 161, 324, 102, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Wide Slope", GlobalData.SCAVENGERS_FACTION, 2, 22, 22, 61, 13, 0.0, 0, 0));
            //SCAVENGERS 3
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 3, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 3, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 3, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 3, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 3, 9, 9, 23, 5, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 3, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 4
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Door", GlobalData.SCAVENGERS_FACTION, 4, 114, 114, 323, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Door", GlobalData.SCAVENGERS_FACTION, 4, 114, 114, 323, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 4, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 4, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Wide Slope", GlobalData.SCAVENGERS_FACTION, 4, 22, 22, 61, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 4, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 4, 11, 11, 31, 7, 0.0, 0, 0));
            //SCAVENGERS 5
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Door", GlobalData.SCAVENGERS_FACTION, 5, 114, 114, 323, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Door", GlobalData.SCAVENGERS_FACTION, 5, 114, 114, 323, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Metal Box", GlobalData.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Metal Box", GlobalData.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Half-Wall", GlobalData.SCAVENGERS_FACTION, 5, 57, 57, 162, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Half-Wall", GlobalData.SCAVENGERS_FACTION, 5, 57, 57, 162, 35, 0.0, 0, 0));
            //SCAVENGERS 6
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Fender", GlobalData.SCAVENGERS_FACTION, 6, 93, 93, 263, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Fender", GlobalData.SCAVENGERS_FACTION, 6, 93, 93, 263, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 6, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 6, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 6, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 6, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 6, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 6, 11, 11, 31, 7, 0.0, 0, 0));
            //SCAVENGERS 7
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 7, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 7, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thick Pipe Mudguard", GlobalData.SCAVENGERS_FACTION, 7, 24, 24, 66, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thick Pipe Mudguard", GlobalData.SCAVENGERS_FACTION, 7, 24, 24, 66, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Train Plow", GlobalData.SCAVENGERS_FACTION, 7, 0, 416, 952, 300, 0.0, 0, 0.9));
            //SCAVENGERS 8
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Terribull Bar", GlobalData.SCAVENGERS_FACTION, 8, 0, 161, 324, 102, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Wide Slope", GlobalData.SCAVENGERS_FACTION, 8, 22, 22, 61, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Wide Slope", GlobalData.SCAVENGERS_FACTION, 8, 22, 22, 61, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 8, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 8, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Half-Wall", GlobalData.SCAVENGERS_FACTION, 8, 57, 57, 162, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Half-Wall", GlobalData.SCAVENGERS_FACTION, 8, 57, 57, 162, 35, 0.0, 0, 0));
            //SCAVENGERS 9
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipe Shield", GlobalData.SCAVENGERS_FACTION, 9, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipe Shield", GlobalData.SCAVENGERS_FACTION, 9, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Metal Box", GlobalData.SCAVENGERS_FACTION, 9, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Metal Box", GlobalData.SCAVENGERS_FACTION, 9, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 9, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 9, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Twin Slope", GlobalData.SCAVENGERS_FACTION, 9, 22, 22, 61, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Twin Slope", GlobalData.SCAVENGERS_FACTION, 9, 22, 22, 61, 13, 0.0, 0, 0));
            //SCAVENGERS 10
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Fender", GlobalData.SCAVENGERS_FACTION, 10, 93, 93, 263, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Fender", GlobalData.SCAVENGERS_FACTION, 10, 93, 93, 263, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 10, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 10, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Long Pipe Shield", GlobalData.SCAVENGERS_FACTION, 10, 43, 43, 121, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Long Pipe Shield", GlobalData.SCAVENGERS_FACTION, 10, 43, 43, 121, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 10, 9, 9, 23, 5, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 10, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 11
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 11, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Quarter Wall", GlobalData.SCAVENGERS_FACTION, 11, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 11, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 11, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 11, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("T-Pipe", GlobalData.SCAVENGERS_FACTION, 11, 8, 8, 21, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 11, 9, 9, 23, 5, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Curved Pipe", GlobalData.SCAVENGERS_FACTION, 11, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 12
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 12, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 12, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 12, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Barrel Quarter", GlobalData.SCAVENGERS_FACTION, 12, 12, 12, 32, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 12, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Slope", GlobalData.SCAVENGERS_FACTION, 12, 36, 36, 101, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Container Wall", GlobalData.SCAVENGERS_FACTION, 12, 114, 114, 323, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Container Wall", GlobalData.SCAVENGERS_FACTION, 12, 114, 114, 323, 70, 0.0, 0, 0));
            //SCAVENGERS 13
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Long Pipe Shield", GlobalData.SCAVENGERS_FACTION, 13, 43, 43, 121, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Long Pipe Shield", GlobalData.SCAVENGERS_FACTION, 13, 43, 43, 121, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 13, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Truck Slope", GlobalData.SCAVENGERS_FACTION, 13, 11, 11, 31, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 13, 15, 15, 41, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Straight Pipe", GlobalData.SCAVENGERS_FACTION, 13, 15, 15, 41, 9, 0.0, 0, 0));
            //SCAVENGERS 14
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Fender", GlobalData.SCAVENGERS_FACTION, 14, 93, 93, 263, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Fender", GlobalData.SCAVENGERS_FACTION, 14, 93, 93, 263, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipe Shield", GlobalData.SCAVENGERS_FACTION, 14, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipe Shield", GlobalData.SCAVENGERS_FACTION, 14, 29, 29, 81, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Twin Slope", GlobalData.SCAVENGERS_FACTION, 14, 22, 22, 61, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Twin Slope", GlobalData.SCAVENGERS_FACTION, 14, 22, 22, 61, 13, 0.0, 0, 0));
            //SCAVENGERS 15
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Train Plow", GlobalData.SCAVENGERS_FACTION, 15, 0, 416, 952, 300, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thick Pipe Mudguard", GlobalData.SCAVENGERS_FACTION, 15, 24, 24, 66, 14, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thick Pipe Mudguard", GlobalData.SCAVENGERS_FACTION, 15, 24, 24, 66, 14, 0.0, 0, 0));
            //SCAVENGERS PRESTIGE
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bartizan", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bartizan", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bartizan", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bartizan", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bartizan", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bartizan", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Veil", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 0, 97, 194, 32, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Phantom Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 89, 89, 252, 55, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Phantom Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 89, 89, 252, 55, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rear Cover", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 48, 48, 137, 30, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rear Cover", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 48, 48, 137, 30, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rear Cover", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.SCAVENGERS_FACTION, 48, 48, 137, 30, 0.0, 0, 0));
            //STEPPENWOLF 1
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 1, 120, 120, 359, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 1, 120, 120, 359, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thin Strike Plate", GlobalData.STEPPENWOLFS_FACTION, 1, 8, 8, 23, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thin Strike Plate", GlobalData.STEPPENWOLFS_FACTION, 1, 8, 8, 23, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Slope", GlobalData.STEPPENWOLFS_FACTION, 1, 49, 49, 146, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Slope", GlobalData.STEPPENWOLFS_FACTION, 1, 49, 49, 146, 29, 0.0, 0, 0));
            //STEPENWOLF 2
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Ventilation Slope", GlobalData.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Ventilation Slope", GlobalData.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hard Module", GlobalData.STEPPENWOLFS_FACTION, 2, 94, 94, 280, 55, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 2, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 2, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 3
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 3, 120, 120, 359, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Side Part", GlobalData.STEPPENWOLFS_FACTION, 3, 61, 61, 180, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 3, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 3, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thin Strike Plate", GlobalData.STEPPENWOLFS_FACTION, 3, 8, 8, 23, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thin Strike Plate", GlobalData.STEPPENWOLFS_FACTION, 3, 8, 8, 23, 4, 0.0, 0, 0));
            //STEPENWOLF 4
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Defence Perimeter", GlobalData.STEPPENWOLFS_FACTION, 4, 0, 133, 288, 42, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hard Module", GlobalData.STEPPENWOLFS_FACTION, 4, 94, 94, 280, 55, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 4, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 4, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Slope", GlobalData.STEPPENWOLFS_FACTION, 4, 49, 49, 146, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Slope", GlobalData.STEPPENWOLFS_FACTION, 4, 49, 49, 146, 29, 0.0, 0, 0));
            //STEPENWOLF 5
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Rear", GlobalData.STEPPENWOLFS_FACTION, 5, 105, 105, 314, 62, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Twin Slope", GlobalData.STEPPENWOLFS_FACTION, 5, 12, 12, 34, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Twin Slope", GlobalData.STEPPENWOLFS_FACTION, 5, 12, 12, 34, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Ventilation Slope", GlobalData.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Ventilation Slope", GlobalData.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 6
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Defence Line", GlobalData.STEPPENWOLFS_FACTION, 6, 0, 89, 192, 28, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Side Part", GlobalData.STEPPENWOLFS_FACTION, 6, 61, 61, 180, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 6, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 6, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Slope", GlobalData.STEPPENWOLFS_FACTION, 6, 49, 49, 146, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Slope", GlobalData.STEPPENWOLFS_FACTION, 6, 49, 49, 146, 29, 0.0, 0, 0));
            //STEPENWOLF 7
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thin Strike Plate", GlobalData.STEPPENWOLFS_FACTION, 7, 8, 8, 23, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Thin Strike Plate", GlobalData.STEPPENWOLFS_FACTION, 7, 8, 8, 23, 4, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Armored Hatch", GlobalData.STEPPENWOLFS_FACTION, 7, 98, 98, 293, 58, 0.0, 0, 0));
            //STEPENWOLF 8
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 8, 120, 120, 359, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 9
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Door", GlobalData.STEPPENWOLFS_FACTION, 9, 53, 53, 157, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Door", GlobalData.STEPPENWOLFS_FACTION, 9, 53, 53, 157, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hard Module", GlobalData.STEPPENWOLFS_FACTION, 9, 94, 94, 280, 55, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Ventilation Slope", GlobalData.STEPPENWOLFS_FACTION, 9, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Ventilation Slope", GlobalData.STEPPENWOLFS_FACTION, 9, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Twin Slope", GlobalData.STEPPENWOLFS_FACTION, 9, 12, 12, 34, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Strengthened Twin Slope", GlobalData.STEPPENWOLFS_FACTION, 9, 12, 12, 34, 7, 0.0, 0, 0));
            //STEPENWOLF 10
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 10, 120, 120, 359, 70, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 10, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 10, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Defence Perimeter", GlobalData.STEPPENWOLFS_FACTION, 10, 0, 133, 288, 42, 0.0, 0, 0.9));
            //STEPENWOLF 11
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Door", GlobalData.STEPPENWOLFS_FACTION, 11, 53, 53, 157, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Door", GlobalData.STEPPENWOLFS_FACTION, 11, 53, 53, 157, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Side Part", GlobalData.STEPPENWOLFS_FACTION, 11, 61, 61, 180, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Side Part", GlobalData.STEPPENWOLFS_FACTION, 11, 61, 61, 180, 35, 0.0, 0, 0));
            //STEPENWOLF 12
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Rear", GlobalData.STEPPENWOLFS_FACTION, 12, 105, 105, 314, 62, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 12, 120, 120, 359, 70, 0.0, 0, 0));
            //STEPENWOLF 13
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Defence Line", GlobalData.STEPPENWOLFS_FACTION, 13, 0, 89, 192, 28, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Side Part", GlobalData.STEPPENWOLFS_FACTION, 13, 61, 61, 180, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("APC Side Part", GlobalData.STEPPENWOLFS_FACTION, 13, 61, 61, 180, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 13, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 13, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 14
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 14, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Tank Side Part", GlobalData.STEPPENWOLFS_FACTION, 14, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Armored Hatch", GlobalData.STEPPENWOLFS_FACTION, 14, 98, 98, 293, 58, 0.0, 0, 0));
            //STEPENWOLF 15
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Roof Part", GlobalData.STEPPENWOLFS_FACTION, 15, 23, 23, 68, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hard Module", GlobalData.STEPPENWOLFS_FACTION, 15, 94, 94, 280, 55, 0.0, 0, 0));
            //STEPENWOLF PRESTIGE
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Line of Defence", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Line of Defence", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Vanguard", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 31, 31, 90, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Western Front", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Eastern Front", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 46, 46, 135, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Wedge", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 61, 61, 180, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Home Front", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 105, 105, 314, 62, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Barrier", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 14, 14, 40, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Barrier", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 14, 14, 40, 8, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Sentry Line", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 122, 264, 39, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Rampart", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 38, 38, 112, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Rampart", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 38, 38, 112, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Military Truck Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Military Truck Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right APC Bumper", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left APC Bumper", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Military Truck Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Military Truck Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Military Truck Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Military Truck Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small APC Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large APC Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 90, 90, 269, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large APC Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 90, 90, 269, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Flail", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 76, 165, 24, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Flail", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 76, 165, 24, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Flail", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 76, 165, 24, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Flail", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 80, 96, 56, 0.0, 0.25, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Flail", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 80, 96, 56, 0.0, 0.25, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Flail", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 80, 96, 56, 0.0, 0.25, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right APC Bumper", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left APC Bumper", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            //DAWNS CHILDREN 1
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 1, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 1, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Observation Pod", GlobalData.DAWNS_CHILDREN_FACTION, 1, 31, 31, 79, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 1, 4, 4, 8, 2, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 1, 4, 4, 8, 2, 0.0, 0, 0));
            //DAWNS CHILDREN 2
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Back", GlobalData.DAWNS_CHILDREN_FACTION, 2, 53, 53, 134, 37, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 2, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 2, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 2, 10, 10, 24, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 2, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 3
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 3, 4, 4, 8, 2, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 3, 4, 4, 8, 2, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Ventilation Box", GlobalData.DAWNS_CHILDREN_FACTION, 3, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 3, 19, 19, 48, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 3, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 4
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 4, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 4, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Observation Pod", GlobalData.DAWNS_CHILDREN_FACTION, 4, 31, 31, 79, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 4, 10, 10, 24, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 4, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 5
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Back", GlobalData.DAWNS_CHILDREN_FACTION, 5, 53, 53, 134, 37, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 5, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 5, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 5, 19, 19, 48, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 5, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 6
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Ventilation Box", GlobalData.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 6, 10, 10, 24, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 6, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 7
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 7, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 7, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Shock Absorber", GlobalData.DAWNS_CHILDREN_FACTION, 7, 0, 132, 202, 77, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 7, 19, 19, 48, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 7, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 8
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Back", GlobalData.DAWNS_CHILDREN_FACTION, 8, 53, 53, 134, 37, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 8, 4, 4, 8, 2, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 8, 4, 4, 8, 2, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 8, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 9
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Back", GlobalData.DAWNS_CHILDREN_FACTION, 9, 53, 53, 134, 37, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 9, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 9, 62, 62, 157, 44, 0.0, 0, 0));
            //DAWNS CHILDREN 10
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Part", GlobalData.DAWNS_CHILDREN_FACTION, 10, 10, 10, 24, 7, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Ventilation Box", GlobalData.DAWNS_CHILDREN_FACTION, 10, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 10, 19, 19, 48, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Broken Radiator", GlobalData.DAWNS_CHILDREN_FACTION, 10, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 11
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 11, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Control Module", GlobalData.DAWNS_CHILDREN_FACTION, 11, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Observation Pod", GlobalData.DAWNS_CHILDREN_FACTION, 11, 31, 31, 79, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Observation Pod", GlobalData.DAWNS_CHILDREN_FACTION, 11, 31, 31, 79, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 11, 4, 4, 8, 2, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 11, 4, 4, 8, 2, 0.0, 0, 0));
            //DAWNS CHILDREN 12
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Back", GlobalData.DAWNS_CHILDREN_FACTION, 12, 53, 53, 134, 37, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 12, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Ventilation Box", GlobalData.DAWNS_CHILDREN_FACTION, 12, 28, 28, 71, 20, 0.0, 0, 0));
            //DAWNS CHILDREN 13
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Observation Pod", GlobalData.DAWNS_CHILDREN_FACTION, 13, 31, 31, 79, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 13, 4, 4, 8, 2, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Air Intake", GlobalData.DAWNS_CHILDREN_FACTION, 13, 4, 4, 8, 2, 0.0, 0, 0));
            //DAWNS CHILDREN 14
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Hull Back", GlobalData.DAWNS_CHILDREN_FACTION, 14, 53, 53, 134, 37, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Ventilation Box", GlobalData.DAWNS_CHILDREN_FACTION, 14, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Ventilation Box", GlobalData.DAWNS_CHILDREN_FACTION, 14, 28, 28, 71, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Observation Pod", GlobalData.DAWNS_CHILDREN_FACTION, 14, 31, 31, 79, 22, 0.0, 0, 0));
            //DAWNS CHILDREN 15
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cooling System", GlobalData.DAWNS_CHILDREN_FACTION, 15, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Shock Absorber", GlobalData.DAWNS_CHILDREN_FACTION, 15, 0, 132, 202, 77, 0.25, 0.0, 0.9));
            //DAWNS CHILDREN PRESTIGE
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rump", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 25, 25, 48, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Phalanx", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 13, 13, 24, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Phalanx", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 13, 13, 24, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Rib", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 19, 19, 37, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Rib", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 19, 19, 37, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cranium", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 55, 58, 28, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Reflector", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Reflector", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Reflector", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Reflector", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Reflector", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Reflector", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Screener", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Screener", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Screener", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Screener", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Assembly Section", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Assembly Section", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Assembly Section", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Assembly Section", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Incisor", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Incisor", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Incisor", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Incisor", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Incisor", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Incisor", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Assembly Section", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Assembly Section", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            //FIRESTARTER 1
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flaming Rakes", GlobalData.FIRESTARTERS_FACTION, 1, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flaming Rakes", GlobalData.FIRESTARTERS_FACTION, 1, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Left", GlobalData.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Left", GlobalData.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Right", GlobalData.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Right", GlobalData.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            //FIRESTARTER 2
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Scorched", GlobalData.FIRESTARTERS_FACTION, 2, 47, 47, 99, 48, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Scorched", GlobalData.FIRESTARTERS_FACTION, 2, 47, 47, 99, 48, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Nibbler", GlobalData.FIRESTARTERS_FACTION, 2, 0, 71, 86, 32, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 2, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 2, 22, 22, 45, 22, 0.0, 0, 0));
            //FIRESTARTER 3
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Peaky Blinder", GlobalData.FIRESTARTERS_FACTION, 3, 17, 17, 36, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Peaky Blinder", GlobalData.FIRESTARTERS_FACTION, 3, 17, 17, 36, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipetooth", GlobalData.FIRESTARTERS_FACTION, 3, 0, 44, 53, 19, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipetooth", GlobalData.FIRESTARTERS_FACTION, 3, 0, 44, 53, 19, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Devilry", GlobalData.FIRESTARTERS_FACTION, 3, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 4
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Scorched", GlobalData.FIRESTARTERS_FACTION, 4, 47, 47, 99, 48, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Scorched", GlobalData.FIRESTARTERS_FACTION, 4, 47, 47, 99, 48, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 4, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 4, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 4, 28, 28, 59, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 4, 28, 28, 59, 29, 0.0, 0, 0));
            //FIRESTARTER 5
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Left", GlobalData.FIRESTARTERS_FACTION, 5, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Right", GlobalData.FIRESTARTERS_FACTION, 5, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Boar", GlobalData.FIRESTARTERS_FACTION, 5, 45, 45, 95, 46, 0.0, 0, 0));
            //FIRESTARTER 6
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flaming Rakes", GlobalData.FIRESTARTERS_FACTION, 6, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flaming Rakes", GlobalData.FIRESTARTERS_FACTION, 6, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 6, 28, 28, 59, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 6, 28, 28, 59, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Devilry", GlobalData.FIRESTARTERS_FACTION, 6, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 7
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Scorched", GlobalData.FIRESTARTERS_FACTION, 7, 47, 47, 99, 48, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Thorn", GlobalData.FIRESTARTERS_FACTION, 7, 13, 13, 27, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Thorn", GlobalData.FIRESTARTERS_FACTION, 7, 13, 13, 27, 13, 0.0, 0, 0));
            //FIRESTARTER 8
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flaming Rakes", GlobalData.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipetooth", GlobalData.FIRESTARTERS_FACTION, 8, 0, 44, 53, 19, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Boar", GlobalData.FIRESTARTERS_FACTION, 8, 45, 45, 95, 46, 0.0, 0, 0));
            //FIRESTARTER 9
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Peaky Blinder", GlobalData.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Peaky Blinder", GlobalData.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Peaky Blinder", GlobalData.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Peaky Blinder", GlobalData.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Stranglehold", GlobalData.FIRESTARTERS_FACTION, 9, 0, 79, 96, 35, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Devilry", GlobalData.FIRESTARTERS_FACTION, 9, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 10
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Nibbler", GlobalData.FIRESTARTERS_FACTION, 10, 0, 71, 86, 32, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 10, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 10, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 10, 28, 28, 59, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 10, 28, 28, 59, 29, 0.0, 0, 0));
            //FIRESTARTER 11
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Thorn", GlobalData.FIRESTARTERS_FACTION, 11, 13, 13, 27, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Thorn", GlobalData.FIRESTARTERS_FACTION, 11, 13, 13, 27, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Boar", GlobalData.FIRESTARTERS_FACTION, 11, 45, 45, 95, 46, 0.0, 0, 0));
            //FIRESTARTER 12
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Scorched", GlobalData.FIRESTARTERS_FACTION, 12, 47, 47, 99, 48, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pipetooth", GlobalData.FIRESTARTERS_FACTION, 12, 0, 44, 53, 19, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flaming Rakes", GlobalData.FIRESTARTERS_FACTION, 12, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Devilry", GlobalData.FIRESTARTERS_FACTION, 12, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 13
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 13, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Downstream", GlobalData.FIRESTARTERS_FACTION, 13, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Left", GlobalData.FIRESTARTERS_FACTION, 13, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Cover Your Right", GlobalData.FIRESTARTERS_FACTION, 13, 15, 15, 32, 15, 0.0, 0, 0));
            //FIRESTARTER 14
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Boar", GlobalData.FIRESTARTERS_FACTION, 14, 45, 45, 95, 46, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Stranglehold", GlobalData.FIRESTARTERS_FACTION, 14, 0, 79, 96, 35, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 14, 28, 28, 59, 29, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Rollover", GlobalData.FIRESTARTERS_FACTION, 14, 28, 28, 59, 29, 0.0, 0, 0));
            //FIRESTARTER 15
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Thorn", GlobalData.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Thorn", GlobalData.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Thorn", GlobalData.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Thorn", GlobalData.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            //FIRESTARTER PRESTIGE
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("The Omen", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 71, 86, 32, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Death Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 19, 19, 48, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Death Fender", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 19, 19, 48, 13, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Finale", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 56, 56, 135, 44, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Catheter", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Catheter", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Catheter", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Catheter", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Catheter", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Catheter", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Right Plaster", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Left Plaster", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 15, 15, 32, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bandage", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 26, 26, 54, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bandage", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 26, 26, 54, 26, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Vial", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.9, 0.0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Pill", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 17, 17, 36, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Aura", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Aura", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Aura", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Aura", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Aura", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Aura", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bus Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bus Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bus Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Bus Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 64, 64, 135, 66, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Minivan Panel", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 64, 64, 135, 66, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Thorn", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 20, 24, 14, 0.25, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Thorn", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 20, 24, 14, 0.25, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Thorn", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 40, 48, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Medium Thorn", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 40, 48, 28, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flayer", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 95, 115, 42, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Flayer", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 95, 115, 42, 0.0, 0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Thorn", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 80, 96, 56, 0.25, 0.0, 0.9));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Thorn", GlobalData.PRESTIGUE_PACK_FACTION, GlobalData.FIRESTARTERS_FACTION, 0, 80, 96, 56, 0.25, 0.0, 0.9));
            //FOUNDERS
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Left", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Left", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Left", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Left", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Right", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Right", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Right", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Hull Right", GlobalData.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Left", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Left", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Left", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Left", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Right", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Right", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Right", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Plug Right", GlobalData.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Left", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Left", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Left", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Left", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Right", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Right", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Right", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Crane Side Right", GlobalData.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Digger Hull", GlobalData.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Digger Hull", GlobalData.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Digger Hull", GlobalData.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Digger Hull", GlobalData.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Digger Side", GlobalData.FOUNDERS_FACTION, 1, 62, 62, 157, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Digger Side", GlobalData.FOUNDERS_FACTION, 1, 62, 62, 157, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Digger Side", GlobalData.FOUNDERS_FACTION, 1, 62, 62, 157, 31, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Platform", GlobalData.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Platform", GlobalData.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Platform", GlobalData.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Large Platform", GlobalData.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Sloped Platform", GlobalData.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Sloped Platform", GlobalData.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Sloped Platform", GlobalData.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Sloped Platform", GlobalData.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Digger Side", GlobalData.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Digger Side", GlobalData.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Digger Side", GlobalData.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Digger Side", GlobalData.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Digger Side", GlobalData.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Platform", GlobalData.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Platform", GlobalData.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Platform", GlobalData.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
            currentSession.StaticRecords.GlobalPartsList.Add(NewPart("Small Platform", GlobalData.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
        }


    }
}

