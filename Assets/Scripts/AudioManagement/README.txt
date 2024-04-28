Hi, heres how to use the audio manager

1) Make sure it is in the scene

2) Access it with AudioManager.SharedInstance

3) use .PlayMusic(Song Name), .PlaySoundEffect(Sound effect name), or .PlayVoiceLine(voice line name)

To add a new sound effect or song, go to the respective managaer in the children
of the AudioManager.

1) drag in a new BGTrack or SoundEffect from the prefabs folder in the AudioManagement scrips folder

2) set the variables

3) it can now be called using the name you set using the first part of this doc