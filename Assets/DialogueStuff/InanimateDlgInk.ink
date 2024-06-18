EXTERNAL ExitDialogue()
EXTERNAL GiveItem()

-> start

=== start ===
It's an inanimate fuckin' object.
* [Take item.]
    ~ GiveItem()
    -> itemTaken

* [Goodbye.]
    ~ ExitDialogue()
    ->END

=== itemTaken ===
You have taken an item, how dare you?
* [Thanks, goodbye.]
    ~ ExitDialogue()
    ->END
    

