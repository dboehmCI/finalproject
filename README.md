# Final Project - Comp 437

Final Project: List of “To-Do’s”


![#f03c15](https://placehold.it/15/f03c15/000000?text=+)  Week 4/26 - 5/3
-         Complete the Main Menu Scene and Implement Sounds. (Complete)

  - Comments: I ended up breaking the AudioManager for my sounds, so I am currently correcting the audio. Implemented the "hover-over" audio sound for the menu options. When the mouse hovers over the menu ui, there will be a sound that plays. Need to correct the BGM audio + the level BGM transition.
  - Update (5/16/18):  (FIXED) [BUG: Audio stops on scene transitions] - I am unsure as to why but ALL audio including sound effects stop working after a scene transition has occurred. It is weird because this does not occur when loading each scene individually, only when a scene transition occurs. I am not sure if this bug will be fixed by deadline, I will need to come back to this.
    - [BUG Fixed]: Corrected the Fading Script & SwitchMusicOnLoad Audio variables for fading in/out. Fading Script originally faded out music between scenes using a Lerp Tween on the AudioListerner.volume; however, that AudioListener did not have a 'fade in' on new level loading. Added this functionality to resolve.

![#c5f015](https://placehold.it/15/c5f015/000000?text=+)  Week 5/3 - 5/10

-          Complete Game Sounds (Connecting Dots SFX, Scoring, Game Over, etc) (Complete)
  - Update (5/5/18): Completed the Main Menu BGM Sound. Completed the Settings Functionality for the Main Menu Sound Volume,  User can adjust the volume of the BGM & Sound Effects used in the Main Menu areas. 
  
  - Update (5/5/18): Fixed [BUG : BGM only playing on Settings Page]
  - Update (5/16/18): Unable to get the Music/Sound Effects to Play After loading a new scene.
  

-          Create main menu text for the name of the game. (Completed)

  - Update (5/9/18): Reconstructing the Main BG:
    - Created the Main Main Text "LOGO"
    - Created a Universal BG for all the Main Menu Option transitions.
    - Prepped the BG for the Menu Animation (Circles spinning by Thursday).
    - Starting work on the drag and click functionality of the menu.
    - Cleaned up the Font
      - All Font for the Main Menu UI will now be utilizing 'Pacifico' for transparency.
      

-          Create a “Level Cleared” (Complete)
  -  Update (5/17/18): Level Cleared Screens appears after each level objective has been completed. Player then can click the next level button to advance.

-          Create a “Game Over” Screen (Complete)

-          Complete the Tutorial “How-to” option (Complete)
  - Update (5/17/18): Implemented the Tutorial How To Option on Main Menu. Slides show the player a quick 'how-to' of the game.
  - Update (5/10/18): Created the UI "How-To-Play" Button and Canvas Menu. Still working on implementing the best method to introduce the tutorial version of the game; whether to use scrollable images, a video demo, or demo scene. Pushing the tutorial mode to the last week.

-          Create a Fade-In (Load) (Complete)
  - Update (5/10/18): Currently Fades White. Still working on a polished version of the game.
  - Update (5/10/18): Scene Transitions are currently fading correctly. Still needing to implement a level 'pause' that allows the animation of the fading to complete before the level actually starts; providing enough time for the player to witness the transition and then be ready to play.
  - Update (5/11/18): Changed the Transition Time to 8 seconds. Also created a delayed period of 8 seconds to allow the transition of the fade to complete before the actual game begins. 

-          Opening Menu Animation (Circles Loading) (Complete)
  - Update (5/10/18): Added the Animation Circles. 


![#1589F0](https://placehold.it/15/1589F0/000000?text=+)  Week 5/10 - 5/17

-          Progress of game from Last Play should be saved.

-          Create Multiple Levels (Complete)
-          Add Objective Tasks Prior to Levels Loading (Complete)
  - Get a score of 10
  - Get a score of 20
  - Get a score of 30


