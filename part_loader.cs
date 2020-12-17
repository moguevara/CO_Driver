using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using CO_Driver.Properties;
using System.Globalization;

namespace CO_Driver
{
    public class part_loader
    {
        public class Part
        {
            public string description { get; set; }
            public int faction { get; set; }
            public int level { get; set; }
            public int hull_durability { get; set; }
            public int part_durability { get; set; }
            public int mass { get; set; }
            public int power_score { get; set; }
            public double pass_through { get; set; }
            public double bullet_resistance { get; set; }
            public double melee_resistance { get; set; }
        }

        public class Weapon
        {
            public string name { get; set; }
            public string description { get; set; }
            public int rarity { get; set; }
            public int energy { get; set; }
            public double base_damage { get; set; }
            public int mass { get; set; }
            public int durability { get; set; }
            public int power_score { get; set; }
            public string weapon_class { get; set;}
        }

        public class Cabin
        {
            public string name { get; set; }
            public string description { get; set; }
            public int rarity { get; set; }
            public int energy { get; set; }
            public int base_speed { get; set; }
            public int mass_limit { get; set; }
            public int tonnage { get; set; }
            public int mass { get; set; }
            public int durability { get; set; }
            public int power_score { get; set; }
            public string cabin_class { get; set; }
        }

        public class Module
        {
            public string name { get; set; }
            public string description { get; set; }
            public int rarity { get; set; }
            public int energy { get; set; }
            public int durability { get; set; } //i hate that durability and mass are swapped
            public int mass { get; set; } //but im not sure how to fix it...
            public int power_score { get; set; }
            public string module_class { get; set; }
        }

        public class Engine
        {
            public string name { get; set; }
            public string description { get; set; }
            public int rarity { get; set; }
            public int energy { get; set; }
            public int durability { get; set; }
            public int mass { get; set; }
            public int power_score { get; set; }
            public int tonnage { get; set; }
            public int mass_limit { get; set; }
            public int speed_bonus { get; set; }
            public int power_bonus { get; set; }
        }

        public class Explosive
        {
            public string name { get; set; }
            public string description { get; set; }
            public int rarity { get; set; }
            public int energy { get; set; }
            public int durability { get; set; }
            public int mass { get; set; }
            public int power_score { get; set; }
            public int blast_damage { get; set; }
            public string explosive_class { get; set; }
        }

        public static Part new_part(string desc, int faction, int level, int hull, int part_dura, int mass, int power_score, double pass_through, double bullet_resist, double melee_resist)
        {
            return new Part
            {
                description = desc,
                faction = faction,
                level = level,
                hull_durability = hull,
                part_durability = part_dura,
                mass = mass,
                power_score = power_score,
                pass_through = pass_through,
                bullet_resistance = bullet_resist,
                melee_resistance = melee_resist
            };
        }

        public static Weapon new_weapon(string name, string desc, int rarity, int energy, double base_damage, int mass, int dura, int ps, string weapon_class)
        {
            return new Weapon
            {
                name = name,
                description = desc,
                rarity = rarity,
                energy = energy,
                base_damage = base_damage,
                mass = mass,
                durability = dura,
                power_score = ps,
                weapon_class = weapon_class
            };
        }

        public static Cabin new_cabin(string name, string desc, int rarity, int energy, int speed, int mass_lim, int tonnage, int mass, int dura, int ps, string cabin_class)
        {
            return new Cabin
            {
                name = name,
                description = desc,
                rarity = rarity,
                energy = energy,
                base_speed = speed,
                mass_limit = mass_lim,
                tonnage = tonnage,
                mass = mass,
                durability = dura,
                power_score = ps,
                cabin_class = cabin_class
            };
        }

        public static Module new_module(string name, string desc, int rarity, int energy, int dura, int mass, int ps, string module_class)
        {
            return new Module
            {
                name = name,
                description = desc,
                rarity = rarity,
                energy = energy,
                durability = dura,
                mass = mass,
                power_score = ps,
                module_class = module_class
            };
        }
        public static Engine new_engine(string name, string desc, int rarity, int energy, int dura, int mass, int ps, int tonnage, int mass_lim, int speed, int power)
        {
            return new Engine
            {
                name = name,
                description = desc,
                rarity = rarity,
                energy = energy,
                durability = dura,
                mass = mass,
                power_score = ps,
                tonnage = tonnage,
                mass_limit = mass_lim,
                speed_bonus = speed,
                power_bonus = power
            };
        }

        public static Explosive new_explosive(string name, string desc, int rarity, int energy, int dura, int mass, int ps, int blast, string explosive_class)
        {
            return new Explosive
            {
                name = name,
                description = desc,
                rarity = rarity,
                energy = energy,
                durability = dura,
                mass = mass,
                power_score = ps,
                blast_damage = blast,
                explosive_class = explosive_class
            };
        }

        public static void populate_weapon_list(file_trace_managment.SessionStats Current_session)
        {
            //MACHINE GUNS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_Starter", "SM Hornet", global_data.BASE_RARITY, 2, 2.71, 144, 60, 170, "machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun", "LM-54 Chord", global_data.COMMON_RARITY, 2, 3.11, 144, 60, 170, "machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_Frontal", "ST-M23 Defender", global_data.RARE_RARITY, 3, 7.2, 144, 140, 390, "frontal machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_rare", "Vector", global_data.RARE_RARITY, 3, 7.07, 171, 74, 390, "machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_SMG", "M-37 Piercer", global_data.SPECIAL_RARITY, 3, 7.7, 195, 133, 570, "rapid-fire machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_Preepic", "Sinus-0", global_data.SPECIAL_RARITY, 3, 7.56, 185, 90, 570, "machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_ParticleBeam", "Aurora", global_data.EPIC_RARITY, 4, 1.08, 315, 275, 1100, "laser minigun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_SmartMachinegun", "Caucasus", global_data.EPIC_RARITY, 4, 11.3, 824, 314, 1100, "automatic machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_Frontal_Epic", "M-29 Protector", global_data.EPIC_RARITY, 3, 8.9, 170, 213, 825, "frontal machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_SMG_Epic", "M-38 Fidget", global_data.EPIC_RARITY, 3, 7.4, 220, 145, 825, "rapid-fire machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Minigun", "MG13 Equalizer", global_data.EPIC_RARITY, 3, 3.8, 216, 163, 825, "minigun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Carabine", "R-37-39 Adapter", global_data.EPIC_RARITY, 4, 12.28, 240, 154, 1100, "reloading machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_Corner", "ST-M26 Tackler", global_data.EPIC_RARITY, 3, 16.1, 180, 228, 825, "frontal machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_Legendary", "Aspect", global_data.LEGENDARY_RARITY, 4, 9.6, 342, 220, 1600, "machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_SMG_Legend", "M-39 Imp", global_data.LEGENDARY_RARITY, 3, 8.24, 280, 209, 1200, "rapid-fire machine gun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Minigun_Legend", "MG14 Arbiter", global_data.LEGENDARY_RARITY, 3, 4, 279, 186, 1200, "minigun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_CannonMinigun_legend", "Reaper", global_data.LEGENDARY_RARITY, 6, 12.5, 603, 520, 2400, "minigun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Machinegun_Relic", "Punisher", global_data.RELIC_RARITY, 4, 11, 430, 368, 2400, "machine gun"));
            //SHOTGUNS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun", "Lupara", global_data.COMMON_RARITY, 3, 24, 68, 63, 255, "shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_rare", "Sledgehammer", global_data.RARE_RARITY, 3, 24.42, 54, 115, 390, "shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_Frontal", "Spitfire", global_data.RARE_RARITY, 3, 25.8, 126, 183, 390, "frontal shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_Fixed_Rare", "Goblin", global_data.SPECIAL_RARITY, 2, 24.54, 90, 128, 380, "frontal shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_ShotGun_Garbage", "Junkbow", global_data.SPECIAL_RARITY, 4, 144, 189, 247, 760, "reloading shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_Frontal_Preepic", "Leech", global_data.SPECIAL_RARITY, 3, 28.2, 135, 190, 570, "frontal shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_Preepic", "Mace", global_data.SPECIAL_RARITY, 3, 25.98, 65, 120, 570, "shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_NailGun_rare", "Summator", global_data.SPECIAL_RARITY, 4, 138, 180, 157, 760, "charging shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_MiddleRangeShotgun", "Arothron", global_data.EPIC_RARITY, 4, 211.2, 378, 280, 1100, "reloading shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_ShotGun_Garbage_epic", "Fafnir", global_data.EPIC_RARITY, 4, 152, 255, 315, 1100, "reloading shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_ShotGun", "Gravastar", global_data.EPIC_RARITY, 4, 42, 306, 196, 1100, "laser shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_Corner", "Rupture", global_data.EPIC_RARITY, 3, 29.4, 160, 229, 825, "frontal shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_epic", "Thunderbolt", global_data.EPIC_RARITY, 4, 39.6, 90, 173, 1100, "shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_legend", "Hammerfall", global_data.LEGENDARY_RARITY, 5, 42, 122, 221, 2000, "shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_ShotGun_Garbage_legend", "Nidhogg", global_data.LEGENDARY_RARITY, 4, 184, 290, 340, 1600, "reloading shotgun"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Shotgun_Relic", "Breaker", global_data.RELIC_RARITY, 5, 47.4, 180, 387, 3000, "shotgun"));
            //AUTOCANNONS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Cannon_rare", "AC43 Rapier", global_data.RARE_RARITY, 4, 14.3, 180, 113, 520, "autocannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Cannon_Preepic", "AC50 Storm", global_data.SPECIAL_RARITY, 4, 14.3, 210, 168, 760, "autocannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Cannon_Oneshot_preepic", "Median", global_data.SPECIAL_RARITY, 5, 150, 342, 189, 950, "reloading autocannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Lcannon_epic", "AC64 Joule", global_data.EPIC_RARITY, 4, 13.6, 240, 216, 1100, "rapid-fire autocannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Cannon_epic", "AC72 Whirlwind", global_data.EPIC_RARITY, 5, 16.2, 486, 391, 1375, "autocannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_CloseCombatCannon", "Whirl", global_data.EPIC_RARITY, 4, 32.76, 729, 457, 1100, "autocannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Cannon_Legend", "Cyclone", global_data.LEGENDARY_RARITY, 5, 21, 570, 535, 2000, "rapid-fire autocannon"));
            //CANNONS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_EX", "Avenger 57mm", global_data.COMMON_RARITY, 5, 89, 468, 217, 425, "cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_EX_rare", "Judge 76mm", global_data.RARE_RARITY, 5, 105.8, 585, 320, 650, "cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_Free_rare", "Little Boy 6LB", global_data.RARE_RARITY, 6, 110, 837, 454, 780, "turret cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_Free_Preepic", "ZS-33 Hulk", global_data.SPECIAL_RARITY, 6, 121, 850, 583, 1140, "turret cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_EX_Preepic", "Prosecutor 76mm", global_data.SPECIAL_RARITY, 5, 118, 670, 400, 950, "cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_Free_T34_epic", "Elephant", global_data.EPIC_RARITY, 6, 126.1, 1300, 847, 1650, "turret cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_EX_epic", "Executioner 88mm", global_data.EPIC_RARITY, 5, 143.41, 864, 495, 1375, "cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_Free_epic", "ZS-34 Fat Man", global_data.EPIC_RARITY, 6, 136, 1215, 830, 1650, "turret cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_EX_Legend", "BC-17 Tsunami", global_data.LEGENDARY_RARITY, 6, 213, 1850, 746, 2400, "cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_Free_legend", "ZS-46 Mammoth", global_data.LEGENDARY_RARITY, 6, 170, 2633, 1284, 2400, "turret cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_EX_Relic", "CC-18 Typhoon", global_data.RELIC_RARITY, 6, 255, 2200, 950, 3600, "cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_BigCannon_Free_Relic", "ZS-52 Mastodon", global_data.RELIC_RARITY, 6, 75, 2855, 1505, 3600, "turret cannon"));
            //ROCKET LAUNCHERS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_AutoGuidedCourseGun_rare", "Wasp", global_data.RARE_RARITY, 4, 77.1, 90, 55, 520, "unguided rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_AutoGuidedCourseGun_Nurs_Preepic", "Pyralid", global_data.SPECIAL_RARITY, 4, 89, 98, 69, 760, "unguided rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Improv_HomingMissileLauncher_epic", "ATGM Flute", global_data.EPIC_RARITY, 2, 73.07, 81, 47, 550, "guided rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_GuidedMissile_Sniper", "Clarinet TOW", global_data.EPIC_RARITY, 5, 198.5, 270, 172, 1375, "guided rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_AutoGuidedCourseGun_epic", "Cricket", global_data.EPIC_RARITY, 5, 51.14, 288, 150, 1375, "unguided rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_AutoGuidedCourseGun_Epic2", "Locust", global_data.EPIC_RARITY, 4, 94, 110, 100, 1100, "unguided rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_HomingMissileLauncherLockOn_epic", "Nest", global_data.EPIC_RARITY, 5, 37, 288, 164, 1375, "homing rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_HomingMissileLauncher_epic", "Pyre", global_data.EPIC_RARITY, 2, 116, 81, 52, 550, "homing rocket"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_HomingMissileLauncherBurstR_legend", "Hurricane", global_data.LEGENDARY_RARITY, 6, 89, 288, 175, 2400, "homing rocket"));
            //GRENADE LAUNCHERS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_GrenadeLauncher_Auto", "GL-55 Impulse", global_data.EPIC_RARITY, 5, 50, 198, 126, 1375, "grenade launcher"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_GrenadeLauncher_Shotgun", "Retcher", global_data.LEGENDARY_RARITY, 6, 100.2, 234, 213, 2400, "grenade launcher"));
            //ENERGY WEAPONS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_FusionRifle", "Synthesis", global_data.SPECIAL_RARITY, 4, 14.18, 158, 175, 760, "plasma emitter"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Plasma_Cutter", "Blockchain", global_data.EPIC_RARITY, 4, 112, 340, 260, 1100, "electric sniper"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_FusionRifle_epic", "Prometheus", global_data.EPIC_RARITY, 4, 14.4, 200, 185, 1100, "plasma emitter"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_Plazma", "Quasar", global_data.EPIC_RARITY, 6, 135, 792, 535, 1650, "plasma cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Plasma_Drill", "Trigger", global_data.EPIC_RARITY, 4, 7, 410, 246, 1100, "reloading laser"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_LightningGun", "Assembler", global_data.LEGENDARY_RARITY, 6, 233.1, 293, 312, 2400, "electric sniper"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_FusionRifle_legend", "Helios", global_data.LEGENDARY_RARITY, 4, 15.3, 250, 225, 1600, "plasma emitter"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_Plazma_Legend", "Pulsar", global_data.LEGENDARY_RARITY, 6, 142, 950, 693, 2400, "plasma cannon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_Tesla", "Spark III", global_data.LEGENDARY_RARITY, 4, 16, 360, 435, 1600, "tesla emitter"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Syfy_Tesla_relic", "Flash I", global_data.RELIC_RARITY, 4, 20, 450, 544, 2400, "tesla emitter"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_SniperCrossbow", "Scorpion", global_data.RELIC_RARITY, 6, 280, 900, 552, 3600, "electric sniper"));
            //CROSSBOWS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Blast_ClassicCrossbow", "Phoenix", global_data.EPIC_RARITY, 5, 178, 1012, 418, 1375, "crossbow"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_ClassicCrossbow", "Spike-1", global_data.EPIC_RARITY, 4, 180, 810, 305, 1100, "crossbow"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_DoubleCrossbow", "Toadfish", global_data.LEGENDARY_RARITY, 4, 140, 900, 384, 1600, "crossbow"));
            //MELEE WEAPONS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Drill_epic", "Borer", global_data.RARE_RARITY, 2, 20, 250, 330, 260, "grinding melee"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_SpearExplosive", "Boom", global_data.SPECIAL_RARITY, 1, 199.76, 45, 31, 190, "explosive melee"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Roundsaw_rare", "Buzzsaw", global_data.SPECIAL_RARITY, 2, 33, 125, 279, 380, "grinding melee"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Chainsaw_dble_epic", "Lacerator", global_data.EPIC_RARITY, 3, 50, 188, 401, 825, "grinding melee"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_LanceExplosive", "Lancelot", global_data.EPIC_RARITY, 1, 158.32, 144, 57, 275, "explosive melee"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_ChainSaw_epic", "Mauler", global_data.EPIC_RARITY, 3, 49.5, 94, 327, 825, "grinding melee"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Harvester_legend", "Harvester", global_data.LEGENDARY_RARITY, 4, 30, 940, 765, 1600, "grinding melee"));
            //FLAMETHROWERS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Flamethrower_frontal", "Remedy", global_data.EPIC_RARITY, 4, 15, 300, 420, 1100, "frontal flamethrower"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Flamethrower_fixed", "Draco", global_data.LEGENDARY_RARITY, 4, 23, 270, 360, 1600, "frontal flamethrower"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Flamethrower_light", "Firebug", global_data.RELIC_RARITY, 4, 25, 315, 540, 2400, "flamethrower"));
            //HARPOONS AND MINELAYERS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_MineTrap", "Kapkan", global_data.EPIC_RARITY, 2, 0, 360, 267, 550, "harpoon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Harpoon", "Skinner", global_data.EPIC_RARITY, 2, 0.1, 378, 308, 550, "harpoon"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_MineLauncher_Legend", "King", global_data.EPIC_RARITY, 3, 119.26, 540, 240, 825, "minelayer"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_WheelRocket", "Fortune", global_data.LEGENDARY_RARITY, 5, 85, 360, 288, 2000, "minelayer"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_MineLauncher", "Porcupine", global_data.RELIC_RARITY, 3, 174.21, 720, 384, 1800, "minelayer"));
            //ARTILLERY
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Catapult", "Incinerator", global_data.EPIC_RARITY, 6, 2.5, 540, 472, 1650, "artillery"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Mortar_Revert", "Mandrake", global_data.LEGENDARY_RARITY, 8, 110, 2430, 689, 3200, "artillery"));
            //TURRETS AND DRONES
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Quadrocopter_rare", "AD-12 Falcon", global_data.RARE_RARITY, 3, 10, 128, 126, 390, "drone"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_TurretDeployer_rare", "DT Cobra", global_data.RARE_RARITY, 3, 10, 128, 126, 390, "turret"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Quadrocopter_preepic", "AD-13 Hawk", global_data.SPECIAL_RARITY, 3, 12.32, 128, 141, 570, "drone"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_WheelDroneDeployer", "Sidekick", global_data.SPECIAL_RARITY, 4, 15.3, 256, 141, 760, "drone"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_TurretDeployer_Preepic", "T4 Python", global_data.SPECIAL_RARITY, 3, 11.2, 128, 141, 570, "turret"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_TurretDeployer_Shield", "Barrier IX", global_data.EPIC_RARITY, 3, 0, 128, 161, 825, "turret"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_kamikazeDroneDeployer", "Fuze", global_data.EPIC_RARITY, 4, 134.1, 128, 161, 1100, "drone"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_WheelDroneDeployer_epic", "Grenadier", global_data.EPIC_RARITY, 4, 33.6, 180, 141, 1100, "drone"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Quadrocopter_epic", "MD-3 Owl", global_data.EPIC_RARITY, 4, 100.8, 128, 161, 1100, "drone"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_TurretDeployerMissile_epic", "RT Anaconda", global_data.EPIC_RARITY, 4, 101, 256, 321, 1100, "turret"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Quadrocopter_Syfy", "Annihilator", global_data.LEGENDARY_RARITY, 4, 12, 200, 190, 1600, "drone"));
            //REVOLVERS
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_MGL_rare", "Emily", global_data.SPECIAL_RARITY, 4, 38.5, 160, 100, 760, "revolver"));
            Current_session.global_weapon_list.Add(new_weapon("CarPart_Gun_Revolver_epic", "Corvo", global_data.EPIC_RARITY, 4, 20, 200, 160, 1100, "revolver"));
        }

        public static void populate_global_parts_list(file_trace_managment.SessionStats Current_session)
        {
            //ENGINEER 1
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 1, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 1, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 1, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 2
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.ENGINEER_FACTION, 2, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Catch", global_data.ENGINEER_FACTION, 2, 0, 53, 72, 21, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.ENGINEER_FACTION, 2, 41, 41, 80, 52, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.ENGINEER_FACTION, 2, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 2, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 2, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 2, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 2, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 2, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 2, 13, 13, 28, 11, 0.0, 0, 0));
            //ENGINEER 3
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.ENGINEER_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 3, 0, 7, 7, 21, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 3, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 3, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.ENGINEER_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 3, 15, 15, 34, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 3, 15, 15, 34, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 3, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 3, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 3, 23, 23, 51, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 3, 23, 23, 51, 20, 0.0, 0, 0));
            //ENGINEER 4
            Current_session.global_parts_list.Add(new_part("Gun Mount", global_data.ENGINEER_FACTION, 4, 0, 38, 43, 133, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 4, 0, 31, 42, 12, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 4, 0, 31, 42, 12, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 4, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 4, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 5
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 5, 0, 8, 9, 28, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 5, 0, 8, 9, 28, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 5, 60, 60, 135, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 6
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 6, 0, 7, 7, 21, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 6, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 6, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 6, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 6, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Offroad Bumper", global_data.ENGINEER_FACTION, 6, 0, 139, 192, 56, 0.0, 0, 0.9));
            //ENGINEER 7
            Current_session.global_parts_list.Add(new_part("Rear Door", global_data.ENGINEER_FACTION, 7, 86, 86, 196, 77, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 7, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 7, 6, 6, 12, 4, 0.0, 0, 0));
            //ENGINEER 8
            Current_session.global_parts_list.Add(new_part("Gun Mount", global_data.ENGINEER_FACTION, 8, 0, 38, 43, 133, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 8, 23, 23, 51, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 8, 23, 23, 51, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 8, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 8, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 9
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 9, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Catch", global_data.ENGINEER_FACTION, 9, 0, 53, 72, 21, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 9, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 9, 13, 13, 28, 11, 0.0, 0, 0));
            //ENGINEER 10
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 10, 15, 15, 34, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 10, 15, 15, 34, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 10, 60, 60, 135, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 10, 60, 60, 135, 53, 0.0, 0, 0));
            //ENGINEER 11
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 11, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 11, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Offroad Bumper", global_data.ENGINEER_FACTION, 11, 0, 139, 192, 56, 0.0, 0, 0.9));
            //ENGINEER 12 
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 12, 0, 7, 7, 21, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 12, 0, 7, 7, 21, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 12, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 12, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 12, 60, 60, 135, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 12, 60, 60, 135, 53, 0.0, 0, 0));
            //ENGINEER 13
            Current_session.global_parts_list.Add(new_part("Buggy Floor", global_data.ENGINEER_FACTION, 13, 0, 16, 18, 56, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Floor", global_data.ENGINEER_FACTION, 13, 0, 16, 18, 56, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Rear Door", global_data.ENGINEER_FACTION, 13, 86, 86, 196, 77, 0.0, 0, 0));
            //ENGINEER 14
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 14, 0, 5, 5, 14, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 14, 0, 5, 5, 14, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 14, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 14, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 15
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 15, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 15, 6, 6, 12, 4, 0.0, 0, 0));
            //ENGINEER 16
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 16, 0, 5, 5, 14, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 16, 0, 5, 5, 14, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 16, 0, 31, 42, 12, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 16, 0, 31, 42, 12, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Gun Mount", global_data.ENGINEER_FACTION, 16, 0, 38, 43, 133, 0.9, 0.9, 0));
            //ENGINEER 17
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 17, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 17, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 17, 0, 8, 9, 28, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 17, 0, 8, 9, 28, 0.9, 0.9, 0));
            //ENGINEER 18
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 18, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 18, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 18, 0, 8, 9, 28, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 18, 0, 8, 9, 28, 0.9, 0.9, 0));
            //ENGINEER 19
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 19, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 19, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 19, 15, 15, 34, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 19, 15, 15, 34, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 19, 23, 23, 51, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 19, 23, 23, 51, 20, 0.0, 0, 0));
            //ENGINEER 20
            Current_session.global_parts_list.Add(new_part("Torino Rear", global_data.ENGINEER_FACTION, 20, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Nosecut", global_data.ENGINEER_FACTION, 20, 40, 40, 90, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 20, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 20, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 21
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 21, 0, 7, 7, 21, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 21, 0, 7, 7, 21, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 21, 23, 23, 51, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 21, 23, 23, 51, 20, 0.0, 0, 0));
            //ENGINEER 22
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 22, 0, 8, 9, 28, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 22, 0, 8, 9, 28, 0.9, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 22, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 22, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 23
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 23, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 23, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Door", global_data.ENGINEER_FACTION, 23, 86, 86, 196, 77, 0.0, 0, 0));
            //ENGINEER 24
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 24, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 24, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 24, 60, 60, 135, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 24, 60, 60, 135, 53, 0.0, 0, 0));
            //ENGINEER 25
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 25, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 25, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Bonnet", global_data.ENGINEER_FACTION, 25, 94, 94, 213, 84, 0.0, 0, 0));
            //ENGINEER 26
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 26, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 26, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Nosecut", global_data.ENGINEER_FACTION, 26, 40, 40, 90, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 26, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 26, 20, 20, 45, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Rear", global_data.ENGINEER_FACTION, 26, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 27
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 27, 25, 25, 56, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 27, 25, 25, 56, 22, 0.0, 0, 0));
            //ENGINEER 28
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 28, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 28, 13, 13, 28, 11, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Bonnet", global_data.ENGINEER_FACTION, 28, 94, 94, 213, 84, 0.0, 0, 0));
            //ENGINEER 29
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 29, 6, 6, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 29, 6, 6, 12, 4, 0.0, 0, 0));
            //ENGINEER 30
            //ENGINEER PRESTIGE
            Current_session.global_parts_list.Add(new_part("Hot Rod Grille", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 23, 23, 54, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Hood", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 50, 50, 121, 40, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Left Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 22, 22, 51, 17, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Left Rear Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 34, 34, 81, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Right Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 22, 22, 51, 17, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Right Rear Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 34, 34, 81, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Trunk", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 36, 36, 85, 28, 0.0, 0, 0));
            //LUNATICS 1
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 1, 28, 28, 54, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 1, 28, 28, 54, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 1, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 1, 4, 4, 7, 4, 0.0, 0, 0));
            //LUNATICS 2
            Current_session.global_parts_list.Add(new_part("Bullbar", global_data.LUNATICS_FACTION, 2, 0, 95, 101, 49, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 2, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 2, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 2, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 2, 14, 14, 27, 18, 0.0, 0, 0));
            //LUNATICS 3
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 3, 41, 41, 80, 52, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 3, 41, 41, 80, 52, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 3, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Spike", global_data.LUNATICS_FACTION, 3, 0, 55, 58, 28, 0.0, 0, 0.9));
            //LUNATICS 4
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 4, 44, 44, 86, 56, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 4, 44, 44, 86, 56, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 4, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 4, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 4, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 4, 14, 14, 27, 18, 0.0, 0, 0));
            //LUNATICS 5
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 5, 28, 28, 54, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 5, 28, 28, 54, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 5, 41, 41, 80, 52, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 5, 41, 41, 80, 52, 0.0, 0, 0));
            //LUNATICS 6
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 6, 44, 44, 86, 56, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 6, 44, 44, 86, 56, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Left", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Left", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 6, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 6, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Right", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Right", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 6, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 6, 10, 10, 19, 12, 0.0, 0, 0));
            //LUNATICS 7
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Frontal Protection System", global_data.LUNATICS_FACTION, 7, 0, 68, 72, 35, 0.0, 0, 0.9));
            //LUNATICS 8
            Current_session.global_parts_list.Add(new_part("Bullbar", global_data.LUNATICS_FACTION, 8, 0, 95, 101, 49, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 8, 28, 28, 54, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 8, 28, 28, 54, 35, 0.0, 0, 0));
            //LUNATICS 9
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 9, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 9, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 9, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 9, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Spike", global_data.LUNATICS_FACTION, 9, 0, 55, 58, 28, 0.0, 0, 0.9));
            //LUNATICS 10
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 10, 41, 41, 80, 52, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 10, 41, 41, 80, 52, 0.0, 0, 0));
            //LUNATICS 11
            Current_session.global_parts_list.Add(new_part("Buggy Fender Left", global_data.LUNATICS_FACTION, 11, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Right", global_data.LUNATICS_FACTION, 11, 6, 6, 11, 7, 0.0, 0, 0));
            //LUNATICS 12
            Current_session.global_parts_list.Add(new_part("Buggy Bumper", global_data.LUNATICS_FACTION, 12, 0, 81, 86, 42, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 12, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 12, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, 0.0, 0, 0));
            //LUNATICS 13
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 13, 44, 44, 86, 56, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 13, 44, 44, 86, 56, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Spike", global_data.LUNATICS_FACTION, 13, 0, 55, 58, 28, 0.0, 0, 0.9));
            //LUNATICS 14
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 14, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 14, 8, 8, 14, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 14, 41, 41, 80, 52, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 14, 41, 41, 80, 52, 0.0, 0, 0));
            //LUNATICS 15
            Current_session.global_parts_list.Add(new_part("Buggy Bumper", global_data.LUNATICS_FACTION, 15, 0, 81, 86, 42, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Frontal Protection System", global_data.LUNATICS_FACTION, 15, 0, 68, 72, 35, 0.0, 0, 0.9));
            //LUNATICS PRESTIGE
            Current_session.global_parts_list.Add(new_part("Powerslide", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 68, 68, 138, 88, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Shielded Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 7, 7, 12, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Shielded Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 7, 7, 12, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Side Guard Right", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 11, 11, 21, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Side Guard Left", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 11, 11, 21, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bully Nosecut", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bully Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 0, 68, 72, 35, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Pole Position", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 0, 89, 94, 46, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Backmarker", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 18, 18, 34, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Backmaker", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 18, 18, 34, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Bend", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 14, 14, 27, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Bend", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 14, 14, 27, 18, 0.0, 0, 0));
            //NOMADS 1
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 1, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 1, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 1, 45, 45, 108, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 1, 45, 45, 108, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 1, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 1, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMADS 2
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 2, 0, 216, 492, 155, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 2, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 2, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 2, 20, 20, 48, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 2, 23, 23, 54, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 2, 23, 23, 54, 18, 0.0, 0, 0));
            //NOMADS 3
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 3, 0, 28, 43, 17, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 3, 0, 28, 43, 17, 0.28, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 3, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 3, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 3, 54, 54, 130, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 3, 54, 54, 130, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 3, 8, 8, 19, 6, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 3, 8, 8, 19, 6, 0.0, 0, 0));
            //NOMADS 4
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 4, 5, 5, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 4, 5, 5, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 4, 20, 20, 48, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 4, 50, 50, 121, 40, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 4, 50, 50, 121, 40, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 4, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 4, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 4, 23, 23, 54, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 4, 23, 23, 54, 18, 0.0, 0, 0));
            //NOMADS 5
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 5, 5, 5, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 5, 5, 5, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 5, 45, 45, 108, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 5, 45, 45, 108, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 5, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 5, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 5, 50, 50, 121, 40, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 5, 50, 50, 121, 40, 0.0, 0, 0));
            //NOMAD 6
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 6, 53, 53, 128, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 6, 53, 53, 128, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 6, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 6, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 6, 31, 31, 74, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 6, 31, 31, 74, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMAD 7
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 7, 37, 37, 88, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 7, 37, 37, 88, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 7, 12, 12, 27, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 7, 12, 12, 27, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 7, 0, 28, 43, 17, 0.0, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 7, 23, 23, 54, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 7, 23, 23, 54, 18, 0.0, 0, 0));
            //NOMAD 8
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 8, 8, 8, 19, 6, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 8, 8, 8, 19, 6, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 8, 10, 10, 22, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 8, 10, 10, 22, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 8, 45, 45, 108, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 8, 45, 45, 108, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 8, 0, 216, 492, 155, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 8, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 8, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMAD 9
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 9, 5, 5, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 9, 5, 5, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin BladeWing", global_data.NOMADS_FACTION, 9, 0, 56, 86, 34, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Twin BladeWing", global_data.NOMADS_FACTION, 9, 0, 56, 86, 34, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 9, 54, 54, 130, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 9, 54, 54, 130, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 9, 20, 20, 48, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 9, 20, 20, 48, 15, 0.0, 0, 0));
            //NOMAD 10
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 10, 53, 53, 128, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 10, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 10, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 10, 53, 53, 128, 42, 0.0, 0, 0));
            //NOMAD 11
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 11, 0, 28, 43, 17, 0.0, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 11, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 11, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 11, 20, 20, 48, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 11, 20, 20, 48, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 11, 5, 5, 12, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 11, 5, 5, 12, 4, 0.0, 0, 0));
            //NOMAD 12
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 12, 37, 37, 88, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 12, 37, 37, 88, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 12, 12, 12, 27, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 12, 12, 12, 27, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 12, 10, 10, 24, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 12, 10, 10, 24, 8, 0.0, 0, 0));
            //NOMAD 13
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 13, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 13, 16, 16, 37, 12, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 13, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 13, 13, 13, 31, 10, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 13, 31, 31, 74, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 13, 31, 31, 74, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 13, 10, 10, 22, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 13, 10, 10, 22, 7, 0.0, 0, 0));
            //NOMAD 14
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, 0.0, 0, 0));
            //NOMAD 15
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 15, 8, 8, 19, 6, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 15, 8, 8, 19, 6, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 15, 0, 216, 492, 155, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 15, 0, 216, 492, 155, 0.0, 0, 0.9));
            //NOMAD PRESTIGE
            Current_session.global_parts_list.Add(new_part("Mariposa", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 0, 75, 115, 28, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Shoulder", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 7, 7, 16, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Shoulder", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 7, 7, 16, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Corrida Right Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 56, 56, 142, 40, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Corrida Nosecut", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 68, 68, 173, 48, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Corrida Left Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 56, 56, 142, 40, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Splitter", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 0, 72, 110, 28, 0.0, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Side Air Intake", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 20, 20, 48, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Side Air", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 20, 20, 48, 15, 0.0, 0, 0));
            //SCAVENGERS 1
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 1, 57, 57, 162, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 1, 57, 57, 162, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 1, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 1, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 2
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 2, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 2, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 2, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 2, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Terribull Bar", global_data.SCAVENGERS_FACTION, 2, 0, 161, 324, 102, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 2, 22, 22, 61, 13, 0.0, 0, 0));
            //SCAVENGERS 3
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 3, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 3, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 3, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 3, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 3, 9, 9, 23, 5, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 3, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 4
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 4, 114, 114, 323, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 4, 114, 114, 323, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 4, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 4, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 4, 22, 22, 61, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 4, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 4, 11, 11, 31, 7, 0.0, 0, 0));
            //SCAVENGERS 5
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 5, 114, 114, 323, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 5, 114, 114, 323, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 5, 57, 57, 162, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 5, 57, 57, 162, 35, 0.0, 0, 0));
            //SCAVENGERS 6
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 6, 93, 93, 263, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 6, 93, 93, 263, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 6, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 6, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 6, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 6, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 6, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 6, 11, 11, 31, 7, 0.0, 0, 0));
            //SCAVENGERS 7
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 7, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 7, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 7, 24, 24, 66, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 7, 24, 24, 66, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Train Plow", global_data.SCAVENGERS_FACTION, 7, 0, 416, 952, 300, 0.0, 0, 0.9));
            //SCAVENGERS 8
            Current_session.global_parts_list.Add(new_part("Terribull Bar", global_data.SCAVENGERS_FACTION, 8, 0, 161, 324, 102, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 8, 22, 22, 61, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 8, 22, 22, 61, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 8, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 8, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 8, 57, 57, 162, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 8, 57, 57, 162, 35, 0.0, 0, 0));
            //SCAVENGERS 9
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 9, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 9, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 9, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 9, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 9, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 9, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 9, 22, 22, 61, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 9, 22, 22, 61, 13, 0.0, 0, 0));
            //SCAVENGERS 10
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 10, 93, 93, 263, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 10, 93, 93, 263, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 10, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 10, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 10, 43, 43, 121, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 10, 43, 43, 121, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 10, 9, 9, 23, 5, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 10, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 11
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 11, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 11, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 11, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 11, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 11, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 11, 8, 8, 21, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 11, 9, 9, 23, 5, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 11, 9, 9, 23, 5, 0.0, 0, 0));
            //SCAVENGERS 12
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 12, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 12, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 12, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 12, 12, 12, 32, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 12, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 12, 36, 36, 101, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Container Wall", global_data.SCAVENGERS_FACTION, 12, 114, 114, 323, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Container Wall", global_data.SCAVENGERS_FACTION, 12, 114, 114, 323, 70, 0.0, 0, 0));
            //SCAVENGERS 13
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 13, 43, 43, 121, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 13, 43, 43, 121, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 13, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 13, 11, 11, 31, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 13, 15, 15, 41, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 13, 15, 15, 41, 9, 0.0, 0, 0));
            //SCAVENGERS 14
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 14, 93, 93, 263, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 14, 93, 93, 263, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 14, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 14, 29, 29, 81, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 14, 22, 22, 61, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 14, 22, 22, 61, 13, 0.0, 0, 0));
            //SCAVENGERS 15
            Current_session.global_parts_list.Add(new_part("Train Plow", global_data.SCAVENGERS_FACTION, 15, 0, 416, 952, 300, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 15, 24, 24, 66, 14, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 15, 24, 24, 66, 14, 0.0, 0, 0));
            //SCAVENGERS PRESTIGE
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Veil", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 0, 97, 194, 32, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Phantom Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 89, 89, 252, 55, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Phantom Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 89, 89, 252, 55, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Cover", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 48, 48, 137, 30, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Cover", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 48, 48, 137, 30, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Cover", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 48, 48, 137, 30, 0.0, 0, 0));
            //STEPPENWOLF 1
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 1, 120, 120, 359, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 1, 120, 120, 359, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 1, 8, 8, 23, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 1, 8, 8, 23, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 1, 49, 49, 146, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 1, 49, 49, 146, 29, 0.0, 0, 0));
            //STEPENWOLF 2
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 2, 94, 94, 280, 55, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 3
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 3, 120, 120, 359, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 3, 61, 61, 180, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 3, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 3, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 3, 8, 8, 23, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 3, 8, 8, 23, 4, 0.0, 0, 0));
            //STEPENWOLF 4
            Current_session.global_parts_list.Add(new_part("Defence Perimeter", global_data.STEPPENWOLFS_FACTION, 4, 0, 133, 288, 42, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 4, 94, 94, 280, 55, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 4, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 4, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 4, 49, 49, 146, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 4, 49, 49, 146, 29, 0.0, 0, 0));
            //STEPENWOLF 5
            Current_session.global_parts_list.Add(new_part("APC Rear", global_data.STEPPENWOLFS_FACTION, 5, 105, 105, 314, 62, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 5, 12, 12, 34, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 5, 12, 12, 34, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 6
            Current_session.global_parts_list.Add(new_part("Defence Line", global_data.STEPPENWOLFS_FACTION, 6, 0, 89, 192, 28, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 6, 61, 61, 180, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 6, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 6, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 6, 49, 49, 146, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 6, 49, 49, 146, 29, 0.0, 0, 0));
            //STEPENWOLF 7
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 7, 8, 8, 23, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 7, 8, 8, 23, 4, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Armored Hatch", global_data.STEPPENWOLFS_FACTION, 7, 98, 98, 293, 58, 0.0, 0, 0));
            //STEPENWOLF 8
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 8, 120, 120, 359, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 9
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 9, 53, 53, 157, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 9, 53, 53, 157, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 9, 94, 94, 280, 55, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 9, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 9, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 9, 12, 12, 34, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 9, 12, 12, 34, 7, 0.0, 0, 0));
            //STEPENWOLF 10
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 10, 120, 120, 359, 70, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 10, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 10, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Defence Perimeter", global_data.STEPPENWOLFS_FACTION, 10, 0, 133, 288, 42, 0.0, 0, 0.9));
            //STEPENWOLF 11
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 11, 53, 53, 157, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 11, 53, 53, 157, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 11, 61, 61, 180, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 11, 61, 61, 180, 35, 0.0, 0, 0));
            //STEPENWOLF 12
            Current_session.global_parts_list.Add(new_part("APC Rear", global_data.STEPPENWOLFS_FACTION, 12, 105, 105, 314, 62, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 12, 120, 120, 359, 70, 0.0, 0, 0));
            //STEPENWOLF 13
            Current_session.global_parts_list.Add(new_part("Defence Line", global_data.STEPPENWOLFS_FACTION, 13, 0, 89, 192, 28, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 13, 61, 61, 180, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 13, 61, 61, 180, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 13, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 13, 23, 23, 68, 13, 0.0, 0, 0));
            //STEPENWOLF 14
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 14, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 14, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Armored Hatch", global_data.STEPPENWOLFS_FACTION, 14, 98, 98, 293, 58, 0.0, 0, 0));
            //STEPENWOLF 15
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 15, 23, 23, 68, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 15, 94, 94, 280, 55, 0.0, 0, 0));
            //STEPENWOLF PRESTIGE
            Current_session.global_parts_list.Add(new_part("Line of Defence", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Line of Defence", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 75, 75, 224, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Vanguard", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 31, 31, 90, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Western Front", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Eastern Front", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 46, 46, 135, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Wedge", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 61, 61, 180, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Home Front", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 105, 105, 314, 62, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Barrier", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 14, 14, 40, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Barrier", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 14, 14, 40, 8, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sentry Line", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 122, 264, 39, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Rampart", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 38, 38, 112, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Rampart", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 38, 38, 112, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 90, 90, 269, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 90, 90, 269, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 76, 165, 24, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 76, 165, 24, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 76, 165, 24, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 80, 96, 56, 0.0, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 80, 96, 56, 0.0, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 80, 96, 56, 0.0, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Right APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, 0.0, 0, 0.9));
            //DAWNS CHILDREN 1
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 1, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 1, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 1, 31, 31, 79, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 1, 4, 4, 8, 2, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 1, 4, 4, 8, 2, 0.0, 0, 0));
            //DAWNS CHILDREN 2
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 2, 53, 53, 134, 37, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 2, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 2, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 2, 10, 10, 24, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 2, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 3
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 3, 4, 4, 8, 2, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 3, 4, 4, 8, 2, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 3, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 3, 19, 19, 48, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 3, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 4
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 4, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 4, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 4, 31, 31, 79, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 4, 10, 10, 24, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 4, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 5
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 5, 53, 53, 134, 37, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 5, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 5, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 5, 19, 19, 48, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 5, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 6
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 6, 10, 10, 24, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 6, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 7
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 7, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 7, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Shock Absorber", global_data.DAWNS_CHILDREN_FACTION, 7, 0, 132, 202, 77, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 7, 19, 19, 48, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 7, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 8
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 8, 53, 53, 134, 37, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 8, 4, 4, 8, 2, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 8, 4, 4, 8, 2, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 8, 10, 10, 24, 7, 0.0, 0, 0));
            //DAWNS CHILDREN 9
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 9, 53, 53, 134, 37, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 9, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 9, 62, 62, 157, 44, 0.0, 0, 0));
            //DAWNS CHILDREN 10
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 10, 10, 10, 24, 7, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 10, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 10, 19, 19, 48, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 10, 19, 19, 48, 13, 0.0, 0, 0));
            //DAWNS CHILDREN 11
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 11, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 11, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 11, 31, 31, 79, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 11, 31, 31, 79, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 11, 4, 4, 8, 2, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 11, 4, 4, 8, 2, 0.0, 0, 0));
            //DAWNS CHILDREN 12
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 12, 53, 53, 134, 37, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 12, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 12, 28, 28, 71, 20, 0.0, 0, 0));
            //DAWNS CHILDREN 13
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 13, 31, 31, 79, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 13, 4, 4, 8, 2, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 13, 4, 4, 8, 2, 0.0, 0, 0));
            //DAWNS CHILDREN 14
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 14, 53, 53, 134, 37, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 14, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 14, 28, 28, 71, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 14, 31, 31, 79, 22, 0.0, 0, 0));
            //DAWNS CHILDREN 15
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 15, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Shock Absorber", global_data.DAWNS_CHILDREN_FACTION, 15, 0, 132, 202, 77, 0.25, 0.0, 0.9));
            //DAWNS CHILDREN PRESTIGE
            Current_session.global_parts_list.Add(new_part("Rump", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 25, 25, 48, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Phalanx", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 13, 13, 24, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Phalanx", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 13, 13, 24, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Rib", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 19, 19, 37, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Rib", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 19, 19, 37, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cranium", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 55, 58, 28, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Large Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, 0.0, 0, 0));
            //FIRESTARTER 1
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 1, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 1, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, 0.0, 0, 0));
            //FIRESTARTER 2
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 2, 47, 47, 99, 48, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 2, 47, 47, 99, 48, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Nibbler", global_data.FIRESTARTERS_FACTION, 2, 0, 71, 86, 32, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 2, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 2, 22, 22, 45, 22, 0.0, 0, 0));
            //FIRESTARTER 3
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 3, 17, 17, 36, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 3, 17, 17, 36, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 3, 0, 44, 53, 19, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 3, 0, 44, 53, 19, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 3, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 4
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 4, 47, 47, 99, 48, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 4, 47, 47, 99, 48, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 4, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 4, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 4, 28, 28, 59, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 4, 28, 28, 59, 29, 0.0, 0, 0));
            //FIRESTARTER 5
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 5, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 5, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 5, 45, 45, 95, 46, 0.0, 0, 0));
            //FIRESTARTER 6
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 6, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 6, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 6, 28, 28, 59, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 6, 28, 28, 59, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 6, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 7
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 7, 47, 47, 99, 48, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 7, 13, 13, 27, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 7, 13, 13, 27, 13, 0.0, 0, 0));
            //FIRESTARTER 8
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 8, 0, 44, 53, 19, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 8, 45, 45, 95, 46, 0.0, 0, 0));
            //FIRESTARTER 9
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Stranglehold", global_data.FIRESTARTERS_FACTION, 9, 0, 79, 96, 35, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 9, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 10
            Current_session.global_parts_list.Add(new_part("Nibbler", global_data.FIRESTARTERS_FACTION, 10, 0, 71, 86, 32, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 10, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 10, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 10, 28, 28, 59, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 10, 28, 28, 59, 29, 0.0, 0, 0));
            //FIRESTARTER 11
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 11, 13, 13, 27, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 11, 13, 13, 27, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 11, 45, 45, 95, 46, 0.0, 0, 0));
            //FIRESTARTER 12
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 12, 47, 47, 99, 48, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 12, 0, 44, 53, 19, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 12, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 12, 30, 30, 63, 31, 0.0, 0, 0));
            //FIRESTARTER 13
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 13, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 13, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 13, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 13, 15, 15, 32, 15, 0.0, 0, 0));
            //FIRESTARTER 14
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 14, 45, 45, 95, 46, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Stranglehold", global_data.FIRESTARTERS_FACTION, 14, 0, 79, 96, 35, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 14, 28, 28, 59, 29, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 14, 28, 28, 59, 29, 0.0, 0, 0));
            //FIRESTARTER 15
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, 0.0, 0, 0));
            //FIRESTARTER PRESTIGE
            Current_session.global_parts_list.Add(new_part("The Omen", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 71, 86, 32, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Death Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 19, 19, 48, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Death Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 19, 19, 48, 13, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Finale", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 56, 56, 135, 44, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, 0.9, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Plaster", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Plaster", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 15, 15, 32, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bandage", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 26, 26, 54, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bandage", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 26, 26, 54, 26, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Vial", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.9, 0.0, 0));
            Current_session.global_parts_list.Add(new_part("Pill", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 17, 17, 36, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 64, 64, 135, 66, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 64, 64, 135, 66, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 20, 24, 14, 0.25, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Small Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 20, 24, 14, 0.25, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Medium Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 40, 48, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Medium Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 40, 48, 28, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Flayer", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 95, 115, 42, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Flayer", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 95, 115, 42, 0.0, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Large Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 80, 96, 56, 0.25, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Large Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 80, 96, 56, 0.25, 0.0, 0.9));
            //FOUNDERS
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Side", global_data.FOUNDERS_FACTION, 1, 62, 62, 157, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Side", global_data.FOUNDERS_FACTION, 1, 62, 62, 157, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Side", global_data.FOUNDERS_FACTION, 1, 62, 62, 157, 31, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, 0.0, 0, 0));
        }
    }
}
