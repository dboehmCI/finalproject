
# Final Project - Comp 437 Bug List
Known Bugs for Final Project Submission.
(All Bugs I am aware of that could not be fixed in time)


![#f03c15](https://placehold.it/15/f03c15/000000?text=+)  Important Known Bugs
- Project Resolution Not Saving: When downloading the file uploaded to GitHub and launching in Unity. The Custom Aspect Resolution is not saved. IMPORTANT: If observing the Project in Unity, Create a Custom Aspect Ratio of 375 : 667

- Reference Exception Error: There is an animation being played on Dots that are Connected called RunDotAnimation. When a player loads a new scene/new level whether by clearing a level or failing and trying again this error occurs. On the first playthrough, players will be able to click the dot and watch the pulse animation occur, after that the game still functions but the player will not see the animation.

- Demo Build Windowed Only Error : To resolve an issue with unwanted screen resolutions, the game must be played in Windowed Mode. I've created a script that will set the proper resolution upon loading a level; however, this only works if the game is set to windowed mode before playing.

