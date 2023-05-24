using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pokedex
{
    public class Pokemon
    {
        
        // Very important variables!
        public Image pokemonImage;
        public int PokedexNumber;
        public string Description;
        public string Gen6Ability;
        public string Location;
        public string Name;
        public string PokemonAbility;
        public string PokemonAbility2;
        public Types PokemonType1;
        public Types? PokemonType2;

        // Stats
        public decimal Height = 0;
        public decimal Weight = 0;
        public int BaseHP, BaseAttk, BaseDef, BaseSPA, BaseSpD, BaseSpeed;
        public int iv = 31;

        // Generations
        public int Generation4 = 4;
        public int Generation5 = 5;
        public int Generation6 = 6;
        public string HiddenAbility;

        // Types
        public enum Types
        {
            Bug,
            Dark,
            Dragon,
            Electric,
            Fairy,
            Fighting,
            Fire,
            Flying,
            Ghost,
            Grass,
            Ground,
            Ice,
            Normal,
            Poison,
            Psychic,
            Rock,
            Steel,
            Water
        }

        // Abilities
        public enum Ability
        {
            Adaptability,
            Aerilate,
            Aftermath,
            AirLock,
            Analytic,
            AngerPoint,
            Anticipation,
            ArenaTrap,
            AromaVeil,
            AuraBreak,
            BadDreams,
            BattleArmor,
            BigPecks,
            Blaze,
            Bulletproof,
            CheekPouch,
            Chlorophyll,
            ClearBody,
            CloudNine,
            Competitive,
            CompoundEyes,
            Contrary,
            CursedBody,
            CuteCharm,
            Damp,
            DarkAura,
            Defaint,
            Defeatist,
            DeltaStream,
            DesolateLand,
            Download,
            Drizzle,
            Drought,
            DrySkin,
            EarlyBird,
            EffectSpore,
            FairyAura,
            Filter,
            FlameBody,
            FlareBoost,
            FlashFire,
            FlowerGift,
            FlowerVeil,
            Forecast,
            Forewarn,
            FriendGuard,
            Frisk,
            FurCoat,
            GaleWings,
            Gluttony,
            Gooey,
            GrassPelt,
            Guts,
            Harvest,
            Healer,
            Heatproof,
            HeavyMetal,
            HoneyGather,
            HugePower,
            Hustle,
            Hydration,
            HyperCutter,
            IceBody,
            Illuminate,
            Illusion,
            Immunity,
            Imposter,
            Infiltrator,
            InnerFocus,
            Insomnia,
            Intimidate,
            IronBarbs,
            IronFist,
            Justified,
            KeenEye,
            Klutz,
            LeafGuard,
            Levitate,
            LightMetal,
            LightningRod,
            Limber,
            LiquidOoze,
            MagicBounce,
            MagicGuard,
            Magician,
            MagmaArmor,
            MagnetPull,
            MarvelScale,
            MegaLauncher,
            Minus,
            MoldBreaker,
            Moody,
            MotorDrive,
            Moxie,
            Multiscale,
            Multitype,
            Mummy,
            NaturalCure,
            NoGuard,
            Normalize,
            Oblivious,
            Overcoat,
            Overgrow,
            OwnTempo,
            ParentalBond,
            Pickpocket,
            Pickup,
            Pixilate,
            Plus,
            PoisonHeal,
            PoisonPoint,
            PoisonTouch,
            Prankster,
            Pressure,
            PrimoridalSea,
            Protean,
            PurePower,
            QuickFeet,
            RainDish,
            Rattled,
            Reckless,
            Refrigerate,
            Regenerator,
            Rivalry,
            RockHead,
            RoughSkin,
            RunAway,
            SandForce,
            SandRush,
            SandStream,
            SandVeil,
            SapSipper,
            Scrappy,
            SereneGrace,
            ShadowTag,
            ShedSkin,
            SheerForce,
            ShellArmor,
            ShieldDust,
            Simple,
            SkillLink,
            SloarPower,
            SlowStart,
            Sniper,
            SnowCloak,
            SnowWarning,
            SolidRock,
            Soundproof,
            SpeedBoost,
            Stall,
            StanceChange,
            Static,
            Steadfast,
            Stench,
            StickyHold,
            StormDrain,
            StrongJaw,
            Sturdy,
            SuctionCups,
            SuperLuck,
            Swarm,
            SweetVeil,
            SwiftSwim,
            Symbiosis,
            Synchronize,
            TangledFeet,
            Technician,
            Telepathy,
            Teravolt,
            Thickfat,
            TintedLens,
            Torrent,
            ToughClaws,
            ToxicBoost,
            Trace,
            Traunt,
            Turboblaze,
            Unaware,
            Unburden,
            Unnerve,
            VictoryStar,
            VitalSpirit,
            VoltAbsorb,
            WaterAbsorb,
            WaterVeil,
            WeakArmor,
            WhiteSmoke,
            WonderGuard,
            WonderSkin,
            ZenMode
        }

        // Natures
        public enum Natures
        {
            Adamant,
            Bashful,
            Bold,
            Brave,
            Calm,
            Careful,
            Docile,
            Gentle,
            Hardy,
            Hasty,
            Impish,
            Jolly,
            Lax,
            Lonely,
            Mild,
            Modest,
            Naive,
            Naughty,
            Quiet,
            Quirky,
            Rash,
            Relaxed,
            Sassy,
            Serious,
            Timid
        }

        public enum Category
        {
            Physical,
            Special,
            Status
        }

        public Pokemon(Image imageReference, int number)
        {
            pokemonImage = imageReference;
            PokedexNumber = number;
        }
    }
}

