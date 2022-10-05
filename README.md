# 2k23Extractor

## Instructions for finding addresses

1. open up cheat engine and 2k, start a play now game
1. open tabs for home/away team score (after they score so faster than searching for 2 byte 0) and time remaining (if you do before tip, you can search for exact value of 720 as 2 byte int)
1. search for home and away team nickname and go to team comparison stats in game… see which is being read (usually second to last one of the last addresses returned) - that is the static address
1. run out of bounds with players to get turnovers (mainly with home PG to isolate) - scan between each for home PG's turnovers - should get down to an address - can verify by going into box score in pause menu and editing - should see turnovers change when you edit in cheat engine

home roster:
1. when a new turnover happens, be using F6 (what writes to) in cheat engine to see pointer going to turnovers, then use more info
1. do the same to find first level pointer - possibly just scan for the value from more info in above step
1. now you should have an address that the static player is referring to - so you can scan a range of addresses around the address that you got up in line 4 (finding last name of home PG) - this should reveal what ultimately gets to stats
1. that pointer that goes to stats is called DynamicPlayerPointer in the player class - so it's usually easiest to get that working in extractor and then you can easily find that location for any player
1. from there, I usually just let a game sim, which will fill out stats for guys, then at end of game, find a player that has a lot of different stats (so everything isn't just zeros, and search the ~25000 bytes after that in cheat engine for one of the bigger/more unique values
1. so say a guy has like 11 points, search from DynamicPlayerPointer to DynamicPlayerPointer+25000 (61A8 in hex).
1. the "first" of the stats usually shows up around 22000 after DynamicPlayerPointer, so you could probably limit the lower bound of the search and start there.
1. The spacing between stats is usually identical or very close, so for example if you find points, FTM is 4 bytes after that and then all of the other FT/2P/3P stuff is separated by 2 bytes for that - so it isn't like you have to search for everything
1. Usually I'll just kind of go by what they were previously separated by (in last year's game), plug all of those numbers in relative to the points stat and see if it looks good. Usually some stats/groups of stats will need to have something extra added to them because they added another value or two to whatever class behind the scenes
1. For harder to find ones, it is helpful to bring up stats>box score in 2k and then, say you have a guy with 2 dunks - search that whole segment of 22000-25000 after DynamicPlayerPointer for 2, and then that will probably return maybe 10 or so values, just start changing them in cheat engine and see which one changes the dunks value in box score - then you found your winner
1. There are some stats (fast break points, points in the paint, etc.) which don't show up in box score, so it makes them more difficult to find. Usually I'll use the values relative to previous version in the first release, see if they're looking right and then if not, have to go into the game, put it on rookie difficulty and then just score from those different places (like score 2, points in paint, search for 2, score another 2 points in paint, search for 4, score 2 not in paint, search for 4 again) - and then you should get it down to 1 address pretty quickly
