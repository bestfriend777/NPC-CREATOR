using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace NPC_CREATOR
{
    public class PassiveNPC : NPC
    {
        public bool m_HasDialogue { get; set; }

        public PassiveNPC()
        {
            BuildDialogue();
        }

        public void BuildDialogue()
        {
            Console.WriteLine("USE DEFAULT CONSTRUCTOR? (Y/N)\n");
            string isDefault = Console.ReadLine().ToUpper();

            if(isDefault == "Y")
            {
                m_Name = "NpcHostile";
                m_Size = new float[3] { 1.0f, 1.0f, 1.0f };
                m_Speed = 0.1f;
            } 
            else if(isDefault == "N")
            {
                Console.WriteLine("m_Name = ");
                m_Name = Console.ReadLine();
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("m_Size[" + i + "]");
                    m_Size[i] = (float)(Convert.ToDouble(Console.ReadLine()));
                }

                Console.WriteLine("m_Speed = ");
                m_Speed = (float)(Convert.ToDouble(Console.ReadLine()));

                Console.WriteLine("m_HasDialogue = ");
                m_HasDialogue = Convert.ToBoolean(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("INVALID INPUT\n");
            }
            
        }

    }
}
