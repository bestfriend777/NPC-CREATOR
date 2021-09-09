using System;
using System.Collections.Generic;
using System.Text;


namespace NPC_CREATOR
{
    public enum NPC_ENUM
    {
        NPC_DEFAULT = 0,
        NPC_PASSIVE = 1,
        NPC_HOSTILE = 2,
    }

    class NPCManager
    {
        static NPCManager instance;

        static List<NPC> m_NpcList;

        NPCManager() // The Constructor is private because this class is written using the "singleton" technique... Its confusing but very useful
        {
            // NPCManager Constructor
        }

        public static NPCManager Instance()
        {
            if(instance == null)
            {
                instance = new NPCManager();
            }

            return instance;
        }

        // uint (unsigned integer) is a data type that represents an integer that MUST be positive (AKA it has no negative sign (-) so its 'unsigned')
        public static void CreateNew(string npcType)  
        {
            if (m_NpcList == null)
                m_NpcList = new List<NPC>();

            try
            {
                NPC_ENUM type = (NPC_ENUM)Enum.Parse(typeof(NPC_ENUM), npcType, true);

                switch (type)
                {
                    case NPC_ENUM.NPC_DEFAULT:
                        m_NpcList.Add(new NPC());
                        Console.WriteLine("Added New NPC_DEFAULT\n");
                        break;
                    case NPC_ENUM.NPC_PASSIVE:
                        m_NpcList.Add(new PassiveNPC());
                        Console.WriteLine("Added New NPC_PASSIVE\n");
                        break;
                    case NPC_ENUM.NPC_HOSTILE:
                        m_NpcList.Add(new HostileNPC());
                        Console.WriteLine("Added New NPC_HOSTILE\n");
                        break;
                }
            }
            catch(ArgumentException)
            {
                Console.WriteLine(npcType + " Is Not a Valid NPC_ENUM\n");
            }
        }

        public static void PopulateFromList(List<NPC> list)
        {
            m_NpcList = list;
        }

        // END OF CLASS
    }
}
