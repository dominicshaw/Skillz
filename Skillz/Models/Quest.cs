﻿using System.Collections.Generic;

namespace Skillz.Models
{
    public class Quest
    {
        public string Name { get; set; }

        public List<Quest> PrerequisteQuests { get; } = new List<Quest>();
        public Dictionary<SkillTypes, int> PrerequisteSkills { get; } = new Dictionary<SkillTypes, int>();

        public Quest()
        {

        }

        public void SetPrequesite(Quest quest)
        {
            if (PrerequisteQuests.Contains(quest))
                return;
            PrerequisteQuests.Add(quest);
        }

        public void SetPrequesite(SkillTypes skill, int level)
        {
            if (PrerequisteSkills.ContainsKey(skill))
                PrerequisteSkills[skill] = level;
            else
                PrerequisteSkills.Add(skill, level);
        }
    }

    public class Quests
    {
        private Dictionary<string, Quest> _quests = new Dictionary<string, Quest>();

        public Quests()
        {
            var jungle = new Quest()
            {
                Name = "Jungle Potion",
                PrerequisteSkills =
                {
                    { SkillTypes.Agility, 5 }
                }
            };

            var slayer = new Quest()
            {
                Name = "Slayer Slayer",
                PrerequisteSkills =
                {
                    { SkillTypes.Attack, 45 },
                    { SkillTypes.Construction, 42 }
                },
                PrerequisteQuests = { jungle }
            };

            _quests.Add(jungle.Name, jungle);
            _quests.Add(slayer.Name, slayer);
        }
    }
}