using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

// COMMENT ADDED FOR GITHUB REASONS LOL

namespace NPC_CREATOR
{
    class Application
    {
        static int Main(string[] args)
       {
            //NPCManager npcManager = NPCManager.Instance();
            bool shouldExit = false;
            string listPath = "NpcList.json";
            string npcListJson;
            List<NPC> npcList;
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            
            try
            {
                //File.ReadAllText(listPath) != null;
                //string listData = File.ReadAllText(listPath);
                npcListJson = File.ReadAllText(listPath);
                npcList = JsonSerializer.Deserialize<List<NPC>>(npcListJson);
                NPCManager.PopulateFromList(npcList);
                Console.WriteLine("[WELCOME TO NPC_CREATOR!]\nSuccesfully Loaded File: " + listPath + "\n");

            }
            catch
            {
                Console.WriteLine("[WELCOME TO NPC_CREATOR!]\n[WARNING] : 'npcList.json' Not Found!\nStart New List? (Y/N)\n");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    Console.WriteLine("Starting New List\n");
                    npcList = new List<NPC>();
                }
                else
                {
                    Console.WriteLine("PRESS ANY KEY TO EXIT");
                    return 0;
                }
                //npcListJson = JsonSerializer.Serialize(npcList);
                //File.WriteAllText(listPath, jsonString);

                //string jsonString = File.ReadAllText(listPath);
                //NPClist = JsonSerializer.Deserialize<List<NPC>>(jsonString);
                //File.WriteAllText(listPath, jsonString);
            }

            // MAIN LOOP
            while(!shouldExit)
            {
                Console.WriteLine("(1) Enter 'NEW' to add new Npc\n(2) Enter 'W' to view list contents\n(3) Enter 'CLEAR' to erase list data from file\n");
                string inputStr = Console.ReadLine().ToUpper();
                if (inputStr == "W")
                {
                    Console.WriteLine(File.ReadAllText(listPath));
                }
                else if (inputStr == "CLEAR")
                {
                    Console.WriteLine(listPath + " Contents Cleared" +
                        "");
                    npcListJson = JsonSerializer.Serialize(npcList, options);
                    File.WriteAllText(listPath, npcListJson);
                }
                else if (inputStr == "NEW")
                {
                    Console.WriteLine("NPC_ENUM Options: NPC_DEFAULT, NPC_PASSIVE, NPC_HOSTILE\n Enter an NPC_ENUM");
                    inputStr = Console.ReadLine().ToUpper();
                    NPCManager.CreateNew(inputStr);
                }
      
                Console.WriteLine("\nExit NPC_Creator? (Y/N)");
                if (Console.ReadLine().ToUpper() == "Y")
                    shouldExit = true;
            }

            //SHUTDOWN
            npcListJson = JsonSerializer.Serialize(npcList, options);
            File.WriteAllText(listPath, npcListJson);
            return 0;
        }
        
    }
}
