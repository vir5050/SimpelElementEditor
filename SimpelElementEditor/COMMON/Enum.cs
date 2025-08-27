using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SimpelElementEditor.COMMON
{ //ENUM ARE NOT CHECKED AND PROLLY SOME ARE BROKEN!!

    [Flags]
    public enum CharacterClassFlags
    {
        None = 0,
        Beginner = 1 << 0,
        Rogue = 1 << 1,
        Ranger = 1 << 2,
        Dragoon = 1 << 3,
        Shaman = 1 << 4,
        Conjurer = 1 << 5,
        Mystic = 1 << 6,
        Defiler = 1 << 7,
        Assassin = 1 << 8,
        Marksman = 1 << 9,
        Seeker = 1 << 10,
        Guardian = 1 << 11,
        Vanguard = 1 << 12,
        Templar = 1 << 13,
        Heretic = 1 << 14,
        Prmncr = 1 << 15,
        Tempest = 1 << 16,
        Priest = 1 << 17,
        Shura = 1 << 18,
        Hellion = 1 << 19,
        Warlord = 1 << 20,
        Ruiner = 1 << 21,
        Maven = 1 << 22,
        Seraph = 1 << 23,
        Magus = 1 << 24
    }

    [Flags]
    public enum ProcTypeFlags
    {
        None = 0x0000,
        NoDrop = 0x0001,   // 死亡时不掉落
        NoThrow = 0x0002,   // 无法扔在地上
        NoSell = 0x0004,   // 无法卖给NPC
        CashItem = 0x0008,   // 人民币物品
        NoTrade = 0x0010,   // 玩家间不能交易
        TaskItem = 0x0020,   // 是任务物品
        BindOnEquip = 0x0040,   // 装备后即绑定的物品
        CanUnbind = 0x0080,   // 是否可以解绑
        NoSave = 0x0100,   // 离开场景时消失
        AutoUse = 0x0200,   // 自动使用
        DeathDrop = 0x0400,   // 死亡掉落
        LeaveDrop = 0x0800,   // 下线掉落
        Unrepairable = 0x1000,   // 不可修理
        DamagedOnPKDeath = 0x2000,   // 玩家pk被杀死后，物品损毁
        NoPutInUserTrash = 0x4000,   // 不可放入帐号仓库物品
        Bound = 0x8000,   // 是已经绑定的物品
        CanWebTrade = 0x10000,  // 可以在寻宝网交易
        MallItem = 0x20000   // 从乾坤袋购买的物品，赠品除
                             // enz...
    }

    public enum ADDON_TYPE
    {
        [Description("Melee Weapon")]
        Weapon = 0,
        [Description("Body Armor")]
        Armor = 1,
        [Description("Magic Accessory")]
        Accessory = 2,
        [Description("Usable Item")]
        Consumable = 3
    }
    public enum WORLDS
    {
        [Description("Login")]
        Login = 0,
        [Description("Gaap Lands")]
        Gaap_Lands = 1,
        [Description("Gallio")]
        Galio = 2,
        [Description("River Temple")]
        River_Temple = 3
    }


    public enum BOOL
    {
        [Description("False")]
        False = 0,
        [Description("True")]
        True = 1
    }

    public enum REPU_TYPE
    {
        [Description("Amaymonia Virtue")]
        AMAYMONIA_VIRTUE = 0,

        [Description("Korson Heights Virtue")]
        KORSON_HEIGHTS_VIRTUE = 1,

        [Description("Gaap Lands Virtue")]
        GAAP_LANDS_VIRTUE = 2,

        [Description("Ziminian Domain Virtue")]
        ZIMINIAN_DOMAIN_VIRTUE = 3,

        [Description("Scalen Bond")]
        SCALEN_BOND = 4,

        [Description("Aerax Bond")]
        AERAX_BOND = 5,

        [Description("Vena Bond")]
        VENA_BOND = 6,

        [Description("7")]
        EMPTY_100007 = 7,

        [Description("8")]
        EMPTY_100008 = 8,

        [Description("9")]
        EMPTY_100009 = 9,

        [Description("Buyer Credit")]
        BUYER_CREDIT = 10,

        [Description("Charisma")]
        CHARISMA = 11,

        [Description("Elmenta Bond")]
        ELMENTA_BOND = 12,

        [Description("Mechen Bond")]
        MECHEN_BOND = 13,

        [Description("Haunten Bond")]
        HAUNTEN_BOND = 14,

        [Description("Humanoid Bond")]
        HUMANOID_BOND = 15,

        [Description("Beastkin Bond")]
        BEASTKIN_BOND = 16,

        [Description("Florax Bond")]
        FLORAX_BOND = 17,

        [Description("Karma")]
        KARMA = 18,

        [Description("Reputation")]
        REPUTATION = 19,

        [Description("Culture")]
        CULTURE = 20,

        [Description("Gems")]
        GEMS = 21,

        [Description("Honor")]
        HONOR = 22,

        [Description("Achievements")]
        ACHIEVEMENTS = 23,

        [Description("Personal Funds")]
        PERSONAL_FUNDS = 24,

        [Description("24")]
        EMPTY_100025 = 25,

        [Description("26")]
        EMPTY_100026 = 26,

        [Description("27")]
        EMPTY_100027 = 27,

        [Description("28")]
        EMPTY_100028 = 28,

        [Description("29")]
        EMPTY_100029 = 29,

        [Description("30")]
        EMPTY_100030 = 30,

        [Description("31")]
        EMPTY_100031 = 31,

        [Description("Valor")]
        VALOR = 32,

        [Description("Astral Virtue")]
        ASTRAL_VIRTUE = 33,

        [Description("Clan Activity")]
        CLAN_ACTIVITY = 34,
    }

    public enum EQUIPMENT_ADDON_TYPE
    {
        None = 0,
        FerusAffinity = 1,
        FloraAffinity = 2,
        TerraAffinity = 3,
        AquanAffinity = 4,
        PyrosAffinity = 5,
        ChaosAffinity = 6,
        ChaosAffinityDuplicate = 7,
        ElementalAffinity = 8,
        Health = 10,
        Mana = 11,
        Vigor = 12,
        Strength = 14,
        Intellect = 15,
        Defense = 16,
        Resistance = 17,
        FerusAffinityPercent = 18,
        FloraAffinityPercent = 19,
        TerraAffinityPercent = 20,
        AquanAffinityPercent = 21,
        PyrosAffinityPercent = 22,
        ChaosAffinityPercent = 23,
        ChaosAffinityPercentDuplicate = 24,
        HealthPercent = 25,
        ManaPercent = 26,
        StrengthPercent = 29,
        IntellectPercent = 30,
        DefensePercent = 31,
        ResistancePercent = 32,
        ExperienceGainPercent = 33,
        GoldGainPercent = 34,
        ReducesDamageTakenPercent = 36,
        SkillLevel = 41,
        HealthRegenPercent = 42,
        ManaRegenPercent = 43,
        NascencePercent = 44,
        CSRPercent = 46,
        CSBPercent = 47,
        CCRPercent = 48,
        CCDPercent = 49,
        MovementSpeed = 50,
        Accuracy = 51,
        Resilience = 52,
        SkillStageLevel = 53,
        DefenseResistance = 54,
        StrengthIntellect = 55,
        StrengthResistance = 56,
        DefenseIntellect = 57,
        PetFerusAffinity = 58,
        PetFloraAffinity = 59,
        PetTerraAffinity = 60,
        PetAquanAffinity = 61,
        PetPyrosAffinity = 62,
        PetChaosAffinity = 63,
        PetCombat = 64,
        PetHP = 65,
        PetSTR = 66,
        PetINT = 67,
        PetDEF = 68,
        PetRESIST = 69,
        PetDEF2 = 70,
        PetFerusAffinityPercent = 71,
        PetFerusAffinityPercentDuplicate = 72,
        PetFloraAffinityPercent = 73,
        PetTerraAffinityPercent = 74,
        PetAquanAffinityPercent = 75,
        PetPyrosAffinityPercent = 76,
        PetChaosAffinityPercent = 77,
        PetHPPercent = 78,
        PetSTRPercent = 79,
        PetINTPercent = 80,
        PetDEFPercent = 81,
        PetRESISTPercent = 82,
        PetDamageTake = 83,
        PetDamageTakePercent = 84,
        PetLevel = 85,
        PetCooldown = 86,
        AdditionalPetDamage = 87,
        PetSkillLevel = 88,
        PetHPRegenPercent = 89,
        PetCSRPercent = 90,
        PetCSDPercent = 91,
        PetCCRPercent = 92,
        PetCCDPercent = 93,
        PetSpeedPercent = 94,
        PetACC = 95,
        PetRESL = 96,
        PetSkillLevel2 = 97,
        PetDEFRESIST = 98,
        PetSTRINT = 99,
        PetINTRESIST = 100,
        PetDEFINT = 101,
        FerusResistance = 102,
        FloraResistance = 103,
        AquanResistance = 104,
        PyrosResistance = 105,
        TerraResistance = 106,
        CombatResistance = 107,
        ChaosResistance = 108,
        FerusResistancePercent = 109,
        FloraResistancePercent = 110,
        AquanResistancePercent = 111,
        PyrosResistancePercent = 112,
        TerraResistancePercent = 113,
        CombatResistancePercent = 114,
        ChaosResistancePercent = 115,
        CritstrikeEvasion = 116,
        CritstrikeEvasionRate = 117,
        CritcastEvasionChance = 118,
        CritcastEvasionRate = 119,
        PoisonSuccessRate = 120,
        BleedSuccessRate = 121,
        StunSuccessRate = 122,
        SleepSuccessRate = 123,
        TangleSuccessRate = 124,
        SlowSuccessRate = 125,
        SilenceSuccessRate = 126,
        BlindSuccessRate = 127,
        WeakSuccessRate = 128,
        DispellSuccessRate = 129,
        KnockbackSuccessRate = 130,
        ReservedSuccessRate = 131,
        PoisonResistRate = 132,
        BleedResistRate = 133,
        StunResistRate = 134,
        SleepResistRate = 135,
        TangleResistRate = 136,
        SlowResistRate = 137,
        SilenceResistRate = 138,
        BlindResistRate = 139,
        WeakResistRate = 140,
        DispellResistRate = 141,
        KnockbackResistRate = 142,
        ReservedResistRate = 143,
        ReduceLvOfGearPercent = 144
    }


    public enum MONSTER_TYPE
    {
        [Description("Scalen")]
        SCALEN = 0,
        [Description("Aerax")]
        AERAX = 1,
        [Description("Vena")]
        VENA = 2,
        [Description("Elementa")]
        ELEMENTA = 3,
        [Description("Mechen")]
        MECHEN = 4,
        [Description("Haunten")]
        HAUNTEN = 5,
        [Description("Humanoid")]
        HUMANOID = 6,
        [Description("Beastkin")]
        BEASTKIN = 7,
        [Description("Florax")]
        FLORAX = 8,
        [Description("Demonix")]
        DEMONIX = 9
    }
    public enum ChatChannel
    {
        [Description("Local Chat")]
        GP_CHAT_LOCAL = 0,
        [Description("Farcry Chat")]
        GP_CHAT_FARCRY = 1,
        [Description("Team Chat")]
        GP_CHAT_TEAM = 2,
        [Description("Faction Chat")]
        GP_CHAT_FACTION = 3,
        [Description("Whisper Chat")]
        GP_CHAT_WHISPER = 4,
        [Description("Damage Chat")]
        GP_CHAT_DAMAGE = 5,
        [Description("Fight Chat")]
        GP_CHAT_FIGHT = 6,
        [Description("Trade Chat")]
        GP_CHAT_TRADE = 7,
        [Description("System Chat")]
        GP_CHAT_SYSTEM = 8,
        [Description("Broadcast Chat")]
        GP_CHAT_BROADCAST = 9,
        [Description("Miscellaneous Chat")]
        GP_CHAT_MISC = 10,
        [Description("Family Chat")]
        GP_CHAT_FAMILY = 11,
        [Description("Max Chat Channel")]
        GP_CHAT_MAX = 12,
    }

    [Flags]
    public enum GenderFlags
    {
        None = 0,
        Male = 1 << 0,
        Female = 1 << 1
    }

    [Flags]
    public enum EquipInventoryItemType
    {
        None = 0,

        [Description("Melee Weapon")]
        EQUIPIVTR_WEAPON_MELEE = 1 << 0,

        [Description("Ranged Weapon")]
        EQUIPIVTR_WEAPON_RANGE = 1 << 1,

        [Description("Body")]
        EQUIPIVTR_BODY = 1 << 2,

        [Description("Shoulder")]
        EQUIPIVTR_SHOULDER = 1 << 3,

        [Description("Leg")]
        EQUIPIVTR_LEG = 1 << 4,

        [Description("Foot")]
        EQUIPIVTR_FOOT = 1 << 5,

        [Description("Waist")]
        EQUIPIVTR_WAIST = 1 << 6,

        [Description("Wrist")]
        EQUIPIVTR_WRIST = 1 << 7,

        [Description("Head")]
        EQUIPIVTR_HEAD = 1 << 8,

        [Description("Finger 1")]
        EQUIPIVTR_FINGER1 = 1 << 9,

        [Description("Finger 2")]
        EQUIPIVTR_FINGER2 = 1 << 10,

        [Description("Mantle")]
        EQUIPIVTR_MANTLE = 1 << 11,

        [Description("Fashion Head")]
        EQUIPIVTR_FASHION_HEAD = 1 << 12,

        [Description("Fashion Body")]
        EQUIPIVTR_FASHION_BODY = 1 << 13,

        [Description("Fashion Eye")]
        EQUIPIVTR_FASHION_EYE = 1 << 14,

        [Description("Fashion Nose")]
        EQUIPIVTR_FASHION_NOSE = 1 << 15,

        [Description("Fashion Lip")]
        EQUIPIVTR_FASHION_LIP = 1 << 16,

        [Description("Fashion Ear")]
        EQUIPIVTR_FASHION_EAR = 1 << 17,

        [Description("Main Talisman")]
        EQUIPIVTR_MAIN_TALISMAN = 1 << 18,

        [Description("Medal")]
        EQUIPIVTR_MEDAL = 1 << 19,

        [Description("Saddle")]
        EQUIPIVTR_SADDLE = 1 << 20,

        [Description("Chest")]
        EQUIPIVTR_CHEST = 1 << 21,

        [Description("Compass")]
        EQUIPIVTR_COMPASS = 1 << 22,

        [Description("Churinga 1")]
        EQUIPIVTR_CHURINGA1 = 1 << 23,

        [Description("Churinga 2")]
        EQUIPIVTR_CHURINGA2 = 1 << 24,

        [Description("Churinga 3")]
        EQUIPIVTR_CHURINGA3 = 1 << 25,

        [Description("Churinga 4")]
        EQUIPIVTR_CHURINGA4 = 1 << 26,

        [Description("Churinga 5")]
        EQUIPIVTR_CHURINGA5 = 1 << 27,

        [Description("Churinga 6")]
        EQUIPIVTR_CHURINGA6 = 1 << 28
    }

    [Flags]
    public enum RaceFlags
    {
        None = 0,
        Ren = 1 << 0,
        Yaoh = 1 << 1,
        Shenzu = 1 << 2,
        Mogui = 1 << 3
    }
}
