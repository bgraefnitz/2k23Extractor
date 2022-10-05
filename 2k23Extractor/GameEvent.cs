﻿using System;


namespace _2k23Extractor
{
    [Serializable] 
    public class GameEvent
    {
        public string GameStatus;
        public string Team;
        public string Player;
        public string StatChange;

        public GameEvent(string gameStatus, string team, string player, string statChange)
        {
            GameStatus = gameStatus;
            Team = team;
            Player = player;
            StatChange = statChange;
        }
    }
}
