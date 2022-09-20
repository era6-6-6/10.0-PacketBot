using FunnyProject.UserCollections.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.UserCollections
{
    public class Players
    {

        public List<Player> AllPlayers = new();
        public List<Player> AllyPlayers = new();
        public List<Player> Npcs = new();
        public List<Player> EnemyPlayers = new(); 
        
        public void Add(Player player , bool enemy)
        {
            lock (AllPlayers)
            {
                AllPlayers.Add(player);
                if(player.IsNpc)
                {
                    lock (Npcs)
                    {
                        Npcs.Add(player);
                        return;
                    }
                }
                else if(enemy)
                {
                    lock (EnemyPlayers)
                    {
                        EnemyPlayers.Add(player);
                        return;
                    }
                }
                else
                {
                    lock (AllyPlayers)
                    {
                        AllyPlayers.Add(player);
                        return;
                    }
                }
            }
            
        }
        public void Remove(int id)
        {
            Player? player = null;
            lock (AllPlayers)
            {
                player = AllPlayers.Find(x => x.ID == id);
            }
            if(player != null)
            {
                lock (AllPlayers)
                {
                    AllPlayers.Remove(player);
                }
                if(player.IsNpc)
                {
                    lock(Npcs)
                    {
                        Npcs.Remove(player);
                    }
                    
                }
                else
                {
                    lock(EnemyPlayers)
                    {
                        EnemyPlayers.Remove(player);
                    }
                    lock(AllyPlayers)
                    {
                        AllyPlayers.Remove(player);
                    }
                }

            }
            
            
        }
    }
        
    
}
