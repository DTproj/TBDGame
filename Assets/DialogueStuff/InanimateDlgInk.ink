EXTERNAL ExitDialogue()

-> start

=== start ===
It's an inanimate fuckin' object.
* [Take item.]
    -> itemTaken

* [Goodbye.]
    ~ ExitDialogue()
    ->END

=== itemTaken ===
You have taken an item, how dare you?
* [Thanks, goodbye.]
    ~ ExitDialogue()
    ->END
    

