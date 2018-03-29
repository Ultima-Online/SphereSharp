﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SphereSharp.ServUO.Sphere._Global;

namespace SphereSharp.ServUO.Sphere
{
    public partial class _Global
    {
        public const int SKILL_VARIANCE = 100;		// Difficulty modifier for determining success. 10.0 %
    }

    public abstract partial class CObjBase : CObjBaseTemplate
    {
        public HUE_TYPE m_SpeechHue;    // previous Client select speech hue. or npc selected.
        public FONT_TYPE m_fonttype;	// Speech font to use // can client set this ?

        public CCharActState m_Act = new CCharActState();


        public virtual void Speak(string pText, HUE_TYPE wHue, TALKMODE_TYPE mode, FONT_TYPE font)
        {
            g_World.Speak(this, pText, wHue, mode, font);
        }

        public abstract void OnSpellEffect(SPELL_TYPE spell, CChar cChar, int iSkillLevel, CItem cItem);
    }

    public abstract class CObjBasePtr : CObjBase
    {
        public CObjBasePtr(int serial) : base(serial)
        {
        }
    }

    public partial class CChar
    {
        public StatsArray m_Stat;		// karma is signed. (stats should be able to go temporariliy negative !)
        public STAT_LEVEL m_StatMana { get => m_Stat[STAT_TYPE.STAT_Mana]; set => m_Stat[STAT_TYPE.STAT_Mana] = value; }
        public STAT_LEVEL m_StatMaxMana { get => m_Stat[STAT_TYPE.STAT_MaxMana]; set => m_Stat[STAT_TYPE.STAT_MaxMana] = value; }

        public bool IsGM()
    
	    {
            // TODO:
            // return(IsPrivFlag(PRIV_GM));

            return false;
	    }

        public SKILL_TYPE Skill_GetActive()
    
	    {

		    return(m_Act.m_SkillCurrent );

	    }

        public bool IsSkillBase(SKILL_TYPE skill) // static

        {

            // Is this in the base set of skills.

            return (IS_SKILL_BASE(skill));

        }

        public bool IS_SKILL_BASE(SKILL_TYPE sk) => ((sk) >= SKILL_TYPE.SKILL_First && (sk) < SKILL_QTY);

        public SKILL_LEVEL Skill_GetBase(SKILL_TYPE skill)
  
	    {


            ASSERT(IsSkillBase(skill));

		    return(m_Skill[(int)skill] );
	    }

        SkillsArray m_Skill;	// List of skills ( skill* 10 ) (might go temporariliy negative!)

        public class SkillsArray
        {
            STAT_LEVEL[] m_Skill = new STAT_LEVEL[(int)SKILL_QTY];  // List of skills ( skill* 10 ) (might go temporariliy negative!)
            private CChar cChar;

            public SkillsArray(CChar cChar)
            {
                this.cChar = cChar;
            }

            public STAT_LEVEL this[int skillNum] => (STAT_LEVEL)this.cChar.mobile.Skills[skillNum].Fixed;
        }

        public class StatsArray
        {
            private CChar cChar;

            public StatsArray(CChar cChar)
            {
                this.cChar = cChar;
            }

            public STAT_LEVEL this[STAT_TYPE statType]
            {
                get
                {
                    switch (statType)
                    {
                        case STAT_TYPE.STAT_Mana:
                            return this.cChar.mobile.Mana;
                        case STAT_TYPE.STAT_MaxMana:
                            return this.cChar.mobile.ManaMax;
                        case STAT_TYPE.STAT_Str:
                            return this.cChar.mobile.Str;
                        case STAT_TYPE.STAT_Int:
                            return this.cChar.mobile.Int;
                        case STAT_TYPE.STAT_Dex:
                            return this.cChar.mobile.Dex;
                        default:
                            throw new NotImplementedException($"STAT_TYPE {statType}");
                    }
                }

                set
                {
                    switch (statType)
                    {
                        case STAT_TYPE.STAT_Mana:
                            this.cChar.mobile.Mana = value;
                            break;
                        default:
                            throw new NotImplementedException($"STAT_TYPE {statType}");
                    }
                }
            }
        }

    }
}
