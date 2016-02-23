20080416 - Rewrite of the UI preview with all-new screenshots: [LOMM20](LOMM20.md)

_<sub>Side note: SVN is driving me batty. No IDE integration (unless I buy a plugin) is not helping. Bugs in Tortoise (the shell integration client) are horrible and pervasive.</sub>_

**News on 2.0**

Update 20080416:

The patch notes for Rohyren book 13 just came out (http://forums.lotro.com/showthread.php?t=132767 - note that these are not the final patch notes for release and anything may change). I have a lot of work to do: new emotes (/flip), new monsterplay-only commands (/tr replaces /k, etc.), new ABC support (tuples in two forms, stepped dynamic support, and X tag support for multiple tunes per file). The X tag support is especially welcome, but means a noticeable rework on my part.

As such, I'm _hoping_ to launch 2.0 right after book 13. The macro UI us just about done, so I'm almost there other than the ABC changes. I do need to get on Rohyren and check out the slash commands and so forth (the book 13 preview has been pushed back by a day or two due to corrupted data files).

Note that X support means that only the first tune in a file will show in LOMM 1.4, but book 13 LOTRO will play others. If you keep using 1.4, break your ABC files into one for each tune, like you had to do prior to book 13.

Update 20080404:

After several weeks of workworkwork, I am back in the saddle. I'll get the new emote system wrapped up (it just needs better UI around it now and my gf and I designed the UI) and close out the changes to playing lyrics. I'm checking in (functional but incomplete) code if anyone wants to take a gander.

Update 20080310:

Getting very close to a release candidate. Remaining items are the (now designed) UI for editing custom emotes, changing the UI for lyrics to a much better one my gf designed, and some random cleanup, such as toggling a boatload of new options: keeping LOTRO sounds playing while LOMM (or any other app) has focus, highlighting which ABC elements and _maybe_ in what color/font, etc.

I will probably not include my super-spiffy detached radial menu feature in the interest of getting the new emotes to you sooner. I also have backed off of highlighting chords with mis-matched length. It is highlighting chords, though. All MyLotroBand integration is probably pushed to 2.1.

The all-new emote system is looking good. I have test emotes that do some fun things. One says a line of text randomly from a list, with different weightings--e.g., says `"Help me, this ;target is slowing down my chance to inspire you!"` or `"Please distract the ;target so I can keep you fighting!"` and _occasionally_ says `"Ack! ;target! Not in the hands! Hit my face, please! OhhelpmeOhhelpmeit'sbreakingmylute...."`. Another activates a hotkey while saying some text (e.g., uses Bolster Courage and send the text `"/t ;target Heal Incoming (~650)"`). A third presses two hotkeys in a row (the most you can queue up), such as my morning Tale of Warding and War-speech, or mine a node and get back on the pony.

Update early March:

I'm hard at work on version 2.0. The new UI is coming along nicely and various requests from the forums are already in. I'm working with Warden over at MyLotroBand to integrate downloading and uploading abc files (we have downloading done as of 03/01). The new emote system is the next step, along with some final UI cleanup (there will finally need to be an options dialog, for example). I'm also hoping to make some options per-character, rather than per-account, since custom emotes are likely to be character-specific. I'm hoping to have a "preview edition" (not feature complete, depending on real life commitments and coordinating with people) by the 10th. I should put up some screen shots of the full new UI sooner than that.

I would suggest that people download 1.0.4 still and upgrade later, rather than wait for 2.0.

[2.0 tracking link.](http://code.google.com/p/lomm/issues/list?can=1&q=Milestone:Release2.0&sort=Status%20Feature%20priority%20Component%20Status%20ID&colspec=ID%20Priority%20Feature%20Component%20Status%20Summary#)

**Latest version: 1.0.4**
  * Recurses subdirectories for abc files and plays out of subdirectories.
  * New UI for handling synced play: the "Play" button is now a split button and you can switch it to "Wait to play" or execute a "Start group" command. All other ui around this (menus and the button/checkbox combo) are gone.
  * Keeps focus after any command that doesn't start music playing.
  * Shows unix files properly (and saves them as MSDOS files)
  * Tooltips on the list of abc files. This is 100% useless, causes reloading the list to be slower, and uses a little bit more memory, but it was fun to do.

---

### Features under active development ###
Check out the proposed new UI: [LOMM20](LOMM20.md)
> _**Lyrics**_ This looks like it will be a window with the full ABC, but with the lyric lines highlighted. A button will send the lyric line to the chosen channel (/say, /f, /ra, /local, /rpc) and select the next lyric line. The rest of the ABC is there (grayed out) to help with timing.
    * Currently, the hard part is designing a good UI for lyrics playing.
> _**Illegal pitch detection**_ This was a feature request. Search for and highlight pitches outside the general LOTRO range. LOTRO will tell you this, but only for the first illegal pitch it finds. Just for the fun of it, I _think_ this is the regex that describes most non-degenerate illegal pitches:
```
(?'low'_+C,)|(?'low'[A-G],{2,})|(?'low'_+c,,)|(?'low'[a-g],{3,})|(?'high'[abd-g]'+)|(?'high'\^+c')|(?'high'[ABD-G]'{2,})|(?'high'C'{3,})|(?'high'\^+C'')
```
    * Degenerate illegal pitches are ones needing more than two sharps or two flats, such as `___B,` (low B triple-flat) and `^^b`.
> _**Minimize to an emotes menu**_ This will minimize to a small menu with just emotes on it. Ideally, it will be a circle you can float over the radar window border (like many WoW addons) and will pop out a radial menu. I'm hoping to include an editor for this so you can add custom expressions.
    * One goal is to make in-party emotes (/OOP, /Wait, /Charge, etc.) convenient to use
    * Another goal is to allow for more character flavor (like my hobbit's farewell statement, "May your victories be great--but your victory feasts greater.")
    * And finally, there are a bunch of things I've made into ;shortcuts, like how to play an instrument or how to get to certain commonly-sought places. Managing these is a PITA in-game.
> _**Custom Emotes**_ The emotes bar will still have all the emotes it currently does, but you'll be able to add and remove items from it, as well as to group items in your own preferred way. Items you create have some options:
    * Send a line to text to any channel (/f, /say, /k, /ra, etc.)
    * Send any slash command or alias
    * Press any hotkey you've mapped in the options
    * Perform several of these in a chosen order (but without delays, so you can't queue up three hotkeys, for example)
Some examples:
    * "/say Healing ;target for ~660" and then press the hotkey for Quickbar 1, button 10
    * "/scold" five times
    * Perform a bunch of emotes that bestow titles or abilities and do each the maximum number of times rewarded per day (but really, that's a lot of items!)
    * Press Quickbar 5, button 2, button 3, button 4, and button 5 in sequence (for me, that activates the chat log, Track Ore, Tale of Warding, and War Speech, which is my usual "back from dead" or "just logged in" sequence; all of these can be queued instantly because the first three do not go on the skill queue)
    * Say "Help! Minstrel in trouble and taking extreme measures" and press Quickslot 3, button 3 and Quickslot 3, button 2 (which activate Lay of the Hammerhand and Still as Death)
    * Say ";target is getting extreme measures" and activate Gift of the Hammerhand, an instant heal, and a fast heal. I have to hit the longer heal manually because the skill queue is full (and the fast heal may not have happened, depending on the cooldown status of the instant heal)
    * Say "And that's how we do it", equip a horn (via a quickslot button), start /music, and play the ABC file "Victory Dance.abc"
    * Say "Healing time!", equip the theorbo, and cancel War Speech. Note that this will activate War Speech if it wasn't active. This is a limitation of the LOTRO slash command and quickslot system (other games have added specific slash commands or macro items to enable this kind of thing)

---

## Changelog ##
    * 1.0.4 - 20080117 - Recurses subdirectories for abc files and plays out of subdirectories. New UI for handling synced play: the "Play" button is now a split button and you can switch it to "Wait to play" or execute a "Start group" command. All other ui around this (menus and the button/checkbox combo) are gone. Unix file handling and conversion. Keeps focus after a command that doesn't play music. Tooltips on the list of abc files--100% useless, causes reloading the list to be slower, and uses a little bit more memory, but it was fun to do.
    * 1.0.3 - 20080113 - All emotes used to grant new emotes or titles along with the # of times per day they add to the deed and what they grant (list cheerfully stolen from [The Dawnsong Explorers](http://www.dawnsong.org/LotRO/guides/emotes.htm))
    * 1.0.2 - 20080108 - Original release
    * 1.0.1 - (bad version label)
    * 1.0.0 - 20080107 - Preview release for feedback

---